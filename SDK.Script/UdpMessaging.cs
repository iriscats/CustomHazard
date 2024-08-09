using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
namespace SDK.Script.UdpMessagingSDK
{
    public class UdpMessagingSettings : Object
    {
        public UdpMessagingSettings(nint addr) : base(addr) { }
        public bool EnabledByDefault { get { return this[nameof(EnabledByDefault)].Flag; } set { this[nameof(EnabledByDefault)].Flag = value; } }
        public bool EnableTransport { get { return this[nameof(EnableTransport)].Flag; } set { this[nameof(EnableTransport)].Flag = value; } }
        public bool bAutoRepair { get { return this[nameof(bAutoRepair)].Flag; } set { this[nameof(bAutoRepair)].Flag = value; } }
        public float MaxSendRate { get { return this[nameof(MaxSendRate)].GetValue<float>(); } set { this[nameof(MaxSendRate)].SetValue<float>(value); } }
        public uint AutoRepairAttemptLimit { get { return this[nameof(AutoRepairAttemptLimit)].GetValue<uint>(); } set { this[nameof(AutoRepairAttemptLimit)].SetValue<uint>(value); } }
        public bool bStopServiceWhenAppDeactivates { get { return this[nameof(bStopServiceWhenAppDeactivates)].Flag; } set { this[nameof(bStopServiceWhenAppDeactivates)].Flag = value; } }
        public Object UnicastEndpoint { get { return this[nameof(UnicastEndpoint)]; } set { this[nameof(UnicastEndpoint)] = value; } }
        public Object MulticastEndpoint { get { return this[nameof(MulticastEndpoint)]; } set { this[nameof(MulticastEndpoint)] = value; } }
        public EUdpMessageFormat MessageFormat { get { return (EUdpMessageFormat)this[nameof(MessageFormat)].GetValue<int>(); } set { this[nameof(MessageFormat)].SetValue<int>((int)value); } }
        public byte MulticastTimeToLive { get { return this[nameof(MulticastTimeToLive)].GetValue<byte>(); } set { this[nameof(MulticastTimeToLive)].SetValue<byte>(value); } }
        public UArray<Object> StaticEndpoints { get { return new UArray<Object>(this[nameof(StaticEndpoints)].Address); } }
        public bool EnableTunnel { get { return this[nameof(EnableTunnel)].Flag; } set { this[nameof(EnableTunnel)].Flag = value; } }
        public Object TunnelUnicastEndpoint { get { return this[nameof(TunnelUnicastEndpoint)]; } set { this[nameof(TunnelUnicastEndpoint)] = value; } }
        public Object TunnelMulticastEndpoint { get { return this[nameof(TunnelMulticastEndpoint)]; } set { this[nameof(TunnelMulticastEndpoint)] = value; } }
        public UArray<Object> RemoteTunnelEndpoints { get { return new UArray<Object>(this[nameof(RemoteTunnelEndpoints)].Address); } }
    }
    public enum EUdpMessageFormat : int
    {
        None = 0,
        Json = 1,
        TaggedProperty = 2,
        CborPlatformEndianness = 3,
        CborStandardEndianness = 4,
        EUdpMessageFormat_MAX = 5,
    }
    public class UdpMockMessage : Object
    {
        public UdpMockMessage(nint addr) : base(addr) { }
        public UArray<byte> Data { get { return new UArray<byte>(this[nameof(Data)].Address); } }
    }
}
