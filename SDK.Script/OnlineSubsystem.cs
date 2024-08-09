using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.OnlineSubsystemSDK
{
    public class NamedInterfaces : Object
    {
        public NamedInterfaces(nint addr) : base(addr) { }
        public UArray<NamedInterface> NamedInterfaces_value { get { return new UArray<NamedInterface>(this[nameof(NamedInterfaces)].Address); } }
        public UArray<NamedInterfaceDef> NamedInterfaceDefs { get { return new UArray<NamedInterfaceDef>(this[nameof(NamedInterfaceDefs)].Address); } }
    }
    public class TurnBasedMatchInterface : Interface
    {
        public TurnBasedMatchInterface(nint addr) : base(addr) { }
        public void OnMatchReceivedTurn(Object Match, bool bDidBecomeActive) { Invoke(nameof(OnMatchReceivedTurn), Match, bDidBecomeActive); }
        public void OnMatchEnded(Object Match) { Invoke(nameof(OnMatchEnded), Match); }
    }
    public enum EInAppPurchaseState : int
    {
        Unknown = 0,
        Success = 1,
        Failed = 2,
        Cancelled = 3,
        Invalid = 4,
        NotAllowed = 5,
        Restored = 6,
        AlreadyOwned = 7,
        EInAppPurchaseState_MAX = 8,
    }
    public enum EMPMatchOutcome : int
    {
        None = 0,
        Quit = 1,
        Won = 2,
        Lost = 3,
        Tied = 4,
        TimeExpired = 5,
        First = 6,
        Second = 7,
        Third = 8,
        Fourth = 9,
        EMPMatchOutcome_MAX = 10,
    }
    public class InAppPurchaseProductInfo : Object
    {
        public InAppPurchaseProductInfo(nint addr) : base(addr) { }
        public Object Identifier { get { return this[nameof(Identifier)]; } set { this[nameof(Identifier)] = value; } }
        public Object TransactionIdentifier { get { return this[nameof(TransactionIdentifier)]; } set { this[nameof(TransactionIdentifier)] = value; } }
        public Object DisplayName { get { return this[nameof(DisplayName)]; } set { this[nameof(DisplayName)] = value; } }
        public Object DisplayDescription { get { return this[nameof(DisplayDescription)]; } set { this[nameof(DisplayDescription)] = value; } }
        public Object DisplayPrice { get { return this[nameof(DisplayPrice)]; } set { this[nameof(DisplayPrice)] = value; } }
        public float RawPrice { get { return this[nameof(RawPrice)].GetValue<float>(); } set { this[nameof(RawPrice)].SetValue<float>(value); } }
        public Object CurrencyCode { get { return this[nameof(CurrencyCode)]; } set { this[nameof(CurrencyCode)] = value; } }
        public Object CurrencySymbol { get { return this[nameof(CurrencySymbol)]; } set { this[nameof(CurrencySymbol)] = value; } }
        public Object DecimalSeparator { get { return this[nameof(DecimalSeparator)]; } set { this[nameof(DecimalSeparator)] = value; } }
        public Object GroupingSeparator { get { return this[nameof(GroupingSeparator)]; } set { this[nameof(GroupingSeparator)] = value; } }
        public Object ReceiptData { get { return this[nameof(ReceiptData)]; } set { this[nameof(ReceiptData)] = value; } }
    }
    public class InAppPurchaseRestoreInfo : Object
    {
        public InAppPurchaseRestoreInfo(nint addr) : base(addr) { }
        public Object Identifier { get { return this[nameof(Identifier)]; } set { this[nameof(Identifier)] = value; } }
        public Object ReceiptData { get { return this[nameof(ReceiptData)]; } set { this[nameof(ReceiptData)] = value; } }
        public Object TransactionIdentifier { get { return this[nameof(TransactionIdentifier)]; } set { this[nameof(TransactionIdentifier)] = value; } }
    }
    public class NamedInterfaceDef : Object
    {
        public NamedInterfaceDef(nint addr) : base(addr) { }
        public Object InterfaceName { get { return this[nameof(InterfaceName)]; } set { this[nameof(InterfaceName)] = value; } }
        public Object InterfaceClassName { get { return this[nameof(InterfaceClassName)]; } set { this[nameof(InterfaceClassName)] = value; } }
    }
    public class NamedInterface : Object
    {
        public NamedInterface(nint addr) : base(addr) { }
        public Object InterfaceName { get { return this[nameof(InterfaceName)]; } set { this[nameof(InterfaceName)] = value; } }
        public Object InterfaceObject { get { return this[nameof(InterfaceObject)].As<Object>(); } set { this["InterfaceObject"] = value; } }
    }
    public class InAppPurchaseProductRequest : Object
    {
        public InAppPurchaseProductRequest(nint addr) : base(addr) { }
        public Object ProductIdentifier { get { return this[nameof(ProductIdentifier)]; } set { this[nameof(ProductIdentifier)] = value; } }
        public bool bIsConsumable { get { return this[nameof(bIsConsumable)].Flag; } set { this[nameof(bIsConsumable)].Flag = value; } }
    }
}
