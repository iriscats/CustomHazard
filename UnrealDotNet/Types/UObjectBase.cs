namespace UnrealDotNet.Types;

public class UObjectBase
{
    protected int ObjectOuterOffset = 0x20;
    protected int ClassOffset = 0x10;
    protected int NameOffset = 0x18;
    protected int StructSuperOffset = 0x40;
    protected int ChildPropertiesOffset = 0x50;
    protected int ChildrenOffset = 0x48;
    protected int FieldNameOffset = 0x28;
    protected int FieldTypeNameOffset = 0;
    protected int FieldClassOffset = 0x8;
    protected int FieldNextOffset = 0x20;
    protected int FuncNextOffset = 0x20;
    protected int FieldOffset = 0x4C;
    protected int PropertySize = 0x78;
    protected int VTableFuncNum = 66;
    protected int FuncFlagsOffset = 0xB0;
    protected int EnumArrayOffset = 0x40;
    protected int EnumCountOffset = 0x48;

    private readonly UnrealEngine _unrealEngine = UnrealEngine.GetInstance();

    public string GetName(int key)
    {
        var namePtr = _unrealEngine.ReadProcessMemory<nint>(_unrealEngine.GNames + ((key >> 16) + 2) * 8);
        if (namePtr == 0)
            return "badIndex";

        var nameEntry = _unrealEngine.ReadProcessMemory<UInt16>(namePtr + (key & 0xffff) * 2);
        var nameLength = nameEntry >> 6;
        if (nameLength <= 0)
            return "badIndex";

        return _unrealEngine.MemoryReadString(namePtr + (key & 0xffff) * 2 + 2, nameLength);
    }

    public Boolean NewFName = true;

    public void UpdateUObject()
    {
        var world = _unrealEngine.ReadProcessMemory<nint>(_unrealEngine.GWorld);
        {
            var foundClassAndName = false;
            for (var c = 0; c < 0x50 && !foundClassAndName; c += 0x8)
            {
                var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + c);
                if (classPtr == 0x0)
                    continue;

                for (var n = 0; n < 0x50 && !foundClassAndName; n += 0x8)
                {
                    var classNameIndex = _unrealEngine.ReadProcessMemory<int>(classPtr + n);
                    var name = GetName(classNameIndex);
                    if (name == "World")
                    {
                        ClassOffset = c;
                        NameOffset = n;
                        foundClassAndName = true;
                    }
                }
            }

            if (!foundClassAndName)
                throw new Exception("bad World or offsets?");
        }
        {
            var foundOuter = false;
            var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + ClassOffset);
            for (var o = 0; o < 0x50; o += 0x8)
            {
                var outerObj = _unrealEngine.ReadProcessMemory<nint>(classPtr + o);
                var classNameIndex = _unrealEngine.ReadProcessMemory<int>(outerObj + NameOffset);
                var name = GetName(classNameIndex);
                if (name == "/Script/Engine")
                {
                    ObjectOuterOffset = o;
                    foundOuter = true;
                    break;
                }
            }

