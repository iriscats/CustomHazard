using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.ClothingSystemRuntimeInterfaceSDK;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.ClothingSystemRuntimeCommonSDK
{
    public class ClothConfigCommon : ClothConfigBase
    {
        public ClothConfigCommon(nint addr) : base(addr) { }
    }
    public class ClothSharedConfigCommon : ClothConfigCommon
    {
        public ClothSharedConfigCommon(nint addr) : base(addr) { }
    }
    public class ClothingAssetCustomData : Object
    {
        public ClothingAssetCustomData(nint addr) : base(addr) { }
    }
    public class ClothingAssetCommon : ClothingAssetBase
    {
        public ClothingAssetCommon(nint addr) : base(addr) { }
        public PhysicsAsset PhysicsAsset { get { return this[nameof(PhysicsAsset)].As<PhysicsAsset>(); } set { this["PhysicsAsset"] = value; } }
        public Object ClothConfigs { get { return this[nameof(ClothConfigs)]; } set { this[nameof(ClothConfigs)] = value; } }
        public UArray<ClothLODDataCommon> LODData { get { return new UArray<ClothLODDataCommon>(this[nameof(LODData)].Address); } }
        public UArray<int> LodMap { get { return new UArray<int>(this[nameof(LodMap)].Address); } }
        public UArray<Object> UsedBoneNames { get { return new UArray<Object>(this[nameof(UsedBoneNames)].Address); } }
        public UArray<int> UsedBoneIndices { get { return new UArray<int>(this[nameof(UsedBoneIndices)].Address); } }
        public int ReferenceBoneIndex { get { return this[nameof(ReferenceBoneIndex)].GetValue<int>(); } set { this[nameof(ReferenceBoneIndex)].SetValue<int>(value); } }
        public ClothingAssetCustomData CustomData { get { return this[nameof(CustomData)].As<ClothingAssetCustomData>(); } set { this["CustomData"] = value; } }
    }
    public class ClothLODDataCommon_Legacy : Object
    {
        public ClothLODDataCommon_Legacy(nint addr) : base(addr) { }
        public ClothPhysicalMeshDataBase_Legacy PhysicalMeshData { get { return this[nameof(PhysicalMeshData)].As<ClothPhysicalMeshDataBase_Legacy>(); } set { this["PhysicalMeshData"] = value; } }
        public ClothPhysicalMeshData ClothPhysicalMeshData { get { return this[nameof(ClothPhysicalMeshData)].As<ClothPhysicalMeshData>(); } set { this["ClothPhysicalMeshData"] = value; } }
        public ClothCollisionData CollisionData { get { return this[nameof(CollisionData)].As<ClothCollisionData>(); } set { this["CollisionData"] = value; } }
    }
    public enum EClothMassMode : int
    {
        UniformMass = 0,
        TotalMass = 1,
        Density = 2,
        MaxClothMassMode = 3,
        EClothMassMode_MAX = 4,
    }
    public enum EClothingWindMethod_Legacy : int
    {
        Legacy = 0,
        Accurate = 1,
        EClothingWindMethod_MAX = 2,
    }
    public enum EWeightMapTargetCommon : int
    {
        None = 0,
        MaxDistance = 1,
        BackstopDistance = 2,
        BackstopRadius = 3,
        AnimDriveStiffness = 4,
        AnimDriveDamping = 5,
        EWeightMapTargetCommon_MAX = 6,
    }
    public class ClothConfig_Legacy : Object
    {
        public ClothConfig_Legacy(nint addr) : base(addr) { }
        public EClothingWindMethod_Legacy WindMethod { get { return (EClothingWindMethod_Legacy)this[nameof(WindMethod)].GetValue<int>(); } set { this[nameof(WindMethod)].SetValue<int>((int)value); } }
        public ClothConstraintSetup_Legacy VerticalConstraintConfig { get { return this[nameof(VerticalConstraintConfig)].As<ClothConstraintSetup_Legacy>(); } set { this["VerticalConstraintConfig"] = value; } }
        public ClothConstraintSetup_Legacy HorizontalConstraintConfig { get { return this[nameof(HorizontalConstraintConfig)].As<ClothConstraintSetup_Legacy>(); } set { this["HorizontalConstraintConfig"] = value; } }
        public ClothConstraintSetup_Legacy BendConstraintConfig { get { return this[nameof(BendConstraintConfig)].As<ClothConstraintSetup_Legacy>(); } set { this["BendConstraintConfig"] = value; } }
        public ClothConstraintSetup_Legacy ShearConstraintConfig { get { return this[nameof(ShearConstraintConfig)].As<ClothConstraintSetup_Legacy>(); } set { this["ShearConstraintConfig"] = value; } }
        public float SelfCollisionRadius { get { return this[nameof(SelfCollisionRadius)].GetValue<float>(); } set { this[nameof(SelfCollisionRadius)].SetValue<float>(value); } }
        public float SelfCollisionStiffness { get { return this[nameof(SelfCollisionStiffness)].GetValue<float>(); } set { this[nameof(SelfCollisionStiffness)].SetValue<float>(value); } }
        public float SelfCollisionCullScale { get { return this[nameof(SelfCollisionCullScale)].GetValue<float>(); } set { this[nameof(SelfCollisionCullScale)].SetValue<float>(value); } }
        public Vector Damping { get { return this[nameof(Damping)].As<Vector>(); } set { this["Damping"] = value; } }
        public float Friction { get { return this[nameof(Friction)].GetValue<float>(); } set { this[nameof(Friction)].SetValue<float>(value); } }
        public float WindDragCoefficient { get { return this[nameof(WindDragCoefficient)].GetValue<float>(); } set { this[nameof(WindDragCoefficient)].SetValue<float>(value); } }
        public float WindLiftCoefficient { get { return this[nameof(WindLiftCoefficient)].GetValue<float>(); } set { this[nameof(WindLiftCoefficient)].SetValue<float>(value); } }
        public Vector LinearDrag { get { return this[nameof(LinearDrag)].As<Vector>(); } set { this["LinearDrag"] = value; } }
        public Vector AngularDrag { get { return this[nameof(AngularDrag)].As<Vector>(); } set { this["AngularDrag"] = value; } }
        public Vector LinearInertiaScale { get { return this[nameof(LinearInertiaScale)].As<Vector>(); } set { this["LinearInertiaScale"] = value; } }
        public Vector AngularInertiaScale { get { return this[nameof(AngularInertiaScale)].As<Vector>(); } set { this["AngularInertiaScale"] = value; } }
        public Vector CentrifugalInertiaScale { get { return this[nameof(CentrifugalInertiaScale)].As<Vector>(); } set { this["CentrifugalInertiaScale"] = value; } }
        public float SolverFrequency { get { return this[nameof(SolverFrequency)].GetValue<float>(); } set { this[nameof(SolverFrequency)].SetValue<float>(value); } }
        public float StiffnessFrequency { get { return this[nameof(StiffnessFrequency)].GetValue<float>(); } set { this[nameof(StiffnessFrequency)].SetValue<float>(value); } }
        public float GravityScale { get { return this[nameof(GravityScale)].GetValue<float>(); } set { this[nameof(GravityScale)].SetValue<float>(value); } }
        public Vector GravityOverride { get { return this[nameof(GravityOverride)].As<Vector>(); } set { this["GravityOverride"] = value; } }
        public bool bUseGravityOverride { get { return this[nameof(bUseGravityOverride)].Flag; } set { this[nameof(bUseGravityOverride)].Flag = value; } }
        public float TetherStiffness { get { return this[nameof(TetherStiffness)].GetValue<float>(); } set { this[nameof(TetherStiffness)].SetValue<float>(value); } }
        public float TetherLimit { get { return this[nameof(TetherLimit)].GetValue<float>(); } set { this[nameof(TetherLimit)].SetValue<float>(value); } }
        public float CollisionThickness { get { return this[nameof(CollisionThickness)].GetValue<float>(); } set { this[nameof(CollisionThickness)].SetValue<float>(value); } }
        public float AnimDriveSpringStiffness { get { return this[nameof(AnimDriveSpringStiffness)].GetValue<float>(); } set { this[nameof(AnimDriveSpringStiffness)].SetValue<float>(value); } }
        public float AnimDriveDamperStiffness { get { return this[nameof(AnimDriveDamperStiffness)].GetValue<float>(); } set { this[nameof(AnimDriveDamperStiffness)].SetValue<float>(value); } }
    }
    public class ClothConstraintSetup_Legacy : Object
    {
        public ClothConstraintSetup_Legacy(nint addr) : base(addr) { }
        public float Stiffness { get { return this[nameof(Stiffness)].GetValue<float>(); } set { this[nameof(Stiffness)].SetValue<float>(value); } }
        public float StiffnessMultiplier { get { return this[nameof(StiffnessMultiplier)].GetValue<float>(); } set { this[nameof(StiffnessMultiplier)].SetValue<float>(value); } }
        public float StretchLimit { get { return this[nameof(StretchLimit)].GetValue<float>(); } set { this[nameof(StretchLimit)].SetValue<float>(value); } }
        public float CompressionLimit { get { return this[nameof(CompressionLimit)].GetValue<float>(); } set { this[nameof(CompressionLimit)].SetValue<float>(value); } }
    }
    public class ClothLODDataCommon : Object
    {
        public ClothLODDataCommon(nint addr) : base(addr) { }
        public ClothPhysicalMeshData PhysicalMeshData { get { return this[nameof(PhysicalMeshData)].As<ClothPhysicalMeshData>(); } set { this["PhysicalMeshData"] = value; } }
        public ClothCollisionData CollisionData { get { return this[nameof(CollisionData)].As<ClothCollisionData>(); } set { this["CollisionData"] = value; } }
        public bool bUseMultipleInfluences { get { return this[nameof(bUseMultipleInfluences)].Flag; } set { this[nameof(bUseMultipleInfluences)].Flag = value; } }
        public float SkinningKernelRadius { get { return this[nameof(SkinningKernelRadius)].GetValue<float>(); } set { this[nameof(SkinningKernelRadius)].SetValue<float>(value); } }
    }
    public class ClothPhysicalMeshData : Object
    {
        public ClothPhysicalMeshData(nint addr) : base(addr) { }
        public UArray<Vector> Vertices { get { return new UArray<Vector>(this[nameof(Vertices)].Address); } }
        public UArray<Vector> Normals { get { return new UArray<Vector>(this[nameof(Normals)].Address); } }
        public UArray<uint> Indices { get { return new UArray<uint>(this[nameof(Indices)].Address); } }
        public Object WeightMaps { get { return this[nameof(WeightMaps)]; } set { this[nameof(WeightMaps)] = value; } }
        public UArray<float> InverseMasses { get { return new UArray<float>(this[nameof(InverseMasses)].Address); } }
        public UArray<ClothVertBoneData> BoneData { get { return new UArray<ClothVertBoneData>(this[nameof(BoneData)].Address); } }
        public int MaxBoneWeights { get { return this[nameof(MaxBoneWeights)].GetValue<int>(); } set { this[nameof(MaxBoneWeights)].SetValue<int>(value); } }
        public int NumFixedVerts { get { return this[nameof(NumFixedVerts)].GetValue<int>(); } set { this[nameof(NumFixedVerts)].SetValue<int>(value); } }
        public UArray<uint> SelfCollisionIndices { get { return new UArray<uint>(this[nameof(SelfCollisionIndices)].Address); } }
        public UArray<float> MaxDistances { get { return new UArray<float>(this[nameof(MaxDistances)].Address); } }
        public UArray<float> BackstopDistances { get { return new UArray<float>(this[nameof(BackstopDistances)].Address); } }
        public UArray<float> BackstopRadiuses { get { return new UArray<float>(this[nameof(BackstopRadiuses)].Address); } }
        public UArray<float> AnimDriveMultipliers { get { return new UArray<float>(this[nameof(AnimDriveMultipliers)].Address); } }
    }
    public class PointWeightMap : Object
    {
        public PointWeightMap(nint addr) : base(addr) { }
        public UArray<float> Values { get { return new UArray<float>(this[nameof(Values)].Address); } }
    }
    public class ClothParameterMask_Legacy : Object
    {
        public ClothParameterMask_Legacy(nint addr) : base(addr) { }
        public Object MaskName { get { return this[nameof(MaskName)]; } set { this[nameof(MaskName)] = value; } }
        public EWeightMapTargetCommon CurrentTarget { get { return (EWeightMapTargetCommon)this[nameof(CurrentTarget)].GetValue<int>(); } set { this[nameof(CurrentTarget)].SetValue<int>((int)value); } }
        public float MaxValue { get { return this[nameof(MaxValue)].GetValue<float>(); } set { this[nameof(MaxValue)].SetValue<float>(value); } }
        public float MinValue { get { return this[nameof(MinValue)].GetValue<float>(); } set { this[nameof(MinValue)].SetValue<float>(value); } }
        public UArray<float> Values { get { return new UArray<float>(this[nameof(Values)].Address); } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
}
