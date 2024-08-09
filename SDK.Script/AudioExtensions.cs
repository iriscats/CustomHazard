using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
namespace SDK.Script.AudioExtensionsSDK
{
    public class SpatializationPluginSourceSettingsBase : Object
    {
        public SpatializationPluginSourceSettingsBase(nint addr) : base(addr) { }
    }
    public class AudioEndpointSettingsBase : Object
    {
        public AudioEndpointSettingsBase(nint addr) : base(addr) { }
    }
    public class SoundfieldEncodingSettingsBase : Object
    {
        public SoundfieldEncodingSettingsBase(nint addr) : base(addr) { }
    }
    public class DummyEndpointSettings : AudioEndpointSettingsBase
    {
        public DummyEndpointSettings(nint addr) : base(addr) { }
    }
    public class OcclusionPluginSourceSettingsBase : Object
    {
        public OcclusionPluginSourceSettingsBase(nint addr) : base(addr) { }
    }
    public class ReverbPluginSourceSettingsBase : Object
    {
        public ReverbPluginSourceSettingsBase(nint addr) : base(addr) { }
    }
    public class SoundModulatorBase : Object
    {
        public SoundModulatorBase(nint addr) : base(addr) { }
    }
    public class SoundfieldEndpointSettingsBase : Object
    {
        public SoundfieldEndpointSettingsBase(nint addr) : base(addr) { }
    }
    public class SoundfieldEffectSettingsBase : Object
    {
        public SoundfieldEffectSettingsBase(nint addr) : base(addr) { }
    }
    public class SoundfieldEffectBase : Object
    {
        public SoundfieldEffectBase(nint addr) : base(addr) { }
        public SoundfieldEffectSettingsBase Settings { get { return this[nameof(Settings)].As<SoundfieldEffectSettingsBase>(); } set { this["Settings"] = value; } }
    }
}
