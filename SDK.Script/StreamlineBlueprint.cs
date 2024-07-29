using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
namespace SDK.Script.StreamlineBlueprintSDK
{
    public class StreamlineLibrary : BlueprintFunctionLibrary
    {
        public StreamlineLibrary(nint addr) : base(addr) { }
        public UStreamlineFeatureSupport QueryStreamlineFeatureSupport(UStreamlineFeature Feature) { return Invoke<UStreamlineFeatureSupport>(nameof(QueryStreamlineFeatureSupport), Feature); }
        public bool IsStreamlineFeatureSupported(UStreamlineFeature Feature) { return Invoke<bool>(nameof(IsStreamlineFeatureSupported), Feature); }
        public StreamlineFeatureRequirements GetStreamlineFeatureInformation(UStreamlineFeature Feature) { return Invoke<StreamlineFeatureRequirements>(nameof(GetStreamlineFeatureInformation), Feature); }
        public void BreakStreamlineFeatureRequirements(UStreamlineFeatureRequirementsFlags Requirements, bool D3D11Supported, bool D3D12Supported, bool VulkanSupported, bool VSyncOffRequired, bool HardwareSchedulingRequired) { Invoke(nameof(BreakStreamlineFeatureRequirements), Requirements, D3D11Supported, D3D12Supported, VulkanSupported, VSyncOffRequired, HardwareSchedulingRequired); }
    }
    public class StreamlineLibraryDLSSG : BlueprintFunctionLibrary
    {
        public StreamlineLibraryDLSSG(nint addr) : base(addr) { }
        public void SetDLSSGMode(UStreamlineDLSSGMode DLSSGMode) { Invoke(nameof(SetDLSSGMode), DLSSGMode); }
        public UStreamlineFeatureSupport QueryDLSSGSupport() { return Invoke<UStreamlineFeatureSupport>(nameof(QueryDLSSGSupport)); }
        public bool IsDLSSGSupported() { return Invoke<bool>(nameof(IsDLSSGSupported)); }
        public bool IsDLSSGModeSupported(UStreamlineDLSSGMode DLSSGMode) { return Invoke<bool>(nameof(IsDLSSGModeSupported), DLSSGMode); }
        public Array<UStreamlineDLSSGMode> GetSupportedDLSSGModes() { return Invoke<Array<UStreamlineDLSSGMode>>(nameof(GetSupportedDLSSGModes)); }
        public UStreamlineDLSSGMode GetDLSSGMode() { return Invoke<UStreamlineDLSSGMode>(nameof(GetDLSSGMode)); }
        public void GetDLSSGFrameTiming(float FrameRateInHertz, int FramesPresented) { Invoke(nameof(GetDLSSGFrameTiming), FrameRateInHertz, FramesPresented); }
        public UStreamlineDLSSGMode GetDefaultDLSSGMode() { return Invoke<UStreamlineDLSSGMode>(nameof(GetDefaultDLSSGMode)); }
    }
    public class StreamlineLibraryReflex : BlueprintFunctionLibrary
    {
        public StreamlineLibraryReflex(nint addr) : base(addr) { }
        public void SetReflexMode(UStreamlineReflexMode Mode) { Invoke(nameof(SetReflexMode), Mode); }
        public UStreamlineFeatureSupport QueryReflexSupport() { return Invoke<UStreamlineFeatureSupport>(nameof(QueryReflexSupport)); }
        public bool IsReflexSupported() { return Invoke<bool>(nameof(IsReflexSupported)); }
        public float GetRenderLatencyInMs() { return Invoke<float>(nameof(GetRenderLatencyInMs)); }
        public UStreamlineReflexMode GetReflexMode() { return Invoke<UStreamlineReflexMode>(nameof(GetReflexMode)); }
        public float GetGameToRenderLatencyInMs() { return Invoke<float>(nameof(GetGameToRenderLatencyInMs)); }
        public float GetGameLatencyInMs() { return Invoke<float>(nameof(GetGameLatencyInMs)); }
        public UStreamlineReflexMode GetDefaultReflexMode() { return Invoke<UStreamlineReflexMode>(nameof(GetDefaultReflexMode)); }
    }
    public enum UStreamlineFeatureRequirementsFlags : int
    {
        None = 0,
        D3D11Supported = 1,
        D3D12Supported = 2,
        VulkanSupported = 4,
        VSyncOffRequired = 8,
        HardwareSchedulingRequired = 16,
        UStreamlineFeatureRequirementsFlags_MAX = 17,
    }
    public enum UStreamlineFeatureSupport : int
    {
        Supported = 0,
        NotSupported = 1,
        NotSupportedIncompatibleHardware = 2,
        NotSupportedDriverOutOfDate = 3,
        NotSupportedOperatingSystemOutOfDate = 4,
        NotSupportedHardewareSchedulingDisabled = 5,
        NotSupportedByRHI = 6,
        NotSupportedByPlatformAtBuildTime = 7,
        NotSupportedIncompatibleAPICaptureToolActive = 8,
        UStreamlineFeatureSupport_MAX = 9,
    }
    public enum UStreamlineFeature : int
    {
        DLSSG = 0,
        Reflex = 1,
        Count = 2,
        UStreamlineFeature_MAX = 3,
    }
    public enum UStreamlineDLSSGMode : int
    {
        Off = 0,
        On = 1,
        Auto = 2,
        UStreamlineDLSSGMode_MAX = 3,
    }
    public enum UStreamlineReflexMode : int
    {
        Disabled = 0,
        Enabled = 1,
        EnabledPlusBoost = 3,
        UStreamlineReflexMode_MAX = 4,
    }
    public class StreamlineFeatureRequirements : Object
    {
        public StreamlineFeatureRequirements(nint addr) : base(addr) { }
        public UStreamlineFeatureSupport Support { get { return (UStreamlineFeatureSupport)this[nameof(Support)].GetValue<int>(); } set { this[nameof(Support)].SetValue<int>((int)value); } }
        public UStreamlineFeatureRequirementsFlags Requirements { get { return (UStreamlineFeatureRequirementsFlags)this[nameof(Requirements)].GetValue<int>(); } set { this[nameof(Requirements)].SetValue<int>((int)value); } }
        public StreamlineVersion RequiredOperatingSystemVersion { get { return this[nameof(RequiredOperatingSystemVersion)].As<StreamlineVersion>(); } set { this["RequiredOperatingSystemVersion"] = value; } }
        public StreamlineVersion DetectedOperatingSystemVersion { get { return this[nameof(DetectedOperatingSystemVersion)].As<StreamlineVersion>(); } set { this["DetectedOperatingSystemVersion"] = value; } }
        public StreamlineVersion RequiredDriverVersion { get { return this[nameof(RequiredDriverVersion)].As<StreamlineVersion>(); } set { this["RequiredDriverVersion"] = value; } }
        public StreamlineVersion DetectedDriverVersion { get { return this[nameof(DetectedDriverVersion)].As<StreamlineVersion>(); } set { this["DetectedDriverVersion"] = value; } }
    }
    public class StreamlineVersion : Object
    {
        public StreamlineVersion(nint addr) : base(addr) { }
        public int Major { get { return this[nameof(Major)].GetValue<int>(); } set { this[nameof(Major)].SetValue<int>(value); } }
        public int Minor { get { return this[nameof(Minor)].GetValue<int>(); } set { this[nameof(Minor)].SetValue<int>(value); } }
        public int Build { get { return this[nameof(Build)].GetValue<int>(); } set { this[nameof(Build)].SetValue<int>(value); } }
    }
}
