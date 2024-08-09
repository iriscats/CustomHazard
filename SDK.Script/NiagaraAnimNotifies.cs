using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.NiagaraSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.NiagaraAnimNotifiesSDK
{
    public class AnimNotify_PlayNiagaraEffect : AnimNotify
    {
        public AnimNotify_PlayNiagaraEffect(nint addr) : base(addr) { }
        public NiagaraSystem Template { get { return this[nameof(Template)].As<NiagaraSystem>(); } set { this["Template"] = value; } }
        public Vector LocationOffset { get { return this[nameof(LocationOffset)].As<Vector>(); } set { this["LocationOffset"] = value; } }
        public Rotator RotationOffset { get { return this[nameof(RotationOffset)].As<Rotator>(); } set { this["RotationOffset"] = value; } }
        public Vector Scale { get { return this[nameof(Scale)].As<Vector>(); } set { this["Scale"] = value; } }
        public bool bAbsoluteScale { get { return this[nameof(bAbsoluteScale)].Flag; } set { this[nameof(bAbsoluteScale)].Flag = value; } }
        public bool Attached { get { return this[nameof(Attached)].Flag; } set { this[nameof(Attached)].Flag = value; } }
        public Object SocketName { get { return this[nameof(SocketName)]; } set { this[nameof(SocketName)] = value; } }
        public FXSystemComponent GetSpawnedEffect() { return Invoke<FXSystemComponent>(nameof(GetSpawnedEffect)); }
    }
    public class AnimNotifyState_TimedNiagaraEffect : AnimNotifyState
    {
        public AnimNotifyState_TimedNiagaraEffect(nint addr) : base(addr) { }
        public NiagaraSystem Template { get { return this[nameof(Template)].As<NiagaraSystem>(); } set { this["Template"] = value; } }
        public Object SocketName { get { return this[nameof(SocketName)]; } set { this[nameof(SocketName)] = value; } }
        public Vector LocationOffset { get { return this[nameof(LocationOffset)].As<Vector>(); } set { this["LocationOffset"] = value; } }
        public Rotator RotationOffset { get { return this[nameof(RotationOffset)].As<Rotator>(); } set { this["RotationOffset"] = value; } }
        public bool bDestroyAtEnd { get { return this[nameof(bDestroyAtEnd)].Flag; } set { this[nameof(bDestroyAtEnd)].Flag = value; } }
        public FXSystemComponent GetSpawnedEffect(MeshComponent MeshComp) { return Invoke<FXSystemComponent>(nameof(GetSpawnedEffect), MeshComp); }
    }
    public class AnimNotifyState_TimedNiagaraEffectAdvanced : AnimNotifyState_TimedNiagaraEffect
    {
        public AnimNotifyState_TimedNiagaraEffectAdvanced(nint addr) : base(addr) { }
        public float GetNotifyProgress(MeshComponent MeshComp) { return Invoke<float>(nameof(GetNotifyProgress), MeshComp); }
    }
}
