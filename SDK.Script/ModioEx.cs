using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.ModioSDK;
namespace SDK.Script.ModioExSDK
{
    public class ModioSubmissionExtensionLibrary : BlueprintFunctionLibrary
    {
        public ModioSubmissionExtensionLibrary(nint addr) : base(addr) { }
        public void K2_SubmitNewModFileForModFromMemory(ModioSubsystem Target, ModioModID Mod, ModioCreateModFileMemoryParams Params) { Invoke(nameof(K2_SubmitNewModFileForModFromMemory), Target, Mod, Params); }
        public bool K2_LoadModFileToMemory(ModioSubsystem Target, ModioModID ModId, Array<byte> ModData) { return Invoke<bool>(nameof(K2_LoadModFileToMemory), Target, ModId, ModData); }
    }
    public class ModioCreateModFileMemoryParams : Object
    {
        public ModioCreateModFileMemoryParams(nint addr) : base(addr) { }
        public Array<byte> ModMemory { get { return new Array<byte>(this[nameof(ModMemory)].Address); } }
    }
}