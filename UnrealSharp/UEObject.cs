using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace UnrealSharp
{
    public class Array<T> : UEObject
    {
        public Array(UEObject obj) : base()
        {
            Address = obj.Address;
            _classAddr = obj.ClassAddr;
            _substructAddr = obj._substructAddr;
        }

        public Array(nint addr) : base(addr)
        {
        }

        public Array(nint addr, nint classAddr) : base(addr)
        {
            _classAddr = classAddr;
        }

        public int Num
        {
            get
            {
                if (_num != int.MaxValue) return _num;
                _num = UnrealEngine.Memory.ReadProcessMemory<int>(Address + 8);
                if (_num > 0x20000) _num = 0x20000;
                return _num;
            }
        }

        public Byte[] ArrayCache
        {
            get
            {
                if (_arrayCache.Length != 0) return _arrayCache;
                _arrayCache = UnrealEngine.Memory.ReadProcessMemory(Value, Num * 8);
                return _arrayCache;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= Num) return (T)Activator.CreateInstance(typeof(T), (nint)0);
                return (T)Activator.CreateInstance(typeof(T), (nint)BitConverter.ToUInt64(ArrayCache, index * 8));
            }
        }

        public T this[int index, bool t]
        {
            get
            {
                if (typeof(T).IsAssignableTo(typeof(UEObject)))
                {
                    var subStructSize = 0x28; // (int)typeof(T).GetField("size").GetValue(null);
                    var obj = (T)Activator.CreateInstance(typeof(T), (nint)Value + index * subStructSize);
                    var q = obj as UEObject;
                    q._classAddr = _substructAddr;
                    obj = (T)(object)q;
                    return obj;
                }
                else
                {
                    var obj = (T)Activator.CreateInstance(typeof(T), (nint)Value + index * Marshal.SizeOf(typeof(T)));
                    return obj;
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class NamespaceAttribute : Attribute
    {
        public string name;

        public NamespaceAttribute(string name)
        {
            this.name = name;
        }
    }


    public class UEObject
    {
        public static int objectOuterOffset = 0x20;
        public static int classOffset = 0x10;
        public static int nameOffset = 0x18;
        public static int structSuperOffset = 0x40;
        public static int childPropertiesOffset = 0x50;
        public static int childrenOffset = 0x48;
        public static int fieldNameOffset = 0x28;
        public static int fieldTypeNameOffset = 0;
        public static int fieldClassOffset = 0x8;
        public static int fieldNextOffset = 0x20;
        public static int funcNextOffset = 0x20;
        public static int fieldOffset = 0x4C;
        public static int propertySize = 0x78;
        public static int vTableFuncNum = 66;
        public static int funcFlagsOffset = 0xB0;
        public static int enumArrayOffset = 0x40;
        public static int enumCountOffset = 0x48;

        static ConcurrentDictionary<nint, string> AddrToName = new ConcurrentDictionary<nint, string>();
        static ConcurrentDictionary<nint, nint> AddrToClass = new ConcurrentDictionary<nint, nint>();
        static ConcurrentDictionary<String, Boolean> ClassIsSubClass = new ConcurrentDictionary<string, bool>();
        static ConcurrentDictionary<nint, string> ClassToName = new ConcurrentDictionary<nint, string>();

        static ConcurrentDictionary<nint, ConcurrentDictionary<string, nint>> ClassFieldToAddr =
            new ConcurrentDictionary<nint, ConcurrentDictionary<string, nint>>();

        static ConcurrentDictionary<nint, int> FieldAddrToOffset = new ConcurrentDictionary<nint, int>();
        static ConcurrentDictionary<nint, string> FieldAddrToType = new ConcurrentDictionary<nint, string>();

        public static void ClearCache()
        {
            AddrToName.Clear();
            AddrToClass.Clear();
            ClassIsSubClass.Clear();
            //ClassToAddr.Clear();
            ClassFieldToAddr.Clear();
            FieldAddrToOffset.Clear();
            FieldAddrToType.Clear();
        }

        public int GetFieldOffset(nint fieldAddr)
        {
            if (FieldAddrToOffset.ContainsKey(fieldAddr)) return FieldAddrToOffset[fieldAddr];
            var offset = UnrealEngine.Memory.ReadProcessMemory<int>(fieldAddr + fieldOffset);
            FieldAddrToOffset[fieldAddr] = offset;
            return offset;
        }

        String _className;

        public String ClassName
        {
            get
            {
                if (_className != null) return _className;
                _className = GetFullPath(); // GetFullName(ClassAddr);
                return _className;
            }
        }

        public nint _substructAddr = nint.MaxValue;
        public nint _classAddr = nint.MaxValue;

        public nint ClassAddr
        {
            get
            {
                if (_classAddr != nint.MaxValue) return _classAddr;
                if (AddrToClass.ContainsKey(Address))
                {
                    _classAddr = AddrToClass[Address];
                    return _classAddr;
                }

                _classAddr = UnrealEngine.Memory.ReadProcessMemory<nint>(Address + classOffset);
                AddrToClass[Address] = _classAddr;
                return _classAddr;
            }
        }

        public UEObject(nint address = 0)
        {
            Address = address;
        }

        public Boolean IsA(nint entityClassAddr, String targetClassName)
        {
            var key = entityClassAddr + ":" + targetClassName;
            if (ClassIsSubClass.ContainsKey(key)) return ClassIsSubClass[key];
            var tempEntityClassAddr = entityClassAddr;
            while (true)
            {
                var tempEntity = new UEObject(tempEntityClassAddr);
                var className = tempEntity.GetFullPath();
                if (className == targetClassName)
                {
                    ClassIsSubClass[key] = true;
                    return true;
                }

                tempEntityClassAddr =
                    UnrealEngine.Memory.ReadProcessMemory<nint>(tempEntityClassAddr + structSuperOffset);
                if (tempEntityClassAddr == 0) break;
            }

            ClassIsSubClass[key] = false;
            return false;
        }

        public Boolean IsA(String className)
        {
            return IsA(ClassAddr, className);
        }

        public Boolean IsA<T>(out T converted) where T : UEObject
        {
            var n = typeof(T).Namespace;
            n = n.Substring(3, n.Length - 6).Replace(".", "/");
            n = "Class " + n + "." + typeof(T).Name;
            converted = As<T>();
            return IsA(ClassAddr, n);
        }

        public Boolean IsA<T>() where T : UEObject
        {
            if (Address == 0) return false;
            return IsA<T>(out _);
        }

        public static Boolean NewFName = true;

        public static String GetName(int key)
        {
            var namePtr = UnrealEngine.Memory.ReadProcessMemory<nint>(UnrealEngine.GNames + ((key >> 16) + 2) * 8);
            if (namePtr == 0) return "badIndex";
            var nameEntry = UnrealEngine.Memory.ReadProcessMemory<UInt16>(namePtr + (key & 0xffff) * 2);
            var nameLength = (Int32)(nameEntry >> 6);
            if (nameLength <= 0) return "badIndex";

            UnrealEngine.Memory.maxStringLength = nameLength;
            string result = UnrealEngine.Memory.ReadProcessMemory<String>(namePtr + (key & 0xffff) * 2 + 2);
            UnrealEngine.Memory.maxStringLength = 0x100;
            return result;
        }

        public String GetName()
        {
            return GetName(UnrealEngine.Memory.ReadProcessMemory<int>(Address + nameOffset));
        }

        public String GetShortName()
        {
            if (ClassToName.ContainsKey(ClassAddr)) return ClassToName[ClassAddr];
            var classNameIndex = UnrealEngine.Memory.ReadProcessMemory<int>(ClassAddr + nameOffset);
            ClassToName[ClassAddr] = GetName(classNameIndex);
            return ClassToName[ClassAddr];
        }

        public String GetFullPath()
        {
            if (AddrToName.ContainsKey(Address)) return AddrToName[Address];
            var classPtr = UnrealEngine.Memory.ReadProcessMemory<nint>(Address + classOffset);
            var classNameIndex = UnrealEngine.Memory.ReadProcessMemory<int>(classPtr + nameOffset);
            var name = GetName(classNameIndex);
            var outerEntityAddr = Address;
            var parentName = "";
            while (true)
            {
                var tempOuterEntityAddr =
                    UnrealEngine.Memory.ReadProcessMemory<nint>(outerEntityAddr + objectOuterOffset);
                //var tempOuterEntityAddr = Memory.ReadProcessMemory<UInt64>(outerEntityAddr + structSuperOffset);
                if (tempOuterEntityAddr == outerEntityAddr || tempOuterEntityAddr == 0) break;
                outerEntityAddr = tempOuterEntityAddr;
                var outerNameIndex = UnrealEngine.Memory.ReadProcessMemory<int>(outerEntityAddr + nameOffset);
                var tempName = GetName(outerNameIndex);
                if (tempName == "") break;
                if (tempName == "None") break;
                parentName = tempName + "." + parentName;
            }

            name += " " + parentName;
            var nameIndex = UnrealEngine.Memory.ReadProcessMemory<int>(Address + nameOffset);
            name += GetName(nameIndex);
            AddrToName[Address] = name;
            return name;
        }

        public String GetHierachy()
        {
            var sb = new StringBuilder();
            var tempEntityClassAddr = ClassAddr;
            while (true)
            {
                var tempEntity = new UEObject(tempEntityClassAddr);
                var className = tempEntity.GetFullPath();
                sb.AppendLine(className);
                tempEntityClassAddr =
                    UnrealEngine.Memory.ReadProcessMemory<nint>(tempEntityClassAddr + structSuperOffset);
                if (tempEntityClassAddr == 0) break;
            }

            return sb.ToString();
        }

        public String GetFieldType(nint fieldAddr)
        {
            if (FieldAddrToType.ContainsKey(fieldAddr)) return FieldAddrToType[fieldAddr];
            var fieldType = UnrealEngine.Memory.ReadProcessMemory<nint>(fieldAddr + fieldClassOffset);
            var name = GetName(
                UnrealEngine.Memory.ReadProcessMemory<int>(fieldType + (NewFName ? 0 : fieldNameOffset)));
            FieldAddrToType[fieldAddr] = name;
            return name;
        }

        nint GetFieldAddr(nint origClassAddr, nint classAddr, string fieldName)
        {
            if (ClassFieldToAddr.ContainsKey(origClassAddr) && ClassFieldToAddr[origClassAddr].ContainsKey(fieldName))
                return ClassFieldToAddr[origClassAddr][fieldName];
            var field = classAddr + childPropertiesOffset - fieldNextOffset;
            while ((field = UnrealEngine.Memory.ReadProcessMemory<nint>(field + fieldNextOffset)) > 0)
            {
                var fName = GetName(UnrealEngine.Memory.ReadProcessMemory<int>(field + fieldNameOffset));
                if (fName == fieldName)
                {
                    if (!ClassFieldToAddr.ContainsKey(origClassAddr))
                        ClassFieldToAddr[origClassAddr] = new ConcurrentDictionary<string, nint>();
                    ClassFieldToAddr[origClassAddr][fieldName] = field;
                    return field;
                }
            }

            var parentClass = UnrealEngine.Memory.ReadProcessMemory<nint>(classAddr + structSuperOffset);
            //if (parentClass == classAddr) throw new Exception("parent is me");
            if (parentClass == 0)
            {
                if (!ClassFieldToAddr.ContainsKey(origClassAddr))
                    ClassFieldToAddr[origClassAddr] = new ConcurrentDictionary<string, nint>();
                ClassFieldToAddr[origClassAddr][fieldName] = 0;
                return 0;
            }

            return GetFieldAddr(origClassAddr, parentClass, fieldName);
        }

        public nint GetFieldAddr(string fieldName)
        {
            return GetFieldAddr(ClassAddr, ClassAddr, fieldName);
        }

        public nint GetFuncAddr(nint origClassAddr, nint classAddr, String fieldName)
        {
            if (!NewFName) return GetFieldAddr(origClassAddr, classAddr, fieldName);
            if (ClassFieldToAddr.ContainsKey(origClassAddr) && ClassFieldToAddr[origClassAddr].ContainsKey(fieldName))
                return ClassFieldToAddr[origClassAddr][fieldName];
            var field = classAddr + childrenOffset - funcNextOffset;
            while ((field = UnrealEngine.Memory.ReadProcessMemory<nint>(field + funcNextOffset)) > 0)
            {
                var fName = GetName(UnrealEngine.Memory.ReadProcessMemory<int>(field + nameOffset));
                if (fName == fieldName)
                {
                    if (!ClassFieldToAddr.ContainsKey(origClassAddr))
                        ClassFieldToAddr[origClassAddr] = new ConcurrentDictionary<String, nint>();
                    ClassFieldToAddr[origClassAddr][fieldName] = field;
                    return field;
                }
            }

            var parentClass = UnrealEngine.Memory.ReadProcessMemory<nint>(classAddr + structSuperOffset);
            if (parentClass == classAddr) throw new Exception("parent is me");
            if (parentClass == 0) throw new Exception("bad field");
            return GetFuncAddr(origClassAddr, parentClass, fieldName);
        }

        public int FieldOffset;
        public Byte[] Data;
        public nint _value = 0xcafeb00;

        public nint Value
        {
            get
            {
                if (_value != 0xcafeb00) return _value;
                _value = UnrealEngine.Memory.ReadProcessMemory<nint>(Address);
                return _value;
            }
            set
            {
                _value = 0xcafeb00;
                UnrealEngine.Memory.WriteProcessMemory(Address, value);
            }
        }

        public T GetValue<T>()
        {
            return UnrealEngine.Memory.ReadProcessMemory<T>(Address);
        }

        public void SetValue<T>(T value)
        {
            UnrealEngine.Memory.WriteProcessMemory<T>(Address, value);
        }

        UInt64 boolMask = 0;

        public Boolean Flag
        {
            get
            {
                var val = UnrealEngine.Memory.ReadProcessMemory<UInt64>(Address);
                return ((val & boolMask) == boolMask);
            }
            set
            {
                var val = UnrealEngine.Memory.ReadProcessMemory<UInt64>(Address);
                if (value) val |= boolMask;
                else val &= ~boolMask;
                UnrealEngine.Memory.WriteProcessMemory(Address, val);
                //UnrealEngine.Memory.WriteProcessMemory(Address, value);
            }
        }

        public nint Address;

        public UEObject this[String key]
        {
            get
            {
                var fieldAddr = GetFieldAddr(key);
                if (fieldAddr == 0) return null;
                var fieldType = GetFieldType(fieldAddr);
                var offset = GetFieldOffset(fieldAddr);
                UEObject obj;
                if (fieldType == "ObjectProperty" || fieldType == "ScriptStruct")
                    obj = new UEObject(UnrealEngine.Memory.ReadProcessMemory<nint>(Address + offset))
                        { FieldOffset = offset };
                else if (fieldType == "ArrayProperty")
                {
                    obj = new UEObject(Address + offset);
                    obj._classAddr = UnrealEngine.Memory.ReadProcessMemory<nint>(fieldAddr + fieldClassOffset);
                    var inner = UnrealEngine.Memory.ReadProcessMemory<nint>(fieldAddr + propertySize);
                    var innerClass = UnrealEngine.Memory.ReadProcessMemory<nint>(inner + fieldClassOffset);
                    obj._substructAddr = UnrealEngine.Memory.ReadProcessMemory<nint>(inner + propertySize);
                    //obj._substructAddr;
                }
                else if (fieldType.Contains("Bool"))
                {
                    obj = new UEObject(Address + offset);
                    obj._classAddr = UnrealEngine.Memory.ReadProcessMemory<nint>(fieldAddr + classOffset);
                    obj.boolMask = UnrealEngine.Memory.ReadProcessMemory<Byte>(fieldAddr + propertySize);
                }
                else if (fieldType.Contains("Function"))
                {
                    obj = new UEObject(fieldAddr);
                    //obj.BaseObjAddr = Address;
                }
                else if (fieldType.Contains("StructProperty"))
                {
                    obj = new UEObject(Address + offset);
                    obj._classAddr = UnrealEngine.Memory.ReadProcessMemory<nint>(fieldAddr + propertySize);
                }
                else if (fieldType.Contains("FloatProperty"))
                {
                    obj = new UEObject(Address + offset);
                    obj._classAddr = 0;
                }
                else
                {
                    obj = new UEObject(Address + offset);
                    obj._classAddr = UnrealEngine.Memory.ReadProcessMemory<nint>(fieldAddr + propertySize);
                }

                if (obj.Address == 0)
                {
                    obj = new UEObject(0);
                    //var classInfo = Engine.Instance.DumpClass(ClassAddr);
                    //throw new Exception("bad addr");
                }

                return obj;
            }
            set
            {
                var fieldAddr = GetFieldAddr(key);
                var offset = GetFieldOffset(fieldAddr);
                UnrealEngine.Memory.WriteProcessMemory(Address + offset, value.Address);
            }
        }

        public int _num = int.MaxValue;

        public int Num
        {
            get
            {
                if (_num != int.MaxValue) return _num;
                _num = UnrealEngine.Memory.ReadProcessMemory<int>(Address + 8);
                if (_num > 0x10000) _num = 0x10000;
                return _num;
            }
        }

        public Byte[] _arrayCache = new Byte[0];

        public Byte[] ArrayCache
        {
            get
            {
                if (_arrayCache.Length != 0) return _arrayCache;
                _arrayCache = UnrealEngine.Memory.ReadProcessMemory(Value, Num * 8);
                return _arrayCache;
            }
        }

        public UEObject this[int index]
        {
            get { return new UEObject((nint)BitConverter.ToUInt64(ArrayCache, index * 8)); }
        }

        public nint _vTableFunc = 0xcafeb00;

        public nint VTableFunc
        {
            get
            {
                if (_vTableFunc != 0xcafeb00) return _vTableFunc;
                _vTableFunc = UnrealEngine.Memory.ReadProcessMemory<nint>(Address) + vTableFuncNum * 8;
                _vTableFunc = UnrealEngine.Memory.ReadProcessMemory<nint>(_vTableFunc);
                return _vTableFunc;
            }
        }

        public T Invoke<T>(String funcName, params Object[] args)
        {
            var funcAddr = GetFuncAddr(ClassAddr, ClassAddr, funcName);
            var initFlags = UnrealEngine.Memory.ReadProcessMemory<nint>(funcAddr + funcFlagsOffset);
            var nativeFlag = initFlags;
            nativeFlag |= 0x400;
            UnrealEngine.Memory.WriteProcessMemory(funcAddr + funcFlagsOffset, BitConverter.GetBytes(nativeFlag));
            var val = UnrealEngine.Memory.ExecuteUEFunc<T>((IntPtr)VTableFunc, Address, (IntPtr)funcAddr, args);
            UnrealEngine.Memory.WriteProcessMemory(funcAddr + funcFlagsOffset, BitConverter.GetBytes(initFlags));
            return val;
        }

        public void Invoke(String funcName, params Object[] args)
        {
            Invoke<Int32>(funcName, args);
        }

        public T As<T>() where T : UEObject
        {
            var obj = (T)Activator.CreateInstance(typeof(T), Address);
            obj._classAddr = _classAddr;
            return obj;
        }

        public string Dump()
        {
            var tempEntity = ClassAddr;
            var fields = new List<object> { };
            while (true)
            {
                var classNameIndex = UnrealEngine.Memory.ReadProcessMemory<int>(tempEntity + nameOffset);
                var name = GetName(classNameIndex);
                var field = tempEntity + childPropertiesOffset - fieldNextOffset;
                while ((field = UnrealEngine.Memory.ReadProcessMemory<nint>(field + fieldNextOffset)) > 0)
                {
                    var fName = GetName(UnrealEngine.Memory.ReadProcessMemory<int>(field + fieldNameOffset));
                    var fType = GetFieldType(field);
                    var fValue = "(" + field.ToString("X") + ")";
                    var offset = GetFieldOffset(field);
                    if (fType == "BoolProperty")
                    {
                        fType = "Boolean";
                        fValue = this[fName].Flag.ToString();
                    }
                    else if (fType == "FloatProperty")
                    {
                        fType = "Single";
                        fValue = BitConverter.ToSingle(BitConverter.GetBytes(this[fName].Value), 0).ToString();
                    }
                    else if (fType == "DoubleProperty")
                    {
                        fType = "Double";
                        fValue = BitConverter.ToDouble(BitConverter.GetBytes(this[fName].Value), 0).ToString();
                    }
                    else if (fType == "IntProperty")
                    {
                        fType = "Int32";
                        fValue = ((int)this[fName].Value).ToString("X");
                    }
                    else if (fType == "ObjectProperty" || fType == "StructProperty")
                    {
                        var structFieldIndex = UnrealEngine.Memory.ReadProcessMemory<int>(
                            UnrealEngine.Memory.ReadProcessMemory<nint>(field + UEObject.propertySize) +
                            UEObject.nameOffset);
                        fType = UEObject.GetName(structFieldIndex);
                    }

                    /*fields.Add(new
                    {
                        info = fType + " " + fName + " = " + fValue
                    });*/
                    fields.Add(fType + " " + fName + " = " + fValue + " ( @ " + offset.ToString("X") + " - " +
                               (this.Address + offset).ToString("X") + " )");
                }

                field = tempEntity + UEObject.childrenOffset - UEObject.funcNextOffset;
                while ((field = UnrealEngine.Memory.ReadProcessMemory<nint>(field + funcNextOffset)) > 0)
                {
                    var fName = UEObject.GetName(UnrealEngine.Memory.ReadProcessMemory<Int32>(field + nameOffset));
                }

                tempEntity = UnrealEngine.Memory.ReadProcessMemory<nint>(tempEntity + structSuperOffset);
                if (tempEntity == 0) break;
            }

            var obj = new
            {
                name = ClassName + " : " + GetFullPath(),
                hierarchy = GetHierachy(),
                fields
            };
            return System.Text.Json.JsonSerializer.Serialize(obj,
                new System.Text.Json.JsonSerializerOptions { IncludeFields = true, WriteIndented = true });
        }
    }
}