using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
namespace SDK.Script.PacketHandlerSDK
{
    public class HandlerComponentFactory : Object
    {
        public HandlerComponentFactory(nint addr) : base(addr) { }
    }
    public class PacketHandlerProfileConfig : Object
    {
        public PacketHandlerProfileConfig(nint addr) : base(addr) { }
        public UArray<Object> Components { get { return new UArray<Object>(this[nameof(Components)].Address); } }
    }
}
