using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.DeveloperSettingsSDK;
using SDK.Script.InputCoreSDK;
namespace SDK.Script.FSDRawInputSDK
{
    public class RawInputFunctionLibrary : BlueprintFunctionLibrary
    {
        public RawInputFunctionLibrary(nint addr) : base(addr) { }
        public UArray<RegisteredDeviceInfo> GetRegisteredDevices() { return Invoke<UArray<RegisteredDeviceInfo>>(nameof(GetRegisteredDevices)); }
    }
    public class RawInputSettings : DeveloperSettings
    {
        public RawInputSettings(nint addr) : base(addr) { }
        public UArray<RawInputDeviceConfiguration> DeviceConfigurations { get { return new UArray<RawInputDeviceConfiguration>(this[nameof(DeviceConfigurations)].Address); } }
        public bool bRegisterDefaultDevice { get { return this[nameof(bRegisterDefaultDevice)].Flag; } set { this[nameof(bRegisterDefaultDevice)].Flag = value; } }
    }
    public class RegisteredDeviceInfo : Object
    {
        public RegisteredDeviceInfo(nint addr) : base(addr) { }
        public int Handle { get { return this[nameof(Handle)].GetValue<int>(); } set { this[nameof(Handle)].SetValue<int>(value); } }
        public int VendorID { get { return this[nameof(VendorID)].GetValue<int>(); } set { this[nameof(VendorID)].SetValue<int>(value); } }
        public int ProductID { get { return this[nameof(ProductID)].GetValue<int>(); } set { this[nameof(ProductID)].SetValue<int>(value); } }
        public Object DeviceName { get { return this[nameof(DeviceName)]; } set { this[nameof(DeviceName)] = value; } }
    }
    public class RawInputDeviceConfiguration : Object
    {
        public RawInputDeviceConfiguration(nint addr) : base(addr) { }
        public Object VendorID { get { return this[nameof(VendorID)]; } set { this[nameof(VendorID)] = value; } }
        public Object ProductID { get { return this[nameof(ProductID)]; } set { this[nameof(ProductID)] = value; } }
        public UArray<RawInputDeviceAxisProperties> AxisProperties { get { return new UArray<RawInputDeviceAxisProperties>(this[nameof(AxisProperties)].Address); } }
        public UArray<RawInputDeviceButtonProperties> ButtonProperties { get { return new UArray<RawInputDeviceButtonProperties>(this[nameof(ButtonProperties)].Address); } }
    }
    public class RawInputDeviceButtonProperties : Object
    {
        public RawInputDeviceButtonProperties(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public Key Key { get { return this[nameof(Key)].As<Key>(); } set { this["Key"] = value; } }
    }
    public class RawInputDeviceAxisProperties : Object
    {
        public RawInputDeviceAxisProperties(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public bool bMapToButton { get { return this[nameof(bMapToButton)].Flag; } set { this[nameof(bMapToButton)].Flag = value; } }
        public Key Key { get { return this[nameof(Key)].As<Key>(); } set { this["Key"] = value; } }
        public bool bInverted { get { return this[nameof(bInverted)].Flag; } set { this[nameof(bInverted)].Flag = value; } }
        public bool bGamepadStick { get { return this[nameof(bGamepadStick)].Flag; } set { this[nameof(bGamepadStick)].Flag = value; } }
        public float Offset { get { return this[nameof(Offset)].GetValue<float>(); } set { this[nameof(Offset)].SetValue<float>(value); } }
        public UArray<RawInputDeviceAxisToButtonProperties> AxisToButtonMapping { get { return new UArray<RawInputDeviceAxisToButtonProperties>(this[nameof(AxisToButtonMapping)].Address); } }
    }
    public class RawInputDeviceAxisToButtonProperties : Object
    {
        public RawInputDeviceAxisToButtonProperties(nint addr) : base(addr) { }
        public float AxisValue { get { return this[nameof(AxisValue)].GetValue<float>(); } set { this[nameof(AxisValue)].SetValue<float>(value); } }
        public float AxisThreshold { get { return this[nameof(AxisThreshold)].GetValue<float>(); } set { this[nameof(AxisThreshold)].SetValue<float>(value); } }
        public Key ButtonKey { get { return this[nameof(ButtonKey)].As<Key>(); } set { this["ButtonKey"] = value; } }
    }
}
