using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
namespace SDK.Script.DiscordSDKSDK
{
    public class DiscordSDKInterface : Object
    {
        public DiscordSDKInterface(nint addr) : base(addr) { }
        public Object OnJoinRequest { get { return this[nameof(OnJoinRequest)]; } set { this[nameof(OnJoinRequest)] = value; } }
        public void RejectInvite(Object UserId) { Invoke(nameof(RejectInvite), UserId); }
        public void IgnoreInvite(Object UserId) { Invoke(nameof(IgnoreInvite), UserId); }
        public DiscordSDKInterface Get() { return Invoke<DiscordSDKInterface>(nameof(Get)); }
        public void AcceptInvite(Object UserId) { Invoke(nameof(AcceptInvite), UserId); }
    }
    public class DiscordSDKInterface_Win64 : DiscordSDKInterface
    {
        public DiscordSDKInterface_Win64(nint addr) : base(addr) { }
    }
    public class DiscordUserDataSDK : Object
    {
        public DiscordUserDataSDK(nint addr) : base(addr) { }
        public Object UserId { get { return this[nameof(UserId)]; } set { this[nameof(UserId)] = value; } }
        public Object Username { get { return this[nameof(Username)]; } set { this[nameof(Username)] = value; } }
        public Object discriminator { get { return this[nameof(discriminator)]; } set { this[nameof(discriminator)] = value; } }
        public Object avatar { get { return this[nameof(avatar)]; } set { this[nameof(avatar)] = value; } }
    }
}
