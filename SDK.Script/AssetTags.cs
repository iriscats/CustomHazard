using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.AssetTagsSDK
{
    public class AssetTagsSubsystem : EngineSubsystem
    {
        public AssetTagsSubsystem(nint addr) : base(addr) { }
        public UArray<Object> GetCollectionsContainingAssetPtr(Object AssetPtr) { return Invoke<UArray<Object>>(nameof(GetCollectionsContainingAssetPtr), AssetPtr); }
        public UArray<Object> GetCollectionsContainingAssetData(AssetData AssetData) { return Invoke<UArray<Object>>(nameof(GetCollectionsContainingAssetData), AssetData); }
        public UArray<Object> GetCollectionsContainingAsset(Object AssetPathName) { return Invoke<UArray<Object>>(nameof(GetCollectionsContainingAsset), AssetPathName); }
        public UArray<Object> GetCollections() { return Invoke<UArray<Object>>(nameof(GetCollections)); }
        public UArray<AssetData> GetAssetsInCollection(Object Name) { return Invoke<UArray<AssetData>>(nameof(GetAssetsInCollection), Name); }
        public bool CollectionExists(Object Name) { return Invoke<bool>(nameof(CollectionExists), Name); }
    }
    public enum ECollectionScriptingShareType : int
    {
        Local = 0,
        Private = 1,
        Shared = 2,
        ECollectionScriptingShareType_MAX = 3,
    }
}
