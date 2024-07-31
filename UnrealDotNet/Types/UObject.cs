using System.Collections.Concurrent;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace UnrealDotNet.Types;

public class UObject : UObjectBase
{
    private static readonly ConcurrentDictionary<nint, string> AddrToName = new();
    private static readonly ConcurrentDictionary<nint, nint> AddrToClass = new();
    private static readonly ConcurrentDictionary<String, Boolean> ClassIsSubClass = new();
    private static readonly ConcurrentDictionary<nint, string> ClassToName = new();
    private static readonly ConcurrentDictionary<nint, ConcurrentDictionary<string, nint>> ClassFieldToAddr = new();
    private static readonly ConcurrentDictionary<nint, int> FieldAddrToOffset = new();
    private static readonly ConcurrentDictionary<nint, string> FieldAddrToType = new();

    private readonly UnrealEngine _unrealEngine = UnrealEngine.GetInstance();

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
        if (FieldAddrToOffset.ContainsKey(fieldAddr))
            return FieldAddrToOffset[fieldAddr];

        var offset = _unrealEngine.ReadProcessMemory<int>(fieldAddr + FieldOffset);
        FieldAddrToOffset[fieldAddr] = offset;
        return offset;
    }

    String _className;

    public String ClassName
    {
        get
        {
            if (_className != null)
                return _className;

            _className = GetFullPath();
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

            _classAddr = _unrealEngine.ReadProcessMemory<nint>(Address + ClassOffset);
            AddrToClass[Address] = _classAddr;
            return _classAddr;
        }
    }

    public UObject(nint address = 0)
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
            var tempEntity = new UObject(tempEntityClassAddr);
            var className = tempEntity.GetFullPath();
            if (className == targetClassName)
            {
                ClassIsSubClass[key] = true;
                return true;
            }

            tempEntityClassAddr = _unrealEngine.ReadProcessMemory<nint>(tempEntityClassAddr + StructSuperOffset);
            if (tempEntityClassAddr == 0) break;
        }

        ClassIsSubClass[key] = false;
        return false;
    }

    public Boolean IsA(String className)
    {
        return IsA(ClassAddr, className);
    }

    public Boolean IsA<T>(out T converted) where T : UObject
    {
        var n = typeof(T).Namespace;
        n = n!.Substring(3, n.Length - 6).Replace(".", "/");
        n = "Class " + n + "." + typeof(T).Name;
        converted = As<T>();
        return IsA(ClassAddr, n);
    }

    public Boolean IsA<T>() where T : UObject
    {
        if (Address == 0) return false;
        return IsA<T>(out _);
    }




    public String GetName()
    {
        return GetName(_unrealEngine.ReadProcessMemory<int>(Address + NameOffset));
    }

    public String GetShortName()
    {
        if (ClassToName.ContainsKey(ClassAddr))
            return ClassToName[ClassAddr];

        var classNameIndex = _unrealEngine.ReadProcessMemory<int>(ClassAddr + NameOffset);
        ClassToName[ClassAddr] = GetName(classNameIndex);
        return ClassToName[ClassAddr];
    }

    public String GetFullPath()
    {
        if (AddrToName.ContainsKey(Address))
            return AddrToName[Address];

        var classPtr = _unrealEngine.ReadProcessMemory<nint>(Address + ClassOffset);
        var classNameIndex = _unrealEngine.ReadProcessMemory<int>(classPtr + NameOffset);
        var name = GetName(classNameIndex);
        var outerEntityAddr = Address;
        var parentName = "";
        while (true)
        {
            var tempOuterEntityAddr = _unrealEngine.ReadProcessMemory<nint>(outerEntityAddr + ObjectOuterOffset);

            if (tempOuterEntityAddr == outerEntityAddr || tempOuterEntityAddr == 0)
                break;

            outerEntityAddr = tempOuterEntityAddr;
            var outerNameIndex = _unrealEngine.ReadProcessMemory<int>(outerEntityAddr + NameOffset);
            var tempName = GetName(outerNameIndex);
            if (tempName == "")
                break;
            if (tempName == "None")
                break;
            parentName = tempName + "." + parentName;
        }

        name += " " + parentName;
        var nameIndex = _unrealEngine.ReadProcessMemory<int>(Address + NameOffset);
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
            var tempEntity = new UObject(tempEntityClassAddr);
            var className = tempEntity.GetFullPath();
            sb.AppendLine(className);
            tempEntityClassAddr = _unrealEngine.ReadProcessMemory<nint>(tempEntityClassAddr + StructSuperOffset);

            if (tempEntityClassAddr == 0)
                break;
        }

        return sb.ToString();
    }

    public String GetFieldType(nint fieldAddr)
    {
        if (FieldAddrToType.ContainsKey(fieldAddr))
            return FieldAddrToType[fieldAddr];

        var fieldType = _unrealEngine.ReadProcessMemory<nint>(fieldAddr + FieldClassOffset);
        var name = GetName(_unrealEngine.ReadProcessMemory<int>(fieldType + (NewFName ? 0 : FieldNameOffset)));
        FieldAddrToType[fieldAddr] = name;
        return name;
    }

    nint GetFieldAddr(nint origClassAddr, nint classAddr, string fieldName)
    {
        if (ClassFieldToAddr.ContainsKey(origClassAddr) && ClassFieldToAddr[origClassAddr].ContainsKey(fieldName))
            return ClassFieldToAddr[origClassAddr][fieldName];
        var field = classAddr + ChildPropertiesOffset - FieldNextOffset;
        while ((field = _unrealEngine.ReadProcessMemory<nint>(field + FieldNextOffset)) > 0)
        {
            var fName = GetName(_unrealEngine.ReadProcessMemory<int>(field + FieldNameOffset));
            if (fName == fieldName)
            {
                if (!ClassFieldToAddr.ContainsKey(origClassAddr))
                    ClassFieldToAddr[origClassAddr] = new ConcurrentDictionary<string, nint>();
                ClassFieldToAddr[origClassAddr][fieldName] = field;
                return field;
            }
        }

        var parentClass = _unrealEngine.ReadProcessMemory<nint>(classAddr + StructSuperOffset);
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
        if (!NewFName) 
            return GetFieldAddr(origClassAddr, classAddr, fieldName);
        
        if (ClassFieldToAddr.ContainsKey(origClassAddr) && ClassFieldToAddr[origClassAddr].ContainsKey(fieldName))
            return ClassFieldToAddr[origClassAddr][fieldName];
        var field = classAddr + ChildrenOffset - FuncNextOffset;
        while ((field = _unrealEngine.ReadProcessMemory<nint>(field + FuncNextOffset)) > 0)
        {
            var fName = GetName(_unrealEngine.ReadProcessMemory<int>(field + NameOffset));
            if (fName == fieldName)
            {
                if (!ClassFieldToAddr.ContainsKey(origClassAddr))
                    ClassFieldToAddr[origClassAddr] = new ConcurrentDictionary<String, nint>();
                ClassFieldToAddr[origClassAddr][fieldName] = field;
                return field;
            }
        }

        var parentClass = _unrealEngine.ReadProcessMemory<nint>(classAddr + StructSuperOffset);
        if (parentClass == classAddr) throw new Exception("parent is me");
        if (parentClass == 0) throw new Exception("bad field");
        return GetFuncAddr(origClassAddr, parentClass, fieldName);
    }


    private nint _value = 0xcafeb00;

    public nint Value
    {
        get
        {
            if (_value != 0xcafeb00)
                return _value;

            _value = _unrealEngine.ReadProcessMemory<nint>(Address);
            return _value;
        }
        set
        {
            _value = 0xcafeb00;
            _unrealEngine.WriteProcessMemory(Address, value);
        }
    }

    public T GetValue<T>()
    {
        return _unrealEngine.ReadProcessMemory<T>(Address);
    }

    public void SetValue<T>(T value)
    {
        _unrealEngine.WriteProcessMemory(Address, value);
    }

    UInt64 boolMask;

    public Boolean Flag
    {
        get
        {
            var val = _unrealEngine.ReadProcessMemory<UInt64>(Address);
            return ((val & boolMask) == boolMask);
        }
        set
        {
            var val = _unrealEngine.ReadProcessMemory<UInt64>(Address);
            if (value) val |= boolMask;
            else val &= ~boolMask;
            _unrealEngine.WriteProcessMemory(Address, val);
            //_unrealEngine.WriteProcessMemory(Address, value);
        }
    }

    public nint Address;

    public UObject this[String key]
    {
        get
        {
            var fieldAddr = GetFieldAddr(key);
            if (fieldAddr == 0) 
                return null;
            
            var fieldType = GetFieldType(fieldAddr);
            var offset = GetFieldOffset(fieldAddr);
            UObject obj;
            if (fieldType == "ObjectProperty" || fieldType == "ScriptStruct")
                obj = new UObject(_unrealEngine.ReadProcessMemory<nint>(Address + offset)) { FieldOffset = offset };
    
            else if (fieldType == "ArrayProperty")
            {
                obj = new UObject(Address + offset);
                obj._classAddr = _unrealEngine.ReadProcessMemory<nint>(fieldAddr + FieldClassOffset);
                var inner = _unrealEngine.ReadProcessMemory<nint>(fieldAddr + PropertySize);
                var innerClass = _unrealEngine.ReadProcessMemory<nint>(inner + FieldClassOffset);
                obj._substructAddr = _unrealEngine.ReadProcessMemory<nint>(inner + PropertySize);
                //obj._substructAddr;
            }
            else if (fieldType.Contains("Bool"))
            {
                obj = new UObject(Address + offset);
                obj._classAddr = _unrealEngine.ReadProcessMemory<nint>(fieldAddr + ClassOffset);
                obj.boolMask = _unrealEngine.ReadProcessMemory<Byte>(fieldAddr + PropertySize);
            }
            else if (fieldType.Contains("Function"))
            {
                obj = new UObject(fieldAddr);
                //obj.BaseObjAddr = Address;
            }
            else if (fieldType.Contains("StructProperty"))
            {
                obj = new UObject(Address + offset);
                obj._classAddr = _unrealEngine.ReadProcessMemory<nint>(fieldAddr + PropertySize);
            }
            else if (fieldType.Contains("FloatProperty"))
            {
                obj = new UObject(Address + offset);
                obj._classAddr = 0;
            }
            else
            {
                obj = new UObject(Address + offset);
                obj._classAddr = _unrealEngine.ReadProcessMemory<nint>(fieldAddr + PropertySize);
            }

            if (obj.Address == 0)
            {
                obj = new UObject();
                //var classInfo = Engine.Instance.DumpClass(ClassAddr);
                //throw new Exception("bad addr");
            }

            return obj;
        }
        set
        {
            var fieldAddr = GetFieldAddr(key);
            var offset = GetFieldOffset(fieldAddr);
            _unrealEngine.WriteProcessMemory(Address + offset, value.Address);
        }
    }

    private int _num = int.MaxValue;

    public int Num
    {
        get
        {
            if (_num != int.MaxValue) return _num;
            _num = _unrealEngine.ReadProcessMemory<int>(Address + 8);
            if (_num > 0x10000) _num = 0x10000;
            return _num;
        }
    }

    private Byte[] _arrayCache = [];

    public Byte[] ArrayCache
    {
        get
        {
            if (_arrayCache.Length != 0) return _arrayCache;
            _arrayCache = _unrealEngine.ReadProcessMemory(Value, Num * 8);
            return _arrayCache;
        }
    }

    public UObject this[int index]
    {
        get { return new UObject((nint)BitConverter.ToUInt64(ArrayCache, index * 8)); }
    }

    private nint _vTableFunc = 0xcafeb00;

    public nint VTableFunc
    {
        get
        {
            if (_vTableFunc != 0xcafeb00) return _vTableFunc;
            _vTableFunc = _unrealEngine.ReadProcessMemory<nint>(Address) + VTableFuncNum * 8;
            _vTableFunc = _unrealEngine.ReadProcessMemory<nint>(_vTableFunc);
            return _vTableFunc;
        }
    }

    public T Invoke<T>(String funcName, params Object[] args)
    {
        var funcAddr = GetFuncAddr(ClassAddr, ClassAddr, funcName);
        var initFlags = _unrealEngine.ReadProcessMemory<nint>(funcAddr + FuncFlagsOffset);
        var nativeFlag = initFlags;
        nativeFlag |= 0x400;
        _unrealEngine.WriteProcessMemory(funcAddr + FuncFlagsOffset, BitConverter.GetBytes(nativeFlag));
        var val = _unrealEngine.ExecuteUEFunc<T>(VTableFunc, Address, funcAddr, args);
        _unrealEngine.WriteProcessMemory(funcAddr + FuncFlagsOffset, BitConverter.GetBytes(initFlags));
        return val;
    }

    public void Invoke(String funcName, params Object[] args)
    {
        Invoke<Int32>(funcName, args);
    }

    public T As<T>() where T : UObject
    {
        var obj = (T)Activator.CreateInstance(typeof(T), Address);
        obj._classAddr = _classAddr;
        return obj;
    }

    public override string ToString()
    {
        var tempEntity = ClassAddr;
        var fields = new List<object>
        {
            Capacity = 0
        };

        while (true)
        {
            var classNameIndex = _unrealEngine.ReadProcessMemory<int>(tempEntity + NameOffset);
            var name = GetName(classNameIndex);
            var field = tempEntity + ChildPropertiesOffset - FieldNextOffset;
            while ((field = _unrealEngine.ReadProcessMemory<nint>(field + FieldNextOffset)) > 0)
            {
                var fName = GetName(_unrealEngine.ReadProcessMemory<int>(field + FieldNameOffset));
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
                    fValue = BitConverter.ToSingle(BitConverter.GetBytes(this[fName].Value), 0)
                        .ToString(CultureInfo.InvariantCulture);
                }
                else if (fType == "DoubleProperty")
                {
                    fType = "Double";
                    fValue = BitConverter.ToDouble(BitConverter.GetBytes(this[fName].Value), 0)
                        .ToString(CultureInfo.InvariantCulture);
                }
                else if (fType == "IntProperty")
                {
                    fType = "Int32";
                    fValue = ((int)this[fName].Value).ToString("X");
                }
                else if (fType == "ObjectProperty" || fType == "StructProperty")
                {
                    var structFieldIndex = _unrealEngine.ReadProcessMemory<int>(
                        _unrealEngine.ReadProcessMemory<nint>(field + PropertySize) +
                        NameOffset);
                    fType = GetName(structFieldIndex);
                }

                fields.Add(fType + " " + fName + " = " + fValue + " ( @ " + offset.ToString("X") + " - " +
                           (Address + offset).ToString("X") + " )");
            }

            field = tempEntity + ChildrenOffset - FuncNextOffset;
            while ((field = _unrealEngine.ReadProcessMemory<nint>(field + FuncNextOffset)) > 0)
            {
                var fName = GetName(_unrealEngine.ReadProcessMemory<Int32>(field + NameOffset));
            }

            tempEntity = _unrealEngine.ReadProcessMemory<nint>(tempEntity + StructSuperOffset);
            if (tempEntity == 0) break;
        }

        var obj = new
        {
            name = ClassName + " : " + GetFullPath(),
            hierarchy = GetHierachy(),
            fields
        };
        return JsonSerializer.Serialize(obj,
            new JsonSerializerOptions { IncludeFields = true, WriteIndented = true });
    }
}