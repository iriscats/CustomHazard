using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
namespace SDK.Script.ImgMediaEngineSDK
{
    public class ImgMediaPlaybackComponent : ActorComponent
    {
        public ImgMediaPlaybackComponent(nint addr) : base(addr) { }
        public float Width { get { return this[nameof(Width)].GetValue<float>(); } set { this[nameof(Width)].SetValue<float>(value); } }
        public float LODBias { get { return this[nameof(LODBias)].GetValue<float>(); } set { this[nameof(LODBias)].SetValue<float>(value); } }
    }
}
