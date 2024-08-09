using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.ProceduralMeshComponentSDK
{
    public class KismetProceduralMeshLibrary : BlueprintFunctionLibrary
    {
        public KismetProceduralMeshLibrary(nint addr) : base(addr) { }
        public void SliceProceduralMesh(ProceduralMeshComponent InProcMesh, Vector PlanePosition, Vector PlaneNormal, bool bCreateOtherHalf, ProceduralMeshComponent OutOtherHalfProcMesh, EProcMeshSliceCapOption CapOption, MaterialInterface CapMaterial) { Invoke(nameof(SliceProceduralMesh), InProcMesh, PlanePosition, PlaneNormal, bCreateOtherHalf, OutOtherHalfProcMesh, CapOption, CapMaterial); }
        public void GetSectionFromStaticMesh(StaticMesh InMesh, int LODIndex, int SectionIndex, UArray<Vector> Vertices, UArray<int> Triangles, UArray<Vector> Normals, UArray<Vector2D> UVs, UArray<ProcMeshTangent> Tangents) { Invoke(nameof(GetSectionFromStaticMesh), InMesh, LODIndex, SectionIndex, Vertices, Triangles, Normals, UVs, Tangents); }
        public void GetSectionFromProceduralMesh(ProceduralMeshComponent InProcMesh, int SectionIndex, UArray<Vector> Vertices, UArray<int> Triangles, UArray<Vector> Normals, UArray<Vector2D> UVs, UArray<ProcMeshTangent> Tangents) { Invoke(nameof(GetSectionFromProceduralMesh), InProcMesh, SectionIndex, Vertices, Triangles, Normals, UVs, Tangents); }
        public void GenerateBoxMesh(Vector BoxRadius, UArray<Vector> Vertices, UArray<int> Triangles, UArray<Vector> Normals, UArray<Vector2D> UVs, UArray<ProcMeshTangent> Tangents) { Invoke(nameof(GenerateBoxMesh), BoxRadius, Vertices, Triangles, Normals, UVs, Tangents); }
        public void CreateGridMeshWelded(int NumX, int NumY, UArray<int> Triangles, UArray<Vector> Vertices, UArray<Vector2D> UVs, float GridSpacing) { Invoke(nameof(CreateGridMeshWelded), NumX, NumY, Triangles, Vertices, UVs, GridSpacing); }
        public void CreateGridMeshTriangles(int NumX, int NumY, bool bWinding, UArray<int> Triangles) { Invoke(nameof(CreateGridMeshTriangles), NumX, NumY, bWinding, Triangles); }
        public void CreateGridMeshSplit(int NumX, int NumY, UArray<int> Triangles, UArray<Vector> Vertices, UArray<Vector2D> UVs, UArray<Vector2D> UV1s, float GridSpacing) { Invoke(nameof(CreateGridMeshSplit), NumX, NumY, Triangles, Vertices, UVs, UV1s, GridSpacing); }
        public void CopyProceduralMeshFromStaticMeshComponent(StaticMeshComponent StaticMeshComponent, int LODIndex, ProceduralMeshComponent ProcMeshComponent, bool bCreateCollision) { Invoke(nameof(CopyProceduralMeshFromStaticMeshComponent), StaticMeshComponent, LODIndex, ProcMeshComponent, bCreateCollision); }
        public void ConvertQuadToTriangles(UArray<int> Triangles, int Vert0, int Vert1, int Vert2, int Vert3) { Invoke(nameof(ConvertQuadToTriangles), Triangles, Vert0, Vert1, Vert2, Vert3); }
        public void CalculateTangentsForMesh(UArray<Vector> Vertices, UArray<int> Triangles, UArray<Vector2D> UVs, UArray<Vector> Normals, UArray<ProcMeshTangent> Tangents) { Invoke(nameof(CalculateTangentsForMesh), Vertices, Triangles, UVs, Normals, Tangents); }
    }
    public class ProceduralMeshComponent : MeshComponent
    {
        public ProceduralMeshComponent(nint addr) : base(addr) { }
        public bool bUseComplexAsSimpleCollision { get { return this[nameof(bUseComplexAsSimpleCollision)].Flag; } set { this[nameof(bUseComplexAsSimpleCollision)].Flag = value; } }
        public bool bUseAsyncCooking { get { return this[nameof(bUseAsyncCooking)].Flag; } set { this[nameof(bUseAsyncCooking)].Flag = value; } }
        public BodySetup ProcMeshBodySetup { get { return this[nameof(ProcMeshBodySetup)].As<BodySetup>(); } set { this["ProcMeshBodySetup"] = value; } }
        public UArray<ProcMeshSection> ProcMeshSections { get { return new UArray<ProcMeshSection>(this[nameof(ProcMeshSections)].Address); } }
        public UArray<KConvexElem> CollisionConvexElems { get { return new UArray<KConvexElem>(this[nameof(CollisionConvexElems)].Address); } }
        public BoxSphereBounds LocalBounds { get { return this[nameof(LocalBounds)].As<BoxSphereBounds>(); } set { this["LocalBounds"] = value; } }
        public UArray<BodySetup> AsyncBodySetupQueue { get { return new UArray<BodySetup>(this[nameof(AsyncBodySetupQueue)].Address); } }
        public void UpdateMeshSection_LinearColor(int SectionIndex, UArray<Vector> Vertices, UArray<Vector> Normals, UArray<Vector2D> UV0, UArray<Vector2D> UV1, UArray<Vector2D> UV2, UArray<Vector2D> UV3, UArray<LinearColor> VertexColors, UArray<ProcMeshTangent> Tangents) { Invoke(nameof(UpdateMeshSection_LinearColor), SectionIndex, Vertices, Normals, UV0, UV1, UV2, UV3, VertexColors, Tangents); }
        public void UpdateMeshSection(int SectionIndex, UArray<Vector> Vertices, UArray<Vector> Normals, UArray<Vector2D> UV0, UArray<Color> VertexColors, UArray<ProcMeshTangent> Tangents) { Invoke(nameof(UpdateMeshSection), SectionIndex, Vertices, Normals, UV0, VertexColors, Tangents); }
        public void SetMeshSectionVisible(int SectionIndex, bool bNewVisibility) { Invoke(nameof(SetMeshSectionVisible), SectionIndex, bNewVisibility); }
        public bool IsMeshSectionVisible(int SectionIndex) { return Invoke<bool>(nameof(IsMeshSectionVisible), SectionIndex); }
        public int GetNumSections() { return Invoke<int>(nameof(GetNumSections)); }
        public void CreateMeshSection_LinearColor(int SectionIndex, UArray<Vector> Vertices, UArray<int> Triangles, UArray<Vector> Normals, UArray<Vector2D> UV0, UArray<Vector2D> UV1, UArray<Vector2D> UV2, UArray<Vector2D> UV3, UArray<LinearColor> VertexColors, UArray<ProcMeshTangent> Tangents, bool bCreateCollision) { Invoke(nameof(CreateMeshSection_LinearColor), SectionIndex, Vertices, Triangles, Normals, UV0, UV1, UV2, UV3, VertexColors, Tangents, bCreateCollision); }
        public void CreateMeshSection(int SectionIndex, UArray<Vector> Vertices, UArray<int> Triangles, UArray<Vector> Normals, UArray<Vector2D> UV0, UArray<Color> VertexColors, UArray<ProcMeshTangent> Tangents, bool bCreateCollision) { Invoke(nameof(CreateMeshSection), SectionIndex, Vertices, Triangles, Normals, UV0, VertexColors, Tangents, bCreateCollision); }
        public void ClearMeshSection(int SectionIndex) { Invoke(nameof(ClearMeshSection), SectionIndex); }
        public void ClearCollisionConvexMeshes() { Invoke(nameof(ClearCollisionConvexMeshes)); }
        public void ClearAllMeshSections() { Invoke(nameof(ClearAllMeshSections)); }
        public void AddCollisionConvexMesh(UArray<Vector> ConvexVerts) { Invoke(nameof(AddCollisionConvexMesh), ConvexVerts); }
    }
    public enum EProcMeshSliceCapOption : int
    {
        NoCap = 0,
        CreateNewSectionForCap = 1,
        UseLastSectionForCap = 2,
        EProcMeshSliceCapOption_MAX = 3,
    }
    public class ProcMeshSection : Object
    {
        public ProcMeshSection(nint addr) : base(addr) { }
        public UArray<ProcMeshVertex> ProcVertexBuffer { get { return new UArray<ProcMeshVertex>(this[nameof(ProcVertexBuffer)].Address); } }
        public UArray<uint> ProcIndexBuffer { get { return new UArray<uint>(this[nameof(ProcIndexBuffer)].Address); } }
        public Box SectionLocalBox { get { return this[nameof(SectionLocalBox)].As<Box>(); } set { this["SectionLocalBox"] = value; } }
        public bool bEnableCollision { get { return this[nameof(bEnableCollision)].Flag; } set { this[nameof(bEnableCollision)].Flag = value; } }
        public bool bSectionVisible { get { return this[nameof(bSectionVisible)].Flag; } set { this[nameof(bSectionVisible)].Flag = value; } }
    }
    public class ProcMeshVertex : Object
    {
        public ProcMeshVertex(nint addr) : base(addr) { }
        public Vector Position { get { return this[nameof(Position)].As<Vector>(); } set { this["Position"] = value; } }
        public Vector Normal { get { return this[nameof(Normal)].As<Vector>(); } set { this["Normal"] = value; } }
        public ProcMeshTangent Tangent { get { return this[nameof(Tangent)].As<ProcMeshTangent>(); } set { this["Tangent"] = value; } }
        public Color Color { get { return this[nameof(Color)].As<Color>(); } set { this["Color"] = value; } }
        public Vector2D UV0 { get { return this[nameof(UV0)].As<Vector2D>(); } set { this["UV0"] = value; } }
        public Vector2D UV1 { get { return this[nameof(UV1)].As<Vector2D>(); } set { this["UV1"] = value; } }
        public Vector2D UV2 { get { return this[nameof(UV2)].As<Vector2D>(); } set { this["UV2"] = value; } }
        public Vector2D UV3 { get { return this[nameof(UV3)].As<Vector2D>(); } set { this["UV3"] = value; } }
    }
    public class ProcMeshTangent : Object
    {
        public ProcMeshTangent(nint addr) : base(addr) { }
        public Vector TangentX { get { return this[nameof(TangentX)].As<Vector>(); } set { this["TangentX"] = value; } }
        public bool bFlipTangentY { get { return this[nameof(bFlipTangentY)].Flag; } set { this[nameof(bFlipTangentY)].Flag = value; } }
    }
}
