using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
namespace SDK.Script.NetCoreSDK
{
    public class NetAnalyticsAggregatorConfig : Object
    {
        public NetAnalyticsAggregatorConfig(nint addr) : base(addr) { }
        public Array<NetAnalyticsDataConfig> NetAnalyticsData { get { return new Array<NetAnalyticsDataConfig>(this[nameof(NetAnalyticsData)].Address); } }
    }
    public class NetAnalyticsDataConfig : Object
    {
        public NetAnalyticsDataConfig(nint addr) : base(addr) { }
        public Object DataName { get { return this[nameof(DataName)]; } set { this[nameof(DataName)] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
}
