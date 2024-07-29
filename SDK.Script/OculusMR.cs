using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.HeadMountedDisplaySDK;
using SDK.Script.CoreUObjectSDK;
using SDK.Script.OculusHMDSDK;
namespace SDK.Script.OculusMRSDK
{
    public class OculusMR_CastingCameraActor : SceneCapture2D
    {
        public OculusMR_CastingCameraActor(nint addr) : base(addr) { }
        public VRNotificationsComponent VRNotificationComponent { get { return this[nameof(VRNotificationComponent)].As<VRNotificationsComponent>(); } set { this["VRNotificationComponent"] = value; } }
        public Texture2D CameraColorTexture { get { return this[nameof(CameraColorTexture)].As<Texture2D>(); } set { this["CameraColorTexture"] = value; } }
        public Texture2D CameraDepthTexture { get { return this[nameof(CameraDepthTexture)].As<Texture2D>(); } set { this["CameraDepthTexture"] = value; } }
        public OculusMR_PlaneMeshComponent PlaneMeshComponent { get { return this[nameof(PlaneMeshComponent)].As<OculusMR_PlaneMeshComponent>(); } set { this["PlaneMeshComponent"] = value; } }
        public Material ChromaKeyMaterial { get { return this[nameof(ChromaKeyMaterial)].As<Material>(); } set { this["ChromaKeyMaterial"] = value; } }
        public Material OpaqueColoredMaterial { get { return this[nameof(OpaqueColoredMaterial)].As<Material>(); } set { this["OpaqueColoredMaterial"] = value; } }
        public MaterialInstanceDynamic ChromaKeyMaterialInstance { get { return this[nameof(ChromaKeyMaterialInstance)].As<MaterialInstanceDynamic>(); } set { this["ChromaKeyMaterialInstance"] = value; } }
        public MaterialInstanceDynamic CameraFrameMaterialInstance { get { return this[nameof(CameraFrameMaterialInstance)].As<MaterialInstanceDynamic>(); } set { this["CameraFrameMaterialInstance"] = value; } }
        public MaterialInstanceDynamic BackdropMaterialInstance { get { return this[nameof(BackdropMaterialInstance)].As<MaterialInstanceDynamic>(); } set { this["BackdropMaterialInstance"] = value; } }
        public Texture2D DefaultTexture_White { get { return this[nameof(DefaultTexture_White)].As<Texture2D>(); } set { this["DefaultTexture_White"] = value; } }
        public Array<TextureRenderTarget2D> BackgroundRenderTargets { get { return new Array<TextureRenderTarget2D>(this[nameof(BackgroundRenderTargets)].Address); } }
        public SceneCapture2D ForegroundCaptureActor { get { return this[nameof(ForegroundCaptureActor)].As<SceneCapture2D>(); } set { this["ForegroundCaptureActor"] = value; } }
        public Array<TextureRenderTarget2D> ForegroundRenderTargets { get { return new Array<TextureRenderTarget2D>(this[nameof(ForegroundRenderTargets)].Address); } }
        public Array<double> PoseTimes { get { return new Array<double>(this[nameof(PoseTimes)].Address); } }
        public OculusMR_Settings MRSettings { get { return this[nameof(MRSettings)].As<OculusMR_Settings>(); } set { this["MRSettings"] = value; } }
        public OculusMR_State MRState { get { return this[nameof(MRState)].As<OculusMR_State>(); } set { this["MRState"] = value; } }
    }
    public class OculusMR_PlaneMeshComponent : MeshComponent
    {
        public OculusMR_PlaneMeshComponent(nint addr) : base(addr) { }
        public bool SetCustomMeshTriangles(Array<OculusMR_PlaneMeshTriangle> Triangles) { return Invoke<bool>(nameof(SetCustomMeshTriangles), Triangles); }
        public void ClearCustomMeshTriangles() { Invoke(nameof(ClearCustomMeshTriangles)); }
        public void AddCustomMeshTriangles(Array<OculusMR_PlaneMeshTriangle> Triangles) { Invoke(nameof(AddCustomMeshTriangles), Triangles); }
    }
    public class OculusMR_Settings : Object
    {
        public OculusMR_Settings(nint addr) : base(addr) { }
        public EOculusMR_ClippingReference ClippingReference { get { return (EOculusMR_ClippingReference)this[nameof(ClippingReference)].GetValue<int>(); } set { this[nameof(ClippingReference)].SetValue<int>((int)value); } }
        public bool bUseTrackedCameraResolution { get { return this[nameof(bUseTrackedCameraResolution)].Flag; } set { this[nameof(bUseTrackedCameraResolution)].Flag = value; } }
        public int WidthPerView { get { return this[nameof(WidthPerView)].GetValue<int>(); } set { this[nameof(WidthPerView)].SetValue<int>(value); } }
        public int HeightPerView { get { return this[nameof(HeightPerView)].GetValue<int>(); } set { this[nameof(HeightPerView)].SetValue<int>(value); } }
        public float CastingLatency { get { return this[nameof(CastingLatency)].GetValue<float>(); } set { this[nameof(CastingLatency)].SetValue<float>(value); } }
        public Color BackdropColor { get { return this[nameof(BackdropColor)].As<Color>(); } set { this["BackdropColor"] = value; } }
        public float HandPoseStateLatency { get { return this[nameof(HandPoseStateLatency)].GetValue<float>(); } set { this[nameof(HandPoseStateLatency)].SetValue<float>(value); } }
        public Color ChromaKeyColor { get { return this[nameof(ChromaKeyColor)].As<Color>(); } set { this["ChromaKeyColor"] = value; } }
        public float ChromaKeySimilarity { get { return this[nameof(ChromaKeySimilarity)].GetValue<float>(); } set { this[nameof(ChromaKeySimilarity)].SetValue<float>(value); } }
        public float ChromaKeySmoothRange { get { return this[nameof(ChromaKeySmoothRange)].GetValue<float>(); } set { this[nameof(ChromaKeySmoothRange)].SetValue<float>(value); } }
        public float ChromaKeySpillRange { get { return this[nameof(ChromaKeySpillRange)].GetValue<float>(); } set { this[nameof(ChromaKeySpillRange)].SetValue<float>(value); } }
        public EOculusMR_PostProcessEffects ExternalCompositionPostProcessEffects { get { return (EOculusMR_PostProcessEffects)this[nameof(ExternalCompositionPostProcessEffects)].GetValue<int>(); } set { this[nameof(ExternalCompositionPostProcessEffects)].SetValue<int>((int)value); } }
        public bool bIsCasting { get { return this[nameof(bIsCasting)].Flag; } set { this[nameof(bIsCasting)].Flag = value; } }
        public EOculusMR_CompositionMethod CompositionMethod { get { return (EOculusMR_CompositionMethod)this[nameof(CompositionMethod)].GetValue<int>(); } set { this[nameof(CompositionMethod)].SetValue<int>((int)value); } }
        public EOculusMR_CameraDeviceEnum CapturingCamera { get { return (EOculusMR_CameraDeviceEnum)this[nameof(CapturingCamera)].GetValue<int>(); } set { this[nameof(CapturingCamera)].SetValue<int>((int)value); } }
        public void SetIsCasting(bool Val) { Invoke(nameof(SetIsCasting), Val); }
        public void SetCompositionMethod(EOculusMR_CompositionMethod Val) { Invoke(nameof(SetCompositionMethod), Val); }
        public void SetCapturingCamera(EOculusMR_CameraDeviceEnum Val) { Invoke(nameof(SetCapturingCamera), Val); }
        public void SaveToIni() { Invoke(nameof(SaveToIni)); }
        public void LoadFromIni() { Invoke(nameof(LoadFromIni)); }
        public bool GetIsCasting() { return Invoke<bool>(nameof(GetIsCasting)); }
        public EOculusMR_CompositionMethod GetCompositionMethod() { return Invoke<EOculusMR_CompositionMethod>(nameof(GetCompositionMethod)); }
        public EOculusMR_CameraDeviceEnum GetCapturingCamera() { return Invoke<EOculusMR_CameraDeviceEnum>(nameof(GetCapturingCamera)); }
        public int GetBindToTrackedCameraIndex() { return Invoke<int>(nameof(GetBindToTrackedCameraIndex)); }
        public void BindToTrackedCameraIndexIfAvailable(int InTrackedCameraIndex) { Invoke(nameof(BindToTrackedCameraIndexIfAvailable), InTrackedCameraIndex); }
    }
    public class OculusMR_State : Object
    {
        public OculusMR_State(nint addr) : base(addr) { }
        public TrackedCamera TrackedCamera { get { return this[nameof(TrackedCamera)].As<TrackedCamera>(); } set { this["TrackedCamera"] = value; } }
        public SceneComponent TrackingReferenceComponent { get { return this[nameof(TrackingReferenceComponent)].As<SceneComponent>(); } set { this["TrackingReferenceComponent"] = value; } }
        public double ScalingFactor { get { return this[nameof(ScalingFactor)].GetValue<double>(); } set { this[nameof(ScalingFactor)].SetValue<double>(value); } }
        public bool ChangeCameraStateRequested { get { return this[nameof(ChangeCameraStateRequested)].Flag; } set { this[nameof(ChangeCameraStateRequested)].Flag = value; } }
        public bool BindToTrackedCameraIndexRequested { get { return this[nameof(BindToTrackedCameraIndexRequested)].Flag; } set { this[nameof(BindToTrackedCameraIndexRequested)].Flag = value; } }
    }
    public class OculusMRFunctionLibrary : BlueprintFunctionLibrary
    {
        public OculusMRFunctionLibrary(nint addr) : base(addr) { }
        public bool SetTrackingReferenceComponent(SceneComponent Component) { return Invoke<bool>(nameof(SetTrackingReferenceComponent), Component); }
        public bool SetMrcScalingFactor(float ScalingFactor) { return Invoke<bool>(nameof(SetMrcScalingFactor), ScalingFactor); }
        public bool IsMrcEnabled() { return Invoke<bool>(nameof(IsMrcEnabled)); }
        public bool IsMrcActive() { return Invoke<bool>(nameof(IsMrcActive)); }
        public SceneComponent GetTrackingReferenceComponent() { return Invoke<SceneComponent>(nameof(GetTrackingReferenceComponent)); }
        public OculusMR_Settings GetOculusMRSettings() { return Invoke<OculusMR_Settings>(nameof(GetOculusMRSettings)); }
        public float GetMrcScalingFactor() { return Invoke<float>(nameof(GetMrcScalingFactor)); }
    }
    public enum EOculusMR_CompositionMethod : int
    {
        ExternalComposition = 0,
        DirectComposition = 1,
        EOculusMR_MAX = 2,
    }
    public enum EOculusMR_PostProcessEffects : int
    {
        PPE_Off = 0,
        PPE_On = 1,
        PPE_MAX = 2,
    }
    public enum EOculusMR_ClippingReference : int
    {
        CR_TrackingReference = 0,
        CR_Head = 1,
        CR_MAX = 2,
    }
    public enum EOculusMR_CameraDeviceEnum : int
    {
        CD_None = 0,
        CD_WebCamera0 = 1,
        CD_WebCamera1 = 2,
        CD_MAX = 3,
    }
    public class OculusMR_PlaneMeshTriangle : Object
    {
        public OculusMR_PlaneMeshTriangle(nint addr) : base(addr) { }
        public Vector Vertex0 { get { return this[nameof(Vertex0)].As<Vector>(); } set { this["Vertex0"] = value; } }
        public Vector2D UV0 { get { return this[nameof(UV0)].As<Vector2D>(); } set { this["UV0"] = value; } }
        public Vector Vertex1 { get { return this[nameof(Vertex1)].As<Vector>(); } set { this["Vertex1"] = value; } }
        public Vector2D UV1 { get { return this[nameof(UV1)].As<Vector2D>(); } set { this["UV1"] = value; } }
        public Vector Vertex2 { get { return this[nameof(Vertex2)].As<Vector>(); } set { this["Vertex2"] = value; } }
        public Vector2D UV2 { get { return this[nameof(UV2)].As<Vector2D>(); } set { this["UV2"] = value; } }
    }
    public class TrackedCamera : Object
    {
        public TrackedCamera(nint addr) : base(addr) { }
        public int Index { get { return this[nameof(Index)].GetValue<int>(); } set { this[nameof(Index)].SetValue<int>(value); } }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public double UpdateTime { get { return this[nameof(UpdateTime)].GetValue<double>(); } set { this[nameof(UpdateTime)].SetValue<double>(value); } }
        public float FieldOfView { get { return this[nameof(FieldOfView)].GetValue<float>(); } set { this[nameof(FieldOfView)].SetValue<float>(value); } }
        public int SizeX { get { return this[nameof(SizeX)].GetValue<int>(); } set { this[nameof(SizeX)].SetValue<int>(value); } }
        public int SizeY { get { return this[nameof(SizeY)].GetValue<int>(); } set { this[nameof(SizeY)].SetValue<int>(value); } }
        public ETrackedDeviceType AttachedTrackedDevice { get { return (ETrackedDeviceType)this[nameof(AttachedTrackedDevice)].GetValue<int>(); } set { this[nameof(AttachedTrackedDevice)].SetValue<int>((int)value); } }
        public Rotator CalibratedRotation { get { return this[nameof(CalibratedRotation)].As<Rotator>(); } set { this["CalibratedRotation"] = value; } }
        public Vector CalibratedOffset { get { return this[nameof(CalibratedOffset)].As<Vector>(); } set { this["CalibratedOffset"] = value; } }
        public Rotator UserRotation { get { return this[nameof(UserRotation)].As<Rotator>(); } set { this["UserRotation"] = value; } }
        public Vector UserOffset { get { return this[nameof(UserOffset)].As<Vector>(); } set { this["UserOffset"] = value; } }
        public Rotator RawRotation { get { return this[nameof(RawRotation)].As<Rotator>(); } set { this["RawRotation"] = value; } }
        public Vector RawOffset { get { return this[nameof(RawOffset)].As<Vector>(); } set { this["RawOffset"] = value; } }
    }
}
