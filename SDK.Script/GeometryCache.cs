using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
namespace SDK.Script.GeometryCacheSDK
{
    public class GeometryCache : Object
    {
        public GeometryCache(nint addr) : base(addr) { }
        public Array<MaterialInterface> Materials { get { return new Array<MaterialInterface>(this[nameof(Materials)].Address); } }
        public Array<GeometryCacheTrack> Tracks { get { return new Array<GeometryCacheTrack>(this[nameof(Tracks)].Address); } }
        public int StartFrame { get { return this[nameof(StartFrame)].GetValue<int>(); } set { this[nameof(StartFrame)].SetValue<int>(value); } }
        public int EndFrame { get { return this[nameof(EndFrame)].GetValue<int>(); } set { this[nameof(EndFrame)].SetValue<int>(value); } }
        public ulong Hash { get { return this[nameof(Hash)].GetValue<ulong>(); } set { this[nameof(Hash)].SetValue<ulong>(value); } }
    }
    public class GeometryCacheActor : Actor
    {
        public GeometryCacheActor(nint addr) : base(addr) { }
        public GeometryCacheComponent GeometryCacheComponent { get { return this[nameof(GeometryCacheComponent)].As<GeometryCacheComponent>(); } set { this["GeometryCacheComponent"] = value; } }
        public GeometryCacheComponent GetGeometryCacheComponent() { return Invoke<GeometryCacheComponent>(nameof(GetGeometryCacheComponent)); }
    }
    public class GeometryCacheCodecBase : Object
    {
        public GeometryCacheCodecBase(nint addr) : base(addr) { }
        public Array<int> TopologyRanges { get { return new Array<int>(this[nameof(TopologyRanges)].Address); } }
    }
    public class GeometryCacheCodecRaw : GeometryCacheCodecBase
    {
        public GeometryCacheCodecRaw(nint addr) : base(addr) { }
        public int DummyProperty { get { return this[nameof(DummyProperty)].GetValue<int>(); } set { this[nameof(DummyProperty)].SetValue<int>(value); } }
    }
    public class GeometryCacheCodecV1 : GeometryCacheCodecBase
    {
        public GeometryCacheCodecV1(nint addr) : base(addr) { }
    }
    public class GeometryCacheComponent : MeshComponent
    {
        public GeometryCacheComponent(nint addr) : base(addr) { }
        public GeometryCache GeometryCache { get { return this[nameof(GeometryCache)].As<GeometryCache>(); } set { this["GeometryCache"] = value; } }
        public bool bRunning { get { return this[nameof(bRunning)].Flag; } set { this[nameof(bRunning)].Flag = value; } }
        public bool bLooping { get { return this[nameof(bLooping)].Flag; } set { this[nameof(bLooping)].Flag = value; } }
        public bool bExtrapolateFrames { get { return this[nameof(bExtrapolateFrames)].Flag; } set { this[nameof(bExtrapolateFrames)].Flag = value; } }
        public float StartTimeOffset { get { return this[nameof(StartTimeOffset)].GetValue<float>(); } set { this[nameof(StartTimeOffset)].SetValue<float>(value); } }
        public float PlaybackSpeed { get { return this[nameof(PlaybackSpeed)].GetValue<float>(); } set { this[nameof(PlaybackSpeed)].SetValue<float>(value); } }
        public float MotionVectorScale { get { return this[nameof(MotionVectorScale)].GetValue<float>(); } set { this[nameof(MotionVectorScale)].SetValue<float>(value); } }
        public int NumTracks { get { return this[nameof(NumTracks)].GetValue<int>(); } set { this[nameof(NumTracks)].SetValue<int>(value); } }
        public float ElapsedTime { get { return this[nameof(ElapsedTime)].GetValue<float>(); } set { this[nameof(ElapsedTime)].SetValue<float>(value); } }
        public float Duration { get { return this[nameof(Duration)].GetValue<float>(); } set { this[nameof(Duration)].SetValue<float>(value); } }
        public bool bManualTick { get { return this[nameof(bManualTick)].Flag; } set { this[nameof(bManualTick)].Flag = value; } }
        public void TickAtThisTime(float Time, bool bInIsRunning, bool bInBackwards, bool bInIsLooping) { Invoke(nameof(TickAtThisTime), Time, bInIsRunning, bInBackwards, bInIsLooping); }
        public void Stop() { Invoke(nameof(Stop)); }
        public void SetStartTimeOffset(float NewStartTimeOffset) { Invoke(nameof(SetStartTimeOffset), NewStartTimeOffset); }
        public void SetPlaybackSpeed(float NewPlaybackSpeed) { Invoke(nameof(SetPlaybackSpeed), NewPlaybackSpeed); }
        public void SetMotionVectorScale(float NewMotionVectorScale) { Invoke(nameof(SetMotionVectorScale), NewMotionVectorScale); }
        public void SetLooping(bool bNewLooping) { Invoke(nameof(SetLooping), bNewLooping); }
        public bool SetGeometryCache(GeometryCache NewGeomCache) { return Invoke<bool>(nameof(SetGeometryCache), NewGeomCache); }
        public void SetExtrapolateFrames(bool bNewExtrapolating) { Invoke(nameof(SetExtrapolateFrames), bNewExtrapolating); }
        public void PlayReversedFromEnd() { Invoke(nameof(PlayReversedFromEnd)); }
        public void PlayReversed() { Invoke(nameof(PlayReversed)); }
        public void PlayFromStart() { Invoke(nameof(PlayFromStart)); }
        public void Play() { Invoke(nameof(Play)); }
        public void Pause() { Invoke(nameof(Pause)); }
        public bool IsPlayingReversed() { return Invoke<bool>(nameof(IsPlayingReversed)); }
        public bool IsPlaying() { return Invoke<bool>(nameof(IsPlaying)); }
        public bool IsLooping() { return Invoke<bool>(nameof(IsLooping)); }
        public bool IsExtrapolatingFrames() { return Invoke<bool>(nameof(IsExtrapolatingFrames)); }
        public float GetStartTimeOffset() { return Invoke<float>(nameof(GetStartTimeOffset)); }
        public float GetPlaybackSpeed() { return Invoke<float>(nameof(GetPlaybackSpeed)); }
        public float GetPlaybackDirection() { return Invoke<float>(nameof(GetPlaybackDirection)); }
        public int GetNumberOfFrames() { return Invoke<int>(nameof(GetNumberOfFrames)); }
        public float GetMotionVectorScale() { return Invoke<float>(nameof(GetMotionVectorScale)); }
        public float GetDuration() { return Invoke<float>(nameof(GetDuration)); }
        public float GetAnimationTime() { return Invoke<float>(nameof(GetAnimationTime)); }
    }
    public class GeometryCacheTrack : Object
    {
        public GeometryCacheTrack(nint addr) : base(addr) { }
        public float Duration { get { return this[nameof(Duration)].GetValue<float>(); } set { this[nameof(Duration)].SetValue<float>(value); } }
    }
    public class GeometryCacheTrack_FlipbookAnimation : GeometryCacheTrack
    {
        public GeometryCacheTrack_FlipbookAnimation(nint addr) : base(addr) { }
        public uint NumMeshSamples { get { return this[nameof(NumMeshSamples)].GetValue<uint>(); } set { this[nameof(NumMeshSamples)].SetValue<uint>(value); } }
        public void AddMeshSample(GeometryCacheMeshData MeshData, float SampleTime) { Invoke(nameof(AddMeshSample), MeshData, SampleTime); }
    }
    public class GeometryCacheTrackStreamable : GeometryCacheTrack
    {
        public GeometryCacheTrackStreamable(nint addr) : base(addr) { }
        public GeometryCacheCodecBase Codec { get { return this[nameof(Codec)].As<GeometryCacheCodecBase>(); } set { this["Codec"] = value; } }
        public float StartSampleTime { get { return this[nameof(StartSampleTime)].GetValue<float>(); } set { this[nameof(StartSampleTime)].SetValue<float>(value); } }
    }
    public class GeometryCacheTrack_TransformAnimation : GeometryCacheTrack
    {
        public GeometryCacheTrack_TransformAnimation(nint addr) : base(addr) { }
        public void SetMesh(GeometryCacheMeshData NewMeshData) { Invoke(nameof(SetMesh), NewMeshData); }
    }
    public class GeometryCacheTrack_TransformGroupAnimation : GeometryCacheTrack
    {
        public GeometryCacheTrack_TransformGroupAnimation(nint addr) : base(addr) { }
        public void SetMesh(GeometryCacheMeshData NewMeshData) { Invoke(nameof(SetMesh), NewMeshData); }
    }
    public class TrackRenderData : Object
    {
        public TrackRenderData(nint addr) : base(addr) { }
    }
    public class GeometryCacheMeshData : Object
    {
        public GeometryCacheMeshData(nint addr) : base(addr) { }
    }
    public class GeometryCacheVertexInfo : Object
    {
        public GeometryCacheVertexInfo(nint addr) : base(addr) { }
    }
    public class GeometryCacheMeshBatchInfo : Object
    {
        public GeometryCacheMeshBatchInfo(nint addr) : base(addr) { }
    }
}