            if (!foundOuter)
                throw new Exception("bad outer addr");
        }
        {
            var foundSuper = false;
            var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + ClassOffset);
            for (var o = 0; o < 0x50; o += 0x8)
            {
                var superObj = _unrealEngine.ReadProcessMemory<nint>(classPtr + o);
                var classNameIndex = _unrealEngine.ReadProcessMemory<int>(superObj + NameOffset);
                var name = GetName(classNameIndex);
                if (name == "Object")
                {
                    StructSuperOffset = o;
                    foundSuper = true;
                    break;
                }
            }

            if (!foundSuper)
                throw new Exception("bad super addr");
        }
        {
            var foundChildsAndFieldName = false;
            var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + ClassOffset);
            for (var c = 0; c < 0x80 && !foundChildsAndFieldName; c += 0x8)
            {
                var childPtr = _unrealEngine.ReadProcessMemory<nint>(classPtr + c);
                if (childPtr == 0x0)
                    continue;

                for (var n = 0; n < 0x80 && !foundChildsAndFieldName; n += 0x8)
                {
                    var classNameIndex = _unrealEngine.ReadProcessMemory<int>(childPtr + n);
                    var name = GetName(classNameIndex);
                    if (name == "PersistentLevel")
                    {
                        ChildPropertiesOffset = c;
                        FieldNameOffset = n;
                        foundChildsAndFieldName = true;
                    }
                }
            }

            if (!foundChildsAndFieldName)
                throw new Exception("bad childs offset");
        }
        {
            var foundNextField = false;
            var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + ClassOffset);
            var fieldPtr = _unrealEngine.ReadProcessMemory<nint>(classPtr + ChildPropertiesOffset);
            for (var c = 0; c < 0x80 && !foundNextField; c += 0x8)
            {
                var childClassPtr = _unrealEngine.ReadProcessMemory<nint>(fieldPtr + c);
                if (childClassPtr == 0x0)
                    continue;

                var classNameIndex = _unrealEngine.ReadProcessMemory<int>(childClassPtr + FieldNameOffset);
                var name = GetName(classNameIndex);
                if (name == "NetDriver")
                {
                    FieldNextOffset = c;
                    foundNextField = true;
                }
            }

            if (!foundNextField)
                throw new Exception("bad next field offset");
        }
        {
            var foundFuncs = false;
            var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + ClassOffset);
            for (var c = 0; c < 0x80 && !foundFuncs; c += 0x8)
            {
                var childPtr = _unrealEngine.ReadProcessMemory<nint>(classPtr + c);
                if (childPtr == 0x0)
                    continue;

                var classNameIndex = _unrealEngine.ReadProcessMemory<int>(childPtr + NameOffset);
                var name = GetName(classNameIndex);
                if (name == "K2_GetWorldSettings")
                {
                    ChildrenOffset = c;
                    foundFuncs = true;
                }
            }

            if (!foundFuncs)
            {
                var testObj = new UObject(world);
                var isField = testObj["K2_GetWorldSettings"];
                if (isField != null)
                {
                    ChildrenOffset = ChildPropertiesOffset;
                    foundFuncs = true;
                }
            }

            if (!foundFuncs)
                throw new Exception("bad childs offset");
        }
        {
            var foundNextField = false;
            var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + ClassOffset);
            var fieldPtr = _unrealEngine.ReadProcessMemory<nint>(classPtr + ChildrenOffset);
            for (var c = 0; c < 0x80 && !foundNextField; c += 0x8)
            {
                var childClassPtr = _unrealEngine.ReadProcessMemory<nint>(fieldPtr + c);
                if (childClassPtr == 0x0)
                    continue;

                var classNameIndex = _unrealEngine.ReadProcessMemory<int>(childClassPtr + NameOffset);
                var name = GetName(classNameIndex);
                if (name == "HandleTimelineScrubbed")
                {
                    FuncNextOffset = c;
                    foundNextField = true;
                }
            }

            if (!foundNextField)
                throw new Exception("bad next offset");
        }
        {
            var foundNextField = false;
            var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + ClassOffset);
            var fieldPtr = _unrealEngine.ReadProcessMemory<nint>(classPtr + ChildPropertiesOffset);
            for (var c = 0; c < 0x80 && !foundNextField; c += 0x8)
            {
                var childClassPtr = _unrealEngine.ReadProcessMemory<nint>(fieldPtr + c);
                if (childClassPtr == 0x0)
                    continue;

                var classNameOffset = NewFName ? 0 : FieldNameOffset;
                var classNameIndex = _unrealEngine.ReadProcessMemory<int>(childClassPtr + classNameOffset);
                var name = GetName(classNameIndex);
                if (name == "ObjectProperty")
                {
                    FieldClassOffset = c;
                    foundNextField = true;
                }
            }

            if (!foundNextField)
                throw new Exception("bad field class offset");
        }
        {
            var foundFieldOffset = false;
            var classPtr = _unrealEngine.ReadProcessMemory<nint>(world + ClassOffset);
            var fieldPtr = _unrealEngine.ReadProcessMemory<nint>(classPtr + ChildPropertiesOffset);
            for (var c = 0x0; c < 0x80 && !foundFieldOffset; c += 0x4)
            {
                var fieldOffset = _unrealEngine.ReadProcessMemory<nint>(fieldPtr + c);
                var nextFieldPtr = _unrealEngine.ReadProcessMemory<nint>(fieldPtr + FieldNextOffset);
                var fieldOffsetPlus8 = _unrealEngine.ReadProcessMemory<nint>(nextFieldPtr + c);
                if ((fieldOffset + 8) == fieldOffsetPlus8)
                {
                    FieldOffset = c;
                    foundFieldOffset = true;
                }
            }

            if (!foundFieldOffset) throw new Exception("bad field offset");
        }
        {
            var worldUObject = new UObject(world);
            var field = worldUObject.GetFieldAddr("StreamingLevelsToConsider");
            var foundPropertySize = false;
            for (var c = 0x60; c < 0x100 && !foundPropertySize; c += 0x8)
            {
                var classAddr = _unrealEngine.ReadProcessMemory<nint>(field + c);
                var classNameIndex = _unrealEngine.ReadProcessMemory<Int32>(classAddr + NameOffset);
                var name = GetName(classNameIndex);
                if (name == "StreamingLevelsToConsider")
                {
                    PropertySize = c;
                    foundPropertySize = true;
                }
            }

            if (!foundPropertySize)
                throw new Exception("bad property size offset");
        }
        {
            var vTable = _unrealEngine.ReadProcessMemory<nint>(world);
            var foundProcessEventOffset = false;
            for (var i = 50; i < 0x100 && !foundProcessEventOffset; i++)
            {
                var s = _unrealEngine.ReadProcessMemory<IntPtr>(vTable + i * 8);
                var sig = (UInt64)_unrealEngine.FindPattern("40 55 56 57 41 54 41 55 41 56 41 57", s, 0X20);
                if (sig != 0)
                {
                    VTableFuncNum = i;
                    foundProcessEventOffset = true;
                }
            }

            if (!foundProcessEventOffset)
                throw new Exception("bad process event offset");
        }
        {
            var testObj = new UObject(world);
            var funcAddr = testObj.GetFuncAddr(testObj.ClassAddr, testObj.ClassAddr, "K2_GetWorldSettings");
            var foundFuncFlags = false;
            for (var i = 0; i < 0x200 && !foundFuncFlags; i += 8)
            {
                var flags = _unrealEngine.ReadProcessMemory<nint>(funcAddr + i);
                if (flags == (nint)0x0008000104020401)
                {
                    FuncFlagsOffset = i;
                    foundFuncFlags = true;
                }
            }

            if (!foundFuncFlags)
                throw new Exception("bad func flags offset");
        }
    }
}