using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
using SDK.Script.PhysicsCoreSDK;
namespace SDK.Script.FSDEngineSDK
{
    public class TerrainMaterialBase : PrimaryDataAsset
    {
        public TerrainMaterialBase(nint addr) : base(addr) { }
    }
    public class TerrainMaterialCore : TerrainMaterialBase
    {
        public TerrainMaterialCore(nint addr) : base(addr) { }
        public TerrainMaterialCore BurntMaterial { get { return this[nameof(BurntMaterial)].As<TerrainMaterialCore>(); } set { this["BurntMaterial"] = value; } }
        public TerrainMaterialCore BulletBurntMaterial { get { return this[nameof(BulletBurntMaterial)].As<TerrainMaterialCore>(); } set { this["BulletBurntMaterial"] = value; } }
        public bool PathfinderDanger { get { return this[nameof(PathfinderDanger)].Flag; } set { this[nameof(PathfinderDanger)].Flag = value; } }
        public bool PathfinderPreventSpawning { get { return this[nameof(PathfinderPreventSpawning)].Flag; } set { this[nameof(PathfinderPreventSpawning)].Flag = value; } }
        public MaterialInterface ScannerMaterial { get { return this[nameof(ScannerMaterial)].As<MaterialInterface>(); } set { this["ScannerMaterial"] = value; } }
        public Object RenderMaterial { get { return this[nameof(RenderMaterial)]; } set { this[nameof(RenderMaterial)] = value; } }
    }
    public class CSGBake : DataAsset
    {
        public CSGBake(nint addr) : base(addr) { }
        public BakeSettings BakeSettings { get { return this[nameof(BakeSettings)].As<BakeSettings>(); } set { this["BakeSettings"] = value; } }
        public int NumVariations { get { return this[nameof(NumVariations)].GetValue<int>(); } set { this[nameof(NumVariations)].SetValue<int>(value); } }
        public int InitialSeed { get { return this[nameof(InitialSeed)].GetValue<int>(); } set { this[nameof(InitialSeed)].SetValue<int>(value); } }
        public Object CSG { get { return this[nameof(CSG)]; } set { this[nameof(CSG)] = value; } }
        public Object Status { get { return this[nameof(Status)]; } set { this[nameof(Status)] = value; } }
        public Box CombinedAABB { get { return this[nameof(CombinedAABB)].As<Box>(); } set { this["CombinedAABB"] = value; } }
        public Array<BakeEntry> Entries { get { return new Array<BakeEntry>(this[nameof(Entries)].Address); } }
        public bool IsBaking { get { return this[nameof(IsBaking)].Flag; } set { this[nameof(IsBaking)].Flag = value; } }
        public Array<BakeConfig> CurrentBakeConfigs { get { return new Array<BakeConfig>(this[nameof(CurrentBakeConfigs)].Address); } }
        public CSGBuilder CDO { get { return this[nameof(CDO)].As<CSGBuilder>(); } set { this["CDO"] = value; } }
        public void BakeCSG() { Invoke(nameof(BakeCSG)); }
    }
    public class BuilderBase : Object
    {
        public BuilderBase(nint addr) : base(addr) { }
    }
    public class CSGBase : BuilderBase
    {
        public CSGBase(nint addr) : base(addr) { }
        public MeshBaseProperties BaseProperties { get { return this[nameof(BaseProperties)].As<MeshBaseProperties>(); } set { this["BaseProperties"] = value; } }
        public Transform RelativeTransform { get { return this[nameof(RelativeTransform)].As<Transform>(); } set { this["RelativeTransform"] = value; } }
    }
    public class CSGBakedChildInstance : CSGBase
    {
        public CSGBakedChildInstance(nint addr) : base(addr) { }
        public CSGBakedChildInstanceProperties Properties { get { return this[nameof(Properties)].As<CSGBakedChildInstanceProperties>(); } set { this["Properties"] = value; } }
        public Box ChildLocalSpaceBoundingBox { get { return this[nameof(ChildLocalSpaceBoundingBox)].As<Box>(); } set { this["ChildLocalSpaceBoundingBox"] = value; } }
        public Box WorldSpaceBoundingBox { get { return this[nameof(WorldSpaceBoundingBox)].As<Box>(); } set { this["WorldSpaceBoundingBox"] = value; } }
        public Matrix TransformMatInv { get { return this[nameof(TransformMatInv)].As<Matrix>(); } set { this["TransformMatInv"] = value; } }
        public DeepCSGFloatTree TempTree { get { return this[nameof(TempTree)].As<DeepCSGFloatTree>(); } set { this["TempTree"] = value; } }
    }
    public class CSGBuilderBaseSceneComponent : SceneComponent
    {
        public CSGBuilderBaseSceneComponent(nint addr) : base(addr) { }
    }
    public class CSGBaseComponent : CSGBuilderBaseSceneComponent
    {
        public CSGBaseComponent(nint addr) : base(addr) { }
        public MeshBaseProperties BaseProperties { get { return this[nameof(BaseProperties)].As<MeshBaseProperties>(); } set { this["BaseProperties"] = value; } }
    }
    public class CSGBakedChildInstanceComponent : CSGBaseComponent
    {
        public CSGBakedChildInstanceComponent(nint addr) : base(addr) { }
        public CSGBakedChildInstanceProperties Properties { get { return this[nameof(Properties)].As<CSGBakedChildInstanceProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGSingleChildBase : CSGBase
    {
        public CSGSingleChildBase(nint addr) : base(addr) { }
        public CSGBase Child { get { return this[nameof(Child)].As<CSGBase>(); } set { this["Child"] = value; } }
    }
    public class CSGDuplicateSingleChildBase : CSGBase
    {
        public CSGDuplicateSingleChildBase(nint addr) : base(addr) { }
        public Array<CSGBase> Children { get { return new Array<CSGBase>(this[nameof(Children)].Address); } }
    }
    public class CSGBuilderBase : Actor
    {
        public CSGBuilderBase(nint addr) : base(addr) { }
        public Box BoundingBox { get { return this[nameof(BoundingBox)].As<Box>(); } set { this["BoundingBox"] = value; } }
        public int PreviewSeed { get { return this[nameof(PreviewSeed)].GetValue<int>(); } set { this[nameof(PreviewSeed)].SetValue<int>(value); } }
        public BakeSettings PreviewSettings { get { return this[nameof(PreviewSettings)].As<BakeSettings>(); } set { this["PreviewSettings"] = value; } }
        public TerrainMaterialCore EmptyMat { get { return this[nameof(EmptyMat)].As<TerrainMaterialCore>(); } set { this["EmptyMat"] = value; } }
        public TerrainMaterialCore ErrorMat { get { return this[nameof(ErrorMat)].As<TerrainMaterialCore>(); } set { this["ErrorMat"] = value; } }
        public TerrainMaterialCore SolidMat { get { return this[nameof(SolidMat)].As<TerrainMaterialCore>(); } set { this["SolidMat"] = value; } }
        public TerrainMaterialCore BurnedMat { get { return this[nameof(BurnedMat)].As<TerrainMaterialCore>(); } set { this["BurnedMat"] = value; } }
        public CSGPreviewComponent PreviewComponent { get { return this[nameof(PreviewComponent)].As<CSGPreviewComponent>(); } set { this["PreviewComponent"] = value; } }
        public void PreGenerate(BakeConfig builder) { Invoke(nameof(PreGenerate), builder); }
    }
    public class CSGBuilder : CSGBuilderBase
    {
        public CSGBuilder(nint addr) : base(addr) { }
        public CSGGroupComponent CSGRoot { get { return this[nameof(CSGRoot)].As<CSGGroupComponent>(); } set { this["CSGRoot"] = value; } }
        public Array<TerrainMaterialCore> UsedMaterials { get { return new Array<TerrainMaterialCore>(this[nameof(UsedMaterials)].Address); } }
        public CSGBase CurrentPreviewRoot { get { return this[nameof(CurrentPreviewRoot)].As<CSGBase>(); } set { this["CurrentPreviewRoot"] = value; } }
        public BakeConfig CurrentPreviewConfig { get { return this[nameof(CurrentPreviewConfig)].As<BakeConfig>(); } set { this["CurrentPreviewConfig"] = value; } }
        public CSGPreviewScene PreviewScene { get { return this[nameof(PreviewScene)].As<CSGPreviewScene>(); } set { this["PreviewScene"] = value; } }
    }
    public class BakeConfig : Object
    {
        public BakeConfig(nint addr) : base(addr) { }
        public BakeSettings Settings { get { return this[nameof(Settings)].As<BakeSettings>(); } set { this["Settings"] = value; } }
        public Object Objects { get { return this[nameof(Objects)]; } set { this[nameof(Objects)] = value; } }
        public Array<Object> Warnings { get { return new Array<Object>(this[nameof(Warnings)].Address); } }
        public Vector GetVectorSetting(Object Name, Vector defaultVal) { return Invoke<Vector>(nameof(GetVectorSetting), Name, defaultVal); }
        public RandomStream GetRandomStream() { return Invoke<RandomStream>(nameof(GetRandomStream)); }
        public BuilderBase GetObject(Object Name) { return Invoke<BuilderBase>(nameof(GetObject), Name); }
        public int GetIntSetting(Object Name, int defaultVal) { return Invoke<int>(nameof(GetIntSetting), Name, defaultVal); }
        public float GetFloatSetting(Object Name, float defaultVal) { return Invoke<float>(nameof(GetFloatSetting), Name, defaultVal); }
        public bool GetBoolSetting(Object Name, bool defaultVal) { return Invoke<bool>(nameof(GetBoolSetting), Name, defaultVal); }
    }
    public class CSGCellNoise : CSGBase
    {
        public CSGCellNoise(nint addr) : base(addr) { }
        public MeshCellNoiseProperties Properties { get { return this[nameof(Properties)].As<MeshCellNoiseProperties>(); } set { this["Properties"] = value; } }
        public BinaryTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<BinaryTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
        public Vector ReciprocalCellSize { get { return this[nameof(ReciprocalCellSize)].As<Vector>(); } set { this["ReciprocalCellSize"] = value; } }
        public DeepCSGFloatTree ApplyTree { get { return this[nameof(ApplyTree)].As<DeepCSGFloatTree>(); } set { this["ApplyTree"] = value; } }
        public Array<Vector> CellPositions { get { return new Array<Vector>(this[nameof(CellPositions)].Address); } }
        public Array<DeepCSGNode> CellLeaves { get { return new Array<DeepCSGNode>(this[nameof(CellLeaves)].Address); } }
    }
    public class CSGCellNoiseComponent : CSGBaseComponent
    {
        public CSGCellNoiseComponent(nint addr) : base(addr) { }
        public MeshCellNoiseProperties Properties { get { return this[nameof(Properties)].As<MeshCellNoiseProperties>(); } set { this["Properties"] = value; } }
        public BinaryTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<BinaryTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
    }
    public class CSGChildInstance : CSGBase
    {
        public CSGChildInstance(nint addr) : base(addr) { }
        public CSGChildInstanceProperties Properties { get { return this[nameof(Properties)].As<CSGChildInstanceProperties>(); } set { this["Properties"] = value; } }
        public GeneralTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<GeneralTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
        public CSGBase CSGChildInstanceRoot { get { return this[nameof(CSGChildInstanceRoot)].As<CSGBase>(); } set { this["CSGChildInstanceRoot"] = value; } }
        public BakeConfig CurrentBakeConfig { get { return this[nameof(CurrentBakeConfig)].As<BakeConfig>(); } set { this["CurrentBakeConfig"] = value; } }
        public Box ChildLocalSpaceBoundingBox { get { return this[nameof(ChildLocalSpaceBoundingBox)].As<Box>(); } set { this["ChildLocalSpaceBoundingBox"] = value; } }
        public Box WorldSpaceBoundingBox { get { return this[nameof(WorldSpaceBoundingBox)].As<Box>(); } set { this["WorldSpaceBoundingBox"] = value; } }
        public DeepCSGFloatTree BoundingTree { get { return this[nameof(BoundingTree)].As<DeepCSGFloatTree>(); } set { this["BoundingTree"] = value; } }
        public Matrix TransformMatInv { get { return this[nameof(TransformMatInv)].As<Matrix>(); } set { this["TransformMatInv"] = value; } }
        public DeepCSGTree TempTree { get { return this[nameof(TempTree)].As<DeepCSGTree>(); } set { this["TempTree"] = value; } }
    }
    public class CSGChildInstanceComponent : CSGBaseComponent
    {
        public CSGChildInstanceComponent(nint addr) : base(addr) { }
        public CSGChildInstanceProperties Properties { get { return this[nameof(Properties)].As<CSGChildInstanceProperties>(); } set { this["Properties"] = value; } }
        public GeneralTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<GeneralTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
    }
    public class SimpleMeshWithCachedTree : CSGBase
    {
        public SimpleMeshWithCachedTree(nint addr) : base(addr) { }
        public BinaryTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<BinaryTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
        public bool InvertCSG { get { return this[nameof(InvertCSG)].Flag; } set { this[nameof(InvertCSG)].Flag = value; } }
    }
    public class ConvexMeshWithCachedTree : SimpleMeshWithCachedTree
    {
        public ConvexMeshWithCachedTree(nint addr) : base(addr) { }
        public ConvexNoiseProperties Noise { get { return this[nameof(Noise)].As<ConvexNoiseProperties>(); } set { this["Noise"] = value; } }
    }
    public class CSGConvexCollider : ConvexMeshWithCachedTree
    {
        public CSGConvexCollider(nint addr) : base(addr) { }
        public CSGConvexColliderProperties Properties { get { return this[nameof(Properties)].As<CSGConvexColliderProperties>(); } set { this["Properties"] = value; } }
    }
    public class SimpleMeshWithCachedTreeComponent : CSGBaseComponent
    {
        public SimpleMeshWithCachedTreeComponent(nint addr) : base(addr) { }
        public BinaryTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<BinaryTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
        public bool InvertCSG { get { return this[nameof(InvertCSG)].Flag; } set { this[nameof(InvertCSG)].Flag = value; } }
    }
    public class ConvexMeshWithCachedTreeComponent : SimpleMeshWithCachedTreeComponent
    {
        public ConvexMeshWithCachedTreeComponent(nint addr) : base(addr) { }
        public ConvexNoiseProperties Noise { get { return this[nameof(Noise)].As<ConvexNoiseProperties>(); } set { this["Noise"] = value; } }
    }
    public class CSGConvexColliderComponent : ConvexMeshWithCachedTreeComponent
    {
        public CSGConvexColliderComponent(nint addr) : base(addr) { }
        public CSGConvexColliderProperties Properties { get { return this[nameof(Properties)].As<CSGConvexColliderProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGGroup : CSGBase
    {
        public CSGGroup(nint addr) : base(addr) { }
        public Array<CSGBase> Children { get { return new Array<CSGBase>(this[nameof(Children)].Address); } }
    }
    public class CSGGroupComponent : CSGBaseComponent
    {
        public CSGGroupComponent(nint addr) : base(addr) { }
    }
    public class CSGLayer : CSGGroup
    {
        public CSGLayer(nint addr) : base(addr) { }
        public MeshLayerProperties Properties { get { return this[nameof(Properties)].As<MeshLayerProperties>(); } set { this["Properties"] = value; } }
        public GeneralTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<GeneralTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
        public Box WorldSpaceBoundingBox { get { return this[nameof(WorldSpaceBoundingBox)].As<Box>(); } set { this["WorldSpaceBoundingBox"] = value; } }
        public DeepCSGFloatTree BoundingTree { get { return this[nameof(BoundingTree)].As<DeepCSGFloatTree>(); } set { this["BoundingTree"] = value; } }
        public DeepCSGTree TempTree { get { return this[nameof(TempTree)].As<DeepCSGTree>(); } set { this["TempTree"] = value; } }
        public Matrix TransformMatInv { get { return this[nameof(TransformMatInv)].As<Matrix>(); } set { this["TransformMatInv"] = value; } }
    }
    public class CSGLayerComponent : CSGGroupComponent
    {
        public CSGLayerComponent(nint addr) : base(addr) { }
        public MeshLayerProperties Properties { get { return this[nameof(Properties)].As<MeshLayerProperties>(); } set { this["Properties"] = value; } }
        public GeneralTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<GeneralTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
    }
    public class CSGAddMaterialLayers : CSGSingleChildBase
    {
        public CSGAddMaterialLayers(nint addr) : base(addr) { }
        public CSGAddMaterialLayersProperties Properties { get { return this[nameof(Properties)].As<CSGAddMaterialLayersProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGAddMaterialLayersComponent : CSGBaseComponent
    {
        public CSGAddMaterialLayersComponent(nint addr) : base(addr) { }
        public CSGAddMaterialLayersProperties Properties { get { return this[nameof(Properties)].As<CSGAddMaterialLayersProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGRandomizeTransform : CSGSingleChildBase
    {
        public CSGRandomizeTransform(nint addr) : base(addr) { }
        public CSGRandomizeTransformProperties Properties { get { return this[nameof(Properties)].As<CSGRandomizeTransformProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGRandomizeTransformComponent : CSGBaseComponent
    {
        public CSGRandomizeTransformComponent(nint addr) : base(addr) { }
        public CSGRandomizeTransformProperties Properties { get { return this[nameof(Properties)].As<CSGRandomizeTransformProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGRandomDisable : CSGSingleChildBase
    {
        public CSGRandomDisable(nint addr) : base(addr) { }
        public CSGRandomDisableProperties Properties { get { return this[nameof(Properties)].As<CSGRandomDisableProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGRandomDisableComponent : CSGBaseComponent
    {
        public CSGRandomDisableComponent(nint addr) : base(addr) { }
        public CSGRandomDisableProperties Properties { get { return this[nameof(Properties)].As<CSGRandomDisableProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGGridDuplicator : CSGDuplicateSingleChildBase
    {
        public CSGGridDuplicator(nint addr) : base(addr) { }
        public CSGGridDuplicatorProperties Properties { get { return this[nameof(Properties)].As<CSGGridDuplicatorProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGGridDuplicatorComponent : CSGBaseComponent
    {
        public CSGGridDuplicatorComponent(nint addr) : base(addr) { }
        public CSGGridDuplicatorProperties Properties { get { return this[nameof(Properties)].As<CSGGridDuplicatorProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGCircleDuplicator : CSGDuplicateSingleChildBase
    {
        public CSGCircleDuplicator(nint addr) : base(addr) { }
        public CSGCircleDuplicatorProperties Properties { get { return this[nameof(Properties)].As<CSGCircleDuplicatorProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGCircleDuplicatorComponent : CSGBaseComponent
    {
        public CSGCircleDuplicatorComponent(nint addr) : base(addr) { }
        public CSGCircleDuplicatorProperties Properties { get { return this[nameof(Properties)].As<CSGCircleDuplicatorProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGPreviewComponent : SceneComponent
    {
        public CSGPreviewComponent(nint addr) : base(addr) { }
        public CSGBuilderBase BaseBuilder { get { return this[nameof(BaseBuilder)].As<CSGBuilderBase>(); } set { this["BaseBuilder"] = value; } }
        public BakeConfig CurrentBakeConfig { get { return this[nameof(CurrentBakeConfig)].As<BakeConfig>(); } set { this["CurrentBakeConfig"] = value; } }
        public Object Meshes { get { return this[nameof(Meshes)]; } set { this[nameof(Meshes)] = value; } }
        public bool UsePreviewScene { get { return this[nameof(UsePreviewScene)].Flag; } set { this[nameof(UsePreviewScene)].Flag = value; } }
        public int ChangeCount { get { return this[nameof(ChangeCount)].GetValue<int>(); } set { this[nameof(ChangeCount)].SetValue<int>(value); } }
    }
    public class CSGPreviewScene : DataAsset
    {
        public CSGPreviewScene(nint addr) : base(addr) { }
        public Object Mesh { get { return this[nameof(Mesh)]; } set { this[nameof(Mesh)] = value; } }
        public BakeSettings Settings { get { return this[nameof(Settings)].As<BakeSettings>(); } set { this["Settings"] = value; } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
        public TerrainMaterialCore TerrainMaterial { get { return this[nameof(TerrainMaterial)].As<TerrainMaterialCore>(); } set { this["TerrainMaterial"] = value; } }
    }
    public class CSGPlane : ConvexMeshWithCachedTree
    {
        public CSGPlane(nint addr) : base(addr) { }
    }
    public class CSGPlaneComponent : ConvexMeshWithCachedTreeComponent
    {
        public CSGPlaneComponent(nint addr) : base(addr) { }
    }
    public class CSGBox : ConvexMeshWithCachedTree
    {
        public CSGBox(nint addr) : base(addr) { }
        public MeshBoxProperties Properties { get { return this[nameof(Properties)].As<MeshBoxProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGBoxComponent : ConvexMeshWithCachedTreeComponent
    {
        public CSGBoxComponent(nint addr) : base(addr) { }
        public MeshBoxProperties Properties { get { return this[nameof(Properties)].As<MeshBoxProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGCylinder : ConvexMeshWithCachedTree
    {
        public CSGCylinder(nint addr) : base(addr) { }
        public CSGCylinderProperties Properties { get { return this[nameof(Properties)].As<CSGCylinderProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGCylinderComponent : ConvexMeshWithCachedTreeComponent
    {
        public CSGCylinderComponent(nint addr) : base(addr) { }
        public CSGCylinderProperties Properties { get { return this[nameof(Properties)].As<CSGCylinderProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGCone : ConvexMeshWithCachedTree
    {
        public CSGCone(nint addr) : base(addr) { }
        public CSGConeProperties Properties { get { return this[nameof(Properties)].As<CSGConeProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGConeComponent : ConvexMeshWithCachedTreeComponent
    {
        public CSGConeComponent(nint addr) : base(addr) { }
        public CSGConeProperties Properties { get { return this[nameof(Properties)].As<CSGConeProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGSphere : ConvexMeshWithCachedTree
    {
        public CSGSphere(nint addr) : base(addr) { }
        public CSGSphereProperties Properties { get { return this[nameof(Properties)].As<CSGSphereProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGSphereComponent : ConvexMeshWithCachedTreeComponent
    {
        public CSGSphereComponent(nint addr) : base(addr) { }
        public CSGSphereProperties Properties { get { return this[nameof(Properties)].As<CSGSphereProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGWarped : CSGSingleChildBase
    {
        public CSGWarped(nint addr) : base(addr) { }
        public WarpedProperties Properties { get { return this[nameof(Properties)].As<WarpedProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGWarpedComponent : CSGBaseComponent
    {
        public CSGWarpedComponent(nint addr) : base(addr) { }
        public WarpedProperties Properties { get { return this[nameof(Properties)].As<WarpedProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGSplineWarp : CSGWarped
    {
        public CSGSplineWarp(nint addr) : base(addr) { }
        public SplineWarpProperties SplineProperties { get { return this[nameof(SplineProperties)].As<SplineWarpProperties>(); } set { this["SplineProperties"] = value; } }
        public SplineCurves SplineCurves { get { return this[nameof(SplineCurves)].As<SplineCurves>(); } set { this["SplineCurves"] = value; } }
        public Array<Box> AABBs { get { return new Array<Box>(this[nameof(AABBs)].Address); } }
        public Array<float> Keys { get { return new Array<float>(this[nameof(Keys)].Address); } }
        public Array<Vector4> planes { get { return new Array<Vector4>(this[nameof(planes)].Address); } }
        public Box TotalAABB { get { return this[nameof(TotalAABB)].As<Box>(); } set { this["TotalAABB"] = value; } }
    }
    public class CSGSplineWarpComponent : CSGWarpedComponent
    {
        public CSGSplineWarpComponent(nint addr) : base(addr) { }
        public SplineWarpProperties SplineProperties { get { return this[nameof(SplineProperties)].As<SplineWarpProperties>(); } set { this["SplineProperties"] = value; } }
    }
    public class CSGSDFInstance : CSGBase
    {
        public CSGSDFInstance(nint addr) : base(addr) { }
        public CSGSDFInstanceProperties Properties { get { return this[nameof(Properties)].As<CSGSDFInstanceProperties>(); } set { this["Properties"] = value; } }
        public BinaryTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<BinaryTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
        public SDFBase CSGSDFInstanceRoot { get { return this[nameof(CSGSDFInstanceRoot)].As<SDFBase>(); } set { this["CSGSDFInstanceRoot"] = value; } }
        public BakeConfig CurrentBakeConfig { get { return this[nameof(CurrentBakeConfig)].As<BakeConfig>(); } set { this["CurrentBakeConfig"] = value; } }
        public Box ChildLocalSpaceBoundingBox { get { return this[nameof(ChildLocalSpaceBoundingBox)].As<Box>(); } set { this["ChildLocalSpaceBoundingBox"] = value; } }
        public Box WorldSpaceBoundingBox { get { return this[nameof(WorldSpaceBoundingBox)].As<Box>(); } set { this["WorldSpaceBoundingBox"] = value; } }
        public DeepCSGFloatTree BoundingTree { get { return this[nameof(BoundingTree)].As<DeepCSGFloatTree>(); } set { this["BoundingTree"] = value; } }
        public Matrix TransformMatInv { get { return this[nameof(TransformMatInv)].As<Matrix>(); } set { this["TransformMatInv"] = value; } }
    }
    public class CSGSDFInstanceComponent : CSGBaseComponent
    {
        public CSGSDFInstanceComponent(nint addr) : base(addr) { }
        public CSGSDFInstanceProperties Properties { get { return this[nameof(Properties)].As<CSGSDFInstanceProperties>(); } set { this["Properties"] = value; } }
        public BinaryTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<BinaryTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
    }
    public class CSGModulatedSDFInstance : CSGBase
    {
        public CSGModulatedSDFInstance(nint addr) : base(addr) { }
        public CSGSDFModulatedInstanceProperties Properties { get { return this[nameof(Properties)].As<CSGSDFModulatedInstanceProperties>(); } set { this["Properties"] = value; } }
        public BinaryTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<BinaryTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
        public SDFBase CSGSDFInstanceRoot { get { return this[nameof(CSGSDFInstanceRoot)].As<SDFBase>(); } set { this["CSGSDFInstanceRoot"] = value; } }
        public BakeConfig CurrentBakeConfig { get { return this[nameof(CurrentBakeConfig)].As<BakeConfig>(); } set { this["CurrentBakeConfig"] = value; } }
        public SDFBase CSGSDFModulatedInstanceRoot { get { return this[nameof(CSGSDFModulatedInstanceRoot)].As<SDFBase>(); } set { this["CSGSDFModulatedInstanceRoot"] = value; } }
        public BakeConfig CurrentModulatedBakeConfig { get { return this[nameof(CurrentModulatedBakeConfig)].As<BakeConfig>(); } set { this["CurrentModulatedBakeConfig"] = value; } }
        public Box ChildLocalSpaceBoundingBox { get { return this[nameof(ChildLocalSpaceBoundingBox)].As<Box>(); } set { this["ChildLocalSpaceBoundingBox"] = value; } }
        public Box WorldSpaceBoundingBox { get { return this[nameof(WorldSpaceBoundingBox)].As<Box>(); } set { this["WorldSpaceBoundingBox"] = value; } }
        public DeepCSGFloatTree BoundingTree { get { return this[nameof(BoundingTree)].As<DeepCSGFloatTree>(); } set { this["BoundingTree"] = value; } }
        public Matrix TransformMatInv { get { return this[nameof(TransformMatInv)].As<Matrix>(); } set { this["TransformMatInv"] = value; } }
    }
    public class CSGModulatedSDFInstanceComponent : CSGBaseComponent
    {
        public CSGModulatedSDFInstanceComponent(nint addr) : base(addr) { }
        public CSGSDFModulatedInstanceProperties Properties { get { return this[nameof(Properties)].As<CSGSDFModulatedInstanceProperties>(); } set { this["Properties"] = value; } }
        public BinaryTerrainMaterialCombiner Materials { get { return this[nameof(Materials)].As<BinaryTerrainMaterialCombiner>(); } set { this["Materials"] = value; } }
    }
    public class CSGVoronoi : SimpleMeshWithCachedTree
    {
        public CSGVoronoi(nint addr) : base(addr) { }
        public VoronoiProperties Properties { get { return this[nameof(Properties)].As<VoronoiProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGVoronoiComponent : SimpleMeshWithCachedTreeComponent
    {
        public CSGVoronoiComponent(nint addr) : base(addr) { }
        public VoronoiProperties Properties { get { return this[nameof(Properties)].As<VoronoiProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGSTL : SimpleMeshWithCachedTree
    {
        public CSGSTL(nint addr) : base(addr) { }
        public CSGSTLProperties Properties { get { return this[nameof(Properties)].As<CSGSTLProperties>(); } set { this["Properties"] = value; } }
    }
    public class CSGSTLComponent : SimpleMeshWithCachedTreeComponent
    {
        public CSGSTLComponent(nint addr) : base(addr) { }
        public CSGSTLProperties Properties { get { return this[nameof(Properties)].As<CSGSTLProperties>(); } set { this["Properties"] = value; } }
    }
    public class DeepCSGSection : Actor
    {
        public DeepCSGSection(nint addr) : base(addr) { }
        public DeepProceduralMeshComponent DeepMesh { get { return this[nameof(DeepMesh)].As<DeepProceduralMeshComponent>(); } set { this["DeepMesh"] = value; } }
    }
    public class DeepProceduralMeshComponent : MeshComponent
    {
        public DeepProceduralMeshComponent(nint addr) : base(addr) { }
        public BodySetup ProcMeshBodySetup { get { return this[nameof(ProcMeshBodySetup)].As<BodySetup>(); } set { this["ProcMeshBodySetup"] = value; } }
        public TerrainMaterialCore FindTerrainMaterialFromPhysicalMaterial(PhysicalMaterial Material) { return Invoke<TerrainMaterialCore>(nameof(FindTerrainMaterialFromPhysicalMaterial), Material); }
    }
    public class SDFBuilder : CSGBuilderBase
    {
        public SDFBuilder(nint addr) : base(addr) { }
        public EPreviewCellSize PreviewSize { get { return (EPreviewCellSize)this[nameof(PreviewSize)].GetValue<int>(); } set { this[nameof(PreviewSize)].SetValue<int>((int)value); } }
        public TerrainMaterialCore PreviewMaterial { get { return this[nameof(PreviewMaterial)].As<TerrainMaterialCore>(); } set { this["PreviewMaterial"] = value; } }
        public SDFUnionOpComponent SDFRoot { get { return this[nameof(SDFRoot)].As<SDFUnionOpComponent>(); } set { this["SDFRoot"] = value; } }
    }
    public class HeightMapWithMinMaxQuadTree : DataAsset
    {
        public HeightMapWithMinMaxQuadTree(nint addr) : base(addr) { }
        public Object Status { get { return this[nameof(Status)]; } set { this[nameof(Status)] = value; } }
        public Object InputRenderTarget { get { return this[nameof(InputRenderTarget)]; } set { this[nameof(InputRenderTarget)] = value; } }
        public Object InputTexture { get { return this[nameof(InputTexture)]; } set { this[nameof(InputTexture)] = value; } }
        public Array<HMMinMaxLevel> MinMaxTree { get { return new Array<HMMinMaxLevel>(this[nameof(MinMaxTree)].Address); } }
        public float MinHeight { get { return this[nameof(MinHeight)].GetValue<float>(); } set { this[nameof(MinHeight)].SetValue<float>(value); } }
        public float MaxHeight { get { return this[nameof(MaxHeight)].GetValue<float>(); } set { this[nameof(MaxHeight)].SetValue<float>(value); } }
        public Array<float> Heights { get { return new Array<float>(this[nameof(Heights)].Address); } }
        public int Dimensions { get { return this[nameof(Dimensions)].GetValue<int>(); } set { this[nameof(Dimensions)].SetValue<int>(value); } }
        public bool Initialized { get { return this[nameof(Initialized)].Flag; } set { this[nameof(Initialized)].Flag = value; } }
        public void Generate() { Invoke(nameof(Generate)); }
    }
    public class SDFBase : BuilderBase
    {
        public SDFBase(nint addr) : base(addr) { }
        public SDFBaseProperties BaseProperties { get { return this[nameof(BaseProperties)].As<SDFBaseProperties>(); } set { this["BaseProperties"] = value; } }
        public Transform RelativeTransform { get { return this[nameof(RelativeTransform)].As<Transform>(); } set { this["RelativeTransform"] = value; } }
    }
    public class SDFHeightMap : SDFBase
    {
        public SDFHeightMap(nint addr) : base(addr) { }
        public SDFHeightMaproperties Properties { get { return this[nameof(Properties)].As<SDFHeightMaproperties>(); } set { this["Properties"] = value; } }
        public HeightMapWithMinMaxQuadTree Heightmap { get { return this[nameof(Heightmap)].As<HeightMapWithMinMaxQuadTree>(); } set { this["Heightmap"] = value; } }
    }
    public class SDFBaseComponent : CSGBuilderBaseSceneComponent
    {
        public SDFBaseComponent(nint addr) : base(addr) { }
        public SDFBaseProperties BaseProperties { get { return this[nameof(BaseProperties)].As<SDFBaseProperties>(); } set { this["BaseProperties"] = value; } }
    }
    public class SDFHeightMapComponent : SDFBaseComponent
    {
        public SDFHeightMapComponent(nint addr) : base(addr) { }
        public SDFHeightMaproperties Properties { get { return this[nameof(Properties)].As<SDFHeightMaproperties>(); } set { this["Properties"] = value; } }
        public HeightMapWithMinMaxQuadTree Heightmap { get { return this[nameof(Heightmap)].As<HeightMapWithMinMaxQuadTree>(); } set { this["Heightmap"] = value; } }
    }
    public class SDFSingleChildBase : SDFBase
    {
        public SDFSingleChildBase(nint addr) : base(addr) { }
        public SDFBase Child { get { return this[nameof(Child)].As<SDFBase>(); } set { this["Child"] = value; } }
    }
    public class SDFModifier : SDFSingleChildBase
    {
        public SDFModifier(nint addr) : base(addr) { }
        public SDFModifierProperties Properties { get { return this[nameof(Properties)].As<SDFModifierProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFModifierComponent : SDFBaseComponent
    {
        public SDFModifierComponent(nint addr) : base(addr) { }
        public SDFModifierProperties Properties { get { return this[nameof(Properties)].As<SDFModifierProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFUnionOp : SDFBase
    {
        public SDFUnionOp(nint addr) : base(addr) { }
        public SDFSmoothingProperties Properties { get { return this[nameof(Properties)].As<SDFSmoothingProperties>(); } set { this["Properties"] = value; } }
        public Array<SDFBase> Arguments { get { return new Array<SDFBase>(this[nameof(Arguments)].Address); } }
    }
    public class SDFUnionOpComponent : SDFBaseComponent
    {
        public SDFUnionOpComponent(nint addr) : base(addr) { }
        public SDFSmoothingProperties Properties { get { return this[nameof(Properties)].As<SDFSmoothingProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFIntersectOp : SDFBase
    {
        public SDFIntersectOp(nint addr) : base(addr) { }
        public SDFSmoothingProperties Properties { get { return this[nameof(Properties)].As<SDFSmoothingProperties>(); } set { this["Properties"] = value; } }
        public Array<SDFBase> Arguments { get { return new Array<SDFBase>(this[nameof(Arguments)].Address); } }
    }
    public class SDFIntersectOpComponent : SDFBaseComponent
    {
        public SDFIntersectOpComponent(nint addr) : base(addr) { }
        public SDFSmoothingProperties Properties { get { return this[nameof(Properties)].As<SDFSmoothingProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFSubOp : SDFBase
    {
        public SDFSubOp(nint addr) : base(addr) { }
        public SDFSmoothingProperties Properties { get { return this[nameof(Properties)].As<SDFSmoothingProperties>(); } set { this["Properties"] = value; } }
        public SDFBase A { get { return this[nameof(A)].As<SDFBase>(); } set { this["A"] = value; } }
        public SDFBase B { get { return this[nameof(B)].As<SDFBase>(); } set { this["B"] = value; } }
    }
    public class SDFSubOpComponent : SDFBaseComponent
    {
        public SDFSubOpComponent(nint addr) : base(addr) { }
        public SDFSmoothingProperties Properties { get { return this[nameof(Properties)].As<SDFSmoothingProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFOnion : SDFBase
    {
        public SDFOnion(nint addr) : base(addr) { }
        public SDFOnionProperties Properties { get { return this[nameof(Properties)].As<SDFOnionProperties>(); } set { this["Properties"] = value; } }
        public SDFBase Argument { get { return this[nameof(Argument)].As<SDFBase>(); } set { this["Argument"] = value; } }
    }
    public class SDFOnionComponent : SDFBaseComponent
    {
        public SDFOnionComponent(nint addr) : base(addr) { }
        public SDFOnionProperties Properties { get { return this[nameof(Properties)].As<SDFOnionProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFRandomizeTransform : SDFSingleChildBase
    {
        public SDFRandomizeTransform(nint addr) : base(addr) { }
        public SDFRandomizeTransformProperties Properties { get { return this[nameof(Properties)].As<SDFRandomizeTransformProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFRandomizeTransformComponent : SDFBaseComponent
    {
        public SDFRandomizeTransformComponent(nint addr) : base(addr) { }
        public SDFRandomizeTransformProperties Properties { get { return this[nameof(Properties)].As<SDFRandomizeTransformProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFRandomDisable : SDFSingleChildBase
    {
        public SDFRandomDisable(nint addr) : base(addr) { }
        public SDFRandomDisableProperties Properties { get { return this[nameof(Properties)].As<SDFRandomDisableProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFRandomDisableComponent : SDFBaseComponent
    {
        public SDFRandomDisableComponent(nint addr) : base(addr) { }
        public SDFRandomDisableProperties Properties { get { return this[nameof(Properties)].As<SDFRandomDisableProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFBaseWithTransform : SDFBase
    {
        public SDFBaseWithTransform(nint addr) : base(addr) { }
    }
    public class SDFBaseWithTransformComponent : SDFBaseComponent
    {
        public SDFBaseWithTransformComponent(nint addr) : base(addr) { }
    }
    public class SDFSphere : SDFBaseWithTransform
    {
        public SDFSphere(nint addr) : base(addr) { }
        public SDFSphereProperties Properties { get { return this[nameof(Properties)].As<SDFSphereProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFSphereComponent : SDFBaseWithTransformComponent
    {
        public SDFSphereComponent(nint addr) : base(addr) { }
        public SDFSphereProperties Properties { get { return this[nameof(Properties)].As<SDFSphereProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFPlane : SDFBaseWithTransform
    {
        public SDFPlane(nint addr) : base(addr) { }
    }
    public class SDFPlaneComponent : SDFBaseWithTransformComponent
    {
        public SDFPlaneComponent(nint addr) : base(addr) { }
    }
    public class SDFBox : SDFBaseWithTransform
    {
        public SDFBox(nint addr) : base(addr) { }
        public SDFBoxProperties Properties { get { return this[nameof(Properties)].As<SDFBoxProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFBoxComponent : SDFBaseWithTransformComponent
    {
        public SDFBoxComponent(nint addr) : base(addr) { }
        public SDFBoxProperties Properties { get { return this[nameof(Properties)].As<SDFBoxProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFCylinder : SDFBaseWithTransform
    {
        public SDFCylinder(nint addr) : base(addr) { }
        public SDFCylinderProperties Properties { get { return this[nameof(Properties)].As<SDFCylinderProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFCylinderComponent : SDFBaseWithTransformComponent
    {
        public SDFCylinderComponent(nint addr) : base(addr) { }
        public SDFCylinderProperties Properties { get { return this[nameof(Properties)].As<SDFCylinderProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFCapsule : SDFBaseWithTransform
    {
        public SDFCapsule(nint addr) : base(addr) { }
        public SDFCapsuleProperties Properties { get { return this[nameof(Properties)].As<SDFCapsuleProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFCapsuleComponent : SDFBaseWithTransformComponent
    {
        public SDFCapsuleComponent(nint addr) : base(addr) { }
        public SDFCapsuleProperties Properties { get { return this[nameof(Properties)].As<SDFCapsuleProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFTorus : SDFBaseWithTransform
    {
        public SDFTorus(nint addr) : base(addr) { }
        public SDFTorusProperties Properties { get { return this[nameof(Properties)].As<SDFTorusProperties>(); } set { this["Properties"] = value; } }
    }
    public class SDFTorusComponent : SDFBaseWithTransformComponent
    {
        public SDFTorusComponent(nint addr) : base(addr) { }
        public SDFTorusProperties Properties { get { return this[nameof(Properties)].As<SDFTorusProperties>(); } set { this["Properties"] = value; } }
    }
    public class StaticMeshCarver : DataAsset
    {
        public StaticMeshCarver(nint addr) : base(addr) { }
        public Object Status { get { return this[nameof(Status)]; } set { this[nameof(Status)] = value; } }
        public Object Mesh { get { return this[nameof(Mesh)]; } set { this[nameof(Mesh)] = value; } }
        public Box AABB { get { return this[nameof(AABB)].As<Box>(); } set { this["AABB"] = value; } }
        public DeepCSGFloatTree BSPTree { get { return this[nameof(BSPTree)].As<DeepCSGFloatTree>(); } set { this["BSPTree"] = value; } }
        public DeepCSGFloatTreePacked BSPTreePacked { get { return this[nameof(BSPTreePacked)].As<DeepCSGFloatTreePacked>(); } set { this["BSPTreePacked"] = value; } }
        public void Generate() { Invoke(nameof(Generate)); }
        public void ExportPreviewMesh() { Invoke(nameof(ExportPreviewMesh)); }
    }
    public enum ECSGModifiers : int
    {
        AddMaterialLayers = 0,
        HasCachedTree = 1,
        ECSGModifiers_MAX = 2,
    }
    public enum EGeneralComb : int
    {
        Empty = 0,
        KeepSrc = 1,
        KeepDest = 2,
        Replace = 3,
        EGeneralComb_MAX = 4,
    }
    public enum EGeneralCombEmpty : int
    {
        Empty = 0,
        Replace = 1,
        EGeneralCombEmpty_MAX = 2,
    }
    public enum EGeneralPattern : int
    {
        SrcSpecific = 0,
        DestSpecific = 1,
        EGeneralPattern_MAX = 2,
    }
    public enum EPattern : int
    {
        Specific = 0,
        Precious = 1,
        EPattern_MAX = 2,
    }
    public enum EBinaryComb : int
    {
        Empty = 0,
        Unchanged = 1,
        Replace = 2,
        Burn = 3,
        BiomeRock = 4,
        EBinaryComb_MAX = 5,
    }
    public enum EEmptyBinaryComb : int
    {
        Unchanged = 0,
        Replace = 1,
        BiomeRock = 2,
        EEmptyBinaryComb_MAX = 3,
    }
    public enum EPreviewCellSize : int
    {
        PRV_CELL_SIZE_12_6 = 0,
        PRV_CELL_SIZE_26 = 1,
        PRV_CELL_SIZE_51 = 2,
        PRV_CELL_SIZE_101 = 3,
        PRV_CELL_SIZE_201 = 4,
        PRV_CELL_SIZE_MAX = 5,
    }
    public enum ESplineWarpType : int
    {
        Normal = 0,
        ForceZUp = 1,
        StairLike = 2,
        ESplineWarpType_MAX = 3,
    }
    public enum ESDFModulateMode : int
    {
        MM_Disabled = 0,
        MM_Single = 1,
        MM_Loop = 2,
        MM_MAX = 3,
    }
    public enum CarveOptionsCellSize : int
    {
        CARVE_CELL_SIZE_26 = 0,
        CARVE_CELL_SIZE_51 = 1,
        CARVE_CELL_SIZE_101 = 2,
        CARVE_CELL_SIZE_201 = 3,
        CARVE_CELL_SIZE_MAX = 4,
    }
    public enum EPreciousMaterialOptions : int
    {
        TurnIntoGems = 0,
        LeaveUntouched = 1,
        Ignore = 2,
        EPreciousMaterialOptions_MAX = 3,
    }
    public enum ECarveFilterType : int
    {
        ReplaceAll = 0,
        ReplaceEmpty = 1,
        ReplaceSolid = 2,
        ReplaceEphemeral = 3,
        ECarveFilterType_MAX = 4,
    }
    public enum EPathfinderResult : int
    {
        Success = 0,
        Failed_StartingPointNotFound = 1,
        Failed_EndPointNotFound = 2,
        Failed_PointsNotConnected = 3,
        Failed_UsedTooManyNodes = 4,
        Failed_NotReady = 5,
        Failed_UnknownError = 6,
        EPathfinderResult_MAX = 7,
    }
    public enum PFCollisionType : int
    {
        SolidWalkable = 0,
        Block = 1,
        Danger = 2,
        PFCollisionType_MAX = 3,
    }
    public enum DeepPathFinderPreference : int
    {
        None = 0,
        Floor = 1,
        Walls = 2,
        Ceiling = 3,
        DeepPathFinderPreference_MAX = 4,
    }
    public enum DeepPathFinderSize : int
    {
        Invalid = 0,
        Small = 3,
        Medium = 2,
        Large = 1,
        DeepPathFinderSize_MAX = 4,
    }
    public enum DeepPathFinderType : int
    {
        Walk = 0,
        Fly = 1,
        MAX = 2,
    }
    public enum EFNDomainWarpType : int
    {
        OPENSIMPLEX2 = 0,
        OPENSIMPLEX2_REDUCED = 1,
        BASICGRID = 2,
        EFNDomainWarpType_MAX = 3,
    }
    public enum EFNCellularReturnType : int
    {
        CELLVALUE = 0,
        DISTANCE = 1,
        DISTANCE2 = 2,
        DISTANCE2ADD = 3,
        DISTANCE2SUB = 4,
        DISTANCE2MUL = 5,
        DISTANCE2DIV = 6,
        EFNCellularReturnType_MAX = 7,
    }
    public enum EFNCellularDistanceFunc : int
    {
        EUCLIDEAN = 0,
        EUCLIDEANSQ = 1,
        MANHATTAN = 2,
        HYBRID = 3,
        EFNCellularDistanceFunc_MAX = 4,
    }
    public enum EFNFractalType : int
    {
        NONE = 0,
        FBM = 1,
        RIDGED = 2,
        PINGPONG = 3,
        DOMAIN_WARP_PROGRESSIVE = 4,
        DOMAIN_WARP_INDEPENDENT = 5,
        EFNFractalType_MAX = 6,
    }
    public enum EFNRotationType3D : int
    {
        NONE = 0,
        IMPROVE_XY_PLANES = 1,
        IMPROVE_XZ_PLANES = 2,
        EFNRotationType3D_MAX = 3,
    }
    public enum EFNNoiseType : int
    {
        OPENSIMPLEX2 = 0,
        OPENSIMPLEX2S = 1,
        CELLULAR = 2,
        PERLIN = 3,
        VALUE_CUBIC = 4,
        VALUE = 5,
        EFNNoiseType_MAX = 6,
    }
    public class MatrixWithExactSync : Object
    {
        public MatrixWithExactSync(nint addr) : base(addr) { }
        public float Values { get { return this[nameof(Values)].GetValue<float>(); } set { this[nameof(Values)].SetValue<float>(value); } }
    }
    public class BakeSettings : Object
    {
        public BakeSettings(nint addr) : base(addr) { }
        public Array<BakeSetting> Pairs { get { return new Array<BakeSetting>(this[nameof(Pairs)].Address); } }
    }
    public class BakeSetting : Object
    {
        public BakeSetting(nint addr) : base(addr) { }
        public Object Key { get { return this[nameof(Key)]; } set { this[nameof(Key)] = value; } }
        public int IntValue { get { return this[nameof(IntValue)].GetValue<int>(); } set { this[nameof(IntValue)].SetValue<int>(value); } }
        public float FloatValue { get { return this[nameof(FloatValue)].GetValue<float>(); } set { this[nameof(FloatValue)].SetValue<float>(value); } }
        public Vector vectorValue { get { return this[nameof(vectorValue)].As<Vector>(); } set { this["vectorValue"] = value; } }
    }
    public class CarveSplineSegment : Object
    {
        public CarveSplineSegment(nint addr) : base(addr) { }
        public Vector SplineStart { get { return this[nameof(SplineStart)].As<Vector>(); } set { this["SplineStart"] = value; } }
        public Vector SplineStartTangent { get { return this[nameof(SplineStartTangent)].As<Vector>(); } set { this["SplineStartTangent"] = value; } }
        public Vector SplineEnd { get { return this[nameof(SplineEnd)].As<Vector>(); } set { this["SplineEnd"] = value; } }
        public Vector SplineEndTangent { get { return this[nameof(SplineEndTangent)].As<Vector>(); } set { this["SplineEndTangent"] = value; } }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
    }
    public class BakeEntry : Object
    {
        public BakeEntry(nint addr) : base(addr) { }
        public DeepCSGFloatTreePacked Tree { get { return this[nameof(Tree)].As<DeepCSGFloatTreePacked>(); } set { this["Tree"] = value; } }
        public Box AABB { get { return this[nameof(AABB)].As<Box>(); } set { this["AABB"] = value; } }
        public Array<TerrainMaterialCore> Materials { get { return new Array<TerrainMaterialCore>(this[nameof(Materials)].Address); } }
        public Array<SmartTerrainMaterialVal> SmartMaterials { get { return new Array<SmartTerrainMaterialVal>(this[nameof(SmartMaterials)].Address); } }
    }
    public class SmartTerrainMaterialVal : Object
    {
        public SmartTerrainMaterialVal(nint addr) : base(addr) { }
        public uint IfEmpty { get { return this[nameof(IfEmpty)].GetValue<uint>(); } set { this[nameof(IfEmpty)].SetValue<uint>(value); } }
        public uint IfSolid { get { return this[nameof(IfSolid)].GetValue<uint>(); } set { this[nameof(IfSolid)].SetValue<uint>(value); } }
        public Array<uint> OverrideKeys { get { return new Array<uint>(this[nameof(OverrideKeys)].Address); } }
        public Array<uint> OverrideValues { get { return new Array<uint>(this[nameof(OverrideValues)].Address); } }
    }
    public class DeepCSGFloatTreePacked : Object
    {
        public DeepCSGFloatTreePacked(nint addr) : base(addr) { }
        public DeepCSGNode Root { get { return this[nameof(Root)].As<DeepCSGNode>(); } set { this["Root"] = value; } }
        public Array<int> encplanes { get { return new Array<int>(this[nameof(encplanes)].Address); } }
    }
    public class DeepCSGNode : Object
    {
        public DeepCSGNode(nint addr) : base(addr) { }
        public uint Val { get { return this[nameof(Val)].GetValue<uint>(); } set { this[nameof(Val)].SetValue<uint>(value); } }
    }
    public class CSGBakedChildInstanceProperties : Object
    {
        public CSGBakedChildInstanceProperties(nint addr) : base(addr) { }
        public CSGBake BakedCSG { get { return this[nameof(BakedCSG)].As<CSGBake>(); } set { this["BakedCSG"] = value; } }
        public int VariantIndex { get { return this[nameof(VariantIndex)].GetValue<int>(); } set { this[nameof(VariantIndex)].SetValue<int>(value); } }
    }
    public class MeshBaseProperties : Object
    {
        public MeshBaseProperties(nint addr) : base(addr) { }
        public bool Enabled { get { return this[nameof(Enabled)].Flag; } set { this[nameof(Enabled)].Flag = value; } }
    }
    public class CSGAddMaterialLayersProperties : Object
    {
        public CSGAddMaterialLayersProperties(nint addr) : base(addr) { }
        public Array<CSGLayers> Layers { get { return new Array<CSGLayers>(this[nameof(Layers)].Address); } }
        public BinaryTerrainMaterialCombiner Inner { get { return this[nameof(Inner)].As<BinaryTerrainMaterialCombiner>(); } set { this["Inner"] = value; } }
    }
    public class BinaryTerrainMaterialCombiner : Object
    {
        public BinaryTerrainMaterialCombiner(nint addr) : base(addr) { }
        public EmptyBinaryMatProperties IfEmpty { get { return this[nameof(IfEmpty)].As<EmptyBinaryMatProperties>(); } set { this["IfEmpty"] = value; } }
        public BinaryMatProperties IfSolid { get { return this[nameof(IfSolid)].As<BinaryMatProperties>(); } set { this["IfSolid"] = value; } }
        public Array<BinaryMatPatterns> Patterns { get { return new Array<BinaryMatPatterns>(this[nameof(Patterns)].Address); } }
    }
    public class BinaryMatPatterns : Object
    {
        public BinaryMatPatterns(nint addr) : base(addr) { }
        public EPattern PatternType { get { return (EPattern)this[nameof(PatternType)].GetValue<int>(); } set { this[nameof(PatternType)].SetValue<int>((int)value); } }
        public TerrainMaterialCore PatternMaterial { get { return this[nameof(PatternMaterial)].As<TerrainMaterialCore>(); } set { this["PatternMaterial"] = value; } }
        public BinaryMatProperties ReplaceWith { get { return this[nameof(ReplaceWith)].As<BinaryMatProperties>(); } set { this["ReplaceWith"] = value; } }
    }
    public class BinaryMatProperties : Object
    {
        public BinaryMatProperties(nint addr) : base(addr) { }
        public EBinaryComb Result { get { return (EBinaryComb)this[nameof(Result)].GetValue<int>(); } set { this[nameof(Result)].SetValue<int>((int)value); } }
        public TerrainMaterialCore Material { get { return this[nameof(Material)].As<TerrainMaterialCore>(); } set { this["Material"] = value; } }
    }
    public class EmptyBinaryMatProperties : Object
    {
        public EmptyBinaryMatProperties(nint addr) : base(addr) { }
        public EEmptyBinaryComb Result { get { return (EEmptyBinaryComb)this[nameof(Result)].GetValue<int>(); } set { this[nameof(Result)].SetValue<int>((int)value); } }
        public TerrainMaterialCore Material { get { return this[nameof(Material)].As<TerrainMaterialCore>(); } set { this["Material"] = value; } }
    }
    public class CSGLayers : Object
    {
        public CSGLayers(nint addr) : base(addr) { }
        public float Offset { get { return this[nameof(Offset)].GetValue<float>(); } set { this[nameof(Offset)].SetValue<float>(value); } }
        public BinaryTerrainMaterialCombiner Above { get { return this[nameof(Above)].As<BinaryTerrainMaterialCombiner>(); } set { this["Above"] = value; } }
    }
    public class GeneralTerrainMaterialCombiner : Object
    {
        public GeneralTerrainMaterialCombiner(nint addr) : base(addr) { }
        public GeneralMatPropertiesEmpty IfBothEmpty { get { return this[nameof(IfBothEmpty)].As<GeneralMatPropertiesEmpty>(); } set { this["IfBothEmpty"] = value; } }
        public Array<GeneralMatPatterns> Patterns { get { return new Array<GeneralMatPatterns>(this[nameof(Patterns)].Address); } }
        public GeneralMatProperties IfBothSolid { get { return this[nameof(IfBothSolid)].As<GeneralMatProperties>(); } set { this["IfBothSolid"] = value; } }
        public GeneralMatProperties IfSrcSolid { get { return this[nameof(IfSrcSolid)].As<GeneralMatProperties>(); } set { this["IfSrcSolid"] = value; } }
        public GeneralMatProperties IfDestSolid { get { return this[nameof(IfDestSolid)].As<GeneralMatProperties>(); } set { this["IfDestSolid"] = value; } }
    }
    public class GeneralMatProperties : Object
    {
        public GeneralMatProperties(nint addr) : base(addr) { }
        public EGeneralComb Result { get { return (EGeneralComb)this[nameof(Result)].GetValue<int>(); } set { this[nameof(Result)].SetValue<int>((int)value); } }
        public TerrainMaterialCore Material { get { return this[nameof(Material)].As<TerrainMaterialCore>(); } set { this["Material"] = value; } }
    }
    public class GeneralMatPatterns : Object
    {
        public GeneralMatPatterns(nint addr) : base(addr) { }
        public EGeneralPattern PatternType { get { return (EGeneralPattern)this[nameof(PatternType)].GetValue<int>(); } set { this[nameof(PatternType)].SetValue<int>((int)value); } }
        public TerrainMaterialCore PatternMaterial { get { return this[nameof(PatternMaterial)].As<TerrainMaterialCore>(); } set { this["PatternMaterial"] = value; } }
        public GeneralMatProperties ReplaceWith { get { return this[nameof(ReplaceWith)].As<GeneralMatProperties>(); } set { this["ReplaceWith"] = value; } }
    }
    public class GeneralMatPropertiesEmpty : Object
    {
        public GeneralMatPropertiesEmpty(nint addr) : base(addr) { }
        public EGeneralCombEmpty Result { get { return (EGeneralCombEmpty)this[nameof(Result)].GetValue<int>(); } set { this[nameof(Result)].SetValue<int>((int)value); } }
        public TerrainMaterialCore Material { get { return this[nameof(Material)].As<TerrainMaterialCore>(); } set { this["Material"] = value; } }
    }
    public class MeshCellNoiseProperties : Object
    {
        public MeshCellNoiseProperties(nint addr) : base(addr) { }
        public Vector CellSize { get { return this[nameof(CellSize)].As<Vector>(); } set { this["CellSize"] = value; } }
        public float CellOffsetFactor { get { return this[nameof(CellOffsetFactor)].GetValue<float>(); } set { this[nameof(CellOffsetFactor)].SetValue<float>(value); } }
        public float InsideFraction { get { return this[nameof(InsideFraction)].GetValue<float>(); } set { this[nameof(InsideFraction)].SetValue<float>(value); } }
        public float Distance { get { return this[nameof(Distance)].GetValue<float>(); } set { this[nameof(Distance)].SetValue<float>(value); } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
    }
    public class CSGChildInstanceProperties : Object
    {
        public CSGChildInstanceProperties(nint addr) : base(addr) { }
        public Object Mesh { get { return this[nameof(Mesh)]; } set { this[nameof(Mesh)] = value; } }
        public BakeSettings Settings { get { return this[nameof(Settings)].As<BakeSettings>(); } set { this["Settings"] = value; } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
    }
    public class CSGConvexColliderProperties : Object
    {
        public CSGConvexColliderProperties(nint addr) : base(addr) { }
        public StaticMesh collider { get { return this[nameof(collider)].As<StaticMesh>(); } set { this["collider"] = value; } }
    }
    public class MeshLayerProperties : Object
    {
        public MeshLayerProperties(nint addr) : base(addr) { }
        public TerrainMaterialCore StartMaterial { get { return this[nameof(StartMaterial)].As<TerrainMaterialCore>(); } set { this["StartMaterial"] = value; } }
        public Box BoundingBox { get { return this[nameof(BoundingBox)].As<Box>(); } set { this["BoundingBox"] = value; } }
    }
    public class CSGCircleDuplicatorProperties : Object
    {
        public CSGCircleDuplicatorProperties(nint addr) : base(addr) { }
        public int Num { get { return this[nameof(Num)].GetValue<int>(); } set { this[nameof(Num)].SetValue<int>(value); } }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
    }
    public class CSGGridDuplicatorProperties : Object
    {
        public CSGGridDuplicatorProperties(nint addr) : base(addr) { }
        public int NumA { get { return this[nameof(NumA)].GetValue<int>(); } set { this[nameof(NumA)].SetValue<int>(value); } }
        public int NumB { get { return this[nameof(NumB)].GetValue<int>(); } set { this[nameof(NumB)].SetValue<int>(value); } }
        public Vector DirectionA { get { return this[nameof(DirectionA)].As<Vector>(); } set { this["DirectionA"] = value; } }
        public Vector DirectionB { get { return this[nameof(DirectionB)].As<Vector>(); } set { this["DirectionB"] = value; } }
    }
    public class CSGRandomDisableProperties : Object
    {
        public CSGRandomDisableProperties(nint addr) : base(addr) { }
        public float DisableProbability { get { return this[nameof(DisableProbability)].GetValue<float>(); } set { this[nameof(DisableProbability)].SetValue<float>(value); } }
    }
    public class CSGRandomizeTransformProperties : Object
    {
        public CSGRandomizeTransformProperties(nint addr) : base(addr) { }
        public Box Translation { get { return this[nameof(Translation)].As<Box>(); } set { this["Translation"] = value; } }
        public float RotationMinZ { get { return this[nameof(RotationMinZ)].GetValue<float>(); } set { this[nameof(RotationMinZ)].SetValue<float>(value); } }
        public float RotationMaxZ { get { return this[nameof(RotationMaxZ)].GetValue<float>(); } set { this[nameof(RotationMaxZ)].SetValue<float>(value); } }
        public float RotationMinY { get { return this[nameof(RotationMinY)].GetValue<float>(); } set { this[nameof(RotationMinY)].SetValue<float>(value); } }
        public float RotationMaxY { get { return this[nameof(RotationMaxY)].GetValue<float>(); } set { this[nameof(RotationMaxY)].SetValue<float>(value); } }
        public float RotationMinX { get { return this[nameof(RotationMinX)].GetValue<float>(); } set { this[nameof(RotationMinX)].SetValue<float>(value); } }
        public float RotationMaxX { get { return this[nameof(RotationMaxX)].GetValue<float>(); } set { this[nameof(RotationMaxX)].SetValue<float>(value); } }
        public Vector ScaleMin { get { return this[nameof(ScaleMin)].As<Vector>(); } set { this["ScaleMin"] = value; } }
        public Vector ScaleMax { get { return this[nameof(ScaleMax)].As<Vector>(); } set { this["ScaleMax"] = value; } }
        public bool ScaleAxesIndependent { get { return this[nameof(ScaleAxesIndependent)].Flag; } set { this[nameof(ScaleAxesIndependent)].Flag = value; } }
        public bool DisableRandomize { get { return this[nameof(DisableRandomize)].Flag; } set { this[nameof(DisableRandomize)].Flag = value; } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
    }
    public class CSGSphereProperties : Object
    {
        public CSGSphereProperties(nint addr) : base(addr) { }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
        public float AngleTop { get { return this[nameof(AngleTop)].GetValue<float>(); } set { this[nameof(AngleTop)].SetValue<float>(value); } }
        public float AngleBottom { get { return this[nameof(AngleBottom)].GetValue<float>(); } set { this[nameof(AngleBottom)].SetValue<float>(value); } }
        public int SidesTopBottom { get { return this[nameof(SidesTopBottom)].GetValue<int>(); } set { this[nameof(SidesTopBottom)].SetValue<int>(value); } }
        public int Sides { get { return this[nameof(Sides)].GetValue<int>(); } set { this[nameof(Sides)].SetValue<int>(value); } }
    }
    public class CSGConeProperties : Object
    {
        public CSGConeProperties(nint addr) : base(addr) { }
        public float Height { get { return this[nameof(Height)].GetValue<float>(); } set { this[nameof(Height)].SetValue<float>(value); } }
        public float RadiusTop { get { return this[nameof(RadiusTop)].GetValue<float>(); } set { this[nameof(RadiusTop)].SetValue<float>(value); } }
        public float RadiusBottom { get { return this[nameof(RadiusBottom)].GetValue<float>(); } set { this[nameof(RadiusBottom)].SetValue<float>(value); } }
        public int Sides { get { return this[nameof(Sides)].GetValue<int>(); } set { this[nameof(Sides)].SetValue<int>(value); } }
    }
    public class CSGCylinderProperties : Object
    {
        public CSGCylinderProperties(nint addr) : base(addr) { }
        public float Height { get { return this[nameof(Height)].GetValue<float>(); } set { this[nameof(Height)].SetValue<float>(value); } }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
        public int Sides { get { return this[nameof(Sides)].GetValue<int>(); } set { this[nameof(Sides)].SetValue<int>(value); } }
    }
    public class MeshBoxProperties : Object
    {
        public MeshBoxProperties(nint addr) : base(addr) { }
        public Vector HalfSize { get { return this[nameof(HalfSize)].As<Vector>(); } set { this["HalfSize"] = value; } }
        public int BevelSegments { get { return this[nameof(BevelSegments)].GetValue<int>(); } set { this[nameof(BevelSegments)].SetValue<int>(value); } }
        public float BevelSize { get { return this[nameof(BevelSize)].GetValue<float>(); } set { this[nameof(BevelSize)].SetValue<float>(value); } }
    }
    public class ConvexNoiseProperties : Object
    {
        public ConvexNoiseProperties(nint addr) : base(addr) { }
        public float Amplitude { get { return this[nameof(Amplitude)].GetValue<float>(); } set { this[nameof(Amplitude)].SetValue<float>(value); } }
        public float GridSize { get { return this[nameof(GridSize)].GetValue<float>(); } set { this[nameof(GridSize)].SetValue<float>(value); } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
    }
    public class SplineWarpProperties : Object
    {
        public SplineWarpProperties(nint addr) : base(addr) { }
        public Box ElementBox { get { return this[nameof(ElementBox)].As<Box>(); } set { this["ElementBox"] = value; } }
        public ESplineWarpType SplineWarpType { get { return (ESplineWarpType)this[nameof(SplineWarpType)].GetValue<int>(); } set { this[nameof(SplineWarpType)].SetValue<int>((int)value); } }
    }
    public class WarpedProperties : Object
    {
        public WarpedProperties(nint addr) : base(addr) { }
        public EPreviewCellSize CellSize { get { return (EPreviewCellSize)this[nameof(CellSize)].GetValue<int>(); } set { this[nameof(CellSize)].SetValue<int>((int)value); } }
        public WarpNoiseProperties WarpNoise { get { return this[nameof(WarpNoise)].As<WarpNoiseProperties>(); } set { this["WarpNoise"] = value; } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
    }
    public class WarpNoiseProperties : Object
    {
        public WarpNoiseProperties(nint addr) : base(addr) { }
        public float Frequency { get { return this[nameof(Frequency)].GetValue<float>(); } set { this[nameof(Frequency)].SetValue<float>(value); } }
        public EFNRotationType3D RotationType3d { get { return (EFNRotationType3D)this[nameof(RotationType3d)].GetValue<int>(); } set { this[nameof(RotationType3d)].SetValue<int>((int)value); } }
        public EFNFractalType FractalType { get { return (EFNFractalType)this[nameof(FractalType)].GetValue<int>(); } set { this[nameof(FractalType)].SetValue<int>((int)value); } }
        public int Octaves { get { return this[nameof(Octaves)].GetValue<int>(); } set { this[nameof(Octaves)].SetValue<int>(value); } }
        public float Lacunarity { get { return this[nameof(Lacunarity)].GetValue<float>(); } set { this[nameof(Lacunarity)].SetValue<float>(value); } }
        public float Gain { get { return this[nameof(Gain)].GetValue<float>(); } set { this[nameof(Gain)].SetValue<float>(value); } }
        public float WeightedStrength { get { return this[nameof(WeightedStrength)].GetValue<float>(); } set { this[nameof(WeightedStrength)].SetValue<float>(value); } }
        public EFNDomainWarpType DomainWarpType { get { return (EFNDomainWarpType)this[nameof(DomainWarpType)].GetValue<int>(); } set { this[nameof(DomainWarpType)].SetValue<int>((int)value); } }
        public float Amplitude { get { return this[nameof(Amplitude)].GetValue<float>(); } set { this[nameof(Amplitude)].SetValue<float>(value); } }
    }
    public class CSGSDFModulatedInstanceProperties : Object
    {
        public CSGSDFModulatedInstanceProperties(nint addr) : base(addr) { }
        public Object SDF { get { return this[nameof(SDF)]; } set { this[nameof(SDF)] = value; } }
        public Object ModulateSDF { get { return this[nameof(ModulateSDF)]; } set { this[nameof(ModulateSDF)] = value; } }
        public EPreviewCellSize CellSize { get { return (EPreviewCellSize)this[nameof(CellSize)].GetValue<int>(); } set { this[nameof(CellSize)].SetValue<int>((int)value); } }
        public BakeSettings SDFSettings { get { return this[nameof(SDFSettings)].As<BakeSettings>(); } set { this["SDFSettings"] = value; } }
        public BakeSettings ModulateSettings { get { return this[nameof(ModulateSettings)].As<BakeSettings>(); } set { this["ModulateSettings"] = value; } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
        public ESDFModulateMode ModulateMode { get { return (ESDFModulateMode)this[nameof(ModulateMode)].GetValue<int>(); } set { this[nameof(ModulateMode)].SetValue<int>((int)value); } }
        public Array<SDFModulateLayer> ModulateLayers { get { return new Array<SDFModulateLayer>(this[nameof(ModulateLayers)].Address); } }
    }
    public class SDFModulateLayer : Object
    {
        public SDFModulateLayer(nint addr) : base(addr) { }
        public float ModulateDistance { get { return this[nameof(ModulateDistance)].GetValue<float>(); } set { this[nameof(ModulateDistance)].SetValue<float>(value); } }
        public float SDFOffset { get { return this[nameof(SDFOffset)].GetValue<float>(); } set { this[nameof(SDFOffset)].SetValue<float>(value); } }
    }
    public class CSGSDFInstanceProperties : Object
    {
        public CSGSDFInstanceProperties(nint addr) : base(addr) { }
        public Object SDF { get { return this[nameof(SDF)]; } set { this[nameof(SDF)] = value; } }
        public EPreviewCellSize CellSize { get { return (EPreviewCellSize)this[nameof(CellSize)].GetValue<int>(); } set { this[nameof(CellSize)].SetValue<int>((int)value); } }
        public BakeSettings Settings { get { return this[nameof(Settings)].As<BakeSettings>(); } set { this["Settings"] = value; } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
    }
    public class VoronoiProperties : Object
    {
        public VoronoiProperties(nint addr) : base(addr) { }
        public Vector HalfSize { get { return this[nameof(HalfSize)].As<Vector>(); } set { this["HalfSize"] = value; } }
        public int NumPoints { get { return this[nameof(NumPoints)].GetValue<int>(); } set { this[nameof(NumPoints)].SetValue<int>(value); } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
        public float Distance { get { return this[nameof(Distance)].GetValue<float>(); } set { this[nameof(Distance)].SetValue<float>(value); } }
        public bool Inverted { get { return this[nameof(Inverted)].Flag; } set { this[nameof(Inverted)].Flag = value; } }
    }
    public class CSGSTLProperties : Object
    {
        public CSGSTLProperties(nint addr) : base(addr) { }
        public StaticMeshCarver Mesh { get { return this[nameof(Mesh)].As<StaticMeshCarver>(); } set { this["Mesh"] = value; } }
    }
    public class DeepCSGFloatTree : Object
    {
        public DeepCSGFloatTree(nint addr) : base(addr) { }
        public DeepCSGNode Root { get { return this[nameof(Root)].As<DeepCSGNode>(); } set { this["Root"] = value; } }
        public Array<DeepCSGFloatPlane> planes { get { return new Array<DeepCSGFloatPlane>(this[nameof(planes)].Address); } }
    }
    public class DeepCSGFloatPlane : Object
    {
        public DeepCSGFloatPlane(nint addr) : base(addr) { }
        public Vector4 Plane { get { return this[nameof(Plane)].As<Vector4>(); } set { this["Plane"] = value; } }
        public DeepCSGNode Top { get { return this[nameof(Top)].As<DeepCSGNode>(); } set { this["Top"] = value; } }
        public DeepCSGNode Bottom { get { return this[nameof(Bottom)].As<DeepCSGNode>(); } set { this["Bottom"] = value; } }
    }
    public class ChunkOffset : Object
    {
        public ChunkOffset(nint addr) : base(addr) { }
        public short X { get { return this[nameof(X)].GetValue<short>(); } set { this[nameof(X)].SetValue<short>(value); } }
        public short Y { get { return this[nameof(Y)].GetValue<short>(); } set { this[nameof(Y)].SetValue<short>(value); } }
        public short Z { get { return this[nameof(Z)].GetValue<short>(); } set { this[nameof(Z)].SetValue<short>(value); } }
    }
    public class ChunkId : Object
    {
        public ChunkId(nint addr) : base(addr) { }
        public short X { get { return this[nameof(X)].GetValue<short>(); } set { this[nameof(X)].SetValue<short>(value); } }
        public short Y { get { return this[nameof(Y)].GetValue<short>(); } set { this[nameof(Y)].SetValue<short>(value); } }
        public short Z { get { return this[nameof(Z)].GetValue<short>(); } set { this[nameof(Z)].SetValue<short>(value); } }
    }
    public class CellId : Object
    {
        public CellId(nint addr) : base(addr) { }
        public short X { get { return this[nameof(X)].GetValue<short>(); } set { this[nameof(X)].SetValue<short>(value); } }
        public short Y { get { return this[nameof(Y)].GetValue<short>(); } set { this[nameof(Y)].SetValue<short>(value); } }
        public short Z { get { return this[nameof(Z)].GetValue<short>(); } set { this[nameof(Z)].SetValue<short>(value); } }
    }
    public class DeepCSGTree : Object
    {
        public DeepCSGTree(nint addr) : base(addr) { }
    }
    public class DeepCSGTreeOperations : Object
    {
        public DeepCSGTreeOperations(nint addr) : base(addr) { }
    }
    public class DeepCSGUtils : Object
    {
        public DeepCSGUtils(nint addr) : base(addr) { }
    }
    public class LinearCellId : Object
    {
        public LinearCellId(nint addr) : base(addr) { }
        public ushort X { get { return this[nameof(X)].GetValue<ushort>(); } set { this[nameof(X)].SetValue<ushort>(value); } }
        public ushort Y { get { return this[nameof(Y)].GetValue<ushort>(); } set { this[nameof(Y)].SetValue<ushort>(value); } }
        public ushort Z { get { return this[nameof(Z)].GetValue<ushort>(); } set { this[nameof(Z)].SetValue<ushort>(value); } }
    }
    public class EncodedChunkCellId : Object
    {
        public EncodedChunkCellId(nint addr) : base(addr) { }
        public EncodedChunkId ChunkId { get { return this[nameof(ChunkId)].As<EncodedChunkId>(); } set { this["ChunkId"] = value; } }
        public ushort cellOffset { get { return this[nameof(cellOffset)].GetValue<ushort>(); } set { this[nameof(cellOffset)].SetValue<ushort>(value); } }
    }
    public class EncodedChunkId : Object
    {
        public EncodedChunkId(nint addr) : base(addr) { }
        public uint ID { get { return this[nameof(ID)].GetValue<uint>(); } set { this[nameof(ID)].SetValue<uint>(value); } }
    }
    public class ChunckIDAndOffsetBox : Object
    {
        public ChunckIDAndOffsetBox(nint addr) : base(addr) { }
        public ChunkId ChunkId { get { return this[nameof(ChunkId)].As<ChunkId>(); } set { this["ChunkId"] = value; } }
        public ChunkOffset minOffset { get { return this[nameof(minOffset)].As<ChunkOffset>(); } set { this["minOffset"] = value; } }
        public ChunkOffset maxOffset { get { return this[nameof(maxOffset)].As<ChunkOffset>(); } set { this["maxOffset"] = value; } }
    }
    public class ChunckIDAndOffset : Object
    {
        public ChunckIDAndOffset(nint addr) : base(addr) { }
        public ChunkId ChunkId { get { return this[nameof(ChunkId)].As<ChunkId>(); } set { this["ChunkId"] = value; } }
        public ChunkOffset Offset { get { return this[nameof(Offset)].As<ChunkOffset>(); } set { this["Offset"] = value; } }
    }
    public class CellBox : Object
    {
        public CellBox(nint addr) : base(addr) { }
        public CellId Min { get { return this[nameof(Min)].As<CellId>(); } set { this["Min"] = value; } }
        public CellId Max { get { return this[nameof(Max)].As<CellId>(); } set { this["Max"] = value; } }
    }
    public class FastNoiseProperties : Object
    {
        public FastNoiseProperties(nint addr) : base(addr) { }
        public float Frequency { get { return this[nameof(Frequency)].GetValue<float>(); } set { this[nameof(Frequency)].SetValue<float>(value); } }
        public EFNNoiseType NoiseType { get { return (EFNNoiseType)this[nameof(NoiseType)].GetValue<int>(); } set { this[nameof(NoiseType)].SetValue<int>((int)value); } }
        public EFNRotationType3D RotationType3d { get { return (EFNRotationType3D)this[nameof(RotationType3d)].GetValue<int>(); } set { this[nameof(RotationType3d)].SetValue<int>((int)value); } }
        public EFNFractalType FractalType { get { return (EFNFractalType)this[nameof(FractalType)].GetValue<int>(); } set { this[nameof(FractalType)].SetValue<int>((int)value); } }
        public int Octaves { get { return this[nameof(Octaves)].GetValue<int>(); } set { this[nameof(Octaves)].SetValue<int>(value); } }
        public float Lacunarity { get { return this[nameof(Lacunarity)].GetValue<float>(); } set { this[nameof(Lacunarity)].SetValue<float>(value); } }
        public float Gain { get { return this[nameof(Gain)].GetValue<float>(); } set { this[nameof(Gain)].SetValue<float>(value); } }
        public float WeightedStrength { get { return this[nameof(WeightedStrength)].GetValue<float>(); } set { this[nameof(WeightedStrength)].SetValue<float>(value); } }
        public float PingPongStrength { get { return this[nameof(PingPongStrength)].GetValue<float>(); } set { this[nameof(PingPongStrength)].SetValue<float>(value); } }
        public EFNCellularDistanceFunc CellularDistanceFunc { get { return (EFNCellularDistanceFunc)this[nameof(CellularDistanceFunc)].GetValue<int>(); } set { this[nameof(CellularDistanceFunc)].SetValue<int>((int)value); } }
        public EFNCellularReturnType CellularReturnYype { get { return (EFNCellularReturnType)this[nameof(CellularReturnYype)].GetValue<int>(); } set { this[nameof(CellularReturnYype)].SetValue<int>((int)value); } }
        public float CellularJitterMod { get { return this[nameof(CellularJitterMod)].GetValue<float>(); } set { this[nameof(CellularJitterMod)].SetValue<float>(value); } }
        public EFNDomainWarpType DomainWarpType { get { return (EFNDomainWarpType)this[nameof(DomainWarpType)].GetValue<int>(); } set { this[nameof(DomainWarpType)].SetValue<int>((int)value); } }
        public float WarpAmplitude { get { return this[nameof(WarpAmplitude)].GetValue<float>(); } set { this[nameof(WarpAmplitude)].SetValue<float>(value); } }
    }
    public class SDFHeightMaproperties : Object
    {
        public SDFHeightMaproperties(nint addr) : base(addr) { }
        public Vector Scale { get { return this[nameof(Scale)].As<Vector>(); } set { this["Scale"] = value; } }
    }
    public class HMMinMaxLevel : Object
    {
        public HMMinMaxLevel(nint addr) : base(addr) { }
        public Array<float> Entries { get { return new Array<float>(this[nameof(Entries)].Address); } }
    }
    public class SDFOnionProperties : Object
    {
        public SDFOnionProperties(nint addr) : base(addr) { }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
    }
    public class SDFSmoothingProperties : Object
    {
        public SDFSmoothingProperties(nint addr) : base(addr) { }
        public float SmoothingDist { get { return this[nameof(SmoothingDist)].GetValue<float>(); } set { this[nameof(SmoothingDist)].SetValue<float>(value); } }
        public bool SmoothingEnabled { get { return this[nameof(SmoothingEnabled)].Flag; } set { this[nameof(SmoothingEnabled)].Flag = value; } }
    }
    public class SDFModifierProperties : Object
    {
        public SDFModifierProperties(nint addr) : base(addr) { }
        public float Offset { get { return this[nameof(Offset)].GetValue<float>(); } set { this[nameof(Offset)].SetValue<float>(value); } }
        public FastNoiseProperties Noise { get { return this[nameof(Noise)].As<FastNoiseProperties>(); } set { this["Noise"] = value; } }
        public float NoiseAmplitude { get { return this[nameof(NoiseAmplitude)].GetValue<float>(); } set { this[nameof(NoiseAmplitude)].SetValue<float>(value); } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
    }
    public class SDFBaseProperties : Object
    {
        public SDFBaseProperties(nint addr) : base(addr) { }
        public bool Enabled { get { return this[nameof(Enabled)].Flag; } set { this[nameof(Enabled)].Flag = value; } }
    }
    public class SDFRandomDisableProperties : Object
    {
        public SDFRandomDisableProperties(nint addr) : base(addr) { }
        public float DisableProbability { get { return this[nameof(DisableProbability)].GetValue<float>(); } set { this[nameof(DisableProbability)].SetValue<float>(value); } }
    }
    public class SDFRandomizeTransformProperties : Object
    {
        public SDFRandomizeTransformProperties(nint addr) : base(addr) { }
        public Box Translation { get { return this[nameof(Translation)].As<Box>(); } set { this["Translation"] = value; } }
        public float RotationMinZ { get { return this[nameof(RotationMinZ)].GetValue<float>(); } set { this[nameof(RotationMinZ)].SetValue<float>(value); } }
        public float RotationMaxZ { get { return this[nameof(RotationMaxZ)].GetValue<float>(); } set { this[nameof(RotationMaxZ)].SetValue<float>(value); } }
        public float RotationMinY { get { return this[nameof(RotationMinY)].GetValue<float>(); } set { this[nameof(RotationMinY)].SetValue<float>(value); } }
        public float RotationMaxY { get { return this[nameof(RotationMaxY)].GetValue<float>(); } set { this[nameof(RotationMaxY)].SetValue<float>(value); } }
        public float RotationMinX { get { return this[nameof(RotationMinX)].GetValue<float>(); } set { this[nameof(RotationMinX)].SetValue<float>(value); } }
        public float RotationMaxX { get { return this[nameof(RotationMaxX)].GetValue<float>(); } set { this[nameof(RotationMaxX)].SetValue<float>(value); } }
        public Vector ScaleMin { get { return this[nameof(ScaleMin)].As<Vector>(); } set { this["ScaleMin"] = value; } }
        public Vector ScaleMax { get { return this[nameof(ScaleMax)].As<Vector>(); } set { this["ScaleMax"] = value; } }
        public bool ScaleAxesIndependent { get { return this[nameof(ScaleAxesIndependent)].Flag; } set { this[nameof(ScaleAxesIndependent)].Flag = value; } }
        public bool DisableRandomize { get { return this[nameof(DisableRandomize)].Flag; } set { this[nameof(DisableRandomize)].Flag = value; } }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
    }
    public class SDFTorusProperties : Object
    {
        public SDFTorusProperties(nint addr) : base(addr) { }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
        public float TubeRadius { get { return this[nameof(TubeRadius)].GetValue<float>(); } set { this[nameof(TubeRadius)].SetValue<float>(value); } }
        public Object SizeOverrideName { get { return this[nameof(SizeOverrideName)]; } set { this[nameof(SizeOverrideName)] = value; } }
    }
    public class SDFCapsuleProperties : Object
    {
        public SDFCapsuleProperties(nint addr) : base(addr) { }
        public float HalfLength { get { return this[nameof(HalfLength)].GetValue<float>(); } set { this[nameof(HalfLength)].SetValue<float>(value); } }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
    }
    public class SDFCylinderProperties : Object
    {
        public SDFCylinderProperties(nint addr) : base(addr) { }
        public float HalfLength { get { return this[nameof(HalfLength)].GetValue<float>(); } set { this[nameof(HalfLength)].SetValue<float>(value); } }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
    }
    public class SDFBoxProperties : Object
    {
        public SDFBoxProperties(nint addr) : base(addr) { }
        public Vector HalfSize { get { return this[nameof(HalfSize)].As<Vector>(); } set { this["HalfSize"] = value; } }
    }
    public class SDFSphereProperties : Object
    {
        public SDFSphereProperties(nint addr) : base(addr) { }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
        public Object RadiusOverrideName { get { return this[nameof(RadiusOverrideName)]; } set { this[nameof(RadiusOverrideName)] = value; } }
    }
}
