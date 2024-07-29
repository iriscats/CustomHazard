using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
using SDK.Script.InputCoreSDK;
namespace SDK.Script.SteamVRSDK
{
    public class SteamVRChaperoneComponent : ActorComponent
    {
        public SteamVRChaperoneComponent(nint addr) : base(addr) { }
        public Object OnLeaveBounds { get { return this[nameof(OnLeaveBounds)]; } set { this[nameof(OnLeaveBounds)] = value; } }
        public Object OnReturnToBounds { get { return this[nameof(OnReturnToBounds)]; } set { this[nameof(OnReturnToBounds)] = value; } }
        public void SteamVRChaperoneEvent__DelegateSignature() { Invoke(nameof(SteamVRChaperoneEvent__DelegateSignature)); }
        public Array<Vector> GetBounds() { return Invoke<Array<Vector>>(nameof(GetBounds)); }
    }
    public class SteamVRFunctionLibrary : BlueprintFunctionLibrary
    {
        public SteamVRFunctionLibrary(nint addr) : base(addr) { }
        public void GetValidTrackedDeviceIds(ESteamVRTrackedDeviceType DeviceType, Array<int> OutTrackedDeviceIds) { Invoke(nameof(GetValidTrackedDeviceIds), DeviceType, OutTrackedDeviceIds); }
        public bool GetTrackedDevicePositionAndOrientation(int DeviceID, Vector OutPosition, Rotator OutOrientation) { return Invoke<bool>(nameof(GetTrackedDevicePositionAndOrientation), DeviceID, OutPosition, OutOrientation); }
        public bool GetHandPositionAndOrientation(int ControllerIndex, EControllerHand hand, Vector OutPosition, Rotator OutOrientation) { return Invoke<bool>(nameof(GetHandPositionAndOrientation), ControllerIndex, hand, OutPosition, OutOrientation); }
    }
    public class SteamVRHQStereoLayerShape : StereoLayerShapeQuad
    {
        public SteamVRHQStereoLayerShape(nint addr) : base(addr) { }
        public bool bCurved { get { return this[nameof(bCurved)].Flag; } set { this[nameof(bCurved)].Flag = value; } }
        public bool bAntiAlias { get { return this[nameof(bAntiAlias)].Flag; } set { this[nameof(bAntiAlias)].Flag = value; } }
        public float AutoCurveMinDistance { get { return this[nameof(AutoCurveMinDistance)].GetValue<float>(); } set { this[nameof(AutoCurveMinDistance)].SetValue<float>(value); } }
        public float AutoCurveMaxDistance { get { return this[nameof(AutoCurveMaxDistance)].GetValue<float>(); } set { this[nameof(AutoCurveMaxDistance)].SetValue<float>(value); } }
        public void SetCurved(bool InCurved) { Invoke(nameof(SetCurved), InCurved); }
        public void SetAutoCurveMinDistance(float InDistance) { Invoke(nameof(SetAutoCurveMinDistance), InDistance); }
        public void SetAutoCurveMaxDistance(float InDistance) { Invoke(nameof(SetAutoCurveMaxDistance), InDistance); }
        public void SetAntiAlias(bool InAntiAlias) { Invoke(nameof(SetAntiAlias), InAntiAlias); }
    }
    public enum ESteamVRTrackedDeviceType : int
    {
        Controller = 0,
        TrackingReference = 1,
        Other = 2,
        Invalid = 3,
        ESteamVRTrackedDeviceType_MAX = 4,
    }
}
