using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.GeometryCollectionEngineSDK;
using SDK.Script.MeshDescriptionSDK;
using SDK.Script.CoreUObjectSDK;
using SDK.Script.EngineSDK;
namespace SDK.Script.EditableMeshSDK
{
    public class EditableMeshAdapter : Object
    {
        public EditableMeshAdapter(nint addr) : base(addr) { }
    }
    public class EditableGeometryCollectionAdapter : EditableMeshAdapter
    {
        public EditableGeometryCollectionAdapter(nint addr) : base(addr) { }
        public GeometryCollection GeometryCollection { get { return this[nameof(GeometryCollection)].As<GeometryCollection>(); } set { this["GeometryCollection"] = value; } }
        public GeometryCollection OriginalGeometryCollection { get { return this[nameof(OriginalGeometryCollection)].As<GeometryCollection>(); } set { this["OriginalGeometryCollection"] = value; } }
        public int GeometryCollectionLODIndex { get { return this[nameof(GeometryCollectionLODIndex)].GetValue<int>(); } set { this[nameof(GeometryCollectionLODIndex)].SetValue<int>(value); } }
    }
    public class EditableMesh : Object
    {
        public EditableMesh(nint addr) : base(addr) { }
        public UArray<EditableMeshAdapter> Adapters { get { return new UArray<EditableMeshAdapter>(this[nameof(Adapters)].Address); } }
        public int TextureCoordinateCount { get { return this[nameof(TextureCoordinateCount)].GetValue<int>(); } set { this[nameof(TextureCoordinateCount)].SetValue<int>(value); } }
        public int PendingCompactCounter { get { return this[nameof(PendingCompactCounter)].GetValue<int>(); } set { this[nameof(PendingCompactCounter)].SetValue<int>(value); } }
        public int SubdivisionCount { get { return this[nameof(SubdivisionCount)].GetValue<int>(); } set { this[nameof(SubdivisionCount)].SetValue<int>(value); } }
        public void WeldVertices(UArray<VertexID> VertexIDs, VertexID OutNewVertexID) { Invoke(nameof(WeldVertices), VertexIDs, OutNewVertexID); }
        public void TryToRemoveVertex(VertexID VertexID, bool bOutWasVertexRemoved, EdgeID OutNewEdgeID) { Invoke(nameof(TryToRemoveVertex), VertexID, bOutWasVertexRemoved, OutNewEdgeID); }
        public void TryToRemovePolygonEdge(EdgeID EdgeID, bool bOutWasEdgeRemoved, PolygonID OutNewPolygonID) { Invoke(nameof(TryToRemovePolygonEdge), EdgeID, bOutWasEdgeRemoved, OutNewPolygonID); }
        public void TriangulatePolygons(UArray<PolygonID> PolygonIDs, UArray<PolygonID> OutNewTrianglePolygons) { Invoke(nameof(TriangulatePolygons), PolygonIDs, OutNewTrianglePolygons); }
        public void TessellatePolygons(UArray<PolygonID> PolygonIDs, ETriangleTessellationMode TriangleTessellationMode, UArray<PolygonID> OutNewPolygonIDs) { Invoke(nameof(TessellatePolygons), PolygonIDs, TriangleTessellationMode, OutNewPolygonIDs); }
        public void StartModification(EMeshModificationType MeshModificationType, EMeshTopologyChange MeshTopologyChange) { Invoke(nameof(StartModification), MeshModificationType, MeshTopologyChange); }
        public void SplitPolygons(UArray<PolygonToSplit> PolygonsToSplit, UArray<EdgeID> OutNewEdgeIDs) { Invoke(nameof(SplitPolygons), PolygonsToSplit, OutNewEdgeIDs); }
        public void SplitPolygonalMesh(Plane InPlane, UArray<PolygonID> PolygonIDs1, UArray<PolygonID> PolygonIDs2, UArray<EdgeID> BoundaryIDs) { Invoke(nameof(SplitPolygonalMesh), InPlane, PolygonIDs1, PolygonIDs2, BoundaryIDs); }
        public void SplitEdge(EdgeID EdgeID, UArray<float> Splits, UArray<VertexID> OutNewVertexIDs) { Invoke(nameof(SplitEdge), EdgeID, Splits, OutNewVertexIDs); }
        public void SetVerticesCornerSharpness(UArray<VertexID> VertexIDs, UArray<float> VerticesNewCornerSharpness) { Invoke(nameof(SetVerticesCornerSharpness), VertexIDs, VerticesNewCornerSharpness); }
        public void SetVerticesAttributes(UArray<AttributesForVertex> AttributesForVertices) { Invoke(nameof(SetVerticesAttributes), AttributesForVertices); }
        public void SetVertexInstancesAttributes(UArray<AttributesForVertexInstance> AttributesForVertexInstances) { Invoke(nameof(SetVertexInstancesAttributes), AttributesForVertexInstances); }
        public void SetTextureCoordinateCount(int NumTexCoords) { Invoke(nameof(SetTextureCoordinateCount), NumTexCoords); }
        public void SetSubdivisionCount(int NewSubdivisionCount) { Invoke(nameof(SetSubdivisionCount), NewSubdivisionCount); }
        public void SetPolygonsVertexAttributes(UArray<VertexAttributesForPolygon> VertexAttributesForPolygons) { Invoke(nameof(SetPolygonsVertexAttributes), VertexAttributesForPolygons); }
        public void SetEdgesHardnessAutomatically(UArray<EdgeID> EdgeIDs, float MaxDotProductForSoftEdge) { Invoke(nameof(SetEdgesHardnessAutomatically), EdgeIDs, MaxDotProductForSoftEdge); }
        public void SetEdgesHardness(UArray<EdgeID> EdgeIDs, UArray<bool> EdgesNewIsHard) { Invoke(nameof(SetEdgesHardness), EdgeIDs, EdgesNewIsHard); }
        public void SetEdgesCreaseSharpness(UArray<EdgeID> EdgeIDs, UArray<float> EdgesNewCreaseSharpness) { Invoke(nameof(SetEdgesCreaseSharpness), EdgeIDs, EdgesNewCreaseSharpness); }
        public void SetEdgesAttributes(UArray<AttributesForEdge> AttributesForEdges) { Invoke(nameof(SetEdgesAttributes), AttributesForEdges); }
        public void SetAllowUndo(bool bInAllowUndo) { Invoke(nameof(SetAllowUndo), bInAllowUndo); }
        public void SetAllowSpatialDatabase(bool bInAllowSpatialDatabase) { Invoke(nameof(SetAllowSpatialDatabase), bInAllowSpatialDatabase); }
        public void SetAllowCompact(bool bInAllowCompact) { Invoke(nameof(SetAllowCompact), bInAllowCompact); }
        public void SearchSpatialDatabaseForPolygonsPotentiallyIntersectingPlane(Plane InPlane, UArray<PolygonID> OutPolygons) { Invoke(nameof(SearchSpatialDatabaseForPolygonsPotentiallyIntersectingPlane), InPlane, OutPolygons); }
        public void SearchSpatialDatabaseForPolygonsPotentiallyIntersectingLineSegment(Vector LineSegmentStart, Vector LineSegmentEnd, UArray<PolygonID> OutPolygons) { Invoke(nameof(SearchSpatialDatabaseForPolygonsPotentiallyIntersectingLineSegment), LineSegmentStart, LineSegmentEnd, OutPolygons); }
        public void SearchSpatialDatabaseForPolygonsInVolume(UArray<Plane> planes, UArray<PolygonID> OutPolygons) { Invoke(nameof(SearchSpatialDatabaseForPolygonsInVolume), planes, OutPolygons); }
        public EditableMesh RevertInstance() { return Invoke<EditableMesh>(nameof(RevertInstance)); }
        public void Revert() { Invoke(nameof(Revert)); }
        public void RebuildRenderMesh() { Invoke(nameof(RebuildRenderMesh)); }
        public void QuadrangulateMesh(UArray<PolygonID> OutNewPolygonIDs) { Invoke(nameof(QuadrangulateMesh), OutNewPolygonIDs); }
        public void PropagateInstanceChanges() { Invoke(nameof(PropagateInstanceChanges)); }
        public void MoveVertices(UArray<VertexToMove> VerticesToMove) { Invoke(nameof(MoveVertices), VerticesToMove); }
        public VertexID MakeVertexID(int VertexIndex) { return Invoke<VertexID>(nameof(MakeVertexID), VertexIndex); }
        public PolygonID MakePolygonID(int PolygonIndex) { return Invoke<PolygonID>(nameof(MakePolygonID), PolygonIndex); }
        public PolygonGroupID MakePolygonGroupID(int PolygonGroupIndex) { return Invoke<PolygonGroupID>(nameof(MakePolygonGroupID), PolygonGroupIndex); }
        public EdgeID MakeEdgeID(int EdgeIndex) { return Invoke<EdgeID>(nameof(MakeEdgeID), EdgeIndex); }
        public bool IsValidVertex(VertexID VertexID) { return Invoke<bool>(nameof(IsValidVertex), VertexID); }
        public bool IsValidPolygonGroup(PolygonGroupID PolygonGroupID) { return Invoke<bool>(nameof(IsValidPolygonGroup), PolygonGroupID); }
        public bool IsValidPolygon(PolygonID PolygonID) { return Invoke<bool>(nameof(IsValidPolygon), PolygonID); }
        public bool IsValidEdge(EdgeID EdgeID) { return Invoke<bool>(nameof(IsValidEdge), EdgeID); }
        public bool IsUndoAllowed() { return Invoke<bool>(nameof(IsUndoAllowed)); }
        public bool IsSpatialDatabaseAllowed() { return Invoke<bool>(nameof(IsSpatialDatabaseAllowed)); }
        public bool IsPreviewingSubdivisions() { return Invoke<bool>(nameof(IsPreviewingSubdivisions)); }
        public bool IsOrphanedVertex(VertexID VertexID) { return Invoke<bool>(nameof(IsOrphanedVertex), VertexID); }
        public bool IsCompactAllowed() { return Invoke<bool>(nameof(IsCompactAllowed)); }
        public bool IsCommittedAsInstance() { return Invoke<bool>(nameof(IsCommittedAsInstance)); }
        public bool IsCommitted() { return Invoke<bool>(nameof(IsCommitted)); }
        public bool IsBeingModified() { return Invoke<bool>(nameof(IsBeingModified)); }
        public VertexID InvalidVertexID() { return Invoke<VertexID>(nameof(InvalidVertexID)); }
        public PolygonID InvalidPolygonID() { return Invoke<PolygonID>(nameof(InvalidPolygonID)); }
        public PolygonGroupID InvalidPolygonGroupID() { return Invoke<PolygonGroupID>(nameof(InvalidPolygonGroupID)); }
        public EdgeID InvalidEdgeID() { return Invoke<EdgeID>(nameof(InvalidEdgeID)); }
        public void InsetPolygons(UArray<PolygonID> PolygonIDs, float InsetFixedDistance, float InsetProgressTowardCenter, EInsetPolygonsMode Mode, UArray<PolygonID> OutNewCenterPolygonIDs, UArray<PolygonID> OutNewSidePolygonIDs) { Invoke(nameof(InsetPolygons), PolygonIDs, InsetFixedDistance, InsetProgressTowardCenter, Mode, OutNewCenterPolygonIDs, OutNewSidePolygonIDs); }
        public void InsertEdgeLoop(EdgeID EdgeID, UArray<float> Splits, UArray<EdgeID> OutNewEdgeIDs) { Invoke(nameof(InsertEdgeLoop), EdgeID, Splits, OutNewEdgeIDs); }
        public void InitializeAdapters() { Invoke(nameof(InitializeAdapters)); }
        public EdgeID GetVertexPairEdge(VertexID VertexID, VertexID NextVertexID, bool bOutEdgeWindingIsReversed) { return Invoke<EdgeID>(nameof(GetVertexPairEdge), VertexID, NextVertexID, bOutEdgeWindingIsReversed); }
        public VertexID GetVertexInstanceVertex(VertexInstanceID VertexInstanceID) { return Invoke<VertexID>(nameof(GetVertexInstanceVertex), VertexInstanceID); }
        public int GetVertexInstanceCount() { return Invoke<int>(nameof(GetVertexInstanceCount)); }
        public void GetVertexInstanceConnectedPolygons(VertexInstanceID VertexInstanceID, UArray<PolygonID> OutConnectedPolygonIDs) { Invoke(nameof(GetVertexInstanceConnectedPolygons), VertexInstanceID, OutConnectedPolygonIDs); }
        public int GetVertexInstanceConnectedPolygonCount(VertexInstanceID VertexInstanceID) { return Invoke<int>(nameof(GetVertexInstanceConnectedPolygonCount), VertexInstanceID); }
        public PolygonID GetVertexInstanceConnectedPolygon(VertexInstanceID VertexInstanceID, int ConnectedPolygonNumber) { return Invoke<PolygonID>(nameof(GetVertexInstanceConnectedPolygon), VertexInstanceID, ConnectedPolygonNumber); }
        public int GetVertexCount() { return Invoke<int>(nameof(GetVertexCount)); }
        public void GetVertexConnectedPolygons(VertexID VertexID, UArray<PolygonID> OutConnectedPolygonIDs) { Invoke(nameof(GetVertexConnectedPolygons), VertexID, OutConnectedPolygonIDs); }
        public void GetVertexConnectedEdges(VertexID VertexID, UArray<EdgeID> OutConnectedEdgeIDs) { Invoke(nameof(GetVertexConnectedEdges), VertexID, OutConnectedEdgeIDs); }
        public int GetVertexConnectedEdgeCount(VertexID VertexID) { return Invoke<int>(nameof(GetVertexConnectedEdgeCount), VertexID); }
        public EdgeID GetVertexConnectedEdge(VertexID VertexID, int ConnectedEdgeNumber) { return Invoke<EdgeID>(nameof(GetVertexConnectedEdge), VertexID, ConnectedEdgeNumber); }
        public void GetVertexAdjacentVertices(VertexID VertexID, UArray<VertexID> OutAdjacentVertexIDs) { Invoke(nameof(GetVertexAdjacentVertices), VertexID, OutAdjacentVertexIDs); }
        public int GetTextureCoordinateCount() { return Invoke<int>(nameof(GetTextureCoordinateCount)); }
        public SubdivisionLimitData GetSubdivisionLimitData() { return Invoke<SubdivisionLimitData>(nameof(GetSubdivisionLimitData)); }
        public int GetSubdivisionCount() { return Invoke<int>(nameof(GetSubdivisionCount)); }
        public int GetPolygonTriangulatedTriangleCount(PolygonID PolygonID) { return Invoke<int>(nameof(GetPolygonTriangulatedTriangleCount), PolygonID); }
        public TriangleID GetPolygonTriangulatedTriangle(PolygonID PolygonID, int PolygonTriangleNumber) { return Invoke<TriangleID>(nameof(GetPolygonTriangulatedTriangle), PolygonID, PolygonTriangleNumber); }
        public void GetPolygonPerimeterVertices(PolygonID PolygonID, UArray<VertexID> OutPolygonPerimeterVertexIDs) { Invoke(nameof(GetPolygonPerimeterVertices), PolygonID, OutPolygonPerimeterVertexIDs); }
        public void GetPolygonPerimeterVertexInstances(PolygonID PolygonID, UArray<VertexInstanceID> OutPolygonPerimeterVertexInstanceIDs) { Invoke(nameof(GetPolygonPerimeterVertexInstances), PolygonID, OutPolygonPerimeterVertexInstanceIDs); }
        public VertexInstanceID GetPolygonPerimeterVertexInstance(PolygonID PolygonID, int PolygonVertexNumber) { return Invoke<VertexInstanceID>(nameof(GetPolygonPerimeterVertexInstance), PolygonID, PolygonVertexNumber); }
        public int GetPolygonPerimeterVertexCount(PolygonID PolygonID) { return Invoke<int>(nameof(GetPolygonPerimeterVertexCount), PolygonID); }
        public VertexID GetPolygonPerimeterVertex(PolygonID PolygonID, int PolygonVertexNumber) { return Invoke<VertexID>(nameof(GetPolygonPerimeterVertex), PolygonID, PolygonVertexNumber); }
        public void GetPolygonPerimeterEdges(PolygonID PolygonID, UArray<EdgeID> OutPolygonPerimeterEdgeIDs) { Invoke(nameof(GetPolygonPerimeterEdges), PolygonID, OutPolygonPerimeterEdgeIDs); }
        public int GetPolygonPerimeterEdgeCount(PolygonID PolygonID) { return Invoke<int>(nameof(GetPolygonPerimeterEdgeCount), PolygonID); }
        public EdgeID GetPolygonPerimeterEdge(PolygonID PolygonID, int PerimeterEdgeNumber, bool bOutEdgeWindingIsReversedForPolygon) { return Invoke<EdgeID>(nameof(GetPolygonPerimeterEdge), PolygonID, PerimeterEdgeNumber, bOutEdgeWindingIsReversedForPolygon); }
        public PolygonID GetPolygonInGroup(PolygonGroupID PolygonGroupID, int PolygonNumber) { return Invoke<PolygonID>(nameof(GetPolygonInGroup), PolygonGroupID, PolygonNumber); }
        public int GetPolygonGroupCount() { return Invoke<int>(nameof(GetPolygonGroupCount)); }
        public int GetPolygonCountInGroup(PolygonGroupID PolygonGroupID) { return Invoke<int>(nameof(GetPolygonCountInGroup), PolygonGroupID); }
        public int GetPolygonCount() { return Invoke<int>(nameof(GetPolygonCount)); }
        public void GetPolygonAdjacentPolygons(PolygonID PolygonID, UArray<PolygonID> OutAdjacentPolygons) { Invoke(nameof(GetPolygonAdjacentPolygons), PolygonID, OutAdjacentPolygons); }
        public PolygonGroupID GetGroupForPolygon(PolygonID PolygonID) { return Invoke<PolygonGroupID>(nameof(GetGroupForPolygon), PolygonID); }
        public PolygonGroupID GetFirstValidPolygonGroup() { return Invoke<PolygonGroupID>(nameof(GetFirstValidPolygonGroup)); }
        public void GetEdgeVertices(EdgeID EdgeID, VertexID OutEdgeVertexID0, VertexID OutEdgeVertexID1) { Invoke(nameof(GetEdgeVertices), EdgeID, OutEdgeVertexID0, OutEdgeVertexID1); }
        public VertexID GetEdgeVertex(EdgeID EdgeID, int EdgeVertexNumber) { return Invoke<VertexID>(nameof(GetEdgeVertex), EdgeID, EdgeVertexNumber); }
        public EdgeID GetEdgeThatConnectsVertices(VertexID VertexID0, VertexID VertexID1) { return Invoke<EdgeID>(nameof(GetEdgeThatConnectsVertices), VertexID0, VertexID1); }
        public void GetEdgeLoopElements(EdgeID EdgeID, UArray<EdgeID> EdgeLoopIDs) { Invoke(nameof(GetEdgeLoopElements), EdgeID, EdgeLoopIDs); }
        public int GetEdgeCount() { return Invoke<int>(nameof(GetEdgeCount)); }
        public void GetEdgeConnectedPolygons(EdgeID EdgeID, UArray<PolygonID> OutConnectedPolygonIDs) { Invoke(nameof(GetEdgeConnectedPolygons), EdgeID, OutConnectedPolygonIDs); }
        public int GetEdgeConnectedPolygonCount(EdgeID EdgeID) { return Invoke<int>(nameof(GetEdgeConnectedPolygonCount), EdgeID); }
        public PolygonID GetEdgeConnectedPolygon(EdgeID EdgeID, int ConnectedPolygonNumber) { return Invoke<PolygonID>(nameof(GetEdgeConnectedPolygon), EdgeID, ConnectedPolygonNumber); }
        public void GeneratePolygonTangentsAndNormals(UArray<PolygonID> PolygonIDs) { Invoke(nameof(GeneratePolygonTangentsAndNormals), PolygonIDs); }
        public void FlipPolygons(UArray<PolygonID> PolygonIDs) { Invoke(nameof(FlipPolygons), PolygonIDs); }
        public int FindPolygonPerimeterVertexNumberForVertex(PolygonID PolygonID, VertexID VertexID) { return Invoke<int>(nameof(FindPolygonPerimeterVertexNumberForVertex), PolygonID, VertexID); }
        public int FindPolygonPerimeterEdgeNumberForVertices(PolygonID PolygonID, VertexID EdgeVertexID0, VertexID EdgeVertexID1) { return Invoke<int>(nameof(FindPolygonPerimeterEdgeNumberForVertices), PolygonID, EdgeVertexID0, EdgeVertexID1); }
        public void FindPolygonLoop(EdgeID EdgeID, UArray<EdgeID> OutEdgeLoopEdgeIDs, UArray<EdgeID> OutFlippedEdgeIDs, UArray<EdgeID> OutReversedEdgeIDPathToTake, UArray<PolygonID> OutPolygonIDsToSplit) { Invoke(nameof(FindPolygonLoop), EdgeID, OutEdgeLoopEdgeIDs, OutFlippedEdgeIDs, OutReversedEdgeIDPathToTake, OutPolygonIDsToSplit); }
        public void ExtrudePolygons(UArray<PolygonID> Polygons, float ExtrudeDistance, bool bKeepNeighborsTogether, UArray<PolygonID> OutNewExtrudedFrontPolygons) { Invoke(nameof(ExtrudePolygons), Polygons, ExtrudeDistance, bKeepNeighborsTogether, OutNewExtrudedFrontPolygons); }
        public void ExtendVertices(UArray<VertexID> VertexIDs, bool bOnlyExtendClosestEdge, Vector ReferencePosition, UArray<VertexID> OutNewExtendedVertexIDs) { Invoke(nameof(ExtendVertices), VertexIDs, bOnlyExtendClosestEdge, ReferencePosition, OutNewExtendedVertexIDs); }
        public void ExtendEdges(UArray<EdgeID> EdgeIDs, bool bWeldNeighbors, UArray<EdgeID> OutNewExtendedEdgeIDs) { Invoke(nameof(ExtendEdges), EdgeIDs, bWeldNeighbors, OutNewExtendedEdgeIDs); }
        public void EndModification(bool bFromUndo) { Invoke(nameof(EndModification), bFromUndo); }
        public void DeleteVertexInstances(UArray<VertexInstanceID> VertexInstanceIDsToDelete, bool bDeleteOrphanedVertices) { Invoke(nameof(DeleteVertexInstances), VertexInstanceIDsToDelete, bDeleteOrphanedVertices); }
        public void DeleteVertexAndConnectedEdgesAndPolygons(VertexID VertexID, bool bDeleteOrphanedEdges, bool bDeleteOrphanedVertices, bool bDeleteOrphanedVertexInstances, bool bDeleteEmptyPolygonGroups) { Invoke(nameof(DeleteVertexAndConnectedEdgesAndPolygons), VertexID, bDeleteOrphanedEdges, bDeleteOrphanedVertices, bDeleteOrphanedVertexInstances, bDeleteEmptyPolygonGroups); }
        public void DeletePolygons(UArray<PolygonID> PolygonIDsToDelete, bool bDeleteOrphanedEdges, bool bDeleteOrphanedVertices, bool bDeleteOrphanedVertexInstances, bool bDeleteEmptyPolygonGroups) { Invoke(nameof(DeletePolygons), PolygonIDsToDelete, bDeleteOrphanedEdges, bDeleteOrphanedVertices, bDeleteOrphanedVertexInstances, bDeleteEmptyPolygonGroups); }
        public void DeletePolygonGroups(UArray<PolygonGroupID> PolygonGroupIDs) { Invoke(nameof(DeletePolygonGroups), PolygonGroupIDs); }
        public void DeleteOrphanVertices(UArray<VertexID> VertexIDsToDelete) { Invoke(nameof(DeleteOrphanVertices), VertexIDsToDelete); }
        public void DeleteEdges(UArray<EdgeID> EdgeIDsToDelete, bool bDeleteOrphanedVertices) { Invoke(nameof(DeleteEdges), EdgeIDsToDelete, bDeleteOrphanedVertices); }
        public void DeleteEdgeAndConnectedPolygons(EdgeID EdgeID, bool bDeleteOrphanedEdges, bool bDeleteOrphanedVertices, bool bDeleteOrphanedVertexInstances, bool bDeleteEmptyPolygonGroups) { Invoke(nameof(DeleteEdgeAndConnectedPolygons), EdgeID, bDeleteOrphanedEdges, bDeleteOrphanedVertices, bDeleteOrphanedVertexInstances, bDeleteEmptyPolygonGroups); }
        public void CreateVertices(UArray<VertexToCreate> VerticesToCreate, UArray<VertexID> OutNewVertexIDs) { Invoke(nameof(CreateVertices), VerticesToCreate, OutNewVertexIDs); }
        public void CreateVertexInstances(UArray<VertexInstanceToCreate> VertexInstancesToCreate, UArray<VertexInstanceID> OutNewVertexInstanceIDs) { Invoke(nameof(CreateVertexInstances), VertexInstancesToCreate, OutNewVertexInstanceIDs); }
        public void CreatePolygons(UArray<PolygonToCreate> PolygonsToCreate, UArray<PolygonID> OutNewPolygonIDs, UArray<EdgeID> OutNewEdgeIDs) { Invoke(nameof(CreatePolygons), PolygonsToCreate, OutNewPolygonIDs, OutNewEdgeIDs); }
        public void CreatePolygonGroups(UArray<PolygonGroupToCreate> PolygonGroupsToCreate, UArray<PolygonGroupID> OutNewPolygonGroupIDs) { Invoke(nameof(CreatePolygonGroups), PolygonGroupsToCreate, OutNewPolygonGroupIDs); }
        public void CreateMissingPolygonPerimeterEdges(PolygonID PolygonID, UArray<EdgeID> OutNewEdgeIDs) { Invoke(nameof(CreateMissingPolygonPerimeterEdges), PolygonID, OutNewEdgeIDs); }
        public void CreateEmptyVertexRange(int NumVerticesToCreate, UArray<VertexID> OutNewVertexIDs) { Invoke(nameof(CreateEmptyVertexRange), NumVerticesToCreate, OutNewVertexIDs); }
        public void CreateEdges(UArray<EdgeToCreate> EdgesToCreate, UArray<EdgeID> OutNewEdgeIDs) { Invoke(nameof(CreateEdges), EdgesToCreate, OutNewEdgeIDs); }
        public void ComputePolygonsSharedEdges(UArray<PolygonID> PolygonIDs, UArray<EdgeID> OutSharedEdgeIDs) { Invoke(nameof(ComputePolygonsSharedEdges), PolygonIDs, OutSharedEdgeIDs); }
        public Plane ComputePolygonPlane(PolygonID PolygonID) { return Invoke<Plane>(nameof(ComputePolygonPlane), PolygonID); }
        public Vector ComputePolygonNormal(PolygonID PolygonID) { return Invoke<Vector>(nameof(ComputePolygonNormal), PolygonID); }
        public Vector ComputePolygonCenter(PolygonID PolygonID) { return Invoke<Vector>(nameof(ComputePolygonCenter), PolygonID); }
        public BoxSphereBounds ComputeBoundingBoxAndSphere() { return Invoke<BoxSphereBounds>(nameof(ComputeBoundingBoxAndSphere)); }
        public Box ComputeBoundingBox() { return Invoke<Box>(nameof(ComputeBoundingBox)); }
        public EditableMesh CommitInstance(PrimitiveComponent ComponentToInstanceTo) { return Invoke<EditableMesh>(nameof(CommitInstance), ComponentToInstanceTo); }
        public void Commit() { Invoke(nameof(Commit)); }
        public void ChangePolygonsVertexInstances(UArray<ChangeVertexInstancesForPolygon> VertexInstancesForPolygons) { Invoke(nameof(ChangePolygonsVertexInstances), VertexInstancesForPolygons); }
        public void BevelPolygons(UArray<PolygonID> PolygonIDs, float BevelFixedDistance, float BevelProgressTowardCenter, UArray<PolygonID> OutNewCenterPolygonIDs, UArray<PolygonID> OutNewSidePolygonIDs) { Invoke(nameof(BevelPolygons), PolygonIDs, BevelFixedDistance, BevelProgressTowardCenter, OutNewCenterPolygonIDs, OutNewSidePolygonIDs); }
        public void AssignPolygonsToPolygonGroups(UArray<PolygonGroupForPolygon> PolygonGroupForPolygons, bool bDeleteOrphanedPolygonGroups) { Invoke(nameof(AssignPolygonsToPolygonGroups), PolygonGroupForPolygons, bDeleteOrphanedPolygonGroups); }
        public bool AnyChangesToUndo() { return Invoke<bool>(nameof(AnyChangesToUndo)); }
    }
    public class EditableMeshFactory : Object
    {
        public EditableMeshFactory(nint addr) : base(addr) { }
        public EditableMesh MakeEditableMesh(PrimitiveComponent PrimitiveComponent, int LODIndex) { return Invoke<EditableMesh>(nameof(MakeEditableMesh), PrimitiveComponent, LODIndex); }
    }
    public class EditableStaticMeshAdapter : EditableMeshAdapter
    {
        public EditableStaticMeshAdapter(nint addr) : base(addr) { }
        public StaticMesh StaticMesh { get { return this[nameof(StaticMesh)].As<StaticMesh>(); } set { this["StaticMesh"] = value; } }
        public StaticMesh OriginalStaticMesh { get { return this[nameof(OriginalStaticMesh)].As<StaticMesh>(); } set { this["OriginalStaticMesh"] = value; } }
        public int StaticMeshLODIndex { get { return this[nameof(StaticMeshLODIndex)].GetValue<int>(); } set { this[nameof(StaticMeshLODIndex)].SetValue<int>(value); } }
    }
    public enum ETriangleTessellationMode : int
    {
        ThreeTriangles = 0,
        FourTriangles = 1,
        ETriangleTessellationMode_MAX = 2,
    }
    public enum EInsetPolygonsMode : int
    {
        All = 0,
        CenterPolygonOnly = 1,
        SidePolygonsOnly = 2,
        EInsetPolygonsMode_MAX = 3,
    }
    public enum EPolygonEdgeHardness : int
    {
        NewEdgesSoft = 0,
        NewEdgesHard = 1,
        AllEdgesSoft = 2,
        AllEdgesHard = 3,
        EPolygonEdgeHardness_MAX = 4,
    }
    public enum EMeshElementAttributeType : int
    {
        None = 0,
        FVector4 = 1,
        FVector = 2,
        FVector2D = 3,
        Float = 4,
        Int = 5,
        Bool = 6,
        FName = 7,
        EMeshElementAttributeType_MAX = 8,
    }
    public enum EMeshTopologyChange : int
    {
        NoTopologyChange = 0,
        TopologyChange = 1,
        EMeshTopologyChange_MAX = 2,
    }
    public enum EMeshModificationType : int
    {
        FirstInterim = 0,
        Interim = 1,
        Final = 2,
        EMeshModificationType_MAX = 3,
    }
    public class AdaptorPolygon2Group : Object
    {
        public AdaptorPolygon2Group(nint addr) : base(addr) { }
        public uint RenderingSectionIndex { get { return this[nameof(RenderingSectionIndex)].GetValue<uint>(); } set { this[nameof(RenderingSectionIndex)].SetValue<uint>(value); } }
        public int MaterialIndex { get { return this[nameof(MaterialIndex)].GetValue<int>(); } set { this[nameof(MaterialIndex)].SetValue<int>(value); } }
        public int MaxTriangles { get { return this[nameof(MaxTriangles)].GetValue<int>(); } set { this[nameof(MaxTriangles)].SetValue<int>(value); } }
    }
    public class AdaptorPolygon : Object
    {
        public AdaptorPolygon(nint addr) : base(addr) { }
        public PolygonGroupID PolygonGroupID { get { return this[nameof(PolygonGroupID)].As<PolygonGroupID>(); } set { this["PolygonGroupID"] = value; } }
        public UArray<AdaptorTriangleID> TriangulatedPolygonTriangleIndices { get { return new UArray<AdaptorTriangleID>(this[nameof(TriangulatedPolygonTriangleIndices)].Address); } }
    }
    public class AdaptorTriangleID : ElementID
    {
        public AdaptorTriangleID(nint addr) : base(addr) { }
    }
    public class PolygonGroupForPolygon : Object
    {
        public PolygonGroupForPolygon(nint addr) : base(addr) { }
        public PolygonID PolygonID { get { return this[nameof(PolygonID)].As<PolygonID>(); } set { this["PolygonID"] = value; } }
        public PolygonGroupID PolygonGroupID { get { return this[nameof(PolygonGroupID)].As<PolygonGroupID>(); } set { this["PolygonGroupID"] = value; } }
    }
    public class PolygonGroupToCreate : Object
    {
        public PolygonGroupToCreate(nint addr) : base(addr) { }
        public MeshElementAttributeList PolygonGroupAttributes { get { return this[nameof(PolygonGroupAttributes)].As<MeshElementAttributeList>(); } set { this["PolygonGroupAttributes"] = value; } }
        public PolygonGroupID OriginalPolygonGroupID { get { return this[nameof(OriginalPolygonGroupID)].As<PolygonGroupID>(); } set { this["OriginalPolygonGroupID"] = value; } }
    }
    public class MeshElementAttributeList : Object
    {
        public MeshElementAttributeList(nint addr) : base(addr) { }
        public UArray<MeshElementAttributeData> Attributes { get { return new UArray<MeshElementAttributeData>(this[nameof(Attributes)].Address); } }
    }
    public class MeshElementAttributeData : Object
    {
        public MeshElementAttributeData(nint addr) : base(addr) { }
        public Object AttributeName { get { return this[nameof(AttributeName)]; } set { this[nameof(AttributeName)] = value; } }
        public int AttributeIndex { get { return this[nameof(AttributeIndex)].GetValue<int>(); } set { this[nameof(AttributeIndex)].SetValue<int>(value); } }
        public MeshElementAttributeValue AttributeValue { get { return this[nameof(AttributeValue)].As<MeshElementAttributeValue>(); } set { this["AttributeValue"] = value; } }
    }
    public class MeshElementAttributeValue : Object
    {
        public MeshElementAttributeValue(nint addr) : base(addr) { }
    }
    public class VertexToMove : Object
    {
        public VertexToMove(nint addr) : base(addr) { }
        public VertexID VertexID { get { return this[nameof(VertexID)].As<VertexID>(); } set { this["VertexID"] = value; } }
        public Vector NewVertexPosition { get { return this[nameof(NewVertexPosition)].As<Vector>(); } set { this["NewVertexPosition"] = value; } }
    }
    public class ChangeVertexInstancesForPolygon : Object
    {
        public ChangeVertexInstancesForPolygon(nint addr) : base(addr) { }
        public PolygonID PolygonID { get { return this[nameof(PolygonID)].As<PolygonID>(); } set { this["PolygonID"] = value; } }
        public UArray<VertexIndexAndInstanceID> PerimeterVertexIndicesAndInstanceIDs { get { return new UArray<VertexIndexAndInstanceID>(this[nameof(PerimeterVertexIndicesAndInstanceIDs)].Address); } }
        public UArray<VertexInstancesForPolygonHole> VertexIndicesAndInstanceIDsForEachHole { get { return new UArray<VertexInstancesForPolygonHole>(this[nameof(VertexIndicesAndInstanceIDsForEachHole)].Address); } }
    }
    public class VertexInstancesForPolygonHole : Object
    {
        public VertexInstancesForPolygonHole(nint addr) : base(addr) { }
        public UArray<VertexIndexAndInstanceID> VertexIndicesAndInstanceIDs { get { return new UArray<VertexIndexAndInstanceID>(this[nameof(VertexIndicesAndInstanceIDs)].Address); } }
    }
    public class VertexIndexAndInstanceID : Object
    {
        public VertexIndexAndInstanceID(nint addr) : base(addr) { }
        public int ContourIndex { get { return this[nameof(ContourIndex)].GetValue<int>(); } set { this[nameof(ContourIndex)].SetValue<int>(value); } }
        public VertexInstanceID VertexInstanceID { get { return this[nameof(VertexInstanceID)].As<VertexInstanceID>(); } set { this["VertexInstanceID"] = value; } }
    }
    public class VertexAttributesForPolygon : Object
    {
        public VertexAttributesForPolygon(nint addr) : base(addr) { }
        public PolygonID PolygonID { get { return this[nameof(PolygonID)].As<PolygonID>(); } set { this["PolygonID"] = value; } }
        public UArray<MeshElementAttributeList> PerimeterVertexAttributeLists { get { return new UArray<MeshElementAttributeList>(this[nameof(PerimeterVertexAttributeLists)].Address); } }
        public UArray<VertexAttributesForPolygonHole> VertexAttributeListsForEachHole { get { return new UArray<VertexAttributesForPolygonHole>(this[nameof(VertexAttributeListsForEachHole)].Address); } }
    }
    public class VertexAttributesForPolygonHole : Object
    {
        public VertexAttributesForPolygonHole(nint addr) : base(addr) { }
        public UArray<MeshElementAttributeList> VertexAttributeList { get { return new UArray<MeshElementAttributeList>(this[nameof(VertexAttributeList)].Address); } }
    }
    public class AttributesForEdge : Object
    {
        public AttributesForEdge(nint addr) : base(addr) { }
        public EdgeID EdgeID { get { return this[nameof(EdgeID)].As<EdgeID>(); } set { this["EdgeID"] = value; } }
        public MeshElementAttributeList EdgeAttributes { get { return this[nameof(EdgeAttributes)].As<MeshElementAttributeList>(); } set { this["EdgeAttributes"] = value; } }
    }
    public class AttributesForVertexInstance : Object
    {
        public AttributesForVertexInstance(nint addr) : base(addr) { }
        public VertexInstanceID VertexInstanceID { get { return this[nameof(VertexInstanceID)].As<VertexInstanceID>(); } set { this["VertexInstanceID"] = value; } }
        public MeshElementAttributeList VertexInstanceAttributes { get { return this[nameof(VertexInstanceAttributes)].As<MeshElementAttributeList>(); } set { this["VertexInstanceAttributes"] = value; } }
    }
    public class AttributesForVertex : Object
    {
        public AttributesForVertex(nint addr) : base(addr) { }
        public VertexID VertexID { get { return this[nameof(VertexID)].As<VertexID>(); } set { this["VertexID"] = value; } }
        public MeshElementAttributeList VertexAttributes { get { return this[nameof(VertexAttributes)].As<MeshElementAttributeList>(); } set { this["VertexAttributes"] = value; } }
    }
    public class PolygonToSplit : Object
    {
        public PolygonToSplit(nint addr) : base(addr) { }
        public PolygonID PolygonID { get { return this[nameof(PolygonID)].As<PolygonID>(); } set { this["PolygonID"] = value; } }
        public UArray<VertexPair> VertexPairsToSplitAt { get { return new UArray<VertexPair>(this[nameof(VertexPairsToSplitAt)].Address); } }
    }
    public class VertexPair : Object
    {
        public VertexPair(nint addr) : base(addr) { }
        public VertexID VertexID0 { get { return this[nameof(VertexID0)].As<VertexID>(); } set { this["VertexID0"] = value; } }
        public VertexID VertexID1 { get { return this[nameof(VertexID1)].As<VertexID>(); } set { this["VertexID1"] = value; } }
    }
    public class PolygonToCreate : Object
    {
        public PolygonToCreate(nint addr) : base(addr) { }
        public PolygonGroupID PolygonGroupID { get { return this[nameof(PolygonGroupID)].As<PolygonGroupID>(); } set { this["PolygonGroupID"] = value; } }
        public UArray<VertexAndAttributes> PerimeterVertices { get { return new UArray<VertexAndAttributes>(this[nameof(PerimeterVertices)].Address); } }
        public PolygonID OriginalPolygonID { get { return this[nameof(OriginalPolygonID)].As<PolygonID>(); } set { this["OriginalPolygonID"] = value; } }
        public EPolygonEdgeHardness PolygonEdgeHardness { get { return (EPolygonEdgeHardness)this[nameof(PolygonEdgeHardness)].GetValue<int>(); } set { this[nameof(PolygonEdgeHardness)].SetValue<int>((int)value); } }
    }
    public class VertexAndAttributes : Object
    {
        public VertexAndAttributes(nint addr) : base(addr) { }
        public VertexInstanceID VertexInstanceID { get { return this[nameof(VertexInstanceID)].As<VertexInstanceID>(); } set { this["VertexInstanceID"] = value; } }
        public VertexID VertexID { get { return this[nameof(VertexID)].As<VertexID>(); } set { this["VertexID"] = value; } }
        public MeshElementAttributeList PolygonVertexAttributes { get { return this[nameof(PolygonVertexAttributes)].As<MeshElementAttributeList>(); } set { this["PolygonVertexAttributes"] = value; } }
    }
    public class EdgeToCreate : Object
    {
        public EdgeToCreate(nint addr) : base(addr) { }
        public VertexID VertexID0 { get { return this[nameof(VertexID0)].As<VertexID>(); } set { this["VertexID0"] = value; } }
        public VertexID VertexID1 { get { return this[nameof(VertexID1)].As<VertexID>(); } set { this["VertexID1"] = value; } }
        public MeshElementAttributeList EdgeAttributes { get { return this[nameof(EdgeAttributes)].As<MeshElementAttributeList>(); } set { this["EdgeAttributes"] = value; } }
        public EdgeID OriginalEdgeID { get { return this[nameof(OriginalEdgeID)].As<EdgeID>(); } set { this["OriginalEdgeID"] = value; } }
    }
    public class VertexInstanceToCreate : Object
    {
        public VertexInstanceToCreate(nint addr) : base(addr) { }
        public VertexID VertexID { get { return this[nameof(VertexID)].As<VertexID>(); } set { this["VertexID"] = value; } }
        public MeshElementAttributeList VertexInstanceAttributes { get { return this[nameof(VertexInstanceAttributes)].As<MeshElementAttributeList>(); } set { this["VertexInstanceAttributes"] = value; } }
        public VertexInstanceID OriginalVertexInstanceID { get { return this[nameof(OriginalVertexInstanceID)].As<VertexInstanceID>(); } set { this["OriginalVertexInstanceID"] = value; } }
    }
    public class VertexToCreate : Object
    {
        public VertexToCreate(nint addr) : base(addr) { }
        public MeshElementAttributeList VertexAttributes { get { return this[nameof(VertexAttributes)].As<MeshElementAttributeList>(); } set { this["VertexAttributes"] = value; } }
        public VertexID OriginalVertexID { get { return this[nameof(OriginalVertexID)].As<VertexID>(); } set { this["OriginalVertexID"] = value; } }
    }
    public class SubdivisionLimitData : Object
    {
        public SubdivisionLimitData(nint addr) : base(addr) { }
        public UArray<Vector> VertexPositions { get { return new UArray<Vector>(this[nameof(VertexPositions)].Address); } }
        public UArray<SubdivisionLimitSection> Sections { get { return new UArray<SubdivisionLimitSection>(this[nameof(Sections)].Address); } }
        public UArray<SubdividedWireEdge> SubdividedWireEdges { get { return new UArray<SubdividedWireEdge>(this[nameof(SubdividedWireEdges)].Address); } }
    }
    public class SubdividedWireEdge : Object
    {
        public SubdividedWireEdge(nint addr) : base(addr) { }
        public int EdgeVertex0PositionIndex { get { return this[nameof(EdgeVertex0PositionIndex)].GetValue<int>(); } set { this[nameof(EdgeVertex0PositionIndex)].SetValue<int>(value); } }
        public int EdgeVertex1PositionIndex { get { return this[nameof(EdgeVertex1PositionIndex)].GetValue<int>(); } set { this[nameof(EdgeVertex1PositionIndex)].SetValue<int>(value); } }
    }
    public class SubdivisionLimitSection : Object
    {
        public SubdivisionLimitSection(nint addr) : base(addr) { }
        public UArray<SubdividedQuad> SubdividedQuads { get { return new UArray<SubdividedQuad>(this[nameof(SubdividedQuads)].Address); } }
    }
    public class SubdividedQuad : Object
    {
        public SubdividedQuad(nint addr) : base(addr) { }
        public SubdividedQuadVertex QuadVertex0 { get { return this[nameof(QuadVertex0)].As<SubdividedQuadVertex>(); } set { this["QuadVertex0"] = value; } }
        public SubdividedQuadVertex QuadVertex1 { get { return this[nameof(QuadVertex1)].As<SubdividedQuadVertex>(); } set { this["QuadVertex1"] = value; } }
        public SubdividedQuadVertex QuadVertex2 { get { return this[nameof(QuadVertex2)].As<SubdividedQuadVertex>(); } set { this["QuadVertex2"] = value; } }
        public SubdividedQuadVertex QuadVertex3 { get { return this[nameof(QuadVertex3)].As<SubdividedQuadVertex>(); } set { this["QuadVertex3"] = value; } }
    }
    public class SubdividedQuadVertex : Object
    {
        public SubdividedQuadVertex(nint addr) : base(addr) { }
        public int VertexPositionIndex { get { return this[nameof(VertexPositionIndex)].GetValue<int>(); } set { this[nameof(VertexPositionIndex)].SetValue<int>(value); } }
        public Vector2D TextureCoordinate0 { get { return this[nameof(TextureCoordinate0)].As<Vector2D>(); } set { this["TextureCoordinate0"] = value; } }
        public Vector2D TextureCoordinate1 { get { return this[nameof(TextureCoordinate1)].As<Vector2D>(); } set { this["TextureCoordinate1"] = value; } }
        public Color VertexColor { get { return this[nameof(VertexColor)].As<Color>(); } set { this["VertexColor"] = value; } }
        public Vector VertexNormal { get { return this[nameof(VertexNormal)].As<Vector>(); } set { this["VertexNormal"] = value; } }
        public Vector VertexTangent { get { return this[nameof(VertexTangent)].As<Vector>(); } set { this["VertexTangent"] = value; } }
        public float VertexBinormalSign { get { return this[nameof(VertexBinormalSign)].GetValue<float>(); } set { this[nameof(VertexBinormalSign)].SetValue<float>(value); } }
    }
    public class RenderingPolygonGroup : Object
    {
        public RenderingPolygonGroup(nint addr) : base(addr) { }
        public uint RenderingSectionIndex { get { return this[nameof(RenderingSectionIndex)].GetValue<uint>(); } set { this[nameof(RenderingSectionIndex)].SetValue<uint>(value); } }
        public int MaterialIndex { get { return this[nameof(MaterialIndex)].GetValue<int>(); } set { this[nameof(MaterialIndex)].SetValue<int>(value); } }
        public int MaxTriangles { get { return this[nameof(MaxTriangles)].GetValue<int>(); } set { this[nameof(MaxTriangles)].SetValue<int>(value); } }
    }
    public class RenderingPolygon : Object
    {
        public RenderingPolygon(nint addr) : base(addr) { }
        public PolygonGroupID PolygonGroupID { get { return this[nameof(PolygonGroupID)].As<PolygonGroupID>(); } set { this["PolygonGroupID"] = value; } }
        public UArray<TriangleID> TriangulatedPolygonTriangleIndices { get { return new UArray<TriangleID>(this[nameof(TriangulatedPolygonTriangleIndices)].Address); } }
    }
}
