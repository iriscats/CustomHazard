namespace UnrealSharp
{
    public class UnrealEngine
    {
        public static UnrealEngine Instance;
        static nint GNamesPattern;
        public static nint GNames;
        static nint GObjectsPattern;
        public static nint GObjects;
        static nint GWorldPtrPattern;
        public static nint GWorldPtr;
        static nint GEnginePattern;
        public static nint GEngine;
        public static nint GStaticCtor;
        public static Memory Memory;

        public UnrealEngine(Memory mem)
        {
            Memory = mem;
            Instance = this;
        }

        public void UpdateAddresses()
        {
            {
                GNamesPattern = Memory.FindPattern("74 09 48 8D 15 ? ? ? ? EB 16");
                var offset = Memory.ReadProcessMemory<int>(GNamesPattern + 5);
                GNames = GNamesPattern + offset + 9;
                if (UEObject.GetName(3) != "ByteProperty") throw new Exception("bad GNames");
                //DumpGNames();
            }
            {
                int offset;
                var stringAddr = Memory.FindStringRef("    SeamlessTravel FlushLevelStreaming");
                GWorldPtrPattern = Memory.FindPattern("48 89 05", stringAddr - 0x500, 0x500);
                //GWorldPtrPattern = Memory.FindPattern("48 89 5C 24 08 57 48 83 EC 30 0F B6 DA 48 8B F9 80 FA 01 ?? ?? ?? ?? ?? ?? ?? ?? ?? BA");
                if (GWorldPtrPattern != 0)
                {
                    offset = UnrealEngine.Memory.ReadProcessMemory<int>(GWorldPtrPattern + 3);
                    GWorldPtr = GWorldPtrPattern + offset + 7;
                }
                else
                {
                    GWorldPtrPattern = Memory.FindPattern("0F 2E ?? 74 ?? 48 8B 1D ?? ?? ?? ?? 48 85 DB 74");
                    offset = Memory.ReadProcessMemory<int>(GWorldPtrPattern + 8);
                    GWorldPtr = GWorldPtrPattern + offset + 12;
                }

                GObjectsPattern = Memory.FindPattern("48 8B 05 ? ? ? ? 48 8B 0C C8 ? 8D 04 D1 EB ?");

                UpdateUEObject();

                offset = Memory.ReadProcessMemory<int>(GObjectsPattern + 3);
                GObjects = GObjectsPattern + offset + 7 - Memory.BaseAddress;
            }
            {
                GEnginePattern = Memory.FindPattern("48 8B 0D ?? ?? ?? ?? 48 85 C9 74 1E 48 8B 01 FF 90");
                var offset = Memory.ReadProcessMemory<int>(GEnginePattern + 3);
                GEngine = Memory.ReadProcessMemory<nint>(GEnginePattern + offset + 7);
            }
            {
                var engine = new UEObject(GEngine);
                GStaticCtor =
                    Memory.FindPattern(
                        "4C 89 44 24 18 55 53 56 57 41 54 41 55 41 56 41 57 48 8D AC 24 ? ? ? ? 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4");
            }
            //DumpSdk();
        }

        public void UpdateUEObject()
        {
            var world = Memory.ReadProcessMemory<nint>(GWorldPtr);
            {
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                var foundClassAndName = false;
                for (var c = 0; c < 0x50 && !foundClassAndName; c += 0x8)
                {
                    classPtr = Memory.ReadProcessMemory<nint>(world + c);
                    if (classPtr == 0x0) continue;
                    for (var n = 0; n < 0x50 && !foundClassAndName; n += 0x8)
                    {
                        var classNameIndex = Memory.ReadProcessMemory<int>(classPtr + n);
                        var name = UEObject.GetName(classNameIndex);
                        if (name == "World")
                        {
                            UEObject.classOffset = c;
                            UEObject.nameOffset = n;
                            foundClassAndName = true;
                        }
                    }
                }

                if (!foundClassAndName) throw new Exception("bad World or offsets?");
            }
            {
                var foundOuter = false;
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                for (var o = 0; o < 0x50; o += 0x8)
                {
                    var outerObj = Memory.ReadProcessMemory<nint>(classPtr + o);
                    var classNameIndex = Memory.ReadProcessMemory<int>(outerObj + UEObject.nameOffset);
                    var name = UEObject.GetName(classNameIndex);
                    if (name == "/Script/Engine")
                    {
                        UEObject.objectOuterOffset = o;
                        foundOuter = true;
                        break;
                    }
                }

                if (!foundOuter) throw new Exception("bad outer addr");
            }
            {
                var foundSuper = false;
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                for (var o = 0; o < 0x50; o += 0x8)
                {
                    var superObj = Memory.ReadProcessMemory<nint>(classPtr + o);
                    var classNameIndex = Memory.ReadProcessMemory<int>(superObj + UEObject.nameOffset);
                    var name = UEObject.GetName(classNameIndex);
                    if (name == "Object")
                    {
                        UEObject.structSuperOffset = o;
                        foundSuper = true;
                        break;
                    }
                }

                if (!foundSuper) throw new Exception("bad super addr");
            }
            {
                var foundChildsAndFieldName = false;
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                for (var c = 0; c < 0x80 && !foundChildsAndFieldName; c += 0x8)
                {
                    var childPtr = Memory.ReadProcessMemory<nint>(classPtr + c);
                    if (childPtr == 0x0) continue;
                    for (var n = 0; n < 0x80 && !foundChildsAndFieldName; n += 0x8)
                    {
                        var classNameIndex = Memory.ReadProcessMemory<int>(childPtr + n);
                        var name = UEObject.GetName(classNameIndex);
                        if (name == "PersistentLevel")
                        {
                            UEObject.childPropertiesOffset = c;
                            UEObject.fieldNameOffset = n;
                            foundChildsAndFieldName = true;
                        }
                    }
                }

                if (!foundChildsAndFieldName) throw new Exception("bad childs offset");
            }
            {
                var foundNextField = false;
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                var fieldPtr = Memory.ReadProcessMemory<nint>(classPtr + UEObject.childPropertiesOffset);
                for (var c = 0; c < 0x80 && !foundNextField; c += 0x8)
                {
                    var childClassPtr = Memory.ReadProcessMemory<nint>(fieldPtr + c);
                    if (childClassPtr == 0x0) continue;
                    var classNameIndex = Memory.ReadProcessMemory<int>(childClassPtr + UEObject.fieldNameOffset);
                    var name = UEObject.GetName(classNameIndex);
                    if (name == "NetDriver")
                    {
                        UEObject.fieldNextOffset = c;
                        foundNextField = true;
                    }
                }

                if (!foundNextField) throw new Exception("bad next field offset");
            }
            {
                var foundFuncs = false;
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                for (var c = 0; c < 0x80 && !foundFuncs; c += 0x8)
                {
                    var childPtr = Memory.ReadProcessMemory<nint>(classPtr + c);
                    if (childPtr == 0x0) continue;
                    var classNameIndex = Memory.ReadProcessMemory<int>(childPtr + UEObject.nameOffset);
                    var name = UEObject.GetName(classNameIndex);
                    if (name == "K2_GetWorldSettings")
                    {
                        UEObject.childrenOffset = c;
                        foundFuncs = true;
                    }
                }

                if (!foundFuncs)
                {
                    var testObj = new UEObject(world);
                    var isField = testObj["K2_GetWorldSettings"];
                    if (isField != null)
                    {
                        UEObject.childrenOffset = UEObject.childPropertiesOffset;
                        foundFuncs = true;
                    }
                }

                if (!foundFuncs) throw new Exception("bad childs offset");
            }
            {
                var foundNextField = false;
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                var fieldPtr = Memory.ReadProcessMemory<nint>(classPtr + UEObject.childrenOffset);
                for (var c = 0; c < 0x80 && !foundNextField; c += 0x8)
                {
                    var childClassPtr = Memory.ReadProcessMemory<nint>(fieldPtr + c);
                    if (childClassPtr == 0x0) continue;
                    var classNameIndex = Memory.ReadProcessMemory<int>(childClassPtr + UEObject.nameOffset);
                    var name = UEObject.GetName(classNameIndex);
                    if (name == "HandleTimelineScrubbed")
                    {
                        UEObject.funcNextOffset = c;
                        foundNextField = true;
                    }
                }

                if (!foundNextField) throw new Exception("bad next offset");
            }
            {
                var foundNextField = false;
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                var fieldPtr = Memory.ReadProcessMemory<nint>(classPtr + UEObject.childPropertiesOffset);
                for (var c = 0; c < 0x80 && !foundNextField; c += 0x8)
                {
                    var childClassPtr = Memory.ReadProcessMemory<nint>(fieldPtr + c);
                    if (childClassPtr == 0x0) continue;
                    var classNameOffset = UEObject.NewFName ? 0 : UEObject.fieldNameOffset;
                    var classNameIndex = Memory.ReadProcessMemory<int>(childClassPtr + classNameOffset);
                    var name = UEObject.GetName(classNameIndex);
                    if (name == "ObjectProperty")
                    {
                        UEObject.fieldClassOffset = c;
                        foundNextField = true;
                    }
                }

                if (!foundNextField) throw new Exception("bad field class offset");
            }
            {
                var foundFieldOffset = false;
                var classPtr = Memory.ReadProcessMemory<nint>(world + UEObject.classOffset);
                var fieldPtr = Memory.ReadProcessMemory<nint>(classPtr + UEObject.childPropertiesOffset);
                for (var c = 0x0; c < 0x80 && !foundFieldOffset; c += 0x4)
                {
                    var fieldOffset = Memory.ReadProcessMemory<nint>(fieldPtr + c);
                    var nextFieldPtr = Memory.ReadProcessMemory<nint>(fieldPtr + UEObject.fieldNextOffset);
                    var fieldOffsetPlus8 = Memory.ReadProcessMemory<nint>(nextFieldPtr + c);
                    if ((fieldOffset + 8) == fieldOffsetPlus8)
                    {
                        UEObject.fieldOffset = c;
                        foundFieldOffset = true;
                    }
                }

                if (!foundFieldOffset) throw new Exception("bad field offset");
            }
            {
                var World = new UEObject(world);
                var field = World.GetFieldAddr("StreamingLevelsToConsider");
                var foundPropertySize = false;
                for (var c = 0x60; c < 0x100 && !foundPropertySize; c += 0x8)
                {
                    var classAddr = Memory.ReadProcessMemory<nint>(field + c);
                    var classNameIndex = Memory.ReadProcessMemory<Int32>(classAddr + UEObject.nameOffset);
                    var name = UEObject.GetName(classNameIndex);
                    if (name == "StreamingLevelsToConsider")
                    {
                        UEObject.propertySize = c;
                        foundPropertySize = true;
                    }
                }

                if (!foundPropertySize) throw new Exception("bad property size offset");
            }
            {
                var vTable = Memory.ReadProcessMemory<nint>(world);
                var foundProcessEventOffset = false;
                for (var i = 50; i < 0x100 && !foundProcessEventOffset; i++)
                {
                    var s = Memory.ReadProcessMemory<IntPtr>(vTable + i * 8);
                    var sig = (UInt64)Memory.FindPattern("40 55 56 57 41 54 41 55 41 56 41 57", s, 0X20);
                    if (sig != 0)
                    {
                        UEObject.vTableFuncNum = i;
                        foundProcessEventOffset = true;
                    }
                }

                if (!foundProcessEventOffset) throw new Exception("bad process event offset");
            }
            {
                var testObj = new UEObject(world);
                var funcAddr = testObj.GetFuncAddr(testObj.ClassAddr, testObj.ClassAddr, "K2_GetWorldSettings");
                var foundFuncFlags = false;
                for (var i = 0; i < 0x200 && !foundFuncFlags; i += 8)
                {
                    var flags = UnrealEngine.Memory.ReadProcessMemory<nint>(funcAddr + i);
                    if (flags == 0x0008000104020401)
                    {
                        UEObject.funcFlagsOffset = i;
                        foundFuncFlags = true;
                    }
                }

                if (!foundFuncFlags)
                    throw new Exception("bad func flags offset");
            }
        }
    }
}