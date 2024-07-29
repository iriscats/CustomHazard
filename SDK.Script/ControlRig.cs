using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.RigVMSDK;
using SDK.Script.AnimationCoreSDK;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
using SDK.Script.LevelSequenceSDK;
using SDK.Script.AnimGraphRuntimeSDK;
using SDK.Script.DeveloperSettingsSDK;
using SDK.Script.MovieSceneTracksSDK;
using SDK.Script.MovieSceneSDK;
namespace SDK.Script.ControlRigSDK
{
    public class ControlRig : Object
    {
        public ControlRig(nint addr) : base(addr) { }
        public ERigExecutionType ExecutionType { get { return (ERigExecutionType)this[nameof(ExecutionType)].GetValue<int>(); } set { this[nameof(ExecutionType)].SetValue<int>((int)value); } }
        public RigVM VM { get { return this[nameof(VM)].As<RigVM>(); } set { this["VM"] = value; } }
        public RigHierarchyContainer Hierarchy { get { return this[nameof(Hierarchy)].As<RigHierarchyContainer>(); } set { this["Hierarchy"] = value; } }
        public Object GizmoLibrary { get { return this[nameof(GizmoLibrary)]; } set { this[nameof(GizmoLibrary)] = value; } }
        public Object InputProperties { get { return this[nameof(InputProperties)]; } set { this[nameof(InputProperties)] = value; } }
        public Object OutputProperties { get { return this[nameof(OutputProperties)]; } set { this[nameof(OutputProperties)] = value; } }
        public ControlRigDrawContainer DrawContainer { get { return this[nameof(DrawContainer)].As<ControlRigDrawContainer>(); } set { this["DrawContainer"] = value; } }
        public AnimationDataSourceRegistry DataSourceRegistry { get { return this[nameof(DataSourceRegistry)].As<AnimationDataSourceRegistry>(); } set { this["DataSourceRegistry"] = value; } }
        public Array<Object> EventQueue { get { return new Array<Object>(this[nameof(EventQueue)].Address); } }
        public RigInfluenceMapPerEvent Influences { get { return this[nameof(Influences)].As<RigInfluenceMapPerEvent>(); } set { this["Influences"] = value; } }
        public ControlRig InteractionRig { get { return this[nameof(InteractionRig)].As<ControlRig>(); } set { this["InteractionRig"] = value; } }
        public Object InteractionRigClass { get { return this[nameof(InteractionRigClass)]; } set { this[nameof(InteractionRigClass)] = value; } }
        public Array<AssetUserData> AssetUserData { get { return new Array<AssetUserData>(this[nameof(AssetUserData)].Address); } }
        public void SetInteractionRigClass(Object InInteractionRigClass) { Invoke(nameof(SetInteractionRigClass), InInteractionRigClass); }
        public void SetInteractionRig(ControlRig InInteractionRig) { Invoke(nameof(SetInteractionRig), InInteractionRig); }
        public Object GetInteractionRigClass() { return Invoke<Object>(nameof(GetInteractionRigClass)); }
        public ControlRig GetInteractionRig() { return Invoke<ControlRig>(nameof(GetInteractionRig)); }
    }
    public class AdditiveControlRig : ControlRig
    {
        public AdditiveControlRig(nint addr) : base(addr) { }
    }
    public class ControlRigAnimInstance : AnimInstance
    {
        public ControlRigAnimInstance(nint addr) : base(addr) { }
    }
    public class ControlRigBlueprintGeneratedClass : BlueprintGeneratedClass
    {
        public ControlRigBlueprintGeneratedClass(nint addr) : base(addr) { }
    }
    public class ControlRigComponent : PrimitiveComponent
    {
        public ControlRigComponent(nint addr) : base(addr) { }
        public Object ControlRigClass { get { return this[nameof(ControlRigClass)]; } set { this[nameof(ControlRigClass)] = value; } }
        public Object OnPostInitializeDelegate { get { return this[nameof(OnPostInitializeDelegate)]; } set { this[nameof(OnPostInitializeDelegate)] = value; } }
        public Object OnPreSetupDelegate { get { return this[nameof(OnPreSetupDelegate)]; } set { this[nameof(OnPreSetupDelegate)] = value; } }
        public Object OnPostSetupDelegate { get { return this[nameof(OnPostSetupDelegate)]; } set { this[nameof(OnPostSetupDelegate)] = value; } }
        public Object OnPreUpdateDelegate { get { return this[nameof(OnPreUpdateDelegate)]; } set { this[nameof(OnPreUpdateDelegate)] = value; } }
        public Object OnPostUpdateDelegate { get { return this[nameof(OnPostUpdateDelegate)]; } set { this[nameof(OnPostUpdateDelegate)] = value; } }
        public Array<ControlRigComponentMappedElement> MappedElements { get { return new Array<ControlRigComponentMappedElement>(this[nameof(MappedElements)].Address); } }
        public bool bResetTransformBeforeTick { get { return this[nameof(bResetTransformBeforeTick)].Flag; } set { this[nameof(bResetTransformBeforeTick)].Flag = value; } }
        public bool bResetInitialsBeforeSetup { get { return this[nameof(bResetInitialsBeforeSetup)].Flag; } set { this[nameof(bResetInitialsBeforeSetup)].Flag = value; } }
        public bool bUpdateRigOnTick { get { return this[nameof(bUpdateRigOnTick)].Flag; } set { this[nameof(bUpdateRigOnTick)].Flag = value; } }
        public bool bUpdateInEditor { get { return this[nameof(bUpdateInEditor)].Flag; } set { this[nameof(bUpdateInEditor)].Flag = value; } }
        public bool bDrawBones { get { return this[nameof(bDrawBones)].Flag; } set { this[nameof(bDrawBones)].Flag = value; } }
        public bool bShowDebugDrawing { get { return this[nameof(bShowDebugDrawing)].Flag; } set { this[nameof(bShowDebugDrawing)].Flag = value; } }
        public ControlRig ControlRig { get { return this[nameof(ControlRig)].As<ControlRig>(); } set { this["ControlRig"] = value; } }
        public void Update(float DeltaTime) { Invoke(nameof(Update), DeltaTime); }
        public void SetMappedElements(Array<ControlRigComponentMappedElement> NewMappedElements) { Invoke(nameof(SetMappedElements), NewMappedElements); }
        public void SetInitialSpaceTransform(Object SpaceName, Transform InitialTransform, EControlRigComponentSpace Space) { Invoke(nameof(SetInitialSpaceTransform), SpaceName, InitialTransform, Space); }
        public void SetInitialBoneTransform(Object BoneName, Transform InitialTransform, EControlRigComponentSpace Space, bool bPropagateToChildren) { Invoke(nameof(SetInitialBoneTransform), BoneName, InitialTransform, Space, bPropagateToChildren); }
        public void SetControlVector2D(Object ControlName, Vector2D Value) { Invoke(nameof(SetControlVector2D), ControlName, Value); }
        public void SetControlTransform(Object ControlName, Transform Value, EControlRigComponentSpace Space) { Invoke(nameof(SetControlTransform), ControlName, Value, Space); }
        public void SetControlScale(Object ControlName, Vector Value, EControlRigComponentSpace Space) { Invoke(nameof(SetControlScale), ControlName, Value, Space); }
        public void SetControlRotator(Object ControlName, Rotator Value, EControlRigComponentSpace Space) { Invoke(nameof(SetControlRotator), ControlName, Value, Space); }
        public void SetControlPosition(Object ControlName, Vector Value, EControlRigComponentSpace Space) { Invoke(nameof(SetControlPosition), ControlName, Value, Space); }
        public void SetControlOffset(Object ControlName, Transform OffsetTransform, EControlRigComponentSpace Space) { Invoke(nameof(SetControlOffset), ControlName, OffsetTransform, Space); }
        public void SetControlInt(Object ControlName, int Value) { Invoke(nameof(SetControlInt), ControlName, Value); }
        public void SetControlFloat(Object ControlName, float Value) { Invoke(nameof(SetControlFloat), ControlName, Value); }
        public void SetControlBool(Object ControlName, bool Value) { Invoke(nameof(SetControlBool), ControlName, Value); }
        public void SetBoneTransform(Object BoneName, Transform Transform, EControlRigComponentSpace Space, float Weight, bool bPropagateToChildren) { Invoke(nameof(SetBoneTransform), BoneName, Transform, Space, Weight, bPropagateToChildren); }
        public void SetBoneInitialTransformsFromSkeletalMesh(SkeletalMesh InSkeletalMesh) { Invoke(nameof(SetBoneInitialTransformsFromSkeletalMesh), InSkeletalMesh); }
        public void OnPreUpdate(ControlRigComponent Component) { Invoke(nameof(OnPreUpdate), Component); }
        public void OnPreSetup(ControlRigComponent Component) { Invoke(nameof(OnPreSetup), Component); }
        public void OnPostUpdate(ControlRigComponent Component) { Invoke(nameof(OnPostUpdate), Component); }
        public void OnPostSetup(ControlRigComponent Component) { Invoke(nameof(OnPostSetup), Component); }
        public void OnPostInitialize(ControlRigComponent Component) { Invoke(nameof(OnPostInitialize), Component); }
        public void Initialize() { Invoke(nameof(Initialize)); }
        public Transform GetSpaceTransform(Object SpaceName, EControlRigComponentSpace Space) { return Invoke<Transform>(nameof(GetSpaceTransform), SpaceName, Space); }
        public Transform GetInitialSpaceTransform(Object SpaceName, EControlRigComponentSpace Space) { return Invoke<Transform>(nameof(GetInitialSpaceTransform), SpaceName, Space); }
        public Transform GetInitialBoneTransform(Object BoneName, EControlRigComponentSpace Space) { return Invoke<Transform>(nameof(GetInitialBoneTransform), BoneName, Space); }
        public Array<Object> GetElementNames(ERigElementType ElementType) { return Invoke<Array<Object>>(nameof(GetElementNames), ElementType); }
        public Vector2D GetControlVector2D(Object ControlName) { return Invoke<Vector2D>(nameof(GetControlVector2D), ControlName); }
        public Transform GetControlTransform(Object ControlName, EControlRigComponentSpace Space) { return Invoke<Transform>(nameof(GetControlTransform), ControlName, Space); }
        public Vector GetControlScale(Object ControlName, EControlRigComponentSpace Space) { return Invoke<Vector>(nameof(GetControlScale), ControlName, Space); }
        public Rotator GetControlRotator(Object ControlName, EControlRigComponentSpace Space) { return Invoke<Rotator>(nameof(GetControlRotator), ControlName, Space); }
        public ControlRig GetControlRig() { return Invoke<ControlRig>(nameof(GetControlRig)); }
        public Vector GetControlPosition(Object ControlName, EControlRigComponentSpace Space) { return Invoke<Vector>(nameof(GetControlPosition), ControlName, Space); }
        public Transform GetControlOffset(Object ControlName, EControlRigComponentSpace Space) { return Invoke<Transform>(nameof(GetControlOffset), ControlName, Space); }
        public int GetControlInt(Object ControlName) { return Invoke<int>(nameof(GetControlInt), ControlName); }
        public float GetControlFloat(Object ControlName) { return Invoke<float>(nameof(GetControlFloat), ControlName); }
        public bool GetControlBool(Object ControlName) { return Invoke<bool>(nameof(GetControlBool), ControlName); }
        public Transform GetBoneTransform(Object BoneName, EControlRigComponentSpace Space) { return Invoke<Transform>(nameof(GetBoneTransform), BoneName, Space); }
        public float GetAbsoluteTime() { return Invoke<float>(nameof(GetAbsoluteTime)); }
        public bool DoesElementExist(Object Name, ERigElementType ElementType) { return Invoke<bool>(nameof(DoesElementExist), Name, ElementType); }
        public void ClearMappedElements() { Invoke(nameof(ClearMappedElements)); }
        public void AddMappedSkeletalMesh(SkeletalMeshComponent SkeletalMeshComponent, Array<ControlRigComponentMappedBone> Bones, Array<ControlRigComponentMappedCurve> Curves) { Invoke(nameof(AddMappedSkeletalMesh), SkeletalMeshComponent, Bones, Curves); }
        public void AddMappedElements(Array<ControlRigComponentMappedElement> NewMappedElements) { Invoke(nameof(AddMappedElements), NewMappedElements); }
        public void AddMappedComponents(Array<ControlRigComponentMappedComponent> Components) { Invoke(nameof(AddMappedComponents), Components); }
        public void AddMappedCompleteSkeletalMesh(SkeletalMeshComponent SkeletalMeshComponent) { Invoke(nameof(AddMappedCompleteSkeletalMesh), SkeletalMeshComponent); }
    }
    public class ControlRigControlActor : Actor
    {
        public ControlRigControlActor(nint addr) : base(addr) { }
        public Actor ActorToTrack { get { return this[nameof(ActorToTrack)].As<Actor>(); } set { this["ActorToTrack"] = value; } }
        public Object ControlRigClass { get { return this[nameof(ControlRigClass)]; } set { this[nameof(ControlRigClass)] = value; } }
        public bool bRefreshOnTick { get { return this[nameof(bRefreshOnTick)].Flag; } set { this[nameof(bRefreshOnTick)].Flag = value; } }
        public bool bIsSelectable { get { return this[nameof(bIsSelectable)].Flag; } set { this[nameof(bIsSelectable)].Flag = value; } }
        public MaterialInterface MaterialOverride { get { return this[nameof(MaterialOverride)].As<MaterialInterface>(); } set { this["MaterialOverride"] = value; } }
        public Object ColorParameter { get { return this[nameof(ColorParameter)]; } set { this[nameof(ColorParameter)] = value; } }
        public bool bCastShadows { get { return this[nameof(bCastShadows)].Flag; } set { this[nameof(bCastShadows)].Flag = value; } }
        public SceneComponent ActorRootComponent { get { return this[nameof(ActorRootComponent)].As<SceneComponent>(); } set { this["ActorRootComponent"] = value; } }
        public ControlRig ControlRig { get { return this[nameof(ControlRig)].As<ControlRig>(); } set { this["ControlRig"] = value; } }
        public Array<Object> ControlNames { get { return new Array<Object>(this[nameof(ControlNames)].Address); } }
        public Array<Transform> GizmoTransforms { get { return new Array<Transform>(this[nameof(GizmoTransforms)].Address); } }
        public Array<StaticMeshComponent> Components { get { return new Array<StaticMeshComponent>(this[nameof(Components)].Address); } }
        public Array<MaterialInstanceDynamic> Materials { get { return new Array<MaterialInstanceDynamic>(this[nameof(Materials)].Address); } }
        public Object ColorParameterName { get { return this[nameof(ColorParameterName)]; } set { this[nameof(ColorParameterName)] = value; } }
        public void Refresh() { Invoke(nameof(Refresh)); }
        public void Clear() { Invoke(nameof(Clear)); }
    }
    public class ControlRigGizmoActor : Actor
    {
        public ControlRigGizmoActor(nint addr) : base(addr) { }
        public SceneComponent ActorRootComponent { get { return this[nameof(ActorRootComponent)].As<SceneComponent>(); } set { this["ActorRootComponent"] = value; } }
        public StaticMeshComponent StaticMeshComponent { get { return this[nameof(StaticMeshComponent)].As<StaticMeshComponent>(); } set { this["StaticMeshComponent"] = value; } }
        public uint ControlRigIndex { get { return this[nameof(ControlRigIndex)].GetValue<uint>(); } set { this[nameof(ControlRigIndex)].SetValue<uint>(value); } }
        public Object ControlName { get { return this[nameof(ControlName)]; } set { this[nameof(ControlName)] = value; } }
        public Object ColorParameterName { get { return this[nameof(ColorParameterName)]; } set { this[nameof(ColorParameterName)] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public bool bSelected { get { return this[nameof(bSelected)].Flag; } set { this[nameof(bSelected)].Flag = value; } }
        public bool bSelectable { get { return this[nameof(bSelectable)].Flag; } set { this[nameof(bSelectable)].Flag = value; } }
        public bool bHovered { get { return this[nameof(bHovered)].Flag; } set { this[nameof(bHovered)].Flag = value; } }
        public void SetSelected(bool bInSelected) { Invoke(nameof(SetSelected), bInSelected); }
        public void SetSelectable(bool bInSelectable) { Invoke(nameof(SetSelectable), bInSelectable); }
        public void SetHovered(bool bInHovered) { Invoke(nameof(SetHovered), bInHovered); }
        public void SetGlobalTransform(Transform InTransform) { Invoke(nameof(SetGlobalTransform), InTransform); }
        public void SetEnabled(bool bInEnabled) { Invoke(nameof(SetEnabled), bInEnabled); }
        public void OnTransformChanged(Transform NewTransform) { Invoke(nameof(OnTransformChanged), NewTransform); }
        public void OnSelectionChanged(bool bIsSelected) { Invoke(nameof(OnSelectionChanged), bIsSelected); }
        public void OnManipulatingChanged(bool bIsManipulating) { Invoke(nameof(OnManipulatingChanged), bIsManipulating); }
        public void OnHoveredChanged(bool bIsSelected) { Invoke(nameof(OnHoveredChanged), bIsSelected); }
        public void OnEnabledChanged(bool bIsEnabled) { Invoke(nameof(OnEnabledChanged), bIsEnabled); }
        public bool IsSelectedInEditor() { return Invoke<bool>(nameof(IsSelectedInEditor)); }
        public bool IsHovered() { return Invoke<bool>(nameof(IsHovered)); }
        public bool IsEnabled() { return Invoke<bool>(nameof(IsEnabled)); }
        public Transform GetGlobalTransform() { return Invoke<Transform>(nameof(GetGlobalTransform)); }
    }
    public class ControlRigGizmoLibrary : Object
    {
        public ControlRigGizmoLibrary(nint addr) : base(addr) { }
        public ControlRigGizmoDefinition DefaultGizmo { get { return this[nameof(DefaultGizmo)].As<ControlRigGizmoDefinition>(); } set { this["DefaultGizmo"] = value; } }
        public Object DefaultMaterial { get { return this[nameof(DefaultMaterial)]; } set { this[nameof(DefaultMaterial)] = value; } }
        public Object MaterialColorParameter { get { return this[nameof(MaterialColorParameter)]; } set { this[nameof(MaterialColorParameter)] = value; } }
        public Array<ControlRigGizmoDefinition> Gizmos { get { return new Array<ControlRigGizmoDefinition>(this[nameof(Gizmos)].Address); } }
    }
    public class ControlRigLayerInstance : AnimInstance
    {
        public ControlRigLayerInstance(nint addr) : base(addr) { }
    }
    public class ControlRigValidationPass : Object
    {
        public ControlRigValidationPass(nint addr) : base(addr) { }
    }
    public class ControlRigNumericalValidationPass : ControlRigValidationPass
    {
        public ControlRigNumericalValidationPass(nint addr) : base(addr) { }
        public bool bCheckControls { get { return this[nameof(bCheckControls)].Flag; } set { this[nameof(bCheckControls)].Flag = value; } }
        public bool bCheckBones { get { return this[nameof(bCheckBones)].Flag; } set { this[nameof(bCheckBones)].Flag = value; } }
        public bool bCheckCurves { get { return this[nameof(bCheckCurves)].Flag; } set { this[nameof(bCheckCurves)].Flag = value; } }
        public float TranslationPrecision { get { return this[nameof(TranslationPrecision)].GetValue<float>(); } set { this[nameof(TranslationPrecision)].SetValue<float>(value); } }
        public float RotationPrecision { get { return this[nameof(RotationPrecision)].GetValue<float>(); } set { this[nameof(RotationPrecision)].SetValue<float>(value); } }
        public float ScalePrecision { get { return this[nameof(ScalePrecision)].GetValue<float>(); } set { this[nameof(ScalePrecision)].SetValue<float>(value); } }
        public float CurvePrecision { get { return this[nameof(CurvePrecision)].GetValue<float>(); } set { this[nameof(CurvePrecision)].SetValue<float>(value); } }
        public Object EventNameA { get { return this[nameof(EventNameA)]; } set { this[nameof(EventNameA)] = value; } }
        public Object EventNameB { get { return this[nameof(EventNameB)]; } set { this[nameof(EventNameB)] = value; } }
        public RigPose pose { get { return this[nameof(pose)].As<RigPose>(); } set { this["pose"] = value; } }
    }
    public class ControlRigObjectHolder : Object
    {
        public ControlRigObjectHolder(nint addr) : base(addr) { }
        public Array<Object> Objects { get { return new Array<Object>(this[nameof(Objects)].Address); } }
    }
    public class ControlRigSequence : LevelSequence
    {
        public ControlRigSequence(nint addr) : base(addr) { }
        public Object LastExportedToAnimationSequence { get { return this[nameof(LastExportedToAnimationSequence)]; } set { this[nameof(LastExportedToAnimationSequence)] = value; } }
        public Object LastExportedUsingSkeletalMesh { get { return this[nameof(LastExportedUsingSkeletalMesh)]; } set { this[nameof(LastExportedUsingSkeletalMesh)] = value; } }
        public float LastExportedFrameRate { get { return this[nameof(LastExportedFrameRate)].GetValue<float>(); } set { this[nameof(LastExportedFrameRate)].SetValue<float>(value); } }
    }
    public class ControlRigSequencerAnimInstance : AnimSequencerInstance
    {
        public ControlRigSequencerAnimInstance(nint addr) : base(addr) { }
    }
    public class ControlRigSettings : DeveloperSettings
    {
        public ControlRigSettings(nint addr) : base(addr) { }
    }
    public class ControlRigValidator : Object
    {
        public ControlRigValidator(nint addr) : base(addr) { }
        public Array<ControlRigValidationPass> Passes { get { return new Array<ControlRigValidationPass>(this[nameof(Passes)].Address); } }
    }
    public class FKControlRig : ControlRig
    {
        public FKControlRig(nint addr) : base(addr) { }
        public Array<bool> IsControlActive { get { return new Array<bool>(this[nameof(IsControlActive)].Address); } }
        public EControlRigFKRigExecuteMode ApplyMode { get { return (EControlRigFKRigExecuteMode)this[nameof(ApplyMode)].GetValue<int>(); } set { this[nameof(ApplyMode)].SetValue<int>((int)value); } }
    }
    public class MovieSceneControlRigParameterSection : MovieSceneParameterSection
    {
        public MovieSceneControlRigParameterSection(nint addr) : base(addr) { }
        public ControlRig ControlRig { get { return this[nameof(ControlRig)].As<ControlRig>(); } set { this["ControlRig"] = value; } }
        public Object ControlRigClass { get { return this[nameof(ControlRigClass)]; } set { this[nameof(ControlRigClass)] = value; } }
        public Array<bool> ControlsMask { get { return new Array<bool>(this[nameof(ControlsMask)].Address); } }
        public MovieSceneTransformMask TransformMask { get { return this[nameof(TransformMask)].As<MovieSceneTransformMask>(); } set { this["TransformMask"] = value; } }
        public MovieSceneFloatChannel Weight { get { return this[nameof(Weight)].As<MovieSceneFloatChannel>(); } set { this["Weight"] = value; } }
        public Object ControlChannelMap { get { return this[nameof(ControlChannelMap)]; } set { this[nameof(ControlChannelMap)] = value; } }
        public Array<EnumParameterNameAndCurve> EnumParameterNamesAndCurves { get { return new Array<EnumParameterNameAndCurve>(this[nameof(EnumParameterNamesAndCurves)].Address); } }
        public Array<IntegerParameterNameAndCurve> IntegerParameterNamesAndCurves { get { return new Array<IntegerParameterNameAndCurve>(this[nameof(IntegerParameterNamesAndCurves)].Address); } }
    }
    public class MovieSceneControlRigParameterTrack : MovieSceneNameableTrack
    {
        public MovieSceneControlRigParameterTrack(nint addr) : base(addr) { }
        public ControlRig ControlRig { get { return this[nameof(ControlRig)].As<ControlRig>(); } set { this["ControlRig"] = value; } }
        public MovieSceneSection SectionToKey { get { return this[nameof(SectionToKey)].As<MovieSceneSection>(); } set { this["SectionToKey"] = value; } }
        public Array<MovieSceneSection> Sections { get { return new Array<MovieSceneSection>(this[nameof(Sections)].Address); } }
        public Object TrackName { get { return this[nameof(TrackName)]; } set { this[nameof(TrackName)] = value; } }
    }
    public enum EControlRigComponentMapDirection : int
    {
        Input = 0,
        Output = 1,
        EControlRigComponentMapDirection_MAX = 2,
    }
    public enum EControlRigComponentSpace : int
    {
        WorldSpace = 0,
        ActorSpace = 1,
        ComponentSpace = 2,
        RigSpace = 3,
        LocalSpace = 4,
        Max = 5,
    }
    public enum ERigExecutionType : int
    {
        Runtime = 0,
        Editing = 1,
        Max = 2,
    }
    public enum EBoneGetterSetterMode : int
    {
        LocalSpace = 0,
        GlobalSpace = 1,
        Max = 2,
    }
    public enum ETransformGetterType : int
    {
        Initial = 0,
        Current = 1,
        Max = 2,
    }
    public enum EControlRigClampSpatialMode : int
    {
        Plane = 0,
        Cylinder = 1,
        Sphere = 2,
        EControlRigClampSpatialMode_MAX = 3,
    }
    public enum ETransformSpaceMode : int
    {
        LocalSpace = 0,
        GlobalSpace = 1,
        BaseSpace = 2,
        BaseJoint = 3,
        Max = 4,
    }
    public enum EControlRigDrawSettings : int
    {
        Points = 0,
        Lines = 1,
        LineStrip = 2,
        DynamicMesh = 3,
        EControlRigDrawSettings_MAX = 4,
    }
    public enum EControlRigDrawHierarchyMode : int
    {
        Axes = 0,
        Max = 1,
    }
    public enum EControlRigAnimEasingType : int
    {
        Linear = 0,
        QuadraticEaseIn = 1,
        QuadraticEaseOut = 2,
        QuadraticEaseInOut = 3,
        CubicEaseIn = 4,
        CubicEaseOut = 5,
        CubicEaseInOut = 6,
        QuarticEaseIn = 7,
        QuarticEaseOut = 8,
        QuarticEaseInOut = 9,
        QuinticEaseIn = 10,
        QuinticEaseOut = 11,
        QuinticEaseInOut = 12,
        SineEaseIn = 13,
        SineEaseOut = 14,
        SineEaseInOut = 15,
        CircularEaseIn = 16,
        CircularEaseOut = 17,
        CircularEaseInOut = 18,
        ExponentialEaseIn = 19,
        ExponentialEaseOut = 20,
        ExponentialEaseInOut = 21,
        ElasticEaseIn = 22,
        ElasticEaseOut = 23,
        ElasticEaseInOut = 24,
        BackEaseIn = 25,
        BackEaseOut = 26,
        BackEaseInOut = 27,
        BounceEaseIn = 28,
        BounceEaseOut = 29,
        BounceEaseInOut = 30,
        EControlRigAnimEasingType_MAX = 31,
    }
    public enum EControlRigRotationOrder : int
    {
        XYZ = 0,
        XZY = 1,
        YXZ = 2,
        YZX = 3,
        ZXY = 4,
        ZYX = 5,
        EControlRigRotationOrder_MAX = 6,
    }
    public enum ECRSimPointIntegrateType : int
    {
        Verlet = 0,
        SemiExplicitEuler = 1,
        ECRSimPointIntegrateType_MAX = 2,
    }
    public enum ECRSimConstraintType : int
    {
        Distance = 0,
        DistanceFromA = 1,
        DistanceFromB = 2,
        Plane = 3,
        ECRSimConstraintType_MAX = 4,
    }
    public enum ECRSimPointForceType : int
    {
        Direction = 0,
        ECRSimPointForceType_MAX = 1,
    }
    public enum ECRSimSoftCollisionType : int
    {
        Plane = 0,
        Sphere = 1,
        Cone = 2,
        ECRSimSoftCollisionType_MAX = 3,
    }
    public enum EControlRigFKRigExecuteMode : int
    {
        Replace = 0,
        Additive = 1,
        Max = 2,
    }
    public enum ERigBoneType : int
    {
        Imported = 0,
        User = 1,
        ERigBoneType_MAX = 2,
    }
    public enum ERigControlAxis : int
    {
        X = 0,
        Y = 1,
        Z = 2,
        ERigControlAxis_MAX = 3,
    }
    public enum ERigControlValueType : int
    {
        Initial = 0,
        Current = 1,
        Minimum = 2,
        Maximum = 3,
        ERigControlValueType_MAX = 4,
    }
    public enum ERigControlType : int
    {
        Bool = 0,
        Float = 1,
        Integer = 2,
        Vector2D = 3,
        Position = 4,
        Scale = 5,
        Rotator = 6,
        Transform = 7,
        TransformNoScale = 8,
        EulerTransform = 9,
        ERigControlType_MAX = 10,
    }
    public enum ERigHierarchyImportMode : int
    {
        Append = 0,
        Replace = 1,
        ReplaceLocalTransform = 2,
        ReplaceGlobalTransform = 3,
        Max = 4,
    }
    public enum EControlRigSetKey : int
    {
        DoNotCare = 0,
        Always = 1,
        Never = 2,
        EControlRigSetKey_MAX = 3,
    }
    public enum ERigEvent : int
    {
        None = 0,
        RequestAutoKey = 1,
        Max = 2,
    }
    public enum ERigElementType : int
    {
        None = 0,
        Bone = 1,
        Space = 2,
        Control = 4,
        Curve = 8,
        All = 15,
        ERigElementType_MAX = 16,
    }
    public enum ERigSpaceType : int
    {
        Global = 0,
        Bone = 1,
        Control = 2,
        Space = 3,
        ERigSpaceType_MAX = 4,
    }
    public enum EAimMode : int
    {
        AimAtTarget = 0,
        OrientToTarget = 1,
        MAX = 2,
    }
    public enum EApplyTransformMode : int
    {
        Override = 0,
        Additive = 1,
        Max = 2,
    }
    public enum ERigUnitDebugPointMode : int
    {
        Point = 0,
        Vector = 1,
        Max = 2,
    }
    public enum ERigUnitDebugTransformMode : int
    {
        Point = 0,
        Axes = 1,
        Box = 2,
        Max = 3,
    }
    public enum EControlRigCurveAlignment : int
    {
        Front = 0,
        Stretched = 1,
        EControlRigCurveAlignment_MAX = 2,
    }
    public enum EControlRigVectorKind : int
    {
        Direction = 0,
        Location = 1,
        EControlRigVectorKind_MAX = 2,
    }
    public enum ERBFVectorDistanceType : int
    {
        Euclidean = 0,
        Manhattan = 1,
        ArcLength = 2,
        ERBFVectorDistanceType_MAX = 3,
    }
    public enum ERBFQuatDistanceType : int
    {
        Euclidean = 0,
        ArcLength = 1,
        SwingAngle = 2,
        TwistAngle = 3,
        ERBFQuatDistanceType_MAX = 4,
    }
    public enum ERBFKernelType : int
    {
        Gaussian = 0,
        Exponential = 1,
        Linear = 2,
        Cubic = 3,
        Quintic = 4,
        ERBFKernelType_MAX = 5,
    }
    public enum EControlRigModifyBoneMode : int
    {
        OverrideLocal = 0,
        OverrideGlobal = 1,
        AdditiveLocal = 2,
        AdditiveGlobal = 3,
        Max = 4,
    }
    public enum ERigUnitVisualDebugPointMode : int
    {
        Point = 0,
        Vector = 1,
        Max = 2,
    }
    public enum EControlRigState : int
    {
        Init = 0,
        Update = 1,
        Invalid = 2,
        EControlRigState_MAX = 3,
    }
    public class AnimationHierarchy : NodeHierarchyWithUserData
    {
        public AnimationHierarchy(nint addr) : base(addr) { }
        public Array<ConstraintNodeData> UserData { get { return new Array<ConstraintNodeData>(this[nameof(UserData)].Address); } }
    }
    public class ConstraintNodeData : Object
    {
        public ConstraintNodeData(nint addr) : base(addr) { }
        public Transform RelativeParent { get { return this[nameof(RelativeParent)].As<Transform>(); } set { this["RelativeParent"] = value; } }
        public ConstraintOffset ConstraintOffset { get { return this[nameof(ConstraintOffset)].As<ConstraintOffset>(); } set { this["ConstraintOffset"] = value; } }
        public Object LinkedNode { get { return this[nameof(LinkedNode)]; } set { this[nameof(LinkedNode)] = value; } }
        public Array<TransformConstraint> Constraints { get { return new Array<TransformConstraint>(this[nameof(Constraints)].Address); } }
    }
    public class AnimNode_ControlRigBase : AnimNode_CustomProperty
    {
        public AnimNode_ControlRigBase(nint addr) : base(addr) { }
        public PoseLink Source { get { return this[nameof(Source)].As<PoseLink>(); } set { this["Source"] = value; } }
        public Object ControlRigBoneMapping { get { return this[nameof(ControlRigBoneMapping)]; } set { this[nameof(ControlRigBoneMapping)] = value; } }
        public Object ControlRigCurveMapping { get { return this[nameof(ControlRigCurveMapping)]; } set { this[nameof(ControlRigCurveMapping)] = value; } }
        public Object InputToCurveMappingUIDs { get { return this[nameof(InputToCurveMappingUIDs)]; } set { this[nameof(InputToCurveMappingUIDs)] = value; } }
        public Object NodeMappingContainer { get { return this[nameof(NodeMappingContainer)]; } set { this[nameof(NodeMappingContainer)] = value; } }
        public ControlRigIOSettings InputSettings { get { return this[nameof(InputSettings)].As<ControlRigIOSettings>(); } set { this["InputSettings"] = value; } }
        public ControlRigIOSettings OutputSettings { get { return this[nameof(OutputSettings)].As<ControlRigIOSettings>(); } set { this["OutputSettings"] = value; } }
        public bool bExecute { get { return this[nameof(bExecute)].Flag; } set { this[nameof(bExecute)].Flag = value; } }
    }
    public class ControlRigIOSettings : Object
    {
        public ControlRigIOSettings(nint addr) : base(addr) { }
        public bool bUpdatePose { get { return this[nameof(bUpdatePose)].Flag; } set { this[nameof(bUpdatePose)].Flag = value; } }
        public bool bUpdateCurves { get { return this[nameof(bUpdateCurves)].Flag; } set { this[nameof(bUpdateCurves)].Flag = value; } }
    }
    public class AnimNode_ControlRig : AnimNode_ControlRigBase
    {
        public AnimNode_ControlRig(nint addr) : base(addr) { }
        public Object ControlRigClass { get { return this[nameof(ControlRigClass)]; } set { this[nameof(ControlRigClass)] = value; } }
        public ControlRig ControlRig { get { return this[nameof(ControlRig)].As<ControlRig>(); } set { this["ControlRig"] = value; } }
        public float alpha { get { return this[nameof(alpha)].GetValue<float>(); } set { this[nameof(alpha)].SetValue<float>(value); } }
        public EAnimAlphaInputType AlphaInputType { get { return (EAnimAlphaInputType)this[nameof(AlphaInputType)].GetValue<int>(); } set { this[nameof(AlphaInputType)].SetValue<int>((int)value); } }
        public bool bAlphaBoolEnabled { get { return this[nameof(bAlphaBoolEnabled)].Flag; } set { this[nameof(bAlphaBoolEnabled)].Flag = value; } }
        public bool bSetRefPoseFromSkeleton { get { return this[nameof(bSetRefPoseFromSkeleton)].Flag; } set { this[nameof(bSetRefPoseFromSkeleton)].Flag = value; } }
        public InputScaleBias AlphaScaleBias { get { return this[nameof(AlphaScaleBias)].As<InputScaleBias>(); } set { this["AlphaScaleBias"] = value; } }
        public InputAlphaBoolBlend AlphaBoolBlend { get { return this[nameof(AlphaBoolBlend)].As<InputAlphaBoolBlend>(); } set { this["AlphaBoolBlend"] = value; } }
        public Object AlphaCurveName { get { return this[nameof(AlphaCurveName)]; } set { this[nameof(AlphaCurveName)] = value; } }
        public InputScaleBiasClamp AlphaScaleBiasClamp { get { return this[nameof(AlphaScaleBiasClamp)].As<InputScaleBiasClamp>(); } set { this["AlphaScaleBiasClamp"] = value; } }
        public Object InputMapping { get { return this[nameof(InputMapping)]; } set { this[nameof(InputMapping)] = value; } }
        public Object OutputMapping { get { return this[nameof(OutputMapping)]; } set { this[nameof(OutputMapping)] = value; } }
        public int LODThreshold { get { return this[nameof(LODThreshold)].GetValue<int>(); } set { this[nameof(LODThreshold)].SetValue<int>(value); } }
    }
    public class AnimNode_ControlRig_ExternalSource : AnimNode_ControlRigBase
    {
        public AnimNode_ControlRig_ExternalSource(nint addr) : base(addr) { }
        public Object ControlRig { get { return this[nameof(ControlRig)]; } set { this[nameof(ControlRig)] = value; } }
    }
    public class ControlRigAnimInstanceProxy : AnimInstanceProxy
    {
        public ControlRigAnimInstanceProxy(nint addr) : base(addr) { }
    }
    public class ControlRigComponentMappedCurve : Object
    {
        public ControlRigComponentMappedCurve(nint addr) : base(addr) { }
        public Object Source { get { return this[nameof(Source)]; } set { this[nameof(Source)] = value; } }
        public Object Target { get { return this[nameof(Target)]; } set { this[nameof(Target)] = value; } }
    }
    public class ControlRigComponentMappedBone : Object
    {
        public ControlRigComponentMappedBone(nint addr) : base(addr) { }
        public Object Source { get { return this[nameof(Source)]; } set { this[nameof(Source)] = value; } }
        public Object Target { get { return this[nameof(Target)]; } set { this[nameof(Target)] = value; } }
    }
    public class ControlRigComponentMappedComponent : Object
    {
        public ControlRigComponentMappedComponent(nint addr) : base(addr) { }
        public SceneComponent Component { get { return this[nameof(Component)].As<SceneComponent>(); } set { this["Component"] = value; } }
        public Object ElementName { get { return this[nameof(ElementName)]; } set { this[nameof(ElementName)] = value; } }
        public ERigElementType ElementType { get { return (ERigElementType)this[nameof(ElementType)].GetValue<int>(); } set { this[nameof(ElementType)].SetValue<int>((int)value); } }
        public EControlRigComponentMapDirection Direction { get { return (EControlRigComponentMapDirection)this[nameof(Direction)].GetValue<int>(); } set { this[nameof(Direction)].SetValue<int>((int)value); } }
    }
    public class ControlRigComponentMappedElement : Object
    {
        public ControlRigComponentMappedElement(nint addr) : base(addr) { }
        public ComponentReference ComponentReference { get { return this[nameof(ComponentReference)].As<ComponentReference>(); } set { this["ComponentReference"] = value; } }
        public int TransformIndex { get { return this[nameof(TransformIndex)].GetValue<int>(); } set { this[nameof(TransformIndex)].SetValue<int>(value); } }
        public Object TransformName { get { return this[nameof(TransformName)]; } set { this[nameof(TransformName)] = value; } }
        public ERigElementType ElementType { get { return (ERigElementType)this[nameof(ElementType)].GetValue<int>(); } set { this[nameof(ElementType)].SetValue<int>((int)value); } }
        public Object ElementName { get { return this[nameof(ElementName)]; } set { this[nameof(ElementName)] = value; } }
        public EControlRigComponentMapDirection Direction { get { return (EControlRigComponentMapDirection)this[nameof(Direction)].GetValue<int>(); } set { this[nameof(Direction)].SetValue<int>((int)value); } }
        public Transform Offset { get { return this[nameof(Offset)].As<Transform>(); } set { this["Offset"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public EControlRigComponentSpace Space { get { return (EControlRigComponentSpace)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public SceneComponent SceneComponent { get { return this[nameof(SceneComponent)].As<SceneComponent>(); } set { this["SceneComponent"] = value; } }
        public int ElementIndex { get { return this[nameof(ElementIndex)].GetValue<int>(); } set { this[nameof(ElementIndex)].SetValue<int>(value); } }
        public int SubIndex { get { return this[nameof(SubIndex)].GetValue<int>(); } set { this[nameof(SubIndex)].SetValue<int>(value); } }
    }
    public class ControlRigExecuteContext : RigVMExecuteContext
    {
        public ControlRigExecuteContext(nint addr) : base(addr) { }
    }
    public class ControlRigDrawContainer : Object
    {
        public ControlRigDrawContainer(nint addr) : base(addr) { }
        public Array<ControlRigDrawInstruction> Instructions { get { return new Array<ControlRigDrawInstruction>(this[nameof(Instructions)].Address); } }
    }
    public class ControlRigDrawInstruction : Object
    {
        public ControlRigDrawInstruction(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public byte PrimitiveType { get { return this[nameof(PrimitiveType)].GetValue<byte>(); } set { this[nameof(PrimitiveType)].SetValue<byte>(value); } }
        public Array<Vector> Positions { get { return new Array<Vector>(this[nameof(Positions)].Address); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
    }
    public class ControlRigDrawInterface : ControlRigDrawContainer
    {
        public ControlRigDrawInterface(nint addr) : base(addr) { }
    }
    public class GizmoActorCreationParam : Object
    {
        public GizmoActorCreationParam(nint addr) : base(addr) { }
    }
    public class ControlRigGizmoDefinition : Object
    {
        public ControlRigGizmoDefinition(nint addr) : base(addr) { }
        public Object GizmoName { get { return this[nameof(GizmoName)]; } set { this[nameof(GizmoName)] = value; } }
        public Object StaticMesh { get { return this[nameof(StaticMesh)]; } set { this[nameof(StaticMesh)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
    }
    public class ControlRigLayerInstanceProxy : AnimInstanceProxy
    {
        public ControlRigLayerInstanceProxy(nint addr) : base(addr) { }
    }
    public class AnimNode_ControlRigInputPose : AnimNode_Base
    {
        public AnimNode_ControlRigInputPose(nint addr) : base(addr) { }
        public PoseLink InputPose { get { return this[nameof(InputPose)].As<PoseLink>(); } set { this["InputPose"] = value; } }
    }
    public class CRFourPointBezier : Object
    {
        public CRFourPointBezier(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public Vector C { get { return this[nameof(C)].As<Vector>(); } set { this["C"] = value; } }
        public Vector D { get { return this[nameof(D)].As<Vector>(); } set { this["D"] = value; } }
    }
    public class ControlRigSequenceObjectReferenceMap : Object
    {
        public ControlRigSequenceObjectReferenceMap(nint addr) : base(addr) { }
        public Array<Guid> BindingIds { get { return new Array<Guid>(this[nameof(BindingIds)].Address); } }
        public Array<ControlRigSequenceObjectReferences> References { get { return new Array<ControlRigSequenceObjectReferences>(this[nameof(References)].Address); } }
    }
    public class ControlRigSequenceObjectReferences : Object
    {
        public ControlRigSequenceObjectReferences(nint addr) : base(addr) { }
        public Array<ControlRigSequenceObjectReference> Array { get { return new Array<ControlRigSequenceObjectReference>(this[nameof(Array)].Address); } }
    }
    public class ControlRigSequenceObjectReference : Object
    {
        public ControlRigSequenceObjectReference(nint addr) : base(addr) { }
        public Object ControlRigClass { get { return this[nameof(ControlRigClass)]; } set { this[nameof(ControlRigClass)] = value; } }
    }
    public class ControlRigSequencerAnimInstanceProxy : AnimSequencerInstanceProxy
    {
        public ControlRigSequencerAnimInstanceProxy(nint addr) : base(addr) { }
    }
    public class ControlRigSettingsPerPinBool : Object
    {
        public ControlRigSettingsPerPinBool(nint addr) : base(addr) { }
        public Object Values { get { return this[nameof(Values)]; } set { this[nameof(Values)] = value; } }
    }
    public class ControlRigValidationContext : Object
    {
        public ControlRigValidationContext(nint addr) : base(addr) { }
    }
    public class CRSimContainer : Object
    {
        public CRSimContainer(nint addr) : base(addr) { }
        public float TimeStep { get { return this[nameof(TimeStep)].GetValue<float>(); } set { this[nameof(TimeStep)].SetValue<float>(value); } }
        public float AccumulatedTime { get { return this[nameof(AccumulatedTime)].GetValue<float>(); } set { this[nameof(AccumulatedTime)].SetValue<float>(value); } }
        public float TimeLeftForStep { get { return this[nameof(TimeLeftForStep)].GetValue<float>(); } set { this[nameof(TimeLeftForStep)].SetValue<float>(value); } }
    }
    public class CRSimLinearSpring : Object
    {
        public CRSimLinearSpring(nint addr) : base(addr) { }
        public int SubjectA { get { return this[nameof(SubjectA)].GetValue<int>(); } set { this[nameof(SubjectA)].SetValue<int>(value); } }
        public int SubjectB { get { return this[nameof(SubjectB)].GetValue<int>(); } set { this[nameof(SubjectB)].SetValue<int>(value); } }
        public float Coefficient { get { return this[nameof(Coefficient)].GetValue<float>(); } set { this[nameof(Coefficient)].SetValue<float>(value); } }
        public float Equilibrium { get { return this[nameof(Equilibrium)].GetValue<float>(); } set { this[nameof(Equilibrium)].SetValue<float>(value); } }
    }
    public class CRSimPoint : Object
    {
        public CRSimPoint(nint addr) : base(addr) { }
        public float Mass { get { return this[nameof(Mass)].GetValue<float>(); } set { this[nameof(Mass)].SetValue<float>(value); } }
        public float Size { get { return this[nameof(Size)].GetValue<float>(); } set { this[nameof(Size)].SetValue<float>(value); } }
        public float LinearDamping { get { return this[nameof(LinearDamping)].GetValue<float>(); } set { this[nameof(LinearDamping)].SetValue<float>(value); } }
        public float InheritMotion { get { return this[nameof(InheritMotion)].GetValue<float>(); } set { this[nameof(InheritMotion)].SetValue<float>(value); } }
        public Vector Position { get { return this[nameof(Position)].As<Vector>(); } set { this["Position"] = value; } }
        public Vector LinearVelocity { get { return this[nameof(LinearVelocity)].As<Vector>(); } set { this["LinearVelocity"] = value; } }
    }
    public class CRSimPointConstraint : Object
    {
        public CRSimPointConstraint(nint addr) : base(addr) { }
        public ECRSimConstraintType Type { get { return (ECRSimConstraintType)this[nameof(Type)].GetValue<int>(); } set { this[nameof(Type)].SetValue<int>((int)value); } }
        public int SubjectA { get { return this[nameof(SubjectA)].GetValue<int>(); } set { this[nameof(SubjectA)].SetValue<int>(value); } }
        public int SubjectB { get { return this[nameof(SubjectB)].GetValue<int>(); } set { this[nameof(SubjectB)].SetValue<int>(value); } }
        public Vector DataA { get { return this[nameof(DataA)].As<Vector>(); } set { this["DataA"] = value; } }
        public Vector DataB { get { return this[nameof(DataB)].As<Vector>(); } set { this["DataB"] = value; } }
    }
    public class CRSimPointContainer : CRSimContainer
    {
        public CRSimPointContainer(nint addr) : base(addr) { }
        public Array<CRSimPoint> Points { get { return new Array<CRSimPoint>(this[nameof(Points)].Address); } }
        public Array<CRSimLinearSpring> Springs { get { return new Array<CRSimLinearSpring>(this[nameof(Springs)].Address); } }
        public Array<CRSimPointForce> Forces { get { return new Array<CRSimPointForce>(this[nameof(Forces)].Address); } }
        public Array<CRSimSoftCollision> CollisionVolumes { get { return new Array<CRSimSoftCollision>(this[nameof(CollisionVolumes)].Address); } }
        public Array<CRSimPointConstraint> Constraints { get { return new Array<CRSimPointConstraint>(this[nameof(Constraints)].Address); } }
        public Array<CRSimPoint> PreviousStep { get { return new Array<CRSimPoint>(this[nameof(PreviousStep)].Address); } }
    }
    public class CRSimSoftCollision : Object
    {
        public CRSimSoftCollision(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public ECRSimSoftCollisionType ShapeType { get { return (ECRSimSoftCollisionType)this[nameof(ShapeType)].GetValue<int>(); } set { this[nameof(ShapeType)].SetValue<int>((int)value); } }
        public float MinimumDistance { get { return this[nameof(MinimumDistance)].GetValue<float>(); } set { this[nameof(MinimumDistance)].SetValue<float>(value); } }
        public float MaximumDistance { get { return this[nameof(MaximumDistance)].GetValue<float>(); } set { this[nameof(MaximumDistance)].SetValue<float>(value); } }
        public EControlRigAnimEasingType FalloffType { get { return (EControlRigAnimEasingType)this[nameof(FalloffType)].GetValue<int>(); } set { this[nameof(FalloffType)].SetValue<int>((int)value); } }
        public float Coefficient { get { return this[nameof(Coefficient)].GetValue<float>(); } set { this[nameof(Coefficient)].SetValue<float>(value); } }
        public bool bInverted { get { return this[nameof(bInverted)].Flag; } set { this[nameof(bInverted)].Flag = value; } }
    }
    public class CRSimPointForce : Object
    {
        public CRSimPointForce(nint addr) : base(addr) { }
        public ECRSimPointForceType ForceType { get { return (ECRSimPointForceType)this[nameof(ForceType)].GetValue<int>(); } set { this[nameof(ForceType)].SetValue<int>((int)value); } }
        public Vector Vector { get { return this[nameof(Vector)].As<Vector>(); } set { this["Vector"] = value; } }
        public float Coefficient { get { return this[nameof(Coefficient)].GetValue<float>(); } set { this[nameof(Coefficient)].SetValue<float>(value); } }
        public bool bNormalize { get { return this[nameof(bNormalize)].Flag; } set { this[nameof(bNormalize)].Flag = value; } }
    }
    public class MovieSceneControlRigInstanceData : MovieSceneSequenceInstanceData
    {
        public MovieSceneControlRigInstanceData(nint addr) : base(addr) { }
        public bool bAdditive { get { return this[nameof(bAdditive)].Flag; } set { this[nameof(bAdditive)].Flag = value; } }
        public bool bApplyBoneFilter { get { return this[nameof(bApplyBoneFilter)].Flag; } set { this[nameof(bApplyBoneFilter)].Flag = value; } }
        public InputBlendPose BoneFilter { get { return this[nameof(BoneFilter)].As<InputBlendPose>(); } set { this["BoneFilter"] = value; } }
        public MovieSceneFloatChannel Weight { get { return this[nameof(Weight)].As<MovieSceneFloatChannel>(); } set { this["Weight"] = value; } }
        public MovieSceneEvaluationOperand Operand { get { return this[nameof(Operand)].As<MovieSceneEvaluationOperand>(); } set { this["Operand"] = value; } }
    }
    public class ChannelMapInfo : Object
    {
        public ChannelMapInfo(nint addr) : base(addr) { }
        public int ControlIndex { get { return this[nameof(ControlIndex)].GetValue<int>(); } set { this[nameof(ControlIndex)].SetValue<int>(value); } }
        public int TotalChannelIndex { get { return this[nameof(TotalChannelIndex)].GetValue<int>(); } set { this[nameof(TotalChannelIndex)].SetValue<int>(value); } }
        public int ChannelIndex { get { return this[nameof(ChannelIndex)].GetValue<int>(); } set { this[nameof(ChannelIndex)].SetValue<int>(value); } }
        public int ParentControlIndex { get { return this[nameof(ParentControlIndex)].GetValue<int>(); } set { this[nameof(ParentControlIndex)].SetValue<int>(value); } }
        public Object ChannelTypeName { get { return this[nameof(ChannelTypeName)]; } set { this[nameof(ChannelTypeName)] = value; } }
    }
    public class IntegerParameterNameAndCurve : Object
    {
        public IntegerParameterNameAndCurve(nint addr) : base(addr) { }
        public Object ParameterName { get { return this[nameof(ParameterName)]; } set { this[nameof(ParameterName)] = value; } }
        public MovieSceneIntegerChannel ParameterCurve { get { return this[nameof(ParameterCurve)].As<MovieSceneIntegerChannel>(); } set { this["ParameterCurve"] = value; } }
    }
    public class EnumParameterNameAndCurve : Object
    {
        public EnumParameterNameAndCurve(nint addr) : base(addr) { }
        public Object ParameterName { get { return this[nameof(ParameterName)]; } set { this[nameof(ParameterName)] = value; } }
        public MovieSceneByteChannel ParameterCurve { get { return this[nameof(ParameterCurve)].As<MovieSceneByteChannel>(); } set { this["ParameterCurve"] = value; } }
    }
    public class MovieSceneControlRigParameterTemplate : MovieSceneParameterSectionTemplate
    {
        public MovieSceneControlRigParameterTemplate(nint addr) : base(addr) { }
        public Array<EnumParameterNameAndCurve> Enums { get { return new Array<EnumParameterNameAndCurve>(this[nameof(Enums)].Address); } }
        public Array<IntegerParameterNameAndCurve> Integers { get { return new Array<IntegerParameterNameAndCurve>(this[nameof(Integers)].Address); } }
    }
    public class RigBoneHierarchy : Object
    {
        public RigBoneHierarchy(nint addr) : base(addr) { }
        public Array<RigBone> Bones { get { return new Array<RigBone>(this[nameof(Bones)].Address); } }
        public Object NameToIndexMapping { get { return this[nameof(NameToIndexMapping)]; } set { this[nameof(NameToIndexMapping)] = value; } }
        public Array<Object> Selection { get { return new Array<Object>(this[nameof(Selection)].Address); } }
    }
    public class RigElement : Object
    {
        public RigElement(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public int Index { get { return this[nameof(Index)].GetValue<int>(); } set { this[nameof(Index)].SetValue<int>(value); } }
    }
    public class RigBone : RigElement
    {
        public RigBone(nint addr) : base(addr) { }
        public Object ParentName { get { return this[nameof(ParentName)]; } set { this[nameof(ParentName)] = value; } }
        public int ParentIndex { get { return this[nameof(ParentIndex)].GetValue<int>(); } set { this[nameof(ParentIndex)].SetValue<int>(value); } }
        public Transform InitialTransform { get { return this[nameof(InitialTransform)].As<Transform>(); } set { this["InitialTransform"] = value; } }
        public Transform GlobalTransform { get { return this[nameof(GlobalTransform)].As<Transform>(); } set { this["GlobalTransform"] = value; } }
        public Transform LocalTransform { get { return this[nameof(LocalTransform)].As<Transform>(); } set { this["LocalTransform"] = value; } }
        public Array<int> Dependents { get { return new Array<int>(this[nameof(Dependents)].Address); } }
        public ERigBoneType Type { get { return (ERigBoneType)this[nameof(Type)].GetValue<int>(); } set { this[nameof(Type)].SetValue<int>((int)value); } }
    }
    public class RigControlHierarchy : Object
    {
        public RigControlHierarchy(nint addr) : base(addr) { }
        public Array<RigControl> Controls { get { return new Array<RigControl>(this[nameof(Controls)].Address); } }
        public Object NameToIndexMapping { get { return this[nameof(NameToIndexMapping)]; } set { this[nameof(NameToIndexMapping)] = value; } }
        public Array<Object> Selection { get { return new Array<Object>(this[nameof(Selection)].Address); } }
    }
    public class RigControl : RigElement
    {
        public RigControl(nint addr) : base(addr) { }
        public ERigControlType ControlType { get { return (ERigControlType)this[nameof(ControlType)].GetValue<int>(); } set { this[nameof(ControlType)].SetValue<int>((int)value); } }
        public Object DisplayName { get { return this[nameof(DisplayName)]; } set { this[nameof(DisplayName)] = value; } }
        public Object ParentName { get { return this[nameof(ParentName)]; } set { this[nameof(ParentName)] = value; } }
        public int ParentIndex { get { return this[nameof(ParentIndex)].GetValue<int>(); } set { this[nameof(ParentIndex)].SetValue<int>(value); } }
        public Object SpaceName { get { return this[nameof(SpaceName)]; } set { this[nameof(SpaceName)] = value; } }
        public int SpaceIndex { get { return this[nameof(SpaceIndex)].GetValue<int>(); } set { this[nameof(SpaceIndex)].SetValue<int>(value); } }
        public Transform OffsetTransform { get { return this[nameof(OffsetTransform)].As<Transform>(); } set { this["OffsetTransform"] = value; } }
        public RigControlValue InitialValue { get { return this[nameof(InitialValue)].As<RigControlValue>(); } set { this["InitialValue"] = value; } }
        public RigControlValue Value { get { return this[nameof(Value)].As<RigControlValue>(); } set { this["Value"] = value; } }
        public ERigControlAxis PrimaryAxis { get { return (ERigControlAxis)this[nameof(PrimaryAxis)].GetValue<int>(); } set { this[nameof(PrimaryAxis)].SetValue<int>((int)value); } }
        public bool bIsCurve { get { return this[nameof(bIsCurve)].Flag; } set { this[nameof(bIsCurve)].Flag = value; } }
        public bool bAnimatable { get { return this[nameof(bAnimatable)].Flag; } set { this[nameof(bAnimatable)].Flag = value; } }
        public bool bLimitTranslation { get { return this[nameof(bLimitTranslation)].Flag; } set { this[nameof(bLimitTranslation)].Flag = value; } }
        public bool bLimitRotation { get { return this[nameof(bLimitRotation)].Flag; } set { this[nameof(bLimitRotation)].Flag = value; } }
        public bool bLimitScale { get { return this[nameof(bLimitScale)].Flag; } set { this[nameof(bLimitScale)].Flag = value; } }
        public bool bDrawLimits { get { return this[nameof(bDrawLimits)].Flag; } set { this[nameof(bDrawLimits)].Flag = value; } }
        public RigControlValue MinimumValue { get { return this[nameof(MinimumValue)].As<RigControlValue>(); } set { this["MinimumValue"] = value; } }
        public RigControlValue MaximumValue { get { return this[nameof(MaximumValue)].As<RigControlValue>(); } set { this["MaximumValue"] = value; } }
        public bool bGizmoEnabled { get { return this[nameof(bGizmoEnabled)].Flag; } set { this[nameof(bGizmoEnabled)].Flag = value; } }
        public bool bGizmoVisible { get { return this[nameof(bGizmoVisible)].Flag; } set { this[nameof(bGizmoVisible)].Flag = value; } }
        public Object GizmoName { get { return this[nameof(GizmoName)]; } set { this[nameof(GizmoName)] = value; } }
        public Transform GizmoTransform { get { return this[nameof(GizmoTransform)].As<Transform>(); } set { this["GizmoTransform"] = value; } }
        public LinearColor GizmoColor { get { return this[nameof(GizmoColor)].As<LinearColor>(); } set { this["GizmoColor"] = value; } }
        public Array<int> Dependents { get { return new Array<int>(this[nameof(Dependents)].Address); } }
        public bool bIsTransientControl { get { return this[nameof(bIsTransientControl)].Flag; } set { this[nameof(bIsTransientControl)].Flag = value; } }
        public Enum ControlEnum { get { return this[nameof(ControlEnum)].As<Enum>(); } set { this["ControlEnum"] = value; } }
    }
    public class RigControlValue : Object
    {
        public RigControlValue(nint addr) : base(addr) { }
        public RigControlValueStorage FloatStorage { get { return this[nameof(FloatStorage)].As<RigControlValueStorage>(); } set { this["FloatStorage"] = value; } }
        public Transform Storage { get { return this[nameof(Storage)].As<Transform>(); } set { this["Storage"] = value; } }
    }
    public class RigControlValueStorage : Object
    {
        public RigControlValueStorage(nint addr) : base(addr) { }
        public float Float00 { get { return this[nameof(Float00)].GetValue<float>(); } set { this[nameof(Float00)].SetValue<float>(value); } }
        public float Float01 { get { return this[nameof(Float01)].GetValue<float>(); } set { this[nameof(Float01)].SetValue<float>(value); } }
        public float Float02 { get { return this[nameof(Float02)].GetValue<float>(); } set { this[nameof(Float02)].SetValue<float>(value); } }
        public float Float03 { get { return this[nameof(Float03)].GetValue<float>(); } set { this[nameof(Float03)].SetValue<float>(value); } }
        public float Float10 { get { return this[nameof(Float10)].GetValue<float>(); } set { this[nameof(Float10)].SetValue<float>(value); } }
        public float Float11 { get { return this[nameof(Float11)].GetValue<float>(); } set { this[nameof(Float11)].SetValue<float>(value); } }
        public float Float12 { get { return this[nameof(Float12)].GetValue<float>(); } set { this[nameof(Float12)].SetValue<float>(value); } }
        public float Float13 { get { return this[nameof(Float13)].GetValue<float>(); } set { this[nameof(Float13)].SetValue<float>(value); } }
        public float Float20 { get { return this[nameof(Float20)].GetValue<float>(); } set { this[nameof(Float20)].SetValue<float>(value); } }
        public float Float21 { get { return this[nameof(Float21)].GetValue<float>(); } set { this[nameof(Float21)].SetValue<float>(value); } }
        public float Float22 { get { return this[nameof(Float22)].GetValue<float>(); } set { this[nameof(Float22)].SetValue<float>(value); } }
        public float Float23 { get { return this[nameof(Float23)].GetValue<float>(); } set { this[nameof(Float23)].SetValue<float>(value); } }
        public float Float30 { get { return this[nameof(Float30)].GetValue<float>(); } set { this[nameof(Float30)].SetValue<float>(value); } }
        public float Float31 { get { return this[nameof(Float31)].GetValue<float>(); } set { this[nameof(Float31)].SetValue<float>(value); } }
        public float Float32 { get { return this[nameof(Float32)].GetValue<float>(); } set { this[nameof(Float32)].SetValue<float>(value); } }
        public float Float33 { get { return this[nameof(Float33)].GetValue<float>(); } set { this[nameof(Float33)].SetValue<float>(value); } }
        public bool bValid { get { return this[nameof(bValid)].Flag; } set { this[nameof(bValid)].Flag = value; } }
    }
    public class RigCurveContainer : Object
    {
        public RigCurveContainer(nint addr) : base(addr) { }
        public Array<RigCurve> Curves { get { return new Array<RigCurve>(this[nameof(Curves)].Address); } }
        public Object NameToIndexMapping { get { return this[nameof(NameToIndexMapping)]; } set { this[nameof(NameToIndexMapping)] = value; } }
        public Array<Object> Selection { get { return new Array<Object>(this[nameof(Selection)].Address); } }
    }
    public class RigCurve : RigElement
    {
        public RigCurve(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
    }
    public class CachedRigElement : Object
    {
        public CachedRigElement(nint addr) : base(addr) { }
        public RigElementKey Key { get { return this[nameof(Key)].As<RigElementKey>(); } set { this["Key"] = value; } }
        public ushort Index { get { return this[nameof(Index)].GetValue<ushort>(); } set { this[nameof(Index)].SetValue<ushort>(value); } }
        public int ContainerVersion { get { return this[nameof(ContainerVersion)].GetValue<int>(); } set { this[nameof(ContainerVersion)].SetValue<int>(value); } }
    }
    public class RigElementKey : Object
    {
        public RigElementKey(nint addr) : base(addr) { }
        public ERigElementType Type { get { return (ERigElementType)this[nameof(Type)].GetValue<int>(); } set { this[nameof(Type)].SetValue<int>((int)value); } }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
    }
    public class RigHierarchyRef : Object
    {
        public RigHierarchyRef(nint addr) : base(addr) { }
    }
    public class RigHierarchyContainer : Object
    {
        public RigHierarchyContainer(nint addr) : base(addr) { }
        public RigBoneHierarchy BoneHierarchy { get { return this[nameof(BoneHierarchy)].As<RigBoneHierarchy>(); } set { this["BoneHierarchy"] = value; } }
        public RigSpaceHierarchy SpaceHierarchy { get { return this[nameof(SpaceHierarchy)].As<RigSpaceHierarchy>(); } set { this["SpaceHierarchy"] = value; } }
        public RigControlHierarchy ControlHierarchy { get { return this[nameof(ControlHierarchy)].As<RigControlHierarchy>(); } set { this["ControlHierarchy"] = value; } }
        public RigCurveContainer CurveContainer { get { return this[nameof(CurveContainer)].As<RigCurveContainer>(); } set { this["CurveContainer"] = value; } }
        public int Version { get { return this[nameof(Version)].GetValue<int>(); } set { this[nameof(Version)].SetValue<int>(value); } }
    }
    public class RigSpaceHierarchy : Object
    {
        public RigSpaceHierarchy(nint addr) : base(addr) { }
        public Array<RigSpace> Spaces { get { return new Array<RigSpace>(this[nameof(Spaces)].Address); } }
        public Object NameToIndexMapping { get { return this[nameof(NameToIndexMapping)]; } set { this[nameof(NameToIndexMapping)] = value; } }
        public Array<Object> Selection { get { return new Array<Object>(this[nameof(Selection)].Address); } }
    }
    public class RigSpace : RigElement
    {
        public RigSpace(nint addr) : base(addr) { }
        public ERigSpaceType SpaceType { get { return (ERigSpaceType)this[nameof(SpaceType)].GetValue<int>(); } set { this[nameof(SpaceType)].SetValue<int>((int)value); } }
        public Object ParentName { get { return this[nameof(ParentName)]; } set { this[nameof(ParentName)] = value; } }
        public int ParentIndex { get { return this[nameof(ParentIndex)].GetValue<int>(); } set { this[nameof(ParentIndex)].SetValue<int>(value); } }
        public Transform InitialTransform { get { return this[nameof(InitialTransform)].As<Transform>(); } set { this["InitialTransform"] = value; } }
        public Transform LocalTransform { get { return this[nameof(LocalTransform)].As<Transform>(); } set { this["LocalTransform"] = value; } }
    }
    public class RigMirrorSettings : Object
    {
        public RigMirrorSettings(nint addr) : base(addr) { }
        public byte MirrorAxis { get { return this[nameof(MirrorAxis)].GetValue<byte>(); } set { this[nameof(MirrorAxis)].SetValue<byte>(value); } }
        public byte AxisToFlip { get { return this[nameof(AxisToFlip)].GetValue<byte>(); } set { this[nameof(AxisToFlip)].SetValue<byte>(value); } }
        public Object OldName { get { return this[nameof(OldName)]; } set { this[nameof(OldName)] = value; } }
        public Object NewName { get { return this[nameof(NewName)]; } set { this[nameof(NewName)] = value; } }
    }
    public class RigHierarchyCopyPasteContent : Object
    {
        public RigHierarchyCopyPasteContent(nint addr) : base(addr) { }
        public Array<ERigElementType> Types { get { return new Array<ERigElementType>(this[nameof(Types)].Address); } }
        public Array<Object> Contents { get { return new Array<Object>(this[nameof(Contents)].Address); } }
        public Array<Transform> LocalTransforms { get { return new Array<Transform>(this[nameof(LocalTransforms)].Address); } }
        public Array<Transform> GlobalTransforms { get { return new Array<Transform>(this[nameof(GlobalTransforms)].Address); } }
    }
    public class RigEventContext : Object
    {
        public RigEventContext(nint addr) : base(addr) { }
    }
    public class RigElementKeyCollection : Object
    {
        public RigElementKeyCollection(nint addr) : base(addr) { }
    }
    public class RigControlModifiedContext : Object
    {
        public RigControlModifiedContext(nint addr) : base(addr) { }
    }
    public class RigPose : Object
    {
        public RigPose(nint addr) : base(addr) { }
        public Array<RigPoseElement> Elements { get { return new Array<RigPoseElement>(this[nameof(Elements)].Address); } }
    }
    public class RigPoseElement : Object
    {
        public RigPoseElement(nint addr) : base(addr) { }
        public CachedRigElement Index { get { return this[nameof(Index)].As<CachedRigElement>(); } set { this["Index"] = value; } }
        public Transform GlobalTransform { get { return this[nameof(GlobalTransform)].As<Transform>(); } set { this["GlobalTransform"] = value; } }
        public Transform LocalTransform { get { return this[nameof(LocalTransform)].As<Transform>(); } set { this["LocalTransform"] = value; } }
        public float CurveValue { get { return this[nameof(CurveValue)].GetValue<float>(); } set { this[nameof(CurveValue)].SetValue<float>(value); } }
    }
    public class RigInfluenceMapPerEvent : Object
    {
        public RigInfluenceMapPerEvent(nint addr) : base(addr) { }
        public Array<RigInfluenceMap> Maps { get { return new Array<RigInfluenceMap>(this[nameof(Maps)].Address); } }
        public Object EventToIndex { get { return this[nameof(EventToIndex)]; } set { this[nameof(EventToIndex)] = value; } }
    }
    public class RigInfluenceMap : Object
    {
        public RigInfluenceMap(nint addr) : base(addr) { }
        public Object EventName { get { return this[nameof(EventName)]; } set { this[nameof(EventName)] = value; } }
        public Array<RigInfluenceEntry> Entries { get { return new Array<RigInfluenceEntry>(this[nameof(Entries)].Address); } }
        public Object KeyToIndex { get { return this[nameof(KeyToIndex)]; } set { this[nameof(KeyToIndex)] = value; } }
    }
    public class RigInfluenceEntry : Object
    {
        public RigInfluenceEntry(nint addr) : base(addr) { }
        public RigElementKey Source { get { return this[nameof(Source)].As<RigElementKey>(); } set { this["Source"] = value; } }
        public Array<RigElementKey> AffectedList { get { return new Array<RigElementKey>(this[nameof(AffectedList)].Address); } }
    }
    public class RigInfluenceEntryModifier : Object
    {
        public RigInfluenceEntryModifier(nint addr) : base(addr) { }
        public Array<RigElementKey> AffectedList { get { return new Array<RigElementKey>(this[nameof(AffectedList)].Address); } }
    }
    public class RigUnit : RigVMStruct
    {
        public RigUnit(nint addr) : base(addr) { }
    }
    public class RigUnitMutable : RigUnit
    {
        public RigUnitMutable(nint addr) : base(addr) { }
        public ControlRigExecuteContext ExecuteContext { get { return this[nameof(ExecuteContext)].As<ControlRigExecuteContext>(); } set { this["ExecuteContext"] = value; } }
    }
    public class RigUnit_SimBase : RigUnit
    {
        public RigUnit_SimBase(nint addr) : base(addr) { }
    }
    public class RigUnit_AccumulateVectorRange : RigUnit_SimBase
    {
        public RigUnit_AccumulateVectorRange(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public Vector Minimum { get { return this[nameof(Minimum)].As<Vector>(); } set { this["Minimum"] = value; } }
        public Vector Maximum { get { return this[nameof(Maximum)].As<Vector>(); } set { this["Maximum"] = value; } }
        public Vector AccumulatedMinimum { get { return this[nameof(AccumulatedMinimum)].As<Vector>(); } set { this["AccumulatedMinimum"] = value; } }
        public Vector AccumulatedMaximum { get { return this[nameof(AccumulatedMaximum)].As<Vector>(); } set { this["AccumulatedMaximum"] = value; } }
    }
    public class RigUnit_AccumulateFloatRange : RigUnit_SimBase
    {
        public RigUnit_AccumulateFloatRange(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public float AccumulatedMinimum { get { return this[nameof(AccumulatedMinimum)].GetValue<float>(); } set { this[nameof(AccumulatedMinimum)].SetValue<float>(value); } }
        public float AccumulatedMaximum { get { return this[nameof(AccumulatedMaximum)].GetValue<float>(); } set { this[nameof(AccumulatedMaximum)].SetValue<float>(value); } }
    }
    public class RigUnit_AccumulateTransformLerp : RigUnit_SimBase
    {
        public RigUnit_AccumulateTransformLerp(nint addr) : base(addr) { }
        public Transform TargetValue { get { return this[nameof(TargetValue)].As<Transform>(); } set { this["TargetValue"] = value; } }
        public Transform InitialValue { get { return this[nameof(InitialValue)].As<Transform>(); } set { this["InitialValue"] = value; } }
        public float Blend { get { return this[nameof(Blend)].GetValue<float>(); } set { this[nameof(Blend)].SetValue<float>(value); } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public Transform AccumulatedValue { get { return this[nameof(AccumulatedValue)].As<Transform>(); } set { this["AccumulatedValue"] = value; } }
    }
    public class RigUnit_AccumulateQuatLerp : RigUnit_SimBase
    {
        public RigUnit_AccumulateQuatLerp(nint addr) : base(addr) { }
        public Quat TargetValue { get { return this[nameof(TargetValue)].As<Quat>(); } set { this["TargetValue"] = value; } }
        public Quat InitialValue { get { return this[nameof(InitialValue)].As<Quat>(); } set { this["InitialValue"] = value; } }
        public float Blend { get { return this[nameof(Blend)].GetValue<float>(); } set { this[nameof(Blend)].SetValue<float>(value); } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
        public Quat AccumulatedValue { get { return this[nameof(AccumulatedValue)].As<Quat>(); } set { this["AccumulatedValue"] = value; } }
    }
    public class RigUnit_AccumulateVectorLerp : RigUnit_SimBase
    {
        public RigUnit_AccumulateVectorLerp(nint addr) : base(addr) { }
        public Vector TargetValue { get { return this[nameof(TargetValue)].As<Vector>(); } set { this["TargetValue"] = value; } }
        public Vector InitialValue { get { return this[nameof(InitialValue)].As<Vector>(); } set { this["InitialValue"] = value; } }
        public float Blend { get { return this[nameof(Blend)].GetValue<float>(); } set { this[nameof(Blend)].SetValue<float>(value); } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public Vector AccumulatedValue { get { return this[nameof(AccumulatedValue)].As<Vector>(); } set { this["AccumulatedValue"] = value; } }
    }
    public class RigUnit_AccumulateFloatLerp : RigUnit_SimBase
    {
        public RigUnit_AccumulateFloatLerp(nint addr) : base(addr) { }
        public float TargetValue { get { return this[nameof(TargetValue)].GetValue<float>(); } set { this[nameof(TargetValue)].SetValue<float>(value); } }
        public float InitialValue { get { return this[nameof(InitialValue)].GetValue<float>(); } set { this[nameof(InitialValue)].SetValue<float>(value); } }
        public float Blend { get { return this[nameof(Blend)].GetValue<float>(); } set { this[nameof(Blend)].SetValue<float>(value); } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public float AccumulatedValue { get { return this[nameof(AccumulatedValue)].GetValue<float>(); } set { this[nameof(AccumulatedValue)].SetValue<float>(value); } }
    }
    public class RigUnit_AccumulateTransformMul : RigUnit_SimBase
    {
        public RigUnit_AccumulateTransformMul(nint addr) : base(addr) { }
        public Transform Multiplier { get { return this[nameof(Multiplier)].As<Transform>(); } set { this["Multiplier"] = value; } }
        public Transform InitialValue { get { return this[nameof(InitialValue)].As<Transform>(); } set { this["InitialValue"] = value; } }
        public bool bFlipOrder { get { return this[nameof(bFlipOrder)].Flag; } set { this[nameof(bFlipOrder)].Flag = value; } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public Transform AccumulatedValue { get { return this[nameof(AccumulatedValue)].As<Transform>(); } set { this["AccumulatedValue"] = value; } }
    }
    public class RigUnit_AccumulateQuatMul : RigUnit_SimBase
    {
        public RigUnit_AccumulateQuatMul(nint addr) : base(addr) { }
        public Quat Multiplier { get { return this[nameof(Multiplier)].As<Quat>(); } set { this["Multiplier"] = value; } }
        public Quat InitialValue { get { return this[nameof(InitialValue)].As<Quat>(); } set { this["InitialValue"] = value; } }
        public bool bFlipOrder { get { return this[nameof(bFlipOrder)].Flag; } set { this[nameof(bFlipOrder)].Flag = value; } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
        public Quat AccumulatedValue { get { return this[nameof(AccumulatedValue)].As<Quat>(); } set { this["AccumulatedValue"] = value; } }
    }
    public class RigUnit_AccumulateVectorMul : RigUnit_SimBase
    {
        public RigUnit_AccumulateVectorMul(nint addr) : base(addr) { }
        public Vector Multiplier { get { return this[nameof(Multiplier)].As<Vector>(); } set { this["Multiplier"] = value; } }
        public Vector InitialValue { get { return this[nameof(InitialValue)].As<Vector>(); } set { this["InitialValue"] = value; } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public Vector AccumulatedValue { get { return this[nameof(AccumulatedValue)].As<Vector>(); } set { this["AccumulatedValue"] = value; } }
    }
    public class RigUnit_AccumulateFloatMul : RigUnit_SimBase
    {
        public RigUnit_AccumulateFloatMul(nint addr) : base(addr) { }
        public float Multiplier { get { return this[nameof(Multiplier)].GetValue<float>(); } set { this[nameof(Multiplier)].SetValue<float>(value); } }
        public float InitialValue { get { return this[nameof(InitialValue)].GetValue<float>(); } set { this[nameof(InitialValue)].SetValue<float>(value); } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public float AccumulatedValue { get { return this[nameof(AccumulatedValue)].GetValue<float>(); } set { this[nameof(AccumulatedValue)].SetValue<float>(value); } }
    }
    public class RigUnit_AccumulateVectorAdd : RigUnit_SimBase
    {
        public RigUnit_AccumulateVectorAdd(nint addr) : base(addr) { }
        public Vector Increment { get { return this[nameof(Increment)].As<Vector>(); } set { this["Increment"] = value; } }
        public Vector InitialValue { get { return this[nameof(InitialValue)].As<Vector>(); } set { this["InitialValue"] = value; } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public Vector AccumulatedValue { get { return this[nameof(AccumulatedValue)].As<Vector>(); } set { this["AccumulatedValue"] = value; } }
    }
    public class RigUnit_AccumulateFloatAdd : RigUnit_SimBase
    {
        public RigUnit_AccumulateFloatAdd(nint addr) : base(addr) { }
        public float Increment { get { return this[nameof(Increment)].GetValue<float>(); } set { this[nameof(Increment)].SetValue<float>(value); } }
        public float InitialValue { get { return this[nameof(InitialValue)].GetValue<float>(); } set { this[nameof(InitialValue)].SetValue<float>(value); } }
        public bool bIntegrateDeltaTime { get { return this[nameof(bIntegrateDeltaTime)].Flag; } set { this[nameof(bIntegrateDeltaTime)].Flag = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public float AccumulatedValue { get { return this[nameof(AccumulatedValue)].GetValue<float>(); } set { this[nameof(AccumulatedValue)].SetValue<float>(value); } }
    }
    public class RigUnit_AddBoneTransform : RigUnitMutable
    {
        public RigUnit_AddBoneTransform(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPostMultiply { get { return this[nameof(bPostMultiply)].Flag; } set { this[nameof(bPostMultiply)].Flag = value; } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
    }
    public class RigUnit_HighlevelBaseMutable : RigUnitMutable
    {
        public RigUnit_HighlevelBaseMutable(nint addr) : base(addr) { }
    }
    public class RigUnit_AimItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_AimItem(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public RigUnit_AimItem_Target Primary { get { return this[nameof(Primary)].As<RigUnit_AimItem_Target>(); } set { this["Primary"] = value; } }
        public RigUnit_AimItem_Target Secondary { get { return this[nameof(Secondary)].As<RigUnit_AimItem_Target>(); } set { this["Secondary"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public RigUnit_AimBone_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_AimBone_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public CachedRigElement CachedItem { get { return this[nameof(CachedItem)].As<CachedRigElement>(); } set { this["CachedItem"] = value; } }
        public CachedRigElement PrimaryCachedSpace { get { return this[nameof(PrimaryCachedSpace)].As<CachedRigElement>(); } set { this["PrimaryCachedSpace"] = value; } }
        public CachedRigElement SecondaryCachedSpace { get { return this[nameof(SecondaryCachedSpace)].As<CachedRigElement>(); } set { this["SecondaryCachedSpace"] = value; } }
    }
    public class RigUnit_AimBone_DebugSettings : Object
    {
        public RigUnit_AimBone_DebugSettings(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
    }
    public class RigUnit_AimItem_Target : Object
    {
        public RigUnit_AimItem_Target(nint addr) : base(addr) { }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Vector Axis { get { return this[nameof(Axis)].As<Vector>(); } set { this["Axis"] = value; } }
        public Vector Target { get { return this[nameof(Target)].As<Vector>(); } set { this["Target"] = value; } }
        public EControlRigVectorKind Kind { get { return (EControlRigVectorKind)this[nameof(Kind)].GetValue<int>(); } set { this[nameof(Kind)].SetValue<int>((int)value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
    }
    public class RigUnit_AimBone : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_AimBone(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public RigUnit_AimBone_Target Primary { get { return this[nameof(Primary)].As<RigUnit_AimBone_Target>(); } set { this["Primary"] = value; } }
        public RigUnit_AimBone_Target Secondary { get { return this[nameof(Secondary)].As<RigUnit_AimBone_Target>(); } set { this["Secondary"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_AimBone_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_AimBone_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public CachedRigElement CachedBoneIndex { get { return this[nameof(CachedBoneIndex)].As<CachedRigElement>(); } set { this["CachedBoneIndex"] = value; } }
        public CachedRigElement PrimaryCachedSpace { get { return this[nameof(PrimaryCachedSpace)].As<CachedRigElement>(); } set { this["PrimaryCachedSpace"] = value; } }
        public CachedRigElement SecondaryCachedSpace { get { return this[nameof(SecondaryCachedSpace)].As<CachedRigElement>(); } set { this["SecondaryCachedSpace"] = value; } }
    }
    public class RigUnit_AimBone_Target : Object
    {
        public RigUnit_AimBone_Target(nint addr) : base(addr) { }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Vector Axis { get { return this[nameof(Axis)].As<Vector>(); } set { this["Axis"] = value; } }
        public Vector Target { get { return this[nameof(Target)].As<Vector>(); } set { this["Target"] = value; } }
        public EControlRigVectorKind Kind { get { return (EControlRigVectorKind)this[nameof(Kind)].GetValue<int>(); } set { this[nameof(Kind)].SetValue<int>((int)value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
    }
    public class RigUnit_HighlevelBase : RigUnit
    {
        public RigUnit_HighlevelBase(nint addr) : base(addr) { }
    }
    public class RigUnit_AimBoneMath : RigUnit_HighlevelBase
    {
        public RigUnit_AimBoneMath(nint addr) : base(addr) { }
        public Transform InputTransform { get { return this[nameof(InputTransform)].As<Transform>(); } set { this["InputTransform"] = value; } }
        public RigUnit_AimItem_Target Primary { get { return this[nameof(Primary)].As<RigUnit_AimItem_Target>(); } set { this["Primary"] = value; } }
        public RigUnit_AimItem_Target Secondary { get { return this[nameof(Secondary)].As<RigUnit_AimItem_Target>(); } set { this["Secondary"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public RigUnit_AimBone_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_AimBone_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public CachedRigElement PrimaryCachedSpace { get { return this[nameof(PrimaryCachedSpace)].As<CachedRigElement>(); } set { this["PrimaryCachedSpace"] = value; } }
        public CachedRigElement SecondaryCachedSpace { get { return this[nameof(SecondaryCachedSpace)].As<CachedRigElement>(); } set { this["SecondaryCachedSpace"] = value; } }
    }
    public class RigUnit_AimConstraint : RigUnitMutable
    {
        public RigUnit_AimConstraint(nint addr) : base(addr) { }
        public Object Joint { get { return this[nameof(Joint)]; } set { this[nameof(Joint)] = value; } }
        public EAimMode AimMode { get { return (EAimMode)this[nameof(AimMode)].GetValue<int>(); } set { this[nameof(AimMode)].SetValue<int>((int)value); } }
        public EAimMode UpMode { get { return (EAimMode)this[nameof(UpMode)].GetValue<int>(); } set { this[nameof(UpMode)].SetValue<int>((int)value); } }
        public Vector AimVector { get { return this[nameof(AimVector)].As<Vector>(); } set { this["AimVector"] = value; } }
        public Vector UpVector { get { return this[nameof(UpVector)].As<Vector>(); } set { this["UpVector"] = value; } }
        public Array<AimTarget> AimTargets { get { return new Array<AimTarget>(this[nameof(AimTargets)].Address); } }
        public Array<AimTarget> UpTargets { get { return new Array<AimTarget>(this[nameof(UpTargets)].Address); } }
        public RigUnit_AimConstraint_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_AimConstraint_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_AimConstraint_WorkData : Object
    {
        public RigUnit_AimConstraint_WorkData(nint addr) : base(addr) { }
        public Array<ConstraintData> ConstraintData { get { return new Array<ConstraintData>(this[nameof(ConstraintData)].Address); } }
    }
    public class AimTarget : Object
    {
        public AimTarget(nint addr) : base(addr) { }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Vector AlignVector { get { return this[nameof(AlignVector)].As<Vector>(); } set { this["AlignVector"] = value; } }
    }
    public class RigUnit_AlphaInterpVector : RigUnit_SimBase
    {
        public RigUnit_AlphaInterpVector(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public float Bias { get { return this[nameof(Bias)].GetValue<float>(); } set { this[nameof(Bias)].SetValue<float>(value); } }
        public bool bMapRange { get { return this[nameof(bMapRange)].Flag; } set { this[nameof(bMapRange)].Flag = value; } }
        public InputRange InRange { get { return this[nameof(InRange)].As<InputRange>(); } set { this["InRange"] = value; } }
        public InputRange OutRange { get { return this[nameof(OutRange)].As<InputRange>(); } set { this["OutRange"] = value; } }
        public bool bClampResult { get { return this[nameof(bClampResult)].Flag; } set { this[nameof(bClampResult)].Flag = value; } }
        public float ClampMin { get { return this[nameof(ClampMin)].GetValue<float>(); } set { this[nameof(ClampMin)].SetValue<float>(value); } }
        public float ClampMax { get { return this[nameof(ClampMax)].GetValue<float>(); } set { this[nameof(ClampMax)].SetValue<float>(value); } }
        public bool bInterpResult { get { return this[nameof(bInterpResult)].Flag; } set { this[nameof(bInterpResult)].Flag = value; } }
        public float InterpSpeedIncreasing { get { return this[nameof(InterpSpeedIncreasing)].GetValue<float>(); } set { this[nameof(InterpSpeedIncreasing)].SetValue<float>(value); } }
        public float InterpSpeedDecreasing { get { return this[nameof(InterpSpeedDecreasing)].GetValue<float>(); } set { this[nameof(InterpSpeedDecreasing)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public InputScaleBiasClamp ScaleBiasClamp { get { return this[nameof(ScaleBiasClamp)].As<InputScaleBiasClamp>(); } set { this["ScaleBiasClamp"] = value; } }
    }
    public class RigUnit_AlphaInterp : RigUnit_SimBase
    {
        public RigUnit_AlphaInterp(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public float Bias { get { return this[nameof(Bias)].GetValue<float>(); } set { this[nameof(Bias)].SetValue<float>(value); } }
        public bool bMapRange { get { return this[nameof(bMapRange)].Flag; } set { this[nameof(bMapRange)].Flag = value; } }
        public InputRange InRange { get { return this[nameof(InRange)].As<InputRange>(); } set { this["InRange"] = value; } }
        public InputRange OutRange { get { return this[nameof(OutRange)].As<InputRange>(); } set { this["OutRange"] = value; } }
        public bool bClampResult { get { return this[nameof(bClampResult)].Flag; } set { this[nameof(bClampResult)].Flag = value; } }
        public float ClampMin { get { return this[nameof(ClampMin)].GetValue<float>(); } set { this[nameof(ClampMin)].SetValue<float>(value); } }
        public float ClampMax { get { return this[nameof(ClampMax)].GetValue<float>(); } set { this[nameof(ClampMax)].SetValue<float>(value); } }
        public bool bInterpResult { get { return this[nameof(bInterpResult)].Flag; } set { this[nameof(bInterpResult)].Flag = value; } }
        public float InterpSpeedIncreasing { get { return this[nameof(InterpSpeedIncreasing)].GetValue<float>(); } set { this[nameof(InterpSpeedIncreasing)].SetValue<float>(value); } }
        public float InterpSpeedDecreasing { get { return this[nameof(InterpSpeedDecreasing)].GetValue<float>(); } set { this[nameof(InterpSpeedDecreasing)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public InputScaleBiasClamp ScaleBiasClamp { get { return this[nameof(ScaleBiasClamp)].As<InputScaleBiasClamp>(); } set { this["ScaleBiasClamp"] = value; } }
    }
    public class RigUnit_AnimBase : RigUnit
    {
        public RigUnit_AnimBase(nint addr) : base(addr) { }
    }
    public class RigUnit_AnimEasing : RigUnit_AnimBase
    {
        public RigUnit_AnimEasing(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public EControlRigAnimEasingType Type { get { return (EControlRigAnimEasingType)this[nameof(Type)].GetValue<int>(); } set { this[nameof(Type)].SetValue<int>((int)value); } }
        public float SourceMinimum { get { return this[nameof(SourceMinimum)].GetValue<float>(); } set { this[nameof(SourceMinimum)].SetValue<float>(value); } }
        public float SourceMaximum { get { return this[nameof(SourceMaximum)].GetValue<float>(); } set { this[nameof(SourceMaximum)].SetValue<float>(value); } }
        public float TargetMinimum { get { return this[nameof(TargetMinimum)].GetValue<float>(); } set { this[nameof(TargetMinimum)].SetValue<float>(value); } }
        public float TargetMaximum { get { return this[nameof(TargetMaximum)].GetValue<float>(); } set { this[nameof(TargetMaximum)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_AnimEasingType : RigUnit_AnimBase
    {
        public RigUnit_AnimEasingType(nint addr) : base(addr) { }
        public EControlRigAnimEasingType Type { get { return (EControlRigAnimEasingType)this[nameof(Type)].GetValue<int>(); } set { this[nameof(Type)].SetValue<int>((int)value); } }
    }
    public class RigUnit_AnimEvalRichCurve : RigUnit_AnimBase
    {
        public RigUnit_AnimEvalRichCurve(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public RuntimeFloatCurve Curve { get { return this[nameof(Curve)].As<RuntimeFloatCurve>(); } set { this["Curve"] = value; } }
        public float SourceMinimum { get { return this[nameof(SourceMinimum)].GetValue<float>(); } set { this[nameof(SourceMinimum)].SetValue<float>(value); } }
        public float SourceMaximum { get { return this[nameof(SourceMaximum)].GetValue<float>(); } set { this[nameof(SourceMaximum)].SetValue<float>(value); } }
        public float TargetMinimum { get { return this[nameof(TargetMinimum)].GetValue<float>(); } set { this[nameof(TargetMinimum)].SetValue<float>(value); } }
        public float TargetMaximum { get { return this[nameof(TargetMaximum)].GetValue<float>(); } set { this[nameof(TargetMaximum)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_AnimRichCurve : RigUnit_AnimBase
    {
        public RigUnit_AnimRichCurve(nint addr) : base(addr) { }
        public RuntimeFloatCurve Curve { get { return this[nameof(Curve)].As<RuntimeFloatCurve>(); } set { this["Curve"] = value; } }
    }
    public class RigUnit_ApplyFK : RigUnitMutable
    {
        public RigUnit_ApplyFK(nint addr) : base(addr) { }
        public Object Joint { get { return this[nameof(Joint)]; } set { this[nameof(Joint)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public TransformFilter Filter { get { return this[nameof(Filter)].As<TransformFilter>(); } set { this["Filter"] = value; } }
        public EApplyTransformMode ApplyTransformMode { get { return (EApplyTransformMode)this[nameof(ApplyTransformMode)].GetValue<int>(); } set { this[nameof(ApplyTransformMode)].SetValue<int>((int)value); } }
        public ETransformSpaceMode ApplyTransformSpace { get { return (ETransformSpaceMode)this[nameof(ApplyTransformSpace)].GetValue<int>(); } set { this[nameof(ApplyTransformSpace)].SetValue<int>((int)value); } }
        public Transform BaseTransform { get { return this[nameof(BaseTransform)].As<Transform>(); } set { this["BaseTransform"] = value; } }
        public Object BaseJoint { get { return this[nameof(BaseJoint)]; } set { this[nameof(BaseJoint)] = value; } }
    }
    public class RigUnit_BeginExecution : RigUnit
    {
        public RigUnit_BeginExecution(nint addr) : base(addr) { }
        public ControlRigExecuteContext ExecuteContext { get { return this[nameof(ExecuteContext)].As<ControlRigExecuteContext>(); } set { this["ExecuteContext"] = value; } }
    }
    public class RigUnit_BlendTransform : RigUnit
    {
        public RigUnit_BlendTransform(nint addr) : base(addr) { }
        public Transform Source { get { return this[nameof(Source)].As<Transform>(); } set { this["Source"] = value; } }
        public Array<BlendTarget> Targets { get { return new Array<BlendTarget>(this[nameof(Targets)].Address); } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class BlendTarget : Object
    {
        public BlendTarget(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
    }
    public class RigUnit_ItemHarmonics : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_ItemHarmonics(nint addr) : base(addr) { }
        public Array<RigUnit_Harmonics_TargetItem> Targets { get { return new Array<RigUnit_Harmonics_TargetItem>(this[nameof(Targets)].Address); } }
        public Vector WaveSpeed { get { return this[nameof(WaveSpeed)].As<Vector>(); } set { this["WaveSpeed"] = value; } }
        public Vector WaveFrequency { get { return this[nameof(WaveFrequency)].As<Vector>(); } set { this["WaveFrequency"] = value; } }
        public Vector WaveAmplitude { get { return this[nameof(WaveAmplitude)].As<Vector>(); } set { this["WaveAmplitude"] = value; } }
        public Vector WaveOffset { get { return this[nameof(WaveOffset)].As<Vector>(); } set { this["WaveOffset"] = value; } }
        public Vector WaveNoise { get { return this[nameof(WaveNoise)].As<Vector>(); } set { this["WaveNoise"] = value; } }
        public EControlRigAnimEasingType WaveEase { get { return (EControlRigAnimEasingType)this[nameof(WaveEase)].GetValue<int>(); } set { this[nameof(WaveEase)].SetValue<int>((int)value); } }
        public float WaveMinimum { get { return this[nameof(WaveMinimum)].GetValue<float>(); } set { this[nameof(WaveMinimum)].SetValue<float>(value); } }
        public float WaveMaximum { get { return this[nameof(WaveMaximum)].GetValue<float>(); } set { this[nameof(WaveMaximum)].SetValue<float>(value); } }
        public EControlRigRotationOrder RotationOrder { get { return (EControlRigRotationOrder)this[nameof(RotationOrder)].GetValue<int>(); } set { this[nameof(RotationOrder)].SetValue<int>((int)value); } }
        public RigUnit_BoneHarmonics_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_BoneHarmonics_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_BoneHarmonics_WorkData : Object
    {
        public RigUnit_BoneHarmonics_WorkData(nint addr) : base(addr) { }
        public Array<CachedRigElement> CachedItems { get { return new Array<CachedRigElement>(this[nameof(CachedItems)].Address); } }
        public Vector WaveTime { get { return this[nameof(WaveTime)].As<Vector>(); } set { this["WaveTime"] = value; } }
    }
    public class RigUnit_Harmonics_TargetItem : Object
    {
        public RigUnit_Harmonics_TargetItem(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public float Ratio { get { return this[nameof(Ratio)].GetValue<float>(); } set { this[nameof(Ratio)].SetValue<float>(value); } }
    }
    public class RigUnit_BoneHarmonics : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_BoneHarmonics(nint addr) : base(addr) { }
        public Array<RigUnit_BoneHarmonics_BoneTarget> Bones { get { return new Array<RigUnit_BoneHarmonics_BoneTarget>(this[nameof(Bones)].Address); } }
        public Vector WaveSpeed { get { return this[nameof(WaveSpeed)].As<Vector>(); } set { this["WaveSpeed"] = value; } }
        public Vector WaveFrequency { get { return this[nameof(WaveFrequency)].As<Vector>(); } set { this["WaveFrequency"] = value; } }
        public Vector WaveAmplitude { get { return this[nameof(WaveAmplitude)].As<Vector>(); } set { this["WaveAmplitude"] = value; } }
        public Vector WaveOffset { get { return this[nameof(WaveOffset)].As<Vector>(); } set { this["WaveOffset"] = value; } }
        public Vector WaveNoise { get { return this[nameof(WaveNoise)].As<Vector>(); } set { this["WaveNoise"] = value; } }
        public EControlRigAnimEasingType WaveEase { get { return (EControlRigAnimEasingType)this[nameof(WaveEase)].GetValue<int>(); } set { this[nameof(WaveEase)].SetValue<int>((int)value); } }
        public float WaveMinimum { get { return this[nameof(WaveMinimum)].GetValue<float>(); } set { this[nameof(WaveMinimum)].SetValue<float>(value); } }
        public float WaveMaximum { get { return this[nameof(WaveMaximum)].GetValue<float>(); } set { this[nameof(WaveMaximum)].SetValue<float>(value); } }
        public EControlRigRotationOrder RotationOrder { get { return (EControlRigRotationOrder)this[nameof(RotationOrder)].GetValue<int>(); } set { this[nameof(RotationOrder)].SetValue<int>((int)value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_BoneHarmonics_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_BoneHarmonics_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_BoneHarmonics_BoneTarget : Object
    {
        public RigUnit_BoneHarmonics_BoneTarget(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public float Ratio { get { return this[nameof(Ratio)].GetValue<float>(); } set { this[nameof(Ratio)].SetValue<float>(value); } }
    }
    public class RigUnit_ControlName : RigUnit
    {
        public RigUnit_ControlName(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
    }
    public class RigUnit_SpaceName : RigUnit
    {
        public RigUnit_SpaceName(nint addr) : base(addr) { }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
    }
    public class RigUnit_BoneName : RigUnit
    {
        public RigUnit_BoneName(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
    }
    public class RigUnit_Item : RigUnit
    {
        public RigUnit_Item(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
    }
    public class RigUnit_CCDIKPerItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_CCDIKPerItem(nint addr) : base(addr) { }
        public RigElementKeyCollection Items { get { return this[nameof(Items)].As<RigElementKeyCollection>(); } set { this["Items"] = value; } }
        public Transform EffectorTransform { get { return this[nameof(EffectorTransform)].As<Transform>(); } set { this["EffectorTransform"] = value; } }
        public float Precision { get { return this[nameof(Precision)].GetValue<float>(); } set { this[nameof(Precision)].SetValue<float>(value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public int MaxIterations { get { return this[nameof(MaxIterations)].GetValue<int>(); } set { this[nameof(MaxIterations)].SetValue<int>(value); } }
        public bool bStartFromTail { get { return this[nameof(bStartFromTail)].Flag; } set { this[nameof(bStartFromTail)].Flag = value; } }
        public float BaseRotationLimit { get { return this[nameof(BaseRotationLimit)].GetValue<float>(); } set { this[nameof(BaseRotationLimit)].SetValue<float>(value); } }
        public Array<RigUnit_CCDIK_RotationLimitPerItem> RotationLimits { get { return new Array<RigUnit_CCDIK_RotationLimitPerItem>(this[nameof(RotationLimits)].Address); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_CCDIK_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_CCDIK_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_CCDIK_WorkData : Object
    {
        public RigUnit_CCDIK_WorkData(nint addr) : base(addr) { }
        public Array<CCDIKChainLink> Chain { get { return new Array<CCDIKChainLink>(this[nameof(Chain)].Address); } }
        public Array<CachedRigElement> CachedItems { get { return new Array<CachedRigElement>(this[nameof(CachedItems)].Address); } }
        public Array<int> RotationLimitIndex { get { return new Array<int>(this[nameof(RotationLimitIndex)].Address); } }
        public Array<float> RotationLimitsPerItem { get { return new Array<float>(this[nameof(RotationLimitsPerItem)].Address); } }
        public CachedRigElement CachedEffector { get { return this[nameof(CachedEffector)].As<CachedRigElement>(); } set { this["CachedEffector"] = value; } }
    }
    public class RigUnit_CCDIK_RotationLimitPerItem : Object
    {
        public RigUnit_CCDIK_RotationLimitPerItem(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public float Limit { get { return this[nameof(Limit)].GetValue<float>(); } set { this[nameof(Limit)].SetValue<float>(value); } }
    }
    public class RigUnit_CCDIK : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_CCDIK(nint addr) : base(addr) { }
        public Object StartBone { get { return this[nameof(StartBone)]; } set { this[nameof(StartBone)] = value; } }
        public Object EffectorBone { get { return this[nameof(EffectorBone)]; } set { this[nameof(EffectorBone)] = value; } }
        public Transform EffectorTransform { get { return this[nameof(EffectorTransform)].As<Transform>(); } set { this["EffectorTransform"] = value; } }
        public float Precision { get { return this[nameof(Precision)].GetValue<float>(); } set { this[nameof(Precision)].SetValue<float>(value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public int MaxIterations { get { return this[nameof(MaxIterations)].GetValue<int>(); } set { this[nameof(MaxIterations)].SetValue<int>(value); } }
        public bool bStartFromTail { get { return this[nameof(bStartFromTail)].Flag; } set { this[nameof(bStartFromTail)].Flag = value; } }
        public float BaseRotationLimit { get { return this[nameof(BaseRotationLimit)].GetValue<float>(); } set { this[nameof(BaseRotationLimit)].SetValue<float>(value); } }
        public Array<RigUnit_CCDIK_RotationLimit> RotationLimits { get { return new Array<RigUnit_CCDIK_RotationLimit>(this[nameof(RotationLimits)].Address); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_CCDIK_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_CCDIK_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_CCDIK_RotationLimit : Object
    {
        public RigUnit_CCDIK_RotationLimit(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public float Limit { get { return this[nameof(Limit)].GetValue<float>(); } set { this[nameof(Limit)].SetValue<float>(value); } }
    }
    public class RigUnit_ChainHarmonicsPerItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_ChainHarmonicsPerItem(nint addr) : base(addr) { }
        public RigElementKey ChainRoot { get { return this[nameof(ChainRoot)].As<RigElementKey>(); } set { this["ChainRoot"] = value; } }
        public Vector Speed { get { return this[nameof(Speed)].As<Vector>(); } set { this["Speed"] = value; } }
        public RigUnit_ChainHarmonics_Reach Reach { get { return this[nameof(Reach)].As<RigUnit_ChainHarmonics_Reach>(); } set { this["Reach"] = value; } }
        public RigUnit_ChainHarmonics_Wave Wave { get { return this[nameof(Wave)].As<RigUnit_ChainHarmonics_Wave>(); } set { this["Wave"] = value; } }
        public RuntimeFloatCurve WaveCurve { get { return this[nameof(WaveCurve)].As<RuntimeFloatCurve>(); } set { this["WaveCurve"] = value; } }
        public RigUnit_ChainHarmonics_Pendulum Pendulum { get { return this[nameof(Pendulum)].As<RigUnit_ChainHarmonics_Pendulum>(); } set { this["Pendulum"] = value; } }
        public bool bDrawDebug { get { return this[nameof(bDrawDebug)].Flag; } set { this[nameof(bDrawDebug)].Flag = value; } }
        public Transform DrawWorldOffset { get { return this[nameof(DrawWorldOffset)].As<Transform>(); } set { this["DrawWorldOffset"] = value; } }
        public RigUnit_ChainHarmonics_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_ChainHarmonics_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_ChainHarmonics_WorkData : Object
    {
        public RigUnit_ChainHarmonics_WorkData(nint addr) : base(addr) { }
        public Vector Time { get { return this[nameof(Time)].As<Vector>(); } set { this["Time"] = value; } }
        public Array<CachedRigElement> Items { get { return new Array<CachedRigElement>(this[nameof(Items)].Address); } }
        public Array<float> Ratio { get { return new Array<float>(this[nameof(Ratio)].Address); } }
        public Array<Vector> LocalTip { get { return new Array<Vector>(this[nameof(LocalTip)].Address); } }
        public Array<Vector> PendulumTip { get { return new Array<Vector>(this[nameof(PendulumTip)].Address); } }
        public Array<Vector> PendulumPosition { get { return new Array<Vector>(this[nameof(PendulumPosition)].Address); } }
        public Array<Vector> PendulumVelocity { get { return new Array<Vector>(this[nameof(PendulumVelocity)].Address); } }
        public Array<Vector> HierarchyLine { get { return new Array<Vector>(this[nameof(HierarchyLine)].Address); } }
        public Array<Vector> VelocityLines { get { return new Array<Vector>(this[nameof(VelocityLines)].Address); } }
    }
    public class RigUnit_ChainHarmonics_Pendulum : Object
    {
        public RigUnit_ChainHarmonics_Pendulum(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float PendulumStiffness { get { return this[nameof(PendulumStiffness)].GetValue<float>(); } set { this[nameof(PendulumStiffness)].SetValue<float>(value); } }
        public Vector PendulumGravity { get { return this[nameof(PendulumGravity)].As<Vector>(); } set { this["PendulumGravity"] = value; } }
        public float PendulumBlend { get { return this[nameof(PendulumBlend)].GetValue<float>(); } set { this[nameof(PendulumBlend)].SetValue<float>(value); } }
        public float PendulumDrag { get { return this[nameof(PendulumDrag)].GetValue<float>(); } set { this[nameof(PendulumDrag)].SetValue<float>(value); } }
        public float PendulumMinimum { get { return this[nameof(PendulumMinimum)].GetValue<float>(); } set { this[nameof(PendulumMinimum)].SetValue<float>(value); } }
        public float PendulumMaximum { get { return this[nameof(PendulumMaximum)].GetValue<float>(); } set { this[nameof(PendulumMaximum)].SetValue<float>(value); } }
        public EControlRigAnimEasingType PendulumEase { get { return (EControlRigAnimEasingType)this[nameof(PendulumEase)].GetValue<int>(); } set { this[nameof(PendulumEase)].SetValue<int>((int)value); } }
        public Vector UnwindAxis { get { return this[nameof(UnwindAxis)].As<Vector>(); } set { this["UnwindAxis"] = value; } }
        public float UnwindMinimum { get { return this[nameof(UnwindMinimum)].GetValue<float>(); } set { this[nameof(UnwindMinimum)].SetValue<float>(value); } }
        public float UnwindMaximum { get { return this[nameof(UnwindMaximum)].GetValue<float>(); } set { this[nameof(UnwindMaximum)].SetValue<float>(value); } }
    }
    public class RigUnit_ChainHarmonics_Wave : Object
    {
        public RigUnit_ChainHarmonics_Wave(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public Vector WaveFrequency { get { return this[nameof(WaveFrequency)].As<Vector>(); } set { this["WaveFrequency"] = value; } }
        public Vector WaveAmplitude { get { return this[nameof(WaveAmplitude)].As<Vector>(); } set { this["WaveAmplitude"] = value; } }
        public Vector WaveOffset { get { return this[nameof(WaveOffset)].As<Vector>(); } set { this["WaveOffset"] = value; } }
        public Vector WaveNoise { get { return this[nameof(WaveNoise)].As<Vector>(); } set { this["WaveNoise"] = value; } }
        public float WaveMinimum { get { return this[nameof(WaveMinimum)].GetValue<float>(); } set { this[nameof(WaveMinimum)].SetValue<float>(value); } }
        public float WaveMaximum { get { return this[nameof(WaveMaximum)].GetValue<float>(); } set { this[nameof(WaveMaximum)].SetValue<float>(value); } }
        public EControlRigAnimEasingType WaveEase { get { return (EControlRigAnimEasingType)this[nameof(WaveEase)].GetValue<int>(); } set { this[nameof(WaveEase)].SetValue<int>((int)value); } }
    }
    public class RigUnit_ChainHarmonics_Reach : Object
    {
        public RigUnit_ChainHarmonics_Reach(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public Vector ReachTarget { get { return this[nameof(ReachTarget)].As<Vector>(); } set { this["ReachTarget"] = value; } }
        public Vector ReachAxis { get { return this[nameof(ReachAxis)].As<Vector>(); } set { this["ReachAxis"] = value; } }
        public float ReachMinimum { get { return this[nameof(ReachMinimum)].GetValue<float>(); } set { this[nameof(ReachMinimum)].SetValue<float>(value); } }
        public float ReachMaximum { get { return this[nameof(ReachMaximum)].GetValue<float>(); } set { this[nameof(ReachMaximum)].SetValue<float>(value); } }
        public EControlRigAnimEasingType ReachEase { get { return (EControlRigAnimEasingType)this[nameof(ReachEase)].GetValue<int>(); } set { this[nameof(ReachEase)].SetValue<int>((int)value); } }
    }
    public class RigUnit_ChainHarmonics : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_ChainHarmonics(nint addr) : base(addr) { }
        public Object ChainRoot { get { return this[nameof(ChainRoot)]; } set { this[nameof(ChainRoot)] = value; } }
        public Vector Speed { get { return this[nameof(Speed)].As<Vector>(); } set { this["Speed"] = value; } }
        public RigUnit_ChainHarmonics_Reach Reach { get { return this[nameof(Reach)].As<RigUnit_ChainHarmonics_Reach>(); } set { this["Reach"] = value; } }
        public RigUnit_ChainHarmonics_Wave Wave { get { return this[nameof(Wave)].As<RigUnit_ChainHarmonics_Wave>(); } set { this["Wave"] = value; } }
        public RuntimeFloatCurve WaveCurve { get { return this[nameof(WaveCurve)].As<RuntimeFloatCurve>(); } set { this["WaveCurve"] = value; } }
        public RigUnit_ChainHarmonics_Pendulum Pendulum { get { return this[nameof(Pendulum)].As<RigUnit_ChainHarmonics_Pendulum>(); } set { this["Pendulum"] = value; } }
        public bool bDrawDebug { get { return this[nameof(bDrawDebug)].Flag; } set { this[nameof(bDrawDebug)].Flag = value; } }
        public Transform DrawWorldOffset { get { return this[nameof(DrawWorldOffset)].As<Transform>(); } set { this["DrawWorldOffset"] = value; } }
        public RigUnit_ChainHarmonics_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_ChainHarmonics_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_CollectionBaseMutable : RigUnitMutable
    {
        public RigUnit_CollectionBaseMutable(nint addr) : base(addr) { }
    }
    public class RigUnit_CollectionLoop : RigUnit_CollectionBaseMutable
    {
        public RigUnit_CollectionLoop(nint addr) : base(addr) { }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public int Index { get { return this[nameof(Index)].GetValue<int>(); } set { this[nameof(Index)].SetValue<int>(value); } }
        public int Count { get { return this[nameof(Count)].GetValue<int>(); } set { this[nameof(Count)].SetValue<int>(value); } }
        public float Ratio { get { return this[nameof(Ratio)].GetValue<float>(); } set { this[nameof(Ratio)].SetValue<float>(value); } }
        public bool Continue { get { return this[nameof(Continue)].Flag; } set { this[nameof(Continue)].Flag = value; } }
        public ControlRigExecuteContext Completed { get { return this[nameof(Completed)].As<ControlRigExecuteContext>(); } set { this["Completed"] = value; } }
    }
    public class RigUnit_CollectionBase : RigUnit
    {
        public RigUnit_CollectionBase(nint addr) : base(addr) { }
    }
    public class RigUnit_CollectionItemAtIndex : RigUnit_CollectionBase
    {
        public RigUnit_CollectionItemAtIndex(nint addr) : base(addr) { }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
        public int Index { get { return this[nameof(Index)].GetValue<int>(); } set { this[nameof(Index)].SetValue<int>(value); } }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
    }
    public class RigUnit_CollectionCount : RigUnit_CollectionBase
    {
        public RigUnit_CollectionCount(nint addr) : base(addr) { }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
        public int Count { get { return this[nameof(Count)].GetValue<int>(); } set { this[nameof(Count)].SetValue<int>(value); } }
    }
    public class RigUnit_CollectionReverse : RigUnit_CollectionBase
    {
        public RigUnit_CollectionReverse(nint addr) : base(addr) { }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
        public RigElementKeyCollection Reversed { get { return this[nameof(Reversed)].As<RigElementKeyCollection>(); } set { this["Reversed"] = value; } }
    }
    public class RigUnit_CollectionDifference : RigUnit_CollectionBase
    {
        public RigUnit_CollectionDifference(nint addr) : base(addr) { }
        public RigElementKeyCollection A { get { return this[nameof(A)].As<RigElementKeyCollection>(); } set { this["A"] = value; } }
        public RigElementKeyCollection B { get { return this[nameof(B)].As<RigElementKeyCollection>(); } set { this["B"] = value; } }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
    }
    public class RigUnit_CollectionIntersection : RigUnit_CollectionBase
    {
        public RigUnit_CollectionIntersection(nint addr) : base(addr) { }
        public RigElementKeyCollection A { get { return this[nameof(A)].As<RigElementKeyCollection>(); } set { this["A"] = value; } }
        public RigElementKeyCollection B { get { return this[nameof(B)].As<RigElementKeyCollection>(); } set { this["B"] = value; } }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
    }
    public class RigUnit_CollectionUnion : RigUnit_CollectionBase
    {
        public RigUnit_CollectionUnion(nint addr) : base(addr) { }
        public RigElementKeyCollection A { get { return this[nameof(A)].As<RigElementKeyCollection>(); } set { this["A"] = value; } }
        public RigElementKeyCollection B { get { return this[nameof(B)].As<RigElementKeyCollection>(); } set { this["B"] = value; } }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
    }
    public class RigUnit_CollectionItems : RigUnit_CollectionBase
    {
        public RigUnit_CollectionItems(nint addr) : base(addr) { }
        public Array<RigElementKey> Items { get { return new Array<RigElementKey>(this[nameof(Items)].Address); } }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
    }
    public class RigUnit_CollectionReplaceItems : RigUnit_CollectionBase
    {
        public RigUnit_CollectionReplaceItems(nint addr) : base(addr) { }
        public RigElementKeyCollection Items { get { return this[nameof(Items)].As<RigElementKeyCollection>(); } set { this["Items"] = value; } }
        public Object Old { get { return this[nameof(Old)]; } set { this[nameof(Old)] = value; } }
        public Object New { get { return this[nameof(New)]; } set { this[nameof(New)] = value; } }
        public bool RemoveInvalidItems { get { return this[nameof(RemoveInvalidItems)].Flag; } set { this[nameof(RemoveInvalidItems)].Flag = value; } }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
        public RigElementKeyCollection CachedCollection { get { return this[nameof(CachedCollection)].As<RigElementKeyCollection>(); } set { this["CachedCollection"] = value; } }
        public int CachedHierarchyHash { get { return this[nameof(CachedHierarchyHash)].GetValue<int>(); } set { this[nameof(CachedHierarchyHash)].SetValue<int>(value); } }
    }
    public class RigUnit_CollectionChildren : RigUnit_CollectionBase
    {
        public RigUnit_CollectionChildren(nint addr) : base(addr) { }
        public RigElementKey Parent { get { return this[nameof(Parent)].As<RigElementKey>(); } set { this["Parent"] = value; } }
        public bool bIncludeParent { get { return this[nameof(bIncludeParent)].Flag; } set { this[nameof(bIncludeParent)].Flag = value; } }
        public bool bRecursive { get { return this[nameof(bRecursive)].Flag; } set { this[nameof(bRecursive)].Flag = value; } }
        public ERigElementType TypeToSearch { get { return (ERigElementType)this[nameof(TypeToSearch)].GetValue<int>(); } set { this[nameof(TypeToSearch)].SetValue<int>((int)value); } }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
        public RigElementKeyCollection CachedCollection { get { return this[nameof(CachedCollection)].As<RigElementKeyCollection>(); } set { this["CachedCollection"] = value; } }
        public int CachedHierarchyHash { get { return this[nameof(CachedHierarchyHash)].GetValue<int>(); } set { this[nameof(CachedHierarchyHash)].SetValue<int>(value); } }
    }
    public class RigUnit_CollectionNameSearch : RigUnit_CollectionBase
    {
        public RigUnit_CollectionNameSearch(nint addr) : base(addr) { }
        public Object PartialName { get { return this[nameof(PartialName)]; } set { this[nameof(PartialName)] = value; } }
        public ERigElementType TypeToSearch { get { return (ERigElementType)this[nameof(TypeToSearch)].GetValue<int>(); } set { this[nameof(TypeToSearch)].SetValue<int>((int)value); } }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
        public RigElementKeyCollection CachedCollection { get { return this[nameof(CachedCollection)].As<RigElementKeyCollection>(); } set { this["CachedCollection"] = value; } }
        public int CachedHierarchyHash { get { return this[nameof(CachedHierarchyHash)].GetValue<int>(); } set { this[nameof(CachedHierarchyHash)].SetValue<int>(value); } }
    }
    public class RigUnit_CollectionChain : RigUnit_CollectionBase
    {
        public RigUnit_CollectionChain(nint addr) : base(addr) { }
        public RigElementKey FirstItem { get { return this[nameof(FirstItem)].As<RigElementKey>(); } set { this["FirstItem"] = value; } }
        public RigElementKey LastItem { get { return this[nameof(LastItem)].As<RigElementKey>(); } set { this["LastItem"] = value; } }
        public bool Reverse { get { return this[nameof(Reverse)].Flag; } set { this[nameof(Reverse)].Flag = value; } }
        public RigElementKeyCollection Collection { get { return this[nameof(Collection)].As<RigElementKeyCollection>(); } set { this["Collection"] = value; } }
        public RigElementKeyCollection CachedCollection { get { return this[nameof(CachedCollection)].As<RigElementKeyCollection>(); } set { this["CachedCollection"] = value; } }
        public int CachedHierarchyHash { get { return this[nameof(CachedHierarchyHash)].GetValue<int>(); } set { this[nameof(CachedHierarchyHash)].SetValue<int>(value); } }
    }
    public class RigUnit_Control : RigUnit
    {
        public RigUnit_Control(nint addr) : base(addr) { }
        public EulerTransform Transform { get { return this[nameof(Transform)].As<EulerTransform>(); } set { this["Transform"] = value; } }
        public Transform Base { get { return this[nameof(Base)].As<Transform>(); } set { this["Base"] = value; } }
        public Transform InitTransform { get { return this[nameof(InitTransform)].As<Transform>(); } set { this["InitTransform"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public TransformFilter Filter { get { return this[nameof(Filter)].As<TransformFilter>(); } set { this["Filter"] = value; } }
    }
    public class RigUnit_Control_StaticMesh : RigUnit_Control
    {
        public RigUnit_Control_StaticMesh(nint addr) : base(addr) { }
        public Transform MeshTransform { get { return this[nameof(MeshTransform)].As<Transform>(); } set { this["MeshTransform"] = value; } }
    }
    public class RigUnit_ToSwingAndTwist : RigUnit
    {
        public RigUnit_ToSwingAndTwist(nint addr) : base(addr) { }
        public Quat Input { get { return this[nameof(Input)].As<Quat>(); } set { this["Input"] = value; } }
        public Vector TwistAxis { get { return this[nameof(TwistAxis)].As<Vector>(); } set { this["TwistAxis"] = value; } }
        public Quat Swing { get { return this[nameof(Swing)].As<Quat>(); } set { this["Swing"] = value; } }
        public Quat Twist { get { return this[nameof(Twist)].As<Quat>(); } set { this["Twist"] = value; } }
    }
    public class RigUnit_ConvertQuaternionToVector : RigUnit
    {
        public RigUnit_ConvertQuaternionToVector(nint addr) : base(addr) { }
        public Quat Input { get { return this[nameof(Input)].As<Quat>(); } set { this["Input"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ConvertRotationToVector : RigUnit
    {
        public RigUnit_ConvertRotationToVector(nint addr) : base(addr) { }
        public Rotator Input { get { return this[nameof(Input)].As<Rotator>(); } set { this["Input"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ConvertVectorToQuaternion : RigUnit
    {
        public RigUnit_ConvertVectorToQuaternion(nint addr) : base(addr) { }
        public Vector Input { get { return this[nameof(Input)].As<Vector>(); } set { this["Input"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ConvertVectorToRotation : RigUnit
    {
        public RigUnit_ConvertVectorToRotation(nint addr) : base(addr) { }
        public Vector Input { get { return this[nameof(Input)].As<Vector>(); } set { this["Input"] = value; } }
        public Rotator Result { get { return this[nameof(Result)].As<Rotator>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ConvertQuaternion : RigUnit
    {
        public RigUnit_ConvertQuaternion(nint addr) : base(addr) { }
        public Quat Input { get { return this[nameof(Input)].As<Quat>(); } set { this["Input"] = value; } }
        public Rotator Result { get { return this[nameof(Result)].As<Rotator>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ConvertRotation : RigUnit
    {
        public RigUnit_ConvertRotation(nint addr) : base(addr) { }
        public Rotator Input { get { return this[nameof(Input)].As<Rotator>(); } set { this["Input"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ConvertVectorRotation : RigUnit_ConvertRotation
    {
        public RigUnit_ConvertVectorRotation(nint addr) : base(addr) { }
    }
    public class RigUnit_ConvertEulerTransform : RigUnit
    {
        public RigUnit_ConvertEulerTransform(nint addr) : base(addr) { }
        public EulerTransform Input { get { return this[nameof(Input)].As<EulerTransform>(); } set { this["Input"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ConvertTransform : RigUnit
    {
        public RigUnit_ConvertTransform(nint addr) : base(addr) { }
        public Transform Input { get { return this[nameof(Input)].As<Transform>(); } set { this["Input"] = value; } }
        public EulerTransform Result { get { return this[nameof(Result)].As<EulerTransform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_DebugBaseMutable : RigUnitMutable
    {
        public RigUnit_DebugBaseMutable(nint addr) : base(addr) { }
    }
    public class RigUnit_DebugBase : RigUnit
    {
        public RigUnit_DebugBase(nint addr) : base(addr) { }
    }
    public class RigUnit_DebugBezierItemSpace : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugBezierItemSpace(nint addr) : base(addr) { }
        public CRFourPointBezier Bezier { get { return this[nameof(Bezier)].As<CRFourPointBezier>(); } set { this["Bezier"] = value; } }
        public float MinimumU { get { return this[nameof(MinimumU)].GetValue<float>(); } set { this[nameof(MinimumU)].SetValue<float>(value); } }
        public float MaximumU { get { return this[nameof(MaximumU)].GetValue<float>(); } set { this[nameof(MaximumU)].SetValue<float>(value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public int Detail { get { return this[nameof(Detail)].GetValue<int>(); } set { this[nameof(Detail)].SetValue<int>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugBezier : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugBezier(nint addr) : base(addr) { }
        public CRFourPointBezier Bezier { get { return this[nameof(Bezier)].As<CRFourPointBezier>(); } set { this["Bezier"] = value; } }
        public float MinimumU { get { return this[nameof(MinimumU)].GetValue<float>(); } set { this[nameof(MinimumU)].SetValue<float>(value); } }
        public float MaximumU { get { return this[nameof(MaximumU)].GetValue<float>(); } set { this[nameof(MaximumU)].SetValue<float>(value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public int Detail { get { return this[nameof(Detail)].GetValue<int>(); } set { this[nameof(Detail)].SetValue<int>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugHierarchy : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugHierarchy(nint addr) : base(addr) { }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugLineItemSpace : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugLineItemSpace(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugLine : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugLine(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugLineStripItemSpace : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugLineStripItemSpace(nint addr) : base(addr) { }
        public Array<Vector> Points { get { return new Array<Vector>(this[nameof(Points)].Address); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugLineStrip : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugLineStrip(nint addr) : base(addr) { }
        public Array<Vector> Points { get { return new Array<Vector>(this[nameof(Points)].Address); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugPointMutable : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugPointMutable(nint addr) : base(addr) { }
        public Vector Vector { get { return this[nameof(Vector)].As<Vector>(); } set { this["Vector"] = value; } }
        public ERigUnitDebugPointMode Mode { get { return (ERigUnitDebugPointMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugPoint : RigUnit_DebugBase
    {
        public RigUnit_DebugPoint(nint addr) : base(addr) { }
        public Vector Vector { get { return this[nameof(Vector)].As<Vector>(); } set { this["Vector"] = value; } }
        public ERigUnitDebugPointMode Mode { get { return (ERigUnitDebugPointMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugArcItemSpace : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugArcItemSpace(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
        public float MinimumDegrees { get { return this[nameof(MinimumDegrees)].GetValue<float>(); } set { this[nameof(MinimumDegrees)].SetValue<float>(value); } }
        public float MaximumDegrees { get { return this[nameof(MaximumDegrees)].GetValue<float>(); } set { this[nameof(MaximumDegrees)].SetValue<float>(value); } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public int Detail { get { return this[nameof(Detail)].GetValue<int>(); } set { this[nameof(Detail)].SetValue<int>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugArc : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugArc(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
        public float MinimumDegrees { get { return this[nameof(MinimumDegrees)].GetValue<float>(); } set { this[nameof(MinimumDegrees)].SetValue<float>(value); } }
        public float MaximumDegrees { get { return this[nameof(MaximumDegrees)].GetValue<float>(); } set { this[nameof(MaximumDegrees)].SetValue<float>(value); } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public int Detail { get { return this[nameof(Detail)].GetValue<int>(); } set { this[nameof(Detail)].SetValue<int>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugRectangleItemSpace : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugRectangleItemSpace(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugRectangle : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugRectangle(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugTransformArrayMutable : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugTransformArrayMutable(nint addr) : base(addr) { }
        public Array<Transform> Transforms { get { return new Array<Transform>(this[nameof(Transforms)].Address); } }
        public ERigUnitDebugTransformMode Mode { get { return (ERigUnitDebugTransformMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public RigUnit_DebugTransformArrayMutable_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_DebugTransformArrayMutable_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_DebugTransformArrayMutable_WorkData : Object
    {
        public RigUnit_DebugTransformArrayMutable_WorkData(nint addr) : base(addr) { }
        public Array<Transform> DrawTransforms { get { return new Array<Transform>(this[nameof(DrawTransforms)].Address); } }
    }
    public class RigUnit_DebugTransformMutableItemSpace : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugTransformMutableItemSpace(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public ERigUnitDebugTransformMode Mode { get { return (ERigUnitDebugTransformMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugTransformMutable : RigUnit_DebugBaseMutable
    {
        public RigUnit_DebugTransformMutable(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public ERigUnitDebugTransformMode Mode { get { return (ERigUnitDebugTransformMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DebugTransform : RigUnit_DebugBase
    {
        public RigUnit_DebugTransform(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public ERigUnitDebugTransformMode Mode { get { return (ERigUnitDebugTransformMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
    }
    public class RigUnit_DeltaFromPreviousTransform : RigUnit_SimBase
    {
        public RigUnit_DeltaFromPreviousTransform(nint addr) : base(addr) { }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
        public Transform Delta { get { return this[nameof(Delta)].As<Transform>(); } set { this["Delta"] = value; } }
        public Transform PreviousValue { get { return this[nameof(PreviousValue)].As<Transform>(); } set { this["PreviousValue"] = value; } }
        public Transform Cache { get { return this[nameof(Cache)].As<Transform>(); } set { this["Cache"] = value; } }
    }
    public class RigUnit_DeltaFromPreviousQuat : RigUnit_SimBase
    {
        public RigUnit_DeltaFromPreviousQuat(nint addr) : base(addr) { }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
        public Quat Delta { get { return this[nameof(Delta)].As<Quat>(); } set { this["Delta"] = value; } }
        public Quat PreviousValue { get { return this[nameof(PreviousValue)].As<Quat>(); } set { this["PreviousValue"] = value; } }
        public Quat Cache { get { return this[nameof(Cache)].As<Quat>(); } set { this["Cache"] = value; } }
    }
    public class RigUnit_DeltaFromPreviousVector : RigUnit_SimBase
    {
        public RigUnit_DeltaFromPreviousVector(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public Vector Delta { get { return this[nameof(Delta)].As<Vector>(); } set { this["Delta"] = value; } }
        public Vector PreviousValue { get { return this[nameof(PreviousValue)].As<Vector>(); } set { this["PreviousValue"] = value; } }
        public Vector Cache { get { return this[nameof(Cache)].As<Vector>(); } set { this["Cache"] = value; } }
    }
    public class RigUnit_DeltaFromPreviousFloat : RigUnit_SimBase
    {
        public RigUnit_DeltaFromPreviousFloat(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Delta { get { return this[nameof(Delta)].GetValue<float>(); } set { this[nameof(Delta)].SetValue<float>(value); } }
        public float PreviousValue { get { return this[nameof(PreviousValue)].GetValue<float>(); } set { this[nameof(PreviousValue)].SetValue<float>(value); } }
        public float Cache { get { return this[nameof(Cache)].GetValue<float>(); } set { this[nameof(Cache)].SetValue<float>(value); } }
    }
    public class RigUnit_DistributeRotationForCollection : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_DistributeRotationForCollection(nint addr) : base(addr) { }
        public RigElementKeyCollection Items { get { return this[nameof(Items)].As<RigElementKeyCollection>(); } set { this["Items"] = value; } }
        public Array<RigUnit_DistributeRotation_Rotation> Rotations { get { return new Array<RigUnit_DistributeRotation_Rotation>(this[nameof(Rotations)].Address); } }
        public EControlRigAnimEasingType RotationEaseType { get { return (EControlRigAnimEasingType)this[nameof(RotationEaseType)].GetValue<int>(); } set { this[nameof(RotationEaseType)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public RigUnit_DistributeRotation_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_DistributeRotation_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_DistributeRotation_WorkData : Object
    {
        public RigUnit_DistributeRotation_WorkData(nint addr) : base(addr) { }
        public Array<CachedRigElement> CachedItems { get { return new Array<CachedRigElement>(this[nameof(CachedItems)].Address); } }
        public Array<int> ItemRotationA { get { return new Array<int>(this[nameof(ItemRotationA)].Address); } }
        public Array<int> ItemRotationB { get { return new Array<int>(this[nameof(ItemRotationB)].Address); } }
        public Array<float> ItemRotationT { get { return new Array<float>(this[nameof(ItemRotationT)].Address); } }
        public Array<Transform> ItemLocalTransforms { get { return new Array<Transform>(this[nameof(ItemLocalTransforms)].Address); } }
    }
    public class RigUnit_DistributeRotation_Rotation : Object
    {
        public RigUnit_DistributeRotation_Rotation(nint addr) : base(addr) { }
        public Quat Rotation { get { return this[nameof(Rotation)].As<Quat>(); } set { this["Rotation"] = value; } }
        public float Ratio { get { return this[nameof(Ratio)].GetValue<float>(); } set { this[nameof(Ratio)].SetValue<float>(value); } }
    }
    public class RigUnit_DistributeRotation : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_DistributeRotation(nint addr) : base(addr) { }
        public Object StartBone { get { return this[nameof(StartBone)]; } set { this[nameof(StartBone)] = value; } }
        public Object EndBone { get { return this[nameof(EndBone)]; } set { this[nameof(EndBone)] = value; } }
        public Array<RigUnit_DistributeRotation_Rotation> Rotations { get { return new Array<RigUnit_DistributeRotation_Rotation>(this[nameof(Rotations)].Address); } }
        public EControlRigAnimEasingType RotationEaseType { get { return (EControlRigAnimEasingType)this[nameof(RotationEaseType)].GetValue<int>(); } set { this[nameof(RotationEaseType)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_DistributeRotation_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_DistributeRotation_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_DrawContainerSetTransform : RigUnitMutable
    {
        public RigUnit_DrawContainerSetTransform(nint addr) : base(addr) { }
        public Object InstructionName { get { return this[nameof(InstructionName)]; } set { this[nameof(InstructionName)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
    }
    public class RigUnit_DrawContainerSetThickness : RigUnitMutable
    {
        public RigUnit_DrawContainerSetThickness(nint addr) : base(addr) { }
        public Object InstructionName { get { return this[nameof(InstructionName)]; } set { this[nameof(InstructionName)] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
    }
    public class RigUnit_DrawContainerSetColor : RigUnitMutable
    {
        public RigUnit_DrawContainerSetColor(nint addr) : base(addr) { }
        public Object InstructionName { get { return this[nameof(InstructionName)]; } set { this[nameof(InstructionName)] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
    }
    public class RigUnit_DrawContainerGetInstruction : RigUnit
    {
        public RigUnit_DrawContainerGetInstruction(nint addr) : base(addr) { }
        public Object InstructionName { get { return this[nameof(InstructionName)]; } set { this[nameof(InstructionName)] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
    }
    public class RigUnit_FABRIKPerItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_FABRIKPerItem(nint addr) : base(addr) { }
        public RigElementKeyCollection Items { get { return this[nameof(Items)].As<RigElementKeyCollection>(); } set { this["Items"] = value; } }
        public Transform EffectorTransform { get { return this[nameof(EffectorTransform)].As<Transform>(); } set { this["EffectorTransform"] = value; } }
        public float Precision { get { return this[nameof(Precision)].GetValue<float>(); } set { this[nameof(Precision)].SetValue<float>(value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public int MaxIterations { get { return this[nameof(MaxIterations)].GetValue<int>(); } set { this[nameof(MaxIterations)].SetValue<int>(value); } }
        public RigUnit_FABRIK_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_FABRIK_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_FABRIK_WorkData : Object
    {
        public RigUnit_FABRIK_WorkData(nint addr) : base(addr) { }
        public Array<FABRIKChainLink> Chain { get { return new Array<FABRIKChainLink>(this[nameof(Chain)].Address); } }
        public Array<CachedRigElement> CachedItems { get { return new Array<CachedRigElement>(this[nameof(CachedItems)].Address); } }
        public CachedRigElement CachedEffector { get { return this[nameof(CachedEffector)].As<CachedRigElement>(); } set { this["CachedEffector"] = value; } }
    }
    public class RigUnit_FABRIK : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_FABRIK(nint addr) : base(addr) { }
        public Object StartBone { get { return this[nameof(StartBone)]; } set { this[nameof(StartBone)] = value; } }
        public Object EffectorBone { get { return this[nameof(EffectorBone)]; } set { this[nameof(EffectorBone)] = value; } }
        public Transform EffectorTransform { get { return this[nameof(EffectorTransform)].As<Transform>(); } set { this["EffectorTransform"] = value; } }
        public float Precision { get { return this[nameof(Precision)].GetValue<float>(); } set { this[nameof(Precision)].SetValue<float>(value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public int MaxIterations { get { return this[nameof(MaxIterations)].GetValue<int>(); } set { this[nameof(MaxIterations)].SetValue<int>(value); } }
        public RigUnit_FABRIK_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_FABRIK_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_FitChainToCurvePerItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_FitChainToCurvePerItem(nint addr) : base(addr) { }
        public RigElementKeyCollection Items { get { return this[nameof(Items)].As<RigElementKeyCollection>(); } set { this["Items"] = value; } }
        public CRFourPointBezier Bezier { get { return this[nameof(Bezier)].As<CRFourPointBezier>(); } set { this["Bezier"] = value; } }
        public EControlRigCurveAlignment Alignment { get { return (EControlRigCurveAlignment)this[nameof(Alignment)].GetValue<int>(); } set { this[nameof(Alignment)].SetValue<int>((int)value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public int SamplingPrecision { get { return this[nameof(SamplingPrecision)].GetValue<int>(); } set { this[nameof(SamplingPrecision)].SetValue<int>(value); } }
        public Vector PrimaryAxis { get { return this[nameof(PrimaryAxis)].As<Vector>(); } set { this["PrimaryAxis"] = value; } }
        public Vector SecondaryAxis { get { return this[nameof(SecondaryAxis)].As<Vector>(); } set { this["SecondaryAxis"] = value; } }
        public Vector PoleVectorPosition { get { return this[nameof(PoleVectorPosition)].As<Vector>(); } set { this["PoleVectorPosition"] = value; } }
        public Array<RigUnit_FitChainToCurve_Rotation> Rotations { get { return new Array<RigUnit_FitChainToCurve_Rotation>(this[nameof(Rotations)].Address); } }
        public EControlRigAnimEasingType RotationEaseType { get { return (EControlRigAnimEasingType)this[nameof(RotationEaseType)].GetValue<int>(); } set { this[nameof(RotationEaseType)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_FitChainToCurve_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_FitChainToCurve_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public RigUnit_FitChainToCurve_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_FitChainToCurve_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_FitChainToCurve_WorkData : Object
    {
        public RigUnit_FitChainToCurve_WorkData(nint addr) : base(addr) { }
        public float ChainLength { get { return this[nameof(ChainLength)].GetValue<float>(); } set { this[nameof(ChainLength)].SetValue<float>(value); } }
        public Array<Vector> ItemPositions { get { return new Array<Vector>(this[nameof(ItemPositions)].Address); } }
        public Array<float> ItemSegments { get { return new Array<float>(this[nameof(ItemSegments)].Address); } }
        public Array<Vector> CurvePositions { get { return new Array<Vector>(this[nameof(CurvePositions)].Address); } }
        public Array<float> CurveSegments { get { return new Array<float>(this[nameof(CurveSegments)].Address); } }
        public Array<CachedRigElement> CachedItems { get { return new Array<CachedRigElement>(this[nameof(CachedItems)].Address); } }
        public Array<int> ItemRotationA { get { return new Array<int>(this[nameof(ItemRotationA)].Address); } }
        public Array<int> ItemRotationB { get { return new Array<int>(this[nameof(ItemRotationB)].Address); } }
        public Array<float> ItemRotationT { get { return new Array<float>(this[nameof(ItemRotationT)].Address); } }
        public Array<Transform> ItemLocalTransforms { get { return new Array<Transform>(this[nameof(ItemLocalTransforms)].Address); } }
    }
    public class RigUnit_FitChainToCurve_DebugSettings : Object
    {
        public RigUnit_FitChainToCurve_DebugSettings(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public LinearColor CurveColor { get { return this[nameof(CurveColor)].As<LinearColor>(); } set { this["CurveColor"] = value; } }
        public LinearColor SegmentsColor { get { return this[nameof(SegmentsColor)].As<LinearColor>(); } set { this["SegmentsColor"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
    }
    public class RigUnit_FitChainToCurve_Rotation : Object
    {
        public RigUnit_FitChainToCurve_Rotation(nint addr) : base(addr) { }
        public Quat Rotation { get { return this[nameof(Rotation)].As<Quat>(); } set { this["Rotation"] = value; } }
        public float Ratio { get { return this[nameof(Ratio)].GetValue<float>(); } set { this[nameof(Ratio)].SetValue<float>(value); } }
    }
    public class RigUnit_FitChainToCurve : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_FitChainToCurve(nint addr) : base(addr) { }
        public Object StartBone { get { return this[nameof(StartBone)]; } set { this[nameof(StartBone)] = value; } }
        public Object EndBone { get { return this[nameof(EndBone)]; } set { this[nameof(EndBone)] = value; } }
        public CRFourPointBezier Bezier { get { return this[nameof(Bezier)].As<CRFourPointBezier>(); } set { this["Bezier"] = value; } }
        public EControlRigCurveAlignment Alignment { get { return (EControlRigCurveAlignment)this[nameof(Alignment)].GetValue<int>(); } set { this[nameof(Alignment)].SetValue<int>((int)value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public int SamplingPrecision { get { return this[nameof(SamplingPrecision)].GetValue<int>(); } set { this[nameof(SamplingPrecision)].SetValue<int>(value); } }
        public Vector PrimaryAxis { get { return this[nameof(PrimaryAxis)].As<Vector>(); } set { this["PrimaryAxis"] = value; } }
        public Vector SecondaryAxis { get { return this[nameof(SecondaryAxis)].As<Vector>(); } set { this["SecondaryAxis"] = value; } }
        public Vector PoleVectorPosition { get { return this[nameof(PoleVectorPosition)].As<Vector>(); } set { this["PoleVectorPosition"] = value; } }
        public Array<RigUnit_FitChainToCurve_Rotation> Rotations { get { return new Array<RigUnit_FitChainToCurve_Rotation>(this[nameof(Rotations)].Address); } }
        public EControlRigAnimEasingType RotationEaseType { get { return (EControlRigAnimEasingType)this[nameof(RotationEaseType)].GetValue<int>(); } set { this[nameof(RotationEaseType)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_FitChainToCurve_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_FitChainToCurve_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public RigUnit_FitChainToCurve_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_FitChainToCurve_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_MapRange_Float : RigUnit
    {
        public RigUnit_MapRange_Float(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float MinIn { get { return this[nameof(MinIn)].GetValue<float>(); } set { this[nameof(MinIn)].SetValue<float>(value); } }
        public float MaxIn { get { return this[nameof(MaxIn)].GetValue<float>(); } set { this[nameof(MaxIn)].SetValue<float>(value); } }
        public float MinOut { get { return this[nameof(MinOut)].GetValue<float>(); } set { this[nameof(MinOut)].SetValue<float>(value); } }
        public float MaxOut { get { return this[nameof(MaxOut)].GetValue<float>(); } set { this[nameof(MaxOut)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_Clamp_Float : RigUnit
    {
        public RigUnit_Clamp_Float(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Min { get { return this[nameof(Min)].GetValue<float>(); } set { this[nameof(Min)].SetValue<float>(value); } }
        public float Max { get { return this[nameof(Max)].GetValue<float>(); } set { this[nameof(Max)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_BinaryFloatOp : RigUnit
    {
        public RigUnit_BinaryFloatOp(nint addr) : base(addr) { }
        public float Argument0 { get { return this[nameof(Argument0)].GetValue<float>(); } set { this[nameof(Argument0)].SetValue<float>(value); } }
        public float Argument1 { get { return this[nameof(Argument1)].GetValue<float>(); } set { this[nameof(Argument1)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_Divide_FloatFloat : RigUnit_BinaryFloatOp
    {
        public RigUnit_Divide_FloatFloat(nint addr) : base(addr) { }
    }
    public class RigUnit_Subtract_FloatFloat : RigUnit_BinaryFloatOp
    {
        public RigUnit_Subtract_FloatFloat(nint addr) : base(addr) { }
    }
    public class RigUnit_Add_FloatFloat : RigUnit_BinaryFloatOp
    {
        public RigUnit_Add_FloatFloat(nint addr) : base(addr) { }
    }
    public class RigUnit_Multiply_FloatFloat : RigUnit_BinaryFloatOp
    {
        public RigUnit_Multiply_FloatFloat(nint addr) : base(addr) { }
    }
    public class RigUnit_ForLoopCount : RigUnitMutable
    {
        public RigUnit_ForLoopCount(nint addr) : base(addr) { }
        public int Count { get { return this[nameof(Count)].GetValue<int>(); } set { this[nameof(Count)].SetValue<int>(value); } }
        public int Index { get { return this[nameof(Index)].GetValue<int>(); } set { this[nameof(Index)].SetValue<int>(value); } }
        public float Ratio { get { return this[nameof(Ratio)].GetValue<float>(); } set { this[nameof(Ratio)].SetValue<float>(value); } }
        public bool Continue { get { return this[nameof(Continue)].Flag; } set { this[nameof(Continue)].Flag = value; } }
        public ControlRigExecuteContext Completed { get { return this[nameof(Completed)].As<ControlRigExecuteContext>(); } set { this["Completed"] = value; } }
    }
    public class RigUnit_GetBoneTransform : RigUnit
    {
        public RigUnit_GetBoneTransform(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
    }
    public class RigUnit_GetControlInitialTransform : RigUnit
    {
        public RigUnit_GetControlInitialTransform(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_GetControlTransform : RigUnit
    {
        public RigUnit_GetControlTransform(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Transform Minimum { get { return this[nameof(Minimum)].As<Transform>(); } set { this["Minimum"] = value; } }
        public Transform Maximum { get { return this[nameof(Maximum)].As<Transform>(); } set { this["Maximum"] = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_GetControlRotator : RigUnit
    {
        public RigUnit_GetControlRotator(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Rotator Rotator { get { return this[nameof(Rotator)].As<Rotator>(); } set { this["Rotator"] = value; } }
        public Rotator Minimum { get { return this[nameof(Minimum)].As<Rotator>(); } set { this["Minimum"] = value; } }
        public Rotator Maximum { get { return this[nameof(Maximum)].As<Rotator>(); } set { this["Maximum"] = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_GetControlVector : RigUnit
    {
        public RigUnit_GetControlVector(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Vector Vector { get { return this[nameof(Vector)].As<Vector>(); } set { this["Vector"] = value; } }
        public Vector Minimum { get { return this[nameof(Minimum)].As<Vector>(); } set { this["Minimum"] = value; } }
        public Vector Maximum { get { return this[nameof(Maximum)].As<Vector>(); } set { this["Maximum"] = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_GetControlVector2D : RigUnit
    {
        public RigUnit_GetControlVector2D(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public Vector2D Vector { get { return this[nameof(Vector)].As<Vector2D>(); } set { this["Vector"] = value; } }
        public Vector2D Minimum { get { return this[nameof(Minimum)].As<Vector2D>(); } set { this["Minimum"] = value; } }
        public Vector2D Maximum { get { return this[nameof(Maximum)].As<Vector2D>(); } set { this["Maximum"] = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_GetControlInteger : RigUnit
    {
        public RigUnit_GetControlInteger(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public int IntegerValue { get { return this[nameof(IntegerValue)].GetValue<int>(); } set { this[nameof(IntegerValue)].SetValue<int>(value); } }
        public int Minimum { get { return this[nameof(Minimum)].GetValue<int>(); } set { this[nameof(Minimum)].SetValue<int>(value); } }
        public int Maximum { get { return this[nameof(Maximum)].GetValue<int>(); } set { this[nameof(Maximum)].SetValue<int>(value); } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_GetControlFloat : RigUnit
    {
        public RigUnit_GetControlFloat(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public float FloatValue { get { return this[nameof(FloatValue)].GetValue<float>(); } set { this[nameof(FloatValue)].SetValue<float>(value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_GetControlBool : RigUnit
    {
        public RigUnit_GetControlBool(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public bool boolValue { get { return this[nameof(boolValue)].Flag; } set { this[nameof(boolValue)].Flag = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_GetCurveValue : RigUnit
    {
        public RigUnit_GetCurveValue(nint addr) : base(addr) { }
        public Object Curve { get { return this[nameof(Curve)]; } set { this[nameof(Curve)] = value; } }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public CachedRigElement CachedCurveIndex { get { return this[nameof(CachedCurveIndex)].As<CachedRigElement>(); } set { this["CachedCurveIndex"] = value; } }
    }
    public class RigUnit_GetDeltaTime : RigUnit_AnimBase
    {
        public RigUnit_GetDeltaTime(nint addr) : base(addr) { }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_GetInitialBoneTransform : RigUnit
    {
        public RigUnit_GetInitialBoneTransform(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
    }
    public class RigUnit_GetJointTransform : RigUnitMutable
    {
        public RigUnit_GetJointTransform(nint addr) : base(addr) { }
        public Object Joint { get { return this[nameof(Joint)]; } set { this[nameof(Joint)] = value; } }
        public ETransformGetterType Type { get { return (ETransformGetterType)this[nameof(Type)].GetValue<int>(); } set { this[nameof(Type)].SetValue<int>((int)value); } }
        public ETransformSpaceMode TransformSpace { get { return (ETransformSpaceMode)this[nameof(TransformSpace)].GetValue<int>(); } set { this[nameof(TransformSpace)].SetValue<int>((int)value); } }
        public Transform BaseTransform { get { return this[nameof(BaseTransform)].As<Transform>(); } set { this["BaseTransform"] = value; } }
        public Object BaseJoint { get { return this[nameof(BaseJoint)]; } set { this[nameof(BaseJoint)] = value; } }
        public Transform Output { get { return this[nameof(Output)].As<Transform>(); } set { this["Output"] = value; } }
    }
    public class RigUnit_GetRelativeBoneTransform : RigUnit
    {
        public RigUnit_GetRelativeBoneTransform(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
        public CachedRigElement CachedSpace { get { return this[nameof(CachedSpace)].As<CachedRigElement>(); } set { this["CachedSpace"] = value; } }
    }
    public class RigUnit_GetRelativeTransformForItem : RigUnit
    {
        public RigUnit_GetRelativeTransformForItem(nint addr) : base(addr) { }
        public RigElementKey Child { get { return this[nameof(Child)].As<RigElementKey>(); } set { this["Child"] = value; } }
        public bool bChildInitial { get { return this[nameof(bChildInitial)].Flag; } set { this[nameof(bChildInitial)].Flag = value; } }
        public RigElementKey Parent { get { return this[nameof(Parent)].As<RigElementKey>(); } set { this["Parent"] = value; } }
        public bool bParentInitial { get { return this[nameof(bParentInitial)].Flag; } set { this[nameof(bParentInitial)].Flag = value; } }
        public Transform RelativeTransform { get { return this[nameof(RelativeTransform)].As<Transform>(); } set { this["RelativeTransform"] = value; } }
        public CachedRigElement CachedChild { get { return this[nameof(CachedChild)].As<CachedRigElement>(); } set { this["CachedChild"] = value; } }
        public CachedRigElement CachedParent { get { return this[nameof(CachedParent)].As<CachedRigElement>(); } set { this["CachedParent"] = value; } }
    }
    public class RigUnit_GetSpaceTransform : RigUnit
    {
        public RigUnit_GetSpaceTransform(nint addr) : base(addr) { }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public EBoneGetterSetterMode SpaceType { get { return (EBoneGetterSetterMode)this[nameof(SpaceType)].GetValue<int>(); } set { this[nameof(SpaceType)].SetValue<int>((int)value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public CachedRigElement CachedSpaceIndex { get { return this[nameof(CachedSpaceIndex)].As<CachedRigElement>(); } set { this["CachedSpaceIndex"] = value; } }
    }
    public class RigUnit_GetTransform : RigUnit
    {
        public RigUnit_GetTransform(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public bool bInitial { get { return this[nameof(bInitial)].Flag; } set { this[nameof(bInitial)].Flag = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public CachedRigElement CachedIndex { get { return this[nameof(CachedIndex)].As<CachedRigElement>(); } set { this["CachedIndex"] = value; } }
    }
    public class RigUnit_GetWorldTime : RigUnit_AnimBase
    {
        public RigUnit_GetWorldTime(nint addr) : base(addr) { }
        public float Year { get { return this[nameof(Year)].GetValue<float>(); } set { this[nameof(Year)].SetValue<float>(value); } }
        public float Month { get { return this[nameof(Month)].GetValue<float>(); } set { this[nameof(Month)].SetValue<float>(value); } }
        public float Day { get { return this[nameof(Day)].GetValue<float>(); } set { this[nameof(Day)].SetValue<float>(value); } }
        public float WeekDay { get { return this[nameof(WeekDay)].GetValue<float>(); } set { this[nameof(WeekDay)].SetValue<float>(value); } }
        public float Hours { get { return this[nameof(Hours)].GetValue<float>(); } set { this[nameof(Hours)].SetValue<float>(value); } }
        public float Minutes { get { return this[nameof(Minutes)].GetValue<float>(); } set { this[nameof(Minutes)].SetValue<float>(value); } }
        public float Seconds { get { return this[nameof(Seconds)].GetValue<float>(); } set { this[nameof(Seconds)].SetValue<float>(value); } }
        public float OverallSeconds { get { return this[nameof(OverallSeconds)].GetValue<float>(); } set { this[nameof(OverallSeconds)].SetValue<float>(value); } }
    }
    public class RigUnit_HierarchyBase : RigUnit
    {
        public RigUnit_HierarchyBase(nint addr) : base(addr) { }
    }
    public class RigUnit_HierarchyGetSiblings : RigUnit_HierarchyBase
    {
        public RigUnit_HierarchyGetSiblings(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public bool bIncludeItem { get { return this[nameof(bIncludeItem)].Flag; } set { this[nameof(bIncludeItem)].Flag = value; } }
        public RigElementKeyCollection Siblings { get { return this[nameof(Siblings)].As<RigElementKeyCollection>(); } set { this["Siblings"] = value; } }
        public CachedRigElement CachedItem { get { return this[nameof(CachedItem)].As<CachedRigElement>(); } set { this["CachedItem"] = value; } }
        public RigElementKeyCollection CachedSiblings { get { return this[nameof(CachedSiblings)].As<RigElementKeyCollection>(); } set { this["CachedSiblings"] = value; } }
    }
    public class RigUnit_HierarchyGetChildren : RigUnit_HierarchyBase
    {
        public RigUnit_HierarchyGetChildren(nint addr) : base(addr) { }
        public RigElementKey Parent { get { return this[nameof(Parent)].As<RigElementKey>(); } set { this["Parent"] = value; } }
        public bool bIncludeParent { get { return this[nameof(bIncludeParent)].Flag; } set { this[nameof(bIncludeParent)].Flag = value; } }
        public bool bRecursive { get { return this[nameof(bRecursive)].Flag; } set { this[nameof(bRecursive)].Flag = value; } }
        public RigElementKeyCollection Children { get { return this[nameof(Children)].As<RigElementKeyCollection>(); } set { this["Children"] = value; } }
        public CachedRigElement CachedParent { get { return this[nameof(CachedParent)].As<CachedRigElement>(); } set { this["CachedParent"] = value; } }
        public RigElementKeyCollection CachedChildren { get { return this[nameof(CachedChildren)].As<RigElementKeyCollection>(); } set { this["CachedChildren"] = value; } }
    }
    public class RigUnit_HierarchyGetParents : RigUnit_HierarchyBase
    {
        public RigUnit_HierarchyGetParents(nint addr) : base(addr) { }
        public RigElementKey Child { get { return this[nameof(Child)].As<RigElementKey>(); } set { this["Child"] = value; } }
        public bool bIncludeChild { get { return this[nameof(bIncludeChild)].Flag; } set { this[nameof(bIncludeChild)].Flag = value; } }
        public bool bReverse { get { return this[nameof(bReverse)].Flag; } set { this[nameof(bReverse)].Flag = value; } }
        public RigElementKeyCollection Parents { get { return this[nameof(Parents)].As<RigElementKeyCollection>(); } set { this["Parents"] = value; } }
        public CachedRigElement CachedChild { get { return this[nameof(CachedChild)].As<CachedRigElement>(); } set { this["CachedChild"] = value; } }
        public RigElementKeyCollection CachedParents { get { return this[nameof(CachedParents)].As<RigElementKeyCollection>(); } set { this["CachedParents"] = value; } }
    }
    public class RigUnit_HierarchyGetParent : RigUnit_HierarchyBase
    {
        public RigUnit_HierarchyGetParent(nint addr) : base(addr) { }
        public RigElementKey Child { get { return this[nameof(Child)].As<RigElementKey>(); } set { this["Child"] = value; } }
        public RigElementKey Parent { get { return this[nameof(Parent)].As<RigElementKey>(); } set { this["Parent"] = value; } }
        public CachedRigElement CachedChild { get { return this[nameof(CachedChild)].As<CachedRigElement>(); } set { this["CachedChild"] = value; } }
        public CachedRigElement CachedParent { get { return this[nameof(CachedParent)].As<CachedRigElement>(); } set { this["CachedParent"] = value; } }
    }
    public class RigUnit_InverseExecution : RigUnit
    {
        public RigUnit_InverseExecution(nint addr) : base(addr) { }
        public ControlRigExecuteContext ExecuteContext { get { return this[nameof(ExecuteContext)].As<ControlRigExecuteContext>(); } set { this["ExecuteContext"] = value; } }
    }
    public class RigUnit_IsInteracting : RigUnit
    {
        public RigUnit_IsInteracting(nint addr) : base(addr) { }
        public bool bIsInteracting { get { return this[nameof(bIsInteracting)].Flag; } set { this[nameof(bIsInteracting)].Flag = value; } }
    }
    public class RigUnit_ItemBase : RigUnit
    {
        public RigUnit_ItemBase(nint addr) : base(addr) { }
    }
    public class RigUnit_ItemReplace : RigUnit_ItemBase
    {
        public RigUnit_ItemReplace(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public Object Old { get { return this[nameof(Old)]; } set { this[nameof(Old)] = value; } }
        public Object New { get { return this[nameof(New)]; } set { this[nameof(New)] = value; } }
        public RigElementKey Result { get { return this[nameof(Result)].As<RigElementKey>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ItemExists : RigUnit_ItemBase
    {
        public RigUnit_ItemExists(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public bool Exists { get { return this[nameof(Exists)].Flag; } set { this[nameof(Exists)].Flag = value; } }
        public CachedRigElement CachedIndex { get { return this[nameof(CachedIndex)].As<CachedRigElement>(); } set { this["CachedIndex"] = value; } }
    }
    public class RigUnit_ItemBaseMutable : RigUnitMutable
    {
        public RigUnit_ItemBaseMutable(nint addr) : base(addr) { }
    }
    public class RigUnit_KalmanTransform : RigUnit_SimBase
    {
        public RigUnit_KalmanTransform(nint addr) : base(addr) { }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
        public int BufferSize { get { return this[nameof(BufferSize)].GetValue<int>(); } set { this[nameof(BufferSize)].SetValue<int>(value); } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public Array<Transform> Buffer { get { return new Array<Transform>(this[nameof(Buffer)].Address); } }
        public int LastInsertIndex { get { return this[nameof(LastInsertIndex)].GetValue<int>(); } set { this[nameof(LastInsertIndex)].SetValue<int>(value); } }
    }
    public class RigUnit_KalmanVector : RigUnit_SimBase
    {
        public RigUnit_KalmanVector(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public int BufferSize { get { return this[nameof(BufferSize)].GetValue<int>(); } set { this[nameof(BufferSize)].SetValue<int>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public Array<Vector> Buffer { get { return new Array<Vector>(this[nameof(Buffer)].Address); } }
        public int LastInsertIndex { get { return this[nameof(LastInsertIndex)].GetValue<int>(); } set { this[nameof(LastInsertIndex)].SetValue<int>(value); } }
    }
    public class RigUnit_KalmanFloat : RigUnit_SimBase
    {
        public RigUnit_KalmanFloat(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public int BufferSize { get { return this[nameof(BufferSize)].GetValue<int>(); } set { this[nameof(BufferSize)].SetValue<int>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public Array<float> Buffer { get { return new Array<float>(this[nameof(Buffer)].Address); } }
        public int LastInsertIndex { get { return this[nameof(LastInsertIndex)].GetValue<int>(); } set { this[nameof(LastInsertIndex)].SetValue<int>(value); } }
    }
    public class RigUnit_MathBase : RigUnit
    {
        public RigUnit_MathBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathBoolBase : RigUnit_MathBase
    {
        public RigUnit_MathBoolBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathBoolNotEquals : RigUnit_MathBoolBase
    {
        public RigUnit_MathBoolNotEquals(nint addr) : base(addr) { }
        public bool A { get { return this[nameof(A)].Flag; } set { this[nameof(A)].Flag = value; } }
        public bool B { get { return this[nameof(B)].Flag; } set { this[nameof(B)].Flag = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathBoolEquals : RigUnit_MathBoolBase
    {
        public RigUnit_MathBoolEquals(nint addr) : base(addr) { }
        public bool A { get { return this[nameof(A)].Flag; } set { this[nameof(A)].Flag = value; } }
        public bool B { get { return this[nameof(B)].Flag; } set { this[nameof(B)].Flag = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathBoolBinaryOp : RigUnit_MathBoolBase
    {
        public RigUnit_MathBoolBinaryOp(nint addr) : base(addr) { }
        public bool A { get { return this[nameof(A)].Flag; } set { this[nameof(A)].Flag = value; } }
        public bool B { get { return this[nameof(B)].Flag; } set { this[nameof(B)].Flag = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathBoolOr : RigUnit_MathBoolBinaryOp
    {
        public RigUnit_MathBoolOr(nint addr) : base(addr) { }
    }
    public class RigUnit_MathBoolNand : RigUnit_MathBoolBinaryOp
    {
        public RigUnit_MathBoolNand(nint addr) : base(addr) { }
    }
    public class RigUnit_MathBoolAnd : RigUnit_MathBoolBinaryOp
    {
        public RigUnit_MathBoolAnd(nint addr) : base(addr) { }
    }
    public class RigUnit_MathBoolUnaryOp : RigUnit_MathBoolBase
    {
        public RigUnit_MathBoolUnaryOp(nint addr) : base(addr) { }
        public bool Value { get { return this[nameof(Value)].Flag; } set { this[nameof(Value)].Flag = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathBoolNot : RigUnit_MathBoolUnaryOp
    {
        public RigUnit_MathBoolNot(nint addr) : base(addr) { }
    }
    public class RigUnit_MathBoolConstant : RigUnit_MathBoolBase
    {
        public RigUnit_MathBoolConstant(nint addr) : base(addr) { }
        public bool Value { get { return this[nameof(Value)].Flag; } set { this[nameof(Value)].Flag = value; } }
    }
    public class RigUnit_MathBoolConstFalse : RigUnit_MathBoolConstant
    {
        public RigUnit_MathBoolConstFalse(nint addr) : base(addr) { }
    }
    public class RigUnit_MathBoolConstTrue : RigUnit_MathBoolConstant
    {
        public RigUnit_MathBoolConstTrue(nint addr) : base(addr) { }
    }
    public class RigUnit_MathColorBase : RigUnit_MathBase
    {
        public RigUnit_MathColorBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathColorLerp : RigUnit_MathColorBase
    {
        public RigUnit_MathColorLerp(nint addr) : base(addr) { }
        public LinearColor A { get { return this[nameof(A)].As<LinearColor>(); } set { this["A"] = value; } }
        public LinearColor B { get { return this[nameof(B)].As<LinearColor>(); } set { this["B"] = value; } }
        public float T { get { return this[nameof(T)].GetValue<float>(); } set { this[nameof(T)].SetValue<float>(value); } }
        public LinearColor Result { get { return this[nameof(Result)].As<LinearColor>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathColorBinaryOp : RigUnit_MathColorBase
    {
        public RigUnit_MathColorBinaryOp(nint addr) : base(addr) { }
        public LinearColor A { get { return this[nameof(A)].As<LinearColor>(); } set { this["A"] = value; } }
        public LinearColor B { get { return this[nameof(B)].As<LinearColor>(); } set { this["B"] = value; } }
        public LinearColor Result { get { return this[nameof(Result)].As<LinearColor>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathColorMul : RigUnit_MathColorBinaryOp
    {
        public RigUnit_MathColorMul(nint addr) : base(addr) { }
    }
    public class RigUnit_MathColorSub : RigUnit_MathColorBinaryOp
    {
        public RigUnit_MathColorSub(nint addr) : base(addr) { }
    }
    public class RigUnit_MathColorAdd : RigUnit_MathColorBinaryOp
    {
        public RigUnit_MathColorAdd(nint addr) : base(addr) { }
    }
    public class RigUnit_MathColorFromFloat : RigUnit_MathColorBase
    {
        public RigUnit_MathColorFromFloat(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public LinearColor Result { get { return this[nameof(Result)].As<LinearColor>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathFloatBase : RigUnit_MathBase
    {
        public RigUnit_MathFloatBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatLawOfCosine : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatLawOfCosine(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public float C { get { return this[nameof(C)].GetValue<float>(); } set { this[nameof(C)].SetValue<float>(value); } }
        public float AlphaAngle { get { return this[nameof(AlphaAngle)].GetValue<float>(); } set { this[nameof(AlphaAngle)].SetValue<float>(value); } }
        public float BetaAngle { get { return this[nameof(BetaAngle)].GetValue<float>(); } set { this[nameof(BetaAngle)].SetValue<float>(value); } }
        public float GammaAngle { get { return this[nameof(GammaAngle)].GetValue<float>(); } set { this[nameof(GammaAngle)].SetValue<float>(value); } }
        public bool bValid { get { return this[nameof(bValid)].Flag; } set { this[nameof(bValid)].Flag = value; } }
    }
    public class RigUnit_MathFloatUnaryOp : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatUnaryOp(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathFloatAtan : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatAtan(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatAcos : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatAcos(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatAsin : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatAsin(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatTan : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatTan(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatCos : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatCos(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatSin : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatSin(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatRad : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatRad(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatDeg : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatDeg(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatSelectBool : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatSelectBool(nint addr) : base(addr) { }
        public bool Condition { get { return this[nameof(Condition)].Flag; } set { this[nameof(Condition)].Flag = value; } }
        public float IfTrue { get { return this[nameof(IfTrue)].GetValue<float>(); } set { this[nameof(IfTrue)].SetValue<float>(value); } }
        public float IfFalse { get { return this[nameof(IfFalse)].GetValue<float>(); } set { this[nameof(IfFalse)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathFloatIsNearlyEqual : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatIsNearlyEqual(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public float Tolerance { get { return this[nameof(Tolerance)].GetValue<float>(); } set { this[nameof(Tolerance)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathFloatIsNearlyZero : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatIsNearlyZero(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Tolerance { get { return this[nameof(Tolerance)].GetValue<float>(); } set { this[nameof(Tolerance)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathFloatLessEqual : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatLessEqual(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathFloatGreaterEqual : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatGreaterEqual(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathFloatLess : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatLess(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathFloatGreater : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatGreater(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathFloatNotEquals : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatNotEquals(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathFloatEquals : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatEquals(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathFloatRemap : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatRemap(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float SourceMinimum { get { return this[nameof(SourceMinimum)].GetValue<float>(); } set { this[nameof(SourceMinimum)].SetValue<float>(value); } }
        public float SourceMaximum { get { return this[nameof(SourceMaximum)].GetValue<float>(); } set { this[nameof(SourceMaximum)].SetValue<float>(value); } }
        public float TargetMinimum { get { return this[nameof(TargetMinimum)].GetValue<float>(); } set { this[nameof(TargetMinimum)].SetValue<float>(value); } }
        public float TargetMaximum { get { return this[nameof(TargetMaximum)].GetValue<float>(); } set { this[nameof(TargetMaximum)].SetValue<float>(value); } }
        public bool bClamp { get { return this[nameof(bClamp)].Flag; } set { this[nameof(bClamp)].Flag = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathFloatLerp : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatLerp(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public float T { get { return this[nameof(T)].GetValue<float>(); } set { this[nameof(T)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathFloatClamp : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatClamp(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathFloatSign : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatSign(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatToInt : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatToInt(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public int Result { get { return this[nameof(Result)].GetValue<int>(); } set { this[nameof(Result)].SetValue<int>(value); } }
    }
    public class RigUnit_MathFloatRound : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatRound(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public int Int { get { return this[nameof(Int)].GetValue<int>(); } set { this[nameof(Int)].SetValue<int>(value); } }
    }
    public class RigUnit_MathFloatCeil : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatCeil(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public int Int { get { return this[nameof(Int)].GetValue<int>(); } set { this[nameof(Int)].SetValue<int>(value); } }
    }
    public class RigUnit_MathFloatFloor : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatFloor(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public int Int { get { return this[nameof(Int)].GetValue<int>(); } set { this[nameof(Int)].SetValue<int>(value); } }
    }
    public class RigUnit_MathFloatAbs : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatAbs(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatNegate : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatNegate(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatSqrt : RigUnit_MathFloatUnaryOp
    {
        public RigUnit_MathFloatSqrt(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatBinaryOp : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatBinaryOp(nint addr) : base(addr) { }
        public float A { get { return this[nameof(A)].GetValue<float>(); } set { this[nameof(A)].SetValue<float>(value); } }
        public float B { get { return this[nameof(B)].GetValue<float>(); } set { this[nameof(B)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathFloatPow : RigUnit_MathFloatBinaryOp
    {
        public RigUnit_MathFloatPow(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatMax : RigUnit_MathFloatBinaryOp
    {
        public RigUnit_MathFloatMax(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatMin : RigUnit_MathFloatBinaryOp
    {
        public RigUnit_MathFloatMin(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatMod : RigUnit_MathFloatBinaryOp
    {
        public RigUnit_MathFloatMod(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatDiv : RigUnit_MathFloatBinaryOp
    {
        public RigUnit_MathFloatDiv(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatMul : RigUnit_MathFloatBinaryOp
    {
        public RigUnit_MathFloatMul(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatSub : RigUnit_MathFloatBinaryOp
    {
        public RigUnit_MathFloatSub(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatAdd : RigUnit_MathFloatBinaryOp
    {
        public RigUnit_MathFloatAdd(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatConstant : RigUnit_MathFloatBase
    {
        public RigUnit_MathFloatConstant(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
    }
    public class RigUnit_MathFloatConstTwoPi : RigUnit_MathFloatConstant
    {
        public RigUnit_MathFloatConstTwoPi(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatConstHalfPi : RigUnit_MathFloatConstant
    {
        public RigUnit_MathFloatConstHalfPi(nint addr) : base(addr) { }
    }
    public class RigUnit_MathFloatConstPi : RigUnit_MathFloatConstant
    {
        public RigUnit_MathFloatConstPi(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntBase : RigUnit_MathBase
    {
        public RigUnit_MathIntBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntLessEqual : RigUnit_MathIntBase
    {
        public RigUnit_MathIntLessEqual(nint addr) : base(addr) { }
        public int A { get { return this[nameof(A)].GetValue<int>(); } set { this[nameof(A)].SetValue<int>(value); } }
        public int B { get { return this[nameof(B)].GetValue<int>(); } set { this[nameof(B)].SetValue<int>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathIntGreaterEqual : RigUnit_MathIntBase
    {
        public RigUnit_MathIntGreaterEqual(nint addr) : base(addr) { }
        public int A { get { return this[nameof(A)].GetValue<int>(); } set { this[nameof(A)].SetValue<int>(value); } }
        public int B { get { return this[nameof(B)].GetValue<int>(); } set { this[nameof(B)].SetValue<int>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathIntLess : RigUnit_MathIntBase
    {
        public RigUnit_MathIntLess(nint addr) : base(addr) { }
        public int A { get { return this[nameof(A)].GetValue<int>(); } set { this[nameof(A)].SetValue<int>(value); } }
        public int B { get { return this[nameof(B)].GetValue<int>(); } set { this[nameof(B)].SetValue<int>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathIntGreater : RigUnit_MathIntBase
    {
        public RigUnit_MathIntGreater(nint addr) : base(addr) { }
        public int A { get { return this[nameof(A)].GetValue<int>(); } set { this[nameof(A)].SetValue<int>(value); } }
        public int B { get { return this[nameof(B)].GetValue<int>(); } set { this[nameof(B)].SetValue<int>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathIntNotEquals : RigUnit_MathIntBase
    {
        public RigUnit_MathIntNotEquals(nint addr) : base(addr) { }
        public int A { get { return this[nameof(A)].GetValue<int>(); } set { this[nameof(A)].SetValue<int>(value); } }
        public int B { get { return this[nameof(B)].GetValue<int>(); } set { this[nameof(B)].SetValue<int>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathIntEquals : RigUnit_MathIntBase
    {
        public RigUnit_MathIntEquals(nint addr) : base(addr) { }
        public int A { get { return this[nameof(A)].GetValue<int>(); } set { this[nameof(A)].SetValue<int>(value); } }
        public int B { get { return this[nameof(B)].GetValue<int>(); } set { this[nameof(B)].SetValue<int>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathIntClamp : RigUnit_MathIntBase
    {
        public RigUnit_MathIntClamp(nint addr) : base(addr) { }
        public int Value { get { return this[nameof(Value)].GetValue<int>(); } set { this[nameof(Value)].SetValue<int>(value); } }
        public int Minimum { get { return this[nameof(Minimum)].GetValue<int>(); } set { this[nameof(Minimum)].SetValue<int>(value); } }
        public int Maximum { get { return this[nameof(Maximum)].GetValue<int>(); } set { this[nameof(Maximum)].SetValue<int>(value); } }
        public int Result { get { return this[nameof(Result)].GetValue<int>(); } set { this[nameof(Result)].SetValue<int>(value); } }
    }
    public class RigUnit_MathIntUnaryOp : RigUnit_MathIntBase
    {
        public RigUnit_MathIntUnaryOp(nint addr) : base(addr) { }
        public int Value { get { return this[nameof(Value)].GetValue<int>(); } set { this[nameof(Value)].SetValue<int>(value); } }
        public int Result { get { return this[nameof(Result)].GetValue<int>(); } set { this[nameof(Result)].SetValue<int>(value); } }
    }
    public class RigUnit_MathIntSign : RigUnit_MathIntUnaryOp
    {
        public RigUnit_MathIntSign(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntToFloat : RigUnit_MathIntBase
    {
        public RigUnit_MathIntToFloat(nint addr) : base(addr) { }
        public int Value { get { return this[nameof(Value)].GetValue<int>(); } set { this[nameof(Value)].SetValue<int>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathIntAbs : RigUnit_MathIntUnaryOp
    {
        public RigUnit_MathIntAbs(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntNegate : RigUnit_MathIntUnaryOp
    {
        public RigUnit_MathIntNegate(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntBinaryOp : RigUnit_MathIntBase
    {
        public RigUnit_MathIntBinaryOp(nint addr) : base(addr) { }
        public int A { get { return this[nameof(A)].GetValue<int>(); } set { this[nameof(A)].SetValue<int>(value); } }
        public int B { get { return this[nameof(B)].GetValue<int>(); } set { this[nameof(B)].SetValue<int>(value); } }
        public int Result { get { return this[nameof(Result)].GetValue<int>(); } set { this[nameof(Result)].SetValue<int>(value); } }
    }
    public class RigUnit_MathIntPow : RigUnit_MathIntBinaryOp
    {
        public RigUnit_MathIntPow(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntMax : RigUnit_MathIntBinaryOp
    {
        public RigUnit_MathIntMax(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntMin : RigUnit_MathIntBinaryOp
    {
        public RigUnit_MathIntMin(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntMod : RigUnit_MathIntBinaryOp
    {
        public RigUnit_MathIntMod(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntDiv : RigUnit_MathIntBinaryOp
    {
        public RigUnit_MathIntDiv(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntMul : RigUnit_MathIntBinaryOp
    {
        public RigUnit_MathIntMul(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntSub : RigUnit_MathIntBinaryOp
    {
        public RigUnit_MathIntSub(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntAdd : RigUnit_MathIntBinaryOp
    {
        public RigUnit_MathIntAdd(nint addr) : base(addr) { }
    }
    public class RigUnit_MathQuaternionRotationOrder : RigUnit_MathBase
    {
        public RigUnit_MathQuaternionRotationOrder(nint addr) : base(addr) { }
        public EControlRigRotationOrder RotationOrder { get { return (EControlRigRotationOrder)this[nameof(RotationOrder)].GetValue<int>(); } set { this[nameof(RotationOrder)].SetValue<int>((int)value); } }
    }
    public class RigUnit_MathQuaternionBase : RigUnit_MathBase
    {
        public RigUnit_MathQuaternionBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathQuaternionSwingTwist : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionSwingTwist(nint addr) : base(addr) { }
        public Quat Input { get { return this[nameof(Input)].As<Quat>(); } set { this["Input"] = value; } }
        public Vector TwistAxis { get { return this[nameof(TwistAxis)].As<Vector>(); } set { this["TwistAxis"] = value; } }
        public Quat Swing { get { return this[nameof(Swing)].As<Quat>(); } set { this["Swing"] = value; } }
        public Quat Twist { get { return this[nameof(Twist)].As<Quat>(); } set { this["Twist"] = value; } }
    }
    public class RigUnit_MathQuaternionGetAxis : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionGetAxis(nint addr) : base(addr) { }
        public Quat Quaternion { get { return this[nameof(Quaternion)].As<Quat>(); } set { this["Quaternion"] = value; } }
        public byte Axis { get { return this[nameof(Axis)].GetValue<byte>(); } set { this[nameof(Axis)].SetValue<byte>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionRotateVector : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionRotateVector(nint addr) : base(addr) { }
        public Quat Quaternion { get { return this[nameof(Quaternion)].As<Quat>(); } set { this["Quaternion"] = value; } }
        public Vector Vector { get { return this[nameof(Vector)].As<Vector>(); } set { this["Vector"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionUnaryOp : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionUnaryOp(nint addr) : base(addr) { }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionUnit : RigUnit_MathQuaternionUnaryOp
    {
        public RigUnit_MathQuaternionUnit(nint addr) : base(addr) { }
    }
    public class RigUnit_MathQuaternionDot : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionDot(nint addr) : base(addr) { }
        public Quat A { get { return this[nameof(A)].As<Quat>(); } set { this["A"] = value; } }
        public Quat B { get { return this[nameof(B)].As<Quat>(); } set { this["B"] = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathQuaternionSelectBool : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionSelectBool(nint addr) : base(addr) { }
        public bool Condition { get { return this[nameof(Condition)].Flag; } set { this[nameof(Condition)].Flag = value; } }
        public Quat IfTrue { get { return this[nameof(IfTrue)].As<Quat>(); } set { this["IfTrue"] = value; } }
        public Quat IfFalse { get { return this[nameof(IfFalse)].As<Quat>(); } set { this["IfFalse"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionNotEquals : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionNotEquals(nint addr) : base(addr) { }
        public Quat A { get { return this[nameof(A)].As<Quat>(); } set { this["A"] = value; } }
        public Quat B { get { return this[nameof(B)].As<Quat>(); } set { this["B"] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathQuaternionEquals : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionEquals(nint addr) : base(addr) { }
        public Quat A { get { return this[nameof(A)].As<Quat>(); } set { this["A"] = value; } }
        public Quat B { get { return this[nameof(B)].As<Quat>(); } set { this["B"] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathQuaternionSlerp : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionSlerp(nint addr) : base(addr) { }
        public Quat A { get { return this[nameof(A)].As<Quat>(); } set { this["A"] = value; } }
        public Quat B { get { return this[nameof(B)].As<Quat>(); } set { this["B"] = value; } }
        public float T { get { return this[nameof(T)].GetValue<float>(); } set { this[nameof(T)].SetValue<float>(value); } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionInverse : RigUnit_MathQuaternionUnaryOp
    {
        public RigUnit_MathQuaternionInverse(nint addr) : base(addr) { }
    }
    public class RigUnit_MathQuaternionBinaryOp : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionBinaryOp(nint addr) : base(addr) { }
        public Quat A { get { return this[nameof(A)].As<Quat>(); } set { this["A"] = value; } }
        public Quat B { get { return this[nameof(B)].As<Quat>(); } set { this["B"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionMul : RigUnit_MathQuaternionBinaryOp
    {
        public RigUnit_MathQuaternionMul(nint addr) : base(addr) { }
    }
    public class RigUnit_MathQuaternionToRotator : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionToRotator(nint addr) : base(addr) { }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
        public Rotator Result { get { return this[nameof(Result)].As<Rotator>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionToEuler : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionToEuler(nint addr) : base(addr) { }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
        public EControlRigRotationOrder RotationOrder { get { return (EControlRigRotationOrder)this[nameof(RotationOrder)].GetValue<int>(); } set { this[nameof(RotationOrder)].SetValue<int>((int)value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionScale : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionScale(nint addr) : base(addr) { }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
    }
    public class RigUnit_MathQuaternionToAxisAndAngle : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionToAxisAndAngle(nint addr) : base(addr) { }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
        public Vector Axis { get { return this[nameof(Axis)].As<Vector>(); } set { this["Axis"] = value; } }
        public float Angle { get { return this[nameof(Angle)].GetValue<float>(); } set { this[nameof(Angle)].SetValue<float>(value); } }
    }
    public class RigUnit_MathQuaternionFromTwoVectors : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionFromTwoVectors(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionFromRotator : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionFromRotator(nint addr) : base(addr) { }
        public Rotator Rotator { get { return this[nameof(Rotator)].As<Rotator>(); } set { this["Rotator"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionFromEuler : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionFromEuler(nint addr) : base(addr) { }
        public Vector Euler { get { return this[nameof(Euler)].As<Vector>(); } set { this["Euler"] = value; } }
        public EControlRigRotationOrder RotationOrder { get { return (EControlRigRotationOrder)this[nameof(RotationOrder)].GetValue<int>(); } set { this[nameof(RotationOrder)].SetValue<int>((int)value); } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathQuaternionFromAxisAndAngle : RigUnit_MathQuaternionBase
    {
        public RigUnit_MathQuaternionFromAxisAndAngle(nint addr) : base(addr) { }
        public Vector Axis { get { return this[nameof(Axis)].As<Vector>(); } set { this["Axis"] = value; } }
        public float Angle { get { return this[nameof(Angle)].GetValue<float>(); } set { this[nameof(Angle)].SetValue<float>(value); } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateBase : RigUnit_MathBase
    {
        public RigUnit_MathRBFInterpolateBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathRBFInterpolateVectorBase : RigUnit_MathRBFInterpolateBase
    {
        public RigUnit_MathRBFInterpolateVectorBase(nint addr) : base(addr) { }
        public Vector Input { get { return this[nameof(Input)].As<Vector>(); } set { this["Input"] = value; } }
        public ERBFVectorDistanceType DistanceFunction { get { return (ERBFVectorDistanceType)this[nameof(DistanceFunction)].GetValue<int>(); } set { this[nameof(DistanceFunction)].SetValue<int>((int)value); } }
        public ERBFKernelType SmoothingFunction { get { return (ERBFKernelType)this[nameof(SmoothingFunction)].GetValue<int>(); } set { this[nameof(SmoothingFunction)].SetValue<int>((int)value); } }
        public float SmoothingRadius { get { return this[nameof(SmoothingRadius)].GetValue<float>(); } set { this[nameof(SmoothingRadius)].SetValue<float>(value); } }
        public bool bNormalizeOutput { get { return this[nameof(bNormalizeOutput)].Flag; } set { this[nameof(bNormalizeOutput)].Flag = value; } }
        public RigUnit_MathRBFInterpolateVectorWorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_MathRBFInterpolateVectorWorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateVectorWorkData : Object
    {
        public RigUnit_MathRBFInterpolateVectorWorkData(nint addr) : base(addr) { }
    }
    public class RigUnit_MathRBFInterpolateVectorXform : RigUnit_MathRBFInterpolateVectorBase
    {
        public RigUnit_MathRBFInterpolateVectorXform(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateVectorXform_Target> Targets { get { return new Array<MathRBFInterpolateVectorXform_Target>(this[nameof(Targets)].Address); } }
        public Transform Output { get { return this[nameof(Output)].As<Transform>(); } set { this["Output"] = value; } }
    }
    public class MathRBFInterpolateVectorXform_Target : Object
    {
        public MathRBFInterpolateVectorXform_Target(nint addr) : base(addr) { }
        public Vector Target { get { return this[nameof(Target)].As<Vector>(); } set { this["Target"] = value; } }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateVectorQuat : RigUnit_MathRBFInterpolateVectorBase
    {
        public RigUnit_MathRBFInterpolateVectorQuat(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateVectorQuat_Target> Targets { get { return new Array<MathRBFInterpolateVectorQuat_Target>(this[nameof(Targets)].Address); } }
        public Quat Output { get { return this[nameof(Output)].As<Quat>(); } set { this["Output"] = value; } }
    }
    public class MathRBFInterpolateVectorQuat_Target : Object
    {
        public MathRBFInterpolateVectorQuat_Target(nint addr) : base(addr) { }
        public Vector Target { get { return this[nameof(Target)].As<Vector>(); } set { this["Target"] = value; } }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateVectorColor : RigUnit_MathRBFInterpolateVectorBase
    {
        public RigUnit_MathRBFInterpolateVectorColor(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateVectorColor_Target> Targets { get { return new Array<MathRBFInterpolateVectorColor_Target>(this[nameof(Targets)].Address); } }
        public LinearColor Output { get { return this[nameof(Output)].As<LinearColor>(); } set { this["Output"] = value; } }
    }
    public class MathRBFInterpolateVectorColor_Target : Object
    {
        public MathRBFInterpolateVectorColor_Target(nint addr) : base(addr) { }
        public Vector Target { get { return this[nameof(Target)].As<Vector>(); } set { this["Target"] = value; } }
        public LinearColor Value { get { return this[nameof(Value)].As<LinearColor>(); } set { this["Value"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateVectorVector : RigUnit_MathRBFInterpolateVectorBase
    {
        public RigUnit_MathRBFInterpolateVectorVector(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateVectorVector_Target> Targets { get { return new Array<MathRBFInterpolateVectorVector_Target>(this[nameof(Targets)].Address); } }
        public Vector Output { get { return this[nameof(Output)].As<Vector>(); } set { this["Output"] = value; } }
    }
    public class MathRBFInterpolateVectorVector_Target : Object
    {
        public MathRBFInterpolateVectorVector_Target(nint addr) : base(addr) { }
        public Vector Target { get { return this[nameof(Target)].As<Vector>(); } set { this["Target"] = value; } }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateVectorFloat : RigUnit_MathRBFInterpolateVectorBase
    {
        public RigUnit_MathRBFInterpolateVectorFloat(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateVectorFloat_Target> Targets { get { return new Array<MathRBFInterpolateVectorFloat_Target>(this[nameof(Targets)].Address); } }
        public float Output { get { return this[nameof(Output)].GetValue<float>(); } set { this[nameof(Output)].SetValue<float>(value); } }
    }
    public class MathRBFInterpolateVectorFloat_Target : Object
    {
        public MathRBFInterpolateVectorFloat_Target(nint addr) : base(addr) { }
        public Vector Target { get { return this[nameof(Target)].As<Vector>(); } set { this["Target"] = value; } }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
    }
    public class RigUnit_MathRBFInterpolateQuatBase : RigUnit_MathRBFInterpolateBase
    {
        public RigUnit_MathRBFInterpolateQuatBase(nint addr) : base(addr) { }
        public Quat Input { get { return this[nameof(Input)].As<Quat>(); } set { this["Input"] = value; } }
        public ERBFQuatDistanceType DistanceFunction { get { return (ERBFQuatDistanceType)this[nameof(DistanceFunction)].GetValue<int>(); } set { this[nameof(DistanceFunction)].SetValue<int>((int)value); } }
        public ERBFKernelType SmoothingFunction { get { return (ERBFKernelType)this[nameof(SmoothingFunction)].GetValue<int>(); } set { this[nameof(SmoothingFunction)].SetValue<int>((int)value); } }
        public float SmoothingAngle { get { return this[nameof(SmoothingAngle)].GetValue<float>(); } set { this[nameof(SmoothingAngle)].SetValue<float>(value); } }
        public bool bNormalizeOutput { get { return this[nameof(bNormalizeOutput)].Flag; } set { this[nameof(bNormalizeOutput)].Flag = value; } }
        public Vector TwistAxis { get { return this[nameof(TwistAxis)].As<Vector>(); } set { this["TwistAxis"] = value; } }
        public RigUnit_MathRBFInterpolateQuatWorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_MathRBFInterpolateQuatWorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateQuatWorkData : Object
    {
        public RigUnit_MathRBFInterpolateQuatWorkData(nint addr) : base(addr) { }
    }
    public class RigUnit_MathRBFInterpolateQuatXform : RigUnit_MathRBFInterpolateQuatBase
    {
        public RigUnit_MathRBFInterpolateQuatXform(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateQuatXform_Target> Targets { get { return new Array<MathRBFInterpolateQuatXform_Target>(this[nameof(Targets)].Address); } }
        public Transform Output { get { return this[nameof(Output)].As<Transform>(); } set { this["Output"] = value; } }
    }
    public class MathRBFInterpolateQuatXform_Target : Object
    {
        public MathRBFInterpolateQuatXform_Target(nint addr) : base(addr) { }
        public Quat Target { get { return this[nameof(Target)].As<Quat>(); } set { this["Target"] = value; } }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateQuatQuat : RigUnit_MathRBFInterpolateQuatBase
    {
        public RigUnit_MathRBFInterpolateQuatQuat(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateQuatQuat_Target> Targets { get { return new Array<MathRBFInterpolateQuatQuat_Target>(this[nameof(Targets)].Address); } }
        public Quat Output { get { return this[nameof(Output)].As<Quat>(); } set { this["Output"] = value; } }
    }
    public class MathRBFInterpolateQuatQuat_Target : Object
    {
        public MathRBFInterpolateQuatQuat_Target(nint addr) : base(addr) { }
        public Quat Target { get { return this[nameof(Target)].As<Quat>(); } set { this["Target"] = value; } }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateQuatColor : RigUnit_MathRBFInterpolateQuatBase
    {
        public RigUnit_MathRBFInterpolateQuatColor(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateQuatColor_Target> Targets { get { return new Array<MathRBFInterpolateQuatColor_Target>(this[nameof(Targets)].Address); } }
        public LinearColor Output { get { return this[nameof(Output)].As<LinearColor>(); } set { this["Output"] = value; } }
    }
    public class MathRBFInterpolateQuatColor_Target : Object
    {
        public MathRBFInterpolateQuatColor_Target(nint addr) : base(addr) { }
        public Quat Target { get { return this[nameof(Target)].As<Quat>(); } set { this["Target"] = value; } }
        public LinearColor Value { get { return this[nameof(Value)].As<LinearColor>(); } set { this["Value"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateQuatVector : RigUnit_MathRBFInterpolateQuatBase
    {
        public RigUnit_MathRBFInterpolateQuatVector(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateQuatVector_Target> Targets { get { return new Array<MathRBFInterpolateQuatVector_Target>(this[nameof(Targets)].Address); } }
        public Vector Output { get { return this[nameof(Output)].As<Vector>(); } set { this["Output"] = value; } }
    }
    public class MathRBFInterpolateQuatVector_Target : Object
    {
        public MathRBFInterpolateQuatVector_Target(nint addr) : base(addr) { }
        public Quat Target { get { return this[nameof(Target)].As<Quat>(); } set { this["Target"] = value; } }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
    }
    public class RigUnit_MathRBFInterpolateQuatFloat : RigUnit_MathRBFInterpolateQuatBase
    {
        public RigUnit_MathRBFInterpolateQuatFloat(nint addr) : base(addr) { }
        public Array<MathRBFInterpolateQuatFloat_Target> Targets { get { return new Array<MathRBFInterpolateQuatFloat_Target>(this[nameof(Targets)].Address); } }
        public float Output { get { return this[nameof(Output)].GetValue<float>(); } set { this[nameof(Output)].SetValue<float>(value); } }
    }
    public class MathRBFInterpolateQuatFloat_Target : Object
    {
        public MathRBFInterpolateQuatFloat_Target(nint addr) : base(addr) { }
        public Quat Target { get { return this[nameof(Target)].As<Quat>(); } set { this["Target"] = value; } }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
    }
    public class RigUnit_MathTransformBase : RigUnit_MathBase
    {
        public RigUnit_MathTransformBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathTransformClampSpatially : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformClampSpatially(nint addr) : base(addr) { }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
        public byte Axis { get { return this[nameof(Axis)].GetValue<byte>(); } set { this[nameof(Axis)].SetValue<byte>(value); } }
        public byte Type { get { return this[nameof(Type)].GetValue<byte>(); } set { this[nameof(Type)].SetValue<byte>(value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public Transform Space { get { return this[nameof(Space)].As<Transform>(); } set { this["Space"] = value; } }
        public bool bDrawDebug { get { return this[nameof(bDrawDebug)].Flag; } set { this[nameof(bDrawDebug)].Flag = value; } }
        public LinearColor DebugColor { get { return this[nameof(DebugColor)].As<LinearColor>(); } set { this["DebugColor"] = value; } }
        public float DebugThickness { get { return this[nameof(DebugThickness)].GetValue<float>(); } set { this[nameof(DebugThickness)].SetValue<float>(value); } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathTransformFromSRT : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformFromSRT(nint addr) : base(addr) { }
        public Vector Location { get { return this[nameof(Location)].As<Vector>(); } set { this["Location"] = value; } }
        public Vector Rotation { get { return this[nameof(Rotation)].As<Vector>(); } set { this["Rotation"] = value; } }
        public EControlRigRotationOrder RotationOrder { get { return (EControlRigRotationOrder)this[nameof(RotationOrder)].GetValue<int>(); } set { this[nameof(RotationOrder)].SetValue<int>((int)value); } }
        public Vector Scale { get { return this[nameof(Scale)].As<Vector>(); } set { this["Scale"] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public EulerTransform EulerTransform { get { return this[nameof(EulerTransform)].As<EulerTransform>(); } set { this["EulerTransform"] = value; } }
    }
    public class RigUnit_MathTransformTransformVector : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformTransformVector(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Vector Location { get { return this[nameof(Location)].As<Vector>(); } set { this["Location"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathTransformRotateVector : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformRotateVector(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Vector Direction { get { return this[nameof(Direction)].As<Vector>(); } set { this["Direction"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathTransformSelectBool : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformSelectBool(nint addr) : base(addr) { }
        public bool Condition { get { return this[nameof(Condition)].Flag; } set { this[nameof(Condition)].Flag = value; } }
        public Transform IfTrue { get { return this[nameof(IfTrue)].As<Transform>(); } set { this["IfTrue"] = value; } }
        public Transform IfFalse { get { return this[nameof(IfFalse)].As<Transform>(); } set { this["IfFalse"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathTransformLerp : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformLerp(nint addr) : base(addr) { }
        public Transform A { get { return this[nameof(A)].As<Transform>(); } set { this["A"] = value; } }
        public Transform B { get { return this[nameof(B)].As<Transform>(); } set { this["B"] = value; } }
        public float T { get { return this[nameof(T)].GetValue<float>(); } set { this[nameof(T)].SetValue<float>(value); } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathTransformUnaryOp : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformUnaryOp(nint addr) : base(addr) { }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathTransformInverse : RigUnit_MathTransformUnaryOp
    {
        public RigUnit_MathTransformInverse(nint addr) : base(addr) { }
    }
    public class RigUnit_MathTransformMakeAbsolute : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformMakeAbsolute(nint addr) : base(addr) { }
        public Transform Local { get { return this[nameof(Local)].As<Transform>(); } set { this["Local"] = value; } }
        public Transform Parent { get { return this[nameof(Parent)].As<Transform>(); } set { this["Parent"] = value; } }
        public Transform Global { get { return this[nameof(Global)].As<Transform>(); } set { this["Global"] = value; } }
    }
    public class RigUnit_MathTransformMakeRelative : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformMakeRelative(nint addr) : base(addr) { }
        public Transform Global { get { return this[nameof(Global)].As<Transform>(); } set { this["Global"] = value; } }
        public Transform Parent { get { return this[nameof(Parent)].As<Transform>(); } set { this["Parent"] = value; } }
        public Transform Local { get { return this[nameof(Local)].As<Transform>(); } set { this["Local"] = value; } }
    }
    public class RigUnit_MathTransformBinaryOp : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformBinaryOp(nint addr) : base(addr) { }
        public Transform A { get { return this[nameof(A)].As<Transform>(); } set { this["A"] = value; } }
        public Transform B { get { return this[nameof(B)].As<Transform>(); } set { this["B"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathTransformMul : RigUnit_MathTransformBinaryOp
    {
        public RigUnit_MathTransformMul(nint addr) : base(addr) { }
    }
    public class RigUnit_MathTransformToEulerTransform : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformToEulerTransform(nint addr) : base(addr) { }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
        public EulerTransform Result { get { return this[nameof(Result)].As<EulerTransform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathTransformFromEulerTransform : RigUnit_MathTransformBase
    {
        public RigUnit_MathTransformFromEulerTransform(nint addr) : base(addr) { }
        public EulerTransform EulerTransform { get { return this[nameof(EulerTransform)].As<EulerTransform>(); } set { this["EulerTransform"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorBase : RigUnit_MathBase
    {
        public RigUnit_MathVectorBase(nint addr) : base(addr) { }
    }
    public class RigUnit_MathIntersectPlane : RigUnit_MathVectorBase
    {
        public RigUnit_MathIntersectPlane(nint addr) : base(addr) { }
        public Vector Start { get { return this[nameof(Start)].As<Vector>(); } set { this["Start"] = value; } }
        public Vector Direction { get { return this[nameof(Direction)].As<Vector>(); } set { this["Direction"] = value; } }
        public Vector PlanePoint { get { return this[nameof(PlanePoint)].As<Vector>(); } set { this["PlanePoint"] = value; } }
        public Vector PlaneNormal { get { return this[nameof(PlaneNormal)].As<Vector>(); } set { this["PlaneNormal"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public float Distance { get { return this[nameof(Distance)].GetValue<float>(); } set { this[nameof(Distance)].SetValue<float>(value); } }
    }
    public class RigUnit_MathVectorClampSpatially : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorClampSpatially(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public byte Axis { get { return this[nameof(Axis)].GetValue<byte>(); } set { this[nameof(Axis)].SetValue<byte>(value); } }
        public byte Type { get { return this[nameof(Type)].GetValue<byte>(); } set { this[nameof(Type)].SetValue<byte>(value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public Transform Space { get { return this[nameof(Space)].As<Transform>(); } set { this["Space"] = value; } }
        public bool bDrawDebug { get { return this[nameof(bDrawDebug)].Flag; } set { this[nameof(bDrawDebug)].Flag = value; } }
        public LinearColor DebugColor { get { return this[nameof(DebugColor)].As<LinearColor>(); } set { this["DebugColor"] = value; } }
        public float DebugThickness { get { return this[nameof(DebugThickness)].GetValue<float>(); } set { this[nameof(DebugThickness)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorMakeBezierFourPoint : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorMakeBezierFourPoint(nint addr) : base(addr) { }
        public CRFourPointBezier Bezier { get { return this[nameof(Bezier)].As<CRFourPointBezier>(); } set { this["Bezier"] = value; } }
    }
    public class RigUnit_MathVectorBezierFourPoint : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorBezierFourPoint(nint addr) : base(addr) { }
        public CRFourPointBezier Bezier { get { return this[nameof(Bezier)].As<CRFourPointBezier>(); } set { this["Bezier"] = value; } }
        public float T { get { return this[nameof(T)].GetValue<float>(); } set { this[nameof(T)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public Vector Tangent { get { return this[nameof(Tangent)].As<Vector>(); } set { this["Tangent"] = value; } }
    }
    public class RigUnit_MathVectorOrthogonal : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorOrthogonal(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathVectorParallel : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorParallel(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathVectorAngle : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorAngle(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathVectorMirror : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorMirror(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public Vector Normal { get { return this[nameof(Normal)].As<Vector>(); } set { this["Normal"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorClampLength : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorClampLength(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public float MinimumLength { get { return this[nameof(MinimumLength)].GetValue<float>(); } set { this[nameof(MinimumLength)].SetValue<float>(value); } }
        public float MaximumLength { get { return this[nameof(MaximumLength)].GetValue<float>(); } set { this[nameof(MaximumLength)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorSetLength : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorSetLength(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public float Length { get { return this[nameof(Length)].GetValue<float>(); } set { this[nameof(Length)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorUnaryOp : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorUnaryOp(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorUnit : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorUnit(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorDot : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorDot(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathVectorBinaryOp : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorBinaryOp(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorCross : RigUnit_MathVectorBinaryOp
    {
        public RigUnit_MathVectorCross(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorDistance : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorDistance(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathVectorLength : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorLength(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathVectorLengthSquared : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorLengthSquared(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_MathVectorRad : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorRad(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorDeg : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorDeg(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorSelectBool : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorSelectBool(nint addr) : base(addr) { }
        public bool Condition { get { return this[nameof(Condition)].Flag; } set { this[nameof(Condition)].Flag = value; } }
        public Vector IfTrue { get { return this[nameof(IfTrue)].As<Vector>(); } set { this["IfTrue"] = value; } }
        public Vector IfFalse { get { return this[nameof(IfFalse)].As<Vector>(); } set { this["IfFalse"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorIsNearlyEqual : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorIsNearlyEqual(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public float Tolerance { get { return this[nameof(Tolerance)].GetValue<float>(); } set { this[nameof(Tolerance)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathVectorIsNearlyZero : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorIsNearlyZero(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public float Tolerance { get { return this[nameof(Tolerance)].GetValue<float>(); } set { this[nameof(Tolerance)].SetValue<float>(value); } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathVectorNotEquals : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorNotEquals(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathVectorEquals : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorEquals(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_MathVectorRemap : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorRemap(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public Vector SourceMinimum { get { return this[nameof(SourceMinimum)].As<Vector>(); } set { this["SourceMinimum"] = value; } }
        public Vector SourceMaximum { get { return this[nameof(SourceMaximum)].As<Vector>(); } set { this["SourceMaximum"] = value; } }
        public Vector TargetMinimum { get { return this[nameof(TargetMinimum)].As<Vector>(); } set { this["TargetMinimum"] = value; } }
        public Vector TargetMaximum { get { return this[nameof(TargetMaximum)].As<Vector>(); } set { this["TargetMaximum"] = value; } }
        public bool bClamp { get { return this[nameof(bClamp)].Flag; } set { this[nameof(bClamp)].Flag = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorLerp : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorLerp(nint addr) : base(addr) { }
        public Vector A { get { return this[nameof(A)].As<Vector>(); } set { this["A"] = value; } }
        public Vector B { get { return this[nameof(B)].As<Vector>(); } set { this["B"] = value; } }
        public float T { get { return this[nameof(T)].GetValue<float>(); } set { this[nameof(T)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorClamp : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorClamp(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public Vector Minimum { get { return this[nameof(Minimum)].As<Vector>(); } set { this["Minimum"] = value; } }
        public Vector Maximum { get { return this[nameof(Maximum)].As<Vector>(); } set { this["Maximum"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorSign : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorSign(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorRound : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorRound(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorCeil : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorCeil(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorFloor : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorFloor(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorAbs : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorAbs(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorNegate : RigUnit_MathVectorUnaryOp
    {
        public RigUnit_MathVectorNegate(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorMax : RigUnit_MathVectorBinaryOp
    {
        public RigUnit_MathVectorMax(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorMin : RigUnit_MathVectorBinaryOp
    {
        public RigUnit_MathVectorMin(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorMod : RigUnit_MathVectorBinaryOp
    {
        public RigUnit_MathVectorMod(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorDiv : RigUnit_MathVectorBinaryOp
    {
        public RigUnit_MathVectorDiv(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorScale : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorScale(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public float Factor { get { return this[nameof(Factor)].GetValue<float>(); } set { this[nameof(Factor)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MathVectorMul : RigUnit_MathVectorBinaryOp
    {
        public RigUnit_MathVectorMul(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorSub : RigUnit_MathVectorBinaryOp
    {
        public RigUnit_MathVectorSub(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorAdd : RigUnit_MathVectorBinaryOp
    {
        public RigUnit_MathVectorAdd(nint addr) : base(addr) { }
    }
    public class RigUnit_MathVectorFromFloat : RigUnit_MathVectorBase
    {
        public RigUnit_MathVectorFromFloat(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_ModifyBoneTransforms : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_ModifyBoneTransforms(nint addr) : base(addr) { }
        public Array<RigUnit_ModifyBoneTransforms_PerBone> BoneToModify { get { return new Array<RigUnit_ModifyBoneTransforms_PerBone>(this[nameof(BoneToModify)].Address); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public float WeightMinimum { get { return this[nameof(WeightMinimum)].GetValue<float>(); } set { this[nameof(WeightMinimum)].SetValue<float>(value); } }
        public float WeightMaximum { get { return this[nameof(WeightMaximum)].GetValue<float>(); } set { this[nameof(WeightMaximum)].SetValue<float>(value); } }
        public EControlRigModifyBoneMode Mode { get { return (EControlRigModifyBoneMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public RigUnit_ModifyBoneTransforms_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_ModifyBoneTransforms_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_ModifyTransforms_WorkData : Object
    {
        public RigUnit_ModifyTransforms_WorkData(nint addr) : base(addr) { }
        public Array<CachedRigElement> CachedItems { get { return new Array<CachedRigElement>(this[nameof(CachedItems)].Address); } }
    }
    public class RigUnit_ModifyBoneTransforms_WorkData : RigUnit_ModifyTransforms_WorkData
    {
        public RigUnit_ModifyBoneTransforms_WorkData(nint addr) : base(addr) { }
    }
    public class RigUnit_ModifyBoneTransforms_PerBone : Object
    {
        public RigUnit_ModifyBoneTransforms_PerBone(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
    }
    public class RigUnit_ModifyTransforms : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_ModifyTransforms(nint addr) : base(addr) { }
        public Array<RigUnit_ModifyTransforms_PerItem> ItemToModify { get { return new Array<RigUnit_ModifyTransforms_PerItem>(this[nameof(ItemToModify)].Address); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public float WeightMinimum { get { return this[nameof(WeightMinimum)].GetValue<float>(); } set { this[nameof(WeightMinimum)].SetValue<float>(value); } }
        public float WeightMaximum { get { return this[nameof(WeightMaximum)].GetValue<float>(); } set { this[nameof(WeightMaximum)].SetValue<float>(value); } }
        public EControlRigModifyBoneMode Mode { get { return (EControlRigModifyBoneMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public RigUnit_ModifyTransforms_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_ModifyTransforms_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_ModifyTransforms_PerItem : Object
    {
        public RigUnit_ModifyTransforms_PerItem(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
    }
    public class RigUnit_MultiFABRIK : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_MultiFABRIK(nint addr) : base(addr) { }
        public Object RootBone { get { return this[nameof(RootBone)]; } set { this[nameof(RootBone)] = value; } }
        public Array<RigUnit_MultiFABRIK_EndEffector> Effectors { get { return new Array<RigUnit_MultiFABRIK_EndEffector>(this[nameof(Effectors)].Address); } }
        public float Precision { get { return this[nameof(Precision)].GetValue<float>(); } set { this[nameof(Precision)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public int MaxIterations { get { return this[nameof(MaxIterations)].GetValue<int>(); } set { this[nameof(MaxIterations)].SetValue<int>(value); } }
        public RigUnit_MultiFABRIK_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_MultiFABRIK_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_MultiFABRIK_WorkData : Object
    {
        public RigUnit_MultiFABRIK_WorkData(nint addr) : base(addr) { }
    }
    public class RigUnit_MultiFABRIK_EndEffector : Object
    {
        public RigUnit_MultiFABRIK_EndEffector(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Vector Location { get { return this[nameof(Location)].As<Vector>(); } set { this["Location"] = value; } }
    }
    public class RigUnit_NameBase : RigUnit
    {
        public RigUnit_NameBase(nint addr) : base(addr) { }
    }
    public class RigUnit_Contains : RigUnit_NameBase
    {
        public RigUnit_Contains(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Search { get { return this[nameof(Search)]; } set { this[nameof(Search)] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_StartsWith : RigUnit_NameBase
    {
        public RigUnit_StartsWith(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Start { get { return this[nameof(Start)]; } set { this[nameof(Start)] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_EndsWith : RigUnit_NameBase
    {
        public RigUnit_EndsWith(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Ending { get { return this[nameof(Ending)]; } set { this[nameof(Ending)] = value; } }
        public bool Result { get { return this[nameof(Result)].Flag; } set { this[nameof(Result)].Flag = value; } }
    }
    public class RigUnit_NameReplace : RigUnit_NameBase
    {
        public RigUnit_NameReplace(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Old { get { return this[nameof(Old)]; } set { this[nameof(Old)] = value; } }
        public Object New { get { return this[nameof(New)]; } set { this[nameof(New)] = value; } }
        public Object Result { get { return this[nameof(Result)]; } set { this[nameof(Result)] = value; } }
    }
    public class RigUnit_NameTruncate : RigUnit_NameBase
    {
        public RigUnit_NameTruncate(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public int Count { get { return this[nameof(Count)].GetValue<int>(); } set { this[nameof(Count)].SetValue<int>(value); } }
        public bool FromEnd { get { return this[nameof(FromEnd)].Flag; } set { this[nameof(FromEnd)].Flag = value; } }
        public Object Remainder { get { return this[nameof(Remainder)]; } set { this[nameof(Remainder)] = value; } }
        public Object Chopped { get { return this[nameof(Chopped)]; } set { this[nameof(Chopped)] = value; } }
    }
    public class RigUnit_NameConcat : RigUnit_NameBase
    {
        public RigUnit_NameConcat(nint addr) : base(addr) { }
        public Object A { get { return this[nameof(A)]; } set { this[nameof(A)] = value; } }
        public Object B { get { return this[nameof(B)]; } set { this[nameof(B)] = value; } }
        public Object Result { get { return this[nameof(Result)]; } set { this[nameof(Result)] = value; } }
    }
    public class RigUnit_NoiseVector : RigUnit_MathBase
    {
        public RigUnit_NoiseVector(nint addr) : base(addr) { }
        public Vector Position { get { return this[nameof(Position)].As<Vector>(); } set { this["Position"] = value; } }
        public Vector Speed { get { return this[nameof(Speed)].As<Vector>(); } set { this["Speed"] = value; } }
        public Vector Frequency { get { return this[nameof(Frequency)].As<Vector>(); } set { this["Frequency"] = value; } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public Vector Time { get { return this[nameof(Time)].As<Vector>(); } set { this["Time"] = value; } }
    }
    public class RigUnit_NoiseFloat : RigUnit_MathBase
    {
        public RigUnit_NoiseFloat(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float Speed { get { return this[nameof(Speed)].GetValue<float>(); } set { this[nameof(Speed)].SetValue<float>(value); } }
        public float Frequency { get { return this[nameof(Frequency)].GetValue<float>(); } set { this[nameof(Frequency)].SetValue<float>(value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public float Time { get { return this[nameof(Time)].GetValue<float>(); } set { this[nameof(Time)].SetValue<float>(value); } }
    }
    public class RigUnit_OffsetTransformForItem : RigUnitMutable
    {
        public RigUnit_OffsetTransformForItem(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public Transform OffsetTransform { get { return this[nameof(OffsetTransform)].As<Transform>(); } set { this["OffsetTransform"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedIndex { get { return this[nameof(CachedIndex)].As<CachedRigElement>(); } set { this["CachedIndex"] = value; } }
    }
    public class RigUnit_ParentSwitchConstraint : RigUnitMutable
    {
        public RigUnit_ParentSwitchConstraint(nint addr) : base(addr) { }
        public RigElementKey Subject { get { return this[nameof(Subject)].As<RigElementKey>(); } set { this["Subject"] = value; } }
        public int ParentIndex { get { return this[nameof(ParentIndex)].GetValue<int>(); } set { this[nameof(ParentIndex)].SetValue<int>(value); } }
        public RigElementKeyCollection Parents { get { return this[nameof(Parents)].As<RigElementKeyCollection>(); } set { this["Parents"] = value; } }
        public Transform InitialGlobalTransform { get { return this[nameof(InitialGlobalTransform)].As<Transform>(); } set { this["InitialGlobalTransform"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public bool Switched { get { return this[nameof(Switched)].Flag; } set { this[nameof(Switched)].Flag = value; } }
        public CachedRigElement CachedSubject { get { return this[nameof(CachedSubject)].As<CachedRigElement>(); } set { this["CachedSubject"] = value; } }
        public CachedRigElement CachedParent { get { return this[nameof(CachedParent)].As<CachedRigElement>(); } set { this["CachedParent"] = value; } }
        public Transform RelativeOffset { get { return this[nameof(RelativeOffset)].As<Transform>(); } set { this["RelativeOffset"] = value; } }
    }
    public class RigUnit_SimBaseMutable : RigUnitMutable
    {
        public RigUnit_SimBaseMutable(nint addr) : base(addr) { }
    }
    public class RigUnit_PointSimulation : RigUnit_SimBaseMutable
    {
        public RigUnit_PointSimulation(nint addr) : base(addr) { }
        public Array<CRSimPoint> Points { get { return new Array<CRSimPoint>(this[nameof(Points)].Address); } }
        public Array<CRSimLinearSpring> Links { get { return new Array<CRSimLinearSpring>(this[nameof(Links)].Address); } }
        public Array<CRSimPointForce> Forces { get { return new Array<CRSimPointForce>(this[nameof(Forces)].Address); } }
        public Array<CRSimSoftCollision> CollisionVolumes { get { return new Array<CRSimSoftCollision>(this[nameof(CollisionVolumes)].Address); } }
        public float SimulatedStepsPerSecond { get { return this[nameof(SimulatedStepsPerSecond)].GetValue<float>(); } set { this[nameof(SimulatedStepsPerSecond)].SetValue<float>(value); } }
        public ECRSimPointIntegrateType IntegratorType { get { return (ECRSimPointIntegrateType)this[nameof(IntegratorType)].GetValue<int>(); } set { this[nameof(IntegratorType)].SetValue<int>((int)value); } }
        public float VerletBlend { get { return this[nameof(VerletBlend)].GetValue<float>(); } set { this[nameof(VerletBlend)].SetValue<float>(value); } }
        public Array<RigUnit_PointSimulation_BoneTarget> BoneTargets { get { return new Array<RigUnit_PointSimulation_BoneTarget>(this[nameof(BoneTargets)].Address); } }
        public bool bLimitLocalPosition { get { return this[nameof(bLimitLocalPosition)].Flag; } set { this[nameof(bLimitLocalPosition)].Flag = value; } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public Vector PrimaryAimAxis { get { return this[nameof(PrimaryAimAxis)].As<Vector>(); } set { this["PrimaryAimAxis"] = value; } }
        public Vector SecondaryAimAxis { get { return this[nameof(SecondaryAimAxis)].As<Vector>(); } set { this["SecondaryAimAxis"] = value; } }
        public RigUnit_PointSimulation_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_PointSimulation_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public CRFourPointBezier Bezier { get { return this[nameof(Bezier)].As<CRFourPointBezier>(); } set { this["Bezier"] = value; } }
        public RigUnit_PointSimulation_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_PointSimulation_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_PointSimulation_WorkData : Object
    {
        public RigUnit_PointSimulation_WorkData(nint addr) : base(addr) { }
        public CRSimPointContainer Simulation { get { return this[nameof(Simulation)].As<CRSimPointContainer>(); } set { this["Simulation"] = value; } }
        public Array<CachedRigElement> BoneIndices { get { return new Array<CachedRigElement>(this[nameof(BoneIndices)].Address); } }
    }
    public class RigUnit_PointSimulation_DebugSettings : Object
    {
        public RigUnit_PointSimulation_DebugSettings(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public float CollisionScale { get { return this[nameof(CollisionScale)].GetValue<float>(); } set { this[nameof(CollisionScale)].SetValue<float>(value); } }
        public bool bDrawPointsAsSpheres { get { return this[nameof(bDrawPointsAsSpheres)].Flag; } set { this[nameof(bDrawPointsAsSpheres)].Flag = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
    }
    public class RigUnit_PointSimulation_BoneTarget : Object
    {
        public RigUnit_PointSimulation_BoneTarget(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public int TranslationPoint { get { return this[nameof(TranslationPoint)].GetValue<int>(); } set { this[nameof(TranslationPoint)].SetValue<int>(value); } }
        public int PrimaryAimPoint { get { return this[nameof(PrimaryAimPoint)].GetValue<int>(); } set { this[nameof(PrimaryAimPoint)].SetValue<int>(value); } }
        public int SecondaryAimPoint { get { return this[nameof(SecondaryAimPoint)].GetValue<int>(); } set { this[nameof(SecondaryAimPoint)].SetValue<int>(value); } }
    }
    public class RigUnit_PrepareForExecution : RigUnit
    {
        public RigUnit_PrepareForExecution(nint addr) : base(addr) { }
        public ControlRigExecuteContext ExecuteContext { get { return this[nameof(ExecuteContext)].As<ControlRigExecuteContext>(); } set { this["ExecuteContext"] = value; } }
    }
    public class RigUnit_EndProfilingTimer : RigUnit_DebugBaseMutable
    {
        public RigUnit_EndProfilingTimer(nint addr) : base(addr) { }
        public int NumberOfMeasurements { get { return this[nameof(NumberOfMeasurements)].GetValue<int>(); } set { this[nameof(NumberOfMeasurements)].SetValue<int>(value); } }
        public Object Prefix { get { return this[nameof(Prefix)]; } set { this[nameof(Prefix)] = value; } }
        public float AccumulatedTime { get { return this[nameof(AccumulatedTime)].GetValue<float>(); } set { this[nameof(AccumulatedTime)].SetValue<float>(value); } }
        public int MeasurementsLeft { get { return this[nameof(MeasurementsLeft)].GetValue<int>(); } set { this[nameof(MeasurementsLeft)].SetValue<int>(value); } }
    }
    public class RigUnit_StartProfilingTimer : RigUnit_DebugBaseMutable
    {
        public RigUnit_StartProfilingTimer(nint addr) : base(addr) { }
    }
    public class RigUnit_ProjectTransformToNewParent : RigUnit
    {
        public RigUnit_ProjectTransformToNewParent(nint addr) : base(addr) { }
        public RigElementKey Child { get { return this[nameof(Child)].As<RigElementKey>(); } set { this["Child"] = value; } }
        public bool bChildInitial { get { return this[nameof(bChildInitial)].Flag; } set { this[nameof(bChildInitial)].Flag = value; } }
        public RigElementKey OldParent { get { return this[nameof(OldParent)].As<RigElementKey>(); } set { this["OldParent"] = value; } }
        public bool bOldParentInitial { get { return this[nameof(bOldParentInitial)].Flag; } set { this[nameof(bOldParentInitial)].Flag = value; } }
        public RigElementKey NewParent { get { return this[nameof(NewParent)].As<RigElementKey>(); } set { this["NewParent"] = value; } }
        public bool bNewParentInitial { get { return this[nameof(bNewParentInitial)].Flag; } set { this[nameof(bNewParentInitial)].Flag = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public CachedRigElement CachedChild { get { return this[nameof(CachedChild)].As<CachedRigElement>(); } set { this["CachedChild"] = value; } }
        public CachedRigElement CachedOldParent { get { return this[nameof(CachedOldParent)].As<CachedRigElement>(); } set { this["CachedOldParent"] = value; } }
        public CachedRigElement CachedNewParent { get { return this[nameof(CachedNewParent)].As<CachedRigElement>(); } set { this["CachedNewParent"] = value; } }
    }
    public class RigUnit_PropagateTransform : RigUnitMutable
    {
        public RigUnit_PropagateTransform(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public bool bRecomputeGlobal { get { return this[nameof(bRecomputeGlobal)].Flag; } set { this[nameof(bRecomputeGlobal)].Flag = value; } }
        public bool bApplyToChildren { get { return this[nameof(bApplyToChildren)].Flag; } set { this[nameof(bApplyToChildren)].Flag = value; } }
        public bool bRecursive { get { return this[nameof(bRecursive)].Flag; } set { this[nameof(bRecursive)].Flag = value; } }
        public CachedRigElement CachedIndex { get { return this[nameof(CachedIndex)].As<CachedRigElement>(); } set { this["CachedIndex"] = value; } }
    }
    public class RigUnit_QuaternionToAngle : RigUnit
    {
        public RigUnit_QuaternionToAngle(nint addr) : base(addr) { }
        public Vector Axis { get { return this[nameof(Axis)].As<Vector>(); } set { this["Axis"] = value; } }
        public Quat Argument { get { return this[nameof(Argument)].As<Quat>(); } set { this["Argument"] = value; } }
        public float Angle { get { return this[nameof(Angle)].GetValue<float>(); } set { this[nameof(Angle)].SetValue<float>(value); } }
    }
    public class RigUnit_QuaternionFromAxisAndAngle : RigUnit
    {
        public RigUnit_QuaternionFromAxisAndAngle(nint addr) : base(addr) { }
        public Vector Axis { get { return this[nameof(Axis)].As<Vector>(); } set { this["Axis"] = value; } }
        public float Angle { get { return this[nameof(Angle)].GetValue<float>(); } set { this[nameof(Angle)].SetValue<float>(value); } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_QuaternionToAxisAndAngle : RigUnit
    {
        public RigUnit_QuaternionToAxisAndAngle(nint addr) : base(addr) { }
        public Quat Argument { get { return this[nameof(Argument)].As<Quat>(); } set { this["Argument"] = value; } }
        public Vector Axis { get { return this[nameof(Axis)].As<Vector>(); } set { this["Axis"] = value; } }
        public float Angle { get { return this[nameof(Angle)].GetValue<float>(); } set { this[nameof(Angle)].SetValue<float>(value); } }
    }
    public class RigUnit_UnaryQuaternionOp : RigUnit
    {
        public RigUnit_UnaryQuaternionOp(nint addr) : base(addr) { }
        public Quat Argument { get { return this[nameof(Argument)].As<Quat>(); } set { this["Argument"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_InverseQuaterion : RigUnit_UnaryQuaternionOp
    {
        public RigUnit_InverseQuaterion(nint addr) : base(addr) { }
    }
    public class RigUnit_BinaryQuaternionOp : RigUnit
    {
        public RigUnit_BinaryQuaternionOp(nint addr) : base(addr) { }
        public Quat Argument0 { get { return this[nameof(Argument0)].As<Quat>(); } set { this["Argument0"] = value; } }
        public Quat Argument1 { get { return this[nameof(Argument1)].As<Quat>(); } set { this["Argument1"] = value; } }
        public Quat Result { get { return this[nameof(Result)].As<Quat>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_MultiplyQuaternion : RigUnit_BinaryQuaternionOp
    {
        public RigUnit_MultiplyQuaternion(nint addr) : base(addr) { }
    }
    public class RigUnit_RandomVector : RigUnit_MathBase
    {
        public RigUnit_RandomVector(nint addr) : base(addr) { }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public float Duration { get { return this[nameof(Duration)].GetValue<float>(); } set { this[nameof(Duration)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public Vector LastResult { get { return this[nameof(LastResult)].As<Vector>(); } set { this["LastResult"] = value; } }
        public int LastSeed { get { return this[nameof(LastSeed)].GetValue<int>(); } set { this[nameof(LastSeed)].SetValue<int>(value); } }
        public float TimeLeft { get { return this[nameof(TimeLeft)].GetValue<float>(); } set { this[nameof(TimeLeft)].SetValue<float>(value); } }
    }
    public class RigUnit_RandomFloat : RigUnit_MathBase
    {
        public RigUnit_RandomFloat(nint addr) : base(addr) { }
        public int Seed { get { return this[nameof(Seed)].GetValue<int>(); } set { this[nameof(Seed)].SetValue<int>(value); } }
        public float Minimum { get { return this[nameof(Minimum)].GetValue<float>(); } set { this[nameof(Minimum)].SetValue<float>(value); } }
        public float Maximum { get { return this[nameof(Maximum)].GetValue<float>(); } set { this[nameof(Maximum)].SetValue<float>(value); } }
        public float Duration { get { return this[nameof(Duration)].GetValue<float>(); } set { this[nameof(Duration)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public float LastResult { get { return this[nameof(LastResult)].GetValue<float>(); } set { this[nameof(LastResult)].SetValue<float>(value); } }
        public int LastSeed { get { return this[nameof(LastSeed)].GetValue<int>(); } set { this[nameof(LastSeed)].SetValue<int>(value); } }
        public float TimeLeft { get { return this[nameof(TimeLeft)].GetValue<float>(); } set { this[nameof(TimeLeft)].SetValue<float>(value); } }
    }
    public class RigUnit_SendEvent : RigUnitMutable
    {
        public RigUnit_SendEvent(nint addr) : base(addr) { }
        public ERigEvent Event { get { return (ERigEvent)this[nameof(Event)].GetValue<int>(); } set { this[nameof(Event)].SetValue<int>((int)value); } }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public float OffsetInSeconds { get { return this[nameof(OffsetInSeconds)].GetValue<float>(); } set { this[nameof(OffsetInSeconds)].SetValue<float>(value); } }
        public bool bEnable { get { return this[nameof(bEnable)].Flag; } set { this[nameof(bEnable)].Flag = value; } }
        public bool bOnlyDuringInteraction { get { return this[nameof(bOnlyDuringInteraction)].Flag; } set { this[nameof(bOnlyDuringInteraction)].Flag = value; } }
    }
    public class RigUnit_SequenceExecution : RigUnit
    {
        public RigUnit_SequenceExecution(nint addr) : base(addr) { }
        public ControlRigExecuteContext ExecuteContext { get { return this[nameof(ExecuteContext)].As<ControlRigExecuteContext>(); } set { this["ExecuteContext"] = value; } }
        public ControlRigExecuteContext A { get { return this[nameof(A)].As<ControlRigExecuteContext>(); } set { this["A"] = value; } }
        public ControlRigExecuteContext B { get { return this[nameof(B)].As<ControlRigExecuteContext>(); } set { this["B"] = value; } }
        public ControlRigExecuteContext C { get { return this[nameof(C)].As<ControlRigExecuteContext>(); } set { this["C"] = value; } }
        public ControlRigExecuteContext D { get { return this[nameof(D)].As<ControlRigExecuteContext>(); } set { this["D"] = value; } }
    }
    public class RigUnit_SetBoneInitialTransform : RigUnitMutable
    {
        public RigUnit_SetBoneInitialTransform(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
    }
    public class RigUnit_SetBoneRotation : RigUnitMutable
    {
        public RigUnit_SetBoneRotation(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Quat Rotation { get { return this[nameof(Rotation)].As<Quat>(); } set { this["Rotation"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
    }
    public class RigUnit_SetBoneTransform : RigUnitMutable
    {
        public RigUnit_SetBoneTransform(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
    }
    public class RigUnit_SetBoneTranslation : RigUnitMutable
    {
        public RigUnit_SetBoneTranslation(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Vector Translation { get { return this[nameof(Translation)].As<Vector>(); } set { this["Translation"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
    }
    public class RigUnit_SetControlColor : RigUnitMutable
    {
        public RigUnit_SetControlColor(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetControlOffset : RigUnitMutable
    {
        public RigUnit_SetControlOffset(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public Transform Offset { get { return this[nameof(Offset)].As<Transform>(); } set { this["Offset"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetControlTransform : RigUnitMutable
    {
        public RigUnit_SetControlTransform(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetMultiControlRotator : RigUnitMutable
    {
        public RigUnit_SetMultiControlRotator(nint addr) : base(addr) { }
        public Array<RigUnit_SetMultiControlRotator_Entry> Entries { get { return new Array<RigUnit_SetMultiControlRotator_Entry>(this[nameof(Entries)].Address); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Array<CachedRigElement> CachedControlIndices { get { return new Array<CachedRigElement>(this[nameof(CachedControlIndices)].Address); } }
    }
    public class RigUnit_SetMultiControlRotator_Entry : Object
    {
        public RigUnit_SetMultiControlRotator_Entry(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public Rotator Rotator { get { return this[nameof(Rotator)].As<Rotator>(); } set { this["Rotator"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
    }
    public class RigUnit_SetControlRotator : RigUnitMutable
    {
        public RigUnit_SetControlRotator(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Rotator Rotator { get { return this[nameof(Rotator)].As<Rotator>(); } set { this["Rotator"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetControlVector : RigUnitMutable
    {
        public RigUnit_SetControlVector(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Vector Vector { get { return this[nameof(Vector)].As<Vector>(); } set { this["Vector"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetMultiControlVector2D : RigUnitMutable
    {
        public RigUnit_SetMultiControlVector2D(nint addr) : base(addr) { }
        public Array<RigUnit_SetMultiControlVector2D_Entry> Entries { get { return new Array<RigUnit_SetMultiControlVector2D_Entry>(this[nameof(Entries)].Address); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Array<CachedRigElement> CachedControlIndices { get { return new Array<CachedRigElement>(this[nameof(CachedControlIndices)].Address); } }
    }
    public class RigUnit_SetMultiControlVector2D_Entry : Object
    {
        public RigUnit_SetMultiControlVector2D_Entry(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public Vector2D Vector { get { return this[nameof(Vector)].As<Vector2D>(); } set { this["Vector"] = value; } }
    }
    public class RigUnit_SetControlVector2D : RigUnitMutable
    {
        public RigUnit_SetControlVector2D(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Vector2D Vector { get { return this[nameof(Vector)].As<Vector2D>(); } set { this["Vector"] = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetMultiControlInteger : RigUnitMutable
    {
        public RigUnit_SetMultiControlInteger(nint addr) : base(addr) { }
        public Array<RigUnit_SetMultiControlInteger_Entry> Entries { get { return new Array<RigUnit_SetMultiControlInteger_Entry>(this[nameof(Entries)].Address); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Array<CachedRigElement> CachedControlIndices { get { return new Array<CachedRigElement>(this[nameof(CachedControlIndices)].Address); } }
    }
    public class RigUnit_SetMultiControlInteger_Entry : Object
    {
        public RigUnit_SetMultiControlInteger_Entry(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public int IntegerValue { get { return this[nameof(IntegerValue)].GetValue<int>(); } set { this[nameof(IntegerValue)].SetValue<int>(value); } }
    }
    public class RigUnit_SetControlInteger : RigUnitMutable
    {
        public RigUnit_SetControlInteger(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public int Weight { get { return this[nameof(Weight)].GetValue<int>(); } set { this[nameof(Weight)].SetValue<int>(value); } }
        public int IntegerValue { get { return this[nameof(IntegerValue)].GetValue<int>(); } set { this[nameof(IntegerValue)].SetValue<int>(value); } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetMultiControlFloat : RigUnitMutable
    {
        public RigUnit_SetMultiControlFloat(nint addr) : base(addr) { }
        public Array<RigUnit_SetMultiControlFloat_Entry> Entries { get { return new Array<RigUnit_SetMultiControlFloat_Entry>(this[nameof(Entries)].Address); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Array<CachedRigElement> CachedControlIndices { get { return new Array<CachedRigElement>(this[nameof(CachedControlIndices)].Address); } }
    }
    public class RigUnit_SetMultiControlFloat_Entry : Object
    {
        public RigUnit_SetMultiControlFloat_Entry(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public float FloatValue { get { return this[nameof(FloatValue)].GetValue<float>(); } set { this[nameof(FloatValue)].SetValue<float>(value); } }
    }
    public class RigUnit_SetControlFloat : RigUnitMutable
    {
        public RigUnit_SetControlFloat(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public float FloatValue { get { return this[nameof(FloatValue)].GetValue<float>(); } set { this[nameof(FloatValue)].SetValue<float>(value); } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetMultiControlBool : RigUnitMutable
    {
        public RigUnit_SetMultiControlBool(nint addr) : base(addr) { }
        public Array<RigUnit_SetMultiControlBool_Entry> Entries { get { return new Array<RigUnit_SetMultiControlBool_Entry>(this[nameof(Entries)].Address); } }
        public Array<CachedRigElement> CachedControlIndices { get { return new Array<CachedRigElement>(this[nameof(CachedControlIndices)].Address); } }
    }
    public class RigUnit_SetMultiControlBool_Entry : Object
    {
        public RigUnit_SetMultiControlBool_Entry(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public bool boolValue { get { return this[nameof(boolValue)].Flag; } set { this[nameof(boolValue)].Flag = value; } }
    }
    public class RigUnit_SetControlBool : RigUnitMutable
    {
        public RigUnit_SetControlBool(nint addr) : base(addr) { }
        public Object Control { get { return this[nameof(Control)]; } set { this[nameof(Control)] = value; } }
        public bool boolValue { get { return this[nameof(boolValue)].Flag; } set { this[nameof(boolValue)].Flag = value; } }
        public CachedRigElement CachedControlIndex { get { return this[nameof(CachedControlIndex)].As<CachedRigElement>(); } set { this["CachedControlIndex"] = value; } }
    }
    public class RigUnit_SetControlVisibility : RigUnitMutable
    {
        public RigUnit_SetControlVisibility(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public Object Pattern { get { return this[nameof(Pattern)]; } set { this[nameof(Pattern)] = value; } }
        public bool bVisible { get { return this[nameof(bVisible)].Flag; } set { this[nameof(bVisible)].Flag = value; } }
        public Array<CachedRigElement> CachedControlIndices { get { return new Array<CachedRigElement>(this[nameof(CachedControlIndices)].Address); } }
    }
    public class RigUnit_SetCurveValue : RigUnitMutable
    {
        public RigUnit_SetCurveValue(nint addr) : base(addr) { }
        public Object Curve { get { return this[nameof(Curve)]; } set { this[nameof(Curve)] = value; } }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public CachedRigElement CachedCurveIndex { get { return this[nameof(CachedCurveIndex)].As<CachedRigElement>(); } set { this["CachedCurveIndex"] = value; } }
    }
    public class RigUnit_SetRelativeBoneTransform : RigUnitMutable
    {
        public RigUnit_SetRelativeBoneTransform(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedBone { get { return this[nameof(CachedBone)].As<CachedRigElement>(); } set { this["CachedBone"] = value; } }
        public CachedRigElement CachedSpaceIndex { get { return this[nameof(CachedSpaceIndex)].As<CachedRigElement>(); } set { this["CachedSpaceIndex"] = value; } }
    }
    public class RigUnit_SetRelativeTransformForItem : RigUnitMutable
    {
        public RigUnit_SetRelativeTransformForItem(nint addr) : base(addr) { }
        public RigElementKey Child { get { return this[nameof(Child)].As<RigElementKey>(); } set { this["Child"] = value; } }
        public RigElementKey Parent { get { return this[nameof(Parent)].As<RigElementKey>(); } set { this["Parent"] = value; } }
        public bool bParentInitial { get { return this[nameof(bParentInitial)].Flag; } set { this[nameof(bParentInitial)].Flag = value; } }
        public Transform RelativeTransform { get { return this[nameof(RelativeTransform)].As<Transform>(); } set { this["RelativeTransform"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedChild { get { return this[nameof(CachedChild)].As<CachedRigElement>(); } set { this["CachedChild"] = value; } }
        public CachedRigElement CachedParent { get { return this[nameof(CachedParent)].As<CachedRigElement>(); } set { this["CachedParent"] = value; } }
    }
    public class RigUnit_SetSpaceInitialTransform : RigUnitMutable
    {
        public RigUnit_SetSpaceInitialTransform(nint addr) : base(addr) { }
        public Object SpaceName { get { return this[nameof(SpaceName)]; } set { this[nameof(SpaceName)] = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public CachedRigElement CachedSpaceIndex { get { return this[nameof(CachedSpaceIndex)].As<CachedRigElement>(); } set { this["CachedSpaceIndex"] = value; } }
    }
    public class RigUnit_SetSpaceTransform : RigUnitMutable
    {
        public RigUnit_SetSpaceTransform(nint addr) : base(addr) { }
        public Object Space { get { return this[nameof(Space)]; } set { this[nameof(Space)] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public EBoneGetterSetterMode SpaceType { get { return (EBoneGetterSetterMode)this[nameof(SpaceType)].GetValue<int>(); } set { this[nameof(SpaceType)].SetValue<int>((int)value); } }
        public CachedRigElement CachedSpaceIndex { get { return this[nameof(CachedSpaceIndex)].As<CachedRigElement>(); } set { this["CachedSpaceIndex"] = value; } }
    }
    public class RigUnit_SetScale : RigUnitMutable
    {
        public RigUnit_SetScale(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Vector Scale { get { return this[nameof(Scale)].As<Vector>(); } set { this["Scale"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedIndex { get { return this[nameof(CachedIndex)].As<CachedRigElement>(); } set { this["CachedIndex"] = value; } }
    }
    public class RigUnit_SetRotation : RigUnitMutable
    {
        public RigUnit_SetRotation(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Quat Rotation { get { return this[nameof(Rotation)].As<Quat>(); } set { this["Rotation"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedIndex { get { return this[nameof(CachedIndex)].As<CachedRigElement>(); } set { this["CachedIndex"] = value; } }
    }
    public class RigUnit_SetTranslation : RigUnitMutable
    {
        public RigUnit_SetTranslation(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public Vector Translation { get { return this[nameof(Translation)].As<Vector>(); } set { this["Translation"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedIndex { get { return this[nameof(CachedIndex)].As<CachedRigElement>(); } set { this["CachedIndex"] = value; } }
    }
    public class RigUnit_SetTransform : RigUnitMutable
    {
        public RigUnit_SetTransform(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public EBoneGetterSetterMode Space { get { return (EBoneGetterSetterMode)this[nameof(Space)].GetValue<int>(); } set { this[nameof(Space)].SetValue<int>((int)value); } }
        public bool bInitial { get { return this[nameof(bInitial)].Flag; } set { this[nameof(bInitial)].Flag = value; } }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public CachedRigElement CachedIndex { get { return this[nameof(CachedIndex)].As<CachedRigElement>(); } set { this["CachedIndex"] = value; } }
    }
    public class RigUnit_SlideChainPerItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_SlideChainPerItem(nint addr) : base(addr) { }
        public RigElementKeyCollection Items { get { return this[nameof(Items)].As<RigElementKeyCollection>(); } set { this["Items"] = value; } }
        public float SlideAmount { get { return this[nameof(SlideAmount)].GetValue<float>(); } set { this[nameof(SlideAmount)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_SlideChain_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_SlideChain_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_SlideChain_WorkData : Object
    {
        public RigUnit_SlideChain_WorkData(nint addr) : base(addr) { }
        public float ChainLength { get { return this[nameof(ChainLength)].GetValue<float>(); } set { this[nameof(ChainLength)].SetValue<float>(value); } }
        public Array<float> ItemSegments { get { return new Array<float>(this[nameof(ItemSegments)].Address); } }
        public Array<CachedRigElement> CachedItems { get { return new Array<CachedRigElement>(this[nameof(CachedItems)].Address); } }
        public Array<Transform> Transforms { get { return new Array<Transform>(this[nameof(Transforms)].Address); } }
        public Array<Transform> BlendedTransforms { get { return new Array<Transform>(this[nameof(BlendedTransforms)].Address); } }
    }
    public class RigUnit_SlideChain : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_SlideChain(nint addr) : base(addr) { }
        public Object StartBone { get { return this[nameof(StartBone)]; } set { this[nameof(StartBone)] = value; } }
        public Object EndBone { get { return this[nameof(EndBone)]; } set { this[nameof(EndBone)] = value; } }
        public float SlideAmount { get { return this[nameof(SlideAmount)].GetValue<float>(); } set { this[nameof(SlideAmount)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_SlideChain_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_SlideChain_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_SpringIK : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_SpringIK(nint addr) : base(addr) { }
        public Object StartBone { get { return this[nameof(StartBone)]; } set { this[nameof(StartBone)] = value; } }
        public Object EndBone { get { return this[nameof(EndBone)]; } set { this[nameof(EndBone)] = value; } }
        public float HierarchyStrength { get { return this[nameof(HierarchyStrength)].GetValue<float>(); } set { this[nameof(HierarchyStrength)].SetValue<float>(value); } }
        public float EffectorStrength { get { return this[nameof(EffectorStrength)].GetValue<float>(); } set { this[nameof(EffectorStrength)].SetValue<float>(value); } }
        public float EffectorRatio { get { return this[nameof(EffectorRatio)].GetValue<float>(); } set { this[nameof(EffectorRatio)].SetValue<float>(value); } }
        public float RootStrength { get { return this[nameof(RootStrength)].GetValue<float>(); } set { this[nameof(RootStrength)].SetValue<float>(value); } }
        public float RootRatio { get { return this[nameof(RootRatio)].GetValue<float>(); } set { this[nameof(RootRatio)].SetValue<float>(value); } }
        public float Damping { get { return this[nameof(Damping)].GetValue<float>(); } set { this[nameof(Damping)].SetValue<float>(value); } }
        public Vector PoleVector { get { return this[nameof(PoleVector)].As<Vector>(); } set { this["PoleVector"] = value; } }
        public bool bFlipPolePlane { get { return this[nameof(bFlipPolePlane)].Flag; } set { this[nameof(bFlipPolePlane)].Flag = value; } }
        public EControlRigVectorKind PoleVectorKind { get { return (EControlRigVectorKind)this[nameof(PoleVectorKind)].GetValue<int>(); } set { this[nameof(PoleVectorKind)].SetValue<int>((int)value); } }
        public Object PoleVectorSpace { get { return this[nameof(PoleVectorSpace)]; } set { this[nameof(PoleVectorSpace)] = value; } }
        public Vector PrimaryAxis { get { return this[nameof(PrimaryAxis)].As<Vector>(); } set { this["PrimaryAxis"] = value; } }
        public Vector SecondaryAxis { get { return this[nameof(SecondaryAxis)].As<Vector>(); } set { this["SecondaryAxis"] = value; } }
        public bool bLiveSimulation { get { return this[nameof(bLiveSimulation)].Flag; } set { this[nameof(bLiveSimulation)].Flag = value; } }
        public int Iterations { get { return this[nameof(Iterations)].GetValue<int>(); } set { this[nameof(Iterations)].SetValue<int>(value); } }
        public bool bLimitLocalPosition { get { return this[nameof(bLimitLocalPosition)].Flag; } set { this[nameof(bLimitLocalPosition)].Flag = value; } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_SpringIK_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_SpringIK_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public RigUnit_SpringIK_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_SpringIK_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_SpringIK_WorkData : Object
    {
        public RigUnit_SpringIK_WorkData(nint addr) : base(addr) { }
        public Array<CachedRigElement> CachedBones { get { return new Array<CachedRigElement>(this[nameof(CachedBones)].Address); } }
        public CachedRigElement CachedPoleVector { get { return this[nameof(CachedPoleVector)].As<CachedRigElement>(); } set { this["CachedPoleVector"] = value; } }
        public Array<Transform> Transforms { get { return new Array<Transform>(this[nameof(Transforms)].Address); } }
        public CRSimPointContainer Simulation { get { return this[nameof(Simulation)].As<CRSimPointContainer>(); } set { this["Simulation"] = value; } }
    }
    public class RigUnit_SpringIK_DebugSettings : Object
    {
        public RigUnit_SpringIK_DebugSettings(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
    }
    public class RigUnit_SecondsToFrames : RigUnit_AnimBase
    {
        public RigUnit_SecondsToFrames(nint addr) : base(addr) { }
        public float Seconds { get { return this[nameof(Seconds)].GetValue<float>(); } set { this[nameof(Seconds)].SetValue<float>(value); } }
        public float Frames { get { return this[nameof(Frames)].GetValue<float>(); } set { this[nameof(Frames)].SetValue<float>(value); } }
    }
    public class RigUnit_FramesToSeconds : RigUnit_AnimBase
    {
        public RigUnit_FramesToSeconds(nint addr) : base(addr) { }
        public float Frames { get { return this[nameof(Frames)].GetValue<float>(); } set { this[nameof(Frames)].SetValue<float>(value); } }
        public float Seconds { get { return this[nameof(Seconds)].GetValue<float>(); } set { this[nameof(Seconds)].SetValue<float>(value); } }
    }
    public class RigUnit_Timeline : RigUnit_SimBase
    {
        public RigUnit_Timeline(nint addr) : base(addr) { }
        public float Speed { get { return this[nameof(Speed)].GetValue<float>(); } set { this[nameof(Speed)].SetValue<float>(value); } }
        public float Time { get { return this[nameof(Time)].GetValue<float>(); } set { this[nameof(Time)].SetValue<float>(value); } }
        public float AccumulatedValue { get { return this[nameof(AccumulatedValue)].GetValue<float>(); } set { this[nameof(AccumulatedValue)].SetValue<float>(value); } }
    }
    public class RigUnit_TimeOffsetTransform : RigUnit_SimBase
    {
        public RigUnit_TimeOffsetTransform(nint addr) : base(addr) { }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
        public float SecondsAgo { get { return this[nameof(SecondsAgo)].GetValue<float>(); } set { this[nameof(SecondsAgo)].SetValue<float>(value); } }
        public int BufferSize { get { return this[nameof(BufferSize)].GetValue<int>(); } set { this[nameof(BufferSize)].SetValue<int>(value); } }
        public float TimeRange { get { return this[nameof(TimeRange)].GetValue<float>(); } set { this[nameof(TimeRange)].SetValue<float>(value); } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
        public Array<Transform> Buffer { get { return new Array<Transform>(this[nameof(Buffer)].Address); } }
        public Array<float> DeltaTimes { get { return new Array<float>(this[nameof(DeltaTimes)].Address); } }
        public int LastInsertIndex { get { return this[nameof(LastInsertIndex)].GetValue<int>(); } set { this[nameof(LastInsertIndex)].SetValue<int>(value); } }
        public int UpperBound { get { return this[nameof(UpperBound)].GetValue<int>(); } set { this[nameof(UpperBound)].SetValue<int>(value); } }
    }
    public class RigUnit_TimeOffsetVector : RigUnit_SimBase
    {
        public RigUnit_TimeOffsetVector(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public float SecondsAgo { get { return this[nameof(SecondsAgo)].GetValue<float>(); } set { this[nameof(SecondsAgo)].SetValue<float>(value); } }
        public int BufferSize { get { return this[nameof(BufferSize)].GetValue<int>(); } set { this[nameof(BufferSize)].SetValue<int>(value); } }
        public float TimeRange { get { return this[nameof(TimeRange)].GetValue<float>(); } set { this[nameof(TimeRange)].SetValue<float>(value); } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
        public Array<Vector> Buffer { get { return new Array<Vector>(this[nameof(Buffer)].Address); } }
        public Array<float> DeltaTimes { get { return new Array<float>(this[nameof(DeltaTimes)].Address); } }
        public int LastInsertIndex { get { return this[nameof(LastInsertIndex)].GetValue<int>(); } set { this[nameof(LastInsertIndex)].SetValue<int>(value); } }
        public int UpperBound { get { return this[nameof(UpperBound)].GetValue<int>(); } set { this[nameof(UpperBound)].SetValue<int>(value); } }
    }
    public class RigUnit_TimeOffsetFloat : RigUnit_SimBase
    {
        public RigUnit_TimeOffsetFloat(nint addr) : base(addr) { }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
        public float SecondsAgo { get { return this[nameof(SecondsAgo)].GetValue<float>(); } set { this[nameof(SecondsAgo)].SetValue<float>(value); } }
        public int BufferSize { get { return this[nameof(BufferSize)].GetValue<int>(); } set { this[nameof(BufferSize)].SetValue<int>(value); } }
        public float TimeRange { get { return this[nameof(TimeRange)].GetValue<float>(); } set { this[nameof(TimeRange)].SetValue<float>(value); } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
        public Array<float> Buffer { get { return new Array<float>(this[nameof(Buffer)].Address); } }
        public Array<float> DeltaTimes { get { return new Array<float>(this[nameof(DeltaTimes)].Address); } }
        public int LastInsertIndex { get { return this[nameof(LastInsertIndex)].GetValue<int>(); } set { this[nameof(LastInsertIndex)].SetValue<int>(value); } }
        public int UpperBound { get { return this[nameof(UpperBound)].GetValue<int>(); } set { this[nameof(UpperBound)].SetValue<int>(value); } }
    }
    public class RigUnit_BinaryTransformOp : RigUnit
    {
        public RigUnit_BinaryTransformOp(nint addr) : base(addr) { }
        public Transform Argument0 { get { return this[nameof(Argument0)].As<Transform>(); } set { this["Argument0"] = value; } }
        public Transform Argument1 { get { return this[nameof(Argument1)].As<Transform>(); } set { this["Argument1"] = value; } }
        public Transform Result { get { return this[nameof(Result)].As<Transform>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_GetRelativeTransform : RigUnit_BinaryTransformOp
    {
        public RigUnit_GetRelativeTransform(nint addr) : base(addr) { }
    }
    public class RigUnit_MultiplyTransform : RigUnit_BinaryTransformOp
    {
        public RigUnit_MultiplyTransform(nint addr) : base(addr) { }
    }
    public class RigUnit_TransformConstraintPerItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_TransformConstraintPerItem(nint addr) : base(addr) { }
        public RigElementKey Item { get { return this[nameof(Item)].As<RigElementKey>(); } set { this["Item"] = value; } }
        public ETransformSpaceMode BaseTransformSpace { get { return (ETransformSpaceMode)this[nameof(BaseTransformSpace)].GetValue<int>(); } set { this[nameof(BaseTransformSpace)].SetValue<int>((int)value); } }
        public Transform BaseTransform { get { return this[nameof(BaseTransform)].As<Transform>(); } set { this["BaseTransform"] = value; } }
        public RigElementKey BaseItem { get { return this[nameof(BaseItem)].As<RigElementKey>(); } set { this["BaseItem"] = value; } }
        public Array<ConstraintTarget> Targets { get { return new Array<ConstraintTarget>(this[nameof(Targets)].Address); } }
        public bool bUseInitialTransforms { get { return this[nameof(bUseInitialTransforms)].Flag; } set { this[nameof(bUseInitialTransforms)].Flag = value; } }
        public RigUnit_TransformConstraint_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_TransformConstraint_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_TransformConstraint_WorkData : Object
    {
        public RigUnit_TransformConstraint_WorkData(nint addr) : base(addr) { }
        public Array<ConstraintData> ConstraintData { get { return new Array<ConstraintData>(this[nameof(ConstraintData)].Address); } }
        public Object ConstraintDataToTargets { get { return this[nameof(ConstraintDataToTargets)]; } set { this[nameof(ConstraintDataToTargets)] = value; } }
    }
    public class ConstraintTarget : Object
    {
        public ConstraintTarget(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bMaintainOffset { get { return this[nameof(bMaintainOffset)].Flag; } set { this[nameof(bMaintainOffset)].Flag = value; } }
        public TransformFilter Filter { get { return this[nameof(Filter)].As<TransformFilter>(); } set { this["Filter"] = value; } }
    }
    public class RigUnit_TransformConstraint : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_TransformConstraint(nint addr) : base(addr) { }
        public Object Bone { get { return this[nameof(Bone)]; } set { this[nameof(Bone)] = value; } }
        public ETransformSpaceMode BaseTransformSpace { get { return (ETransformSpaceMode)this[nameof(BaseTransformSpace)].GetValue<int>(); } set { this[nameof(BaseTransformSpace)].SetValue<int>((int)value); } }
        public Transform BaseTransform { get { return this[nameof(BaseTransform)].As<Transform>(); } set { this["BaseTransform"] = value; } }
        public Object BaseBone { get { return this[nameof(BaseBone)]; } set { this[nameof(BaseBone)] = value; } }
        public Array<ConstraintTarget> Targets { get { return new Array<ConstraintTarget>(this[nameof(Targets)].Address); } }
        public bool bUseInitialTransforms { get { return this[nameof(bUseInitialTransforms)].Flag; } set { this[nameof(bUseInitialTransforms)].Flag = value; } }
        public RigUnit_TransformConstraint_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_TransformConstraint_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_TwistBonesPerItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_TwistBonesPerItem(nint addr) : base(addr) { }
        public RigElementKeyCollection Items { get { return this[nameof(Items)].As<RigElementKeyCollection>(); } set { this["Items"] = value; } }
        public Vector TwistAxis { get { return this[nameof(TwistAxis)].As<Vector>(); } set { this["TwistAxis"] = value; } }
        public Vector PoleAxis { get { return this[nameof(PoleAxis)].As<Vector>(); } set { this["PoleAxis"] = value; } }
        public EControlRigAnimEasingType TwistEaseType { get { return (EControlRigAnimEasingType)this[nameof(TwistEaseType)].GetValue<int>(); } set { this[nameof(TwistEaseType)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_TwistBones_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_TwistBones_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_TwistBones_WorkData : Object
    {
        public RigUnit_TwistBones_WorkData(nint addr) : base(addr) { }
        public Array<CachedRigElement> CachedItems { get { return new Array<CachedRigElement>(this[nameof(CachedItems)].Address); } }
        public Array<float> ItemRatios { get { return new Array<float>(this[nameof(ItemRatios)].Address); } }
        public Array<Transform> ItemTransforms { get { return new Array<Transform>(this[nameof(ItemTransforms)].Address); } }
    }
    public class RigUnit_TwistBones : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_TwistBones(nint addr) : base(addr) { }
        public Object StartBone { get { return this[nameof(StartBone)]; } set { this[nameof(StartBone)] = value; } }
        public Object EndBone { get { return this[nameof(EndBone)]; } set { this[nameof(EndBone)] = value; } }
        public Vector TwistAxis { get { return this[nameof(TwistAxis)].As<Vector>(); } set { this["TwistAxis"] = value; } }
        public Vector PoleAxis { get { return this[nameof(PoleAxis)].As<Vector>(); } set { this["PoleAxis"] = value; } }
        public EControlRigAnimEasingType TwistEaseType { get { return (EControlRigAnimEasingType)this[nameof(TwistEaseType)].GetValue<int>(); } set { this[nameof(TwistEaseType)].SetValue<int>((int)value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_TwistBones_WorkData WorkData { get { return this[nameof(WorkData)].As<RigUnit_TwistBones_WorkData>(); } set { this["WorkData"] = value; } }
    }
    public class RigUnit_TwoBoneIKFK : RigUnitMutable
    {
        public RigUnit_TwoBoneIKFK(nint addr) : base(addr) { }
        public Object StartJoint { get { return this[nameof(StartJoint)]; } set { this[nameof(StartJoint)] = value; } }
        public Object EndJoint { get { return this[nameof(EndJoint)]; } set { this[nameof(EndJoint)] = value; } }
        public Vector PoleTarget { get { return this[nameof(PoleTarget)].As<Vector>(); } set { this["PoleTarget"] = value; } }
        public float Spin { get { return this[nameof(Spin)].GetValue<float>(); } set { this[nameof(Spin)].SetValue<float>(value); } }
        public Transform EndEffector { get { return this[nameof(EndEffector)].As<Transform>(); } set { this["EndEffector"] = value; } }
        public float IKBlend { get { return this[nameof(IKBlend)].GetValue<float>(); } set { this[nameof(IKBlend)].SetValue<float>(value); } }
        public Transform StartJointFKTransform { get { return this[nameof(StartJointFKTransform)].As<Transform>(); } set { this["StartJointFKTransform"] = value; } }
        public Transform MidJointFKTransform { get { return this[nameof(MidJointFKTransform)].As<Transform>(); } set { this["MidJointFKTransform"] = value; } }
        public Transform EndJointFKTransform { get { return this[nameof(EndJointFKTransform)].As<Transform>(); } set { this["EndJointFKTransform"] = value; } }
        public float PreviousFKIKBlend { get { return this[nameof(PreviousFKIKBlend)].GetValue<float>(); } set { this[nameof(PreviousFKIKBlend)].SetValue<float>(value); } }
        public Transform StartJointIKTransform { get { return this[nameof(StartJointIKTransform)].As<Transform>(); } set { this["StartJointIKTransform"] = value; } }
        public Transform MidJointIKTransform { get { return this[nameof(MidJointIKTransform)].As<Transform>(); } set { this["MidJointIKTransform"] = value; } }
        public Transform EndJointIKTransform { get { return this[nameof(EndJointIKTransform)].As<Transform>(); } set { this["EndJointIKTransform"] = value; } }
        public int StartJointIndex { get { return this[nameof(StartJointIndex)].GetValue<int>(); } set { this[nameof(StartJointIndex)].SetValue<int>(value); } }
        public int MidJointIndex { get { return this[nameof(MidJointIndex)].GetValue<int>(); } set { this[nameof(MidJointIndex)].SetValue<int>(value); } }
        public int EndJointIndex { get { return this[nameof(EndJointIndex)].GetValue<int>(); } set { this[nameof(EndJointIndex)].SetValue<int>(value); } }
        public float UpperLimbLength { get { return this[nameof(UpperLimbLength)].GetValue<float>(); } set { this[nameof(UpperLimbLength)].SetValue<float>(value); } }
        public float LowerLimbLength { get { return this[nameof(LowerLimbLength)].GetValue<float>(); } set { this[nameof(LowerLimbLength)].SetValue<float>(value); } }
    }
    public class RigUnit_TwoBoneIKSimpleTransforms : RigUnit_HighlevelBase
    {
        public RigUnit_TwoBoneIKSimpleTransforms(nint addr) : base(addr) { }
        public Transform Root { get { return this[nameof(Root)].As<Transform>(); } set { this["Root"] = value; } }
        public Vector PoleVector { get { return this[nameof(PoleVector)].As<Vector>(); } set { this["PoleVector"] = value; } }
        public Transform Effector { get { return this[nameof(Effector)].As<Transform>(); } set { this["Effector"] = value; } }
        public Vector PrimaryAxis { get { return this[nameof(PrimaryAxis)].As<Vector>(); } set { this["PrimaryAxis"] = value; } }
        public Vector SecondaryAxis { get { return this[nameof(SecondaryAxis)].As<Vector>(); } set { this["SecondaryAxis"] = value; } }
        public float SecondaryAxisWeight { get { return this[nameof(SecondaryAxisWeight)].GetValue<float>(); } set { this[nameof(SecondaryAxisWeight)].SetValue<float>(value); } }
        public bool bEnableStretch { get { return this[nameof(bEnableStretch)].Flag; } set { this[nameof(bEnableStretch)].Flag = value; } }
        public float StretchStartRatio { get { return this[nameof(StretchStartRatio)].GetValue<float>(); } set { this[nameof(StretchStartRatio)].SetValue<float>(value); } }
        public float StretchMaximumRatio { get { return this[nameof(StretchMaximumRatio)].GetValue<float>(); } set { this[nameof(StretchMaximumRatio)].SetValue<float>(value); } }
        public float BoneALength { get { return this[nameof(BoneALength)].GetValue<float>(); } set { this[nameof(BoneALength)].SetValue<float>(value); } }
        public float BoneBLength { get { return this[nameof(BoneBLength)].GetValue<float>(); } set { this[nameof(BoneBLength)].SetValue<float>(value); } }
        public Transform Elbow { get { return this[nameof(Elbow)].As<Transform>(); } set { this["Elbow"] = value; } }
    }
    public class RigUnit_TwoBoneIKSimpleVectors : RigUnit_HighlevelBase
    {
        public RigUnit_TwoBoneIKSimpleVectors(nint addr) : base(addr) { }
        public Vector Root { get { return this[nameof(Root)].As<Vector>(); } set { this["Root"] = value; } }
        public Vector PoleVector { get { return this[nameof(PoleVector)].As<Vector>(); } set { this["PoleVector"] = value; } }
        public Vector Effector { get { return this[nameof(Effector)].As<Vector>(); } set { this["Effector"] = value; } }
        public bool bEnableStretch { get { return this[nameof(bEnableStretch)].Flag; } set { this[nameof(bEnableStretch)].Flag = value; } }
        public float StretchStartRatio { get { return this[nameof(StretchStartRatio)].GetValue<float>(); } set { this[nameof(StretchStartRatio)].SetValue<float>(value); } }
        public float StretchMaximumRatio { get { return this[nameof(StretchMaximumRatio)].GetValue<float>(); } set { this[nameof(StretchMaximumRatio)].SetValue<float>(value); } }
        public float BoneALength { get { return this[nameof(BoneALength)].GetValue<float>(); } set { this[nameof(BoneALength)].SetValue<float>(value); } }
        public float BoneBLength { get { return this[nameof(BoneBLength)].GetValue<float>(); } set { this[nameof(BoneBLength)].SetValue<float>(value); } }
        public Vector Elbow { get { return this[nameof(Elbow)].As<Vector>(); } set { this["Elbow"] = value; } }
    }
    public class RigUnit_TwoBoneIKSimplePerItem : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_TwoBoneIKSimplePerItem(nint addr) : base(addr) { }
        public RigElementKey ItemA { get { return this[nameof(ItemA)].As<RigElementKey>(); } set { this["ItemA"] = value; } }
        public RigElementKey ItemB { get { return this[nameof(ItemB)].As<RigElementKey>(); } set { this["ItemB"] = value; } }
        public RigElementKey EffectorItem { get { return this[nameof(EffectorItem)].As<RigElementKey>(); } set { this["EffectorItem"] = value; } }
        public Transform Effector { get { return this[nameof(Effector)].As<Transform>(); } set { this["Effector"] = value; } }
        public Vector PrimaryAxis { get { return this[nameof(PrimaryAxis)].As<Vector>(); } set { this["PrimaryAxis"] = value; } }
        public Vector SecondaryAxis { get { return this[nameof(SecondaryAxis)].As<Vector>(); } set { this["SecondaryAxis"] = value; } }
        public float SecondaryAxisWeight { get { return this[nameof(SecondaryAxisWeight)].GetValue<float>(); } set { this[nameof(SecondaryAxisWeight)].SetValue<float>(value); } }
        public Vector PoleVector { get { return this[nameof(PoleVector)].As<Vector>(); } set { this["PoleVector"] = value; } }
        public EControlRigVectorKind PoleVectorKind { get { return (EControlRigVectorKind)this[nameof(PoleVectorKind)].GetValue<int>(); } set { this[nameof(PoleVectorKind)].SetValue<int>((int)value); } }
        public RigElementKey PoleVectorSpace { get { return this[nameof(PoleVectorSpace)].As<RigElementKey>(); } set { this["PoleVectorSpace"] = value; } }
        public bool bEnableStretch { get { return this[nameof(bEnableStretch)].Flag; } set { this[nameof(bEnableStretch)].Flag = value; } }
        public float StretchStartRatio { get { return this[nameof(StretchStartRatio)].GetValue<float>(); } set { this[nameof(StretchStartRatio)].SetValue<float>(value); } }
        public float StretchMaximumRatio { get { return this[nameof(StretchMaximumRatio)].GetValue<float>(); } set { this[nameof(StretchMaximumRatio)].SetValue<float>(value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public float ItemALength { get { return this[nameof(ItemALength)].GetValue<float>(); } set { this[nameof(ItemALength)].SetValue<float>(value); } }
        public float ItemBLength { get { return this[nameof(ItemBLength)].GetValue<float>(); } set { this[nameof(ItemBLength)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_TwoBoneIKSimple_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_TwoBoneIKSimple_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public CachedRigElement CachedItemAIndex { get { return this[nameof(CachedItemAIndex)].As<CachedRigElement>(); } set { this["CachedItemAIndex"] = value; } }
        public CachedRigElement CachedItemBIndex { get { return this[nameof(CachedItemBIndex)].As<CachedRigElement>(); } set { this["CachedItemBIndex"] = value; } }
        public CachedRigElement CachedEffectorItemIndex { get { return this[nameof(CachedEffectorItemIndex)].As<CachedRigElement>(); } set { this["CachedEffectorItemIndex"] = value; } }
        public CachedRigElement CachedPoleVectorSpaceIndex { get { return this[nameof(CachedPoleVectorSpaceIndex)].As<CachedRigElement>(); } set { this["CachedPoleVectorSpaceIndex"] = value; } }
    }
    public class RigUnit_TwoBoneIKSimple_DebugSettings : Object
    {
        public RigUnit_TwoBoneIKSimple_DebugSettings(nint addr) : base(addr) { }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public Transform WorldOffset { get { return this[nameof(WorldOffset)].As<Transform>(); } set { this["WorldOffset"] = value; } }
    }
    public class RigUnit_TwoBoneIKSimple : RigUnit_HighlevelBaseMutable
    {
        public RigUnit_TwoBoneIKSimple(nint addr) : base(addr) { }
        public Object BoneA { get { return this[nameof(BoneA)]; } set { this[nameof(BoneA)] = value; } }
        public Object BoneB { get { return this[nameof(BoneB)]; } set { this[nameof(BoneB)] = value; } }
        public Object EffectorBone { get { return this[nameof(EffectorBone)]; } set { this[nameof(EffectorBone)] = value; } }
        public Transform Effector { get { return this[nameof(Effector)].As<Transform>(); } set { this["Effector"] = value; } }
        public Vector PrimaryAxis { get { return this[nameof(PrimaryAxis)].As<Vector>(); } set { this["PrimaryAxis"] = value; } }
        public Vector SecondaryAxis { get { return this[nameof(SecondaryAxis)].As<Vector>(); } set { this["SecondaryAxis"] = value; } }
        public float SecondaryAxisWeight { get { return this[nameof(SecondaryAxisWeight)].GetValue<float>(); } set { this[nameof(SecondaryAxisWeight)].SetValue<float>(value); } }
        public Vector PoleVector { get { return this[nameof(PoleVector)].As<Vector>(); } set { this["PoleVector"] = value; } }
        public EControlRigVectorKind PoleVectorKind { get { return (EControlRigVectorKind)this[nameof(PoleVectorKind)].GetValue<int>(); } set { this[nameof(PoleVectorKind)].SetValue<int>((int)value); } }
        public Object PoleVectorSpace { get { return this[nameof(PoleVectorSpace)]; } set { this[nameof(PoleVectorSpace)] = value; } }
        public bool bEnableStretch { get { return this[nameof(bEnableStretch)].Flag; } set { this[nameof(bEnableStretch)].Flag = value; } }
        public float StretchStartRatio { get { return this[nameof(StretchStartRatio)].GetValue<float>(); } set { this[nameof(StretchStartRatio)].SetValue<float>(value); } }
        public float StretchMaximumRatio { get { return this[nameof(StretchMaximumRatio)].GetValue<float>(); } set { this[nameof(StretchMaximumRatio)].SetValue<float>(value); } }
        public float Weight { get { return this[nameof(Weight)].GetValue<float>(); } set { this[nameof(Weight)].SetValue<float>(value); } }
        public float BoneALength { get { return this[nameof(BoneALength)].GetValue<float>(); } set { this[nameof(BoneALength)].SetValue<float>(value); } }
        public float BoneBLength { get { return this[nameof(BoneBLength)].GetValue<float>(); } set { this[nameof(BoneBLength)].SetValue<float>(value); } }
        public bool bPropagateToChildren { get { return this[nameof(bPropagateToChildren)].Flag; } set { this[nameof(bPropagateToChildren)].Flag = value; } }
        public RigUnit_TwoBoneIKSimple_DebugSettings DebugSettings { get { return this[nameof(DebugSettings)].As<RigUnit_TwoBoneIKSimple_DebugSettings>(); } set { this["DebugSettings"] = value; } }
        public CachedRigElement CachedBoneAIndex { get { return this[nameof(CachedBoneAIndex)].As<CachedRigElement>(); } set { this["CachedBoneAIndex"] = value; } }
        public CachedRigElement CachedBoneBIndex { get { return this[nameof(CachedBoneBIndex)].As<CachedRigElement>(); } set { this["CachedBoneBIndex"] = value; } }
        public CachedRigElement CachedEffectorBoneIndex { get { return this[nameof(CachedEffectorBoneIndex)].As<CachedRigElement>(); } set { this["CachedEffectorBoneIndex"] = value; } }
        public CachedRigElement CachedPoleVectorSpaceIndex { get { return this[nameof(CachedPoleVectorSpaceIndex)].As<CachedRigElement>(); } set { this["CachedPoleVectorSpaceIndex"] = value; } }
    }
    public class RigUnit_Distance_VectorVector : RigUnit
    {
        public RigUnit_Distance_VectorVector(nint addr) : base(addr) { }
        public Vector Argument0 { get { return this[nameof(Argument0)].As<Vector>(); } set { this["Argument0"] = value; } }
        public Vector Argument1 { get { return this[nameof(Argument1)].As<Vector>(); } set { this["Argument1"] = value; } }
        public float Result { get { return this[nameof(Result)].GetValue<float>(); } set { this[nameof(Result)].SetValue<float>(value); } }
    }
    public class RigUnit_BinaryVectorOp : RigUnit
    {
        public RigUnit_BinaryVectorOp(nint addr) : base(addr) { }
        public Vector Argument0 { get { return this[nameof(Argument0)].As<Vector>(); } set { this["Argument0"] = value; } }
        public Vector Argument1 { get { return this[nameof(Argument1)].As<Vector>(); } set { this["Argument1"] = value; } }
        public Vector Result { get { return this[nameof(Result)].As<Vector>(); } set { this["Result"] = value; } }
    }
    public class RigUnit_Divide_VectorVector : RigUnit_BinaryVectorOp
    {
        public RigUnit_Divide_VectorVector(nint addr) : base(addr) { }
    }
    public class RigUnit_Subtract_VectorVector : RigUnit_BinaryVectorOp
    {
        public RigUnit_Subtract_VectorVector(nint addr) : base(addr) { }
    }
    public class RigUnit_Add_VectorVector : RigUnit_BinaryVectorOp
    {
        public RigUnit_Add_VectorVector(nint addr) : base(addr) { }
    }
    public class RigUnit_Multiply_VectorVector : RigUnit_BinaryVectorOp
    {
        public RigUnit_Multiply_VectorVector(nint addr) : base(addr) { }
    }
    public class RigUnit_VerletIntegrateVector : RigUnit_SimBase
    {
        public RigUnit_VerletIntegrateVector(nint addr) : base(addr) { }
        public Vector Target { get { return this[nameof(Target)].As<Vector>(); } set { this["Target"] = value; } }
        public float Strength { get { return this[nameof(Strength)].GetValue<float>(); } set { this[nameof(Strength)].SetValue<float>(value); } }
        public float Damp { get { return this[nameof(Damp)].GetValue<float>(); } set { this[nameof(Damp)].SetValue<float>(value); } }
        public float Blend { get { return this[nameof(Blend)].GetValue<float>(); } set { this[nameof(Blend)].SetValue<float>(value); } }
        public Vector Position { get { return this[nameof(Position)].As<Vector>(); } set { this["Position"] = value; } }
        public Vector Velocity { get { return this[nameof(Velocity)].As<Vector>(); } set { this["Velocity"] = value; } }
        public Vector Acceleration { get { return this[nameof(Acceleration)].As<Vector>(); } set { this["Acceleration"] = value; } }
        public CRSimPoint Point { get { return this[nameof(Point)].As<CRSimPoint>(); } set { this["Point"] = value; } }
        public bool bInitialized { get { return this[nameof(bInitialized)].Flag; } set { this[nameof(bInitialized)].Flag = value; } }
    }
    public class RigUnit_VisualDebugTransformItemSpace : RigUnit_DebugBase
    {
        public RigUnit_VisualDebugTransformItemSpace(nint addr) : base(addr) { }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
    }
    public class RigUnit_VisualDebugTransform : RigUnit_DebugBase
    {
        public RigUnit_VisualDebugTransform(nint addr) : base(addr) { }
        public Transform Value { get { return this[nameof(Value)].As<Transform>(); } set { this["Value"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public Object BoneSpace { get { return this[nameof(BoneSpace)]; } set { this[nameof(BoneSpace)] = value; } }
    }
    public class RigUnit_VisualDebugQuatItemSpace : RigUnit_DebugBase
    {
        public RigUnit_VisualDebugQuatItemSpace(nint addr) : base(addr) { }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
    }
    public class RigUnit_VisualDebugQuat : RigUnit_DebugBase
    {
        public RigUnit_VisualDebugQuat(nint addr) : base(addr) { }
        public Quat Value { get { return this[nameof(Value)].As<Quat>(); } set { this["Value"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public Object BoneSpace { get { return this[nameof(BoneSpace)]; } set { this[nameof(BoneSpace)] = value; } }
    }
    public class RigUnit_VisualDebugVectorItemSpace : RigUnit_DebugBase
    {
        public RigUnit_VisualDebugVectorItemSpace(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public ERigUnitVisualDebugPointMode Mode { get { return (ERigUnitVisualDebugPointMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public RigElementKey Space { get { return this[nameof(Space)].As<RigElementKey>(); } set { this["Space"] = value; } }
    }
    public class RigUnit_VisualDebugVector : RigUnit_DebugBase
    {
        public RigUnit_VisualDebugVector(nint addr) : base(addr) { }
        public Vector Value { get { return this[nameof(Value)].As<Vector>(); } set { this["Value"] = value; } }
        public bool bEnabled { get { return this[nameof(bEnabled)].Flag; } set { this[nameof(bEnabled)].Flag = value; } }
        public ERigUnitVisualDebugPointMode Mode { get { return (ERigUnitVisualDebugPointMode)this[nameof(Mode)].GetValue<int>(); } set { this[nameof(Mode)].SetValue<int>((int)value); } }
        public LinearColor Color { get { return this[nameof(Color)].As<LinearColor>(); } set { this["Color"] = value; } }
        public float Thickness { get { return this[nameof(Thickness)].GetValue<float>(); } set { this[nameof(Thickness)].SetValue<float>(value); } }
        public float Scale { get { return this[nameof(Scale)].GetValue<float>(); } set { this[nameof(Scale)].SetValue<float>(value); } }
        public Object BoneSpace { get { return this[nameof(BoneSpace)]; } set { this[nameof(BoneSpace)] = value; } }
    }
    public class RigUnit_SphereTraceWorld : RigUnit
    {
        public RigUnit_SphereTraceWorld(nint addr) : base(addr) { }
        public Vector Start { get { return this[nameof(Start)].As<Vector>(); } set { this["Start"] = value; } }
        public Vector End { get { return this[nameof(End)].As<Vector>(); } set { this["End"] = value; } }
        public byte Channel { get { return this[nameof(Channel)].GetValue<byte>(); } set { this[nameof(Channel)].SetValue<byte>(value); } }
        public float Radius { get { return this[nameof(Radius)].GetValue<float>(); } set { this[nameof(Radius)].SetValue<float>(value); } }
        public bool bHit { get { return this[nameof(bHit)].Flag; } set { this[nameof(bHit)].Flag = value; } }
        public Vector HitLocation { get { return this[nameof(HitLocation)].As<Vector>(); } set { this["HitLocation"] = value; } }
        public Vector HitNormal { get { return this[nameof(HitNormal)].As<Vector>(); } set { this["HitNormal"] = value; } }
    }
    public class RigUnit_ToRigSpace_Rotation : RigUnit
    {
        public RigUnit_ToRigSpace_Rotation(nint addr) : base(addr) { }
        public Quat Rotation { get { return this[nameof(Rotation)].As<Quat>(); } set { this["Rotation"] = value; } }
        public Quat Global { get { return this[nameof(Global)].As<Quat>(); } set { this["Global"] = value; } }
    }
    public class RigUnit_ToWorldSpace_Rotation : RigUnit
    {
        public RigUnit_ToWorldSpace_Rotation(nint addr) : base(addr) { }
        public Quat Rotation { get { return this[nameof(Rotation)].As<Quat>(); } set { this["Rotation"] = value; } }
        public Quat World { get { return this[nameof(World)].As<Quat>(); } set { this["World"] = value; } }
    }
    public class RigUnit_ToRigSpace_Location : RigUnit
    {
        public RigUnit_ToRigSpace_Location(nint addr) : base(addr) { }
        public Vector Location { get { return this[nameof(Location)].As<Vector>(); } set { this["Location"] = value; } }
        public Vector Global { get { return this[nameof(Global)].As<Vector>(); } set { this["Global"] = value; } }
    }
    public class RigUnit_ToWorldSpace_Location : RigUnit
    {
        public RigUnit_ToWorldSpace_Location(nint addr) : base(addr) { }
        public Vector Location { get { return this[nameof(Location)].As<Vector>(); } set { this["Location"] = value; } }
        public Vector World { get { return this[nameof(World)].As<Vector>(); } set { this["World"] = value; } }
    }
    public class RigUnit_ToRigSpace_Transform : RigUnit
    {
        public RigUnit_ToRigSpace_Transform(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Transform Global { get { return this[nameof(Global)].As<Transform>(); } set { this["Global"] = value; } }
    }
    public class RigUnit_ToWorldSpace_Transform : RigUnit
    {
        public RigUnit_ToWorldSpace_Transform(nint addr) : base(addr) { }
        public Transform Transform { get { return this[nameof(Transform)].As<Transform>(); } set { this["Transform"] = value; } }
        public Transform World { get { return this[nameof(World)].As<Transform>(); } set { this["World"] = value; } }
    }
    public class StructReference : Object
    {
        public StructReference(nint addr) : base(addr) { }
    }
}
