using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.OculusInputSDK
{
    public class OculusHandComponent : PoseableMeshComponent
    {
        public OculusHandComponent(nint addr) : base(addr) { }
        public EOculusHandType SkeletonType { get { return (EOculusHandType)this[nameof(SkeletonType)].GetValue<int>(); } set { this[nameof(SkeletonType)].SetValue<int>((int)value); } }
        public EOculusHandType MeshType { get { return (EOculusHandType)this[nameof(MeshType)].GetValue<int>(); } set { this[nameof(MeshType)].SetValue<int>((int)value); } }
        public EConfidenceBehavior ConfidenceBehavior { get { return (EConfidenceBehavior)this[nameof(ConfidenceBehavior)].GetValue<int>(); } set { this[nameof(ConfidenceBehavior)].SetValue<int>((int)value); } }
        public ESystemGestureBehavior SystemGestureBehavior { get { return (ESystemGestureBehavior)this[nameof(SystemGestureBehavior)].GetValue<int>(); } set { this[nameof(SystemGestureBehavior)].SetValue<int>((int)value); } }
        public MaterialInterface SystemGestureMaterial { get { return this[nameof(SystemGestureMaterial)].As<MaterialInterface>(); } set { this["SystemGestureMaterial"] = value; } }
        public bool bInitializePhysics { get { return this[nameof(bInitializePhysics)].Flag; } set { this[nameof(bInitializePhysics)].Flag = value; } }
        public bool bUpdateHandScale { get { return this[nameof(bUpdateHandScale)].Flag; } set { this[nameof(bUpdateHandScale)].Flag = value; } }
        public MaterialInterface MaterialOverride { get { return this[nameof(MaterialOverride)].As<MaterialInterface>(); } set { this["MaterialOverride"] = value; } }
        public Object BoneNameMappings { get { return this[nameof(BoneNameMappings)]; } set { this[nameof(BoneNameMappings)] = value; } }
        public UArray<OculusCapsuleCollider> CollisionCapsules { get { return new UArray<OculusCapsuleCollider>(this[nameof(CollisionCapsules)].Address); } }
        public bool bSkeletalMeshInitialized { get { return this[nameof(bSkeletalMeshInitialized)].Flag; } set { this[nameof(bSkeletalMeshInitialized)].Flag = value; } }
    }
    public class OculusInputFunctionLibrary : BlueprintFunctionLibrary
    {
        public OculusInputFunctionLibrary(nint addr) : base(addr) { }
        public bool IsPointerPoseValid(EOculusHandType DeviceHand, int ControllerIndex) { return Invoke<bool>(nameof(IsPointerPoseValid), DeviceHand, ControllerIndex); }
        public bool IsHandTrackingEnabled() { return Invoke<bool>(nameof(IsHandTrackingEnabled)); }
        public UArray<OculusCapsuleCollider> InitializeHandPhysics(EOculusHandType SkeletonType, SkinnedMeshComponent HandComponent, float WorldToMeters) { return Invoke<UArray<OculusCapsuleCollider>>(nameof(InitializeHandPhysics), SkeletonType, HandComponent, WorldToMeters); }
        public ETrackingConfidence GetTrackingConfidence(EOculusHandType DeviceHand, int ControllerIndex) { return Invoke<ETrackingConfidence>(nameof(GetTrackingConfidence), DeviceHand, ControllerIndex); }
        public Transform GetPointerPose(EOculusHandType DeviceHand, int ControllerIndex) { return Invoke<Transform>(nameof(GetPointerPose), DeviceHand, ControllerIndex); }
        public bool GetHandSkeletalMesh(SkeletalMesh HandSkeletalMesh, EOculusHandType SkeletonType, EOculusHandType MeshType, float WorldToMeters) { return Invoke<bool>(nameof(GetHandSkeletalMesh), HandSkeletalMesh, SkeletonType, MeshType, WorldToMeters); }
        public float GetHandScale(EOculusHandType DeviceHand, int ControllerIndex) { return Invoke<float>(nameof(GetHandScale), DeviceHand, ControllerIndex); }
        public EOculusHandType GetDominantHand(int ControllerIndex) { return Invoke<EOculusHandType>(nameof(GetDominantHand), ControllerIndex); }
        public Quat GetBoneRotation(EOculusHandType DeviceHand, EBone BoneId, int ControllerIndex) { return Invoke<Quat>(nameof(GetBoneRotation), DeviceHand, BoneId, ControllerIndex); }
        public Object GetBoneName(EBone BoneId) { return Invoke<Object>(nameof(GetBoneName), BoneId); }
    }
    public enum ESystemGestureBehavior : int
    {
        None = 0,
        SwapMaterial = 1,
        ESystemGestureBehavior_MAX = 2,
    }
    public enum EConfidenceBehavior : int
    {
        None = 0,
        HideActor = 1,
        EConfidenceBehavior_MAX = 2,
    }
    public enum EBone : int
    {
        Wrist_Root = 0,
        Hand_Start = 0,
        Forearm_Stub = 1,
        Thumb_1 = 2,
        Thumb_2 = 3,
        Thumb_3 = 4,
        Thumb_4 = 5,
        Index_2 = 6,
        Index_3 = 7,
        Index_4 = 8,
        Middle_2 = 9,
        Middle_3 = 10,
        Middle_4 = 11,
        Ring_2 = 12,
        Ring_3 = 13,
        Ring_4 = 14,
        Pinky_1 = 15,
        Pinky_2 = 16,
        Pinky_3 = 17,
        Pinky_4 = 18,
        Thumb_Tip = 19,
        Max_Skinnable = 19,
        Index_Tip = 20,
        Middle_Tip = 21,
        Ring_Tip = 22,
        Pinky_Tip = 23,
        Hand_End = 24,
        Bone_Max = 24,
        Invalid = 25,
        EBone_MAX = 26,
    }
    public enum ETrackingConfidence : int
    {
        Low = 0,
        High = 1,
        ETrackingConfidence_MAX = 2,
    }
    public enum EOculusHandType : int
    {
        None = 0,
        HandLeft = 1,
        HandRight = 2,
        EOculusHandType_MAX = 3,
    }
    public class OculusCapsuleCollider : Object
    {
        public OculusCapsuleCollider(nint addr) : base(addr) { }
        public CapsuleComponent Capsule { get { return this[nameof(Capsule)].As<CapsuleComponent>(); } set { this["Capsule"] = value; } }
        public EBone BoneId { get { return (EBone)this[nameof(BoneId)].GetValue<int>(); } set { this[nameof(BoneId)].SetValue<int>((int)value); } }
    }
}
