using System.Collections.Concurrent;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace UnrealDotNet.Types;

public partial class UObject
{
    private static readonly ConcurrentDictionary<nint, string> AddrToName = new();
    private static readonly ConcurrentDictionary<nint, nint> AddrToClass = new();
    private static readonly ConcurrentDictionary<string, bool> ClassIsSubClass = new();
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

        var offset = _unrealEngine.MemoryReadInt(fieldAddr + FieldOffset);
        FieldAddrToOffset[fieldAddr] = offset;
        return offset;
    }


    public UObject(nint address = 0)
    {
        Address = address;
    }


    public bool IsA(nint entityClassAddr, string targetClassName)
    {
        var key = entityClassAddr + ":" + targetClassName;
        if (ClassIsSubClass.ContainsKey(key))
            return ClassIsSubClass[key];

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

            tempEntityClassAddr = _unrealEngine.MemoryReadPtr(tempEntityClassAddr + StructSuperOffset);
            if (tempEntityClassAddr == 0) break;
        }

        ClassIsSubClass[key] = false;
        return false;
    }

    public bool IsA(string className)
    {
        return IsA(ClassAddress, className);
    }

    public bool IsA<T>(out T converted) where T : UObject
    {
        var n = typeof(T).Namespace;
        n = n!.Substring(3, n.Length - 6).Replace(".", "/");
        n = "Class " + n + "." + typeof(T).Name;
        converted = As<T>();
        return IsA(ClassAddress, n);
    }

    public bool IsA<T>() where T : UObject
    {
        if (Address == 0) return false;
        return IsA<T>(out _);
    }


    public string GetName()
    {
        return GetName(_unrealEngine.MemoryReadInt(Address + NameOffset));
    }

    public string GetShortName()
    {
        if (ClassToName.TryGetValue(ClassAddress, out var name))
            return name;

        var classNameIndex = _unrealEngine.MemoryReadInt(ClassAddress + NameOffset);
        ClassToName[ClassAddress] = GetName(classNameIndex);
        return ClassToName[ClassAddress];
    }

    public string GetFullPath()
    {
        if (AddrToName.TryGetValue(Address, out var path))
            return path;

        var classPtr = _unrealEngine.MemoryReadPtr(Address + ClassOffset);
        var classNameIndex = _unrealEngine.MemoryReadInt(classPtr + NameOffset);
        var name = GetName(classNameIndex);
        var outerEntityAddr = Address;
        var parentName = "";
        while (true)
        {
            var tempOuterEntityAddr = _unrealEngine.MemoryReadPtr(outerEntityAddr + ObjectOuterOffset);

            if (tempOuterEntityAddr == outerEntityAddr || tempOuterEntityAddr == 0)
                break;

            outerEntityAddr = tempOuterEntityAddr;
            var outerNameIndex = _unrealEngine.MemoryReadInt(outerEntityAddr + NameOffset);
            var tempName = GetName(outerNameIndex);
            if (tempName == "")
                break;
            if (tempName == "None")
                break;
            parentName = tempName + "." + parentName;
        }

        name += " " + parentName;
        var nameIndex = _unrealEngine.MemoryReadInt(Address + NameOffset);
        name += GetName(nameIndex);
        AddrToName[Address] = name;
        return name;
    }

    public string GetHierachy()
    {
        var sb = new StringBuilder();
        var tempEntityClassAddr = ClassAddress;
        while (true)
        {
            var tempEntity = new UObject(tempEntityClassAddr);
            var className = tempEntity.GetFullPath();
            sb.AppendLine(className);
            tempEntityClassAddr = _unrealEngine.MemoryReadPtr(tempEntityClassAddr + StructSuperOffset);

            if (tempEntityClassAddr == 0)
                break;
        }

        return sb.ToString();
    }

    public string GetFieldType(nint fieldAddr)
    {
        bool NewFName = true;
        if (FieldAddrToType.TryGetValue(fieldAddr, out var type))
            return type;

        var fieldType = _unrealEngine.MemoryReadPtr(fieldAddr + FieldClassOffset);
        var name = GetName(_unrealEngine.MemoryReadInt(fieldType + (NewFName ? 0 : FieldNameOffset)));
        FieldAddrToType[fieldAddr] = name;
        return name;
    }

    nint GetFieldAddr(nint origClassAddr, nint classAddr, string fieldName)
    {
        if (ClassFieldToAddr.ContainsKey(origClassAddr) && ClassFieldToAddr[origClassAddr].ContainsKey(fieldName))
            return ClassFieldToAddr[origClassAddr][fieldName];

        var field = classAddr + ChildPropertiesOffset - FieldNextOffset;
        while ((field = _unrealEngine.MemoryReadPtr(field + FieldNextOffset)) > 0)
        {
            var fName = GetName(_unrealEngine.MemoryReadInt(field + FieldNameOffset));
            if (fName == fieldName)
            {
                if (!ClassFieldToAddr.ContainsKey(origClassAddr))
                    ClassFieldToAddr[origClassAddr] = new ConcurrentDictionary<string, nint>();
                ClassFieldToAddr[origClassAddr][fieldName] = field;
                return field;
            }
        }

        var parentClass = _unrealEngine.MemoryReadPtr(classAddr + StructSuperOffset);
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
        return GetFieldAddr(ClassAddress, ClassAddress, fieldName);
    }

    public nint GetFuncAddr(nint origClassAddr, nint classAddr, string fieldName)
    {
        bool NewFName = true;
        if (!NewFName)
            return GetFieldAddr(origClassAddr, classAddr, fieldName);

        if (ClassFieldToAddr.ContainsKey(origClassAddr) && ClassFieldToAddr[origClassAddr].ContainsKey(fieldName))
            return ClassFieldToAddr[origClassAddr][fieldName];

        var field = classAddr + ChildrenOffset - FuncNextOffset;
        while ((field = _unrealEngine.MemoryReadPtr(field + FuncNextOffset)) > 0)
        {
            var fName = GetName(_unrealEngine.MemoryReadInt(field + NameOffset));
            if (fName == fieldName)
            {
                if (!ClassFieldToAddr.ContainsKey(origClassAddr))
                    ClassFieldToAddr[origClassAddr] = new ConcurrentDictionary<string, nint>();
                ClassFieldToAddr[origClassAddr][fieldName] = field;
                return field;
            }
        }

        var parentClass = _unrealEngine.MemoryReadPtr(classAddr + StructSuperOffset);
        if (parentClass == classAddr)
            throw new Exception("parent is me");

        if (parentClass == 0)
            throw new Exception("bad field");

        return GetFuncAddr(origClassAddr, parentClass, fieldName);
    }


    public UObject this[string key]
    {
        get
        {
            var fieldAddr = GetFieldAddr(key);
            if (fieldAddr == 0)
                return null;

            var fieldType = GetFieldType(fieldAddr);
            var offset = GetFieldOffset(fieldAddr);
            
            UObject obj;
            if (fieldType is "ObjectProperty" or "ScriptStruct")
            {
                obj = new UObject(_unrealEngine.MemoryReadPtr(Address + offset));
                FieldOffset = offset;
            }
            else if (fieldType == "ArrayProperty")
            {
                obj = new UObject(Address + offset);
                obj._classAddress = _unrealEngine.MemoryReadPtr(fieldAddr + FieldClassOffset);
                var inner = _unrealEngine.MemoryReadPtr(fieldAddr + PropertySize);
                var innerClass = _unrealEngine.MemoryReadPtr(inner + FieldClassOffset);
                obj.SubStructAddress = _unrealEngine.MemoryReadPtr(inner + PropertySize);
            }
            else if (fieldType.Contains("Bool"))
            {
                obj = new UObject(Address + offset);
                obj._classAddress = _unrealEngine.MemoryReadPtr(fieldAddr + ClassOffset);
                obj._boolMask = _unrealEngine.MemoryReadByte(fieldAddr + PropertySize);
            }
            else if (fieldType.Contains("Function"))
            {
                obj = new UObject(fieldAddr);
                //obj.BaseObjAddr = Address;
            }
            else if (fieldType.Contains("StructProperty"))
            {
                obj = new UObject(Address + offset);
                obj._classAddress = _unrealEngine.MemoryReadPtr(fieldAddr + PropertySize);
            }
            else if (fieldType.Contains("FloatProperty"))
            {
                obj = new UObject(Address + offset);
                obj._classAddress = 0;
            }
            else
            {
                obj = new UObject(Address + offset);
                obj._classAddress = _unrealEngine.MemoryReadPtr(fieldAddr + PropertySize);
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


    public UObject this[int index]
    {
        get { return new UObject((nint)BitConverter.ToUInt64(ArrayCache, index * 8)); }
    }


    public T Invoke<T>(string funcName, params object[] args)
    {
        var funcAddr = GetFuncAddr(ClassAddress, ClassAddress, funcName);
        var initFlags = _unrealEngine.MemoryReadPtr(funcAddr + FuncFlagsOffset);
        var nativeFlag = initFlags;
        nativeFlag |= 0x400;
        _unrealEngine.WriteProcessMemory(funcAddr + FuncFlagsOffset, BitConverter.GetBytes(nativeFlag));
        var val = _unrealEngine.ExecuteUFunction<T>(VTableFunc, Address, funcAddr, args);
        _unrealEngine.WriteProcessMemory(funcAddr + FuncFlagsOffset, BitConverter.GetBytes(initFlags));
        return val;
    }

    public void Invoke(string funcName, params object[] args)
    {
        Invoke<int>(funcName, args);
    }

    public T As<T>() where T : UObject
    {
        var obj = (T)Activator.CreateInstance(typeof(T), Address);
        obj._classAddress = _classAddress;
        return obj;
    }
}