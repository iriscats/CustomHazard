using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.AudioExtensionsSDK;
using SDK.Script.EngineSDK;
namespace SDK.Script.SpatializationSDK
{
    public class ITDSpatializationSourceSettings : SpatializationPluginSourceSettingsBase
    {
        public ITDSpatializationSourceSettings(nint addr) : base(addr) { }
        public bool bEnableILD { get { return this[nameof(bEnableILD)].Flag; } set { this[nameof(bEnableILD)].Flag = value; } }
        public RuntimeFloatCurve PanningIntensityOverDistance { get { return this[nameof(PanningIntensityOverDistance)].As<RuntimeFloatCurve>(); } set { this["PanningIntensityOverDistance"] = value; } }
    }
}
