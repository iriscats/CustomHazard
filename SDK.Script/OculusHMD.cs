using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.OculusHMDSDK
{
    public class OculusFunctionLibrary : BlueprintFunctionLibrary
    {
        public OculusFunctionLibrary(nint addr) : base(addr) { }
        public void SetReorientHMDOnControllerRecenter(bool recenterMode) { Invoke(nameof(SetReorientHMDOnControllerRecenter), recenterMode); }
        public void SetPositionScale3D(Vector PosScale3D) { Invoke(nameof(SetPositionScale3D), PosScale3D); }
        public void SetGuardianVisibility(bool GuardianVisible) { Invoke(nameof(SetGuardianVisibility), GuardianVisible); }
        public void SetFixedFoveatedRenderingLevel(EFixedFoveatedRenderingLevel Level, bool isDynamic) { Invoke(nameof(SetFixedFoveatedRenderingLevel), Level, isDynamic); }
        public void SetDisplayFrequency(float RequestedFrequency) { Invoke(nameof(SetDisplayFrequency), RequestedFrequency); }
        public void SetCPUAndGPULevels(int CPULevel, int GPULevel) { Invoke(nameof(SetCPUAndGPULevels), CPULevel, GPULevel); }
        public void SetColorScaleAndOffset(LinearColor ColorScale, LinearColor ColorOffset, bool bApplyToAllLayers) { Invoke(nameof(SetColorScaleAndOffset), ColorScale, ColorOffset, bApplyToAllLayers); }
        public void SetClientColorDesc(EColorSpace ColorSpace) { Invoke(nameof(SetClientColorDesc), ColorSpace); }
        public void SetBaseRotationAndPositionOffset(Rotator BaseRot, Vector PosOffset, byte options) { Invoke(nameof(SetBaseRotationAndPositionOffset), BaseRot, PosOffset, options); }
        public void SetBaseRotationAndBaseOffsetInMeters(Rotator Rotation, Vector BaseOffsetInMeters, byte options) { Invoke(nameof(SetBaseRotationAndBaseOffsetInMeters), Rotation, BaseOffsetInMeters, options); }
        public bool IsGuardianDisplayed() { return Invoke<bool>(nameof(IsGuardianDisplayed)); }
        public bool IsGuardianConfigured() { return Invoke<bool>(nameof(IsGuardianConfigured)); }
        public bool IsDeviceTracked(ETrackedDeviceType DeviceType) { return Invoke<bool>(nameof(IsDeviceTracked), DeviceType); }
        public bool HasSystemOverlayPresent() { return Invoke<bool>(nameof(HasSystemOverlayPresent)); }
        public bool HasInputFocus() { return Invoke<bool>(nameof(HasInputFocus)); }
        public bool GetUserProfile(HmdUserProfile Profile) { return Invoke<bool>(nameof(GetUserProfile), Profile); }
        public bool GetSystemHmd3DofModeEnabled() { return Invoke<bool>(nameof(GetSystemHmd3DofModeEnabled)); }
        public void GetRawSensorData(Vector AngularAcceleration, Vector LinearAcceleration, Vector AngularVelocity, Vector LinearVelocity, float TimeInSeconds, ETrackedDeviceType DeviceType) { Invoke(nameof(GetRawSensorData), AngularAcceleration, LinearAcceleration, AngularVelocity, LinearVelocity, TimeInSeconds, DeviceType); }
        public void GetPose(Rotator DeviceRotation, Vector DevicePosition, Vector NeckPosition, bool bUseOrienationForPlayerCamera, bool bUsePositionForPlayerCamera, Vector PositionScale) { Invoke(nameof(GetPose), DeviceRotation, DevicePosition, NeckPosition, bUseOrienationForPlayerCamera, bUsePositionForPlayerCamera, PositionScale); }
        public GuardianTestResult GetPointGuardianIntersection(Vector Point, EBoundaryType BoundaryType) { return Invoke<GuardianTestResult>(nameof(GetPointGuardianIntersection), Point, BoundaryType); }
        public Transform GetPlayAreaTransform() { return Invoke<Transform>(nameof(GetPlayAreaTransform)); }
        public GuardianTestResult GetNodeGuardianIntersection(ETrackedDeviceType DeviceType, EBoundaryType BoundaryType) { return Invoke<GuardianTestResult>(nameof(GetNodeGuardianIntersection), DeviceType, BoundaryType); }
        public EColorSpace GetHmdColorDesc() { return Invoke<EColorSpace>(nameof(GetHmdColorDesc)); }
        public UArray<Vector> GetGuardianPoints(EBoundaryType BoundaryType, bool UsePawnSpace) { return Invoke<UArray<Vector>>(nameof(GetGuardianPoints), BoundaryType, UsePawnSpace); }
        public Vector GetGuardianDimensions(EBoundaryType BoundaryType) { return Invoke<Vector>(nameof(GetGuardianDimensions), BoundaryType); }
        public void GetGPUUtilization(bool IsGPUAvailable, float GPUUtilization) { Invoke(nameof(GetGPUUtilization), IsGPUAvailable, GPUUtilization); }
        public float GetGPUFrameTime() { return Invoke<float>(nameof(GetGPUFrameTime)); }
        public EFixedFoveatedRenderingLevel GetFixedFoveatedRenderingLevel() { return Invoke<EFixedFoveatedRenderingLevel>(nameof(GetFixedFoveatedRenderingLevel)); }
        public EOculusDeviceType GetDeviceType() { return Invoke<EOculusDeviceType>(nameof(GetDeviceType)); }
        public Object GetDeviceName() { return Invoke<Object>(nameof(GetDeviceName)); }
        public float GetCurrentDisplayFrequency() { return Invoke<float>(nameof(GetCurrentDisplayFrequency)); }
        public void GetBaseRotationAndPositionOffset(Rotator OutRot, Vector OutPosOffset) { Invoke(nameof(GetBaseRotationAndPositionOffset), OutRot, OutPosOffset); }
        public void GetBaseRotationAndBaseOffsetInMeters(Rotator OutRotation, Vector OutBaseOffsetInMeters) { Invoke(nameof(GetBaseRotationAndBaseOffsetInMeters), OutRotation, OutBaseOffsetInMeters); }
        public UArray<float> GetAvailableDisplayFrequencies() { return Invoke<UArray<float>>(nameof(GetAvailableDisplayFrequencies)); }
        public void EnablePositionTracking(bool bPositionTracking) { Invoke(nameof(EnablePositionTracking), bPositionTracking); }
        public void EnableOrientationTracking(bool bOrientationTracking) { Invoke(nameof(EnableOrientationTracking), bOrientationTracking); }
        public void ClearLoadingSplashScreens() { Invoke(nameof(ClearLoadingSplashScreens)); }
        public void AddLoadingSplashScreen(Texture2D Texture, Vector TranslationInMeters, Rotator Rotation, Vector2D SizeInMeters, Rotator DeltaRotation, bool bClearBeforeAdd) { Invoke(nameof(AddLoadingSplashScreen), Texture, TranslationInMeters, Rotation, SizeInMeters, DeltaRotation, bClearBeforeAdd); }
    }
    public class OculusHMDRuntimeSettings : Object
    {
        public OculusHMDRuntimeSettings(nint addr) : base(addr) { }
        public bool bAutoEnabled { get { return this[nameof(bAutoEnabled)].Flag; } set { this[nameof(bAutoEnabled)].Flag = value; } }
        public UArray<OculusSplashDesc> SplashDescs { get { return new UArray<OculusSplashDesc>(this[nameof(SplashDescs)].Address); } }
        public bool bEnableSpecificColorGamut { get { return this[nameof(bEnableSpecificColorGamut)].Flag; } set { this[nameof(bEnableSpecificColorGamut)].Flag = value; } }
        public EColorSpace ColorSpace { get { return (EColorSpace)this[nameof(ColorSpace)].GetValue<int>(); } set { this[nameof(ColorSpace)].SetValue<int>((int)value); } }
        public bool bSupportsDash { get { return this[nameof(bSupportsDash)].Flag; } set { this[nameof(bSupportsDash)].Flag = value; } }
        public bool bCompositesDepth { get { return this[nameof(bCompositesDepth)].Flag; } set { this[nameof(bCompositesDepth)].Flag = value; } }
        public bool bHQDistortion { get { return this[nameof(bHQDistortion)].Flag; } set { this[nameof(bHQDistortion)].Flag = value; } }
        public float PixelDensityMin { get { return this[nameof(PixelDensityMin)].GetValue<float>(); } set { this[nameof(PixelDensityMin)].SetValue<float>(value); } }
        public float PixelDensityMax { get { return this[nameof(PixelDensityMax)].GetValue<float>(); } set { this[nameof(PixelDensityMax)].SetValue<float>(value); } }
        public int CPULevel { get { return this[nameof(CPULevel)].GetValue<int>(); } set { this[nameof(CPULevel)].SetValue<int>(value); } }
        public int GPULevel { get { return this[nameof(GPULevel)].GetValue<int>(); } set { this[nameof(GPULevel)].SetValue<int>(value); } }
        public EFixedFoveatedRenderingLevel FFRLevel { get { return (EFixedFoveatedRenderingLevel)this[nameof(FFRLevel)].GetValue<int>(); } set { this[nameof(FFRLevel)].SetValue<int>((int)value); } }
        public bool FFRDynamic { get { return this[nameof(FFRDynamic)].Flag; } set { this[nameof(FFRDynamic)].Flag = value; } }
        public bool bChromaCorrection { get { return this[nameof(bChromaCorrection)].Flag; } set { this[nameof(bChromaCorrection)].Flag = value; } }
        public bool bRecenterHMDWithController { get { return this[nameof(bRecenterHMDWithController)].Flag; } set { this[nameof(bRecenterHMDWithController)].Flag = value; } }
        public bool bFocusAware { get { return this[nameof(bFocusAware)].Flag; } set { this[nameof(bFocusAware)].Flag = value; } }
        public bool bLateLatching { get { return this[nameof(bLateLatching)].Flag; } set { this[nameof(bLateLatching)].Flag = value; } }
        public bool bRequiresSystemKeyboard { get { return this[nameof(bRequiresSystemKeyboard)].Flag; } set { this[nameof(bRequiresSystemKeyboard)].Flag = value; } }
        public EHandTrackingSupport HandTrackingSupport { get { return (EHandTrackingSupport)this[nameof(HandTrackingSupport)].GetValue<int>(); } set { this[nameof(HandTrackingSupport)].SetValue<int>((int)value); } }
        public bool bPhaseSync { get { return this[nameof(bPhaseSync)].Flag; } set { this[nameof(bPhaseSync)].Flag = value; } }
    }
    public class OculusResourceHolder : Object
    {
        public OculusResourceHolder(nint addr) : base(addr) { }
        public Material PokeAHoleMaterial { get { return this[nameof(PokeAHoleMaterial)].As<Material>(); } set { this["PokeAHoleMaterial"] = value; } }
    }
    public class OculusSceneCaptureCubemap : Object
    {
        public OculusSceneCaptureCubemap(nint addr) : base(addr) { }
        public UArray<SceneCaptureComponent2D> CaptureComponents { get { return new UArray<SceneCaptureComponent2D>(this[nameof(CaptureComponents)].Address); } }
    }
    public enum EOculusDeviceType : int
    {
        OculusMobile_Deprecated0 = 0,
        OculusQuest = 1,
        OculusQuest2 = 2,
        Rift = 100,
        Rift_S = 101,
        Quest_Link = 102,
        Quest2_Link = 103,
        OculusUnknown = 200,
        EOculusDeviceType_MAX = 201,
    }
    public enum EHandTrackingSupport : int
    {
        ControllersOnly = 0,
        ControllersAndHands = 1,
        HandsOnly = 2,
        EHandTrackingSupport_MAX = 3,
    }
    public enum EColorSpace : int
    {
        Unknown = 0,
        Unmanaged = 1,
        Rec_2021 = 2,
        Rec_710 = 3,
        Rift_CV1 = 4,
        Rift_S = 5,
        Quest = 6,
        P3 = 7,
        Adobe_RGB = 8,
        EColorSpace_MAX = 9,
    }
    public enum EBoundaryType : int
    {
        Boundary_Outer = 0,
        Boundary_PlayArea = 1,
        Boundary_MAX = 2,
    }
    public enum EFixedFoveatedRenderingLevel : int
    {
        FFR_Off = 0,
        FFR_Low = 1,
        FFR_Medium = 2,
        FFR_High = 3,
        FFR_HighTop = 4,
        FFR_MAX = 5,
    }
    public enum ETrackedDeviceType : int
    {
        None = 0,
        HMD = 1,
        LTouch = 2,
        RTouch = 3,
        Touch = 4,
        DeviceObjectZero = 5,
        All = 6,
        ETrackedDeviceType_MAX = 7,
    }
    public class GuardianTestResult : Object
    {
        public GuardianTestResult(nint addr) : base(addr) { }
        public bool IsTriggering { get { return this[nameof(IsTriggering)].Flag; } set { this[nameof(IsTriggering)].Flag = value; } }
        public ETrackedDeviceType DeviceType { get { return (ETrackedDeviceType)this[nameof(DeviceType)].GetValue<int>(); } set { this[nameof(DeviceType)].SetValue<int>((int)value); } }
        public float ClosestDistance { get { return this[nameof(ClosestDistance)].GetValue<float>(); } set { this[nameof(ClosestDistance)].SetValue<float>(value); } }
        public Vector ClosestPoint { get { return this[nameof(ClosestPoint)].As<Vector>(); } set { this["ClosestPoint"] = value; } }
        public Vector ClosestPointNormal { get { return this[nameof(ClosestPointNormal)].As<Vector>(); } set { this["ClosestPointNormal"] = value; } }
    }
    public class HmdUserProfile : Object
    {
        public HmdUserProfile(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Gender { get { return this[nameof(Gender)]; } set { this[nameof(Gender)] = value; } }
        public float PlayerHeight { get { return this[nameof(PlayerHeight)].GetValue<float>(); } set { this[nameof(PlayerHeight)].SetValue<float>(value); } }
        public float EyeHeight { get { return this[nameof(EyeHeight)].GetValue<float>(); } set { this[nameof(EyeHeight)].SetValue<float>(value); } }
        public float IPD { get { return this[nameof(IPD)].GetValue<float>(); } set { this[nameof(IPD)].SetValue<float>(value); } }
        public Vector2D NeckToEyeDistance { get { return this[nameof(NeckToEyeDistance)].As<Vector2D>(); } set { this["NeckToEyeDistance"] = value; } }
        public UArray<HmdUserProfileField> ExtraFields { get { return new UArray<HmdUserProfileField>(this[nameof(ExtraFields)].Address); } }
    }
    public class HmdUserProfileField : Object
    {
        public HmdUserProfileField(nint addr) : base(addr) { }
        public Object FieldName { get { return this[nameof(FieldName)]; } set { this[nameof(FieldName)] = value; } }
        public Object FieldValue { get { return this[nameof(FieldValue)]; } set { this[nameof(FieldValue)] = value; } }
    }
    public class OculusSplashDesc : Object
    {
        public OculusSplashDesc(nint addr) : base(addr) { }
        public SoftObjectPath TexturePath { get { return this[nameof(TexturePath)].As<SoftObjectPath>(); } set { this["TexturePath"] = value; } }
        public Transform TransformInMeters { get { return this[nameof(TransformInMeters)].As<Transform>(); } set { this["TransformInMeters"] = value; } }
        public Vector2D QuadSizeInMeters { get { return this[nameof(QuadSizeInMeters)].As<Vector2D>(); } set { this["QuadSizeInMeters"] = value; } }
        public Quat DeltaRotation { get { return this[nameof(DeltaRotation)].As<Quat>(); } set { this["DeltaRotation"] = value; } }
        public Vector2D TextureOffset { get { return this[nameof(TextureOffset)].As<Vector2D>(); } set { this["TextureOffset"] = value; } }
        public Vector2D TextureScale { get { return this[nameof(TextureScale)].As<Vector2D>(); } set { this["TextureScale"] = value; } }
        public bool bNoAlphaChannel { get { return this[nameof(bNoAlphaChannel)].Flag; } set { this[nameof(bNoAlphaChannel)].Flag = value; } }
    }
}
