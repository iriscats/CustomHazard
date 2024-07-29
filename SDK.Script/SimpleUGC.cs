using UnrealSharp;
using Object = UnrealSharp.UEObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.SimpleUGCSDK
{
    public class MakeReplaceableActorComponent : ActorComponent
    {
        public MakeReplaceableActorComponent(nint addr) : base(addr) { }
        public Object CompatibleReplacement { get { return this[nameof(CompatibleReplacement)]; } set { this[nameof(CompatibleReplacement)] = value; } }
    }
    public class ReplacementActorComponent : ActorComponent
    {
        public ReplacementActorComponent(nint addr) : base(addr) { }
        public Array<Object> ActorClassesToReplace { get { return new Array<Object>(this[nameof(ActorClassesToReplace)].Address); } }
    }
    public class UGCBlueprintLibrary : BlueprintFunctionLibrary
    {
        public UGCBlueprintLibrary(nint addr) : base(addr) { }
        public UGCSettings GetUGCSettings(Object WorldContextObject) { return Invoke<UGCSettings>(nameof(GetUGCSettings), WorldContextObject); }
        public UGCRegistry GetUGCRegistry(Object WorldContextObject) { return Invoke<UGCRegistry>(nameof(GetUGCRegistry), WorldContextObject); }
        public UGCLatentActionManager GetUGCLatentActionManager(Object WorldContextObject) { return Invoke<UGCLatentActionManager>(nameof(GetUGCLatentActionManager), WorldContextObject); }
    }
    public class ModioModInfoWrapper : Object
    {
        public ModioModInfoWrapper(nint addr) : base(addr) { }
        public Object ModId { get { return this[nameof(ModId)]; } set { this[nameof(ModId)] = value; } }
        public Object ModName { get { return this[nameof(ModName)]; } set { this[nameof(ModName)] = value; } }
        public Object ModURL { get { return this[nameof(ModURL)]; } set { this[nameof(ModURL)] = value; } }
        public Object ModAuthor { get { return this[nameof(ModAuthor)]; } set { this[nameof(ModAuthor)] = value; } }
        public Object ModVersion { get { return this[nameof(ModVersion)]; } set { this[nameof(ModVersion)] = value; } }
        public Object ModDescription { get { return this[nameof(ModDescription)]; } set { this[nameof(ModDescription)] = value; } }
        public EUGCApprovalStatus Status { get { return (EUGCApprovalStatus)this[nameof(Status)].GetValue<int>(); } set { this[nameof(Status)].SetValue<int>((int)value); } }
        public bool IsModIdInvalid() { return Invoke<bool>(nameof(IsModIdInvalid)); }
    }
    public class ModioTermsWrapper : Object
    {
        public ModioTermsWrapper(nint addr) : base(addr) { }
        public Object AgreeButtonText { get { return this[nameof(AgreeButtonText)]; } set { this[nameof(AgreeButtonText)] = value; } }
        public Object DisagreeButtonText { get { return this[nameof(DisagreeButtonText)]; } set { this[nameof(DisagreeButtonText)] = value; } }
        public Object TermsLink { get { return this[nameof(TermsLink)]; } set { this[nameof(TermsLink)] = value; } }
        public Object TermsText { get { return this[nameof(TermsText)]; } set { this[nameof(TermsText)] = value; } }
        public Object PrivacyLink { get { return this[nameof(PrivacyLink)]; } set { this[nameof(PrivacyLink)] = value; } }
        public Object PrivacyText { get { return this[nameof(PrivacyText)]; } set { this[nameof(PrivacyText)] = value; } }
        public Object TermsOfUseText { get { return this[nameof(TermsOfUseText)]; } set { this[nameof(TermsOfUseText)] = value; } }
        public bool isEmpty() { return Invoke<bool>(nameof(isEmpty)); }
    }
    public class UGCLatentActionManager : Object
    {
        public UGCLatentActionManager(nint addr) : base(addr) { }
        public Object LatestModioTermsAndConditions { get { return this[nameof(LatestModioTermsAndConditions)]; } set { this[nameof(LatestModioTermsAndConditions)] = value; } }
        public Object ModioModMetaDatas { get { return this[nameof(ModioModMetaDatas)]; } set { this[nameof(ModioModMetaDatas)] = value; } }
        public Object ModioModThumbnails { get { return this[nameof(ModioModThumbnails)]; } set { this[nameof(ModioModThumbnails)] = value; } }
        public ModioModInfoWrapper GetCachedModioModMetaData(long ModId) { return Invoke<ModioModInfoWrapper>(nameof(GetCachedModioModMetaData), ModId); }
    }
    public class UGCPackage : Object
    {
        public UGCPackage(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Version { get { return this[nameof(Version)]; } set { this[nameof(Version)] = value; } }
        public Object ModURL { get { return this[nameof(ModURL)]; } set { this[nameof(ModURL)] = value; } }
        public Object Categories { get { return this[nameof(Categories)]; } set { this[nameof(Categories)] = value; } }
        public EUGCApprovalStatus Status { get { return (EUGCApprovalStatus)this[nameof(Status)].GetValue<int>(); } set { this[nameof(Status)].SetValue<int>((int)value); } }
        public EUGCDownloadVersion DownloadVersion { get { return (EUGCDownloadVersion)this[nameof(DownloadVersion)].GetValue<int>(); } set { this[nameof(DownloadVersion)].SetValue<int>((int)value); } }
        public Object ModPath { get { return this[nameof(ModPath)]; } set { this[nameof(ModPath)] = value; } }
        public Object PakFileLocation { get { return this[nameof(PakFileLocation)]; } set { this[nameof(PakFileLocation)] = value; } }
        public Array<Object> PakFileAssets { get { return new Array<Object>(this[nameof(PakFileAssets)].Address); } }
        public Object Author { get { return this[nameof(Author)]; } set { this[nameof(Author)] = value; } }
        public Object AuthorURL { get { return this[nameof(AuthorURL)]; } set { this[nameof(AuthorURL)] = value; } }
        public Object Description { get { return this[nameof(Description)]; } set { this[nameof(Description)] = value; } }
        public bool IsMounted { get { return this[nameof(IsMounted)].Flag; } set { this[nameof(IsMounted)].Flag = value; } }
        public bool MountingToBeApplied { get { return this[nameof(MountingToBeApplied)].Flag; } set { this[nameof(MountingToBeApplied)].Flag = value; } }
        public bool DeprecatedLocation { get { return this[nameof(DeprecatedLocation)].Flag; } set { this[nameof(DeprecatedLocation)].Flag = value; } }
        public bool ShowStatusForAudioCosmetic { get { return this[nameof(ShowStatusForAudioCosmetic)].Flag; } set { this[nameof(ShowStatusForAudioCosmetic)].Flag = value; } }
        public Array<long> Dependencies { get { return new Array<long>(this[nameof(Dependencies)].Address); } }
        public bool DependencyRemoved { get { return this[nameof(DependencyRemoved)].Flag; } set { this[nameof(DependencyRemoved)].Flag = value; } }
        public bool PackagedForLatestVersion { get { return this[nameof(PackagedForLatestVersion)].Flag; } set { this[nameof(PackagedForLatestVersion)].Flag = value; } }
        public bool OverridePackedForLatestVersion { get { return this[nameof(OverridePackedForLatestVersion)].Flag; } set { this[nameof(OverridePackedForLatestVersion)].Flag = value; } }
        public DateTime LastUpdated { get { return this[nameof(LastUpdated)].As<DateTime>(); } set { this["LastUpdated"] = value; } }
        public Object GetIdAsString() { return Invoke<Object>(nameof(GetIdAsString)); }
        public long GetIdAsInt() { return Invoke<long>(nameof(GetIdAsInt)); }
    }
    public class UGCRegistry : Object
    {
        public UGCRegistry(nint addr) : base(addr) { }
        public Object OnPackageMounted { get { return this[nameof(OnPackageMounted)]; } set { this[nameof(OnPackageMounted)] = value; } }
        public Array<UGCPackage> UGCPackages { get { return new Array<UGCPackage>(this[nameof(UGCPackages)].Address); } }
        public Object RegisteredOverrides { get { return this[nameof(RegisteredOverrides)]; } set { this[nameof(RegisteredOverrides)] = value; } }
        public bool PackageChange { get { return this[nameof(PackageChange)].Flag; } set { this[nameof(PackageChange)].Flag = value; } }
        public Object OnBlueprintsSpawned { get { return this[nameof(OnBlueprintsSpawned)]; } set { this[nameof(OnBlueprintsSpawned)] = value; } }
        public Array<UGCPackage> UGCPackagesInstalledDuringJoin { get { return new Array<UGCPackage>(this[nameof(UGCPackagesInstalledDuringJoin)].Address); } }
        public Array<UGCPackage> UGCPackagesUnmountedDuringJoin { get { return new Array<UGCPackage>(this[nameof(UGCPackagesUnmountedDuringJoin)].Address); } }
        public void UnmountUGCPackages(Array<Object> ExcludingModIds) { Invoke(nameof(UnmountUGCPackages), ExcludingModIds); }
        public bool UnmountUGCPackage(UGCPackage Package, bool RemoveFromUserSettings, bool RemoveFromDisk) { return Invoke<bool>(nameof(UnmountUGCPackage), Package, RemoveFromUserSettings, RemoveFromDisk); }
        public void UnmountSandboxUGCPackages() { Invoke(nameof(UnmountSandboxUGCPackages)); }
        public void UnmountAllNonVerifiedUGCPackages() { Invoke(nameof(UnmountAllNonVerifiedUGCPackages)); }
        public void UGCPackageMounted__DelegateSignature(bool Sandbox) { Invoke(nameof(UGCPackageMounted__DelegateSignature), Sandbox); }
        public void UGCBlueprintsSpawned__DelegateSignature(int Count) { Invoke(nameof(UGCBlueprintsSpawned__DelegateSignature), Count); }
        public UGCPackage TryGetPackageFromId(Object ModId) { return Invoke<UGCPackage>(nameof(TryGetPackageFromId), ModId); }
        public void ResetUGCPackagesManipulatedDuringJoin() { Invoke(nameof(ResetUGCPackagesManipulatedDuringJoin)); }
        public void RegisterAssetFromPackage(UGCPackage Package) { Invoke(nameof(RegisterAssetFromPackage), Package); }
        public int NumberOfModsInstalled(EUGCApprovalStatus ApprovalStatus) { return Invoke<int>(nameof(NumberOfModsInstalled), ApprovalStatus); }
        public bool MountUGCPackage(UGCPackage Package, bool FromJoining) { return Invoke<bool>(nameof(MountUGCPackage), Package, FromJoining); }
        public bool IsModToBeEnabled(long ModId) { return Invoke<bool>(nameof(IsModToBeEnabled), ModId); }
        public bool IsModInstalledImprecise(Object ModName, bool IncludeDeprecatedLocation) { return Invoke<bool>(nameof(IsModInstalledImprecise), ModName, IncludeDeprecatedLocation); }
        public bool IsModInstalledByIdOrName(Object ModIdOrName, bool IncludeDeprecatedLocation) { return Invoke<bool>(nameof(IsModInstalledByIdOrName), ModIdOrName, IncludeDeprecatedLocation); }
        public bool IsModInstalled(Object ModId) { return Invoke<bool>(nameof(IsModInstalled), ModId); }
        public bool IsModEnabled(Object ModId) { return Invoke<bool>(nameof(IsModEnabled), ModId); }
        public Array<UGCPackage> GetPackagesWhichDependsOnPackage(UGCPackage Package) { return Invoke<Array<UGCPackage>>(nameof(GetPackagesWhichDependsOnPackage), Package); }
        public Array<UGCPackage> GetPackagesSorted(EPackageSortField ByField, bool Ascending) { return Invoke<Array<UGCPackage>>(nameof(GetPackagesSorted), ByField, Ascending); }
        public bool GetMapsInPackage(UGCPackage Package, Array<Object> Maps) { return Invoke<bool>(nameof(GetMapsInPackage), Package, Maps); }
        public bool GetAllClassesInPackage(UGCPackage Package, Array<Object> Classes) { return Invoke<bool>(nameof(GetAllClassesInPackage), Package, Classes); }
        public bool AreModsInstalled(EUGCApprovalStatus ApprovalStatus) { return Invoke<bool>(nameof(AreModsInstalled), ApprovalStatus); }
        public bool AreDeprecatedModsInstalled() { return Invoke<bool>(nameof(AreDeprecatedModsInstalled)); }
    }
    public class UGCSettings : Object
    {
        public UGCSettings(nint addr) : base(addr) { }
        public Array<Object> slot1 { get { return new Array<Object>(this[nameof(slot1)].Address); } }
        public int slot1Icon { get { return this[nameof(slot1Icon)].GetValue<int>(); } set { this[nameof(slot1Icon)].SetValue<int>(value); } }
        public Array<Object> slot2 { get { return new Array<Object>(this[nameof(slot2)].Address); } }
        public int slot2Icon { get { return this[nameof(slot2Icon)].GetValue<int>(); } set { this[nameof(slot2Icon)].SetValue<int>(value); } }
        public Array<Object> slot3 { get { return new Array<Object>(this[nameof(slot3)].Address); } }
        public int slot3Icon { get { return this[nameof(slot3Icon)].GetValue<int>(); } set { this[nameof(slot3Icon)].SetValue<int>(value); } }
        public Array<Object> slot4 { get { return new Array<Object>(this[nameof(slot4)].Address); } }
        public int slot4Icon { get { return this[nameof(slot4Icon)].GetValue<int>(); } set { this[nameof(slot4Icon)].SetValue<int>(value); } }
        public int SelectedSlot { get { return this[nameof(SelectedSlot)].GetValue<int>(); } set { this[nameof(SelectedSlot)].SetValue<int>(value); } }
        public Object OnSettingsUpdated { get { return this[nameof(OnSettingsUpdated)]; } set { this[nameof(OnSettingsUpdated)] = value; } }
        public bool WriteToPlainText(Object Filename, Object TextContent, Object OutError, bool Append) { return Invoke<bool>(nameof(WriteToPlainText), Filename, TextContent, OutError, Append); }
        public void UGCSettingsUpdated__DelegateSignature() { Invoke(nameof(UGCSettingsUpdated__DelegateSignature)); }
        public void SetIconIndexOfSlot(int SlotNumber, int iconIndex) { Invoke(nameof(SetIconIndexOfSlot), SlotNumber, iconIndex); }
        public void SaveToSlot(int SlotNumber) { Invoke(nameof(SaveToSlot), SlotNumber); }
        public void SaveToSelectedSlot() { Invoke(nameof(SaveToSelectedSlot)); }
        public void ResetSlot() { Invoke(nameof(ResetSlot)); }
        public bool ReadFromPlainText(Object Filename, Object OutTextContent) { return Invoke<bool>(nameof(ReadFromPlainText), Filename, OutTextContent); }
        public bool LoadSlot(int SlotNumber) { return Invoke<bool>(nameof(LoadSlot), SlotNumber); }
        public Array<Object> GetModNamesOfSlot(int SlotNumber, int outNumberOfUnknown) { return Invoke<Array<Object>>(nameof(GetModNamesOfSlot), SlotNumber, outNumberOfUnknown); }
        public Array<Object> GetModIdsOfSlot(int SlotNumber) { return Invoke<Array<Object>>(nameof(GetModIdsOfSlot), SlotNumber); }
        public int GetIconIndexOfSlot(int SlotNumber) { return Invoke<int>(nameof(GetIconIndexOfSlot), SlotNumber); }
        public bool DoesSlotContainMods(int SlotNumber) { return Invoke<bool>(nameof(DoesSlotContainMods), SlotNumber); }
        public void ClearSlot(int SlotNumber) { Invoke(nameof(ClearSlot), SlotNumber); }
        public void CleanupSlots() { Invoke(nameof(CleanupSlots)); }
    }
    public class UGCSubsystem : EngineSubsystem
    {
        public UGCSubsystem(nint addr) : base(addr) { }
        public bool forceNoMods { get { return this[nameof(forceNoMods)].Flag; } set { this[nameof(forceNoMods)].Flag = value; } }
        public bool noInternetAccess { get { return this[nameof(noInternetAccess)].Flag; } set { this[nameof(noInternetAccess)].Flag = value; } }
        public bool noModioUser { get { return this[nameof(noModioUser)].Flag; } set { this[nameof(noModioUser)].Flag = value; } }
        public bool IsJoining { get { return this[nameof(IsJoining)].Flag; } set { this[nameof(IsJoining)].Flag = value; } }
        public UGCRegistry UGCRegistry { get { return this[nameof(UGCRegistry)].As<UGCRegistry>(); } set { this["UGCRegistry"] = value; } }
        public UGCSettings UGCSettings { get { return this[nameof(UGCSettings)].As<UGCSettings>(); } set { this["UGCSettings"] = value; } }
        public UGCLatentActionManager UGCLatentActionManager { get { return this[nameof(UGCLatentActionManager)].As<UGCLatentActionManager>(); } set { this["UGCLatentActionManager"] = value; } }
        public bool ModioTermsAndConditionsAccepted { get { return this[nameof(ModioTermsAndConditionsAccepted)].Flag; } set { this[nameof(ModioTermsAndConditionsAccepted)].Flag = value; } }
        public Object OnModioUserAuthenticated { get { return this[nameof(OnModioUserAuthenticated)]; } set { this[nameof(OnModioUserAuthenticated)] = value; } }
        public Object OnErrorInstalling { get { return this[nameof(OnErrorInstalling)]; } set { this[nameof(OnErrorInstalling)] = value; } }
        public Object ModsFailedInstall { get { return this[nameof(ModsFailedInstall)]; } set { this[nameof(ModsFailedInstall)] = value; } }
        public Object OnModDownloadExtractProgress { get { return this[nameof(OnModDownloadExtractProgress)]; } set { this[nameof(OnModDownloadExtractProgress)] = value; } }
        public Object OnModDownloadExtractProgressFinished { get { return this[nameof(OnModDownloadExtractProgressFinished)]; } set { this[nameof(OnModDownloadExtractProgressFinished)] = value; } }
        public Object OnModUninstallProgressFinished { get { return this[nameof(OnModUninstallProgressFinished)]; } set { this[nameof(OnModUninstallProgressFinished)] = value; } }
        public Object OnModManagementStateChanged { get { return this[nameof(OnModManagementStateChanged)]; } set { this[nameof(OnModManagementStateChanged)] = value; } }
        public bool IsModioModManagementEnabled { get { return this[nameof(IsModioModManagementEnabled)].Flag; } set { this[nameof(IsModioModManagementEnabled)].Flag = value; } }
        public Object OnLocalUserModsInstalled { get { return this[nameof(OnLocalUserModsInstalled)]; } set { this[nameof(OnLocalUserModsInstalled)] = value; } }
        public bool IsLocalUserModsInstalled { get { return this[nameof(IsLocalUserModsInstalled)].Flag; } set { this[nameof(IsLocalUserModsInstalled)].Flag = value; } }
        public Object OnEscapeMenuOpened { get { return this[nameof(OnEscapeMenuOpened)]; } set { this[nameof(OnEscapeMenuOpened)] = value; } }
        public Object OnModioRequestHandled { get { return this[nameof(OnModioRequestHandled)]; } set { this[nameof(OnModioRequestHandled)] = value; } }
        public Array<Object> CrashingDisabledMods { get { return new Array<Object>(this[nameof(CrashingDisabledMods)].Address); } }
        public Array<UGCPackage> ModsPendingUninstall { get { return new Array<UGCPackage>(this[nameof(ModsPendingUninstall)].Address); } }
        public Array<UGCPackage> ModsPendingUpdate { get { return new Array<UGCPackage>(this[nameof(ModsPendingUpdate)].Address); } }
        public Array<EModioRequestType> ModioRequests { get { return new Array<EModioRequestType>(this[nameof(ModioRequests)].Address); } }
        public Array<long> ModioSubscribeRequestsIds { get { return new Array<long>(this[nameof(ModioSubscribeRequestsIds)].Address); } }
        public Array<long> ModioSubscribeDependecyRequestsIds { get { return new Array<long>(this[nameof(ModioSubscribeDependecyRequestsIds)].Address); } }
        public Array<long> ModioAddDependecyRequestsIds { get { return new Array<long>(this[nameof(ModioAddDependecyRequestsIds)].Address); } }
        public void UGRequiredModsFetched__DelegateSignature(Array<Object> ModsToEnable, Array<Object> ModsToInstall) { Invoke(nameof(UGRequiredModsFetched__DelegateSignature), ModsToEnable, ModsToInstall); }
        public void UGModProgressDone__DelegateSignature(Object ModName, Object ModId) { Invoke(nameof(UGModProgressDone__DelegateSignature), ModName, ModId); }
        public void UGInstallError__DelegateSignature(Object ModName, EUGCPackageError ErrorType) { Invoke(nameof(UGInstallError__DelegateSignature), ModName, ErrorType); }
        public void UGCRequestHandled__DelegateSignature(EModioRequestType requestType) { Invoke(nameof(UGCRequestHandled__DelegateSignature), requestType); }
        public void UGCModProgress__DelegateSignature(Object Name, Array<Object> ModsPendingDownload, bool Downloading, int Progress, int Total) { Invoke(nameof(UGCModProgress__DelegateSignature), Name, ModsPendingDownload, Downloading, Progress, Total); }
        public void UGCModManagementStateChanged__DelegateSignature(bool Enabled) { Invoke(nameof(UGCModManagementStateChanged__DelegateSignature), Enabled); }
        public void UGCLocalUserModsInstalled__DelegateSignature() { Invoke(nameof(UGCLocalUserModsInstalled__DelegateSignature)); }
        public void UGCHiddenMods__DelegateSignature() { Invoke(nameof(UGCHiddenMods__DelegateSignature)); }
        public void UGCEscapeMenuOpened__DelegateSignature() { Invoke(nameof(UGCEscapeMenuOpened__DelegateSignature)); }
        public void UGCAuthenticatedModioUser__DelegateSignature(bool Authenticated) { Invoke(nameof(UGCAuthenticatedModioUser__DelegateSignature), Authenticated); }
        public void SetPackagesAsRecentlyInstalled(Array<UGCPackage> RecentMods) { Invoke(nameof(SetPackagesAsRecentlyInstalled), RecentMods); }
        public void SetModsAsRecentlyInstalled(Array<Object> RecentMods) { Invoke(nameof(SetModsAsRecentlyInstalled), RecentMods); }
        public void SetModidngSettingsMenuEnabled(bool bEnabled) { Invoke(nameof(SetModidngSettingsMenuEnabled), bEnabled); }
        public void SetCheckGameVersion(bool ShouldCheck) { Invoke(nameof(SetCheckGameVersion), ShouldCheck); }
        public void RemoveRequestOfType(EModioRequestType requestType) { Invoke(nameof(RemoveRequestOfType), requestType); }
        public void MarkRecentlyInstalledModsSuccesful() { Invoke(nameof(MarkRecentlyInstalledModsSuccesful)); }
        public void K2_RequestTermsOfUse(Object WorldContext, LatentActionInfo LatentInfo) { Invoke(nameof(K2_RequestTermsOfUse), WorldContext, LatentInfo); }
        public bool K2_RequestSubscribe(Object ModId) { return Invoke<bool>(nameof(K2_RequestSubscribe), ModId); }
        public void K2_RequestModThumbnailById(Object WorldContext, LatentActionInfo LatentInfo, Object ModId) { Invoke(nameof(K2_RequestModThumbnailById), WorldContext, LatentInfo, ModId); }
        public void K2_RequestModThumbnail(Object WorldContext, LatentActionInfo LatentInfo, UGCPackage Package) { Invoke(nameof(K2_RequestModThumbnail), WorldContext, LatentInfo, Package); }
        public void K2_RequestModMetaData(Object WorldContext, LatentActionInfo LatentInfo, Object ModioStringID, long ModId) { Invoke(nameof(K2_RequestModMetaData), WorldContext, LatentInfo, ModioStringID, ModId); }
        public void K2_RequestModDependencyList(Object WorldContext, LatentActionInfo LatentInfo, Object ModId, Object outParentId, Array<Object> outModIds) { Invoke(nameof(K2_RequestModDependencyList), WorldContext, LatentInfo, ModId, outParentId, outModIds); }
        public void K2_RequestFetchModUpdates() { Invoke(nameof(K2_RequestFetchModUpdates)); }
        public void K2_RequestAuthentication() { Invoke(nameof(K2_RequestAuthentication)); }
        public bool IsModPendingUninstall(UGCPackage InMod) { return Invoke<bool>(nameof(IsModPendingUninstall), InMod); }
        public bool HasOutstadingRequestOfType(EModioRequestType requestType) { return Invoke<bool>(nameof(HasOutstadingRequestOfType), requestType); }
        public Array<EModioRequestType> GetQueuedModioRequests() { return Invoke<Array<EModioRequestType>>(nameof(GetQueuedModioRequests)); }
        public Array<Object> GetNamesOfModsPendingUpdate() { return Invoke<Array<Object>>(nameof(GetNamesOfModsPendingUpdate)); }
        public Array<Object> GetNamesOfModsPendingUninstall() { return Invoke<Array<Object>>(nameof(GetNamesOfModsPendingUninstall)); }
        public Array<Object> GetNamesOfModsPendingInstall() { return Invoke<Array<Object>>(nameof(GetNamesOfModsPendingInstall)); }
        public bool GetModdingSettingsMenuEnabled() { return Invoke<bool>(nameof(GetModdingSettingsMenuEnabled)); }
        public bool GetCheckGameVersion() { return Invoke<bool>(nameof(GetCheckGameVersion)); }
        public bool FetchModsForSession(Array<Object> HostMods, Object OnModsFetched) { return Invoke<bool>(nameof(FetchModsForSession), HostMods, OnModsFetched); }
        public void EnableModioModManagement() { Invoke(nameof(EnableModioModManagement)); }
        public void DisableModioModManagement() { Invoke(nameof(DisableModioModManagement)); }
        public void ApplyPendingMods(bool FromJoining) { Invoke(nameof(ApplyPendingMods), FromJoining); }
    }
    public enum EUGCApprovalStatus : int
    {
        Fully = 0,
        Progression = 1,
        Sandbox = 2,
        All = 255,
        EUGCApprovalStatus_MAX = 256,
    }
    public enum EPackageSortField : int
    {
        None = 0,
        Name = 1,
        Status = 2,
        Author = 3,
        Mounted = 4,
        EPackageSortField_MAX = 5,
    }
    public enum EModioRequestType : int
    {
        Authentication = 0,
        K2_Authentication = 1,
        TermsOfUse = 2,
        FetchModUpdates = 3,
        ModMetaData = 4,
        Thumbnail = 5,
        Subscribe = 6,
        ModDependencySubscribe = 7,
        ModDependencyList = 8,
        ModDependencyAdd = 9,
        EModioRequestType_MAX = 10,
    }
    public enum EUGCPackageError : int
    {
        Exists = 0,
        Invalid = 1,
        Other = 2,
        EUGCPackageError_MAX = 3,
    }
    public enum EUGCDownloadVersion : int
    {
        Optional = 0,
        Required = 1,
        All = 255,
        EUGCDownloadVersion_MAX = 256,
    }
    public enum EUGCBlueprintSpawning : int
    {
        Spacerig = 0,
        Cave = 1,
        Other = 2,
        EUGCBlueprintSpawning_MAX = 3,
    }
    public class Mods : Object
    {
        public Mods(nint addr) : base(addr) { }
        public Array<ModDefinition> Mods_value { get { return new Array<ModDefinition>(this[nameof(Mods)].Address); } }
    }
    public class ModDefinition : Object
    {
        public ModDefinition(nint addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public int Category { get { return this[nameof(Category)].GetValue<int>(); } set { this[nameof(Category)].SetValue<int>(value); } }
        public Object Version { get { return this[nameof(Version)]; } set { this[nameof(Version)] = value; } }
    }
}
