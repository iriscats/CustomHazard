using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.ScriptPluginSDK
{
    public class ScriptBlueprint : Blueprint
    {
        public ScriptBlueprint(nint addr) : base(addr) { }
        public UArray<byte> ByteCode { get { return new UArray<byte>(this[nameof(ByteCode)].Address); } }
        public Object SourceCode { get { return this[nameof(SourceCode)]; } set { this[nameof(SourceCode)] = value; } }
    }
    public class ScriptBlueprintGeneratedClass : BlueprintGeneratedClass
    {
        public ScriptBlueprintGeneratedClass(nint addr) : base(addr) { }
        public UArray<byte> ByteCode { get { return new UArray<byte>(this[nameof(ByteCode)].Address); } }
        public Object SourceCode { get { return this[nameof(SourceCode)]; } set { this[nameof(SourceCode)] = value; } }
        public UArray<Property> ScriptProperties { get { return new UArray<Property>(this[nameof(ScriptProperties)].Address); } }
    }
    public class ScriptContext : Object
    {
        public ScriptContext(nint addr) : base(addr) { }
        public void CallScriptFunction(Object FunctionName) { Invoke(nameof(CallScriptFunction), FunctionName); }
    }
    public class ScriptContextComponent : ActorComponent
    {
        public ScriptContextComponent(nint addr) : base(addr) { }
        public void CallScriptFunction(Object FunctionName) { Invoke(nameof(CallScriptFunction), FunctionName); }
    }
    public class ScriptPluginComponent : ActorComponent
    {
        public ScriptPluginComponent(nint addr) : base(addr) { }
        public bool CallScriptFunction(Object FunctionName) { return Invoke<bool>(nameof(CallScriptFunction), FunctionName); }
    }
    public class ScriptTestActor : Actor
    {
        public ScriptTestActor(nint addr) : base(addr) { }
        public Object TestString { get { return this[nameof(TestString)]; } set { this[nameof(TestString)] = value; } }
        public float TestValue { get { return this[nameof(TestValue)].GetValue<float>(); } set { this[nameof(TestValue)].SetValue<float>(value); } }
        public bool TestBool { get { return this[nameof(TestBool)].Flag; } set { this[nameof(TestBool)].Flag = value; } }
        public float TestFunction(float InValue, float InFactor, bool bMultiply) { return Invoke<float>(nameof(TestFunction), InValue, InFactor, bMultiply); }
    }
}
