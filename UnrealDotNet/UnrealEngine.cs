using UnrealDotNet.Types;

namespace UnrealDotNet;

public partial class UnrealEngine
{
    private static UnrealEngine? _instance;

    public static UnrealEngine GetInstance()
    {
        return _instance ??= new UnrealEngine();
    }

    private nint _gNames = -1;

    public nint GNames
    {
        get
        {
            if (_gNames == -1)
            {
                var pattern = FindPattern("74 09 48 8D 15 ? ? ? ? EB 16");
                var offset = MemoryReadInt(pattern + 5);
                _gNames = pattern + offset + 9;
            }

            return _gNames;
        }
    }

    private nint _gObjects = -1;

    public nint GObjects
    {
        get
        {
            if (_gObjects == -1)
            {
                var pattern = FindPattern("48 8B 05 ? ? ? ? 48 8B 0C C8 ? 8D 04 D1 EB ?");
                var offset = MemoryReadInt(pattern + 3);
                _gObjects = pattern + offset + 7 - BaseAddress;
            }

            return _gObjects;
        }
    }

    private nint _gWorld = -1;

    public nint GWorld
    {
        get
        {
            if (_gWorld == -1)
            {
                int offset;
                var stringAddr = FindStringRef("    SeamlessTravel FlushLevelStreaming");
                //var pattern = Memory.FindPattern("48 89 5C 24 08 57 48 83 EC 30 0F B6 DA 48 8B F9 80 FA 01 ?? ?? ?? ?? ?? ?? ?? ?? ?? BA");
                var pattern = FindPattern("48 89 05", stringAddr - 0x500, 0x500);
                if (pattern != 0)
                {
                    offset = MemoryReadInt(pattern + 3);
                    _gWorld = pattern + offset + 7;
                }
                else
                {
                    pattern = FindPattern("0F 2E ?? 74 ?? 48 8B 1D ?? ?? ?? ?? 48 85 DB 74");
                    offset = MemoryReadInt(pattern + 8);
                    _gWorld = pattern + offset + 12;
                }
            }

            return _gWorld;
        }
    }

    private nint _gEngine = -1;

    public nint GEngine
    {
        get
        {
            if (_gEngine == -1)
            {
                var pattern = FindPattern("48 8B 0D ?? ?? ?? ?? 48 85 C9 74 1E 48 8B 01 FF 90");
                var offset = MemoryReadInt(pattern + 3);
                _gEngine = MemoryReadPtr(pattern + offset + 7);
            }

            return _gEngine;
        }
    }

    public nint GStaticCtor
    {
        get
        {
            return FindPattern(
                "4C 89 44 24 18 55 53 56 57 41 54 41 55 41 56 41 57 48 8D AC 24 ? ? ? ? 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4");
        }
    }

    private UnrealEngine()
    {
    }

    public void InitUOject()
    {
        UObject.UpdateUObject();

    }

}