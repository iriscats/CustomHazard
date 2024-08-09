using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
namespace SDK.Script.NiagaraCoreSDK
{
    public class NiagaraMergeable : Object
    {
        public NiagaraMergeable(nint addr) : base(addr) { }
    }
    public class NiagaraDataInterfaceBase : NiagaraMergeable
    {
        public NiagaraDataInterfaceBase(nint addr) : base(addr) { }
    }
    public class NiagaraCompileHash : Object
    {
        public NiagaraCompileHash(nint addr) : base(addr) { }
        public UArray<byte> DataHash { get { return new UArray<byte>(this[nameof(DataHash)].Address); } }
    }
}
