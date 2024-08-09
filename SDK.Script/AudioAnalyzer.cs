using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
namespace SDK.Script.AudioAnalyzerSDK
{
    public class AudioAnalyzerAsset : Object
    {
        public AudioAnalyzerAsset(nint addr) : base(addr) { }
    }
    public class AudioAnalyzerNRTSettings : AudioAnalyzerAsset
    {
        public AudioAnalyzerNRTSettings(nint addr) : base(addr) { }
    }
    public class AudioAnalyzerNRT : AudioAnalyzerAsset
    {
        public AudioAnalyzerNRT(nint addr) : base(addr) { }
        public SoundWave Sound { get { return this[nameof(Sound)].As<SoundWave>(); } set { this["Sound"] = value; } }
        public float DurationInSeconds { get { return this[nameof(DurationInSeconds)].GetValue<float>(); } set { this[nameof(DurationInSeconds)].SetValue<float>(value); } }
    }
}
