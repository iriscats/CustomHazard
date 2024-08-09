using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.PropertyAccessSDK
{
    public class PropertyAccess : Interface
    {
        public PropertyAccess(nint addr) : base(addr) { }
    }
    public class PropertyEventBroadcaster : Interface
    {
        public PropertyEventBroadcaster(nint addr) : base(addr) { }
    }
    public class PropertyEventSubscriber : Interface
    {
        public PropertyEventSubscriber(nint addr) : base(addr) { }
    }
    public enum EPropertyAccessCopyBatch : int
    {
        InternalUnbatched = 0,
        ExternalUnbatched = 1,
        InternalBatched = 2,
        ExternalBatched = 3,
        Count = 4,
        EPropertyAccessCopyBatch_MAX = 5,
    }
    public enum EPropertyAccessCopyType : int
    {
        None = 0,
        Plain = 1,
        Complex = 2,
        Bool = 3,
        Struct = 4,
        Object = 5,
        Name = 6,
        Array = 7,
        PromoteBoolToByte = 8,
        PromoteBoolToInt32 = 9,
        PromoteBoolToInt64 = 10,
        PromoteBoolToFloat = 11,
        PromoteByteToInt32 = 12,
        PromoteByteToInt64 = 13,
        PromoteByteToFloat = 14,
        PromoteInt32ToInt64 = 15,
        PromoteInt32ToFloat = 16,
        EPropertyAccessCopyType_MAX = 17,
    }
    public enum EPropertyAccessObjectType : int
    {
        None = 0,
        Object = 1,
        WeakObject = 2,
        SoftObject = 3,
        EPropertyAccessObjectType_MAX = 4,
    }
    public enum EPropertyAccessIndirectionType : int
    {
        Offset = 0,
        Object = 1,
        Array = 2,
        ScriptFunction = 3,
        NativeFunction = 4,
        EPropertyAccessIndirectionType_MAX = 5,
    }
    public class PropertyAccessLibrary : Object
    {
        public PropertyAccessLibrary(nint addr) : base(addr) { }
        public UArray<PropertyAccessSegment> PathSegments { get { return new UArray<PropertyAccessSegment>(this[nameof(PathSegments)].Address); } }
        public UArray<PropertyAccessPath> SrcPaths { get { return new UArray<PropertyAccessPath>(this[nameof(SrcPaths)].Address); } }
        public UArray<PropertyAccessPath> DestPaths { get { return new UArray<PropertyAccessPath>(this[nameof(DestPaths)].Address); } }
        public PropertyAccessCopyBatch CopyBatches { get { return this[nameof(CopyBatches)].As<PropertyAccessCopyBatch>(); } set { this["CopyBatches"] = value; } }
        public UArray<PropertyAccessIndirectionChain> SrcAccesses { get { return new UArray<PropertyAccessIndirectionChain>(this[nameof(SrcAccesses)].Address); } }
        public UArray<PropertyAccessIndirectionChain> DestAccesses { get { return new UArray<PropertyAccessIndirectionChain>(this[nameof(DestAccesses)].Address); } }
        public UArray<PropertyAccessIndirection> Indirections { get { return new UArray<PropertyAccessIndirection>(this[nameof(Indirections)].Address); } }
        public UArray<int> EventAccessIndices { get { return new UArray<int>(this[nameof(EventAccessIndices)].Address); } }
    }
    public class PropertyAccessIndirection : Object
    {
        public PropertyAccessIndirection(nint addr) : base(addr) { }
        public Object ArrayProperty { get { return this[nameof(ArrayProperty)]; } set { this[nameof(ArrayProperty)] = value; } }
        public Function Function { get { return this[nameof(Function)].As<Function>(); } set { this["Function"] = value; } }
        public int ReturnBufferSize { get { return this[nameof(ReturnBufferSize)].GetValue<int>(); } set { this[nameof(ReturnBufferSize)].SetValue<int>(value); } }
        public int ReturnBufferAlignment { get { return this[nameof(ReturnBufferAlignment)].GetValue<int>(); } set { this[nameof(ReturnBufferAlignment)].SetValue<int>(value); } }
        public int ArrayIndex { get { return this[nameof(ArrayIndex)].GetValue<int>(); } set { this[nameof(ArrayIndex)].SetValue<int>(value); } }
        public uint Offset { get { return this[nameof(Offset)].GetValue<uint>(); } set { this[nameof(Offset)].SetValue<uint>(value); } }
        public EPropertyAccessObjectType ObjectType { get { return (EPropertyAccessObjectType)this[nameof(ObjectType)].GetValue<int>(); } set { this[nameof(ObjectType)].SetValue<int>((int)value); } }
        public EPropertyAccessIndirectionType Type { get { return (EPropertyAccessIndirectionType)this[nameof(Type)].GetValue<int>(); } set { this[nameof(Type)].SetValue<int>((int)value); } }
    }
    public class PropertyAccessIndirectionChain : Object
    {
        public PropertyAccessIndirectionChain(nint addr) : base(addr) { }
        public Object Property { get { return this[nameof(Property)]; } set { this[nameof(Property)] = value; } }
        public int IndirectionStartIndex { get { return this[nameof(IndirectionStartIndex)].GetValue<int>(); } set { this[nameof(IndirectionStartIndex)].SetValue<int>(value); } }
        public int IndirectionEndIndex { get { return this[nameof(IndirectionEndIndex)].GetValue<int>(); } set { this[nameof(IndirectionEndIndex)].SetValue<int>(value); } }
        public int EventId { get { return this[nameof(EventId)].GetValue<int>(); } set { this[nameof(EventId)].SetValue<int>(value); } }
    }
    public class PropertyAccessCopyBatch : Object
    {
        public PropertyAccessCopyBatch(nint addr) : base(addr) { }
        public UArray<PropertyAccessCopy> Copies { get { return new UArray<PropertyAccessCopy>(this[nameof(Copies)].Address); } }
    }
    public class PropertyAccessCopy : Object
    {
        public PropertyAccessCopy(nint addr) : base(addr) { }
        public int AccessIndex { get { return this[nameof(AccessIndex)].GetValue<int>(); } set { this[nameof(AccessIndex)].SetValue<int>(value); } }
        public int DestAccessStartIndex { get { return this[nameof(DestAccessStartIndex)].GetValue<int>(); } set { this[nameof(DestAccessStartIndex)].SetValue<int>(value); } }
        public int DestAccessEndIndex { get { return this[nameof(DestAccessEndIndex)].GetValue<int>(); } set { this[nameof(DestAccessEndIndex)].SetValue<int>(value); } }
        public EPropertyAccessCopyType Type { get { return (EPropertyAccessCopyType)this[nameof(Type)].GetValue<int>(); } set { this[nameof(Type)].SetValue<int>((int)value); } }
    }
    public class PropertyAccessPath : Object
    {
        public PropertyAccessPath(nint addr) : base(addr) { }
        public int PathSegmentStartIndex { get { return this[nameof(PathSegmentStartIndex)].GetValue<int>(); } set { this[nameof(PathSegmentStartIndex)].SetValue<int>(value); } }
        public int PathSegmentCount { get { return this[nameof(PathSegmentCount)].GetValue<int>(); } set { this[nameof(PathSegmentCount)].SetValue<int>(value); } }
        public bool bHasEvents { get { return this[nameof(bHasEvents)].Flag; } set { this[nameof(bHasEvents)].Flag = value; } }
    }
    public class PropertyAccessSegment : Object
    {
        public PropertyAccessSegment(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Struct Struct { get { return this[nameof(Struct)].As<Struct>(); } set { this["Struct"] = value; } }
        public Object Property { get { return this[nameof(Property)]; } set { this[nameof(Property)] = value; } }
        public Function Function { get { return this[nameof(Function)].As<Function>(); } set { this["Function"] = value; } }
        public int ArrayIndex { get { return this[nameof(ArrayIndex)].GetValue<int>(); } set { this[nameof(ArrayIndex)].SetValue<int>(value); } }
        public ushort Flags { get { return this[nameof(Flags)].GetValue<ushort>(); } set { this[nameof(Flags)].SetValue<ushort>(value); } }
    }
}
