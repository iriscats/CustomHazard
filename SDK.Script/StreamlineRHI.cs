using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
namespace SDK.Script.StreamlineRHISDK
{
    public class StreamlineOverrideSettings : Object
    {
        public StreamlineOverrideSettings(nint addr) : base(addr) { }
        public EStreamlineSettingOverride EnableDLSSFGInPlayInEditorViewportsOverride { get { return (EStreamlineSettingOverride)this[nameof(EnableDLSSFGInPlayInEditorViewportsOverride)].GetValue<int>(); } set { this[nameof(EnableDLSSFGInPlayInEditorViewportsOverride)].SetValue<int>((int)value); } }
        public EStreamlineSettingOverride LoadDebugOverlayOverride { get { return (EStreamlineSettingOverride)this[nameof(LoadDebugOverlayOverride)].GetValue<int>(); } set { this[nameof(LoadDebugOverlayOverride)].SetValue<int>((int)value); } }
    }
    public class StreamlineSettings : Object
    {
        public StreamlineSettings(nint addr) : base(addr) { }
        public bool bEnableStreamlineD3D12 { get { return this[nameof(bEnableStreamlineD3D12)].Flag; } set { this[nameof(bEnableStreamlineD3D12)].Flag = value; } }
        public bool bEnableStreamlineD3D11 { get { return this[nameof(bEnableStreamlineD3D11)].Flag; } set { this[nameof(bEnableStreamlineD3D11)].Flag = value; } }
        public bool bEnableDLSSFGInPlayInEditorViewports { get { return this[nameof(bEnableDLSSFGInPlayInEditorViewports)].Flag; } set { this[nameof(bEnableDLSSFGInPlayInEditorViewports)].Flag = value; } }
        public bool bLoadDebugOverlay { get { return this[nameof(bLoadDebugOverlay)].Flag; } set { this[nameof(bLoadDebugOverlay)].Flag = value; } }
        public bool bAllowOTAUpdate { get { return this[nameof(bAllowOTAUpdate)].Flag; } set { this[nameof(bAllowOTAUpdate)].Flag = value; } }
        public int NVIDIANGXApplicationId { get { return this[nameof(NVIDIANGXApplicationId)].GetValue<int>(); } set { this[nameof(NVIDIANGXApplicationId)].SetValue<int>(value); } }
    }
    public enum EStreamlineSettingOverride : int
    {
        Enabled = 0,
        Disabled = 1,
        UseProjectSettings = 2,
        EStreamlineSettingOverride_MAX = 3,
    }
}
