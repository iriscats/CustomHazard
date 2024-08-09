using UnrealDotNet;
using UnrealDotNet.Types;

using Object = UnrealDotNet.Types.UObject;
using Guid = SDK.Script.CoreUObjectSDK.Guid;
using Enum = SDK.Script.CoreUObjectSDK.Enum;
using DateTime = SDK.Script.CoreUObjectSDK.DateTime;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
using SDK.Script.UMGSDK;
namespace SDK.Script.ModioSDK
{
    public class ModioCommonTypesLibrary : BlueprintFunctionLibrary
    {
        public ModioCommonTypesLibrary(nint addr) : base(addr) { }
        public ModioInitializeOptions SetSessionIdentifier(ModioInitializeOptions options, Object SessionIdentifier) { return Invoke<ModioInitializeOptions>(nameof(SetSessionIdentifier), options, SessionIdentifier); }
        public ModioInitializeOptions SetPortal(ModioInitializeOptions options, EModioPortal PortalToUse) { return Invoke<ModioInitializeOptions>(nameof(SetPortal), options, PortalToUse); }
        public bool NotEqualTo(ModioModID A, ModioModID B) { return Invoke<bool>(nameof(NotEqualTo), A, B); }
        public ModioInitializeOptions MakeInitializeOptions(long GameId, Object ApiKey, EModioEnvironment GameEnvironment, EModioPortal PortalInUse) { return Invoke<ModioInitializeOptions>(nameof(MakeInitializeOptions), GameId, ApiKey, GameEnvironment, PortalInUse); }
        public ModioGameID MakeGameId(long GameId) { return Invoke<ModioGameID>(nameof(MakeGameId), GameId); }
        public ModioAuthenticationParams MakeAuthParams(Object AuthToken, Object EmailAddress, bool bHasAcceptedTOS) { return Invoke<ModioAuthenticationParams>(nameof(MakeAuthParams), AuthToken, EmailAddress, bHasAcceptedTOS); }
        public ModioApiKey MakeApiKey(Object ApiKey) { return Invoke<ModioApiKey>(nameof(MakeApiKey), ApiKey); }
        public long GetRawValueFromModID(ModioModID In) { return Invoke<long>(nameof(GetRawValueFromModID), In); }
        public bool EqualTo(ModioModID A, ModioModID B) { return Invoke<bool>(nameof(EqualTo), A, B); }
        public Object Conv_UserIDToString(ModioUserID UserId) { return Invoke<Object>(nameof(Conv_UserIDToString), UserId); }
        public ModioEmailAuthCode Conv_StringToEmailAuthCode(Object AuthCode) { return Invoke<ModioEmailAuthCode>(nameof(Conv_StringToEmailAuthCode), AuthCode); }
        public ModioEmailAddress Conv_StringToEmailAddress(Object Email) { return Invoke<ModioEmailAddress>(nameof(Conv_StringToEmailAddress), Email); }
        public Object Conv_ModIDToString(ModioModID ModId) { return Invoke<Object>(nameof(Conv_ModIDToString), ModId); }
        public Object Conv_GameIDToString(ModioGameID GameId) { return Invoke<Object>(nameof(Conv_GameIDToString), GameId); }
        public Object Conv_FileMetadataIDToString(ModioFileMetadataID FileMetadataID) { return Invoke<Object>(nameof(Conv_FileMetadataIDToString), FileMetadataID); }
        public Object Conv_EmailAuthCodeToString(ModioEmailAuthCode EmailAuthCode) { return Invoke<Object>(nameof(Conv_EmailAuthCodeToString), EmailAuthCode); }
        public Object Conv_EmailAddressToString(ModioEmailAddress EmailAddress) { return Invoke<Object>(nameof(Conv_EmailAddressToString), EmailAddress); }
        public Object Conv_ApiKeyToString(ModioApiKey ApiKey) { return Invoke<Object>(nameof(Conv_ApiKeyToString), ApiKey); }
    }
    public class ModioCreateModLibrary : BlueprintFunctionLibrary
    {
        public ModioCreateModLibrary(nint addr) : base(addr) { }
        public void SetVersionString(ModioCreateModFileParams In, Object Version) { Invoke(nameof(SetVersionString), In, Version); }
        public void SetTags(ModioCreateModParams In, UArray<Object> Tags) { Invoke(nameof(SetTags), In, Tags); }
        public void SetModfilePlatforms(ModioCreateModFileParams In, UArray<EModioModfilePlatform> Platforms) { Invoke(nameof(SetModfilePlatforms), In, Platforms); }
        public void SetModFileMetadataBlob(ModioCreateModFileParams In, Object MetadataBlob) { Invoke(nameof(SetModFileMetadataBlob), In, MetadataBlob); }
        public void SetMetadataBlob(ModioCreateModParams In, Object MetadataBlob) { Invoke(nameof(SetMetadataBlob), In, MetadataBlob); }
        public void SetMarkAsActiveRelease(ModioCreateModFileParams In, bool bMarkAsActiveRelease) { Invoke(nameof(SetMarkAsActiveRelease), In, bMarkAsActiveRelease); }
        public void SetInitialVisibility(ModioCreateModParams In, bool InitialVisibility) { Invoke(nameof(SetInitialVisibility), In, InitialVisibility); }
        public void SetHomepageURL(ModioCreateModParams In, Object HomepageURL) { Invoke(nameof(SetHomepageURL), In, HomepageURL); }
        public void SetDescription(ModioCreateModParams In, Object Description) { Invoke(nameof(SetDescription), In, Description); }
        public void SetChangelogString(ModioCreateModFileParams In, Object Changelog) { Invoke(nameof(SetChangelogString), In, Changelog); }
    }
    public class ModioEditModLibrary : BlueprintFunctionLibrary
    {
        public ModioEditModLibrary(nint addr) : base(addr) { }
        public void SetVisibility(ModioEditModParams In, bool Visibility) { Invoke(nameof(SetVisibility), In, Visibility); }
        public void SetSummary(ModioEditModParams In, Object Summary) { Invoke(nameof(SetSummary), In, Summary); }
        public void SetNamePath(ModioEditModParams In, Object NamePath) { Invoke(nameof(SetNamePath), In, NamePath); }
        public void SetName(ModioEditModParams In, Object Name) { Invoke(nameof(SetName), In, Name); }
        public void SetMetadataBlob(ModioEditModParams In, Object MetadataBlob) { Invoke(nameof(SetMetadataBlob), In, MetadataBlob); }
        public void SetMaturityFlags(ModioEditModParams In, EModioMaturityFlags MaturityFlags) { Invoke(nameof(SetMaturityFlags), In, MaturityFlags); }
        public void SetHomepageURL(ModioEditModParams In, Object HomepageURL) { Invoke(nameof(SetHomepageURL), In, HomepageURL); }
        public void SetDescription(ModioEditModParams In, Object Description) { Invoke(nameof(SetDescription), In, Description); }
    }
    public class ModioErrorCodeLibrary : BlueprintFunctionLibrary
    {
        public ModioErrorCodeLibrary(nint addr) : base(addr) { }
        public bool IsError(ModioErrorCode Error) { return Invoke<bool>(nameof(IsError), Error); }
        public int GetValue(ModioErrorCode Error) { return Invoke<int>(nameof(GetValue), Error); }
        public Object GetMessage(ModioErrorCode Error) { return Invoke<Object>(nameof(GetMessage), Error); }
    }
    public class ModioErrorConditionLibrary : BlueprintFunctionLibrary
    {
        public ModioErrorConditionLibrary(nint addr) : base(addr) { }
        public bool ErrorCodeMatches(ModioErrorCode ErrorCode, EModioErrorCondition Condition) { return Invoke<bool>(nameof(ErrorCodeMatches), ErrorCode, Condition); }
    }
    public class ModioExampleLibrary : BlueprintFunctionLibrary
    {
        public ModioExampleLibrary(nint addr) : base(addr) { }
        public void ListUserSubscriptionAsync(ModioFilterParams FilterParams, Object Callback) { Invoke(nameof(ListUserSubscriptionAsync), FilterParams, Callback); }
        public EModioLogoSize GetLogoThumbnailSize() { return Invoke<EModioLogoSize>(nameof(GetLogoThumbnailSize)); }
        public EModioLogoSize GetLogoFullSize() { return Invoke<EModioLogoSize>(nameof(GetLogoFullSize)); }
        public EModioAvatarSize GetAvatarThumbnailSize() { return Invoke<EModioAvatarSize>(nameof(GetAvatarThumbnailSize)); }
    }
    public class ModioFilterParamsLibrary : BlueprintFunctionLibrary
    {
        public ModioFilterParamsLibrary(nint addr) : base(addr) { }
        public ModioFilterParams WithTags(ModioFilterParams Filter, UArray<Object> NewTags) { return Invoke<ModioFilterParams>(nameof(WithTags), Filter, NewTags); }
        public ModioFilterParams WithTag(ModioFilterParams Filter, Object Tag) { return Invoke<ModioFilterParams>(nameof(WithTag), Filter, Tag); }
        public ModioFilterParams WithoutTags(ModioFilterParams Filter, UArray<Object> NewTags) { return Invoke<ModioFilterParams>(nameof(WithoutTags), Filter, NewTags); }
        public ModioFilterParams WithoutTag(ModioFilterParams Filter, Object Tag) { return Invoke<ModioFilterParams>(nameof(WithoutTag), Filter, Tag); }
        public ModioFilterParams SortBy(ModioFilterParams Filter, EModioSortFieldType ByField, EModioSortDirection ByDirection) { return Invoke<ModioFilterParams>(nameof(SortBy), Filter, ByField, ByDirection); }
        public ModioFilterParams PagedResults(ModioFilterParams Filter, long PageNumber, long PageSize) { return Invoke<ModioFilterParams>(nameof(PagedResults), Filter, PageNumber, PageSize); }
        public ModioFilterParams NameContainsStrings(ModioFilterParams Filter, UArray<Object> SearchStrings) { return Invoke<ModioFilterParams>(nameof(NameContainsStrings), Filter, SearchStrings); }
        public ModioFilterParams NameContains(ModioFilterParams Filter, Object SearchString) { return Invoke<ModioFilterParams>(nameof(NameContains), Filter, SearchString); }
        public ModioFilterParams MetadataLike(ModioFilterParams Filter, Object SearchString) { return Invoke<ModioFilterParams>(nameof(MetadataLike), Filter, SearchString); }
        public ModioFilterParams MatchingIDs(ModioFilterParams Filter, UArray<ModioModID> IDs) { return Invoke<ModioFilterParams>(nameof(MatchingIDs), Filter, IDs); }
        public ModioFilterParams MarkedLiveBefore(ModioFilterParams Filter, DateTime LiveBefore) { return Invoke<ModioFilterParams>(nameof(MarkedLiveBefore), Filter, LiveBefore); }
        public ModioFilterParams MarkedLiveAfter(ModioFilterParams Filter, DateTime LiveAfter) { return Invoke<ModioFilterParams>(nameof(MarkedLiveAfter), Filter, LiveAfter); }
        public ModioFilterParams IndexedResults(ModioFilterParams Filter, long StartIndex, long ResultCount) { return Invoke<ModioFilterParams>(nameof(IndexedResults), Filter, StartIndex, ResultCount); }
        public ModioFilterParams ExcludingIDs(ModioFilterParams Filter, UArray<ModioModID> IDs) { return Invoke<ModioFilterParams>(nameof(ExcludingIDs), Filter, IDs); }
    }
    public class ModioImageLibrary : BlueprintFunctionLibrary
    {
        public ModioImageLibrary(nint addr) : base(addr) { }
        public void LoadAsync(ModioImageWrapper Image, Object OnImageLoaded) { Invoke(nameof(LoadAsync), Image, OnImageLoaded); }
        public Texture2DDynamic GetTexture(ModioImageWrapper Image) { return Invoke<Texture2DDynamic>(nameof(GetTexture), Image); }
        public EModioImageState GetState(ModioImageWrapper Image) { return Invoke<EModioImageState>(nameof(GetState), Image); }
        public Vector2D GetLogoSize(Texture Logo, EModioLogoSize LogoSize) { return Invoke<Vector2D>(nameof(GetLogoSize), Logo, LogoSize); }
        public Vector2D GetGallerySize(Texture GalleryImage, EModioGallerySize GallerySize) { return Invoke<Vector2D>(nameof(GetGallerySize), GalleryImage, GallerySize); }
        public Vector2D GetAvatarSize(Texture avatar, EModioAvatarSize AvatarSize) { return Invoke<Vector2D>(nameof(GetAvatarSize), avatar, AvatarSize); }
    }
    public class ModioModCollectionLibrary : BlueprintFunctionLibrary
    {
        public ModioModCollectionLibrary(nint addr) : base(addr) { }
        public Object GetPath(ModioModCollectionEntry entry) { return Invoke<Object>(nameof(GetPath), entry); }
        public EModioModState GetModState(ModioModCollectionEntry entry) { return Invoke<EModioModState>(nameof(GetModState), entry); }
        public ModioModInfo GetModProfile(ModioModCollectionEntry entry) { return Invoke<ModioModInfo>(nameof(GetModProfile), entry); }
        public ModioModID GetID(ModioModCollectionEntry entry) { return Invoke<ModioModID>(nameof(GetID), entry); }
    }
    public class ModioModDependenciesLibrary : BlueprintFunctionLibrary
    {
        public ModioModDependenciesLibrary(nint addr) : base(addr) { }
        public ModioPagedResult GetPagedResult(ModioModDependencyList ModTags) { return Invoke<ModioPagedResult>(nameof(GetPagedResult), ModTags); }
        public UArray<ModioModDependency> GetDependencies(ModioModDependencyList ModTags) { return Invoke<UArray<ModioModDependency>>(nameof(GetDependencies), ModTags); }
    }
    public class ModioModInfoListLibrary : BlueprintFunctionLibrary
    {
        public ModioModInfoListLibrary(nint addr) : base(addr) { }
        public ModioPagedResult GetPagedResult(ModioModInfoList ModInfoList) { return Invoke<ModioPagedResult>(nameof(GetPagedResult), ModInfoList); }
        public UArray<ModioModInfo> GetMods(ModioModInfoList ModInfoList) { return Invoke<UArray<ModioModInfo>>(nameof(GetMods), ModInfoList); }
    }
    public class ModioModTagOptionsLibrary : BlueprintFunctionLibrary
    {
        public ModioModTagOptionsLibrary(nint addr) : base(addr) { }
        public UArray<ModioModTagInfo> GetTags(ModioModTagOptions ModTags) { return Invoke<UArray<ModioModTagInfo>>(nameof(GetTags), ModTags); }
        public ModioPagedResult GetPagedResult(ModioModTagOptions ModTags) { return Invoke<ModioPagedResult>(nameof(GetPagedResult), ModTags); }
    }
    public class ModioOptionalLibrary : BlueprintFunctionLibrary
    {
        public ModioOptionalLibrary(nint addr) : base(addr) { }
        public bool IsSet_ModioOptionalUser(ModioOptionalUser OptionalUser) { return Invoke<bool>(nameof(IsSet_ModioOptionalUser), OptionalUser); }
        public bool IsSet_ModioOptionalTerms(ModioOptionalTerms OptionalTerms) { return Invoke<bool>(nameof(IsSet_ModioOptionalTerms), OptionalTerms); }
        public bool IsSet_ModioOptionalModTagOptions(ModioOptionalModTagOptions OptionalModTagOptions) { return Invoke<bool>(nameof(IsSet_ModioOptionalModTagOptions), OptionalModTagOptions); }
        public bool IsSet_ModioOptionalModProgressInfo(ModioOptionalModProgressInfo OptionalModProgressInfo) { return Invoke<bool>(nameof(IsSet_ModioOptionalModProgressInfo), OptionalModProgressInfo); }
        public bool IsSet_ModioOptionalModInfoList(ModioOptionalModInfoList OptionalModInfoList) { return Invoke<bool>(nameof(IsSet_ModioOptionalModInfoList), OptionalModInfoList); }
        public bool IsSet_ModioOptionalModInfo(ModioOptionalModInfo OptionalModInfo) { return Invoke<bool>(nameof(IsSet_ModioOptionalModInfo), OptionalModInfo); }
        public bool IsSet_ModioOptionalModID(ModioOptionalModID OptionalID) { return Invoke<bool>(nameof(IsSet_ModioOptionalModID), OptionalID); }
        public bool IsSet_ModioOptionalModDependencyList(ModioOptionalModDependencyList OptionalDependencyList) { return Invoke<bool>(nameof(IsSet_ModioOptionalModDependencyList), OptionalDependencyList); }
        public bool IsSet_ModioOptionalImage(ModioOptionalImage OptionalImage) { return Invoke<bool>(nameof(IsSet_ModioOptionalImage), OptionalImage); }
        public bool GetValue_ModioOptionalUser(ModioOptionalUser OptionalUser, ModioUser User) { return Invoke<bool>(nameof(GetValue_ModioOptionalUser), OptionalUser, User); }
        public bool GetValue_ModioOptionalTerms(ModioOptionalTerms OptionalTerms, ModioTerms Terms) { return Invoke<bool>(nameof(GetValue_ModioOptionalTerms), OptionalTerms, Terms); }
        public bool GetValue_ModioOptionalModTagOptions(ModioOptionalModTagOptions OptionalModTagOptions, ModioModTagOptions ModTagOptions) { return Invoke<bool>(nameof(GetValue_ModioOptionalModTagOptions), OptionalModTagOptions, ModTagOptions); }
        public bool GetValue_ModioOptionalModProgressInfo(ModioOptionalModProgressInfo OptionalModProgressInfo, ModioModProgressInfo ModProgressInfo) { return Invoke<bool>(nameof(GetValue_ModioOptionalModProgressInfo), OptionalModProgressInfo, ModProgressInfo); }
        public bool GetValue_ModioOptionalModInfoList(ModioOptionalModInfoList OptionalModInfoList, ModioModInfoList ModInfoList) { return Invoke<bool>(nameof(GetValue_ModioOptionalModInfoList), OptionalModInfoList, ModInfoList); }
        public bool GetValue_ModioOptionalModInfo(ModioOptionalModInfo OptionalModInfo, ModioModInfo ModInfo) { return Invoke<bool>(nameof(GetValue_ModioOptionalModInfo), OptionalModInfo, ModInfo); }
        public bool GetValue_ModioOptionalModID(ModioOptionalModID OptionalID, ModioModID ID) { return Invoke<bool>(nameof(GetValue_ModioOptionalModID), OptionalID, ID); }
        public bool GetValue_ModioOptionalModDependencyList(ModioOptionalModDependencyList OptionalDependencyList, ModioModDependencyList DependencyList) { return Invoke<bool>(nameof(GetValue_ModioOptionalModDependencyList), OptionalDependencyList, DependencyList); }
        public bool GetValue_ModioOptionalImage(ModioOptionalImage OptionalImage, ModioImageWrapper Image) { return Invoke<bool>(nameof(GetValue_ModioOptionalImage), OptionalImage, Image); }
    }
    public class ModioPopupBase : UserWidget
    {
        public ModioPopupBase(nint addr) : base(addr) { }
    }
    public class ModioPopupContainer : UserWidget
    {
        public ModioPopupContainer(nint addr) : base(addr) { }
        public UArray<ModioPopupBase> PopupStack { get { return new UArray<ModioPopupBase>(this[nameof(PopupStack)].Address); } }
        public UArray<ModioPopupBase> PopupCache { get { return new UArray<ModioPopupBase>(this[nameof(PopupCache)].Address); } }
        public ModioPopupBase PushPopup(Object PopupClass) { return Invoke<ModioPopupBase>(nameof(PushPopup), PopupClass); }
        public ModioPopupBase PopPopup(Object PopupClass) { return Invoke<ModioPopupBase>(nameof(PopPopup), PopupClass); }
    }
    public class ModioReportLibrary : BlueprintFunctionLibrary
    {
        public ModioReportLibrary(nint addr) : base(addr) { }
        public ModioReportParams MakeReportForUser(ModioUserID User, EModioReportType Type, Object ReportDescription, Object ReporterName, Object ReporterContact) { return Invoke<ModioReportParams>(nameof(MakeReportForUser), User, Type, ReportDescription, ReporterName, ReporterContact); }
        public ModioReportParams MakeReportForMod(ModioModID Mod, EModioReportType Type, Object ReportDescription, Object ReporterName, Object ReporterContact) { return Invoke<ModioReportParams>(nameof(MakeReportForMod), Mod, Type, ReportDescription, ReporterName, ReporterContact); }
        public ModioReportParams MakeReportForGame(ModioGameID Game, EModioReportType Type, Object ReportDescription, Object ReporterName, Object ReporterContact) { return Invoke<ModioReportParams>(nameof(MakeReportForGame), Game, Type, ReportDescription, ReporterName, ReporterContact); }
    }
    public class ModioSDKLibrary : BlueprintFunctionLibrary
    {
        public ModioSDKLibrary(nint addr) : base(addr) { }
        public float Pct_Int64Int64(long Dividend, long Divisor) { return Invoke<float>(nameof(Pct_Int64Int64), Dividend, Divisor); }
        public bool IsValidSecurityCodeFormat(Object String) { return Invoke<bool>(nameof(IsValidSecurityCodeFormat), String); }
        public bool IsValidEmailAddressFormat(Object String) { return Invoke<bool>(nameof(IsValidEmailAddressFormat), String); }
        public ModioInitializeOptions GetProjectInitializeOptionsForSessionId(Object sessionId) { return Invoke<ModioInitializeOptions>(nameof(GetProjectInitializeOptionsForSessionId), sessionId); }
        public ModioInitializeOptions GetProjectInitializeOptions() { return Invoke<ModioInitializeOptions>(nameof(GetProjectInitializeOptions)); }
        public ModioGameID GetProjectGameId() { return Invoke<ModioGameID>(nameof(GetProjectGameId)); }
        public EModioEnvironment GetProjectEnvironment() { return Invoke<EModioEnvironment>(nameof(GetProjectEnvironment)); }
        public ModioApiKey GetProjectApiKey() { return Invoke<ModioApiKey>(nameof(GetProjectApiKey)); }
        public Object Filesize_ToString(long Filesize, int MaxDecimals, byte Unit) { return Invoke<Object>(nameof(Filesize_ToString), Filesize, MaxDecimals, Unit); }
        public Object Conv_Int64ToText(long Value, bool bAlwaysSign, bool bUseGrouping, int MinimumIntegralDigits, int MaximumIntegralDigits) { return Invoke<Object>(nameof(Conv_Int64ToText), Value, bAlwaysSign, bUseGrouping, MinimumIntegralDigits, MaximumIntegralDigits); }
        public Object Conv_Int64ToString(long inInt) { return Invoke<Object>(nameof(Conv_Int64ToString), inInt); }
    }
    public class ModioSettings : Object
    {
        public ModioSettings(nint addr) : base(addr) { }
        public long GameId { get { return this[nameof(GameId)].GetValue<long>(); } set { this[nameof(GameId)].SetValue<long>(value); } }
        public Object ApiKey { get { return this[nameof(ApiKey)]; } set { this[nameof(ApiKey)] = value; } }
        public EModioEnvironment Environment { get { return (EModioEnvironment)this[nameof(Environment)].GetValue<int>(); } set { this[nameof(Environment)].SetValue<int>((int)value); } }
        public EModioLogLevel LogLevel { get { return (EModioLogLevel)this[nameof(LogLevel)].GetValue<int>(); } set { this[nameof(LogLevel)].SetValue<int>((int)value); } }
        public EModioPortal DefaultPortal { get { return (EModioPortal)this[nameof(DefaultPortal)].GetValue<int>(); } set { this[nameof(DefaultPortal)].SetValue<int>((int)value); } }
    }
    public class ModioSubsystem : EngineSubsystem
    {
        public ModioSubsystem(nint addr) : base(addr) { }
        public void SetLogLevel(EModioLogLevel UnrealLogLevel) { Invoke(nameof(SetLogLevel), UnrealLogLevel); }
        public void RunPendingHandlers() { Invoke(nameof(RunPendingHandlers)); }
        public Object QueryUserSubscriptions() { return Invoke<Object>(nameof(QueryUserSubscriptions)); }
        public Object QueryUserInstallations(bool bIncludeOutdatedMods) { return Invoke<Object>(nameof(QueryUserInstallations), bIncludeOutdatedMods); }
        public Object QuerySystemInstallations() { return Invoke<Object>(nameof(QuerySystemInstallations)); }
        public ModioErrorCode PrioritizeTransferForMod(ModioModID ModToPrioritize) { return Invoke<ModioErrorCode>(nameof(PrioritizeTransferForMod), ModToPrioritize); }
        public void K2_VerifyUserAuthenticationAsync(Object Callback) { Invoke(nameof(K2_VerifyUserAuthenticationAsync), Callback); }
        public void K2_UnsubscribeFromModAsync(ModioModID ModToUnsubscribeFrom, Object OnUnsubscribeComplete) { Invoke(nameof(K2_UnsubscribeFromModAsync), ModToUnsubscribeFrom, OnUnsubscribeComplete); }
        public void K2_SubscribeToModAsync(ModioModID ModToSubscribeTo, Object OnSubscribeComplete) { Invoke(nameof(K2_SubscribeToModAsync), ModToSubscribeTo, OnSubscribeComplete); }
        public void K2_SubmitNewModFileForMod(ModioModID Mod, ModioCreateModFileParams Params) { Invoke(nameof(K2_SubmitNewModFileForMod), Mod, Params); }
        public void K2_SubmitNewModAsync(ModioModCreationHandle Handle, ModioCreateModParams Params, Object Callback) { Invoke(nameof(K2_SubmitNewModAsync), Handle, Params, Callback); }
        public void K2_SubmitModRatingAsync(ModioModID Mod, EModioRating Rating, Object Callback) { Invoke(nameof(K2_SubmitModRatingAsync), Mod, Rating, Callback); }
        public void K2_SubmitModChangesAsync(ModioModID Mod, ModioEditModParams Params, Object Callback) { Invoke(nameof(K2_SubmitModChangesAsync), Mod, Params, Callback); }
        public void K2_ShutdownAsync(Object OnShutdownComplete) { Invoke(nameof(K2_ShutdownAsync), OnShutdownComplete); }
        public void K2_RequestEmailAuthCodeAsync(ModioEmailAddress EmailAddress, Object Callback) { Invoke(nameof(K2_RequestEmailAuthCodeAsync), EmailAddress, Callback); }
        public void K2_ReportContentAsync(ModioReportParams Report, Object Callback) { Invoke(nameof(K2_ReportContentAsync), Report, Callback); }
        public ModioOptionalUser K2_QueryUserProfile() { return Invoke<ModioOptionalUser>(nameof(K2_QueryUserProfile)); }
        public ModioOptionalModProgressInfo K2_QueryCurrentModUpdate() { return Invoke<ModioOptionalModProgressInfo>(nameof(K2_QueryCurrentModUpdate)); }
        public void K2_ListAllModsAsync(ModioFilterParams Filter, Object Callback) { Invoke(nameof(K2_ListAllModsAsync), Filter, Callback); }
        public void K2_InitializeAsync(ModioInitializeOptions InitializeOptions, Object OnInitComplete) { Invoke(nameof(K2_InitializeAsync), InitializeOptions, OnInitComplete); }
        public void K2_GetUserMediaAvatarAsync(EModioAvatarSize AvatarSize, Object Callback) { Invoke(nameof(K2_GetUserMediaAvatarAsync), AvatarSize, Callback); }
        public void K2_GetTermsOfUseAsync(EModioAuthenticationProvider Provider, EModioLanguage Locale, Object Callback) { Invoke(nameof(K2_GetTermsOfUseAsync), Provider, Locale, Callback); }
        public void K2_GetModTagOptionsAsync(Object Callback) { Invoke(nameof(K2_GetModTagOptionsAsync), Callback); }
        public void K2_GetModMediaLogoAsync(ModioModID ModId, EModioLogoSize LogoSize, Object Callback) { Invoke(nameof(K2_GetModMediaLogoAsync), ModId, LogoSize, Callback); }
        public void K2_GetModMediaGalleryImageAsync(ModioModID ModId, EModioGallerySize GallerySize, int Index, Object Callback) { Invoke(nameof(K2_GetModMediaGalleryImageAsync), ModId, GallerySize, Index, Callback); }
        public void K2_GetModMediaAvatarAsync(ModioModID ModId, EModioAvatarSize AvatarSize, Object Callback) { Invoke(nameof(K2_GetModMediaAvatarAsync), ModId, AvatarSize, Callback); }
        public void K2_GetModInfoAsync(ModioModID ModId, Object Callback) { Invoke(nameof(K2_GetModInfoAsync), ModId, Callback); }
        public void K2_GetModDependenciesAsync(ModioModID ModId, Object Callback) { Invoke(nameof(K2_GetModDependenciesAsync), ModId, Callback); }
        public ModioModCreationHandle K2_GetModCreationHandle() { return Invoke<ModioModCreationHandle>(nameof(K2_GetModCreationHandle)); }
        public void K2_ForceUninstallModAsync(ModioModID ModToRemove, Object Callback) { Invoke(nameof(K2_ForceUninstallModAsync), ModToRemove, Callback); }
        public void K2_FetchExternalUpdatesAsync(Object OnFetchDone) { Invoke(nameof(K2_FetchExternalUpdatesAsync), OnFetchDone); }
        public ModioErrorCode K2_EnableModManagement(Object Callback) { return Invoke<ModioErrorCode>(nameof(K2_EnableModManagement), Callback); }
        public void K2_ClearUserDataAsync(Object Callback) { Invoke(nameof(K2_ClearUserDataAsync), Callback); }
        public void K2_AuthenticateUserExternalAsync(ModioAuthenticationParams User, EModioAuthenticationProvider Provider, Object Callback) { Invoke(nameof(K2_AuthenticateUserExternalAsync), User, Provider, Callback); }
        public void K2_AuthenticateUserEmailAsync(ModioEmailAuthCode AuthenticationCode, Object Callback) { Invoke(nameof(K2_AuthenticateUserEmailAsync), AuthenticationCode, Callback); }
        public void K2_ArchiveModAsync(ModioModID Mod, Object Callback) { Invoke(nameof(K2_ArchiveModAsync), Mod, Callback); }
        public bool IsModManagementBusy() { return Invoke<bool>(nameof(IsModManagementBusy)); }
        public UArray<ModioValidationError> GetLastValidationError() { return Invoke<UArray<ModioValidationError>>(nameof(GetLastValidationError)); }
        public void DisableModManagement() { Invoke(nameof(DisableModManagement)); }
    }
    public class ModioTestSettings : Object
    {
        public ModioTestSettings(nint addr) : base(addr) { }
    }
    public class ModioUnsigned64Library : BlueprintFunctionLibrary
    {
        public ModioUnsigned64Library(nint addr) : base(addr) { }
        public ModioUnsigned64 Subtract(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<ModioUnsigned64>(nameof(Subtract), LHS, RHS); }
        public float Percentage_Unsigned64(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<float>(nameof(Percentage_Unsigned64), LHS, RHS); }
        public bool NotEqualTo(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<bool>(nameof(NotEqualTo), LHS, RHS); }
        public ModioUnsigned64 MakeFromComponents(int High, int Low) { return Invoke<ModioUnsigned64>(nameof(MakeFromComponents), High, Low); }
        public bool LessThan(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<bool>(nameof(LessThan), LHS, RHS); }
        public bool GreaterThan(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<bool>(nameof(GreaterThan), LHS, RHS); }
        public bool EqualTo(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<bool>(nameof(EqualTo), LHS, RHS); }
        public float DivideToFloat(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<float>(nameof(DivideToFloat), LHS, RHS); }
        public float DivideFloat(ModioUnsigned64 LHS, float RHS) { return Invoke<float>(nameof(DivideFloat), LHS, RHS); }
        public ModioUnsigned64 Divide(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<ModioUnsigned64>(nameof(Divide), LHS, RHS); }
        public float Conv_FModioUnsigned64ToFloat(ModioUnsigned64 In) { return Invoke<float>(nameof(Conv_FModioUnsigned64ToFloat), In); }
        public void BreakToComponents(ModioUnsigned64 In, int High, int Low) { Invoke(nameof(BreakToComponents), In, High, Low); }
        public ModioUnsigned64 Add(ModioUnsigned64 LHS, ModioUnsigned64 RHS) { return Invoke<ModioUnsigned64>(nameof(Add), LHS, RHS); }
    }
    public class ModioYoutubeURLList : Object
    {
        public ModioYoutubeURLList(nint addr) : base(addr) { }
    }
    public class ModioSketchfabURLList : Object
    {
        public ModioSketchfabURLList(nint addr) : base(addr) { }
    }
    public class ModioModInfoList : Object
    {
        public ModioModInfoList(nint addr) : base(addr) { }
        public ModioPagedResult PagedResult { get { return this[nameof(PagedResult)].As<ModioPagedResult>(); } set { this["PagedResult"] = value; } }
        public UArray<ModioModInfo> InternalList { get { return new UArray<ModioModInfo>(this[nameof(InternalList)].Address); } }
    }
    public class ModioModInfo : Object
    {
        public ModioModInfo(nint addr) : base(addr) { }
        public ModioModID ModId { get { return this[nameof(ModId)].As<ModioModID>(); } set { this["ModId"] = value; } }
        public Object ProfileName { get { return this[nameof(ProfileName)]; } set { this[nameof(ProfileName)] = value; } }
        public Object ProfileSummary { get { return this[nameof(ProfileSummary)]; } set { this[nameof(ProfileSummary)] = value; } }
        public Object ProfileDescription { get { return this[nameof(ProfileDescription)]; } set { this[nameof(ProfileDescription)] = value; } }
        public Object ProfileDescriptionPlaintext { get { return this[nameof(ProfileDescriptionPlaintext)]; } set { this[nameof(ProfileDescriptionPlaintext)] = value; } }
        public Object ProfileUrl { get { return this[nameof(ProfileUrl)]; } set { this[nameof(ProfileUrl)] = value; } }
        public ModioUser ProfileSubmittedBy { get { return this[nameof(ProfileSubmittedBy)].As<ModioUser>(); } set { this["ProfileSubmittedBy"] = value; } }
        public DateTime ProfileDateAdded { get { return this[nameof(ProfileDateAdded)].As<DateTime>(); } set { this["ProfileDateAdded"] = value; } }
        public DateTime ProfileDateUpdated { get { return this[nameof(ProfileDateUpdated)].As<DateTime>(); } set { this["ProfileDateUpdated"] = value; } }
        public DateTime ProfileDateLive { get { return this[nameof(ProfileDateLive)].As<DateTime>(); } set { this["ProfileDateLive"] = value; } }
        public EModioMaturityFlags ProfileMaturityOption { get { return (EModioMaturityFlags)this[nameof(ProfileMaturityOption)].GetValue<int>(); } set { this[nameof(ProfileMaturityOption)].SetValue<int>((int)value); } }
        public bool bVisible { get { return this[nameof(bVisible)].Flag; } set { this[nameof(bVisible)].Flag = value; } }
        public Object MetadataBlob { get { return this[nameof(MetadataBlob)]; } set { this[nameof(MetadataBlob)] = value; } }
        public ModioFileMetadata FileInfo { get { return this[nameof(FileInfo)].As<ModioFileMetadata>(); } set { this["FileInfo"] = value; } }
        public UArray<ModioMetadata> MetadataKvp { get { return new UArray<ModioMetadata>(this[nameof(MetadataKvp)].Address); } }
        public UArray<ModioModTag> Tags { get { return new UArray<ModioModTag>(this[nameof(Tags)].Address); } }
        public int NumGalleryImages { get { return this[nameof(NumGalleryImages)].GetValue<int>(); } set { this[nameof(NumGalleryImages)].SetValue<int>(value); } }
        public ModioYoutubeURLList YoutubeURLs { get { return this[nameof(YoutubeURLs)].As<ModioYoutubeURLList>(); } set { this["YoutubeURLs"] = value; } }
        public ModioSketchfabURLList SketchfabURLs { get { return this[nameof(SketchfabURLs)].As<ModioSketchfabURLList>(); } set { this["SketchfabURLs"] = value; } }
        public ModioModStats Stats { get { return this[nameof(Stats)].As<ModioModStats>(); } set { this["Stats"] = value; } }
    }
    public class ModioModStats : Object
    {
        public ModioModStats(nint addr) : base(addr) { }
        public long PopularityRankPosition { get { return this[nameof(PopularityRankPosition)].GetValue<long>(); } set { this[nameof(PopularityRankPosition)].SetValue<long>(value); } }
        public long PopularityRankTotalMods { get { return this[nameof(PopularityRankTotalMods)].GetValue<long>(); } set { this[nameof(PopularityRankTotalMods)].SetValue<long>(value); } }
        public long DownloadsTotal { get { return this[nameof(DownloadsTotal)].GetValue<long>(); } set { this[nameof(DownloadsTotal)].SetValue<long>(value); } }
        public long SubscribersTotal { get { return this[nameof(SubscribersTotal)].GetValue<long>(); } set { this[nameof(SubscribersTotal)].SetValue<long>(value); } }
        public long RatingTotal { get { return this[nameof(RatingTotal)].GetValue<long>(); } set { this[nameof(RatingTotal)].SetValue<long>(value); } }
        public long RatingPositive { get { return this[nameof(RatingPositive)].GetValue<long>(); } set { this[nameof(RatingPositive)].SetValue<long>(value); } }
        public long RatingNegative { get { return this[nameof(RatingNegative)].GetValue<long>(); } set { this[nameof(RatingNegative)].SetValue<long>(value); } }
        public long RatingPercentagePositive { get { return this[nameof(RatingPercentagePositive)].GetValue<long>(); } set { this[nameof(RatingPercentagePositive)].SetValue<long>(value); } }
        public float RatingWeightedAggregate { get { return this[nameof(RatingWeightedAggregate)].GetValue<float>(); } set { this[nameof(RatingWeightedAggregate)].SetValue<float>(value); } }
        public Object RatingDisplayText { get { return this[nameof(RatingDisplayText)]; } set { this[nameof(RatingDisplayText)] = value; } }
    }
    public class ModioModTag : Object
    {
        public ModioModTag(nint addr) : base(addr) { }
        public Object Tag { get { return this[nameof(Tag)]; } set { this[nameof(Tag)] = value; } }
    }
    public class ModioMetadata : Object
    {
        public ModioMetadata(nint addr) : base(addr) { }
        public Object Key { get { return this[nameof(Key)]; } set { this[nameof(Key)] = value; } }
        public Object Value { get { return this[nameof(Value)]; } set { this[nameof(Value)] = value; } }
    }
    public class ModioFileMetadata : Object
    {
        public ModioFileMetadata(nint addr) : base(addr) { }
        public ModioFileMetadataID MetadataId { get { return this[nameof(MetadataId)].As<ModioFileMetadataID>(); } set { this["MetadataId"] = value; } }
        public ModioModID ModId { get { return this[nameof(ModId)].As<ModioModID>(); } set { this["ModId"] = value; } }
        public DateTime DateAdded { get { return this[nameof(DateAdded)].As<DateTime>(); } set { this["DateAdded"] = value; } }
        public EModioVirusScanStatus CurrentVirusScanStatus { get { return (EModioVirusScanStatus)this[nameof(CurrentVirusScanStatus)].GetValue<int>(); } set { this[nameof(CurrentVirusScanStatus)].SetValue<int>((int)value); } }
        public EModioVirusStatus CurrentVirusStatus { get { return (EModioVirusStatus)this[nameof(CurrentVirusStatus)].GetValue<int>(); } set { this[nameof(CurrentVirusStatus)].SetValue<int>((int)value); } }
        public long Filesize { get { return this[nameof(Filesize)].GetValue<long>(); } set { this[nameof(Filesize)].SetValue<long>(value); } }
        public Object Filename { get { return this[nameof(Filename)]; } set { this[nameof(Filename)] = value; } }
        public Object Version { get { return this[nameof(Version)]; } set { this[nameof(Version)] = value; } }
        public Object Changelog { get { return this[nameof(Changelog)]; } set { this[nameof(Changelog)] = value; } }
        public Object MetadataBlob { get { return this[nameof(MetadataBlob)]; } set { this[nameof(MetadataBlob)] = value; } }
    }
    public enum EModioVirusStatus : int
    {
        NoThreat = 0,
        Malicious = 1,
        EModioVirusStatus_MAX = 2,
    }
    public enum EModioVirusScanStatus : int
    {
        NotScanned = 0,
        ScanComplete = 1,
        InProgress = 2,
        TooLargeToScan = 3,
        FileNotFound = 4,
        ErrorScanning = 5,
        EModioVirusScanStatus_MAX = 6,
    }
    public class ModioModID : Object
    {
        public ModioModID(nint addr) : base(addr) { }
    }
    public class ModioFileMetadataID : Object
    {
        public ModioFileMetadataID(nint addr) : base(addr) { }
    }
    public enum EModioMaturityFlags : int
    {
        None = 0,
        Alcohol = 1,
        Drugs = 2,
        Violence = 4,
        Explicit = 8,
        EModioMaturityFlags_MAX = 9,
    }
    public class ModioUser : Object
    {
        public ModioUser(nint addr) : base(addr) { }
        public ModioUserID UserId { get { return this[nameof(UserId)].As<ModioUserID>(); } set { this["UserId"] = value; } }
        public Object Username { get { return this[nameof(Username)]; } set { this[nameof(Username)] = value; } }
        public DateTime DateOnline { get { return this[nameof(DateOnline)].As<DateTime>(); } set { this["DateOnline"] = value; } }
        public Object ProfileUrl { get { return this[nameof(ProfileUrl)]; } set { this[nameof(ProfileUrl)] = value; } }
    }
    public class ModioUserID : Object
    {
        public ModioUserID(nint addr) : base(addr) { }
    }
    public class ModioPagedResult : Object
    {
        public ModioPagedResult(nint addr) : base(addr) { }
        public int PageIndex { get { return this[nameof(PageIndex)].GetValue<int>(); } set { this[nameof(PageIndex)].SetValue<int>(value); } }
        public int PageSize { get { return this[nameof(PageSize)].GetValue<int>(); } set { this[nameof(PageSize)].SetValue<int>(value); } }
        public int PageCount { get { return this[nameof(PageCount)].GetValue<int>(); } set { this[nameof(PageCount)].SetValue<int>(value); } }
        public int TotalResultCount { get { return this[nameof(TotalResultCount)].GetValue<int>(); } set { this[nameof(TotalResultCount)].SetValue<int>(value); } }
        public int ResultCount { get { return this[nameof(ResultCount)].GetValue<int>(); } set { this[nameof(ResultCount)].SetValue<int>(value); } }
    }
    public class ModioModTagOptions : Object
    {
        public ModioModTagOptions(nint addr) : base(addr) { }
        public ModioPagedResult PagedResult { get { return this[nameof(PagedResult)].As<ModioPagedResult>(); } set { this["PagedResult"] = value; } }
        public UArray<ModioModTagInfo> InternalList { get { return new UArray<ModioModTagInfo>(this[nameof(InternalList)].Address); } }
    }
    public class ModioModTagInfo : Object
    {
        public ModioModTagInfo(nint addr) : base(addr) { }
        public Object TagGroupName { get { return this[nameof(TagGroupName)]; } set { this[nameof(TagGroupName)] = value; } }
        public UArray<Object> TagGroupValues { get { return new UArray<Object>(this[nameof(TagGroupValues)].Address); } }
        public bool bAllowMultipleSelection { get { return this[nameof(bAllowMultipleSelection)].Flag; } set { this[nameof(bAllowMultipleSelection)].Flag = value; } }
    }
    public class ModioErrorCode : Object
    {
        public ModioErrorCode(nint addr) : base(addr) { }
    }
    public class ModioModManagementEvent : Object
    {
        public ModioModManagementEvent(nint addr) : base(addr) { }
        public ModioModID ID { get { return this[nameof(ID)].As<ModioModID>(); } set { this["ID"] = value; } }
        public EModioModManagementEventType Event { get { return (EModioModManagementEventType)this[nameof(Event)].GetValue<int>(); } set { this[nameof(Event)].SetValue<int>((int)value); } }
        public ModioErrorCode Status { get { return this[nameof(Status)].As<ModioErrorCode>(); } set { this["Status"] = value; } }
    }
    public enum EModioModManagementEventType : int
    {
        Installed = 0,
        Uninstalled = 1,
        Updated = 2,
        Uploaded = 3,
        BeginInstall = 4,
        BeginUninstall = 5,
        BeginUpdate = 6,
        BeginUpload = 7,
        EModioModManagementEventType_MAX = 8,
    }
    public class ModioOptionalModInfoList : Object
    {
        public ModioOptionalModInfoList(nint addr) : base(addr) { }
    }
    public class ModioOptionalModInfo : Object
    {
        public ModioOptionalModInfo(nint addr) : base(addr) { }
    }
    public class ModioOptionalImage : Object
    {
        public ModioOptionalImage(nint addr) : base(addr) { }
    }
    public class ModioOptionalModTagOptions : Object
    {
        public ModioOptionalModTagOptions(nint addr) : base(addr) { }
    }
    public class ModioOptionalTerms : Object
    {
        public ModioOptionalTerms(nint addr) : base(addr) { }
    }
    public class ModioOptionalModDependencyList : Object
    {
        public ModioOptionalModDependencyList(nint addr) : base(addr) { }
    }
    public class ModioOptionalModID : Object
    {
        public ModioOptionalModID(nint addr) : base(addr) { }
    }
    public enum EModioAuthenticationProvider : int
    {
        XboxLive = 0,
        Steam = 1,
        GoG = 2,
        Itch = 3,
        Switch = 4,
        Discord = 5,
        EModioAuthenticationProvider_MAX = 6,
    }
    public enum EModioLanguage : int
    {
        English = 0,
        Bulgarian = 1,
        French = 2,
        German = 3,
        Italian = 4,
        Polish = 5,
        Portuguese = 6,
        Hungarian = 7,
        Japanese = 8,
        Korean = 9,
        Russian = 10,
        Spanish = 11,
        Thai = 12,
        ChineseSimplified = 13,
        ChineseTraditional = 14,
        EModioLanguage_MAX = 15,
    }
    public enum EModioLogLevel : int
    {
        Trace = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        EModioLogLevel_MAX = 4,
    }
    public enum EModioGallerySize : int
    {
        Original = 0,
        Thumb320 = 1,
        EModioGallerySize_MAX = 2,
    }
    public enum EModioAvatarSize : int
    {
        Original = 0,
        Thumb50 = 1,
        Thumb100 = 2,
        EModioAvatarSize_MAX = 3,
    }
    public enum EModioLogoSize : int
    {
        Original = 0,
        Thumb320 = 1,
        Thumb640 = 2,
        Thumb1280 = 3,
        EModioLogoSize_MAX = 4,
    }
    public enum EModioModfilePlatform : int
    {
        Windows = 0,
        Mac = 1,
        Linux = 2,
        Android = 3,
        iOS = 4,
        XboxOne = 5,
        XboxSeriesX = 6,
        PS4 = 7,
        PS5 = 8,
        Switch = 9,
        Oculus = 10,
        EModioModfilePlatform_MAX = 11,
    }
    public enum EModioPortal : int
    {
        None = 0,
        Apple = 1,
        EpicGamesStore = 2,
        GOG = 3,
        Google = 4,
        Itchio = 5,
        Nintendo = 6,
        PSN = 7,
        Steam = 8,
        XboxLive = 9,
        EModioPortal_MAX = 10,
    }
    public enum EModioEnvironment : int
    {
        Test = 0,
        Live = 1,
        EModioEnvironment_MAX = 2,
    }
    public enum EModioErrorCondition : int
    {
        NoError = 0,
        NetworkError = 2,
        ConfigurationError = 3,
        InvalidArgsError = 4,
        FilesystemError = 5,
        InternalError = 6,
        EntityNotFoundError = 12,
        UserTermsOfUseError = 13,
        SubmitReportError = 14,
        UserNotAuthenticatedError = 15,
        SDKNotInitialized = 16,
        UserAlreadyAuthenticatedError = 17,
        SystemError = 18,
        EModioErrorCondition_MAX = 19,
    }
    public enum EModioSortDirection : int
    {
        Ascending = 0,
        Descending = 1,
        EModioSortDirection_MAX = 2,
    }
    public enum EModioSortFieldType : int
    {
        ID = 0,
        DownloadsToday = 1,
        SubscriberCount = 2,
        Rating = 3,
        DateMarkedLive = 4,
        DateUpdated = 5,
        DownloadsTotal = 6,
        EModioSortFieldType_MAX = 7,
    }
    public enum EModioImageState : int
    {
        OnDisc = 0,
        LoadingIntoMemory = 1,
        InMemory = 2,
        Corrupted = 3,
        EModioImageState_MAX = 4,
    }
    public enum EModioModState : int
    {
        InstallationPending = 0,
        Installed = 1,
        UpdatePending = 2,
        Downloading = 3,
        Extracting = 4,
        UninstallPending = 5,
        EModioModState_MAX = 6,
    }
    public enum EModioRating : int
    {
        Neutral = 0,
        Positive = 1,
        Negative = 2,
        EModioRating_MAX = 3,
    }
    public enum EModioReportType : int
    {
        Generic = 0,
        DMCA = 1,
        NotWorking = 2,
        RudeContent = 3,
        IllegalContent = 4,
        StolenContent = 5,
        FalseInformation = 6,
        Other = 7,
        EModioReportType_MAX = 8,
    }
    public enum EFileSizeUnit : int
    {
        Largest = 0,
        B = 1,
        KB = 1024,
        MB = 1048576,
        GB = 1073741824,
        EFileSizeUnit_MAX = 1073741825,
    }
    public class ModioAuthenticationParams : Object
    {
        public ModioAuthenticationParams(nint addr) : base(addr) { }
        public Object AuthToken { get { return this[nameof(AuthToken)]; } set { this[nameof(AuthToken)] = value; } }
        public Object UserEmail { get { return this[nameof(UserEmail)]; } set { this[nameof(UserEmail)] = value; } }
        public bool bUserHasAcceptedTerms { get { return this[nameof(bUserHasAcceptedTerms)].Flag; } set { this[nameof(bUserHasAcceptedTerms)].Flag = value; } }
    }
    public class ModioEmailAuthCode : Object
    {
        public ModioEmailAuthCode(nint addr) : base(addr) { }
    }
    public class ModioEmailAddress : Object
    {
        public ModioEmailAddress(nint addr) : base(addr) { }
    }
    public class ModioApiKey : Object
    {
        public ModioApiKey(nint addr) : base(addr) { }
        public Object ApiKey { get { return this[nameof(ApiKey)]; } set { this[nameof(ApiKey)] = value; } }
    }
    public class ModioGameID : Object
    {
        public ModioGameID(nint addr) : base(addr) { }
        public long GameId { get { return this[nameof(GameId)].GetValue<long>(); } set { this[nameof(GameId)].SetValue<long>(value); } }
    }
    public class ModioCreateModFileParams : Object
    {
        public ModioCreateModFileParams(nint addr) : base(addr) { }
        public Object PathToModRootDirectory { get { return this[nameof(PathToModRootDirectory)]; } set { this[nameof(PathToModRootDirectory)] = value; } }
    }
    public class ModioCreateModParams : Object
    {
        public ModioCreateModParams(nint addr) : base(addr) { }
        public Object PathToLogoFile { get { return this[nameof(PathToLogoFile)]; } set { this[nameof(PathToLogoFile)] = value; } }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Summary { get { return this[nameof(Summary)]; } set { this[nameof(Summary)] = value; } }
    }
    public class ModioEditModParams : Object
    {
        public ModioEditModParams(nint addr) : base(addr) { }
    }
    public class ModioFilterParams : Object
    {
        public ModioFilterParams(nint addr) : base(addr) { }
    }
    public class ModioImageWrapper : Object
    {
        public ModioImageWrapper(nint addr) : base(addr) { }
        public Object ImagePath { get { return this[nameof(ImagePath)]; } set { this[nameof(ImagePath)] = value; } }
    }
    public class ModioInitializeOptions : Object
    {
        public ModioInitializeOptions(nint addr) : base(addr) { }
        public ModioGameID GameId { get { return this[nameof(GameId)].As<ModioGameID>(); } set { this["GameId"] = value; } }
        public ModioApiKey ApiKey { get { return this[nameof(ApiKey)].As<ModioApiKey>(); } set { this["ApiKey"] = value; } }
        public EModioEnvironment GameEnvironment { get { return (EModioEnvironment)this[nameof(GameEnvironment)].GetValue<int>(); } set { this[nameof(GameEnvironment)].SetValue<int>((int)value); } }
        public EModioPortal PortalInUse { get { return (EModioPortal)this[nameof(PortalInUse)].GetValue<int>(); } set { this[nameof(PortalInUse)].SetValue<int>((int)value); } }
    }
    public class ModioModCollectionEntry : Object
    {
        public ModioModCollectionEntry(nint addr) : base(addr) { }
    }
    public class ModioModCreationHandle : Object
    {
        public ModioModCreationHandle(nint addr) : base(addr) { }
    }
    public class ModioModDependencyList : Object
    {
        public ModioModDependencyList(nint addr) : base(addr) { }
        public ModioPagedResult PagedResult { get { return this[nameof(PagedResult)].As<ModioPagedResult>(); } set { this["PagedResult"] = value; } }
        public UArray<ModioModDependency> InternalList { get { return new UArray<ModioModDependency>(this[nameof(InternalList)].Address); } }
    }
    public class ModioModDependency : Object
    {
        public ModioModDependency(nint addr) : base(addr) { }
        public ModioModID ModId { get { return this[nameof(ModId)].As<ModioModID>(); } set { this["ModId"] = value; } }
        public Object ModName { get { return this[nameof(ModName)]; } set { this[nameof(ModName)] = value; } }
    }
    public class ModioOptionalModProgressInfo : Object
    {
        public ModioOptionalModProgressInfo(nint addr) : base(addr) { }
    }
    public class ModioModProgressInfo : Object
    {
        public ModioModProgressInfo(nint addr) : base(addr) { }
        public ModioUnsigned64 TotalDownloadSize { get { return this[nameof(TotalDownloadSize)].As<ModioUnsigned64>(); } set { this["TotalDownloadSize"] = value; } }
        public ModioUnsigned64 CurrentlyDownloadedBytes { get { return this[nameof(CurrentlyDownloadedBytes)].As<ModioUnsigned64>(); } set { this["CurrentlyDownloadedBytes"] = value; } }
        public ModioUnsigned64 TotalExtractedSizeOnDisk { get { return this[nameof(TotalExtractedSizeOnDisk)].As<ModioUnsigned64>(); } set { this["TotalExtractedSizeOnDisk"] = value; } }
        public ModioUnsigned64 CurrentlyExtractedBytes { get { return this[nameof(CurrentlyExtractedBytes)].As<ModioUnsigned64>(); } set { this["CurrentlyExtractedBytes"] = value; } }
        public ModioModID ID { get { return this[nameof(ID)].As<ModioModID>(); } set { this["ID"] = value; } }
    }
    public class ModioUnsigned64 : Object
    {
        public ModioUnsigned64(nint addr) : base(addr) { }
    }
    public class ModioReportParams : Object
    {
        public ModioReportParams(nint addr) : base(addr) { }
    }
    public class ModioTerms : Object
    {
        public ModioTerms(nint addr) : base(addr) { }
        public Object AgreeButtonText { get { return this[nameof(AgreeButtonText)]; } set { this[nameof(AgreeButtonText)] = value; } }
        public Object DisagreeButtonText { get { return this[nameof(DisagreeButtonText)]; } set { this[nameof(DisagreeButtonText)] = value; } }
        public ModioLink WebsiteLink { get { return this[nameof(WebsiteLink)].As<ModioLink>(); } set { this["WebsiteLink"] = value; } }
        public ModioLink TermsLink { get { return this[nameof(TermsLink)].As<ModioLink>(); } set { this["TermsLink"] = value; } }
        public ModioLink PrivacyLink { get { return this[nameof(PrivacyLink)].As<ModioLink>(); } set { this["PrivacyLink"] = value; } }
        public ModioLink ManageLink { get { return this[nameof(ManageLink)].As<ModioLink>(); } set { this["ManageLink"] = value; } }
    }
    public class ModioLink : Object
    {
        public ModioLink(nint addr) : base(addr) { }
        public Object Text { get { return this[nameof(Text)]; } set { this[nameof(Text)] = value; } }
        public Object URL { get { return this[nameof(URL)]; } set { this[nameof(URL)] = value; } }
        public bool bRequired { get { return this[nameof(bRequired)].Flag; } set { this[nameof(bRequired)].Flag = value; } }
    }
    public class ModioOptionalUser : Object
    {
        public ModioOptionalUser(nint addr) : base(addr) { }
    }
    public class ModioValidationError : Object
    {
        public ModioValidationError(nint addr) : base(addr) { }
        public Object FieldName { get { return this[nameof(FieldName)]; } set { this[nameof(FieldName)] = value; } }
        public Object ValidationFailureDescription { get { return this[nameof(ValidationFailureDescription)]; } set { this[nameof(ValidationFailureDescription)] = value; } }
    }
}
