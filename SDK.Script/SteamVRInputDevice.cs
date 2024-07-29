using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.SteamVRInputDeviceSDK
{
    public class SteamVRInputDeviceFunctionLibrary : BlueprintFunctionLibrary
    {
        public SteamVRInputDeviceFunctionLibrary(nint addr) : base(addr) { }
        public void ShowSteamVR_ActionOrigin(SteamVRAction SteamVRAction, SteamVRActionSet SteamVRActionSet) { Invoke(nameof(ShowSteamVR_ActionOrigin), SteamVRAction, SteamVRActionSet); }
        public void ShowAllSteamVR_ActionOrigins() { Invoke(nameof(ShowAllSteamVR_ActionOrigins)); }
        public float SetSteamVR_GlobalPredictedSecondsFromNow(float NewValue) { return Invoke<float>(nameof(SetSteamVR_GlobalPredictedSecondsFromNow), NewValue); }
        public void SetPoseSource(bool bUseSkeletonPose) { Invoke(nameof(SetPoseSource), bUseSkeletonPose); }
        public void SetCurlsAndSplaysState(bool NewLeftHandState, bool NewRightHandState) { Invoke(nameof(SetCurlsAndSplaysState), NewLeftHandState, NewRightHandState); }
        public bool ResetSeatedPosition() { return Invoke<bool>(nameof(ResetSeatedPosition)); }
        public void PlaySteamVR_HapticFeedback(ESteamVRHand hand, float StartSecondsFromNow, float DurationSeconds, float Frequency, float Amplitude) { Invoke(nameof(PlaySteamVR_HapticFeedback), hand, StartSecondsFromNow, DurationSeconds, Frequency, Amplitude); }
        public float GetUserIPD() { return Invoke<float>(nameof(GetUserIPD)); }
        public bool GetSteamVR_OriginTrackedDeviceInfo(SteamVRAction SteamVRAction, SteamVRInputOriginInfo InputOriginInfo) { return Invoke<bool>(nameof(GetSteamVR_OriginTrackedDeviceInfo), SteamVRAction, InputOriginInfo); }
        public void GetSteamVR_OriginLocalizedName(SteamVRAction SteamVRAction, Array<ESteamVRInputStringBits> LocalizedParts, Object OriginLocalizedName) { Invoke(nameof(GetSteamVR_OriginLocalizedName), SteamVRAction, LocalizedParts, OriginLocalizedName); }
        public Array<SteamVRInputBindingInfo> GetSteamVR_InputBindingInfo(SteamVRAction SteamVRActionHandle) { return Invoke<Array<SteamVRInputBindingInfo>>(nameof(GetSteamVR_InputBindingInfo), SteamVRActionHandle); }
        public bool GetSteamVR_HandPoseRelativeToNow(Vector Position, Rotator Orientation, ESteamVRHand hand, float PredictedSecondsFromNow) { return Invoke<bool>(nameof(GetSteamVR_HandPoseRelativeToNow), Position, Orientation, hand, PredictedSecondsFromNow); }
        public float GetSteamVR_GlobalPredictedSecondsFromNow() { return Invoke<float>(nameof(GetSteamVR_GlobalPredictedSecondsFromNow)); }
        public void GetSteamVR_ActionSetArray(Array<SteamVRActionSet> SteamVRActionSets) { Invoke(nameof(GetSteamVR_ActionSetArray), SteamVRActionSets); }
        public void GetSteamVR_ActionArray(Array<SteamVRAction> SteamVRActions) { Invoke(nameof(GetSteamVR_ActionArray), SteamVRActions); }
        public void GetSkeletalTransform(SteamVRSkeletonTransform LeftHand, SteamVRSkeletonTransform RightHand, bool bWithController) { Invoke(nameof(GetSkeletalTransform), LeftHand, RightHand, bWithController); }
        public void GetSkeletalState(bool LeftHandState, bool RightHandState) { Invoke(nameof(GetSkeletalState), LeftHandState, RightHandState); }
        public void GetRightHandPoseData(Vector Position, Rotator Orientation, Vector AngularVelocity, Vector Velocity) { Invoke(nameof(GetRightHandPoseData), Position, Orientation, AngularVelocity, Velocity); }
        public void GetPoseSource(bool bUsingSkeletonPose) { Invoke(nameof(GetPoseSource), bUsingSkeletonPose); }
        public void GetLeftHandPoseData(Vector Position, Rotator Orientation, Vector AngularVelocity, Vector Velocity) { Invoke(nameof(GetLeftHandPoseData), Position, Orientation, AngularVelocity, Velocity); }
        public void GetFingerCurlsAndSplays(EHand hand, SteamVRFingerCurls FingerCurls, SteamVRFingerSplays FingerSplays, ESkeletalSummaryDataType SummaryDataType) { Invoke(nameof(GetFingerCurlsAndSplays), hand, FingerCurls, FingerSplays, SummaryDataType); }
        public void GetCurlsAndSplaysState(bool LeftHandState, bool RightHandState) { Invoke(nameof(GetCurlsAndSplaysState), LeftHandState, RightHandState); }
        public void GetControllerFidelity(EControllerFidelity LeftControllerFidelity, EControllerFidelity RightControllerFidelity) { Invoke(nameof(GetControllerFidelity), LeftControllerFidelity, RightControllerFidelity); }
        public void FindSteamVR_OriginTrackedDeviceInfo(Object ActionName, bool bResult, SteamVRInputOriginInfo InputOriginInfo, Object ActionSet) { Invoke(nameof(FindSteamVR_OriginTrackedDeviceInfo), ActionName, bResult, InputOriginInfo, ActionSet); }
        public Array<SteamVRInputBindingInfo> FindSteamVR_InputBindingInfo(Object ActionName, Object ActionSet) { return Invoke<Array<SteamVRInputBindingInfo>>(nameof(FindSteamVR_InputBindingInfo), ActionName, ActionSet); }
        public bool FindSteamVR_ActionOrigin(Object ActionName, Object ActionSet) { return Invoke<bool>(nameof(FindSteamVR_ActionOrigin), ActionName, ActionSet); }
        public void FindSteamVR_Action(Object ActionName, bool bResult, SteamVRAction FoundAction, SteamVRActionSet FoundActionSet, Object ActionSet) { Invoke(nameof(FindSteamVR_Action), ActionName, bResult, FoundAction, FoundActionSet, ActionSet); }
    }
    public class SteamVRTrackingReferences : ActorComponent
    {
        public SteamVRTrackingReferences(nint addr) : base(addr) { }
        public Object OnTrackedDeviceActivated { get { return this[nameof(OnTrackedDeviceActivated)]; } set { this[nameof(OnTrackedDeviceActivated)] = value; } }
        public Object OnTrackedDeviceDeactivated { get { return this[nameof(OnTrackedDeviceDeactivated)]; } set { this[nameof(OnTrackedDeviceDeactivated)] = value; } }
        public float ActiveDevicePollFrequency { get { return this[nameof(ActiveDevicePollFrequency)].GetValue<float>(); } set { this[nameof(ActiveDevicePollFrequency)].SetValue<float>(value); } }
        public Vector TrackingReferenceScale { get { return this[nameof(TrackingReferenceScale)].As<Vector>(); } set { this["TrackingReferenceScale"] = value; } }
        public Array<StaticMeshComponent> TrackingReferences { get { return new Array<StaticMeshComponent>(this[nameof(TrackingReferences)].Address); } }
        public bool ShowTrackingReferences(StaticMesh TrackingReferenceMesh) { return Invoke<bool>(nameof(ShowTrackingReferences), TrackingReferenceMesh); }
        public void HideTrackingReferences() { Invoke(nameof(HideTrackingReferences)); }
    }
    public enum ESkeletalSummaryDataType : int
    {
        VR_SummaryType_FromAnimation = 0,
        VR_SummaryType_FromDevice = 1,
        VR_SummaryType_MAX = 2,
    }
    public enum ESteamVRInputStringBits : int
    {
        VR_InputString_Hand = 0,
        VR_InputString_ControllerType = 1,
        VR_InputString_InputSource = 2,
        VR_InputString_All = 3,
        VR_InputString_MAX = 4,
    }
    public enum EControllerFidelity : int
    {
        VR_ControllerFidelity_Estimated = 0,
        VR_ControllerFidelity_Full = 1,
        VR_ControllerFidelity_Partial = 2,
        VR_ControllerFidelity_MAX = 3,
    }
    public enum EHandSkeleton : int
    {
        VR_SteamVRHandSkeleton = 0,
        VR_UE4HandSkeleton = 1,
        VR_MAX = 2,
    }
    public enum EHand : int
    {
        VR_LeftHand = 0,
        VR_RightHand = 1,
        VR_MAX = 2,
    }
    public enum EMotionRange : int
    {
        VR_WithoutController = 0,
        VR_WithController = 1,
        VR_MAX = 2,
    }
    public enum ESteamVRHand : int
    {
        VR_Left = 0,
        VR_Right = 1,
        VR_MAX = 2,
    }
    public class AnimNode_SteamVRInputAnimPose : AnimNode_Base
    {
        public AnimNode_SteamVRInputAnimPose(nint addr) : base(addr) { }
        public EMotionRange MotionRange { get { return (EMotionRange)this[nameof(MotionRange)].GetValue<int>(); } set { this[nameof(MotionRange)].SetValue<int>((int)value); } }
        public EHand hand { get { return (EHand)this[nameof(hand)].GetValue<int>(); } set { this[nameof(hand)].SetValue<int>((int)value); } }
        public EHandSkeleton HandSkeleton { get { return (EHandSkeleton)this[nameof(HandSkeleton)].GetValue<int>(); } set { this[nameof(HandSkeleton)].SetValue<int>((int)value); } }
        public bool Mirror { get { return this[nameof(Mirror)].Flag; } set { this[nameof(Mirror)].Flag = value; } }
        public SteamVRSkeletonTransform SteamVRSkeletalTransform { get { return this[nameof(SteamVRSkeletalTransform)].As<SteamVRSkeletonTransform>(); } set { this["SteamVRSkeletalTransform"] = value; } }
        public UE4RetargettingRefs UE4RetargettingRefs { get { return this[nameof(UE4RetargettingRefs)].As<UE4RetargettingRefs>(); } set { this["UE4RetargettingRefs"] = value; } }
    }
    public class UE4RetargettingRefs : Object
    {
        public UE4RetargettingRefs(nint addr) : base(addr) { }
        public bool bIsInitialized { get { return this[nameof(bIsInitialized)].Flag; } set { this[nameof(bIsInitialized)].Flag = value; } }
        public bool bIsRightHanded { get { return this[nameof(bIsRightHanded)].Flag; } set { this[nameof(bIsRightHanded)].Flag = value; } }
        public Vector KnuckleAverageMS_UE4 { get { return this[nameof(KnuckleAverageMS_UE4)].As<Vector>(); } set { this["KnuckleAverageMS_UE4"] = value; } }
        public Vector WristSideDirectionLS_UE4 { get { return this[nameof(WristSideDirectionLS_UE4)].As<Vector>(); } set { this["WristSideDirectionLS_UE4"] = value; } }
        public Vector WristForwardLS_UE4 { get { return this[nameof(WristForwardLS_UE4)].As<Vector>(); } set { this["WristForwardLS_UE4"] = value; } }
    }
    public class SteamVRSkeletonTransform : Object
    {
        public SteamVRSkeletonTransform(nint addr) : base(addr) { }
        public Transform Root { get { return this[nameof(Root)].As<Transform>(); } set { this["Root"] = value; } }
        public Transform wrist { get { return this[nameof(wrist)].As<Transform>(); } set { this["wrist"] = value; } }
        public Transform Thumb { get { return this[nameof(Thumb)].As<Transform>(); } set { this["Thumb"] = value; } }
        public Transform Index { get { return this[nameof(Index)].As<Transform>(); } set { this["Index"] = value; } }
        public Transform Middle { get { return this[nameof(Middle)].As<Transform>(); } set { this["Middle"] = value; } }
        public Transform Ring { get { return this[nameof(Ring)].As<Transform>(); } set { this["Ring"] = value; } }
        public Transform Pinky { get { return this[nameof(Pinky)].As<Transform>(); } set { this["Pinky"] = value; } }
        public Transform Aux_Thumb { get { return this[nameof(Aux_Thumb)].As<Transform>(); } set { this["Aux_Thumb"] = value; } }
        public Transform Aux_Index { get { return this[nameof(Aux_Index)].As<Transform>(); } set { this["Aux_Index"] = value; } }
        public Transform Aux_Middle { get { return this[nameof(Aux_Middle)].As<Transform>(); } set { this["Aux_Middle"] = value; } }
        public Transform Aux_Ring { get { return this[nameof(Aux_Ring)].As<Transform>(); } set { this["Aux_Ring"] = value; } }
        public Transform Aux_Pinky { get { return this[nameof(Aux_Pinky)].As<Transform>(); } set { this["Aux_Pinky"] = value; } }
    }
    public class AnimNode_SteamVRSetWristTransform : AnimNode_Base
    {
        public AnimNode_SteamVRSetWristTransform(nint addr) : base(addr) { }
        public PoseLink ReferencePose { get { return this[nameof(ReferencePose)].As<PoseLink>(); } set { this["ReferencePose"] = value; } }
        public EHandSkeleton HandSkeleton { get { return (EHandSkeleton)this[nameof(HandSkeleton)].GetValue<int>(); } set { this[nameof(HandSkeleton)].SetValue<int>((int)value); } }
        public PoseLink targetPose { get { return this[nameof(targetPose)].As<PoseLink>(); } set { this["targetPose"] = value; } }
    }
    public class SteamVRInputBindingInfo : Object
    {
        public SteamVRInputBindingInfo(nint addr) : base(addr) { }
        public Object DevicePathName { get { return this[nameof(DevicePathName)]; } set { this[nameof(DevicePathName)] = value; } }
        public Object InputPathName { get { return this[nameof(InputPathName)]; } set { this[nameof(InputPathName)] = value; } }
        public Object ModeName { get { return this[nameof(ModeName)]; } set { this[nameof(ModeName)] = value; } }
        public Object slotName { get { return this[nameof(slotName)]; } set { this[nameof(slotName)] = value; } }
    }
    public class SteamVRInputOriginInfo : Object
    {
        public SteamVRInputOriginInfo(nint addr) : base(addr) { }
        public int TrackedDeviceIndex { get { return this[nameof(TrackedDeviceIndex)].GetValue<int>(); } set { this[nameof(TrackedDeviceIndex)].SetValue<int>(value); } }
        public Object RenderModelComponentName { get { return this[nameof(RenderModelComponentName)]; } set { this[nameof(RenderModelComponentName)] = value; } }
        public Object TrackedDeviceModel { get { return this[nameof(TrackedDeviceModel)]; } set { this[nameof(TrackedDeviceModel)] = value; } }
    }
    public class SteamVRActionSet : Object
    {
        public SteamVRActionSet(nint addr) : base(addr) { }
        public Object Path { get { return this[nameof(Path)]; } set { this[nameof(Path)] = value; } }
    }
    public class SteamVRAction : Object
    {
        public SteamVRAction(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Path { get { return this[nameof(Path)]; } set { this[nameof(Path)] = value; } }
    }
    public class SteamVRFingerSplays : Object
    {
        public SteamVRFingerSplays(nint addr) : base(addr) { }
        public float Thumb_Index { get { return this[nameof(Thumb_Index)].GetValue<float>(); } set { this[nameof(Thumb_Index)].SetValue<float>(value); } }
        public float Index_Middle { get { return this[nameof(Index_Middle)].GetValue<float>(); } set { this[nameof(Index_Middle)].SetValue<float>(value); } }
        public float Middle_Ring { get { return this[nameof(Middle_Ring)].GetValue<float>(); } set { this[nameof(Middle_Ring)].SetValue<float>(value); } }
        public float Ring_Pinky { get { return this[nameof(Ring_Pinky)].GetValue<float>(); } set { this[nameof(Ring_Pinky)].SetValue<float>(value); } }
    }
    public class SteamVRFingerCurls : Object
    {
        public SteamVRFingerCurls(nint addr) : base(addr) { }
        public float Thumb { get { return this[nameof(Thumb)].GetValue<float>(); } set { this[nameof(Thumb)].SetValue<float>(value); } }
        public float Index { get { return this[nameof(Index)].GetValue<float>(); } set { this[nameof(Index)].SetValue<float>(value); } }
        public float Middle { get { return this[nameof(Middle)].GetValue<float>(); } set { this[nameof(Middle)].SetValue<float>(value); } }
        public float Ring { get { return this[nameof(Ring)].GetValue<float>(); } set { this[nameof(Ring)].SetValue<float>(value); } }
        public float Pinky { get { return this[nameof(Pinky)].GetValue<float>(); } set { this[nameof(Pinky)].SetValue<float>(value); } }
    }
}
