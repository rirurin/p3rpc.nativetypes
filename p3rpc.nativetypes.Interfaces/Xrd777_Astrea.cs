using System.Runtime.InteropServices;
namespace p3rpc.nativetypes.Interfaces.Astrea;

#pragma warning disable CS1591
// #pragma warning disable RS0016

[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public unsafe struct UAgePanel
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0038)] public USprAsset* _readSpr;
    [FieldOffset(0x0040)] public USprAsset* _readSprAstrea;
    [FieldOffset(0x0048)] public UMaterial* _readMat;
    [FieldOffset(0x0058)] public UMaterialInstanceDynamic* _readMatInst;
    [FieldOffset(0x0068)] public FCurveVectorAnimation _fadeCurve;
    [FieldOffset(0xb0)] public bool bIsDarkHour;
    [FieldOffset(0x278)] public UAgePanelSection BottomMaterial;
    [FieldOffset(0x2a8)] public UAgePanelSection TopMaterial;
    [FieldOffset(0x02F0)] public UAssetLoader* Loader_;
    [FieldOffset(0x2f8)] public uint ActiveDrawTypeId;
    [FieldOffset(0x318)] public FLinearColor BottomColorNormal;
    [FieldOffset(0x328)] public FLinearColor BottomColorDarkHour;
    [FieldOffset(0x338)] public FLinearColor TopColorNormal;
    [FieldOffset(0x348)] public FLinearColor TopColorDarkHour;
    [FieldOffset(0x358)] public FLinearColor WaterColorNormal;
    [FieldOffset(0x368)] public FLinearColor WaterColorDarkHour;
}

[StructLayout(LayoutKind.Explicit, Size = 0x7F8)]
public unsafe struct AUIDateDraw
{
    [FieldOffset(0x0000)] public AUIBaseActor baseObj;
    [FieldOffset(0x02A8)] public UAgePanel* m_pAgePanel;
    [FieldOffset(0x02B0)] public USprAsset* m_pFieldSpr;
    [FieldOffset(0x02B8)] public USprAsset* m_pFieldSprAstrea;
    [FieldOffset(0x408)] public SprDefStruct1 TimeOfDayParams;
    [FieldOffset(0x7b5)] public byte TimeOfDay;
    [FieldOffset(0x07D8)] public UDataTable* LayoutData;
    [FieldOffset(0x07E0)] public UUILayoutDataTable* LayoutDataTable;
    [FieldOffset(0x07E8)] public UDataTable* LayoutDataAstrea;
    [FieldOffset(0x07F0)] public UUILayoutDataTable* LayoutDataTableAstrea;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1110)]
public unsafe struct AUIAccessInfoDraw
{
    [FieldOffset(0x0000)] public AUIBaseActor baseObj;
    [FieldOffset(0x02F0)] public USprAsset* m_pMiniMapSpr;
    [FieldOffset(0x02F8)] public USprAsset* m_pMiniMapSprAstrea;
    [FieldOffset(0x0300)] public USprAsset* m_pPlaceSpr;
    [FieldOffset(0x0308)] public USprAsset* m_pPlaceSprAstrea;
    [FieldOffset(0x0310)] public UUIMiniMapDraw* m_pMiniMap;
    [FieldOffset(0x0318)] public UAssetLoader* m_pLoader;
    //[FieldOffset(0x0320)] public AScrActor* m_pScrActor;
    [FieldOffset(0x0328)] public UBfAsset* m_pBfAsset;
    [FieldOffset(0x0330)] public UBmdAsset* m_pBmdAsset;
    [FieldOffset(0x0338)] public UUILocationSelect* m_pLocationSelect;
    [FieldOffset(0x0340)] public UPlgAsset* m_pPlacePlg;
    [FieldOffset(0x0348)] public UPlgAsset* m_pPlacePlgAstrea;
    [FieldOffset(0x0E88)] public FGetUIParameter m_tagUip;
    [FieldOffset(0x0F00)] public FCurveFloatAnimation m_tagFadeInCurve;
    [FieldOffset(0x0F30)] public FCurveFloatAnimation m_tagFadeOutCurve;
    [FieldOffset(0xf8c)] public FSprColor PlaceInfoBgColor;
    [FieldOffset(0x0FB8)] public UDataTable* LayoutData;
    [FieldOffset(0x0FC0)] public UUILayoutDataTable* LayoutDataTable;
    [FieldOffset(0x0FC8)] public UDataTable* LayoutParamData;
    [FieldOffset(0x0FD0)] public UDataTable* PlaceNameLayoutData;
    [FieldOffset(0x0FD8)] public UUILayoutDataTable* PlaceNameLayoutDataTable;
    [FieldOffset(0x0FE0)] public UDataTable* PlaceNameLayoutDataAstrea;
    [FieldOffset(0x0FE8)] public UUILayoutDataTable* PlaceNameLayoutDataTableAstrea;
    [FieldOffset(0x0FF0)] public UDataTable* MapNameLayoutData;
    [FieldOffset(0x0FF8)] public UUILayoutDataTable* MapNameLayoutDataTable;
    [FieldOffset(0x1000)] public UDataTable* IwatodaiFloorNoLayoutData;
    [FieldOffset(0x1008)] public UUILayoutDataTable* IwatodaiFloorNoLayoutDataTable;
    [FieldOffset(0x1010)] public UDataTable* MallFloorNoLayoutData;
    [FieldOffset(0x1018)] public UUILayoutDataTable* MallFloorNoLayoutDataTable;
    [FieldOffset(0x1020)] public UDataTable* SchoolFloorNoLayoutData;
    [FieldOffset(0x1028)] public UUILayoutDataTable* SchoolFloorNoLayoutDataTable;
    [FieldOffset(0x1030)] public UDataTable* DormitoryFloorNoLayoutData;
    [FieldOffset(0x1038)] public UUILayoutDataTable* DormitoryFloorNoLayoutDataTable;
    [FieldOffset(0x1040)] public UDataTable* RyokanFloorNoLayoutData;
    [FieldOffset(0x1048)] public UUILayoutDataTable* RyokanFloorNoLayoutDataTable;
    [FieldOffset(0x1050)] public UDataTable* HotelFloorNoLayoutData;
    [FieldOffset(0x1058)] public UUILayoutDataTable* HotelFloorNoLayoutDataTable;
    [FieldOffset(0x1060)] public UDataTable* ThebelFloorNoLayoutData;
    [FieldOffset(0x1068)] public UUILayoutDataTable* ThebelFloorNoLayoutDataTable;
    [FieldOffset(0x1070)] public UDataTable* ArqaFloorNoLayoutData;
    [FieldOffset(0x1078)] public UUILayoutDataTable* ArqaFloorNoLayoutDataTable;
    [FieldOffset(0x1080)] public UDataTable* YabbashahFloorNoLayoutData;
    [FieldOffset(0x1088)] public UUILayoutDataTable* YabbashahFloorNoLayoutDataTable;
    [FieldOffset(0x1090)] public UDataTable* TziahFloorNoLayoutData;
    [FieldOffset(0x1098)] public UUILayoutDataTable* TziahFloorNoLayoutDataTable;
    [FieldOffset(0x10A0)] public UDataTable* HarabahFloorNoLayoutData;
    [FieldOffset(0x10A8)] public UUILayoutDataTable* HarabahFloorNoLayoutDataTable;
    [FieldOffset(0x10B0)] public UDataTable* AdamahFloorNoLayoutData;
    [FieldOffset(0x10B8)] public UUILayoutDataTable* AdamahFloorNoLayoutDataTable;
    [FieldOffset(0x10C0)] public TArray<IntPtr> DungeonFloorNoLayoutDataAstrea;
    [FieldOffset(0x10D0)] public TArray<IntPtr> DungeonFloorNoLayoutDataTableAstrea;
}

[StructLayout(LayoutKind.Explicit, Size = 0x250)]
public unsafe struct UMsgProcWindow_Mind
{
    [FieldOffset(0x0000)] public UMsgProcWindowBase baseObj;
    [FieldOffset(0x0108)] public UAssetLoader* Loader_;
    [FieldOffset(0x0110)] public UMaterial* ReadMat_;
    [FieldOffset(0x0118)] public UMaterial* ReadaddMat_;
    [FieldOffset(0x0120)] public UMaterial* ReadblurMat_;
    [FieldOffset(0x0128)] public UMaterial* ReadlineMat_;
    [FieldOffset(0x0130)] public UMaterialInstanceDynamic* ReadMatInst_;
    [FieldOffset(0x0138)] public UMaterialInstanceDynamic* ReadaddMatInst_;
    [FieldOffset(0x0140)] public UMaterialInstanceDynamic* ReadblurMatInst_;
    [FieldOffset(0x0148)] public UMaterialInstanceDynamic* ReadlineMatInst_;
    [FieldOffset(0x0150)] public USprAsset* _readSpr;
    [FieldOffset(0x0158)] public UPlgAsset* MsgPlg_;
    [FieldOffset(0x160)] public UMsgProcWindow_Simple_NextPageParams NextPage;
    [FieldOffset(0x1a8)] public float leftSpotBgOpacity1;
    [FieldOffset(0x1bc)] public float leftSpotBgOpacity2;
    [FieldOffset(0x204)] public FLinearColor OuterBorderColor;
    [FieldOffset(0x214)] public FLinearColor InnerContentsColor;
    [FieldOffset(0x224)] public FLinearColor OutsideMistColor;
    [FieldOffset(0x0238)] public UUILayoutDataTable* LayoutDataTable;
}

[StructLayout(LayoutKind.Explicit, Size = 0x31E0)]
public unsafe struct ACmpMainActor
{
    [FieldOffset(0x0)] public AAppActor baseObj;
    [FieldOffset(0x288)] public int Field288;
    [FieldOffset(0x290)] public int MenuState;
    [FieldOffset(0x12C8)] public UAssetLoader* pAssetLoader;
    //[FieldOffset(0x12D0)] public TSubclassOf<ACampSceneCapture> SceneCaptureClass;
    //[FieldOffset(0x12D8)] public ACampSceneCapture* pSceneCapture2D;
    [FieldOffset(0x12E0)] public UMaterialInstance* pCaptureMaterial;
    [FieldOffset(0x12E8)] public UMaterialInstanceDynamic* pCaptureInstanceDynamic;
    [FieldOffset(0x12F0)] public UMaterialInstance* pOutlineMaterial;
    [FieldOffset(0x12F8)] public UMaterialInstanceDynamic* pOutlineInstanceDynamic;
    [FieldOffset(0x1300)] public UMaterial* pSimpleCopyMaterial;
    [FieldOffset(0x1308)] public UMaterialInstanceDynamic* pSimpleCopyMateDynamic;
    [FieldOffset(0x1310)] public UMaterial* pHologramMaterial;
    [FieldOffset(0x1318)] public UMaterialInstanceDynamic* pHologramMateDynamic;
    [FieldOffset(0x1320)] public UTexture2D* HologMaskTexAAry;
    [FieldOffset(0x1328)] public UTexture2D* HologMaskTexBAry;
    [FieldOffset(0x1330)] public UTexture2D* HologMaskTexCAry;
    [FieldOffset(0x1338)] public UTexture2D* HologMaskTexDAry;
    [FieldOffset(0x1348)] public UMaterialInstanceDynamic* pGlassMateDynamic;
    //[FieldOffset(0x1350)] public UTextureRenderTarget2D* pCaptureRenderTarget;
    [FieldOffset(0x1358)] public UTexture2D* HeroGaussMaskTexAry;
    [FieldOffset(0x13B0)] public UTexture2D* pOutAnimationTexture;
    [FieldOffset(0x13B8)] public USprAsset* pSprCommon;
    [FieldOffset(0x13C0)] public UUimAsset* pUimBgAry;
    [FieldOffset(0x13D0)] public UDataTable* pParamHologTable;
    [FieldOffset(0x13D8)] public UDataTable* pParamTopTable;
    [FieldOffset(0x13E0)] public UDataTable* pParamSkillTable;
    [FieldOffset(0x13E8)] public UDataTable* pParamItemTable;
    [FieldOffset(0x13F0)] public UDataTable* pParamEquipTable;
    [FieldOffset(0x13F8)] public UDataTable* pParamPersonaTable;
    [FieldOffset(0x1400)] public UDataTable* pParamStatusTable;
    [FieldOffset(0x1408)] public UDataTable* pParamRankUpTable;
    [FieldOffset(0x1410)] public UDataTable* pParamCommuTable;
    [FieldOffset(0x1418)] public UDataTable* pParamSystemTable;
    [FieldOffset(0x1420)] public UDataTable* pParamCommonTable;
    [FieldOffset(0x1428)] public UDataTable* pCameraTable;
    [FieldOffset(0x1430)] public UDataTable* pHologramTable;
    [FieldOffset(0x1438)] public UDataTable* pCharaLookAdjustTable;
    //[FieldOffset(0x1440)] public UMaterialParameterCollection* pCharaLookAdjustMPC;
    [FieldOffset(0x1448)] public UMaterial* pMateWaveCaustics;
    [FieldOffset(0x1450)] public FGetUIParameter m_SlashColorParameter;
    [FieldOffset(0x14C8)] public UDataTable* pParamLayoutDataRoot;
    [FieldOffset(0x14D0)] public UDataTable* pParamLayoutDataSystem;
    [FieldOffset(0x14D8)] public UDataTable* pParamTriangularCursorDataRoot;
    [FieldOffset(0x14E0)] public UDataTable* pParamTriangularCursorDataSystem;
    [FieldOffset(0x14E8)] public UDataTable* pParamLayoutDataQuest;
    [FieldOffset(0x14F0)] public UDataTable* pParamLayoutDataQuestDate;
    [FieldOffset(0x14F8)] public UDataTable* pParamLayoutPersonaList;
    [FieldOffset(0x1500)] public UDataTable* pParamLayoutDataItem;
    [FieldOffset(0x1508)] public UDataTable* pParamLayoutDataSkill;
    [FieldOffset(0x1510)] public UDataTable* pParamLayoutDataSkill2;
    [FieldOffset(0x1518)] public UDataTable* pParamLayoutDataOthers;
    [FieldOffset(0x1520)] public UDataTable* pParamLayoutDataOthersAstrea;
    [FieldOffset(0x1528)] public UDataTable* pParamLayoutDataHelpOthers;
    [FieldOffset(0x1530)] public UDataTable* pParamLayoutDataPartyPanel;
    [FieldOffset(0x1538)] public UDataTable* pParamLayoutDataTutorialText;
    [FieldOffset(0x1540)] public UDataTable* pParamLayoutDataDictionaryText;
    [FieldOffset(0x1548)] public UDataTable* pParamLayoutDataCalendarText;
    [FieldOffset(0x1550)] public UDataTable* pParamLayoutDataEquipTextCol;
    [FieldOffset(0x1558)] public UDataTable* pParamLayoutDataItemTextCol;
    [FieldOffset(0x1560)] public UDataTable* pParamLayoutDataQuestTextCol;
    [FieldOffset(0x1568)] public UDataTable* pParamLayoutDataQuestTextPos;
    [FieldOffset(0x1570)] public UDataTable* pParamLayoutDataQuestTextPosAstrea;
    [FieldOffset(0x1578)] public UDataTable* pParamLayoutDataQuestTextColAstrea;
    [FieldOffset(0x1580)] public UDataTable* pParamLayoutDataCommuTextCol;
    [FieldOffset(0x1588)] public UDataTable* pParamLayoutDataStatusTextCol;
    [FieldOffset(0x1590)] public UDataTable* pParamLayoutDataOkNext;
    [FieldOffset(0x1598)] public UDataTable* pParamLayoutDataOkNextMask;
    [FieldOffset(0x15A0)] public UDataTable* pParamLayoutDataRootTouchColl;
    [FieldOffset(0x15A8)] public UDataTable* pParamLayoutDataSystemTouchColl;
    [FieldOffset(0x15B0)] public UUimAsset* pUimNamiRootAAry;
    [FieldOffset(0x16A0)] public UUimAsset* pUimNamiRootBAry;
    [FieldOffset(0x1790)] public UUimAsset* pUimNamiSkillAAry;
    [FieldOffset(0x1880)] public UUimAsset* pUimNamiSkillBAry;
    [FieldOffset(0x1970)] public UUimAsset* pUimNamiItemAAry;
    [FieldOffset(0x1A60)] public UUimAsset* pUimNamiItemBAry;
    [FieldOffset(0x1B50)] public UUimAsset* pUimNamiEquipAAry;
    [FieldOffset(0x1C40)] public UUimAsset* pUimNamiEquipBAry;
    [FieldOffset(0x1D30)] public UUimAsset* pUimNamiPersonaAAry;
    [FieldOffset(0x1E20)] public UUimAsset* pUimNamiPersonaBAry;
    [FieldOffset(0x1F10)] public UUimAsset* pUimNamiStatusAAry;
    [FieldOffset(0x2000)] public UUimAsset* pUimNamiStatusBAry;
    [FieldOffset(0x20F0)] public UUimAsset* pUimNamiQuestAAry;
    [FieldOffset(0x21E0)] public UUimAsset* pUimNamiQuestBAry;
    [FieldOffset(0x22D0)] public UUimAsset* pUimNamiCommuAAry;
    [FieldOffset(0x23C0)] public UUimAsset* pUimNamiCommuBAry;
    [FieldOffset(0x24B0)] public UUimAsset* pUimNamiCalendarAAry;
    [FieldOffset(0x25A0)] public UUimAsset* pUimNamiCalendarBAry;
    [FieldOffset(0x2690)] public UUimAsset* pUimNamiSystemAAry;
    [FieldOffset(0x2780)] public UUimAsset* pUimNamiSystemBAry;
    [FieldOffset(0x2870)] public UUimAsset* pUimNamiTutorialAAry;
    [FieldOffset(0x2960)] public UUimAsset* pUimNamiTutorialBAry;
    [FieldOffset(0x2A50)] public UUimAsset* pUimNamiConfigAAry;
    [FieldOffset(0x2B40)] public UUimAsset* pUimNamiConfigBAry;
    [FieldOffset(0x2C30)] public UTexture2D* pCharaGlassAry;
    [FieldOffset(0x2C90)] public UTexture2D* pCharaDetailAry;
    [FieldOffset(0x2CF0)] public UTexture2D* pCharaDetailShdAry;
    [FieldOffset(0x2D70)] public TArray<IntPtr> MenuList;
    [FieldOffset(0x2D88)] public UCmpMenuBase* pCurrentMenu;
    [FieldOffset(0x2D90)] public UCmpMenuBase* pNextMenu;
    [FieldOffset(0x2D98)] public UCmpMenuBase* pPrevMenu;
    //[FieldOffset(0x2DA0)] public UCampModelController* pModelController;
    //[FieldOffset(0x2DA8)] public ACmpMainLoadActor* pCmpMainLoadActor;
    //[FieldOffset(0x2DB8)] public TSubclassOf<ACharacter> pHeroCharaClass;
    //[FieldOffset(0x2DC0)] public UAppAnimCtrl* pHeroAnimCtrl;
    [FieldOffset(0x2DC8)] public TArray<IntPtr> MateInterAry;
    [FieldOffset(0x2DD8)] public bool bIsDisableForceTermination;
    [FieldOffset(0x2DDA)] public bool bEquipChange;
    [FieldOffset(0x2DDB)] public bool bReturnCommuToField;
    //[FieldOffset(0x2DE0)] public UUIRequest* pUIRequest;
    [FieldOffset(0x2DE8)] public UUIMissingPerson* pUIMissingPerson;
    //[FieldOffset(0x2DF0)] public UUITheurgia* pUITheurgia;
    [FieldOffset(0x3100)] public UUILayoutDataTable* RootLayoutDataTable;
    [FieldOffset(0x3108)] public UUILayoutDataTable* SystemLayoutDataTable;
    [FieldOffset(0x3110)] public UUILayoutDataTable* QuestLayoutDataTable;
    [FieldOffset(0x3118)] public UUILayoutDataTable* QuestDateLayoutDataTable;
    [FieldOffset(0x3120)] public UUILayoutDataTable* OthersLayoutDataTable;
    [FieldOffset(0x3128)] public UUILayoutDataTable* OthersLayoutDataTableAstrea;
    [FieldOffset(0x3130)] public UUILayoutDataTable* HelpOthersLayoutDataTable;
    [FieldOffset(0x3138)] public UUILayoutDataTable* PersonaListLayoutDataTable;
    [FieldOffset(0x3140)] public UUILayoutDataTable* ItemLayoutDataTable;
    [FieldOffset(0x3148)] public UUILayoutDataTable* SkillLayoutDataTable;
    [FieldOffset(0x3150)] public UUILayoutDataTable* SkillLayoutDataTable2;
    [FieldOffset(0x3158)] public UUILayoutDataTable* PartyPanelLayoutDataTable;
    [FieldOffset(0x3160)] public UUILayoutDataTable* TutorialTextLayoutDataTable;
    [FieldOffset(0x3168)] public UUILayoutDataTable* DictionaryTextLayoutDataTable;
    [FieldOffset(0x3170)] public UUILayoutDataTable* CalendarTextLayoutDataTable;
    [FieldOffset(0x3178)] public UUILayoutDataTable* EquipTextColLayoutDataTable;
    [FieldOffset(0x3180)] public UUILayoutDataTable* ItemTextColLayoutDataTable;
    [FieldOffset(0x3188)] public UUILayoutDataTable* QuestTextColLayoutDataTable;
    [FieldOffset(0x3190)] public UUILayoutDataTable* QuestTextPosLayoutDataTable;
    [FieldOffset(0x3198)] public UUILayoutDataTable* QuestTextPosLayoutDataTableAstrea;
    [FieldOffset(0x31A0)] public UUILayoutDataTable* QuestTextColLayoutDataTableAstrea;
    [FieldOffset(0x31A8)] public UUILayoutDataTable* CommuTextColLayoutDataTable;
    [FieldOffset(0x31B0)] public UUILayoutDataTable* StatusTextColLayoutDataTable;
    [FieldOffset(0x31B8)] public UUILayoutDataTable* OkNextLayoutDataTable;
    [FieldOffset(0x31C0)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
    [FieldOffset(0x31C8)] public UUILayoutDataTable* RootTouchCollLayoutDataTable;
    [FieldOffset(0x31D0)] public UUILayoutDataTable* SystemTouchCollLayoutDataTable;
}

public unsafe class CmpMainActor : ICmpMainActor
{
    private ACmpMainActor* Data;
    public CmpMainActor(ACmpMainActor* _Data) { Data = _Data; }
    private ACmpMainActor* Self() => Data;
    public int GetField288() => Self()->Field288;
    public int GetMenuState() => Self()->MenuState;
    public UAssetLoader* GetAssetLoader() => Self()->pAssetLoader;
    public unsafe UMaterialInstance* GetCaptureMaterial() => Self()->pCaptureMaterial;
    public unsafe UMaterialInstanceDynamic* GetCaptureInstanceDynamic() => Self()->pCaptureInstanceDynamic;
    public unsafe UMaterialInstance* GetOutlineMaterial() => Self()->pOutlineMaterial;
    public unsafe UMaterialInstanceDynamic* GetOutlineInstanceDynamic() => Self()->pOutlineInstanceDynamic;
    public unsafe UMaterial* GetSimpleCopyMaterial() => Self()->pSimpleCopyMaterial;
    public unsafe UMaterialInstanceDynamic* GetSimpleCopyMateDynamic() => Self()->pSimpleCopyMateDynamic;
    public unsafe UMaterial* GetHologramMaterial() => Self()->pHologramMaterial;
    public unsafe UMaterialInstanceDynamic* GetHologramMateDynamic() => Self()->pHologramMateDynamic;
    public unsafe UTexture2D* GetHologMaskTexAAry() => Self()->HologMaskTexAAry;
    public unsafe UTexture2D* GetHologMaskTexBAry() => Self()->HologMaskTexBAry;
    public unsafe UTexture2D* GetHologMaskTexCAry() => Self()->HologMaskTexCAry;
    public unsafe UTexture2D* GetHologMaskTexDAry() => Self()->HologMaskTexDAry;
    public unsafe UMaterialInstanceDynamic* GetGlassMateDynamic() => Self()->pHologramMateDynamic;
    public unsafe UCmpMenuBase* GetCurrentMenu() => Self()->pCurrentMenu;
    public unsafe UCmpMenuBase* GetNextMenu() => Self()->pNextMenu;
    public unsafe UCmpMenuBase* GetPrevMenu() => Self()->pPrevMenu;
    public unsafe UUILayoutDataTable* GetRootLayoutDataTable() => Self()->RootLayoutDataTable;
    public unsafe UUILayoutDataTable* GetSystemLayoutDataTable() => Self()->SystemLayoutDataTable;
    public unsafe UUILayoutDataTable* GetQuestLayoutDataTable() => Self()->QuestLayoutDataTable;
    public unsafe UUILayoutDataTable* GetQuestDateLayoutDataTable() => Self()->QuestDateLayoutDataTable;
    public unsafe UUILayoutDataTable* GetOthersLayoutDataTable() => Self()->OthersLayoutDataTable;
    public unsafe UUILayoutDataTable* GetHelpOthersLayoutDataTable() => Self()->HelpOthersLayoutDataTable;
    public unsafe UUILayoutDataTable* GetPersonaListLayoutDataTable() => Self()->PersonaListLayoutDataTable;
    public unsafe UUILayoutDataTable* GetItemLayoutDataTable() => Self()->ItemLayoutDataTable;
    public unsafe UUILayoutDataTable* GetSkillLayoutDataTable() => Self()->SkillLayoutDataTable;
    public unsafe UUILayoutDataTable* GetSkillLayoutDataTable2() => Self()->SkillLayoutDataTable2;
    public unsafe UUILayoutDataTable* GetPartyPanelLayoutDataTable() => Self()->PartyPanelLayoutDataTable;
    public unsafe UUILayoutDataTable* GetTutorialTextLayoutDataTable() => Self()->TutorialTextLayoutDataTable;
    public unsafe UUILayoutDataTable* GetDictionaryTextLayoutDataTable() => Self()->DictionaryTextLayoutDataTable;
    public unsafe UUILayoutDataTable* GetCalendarTextLayoutDataTable() => Self()->CalendarTextLayoutDataTable;
    public unsafe UUILayoutDataTable* GetEquipTextColLayoutDataTable() => Self()->EquipTextColLayoutDataTable;
    public unsafe UUILayoutDataTable* GetItemTextColLayoutDataTable() => Self()->ItemTextColLayoutDataTable;
    public unsafe UUILayoutDataTable* GetQuestTextColLayoutDataTable() => Self()->QuestTextColLayoutDataTable;
    public unsafe UUILayoutDataTable* GetQuestTextPosLayoutDataTable() => Self()->QuestTextPosLayoutDataTable;
    public unsafe UUILayoutDataTable* GetCommuTextColLayoutDataTable() => Self()->CommuTextColLayoutDataTable;
    public unsafe UUILayoutDataTable* GetStatusTextColLayoutDataTable() => Self()->StatusTextColLayoutDataTable;
    public unsafe UUILayoutDataTable* GetOkNextLayoutDataTable() => Self()->OkNextLayoutDataTable;
    public unsafe UUILayoutDataTable* GetOkNextMaskLayoutDataTable() => Self()->OkNextMaskLayoutDataTable;
    public unsafe UUILayoutDataTable* GetRootTouchCollLayoutDataTable() => Self()->RootTouchCollLayoutDataTable;
    public unsafe UUILayoutDataTable* GetSystemTouchCollLayoutDataTable() => Self()->SystemTouchCollLayoutDataTable;

}

[StructLayout(LayoutKind.Explicit, Size = 0x508)]
public unsafe struct FKeyHelpButtonBase
{
    [FieldOffset(0x10)] public USprAsset* keyHelpSpr;
    [FieldOffset(0x18)] public USprAsset* keyHelpSpr2;
    [FieldOffset(0x20)] public UPlgAsset* keyHelpPlg;
    [FieldOffset(0x28)] public UPlgAsset* Field28;
    //[FieldOffset(0x48)] public FKeyHelpButtonUILayout Sprites;
    [FieldOffset(0x1f0)] public FKeyHelpButtonUILayout TextLayout;
    [FieldOffset(0x24c)] public float KeyHelpTransparency;
    [FieldOffset(0x260)] public int SpriteCount;
    [FieldOffset(0x41c)] public FSprColor moviePauseMainColor;
    [FieldOffset(0x4dc)] public FSprColor moviePausePulseColor;

    public FKeyHelpButtonUILayout* GetSpriteLayout(int i) { fixed (FKeyHelpButtonBase* self = &this) { return &((FKeyHelpButtonUILayout*)((nint)self + 0x50))[i]; } }
}

[StructLayout(LayoutKind.Explicit, Size = 0x5a0)]
public unsafe struct FKeyHelpButtonAuto
{
    [FieldOffset(0x0)] public FKeyHelpButtonBase Super;
    [FieldOffset(0x548)] public FKeyHelpInterpolate Field540;
    [FieldOffset(0x598)] public int ActivationState;
}
[StructLayout(LayoutKind.Explicit, Size = 0x598)]
public unsafe struct FKeyHelpButtonFastForward
{
    [FieldOffset(0x0)] public FKeyHelpButtonBase Super;
    [FieldOffset(0x540)] public FKeyHelpInterpolate Field538;
    [FieldOffset(0x590)] public int ActivationState;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30A30)]
public unsafe struct UGlobalWork
{
    [FieldOffset(0x0)] public UGameInstance baseObj;
    //[FieldOffset(0x1b0)] public FDatUnitWork PlayerCharacters[13]; // 10100_3 to 10109_3
    [FieldOffset(0x24d4)] public fixed ushort ActiveCharacters[10]; // 10050_1
    [FieldOffset(0x24e8)] public ItemBag Items; // 10051_1
    [FieldOffset(0x4260)] public uint Money; // 10052_1
    [FieldOffset(0x4264)] public fixed byte Section0[384]; // 10000_1
    [FieldOffset(0x43e4)] public fixed byte Section1[384]; // 10001_2
    [FieldOffset(0x4564)] public fixed byte Section2[640]; // 10002_1
    [FieldOffset(0x47e4)] public fixed byte Section3[64]; // 10003_1
    [FieldOffset(0x4824)] public fixed byte Section4[64]; // 10004_1
    [FieldOffset(0x4864)] public fixed byte Section5[64]; // 10005_1
    [FieldOffset(0x48a4)] public fixed int Counters[384]; // 10010_1
    //[FieldOffset(0x4904)] public FDatUnitPersona Personas[464]; // 10053_1
    [FieldOffset(0xa5a4)] public fixed byte Analysis[828]; // 10054_1
    [FieldOffset(0xa8e0)] public Calendar Calendar; // 10030_1
    //[FieldOffset(0xa8f0)] public byte Shop[7424];
    [FieldOffset(0xc6d0)] public CharacterName Name; // 10061_4
    [FieldOffset(0xc82c)] public Mail Mail; // 10081_2
    [FieldOffset(0x30068)] public USequence* mSequenceInstance_;
    [FieldOffset(0x30070)] public UCalendar* mCalendarInstance_;
    [FieldOffset(0x30078)] public UCldCommonData* mCldCommonData_;
    // [FieldOffset(0x30080)] public UAstreaProgress* mAstreaProgressInstance_;
    // [FieldOffset(0x30088)] public UPrgssCommonData* mAstreaPrgssCommonData_;
    [FieldOffset(0x30090)] public UFileNameManager* mFileNameData_;
    [FieldOffset(0x30098)] public UFldCommonData* mFldCommonData_;
    [FieldOffset(0x300A0)] public UDatItem* mItemData_;
    [FieldOffset(0x300A8)] public UTrophyManager* mTrophy_;
    [FieldOffset(0x300B0)] public ULeaderBoardManager* mLeaderBoard_;
    [FieldOffset(0x300B8)] public USignedInDialog* mSignedInDialog_;
    [FieldOffset(0x300C0)] public UErrorDialog* mErrorDialog_;
    [FieldOffset(0x300C8)] public UMessageDialog* mMessageDialog_;
    [FieldOffset(0x300D0)] public UBustupController* pBustupController;
    [FieldOffset(0x300D8)] public UCommunityWork* pCommunityWork;
    [FieldOffset(0x300E0)] public UMsgWork* pMsgWork;
    [FieldOffset(0x300E8)] public UEvtDataLoad* pEvtDataLoad;
    // [FieldOffset(0x300F0)] public UFrameBufferCapture* pFrameBufferCapture;
    [FieldOffset(0x300F8)] public UPadRumble* pPadRumble;
    [FieldOffset(0x301d0)] public UFldCharParamTable* mFldCharParamTable_;
    // [FieldOffset(0x301d8)] public UAppCharFootstepsTable* mFootstepsTable_;
    // [FieldOffset(0x301e0)] public UAppCharacterPoolManager* mCharacterPoolManager_;
    // [FieldOffset(0x301e8)] public UDatSystemText* mSystemTextTable;
    // [FieldOffset(0x301f0)] public UDatUIUseText* mUIUseTextTable;
    // [FieldOffset(0x301f8)] public UDatUICalendarText* mUICalendarTextTable;
    [FieldOffset(0x30200)] public UXrd777SaveManager* mSaveManager_;
    // [FieldOffset(0x30208)] public UAddContent* mAddContent_;
    // [FieldOffset(0x30898)] public ULoading* pLoadingInst;
    [FieldOffset(0x308A0)] public ACmpMainActor* mCmpMainActor_;
    // [FieldOffset(0x308A8)] public ABtlGuiResourcesBase* mBtlGuiResourcesActor_;
    // [FieldOffset(0x308B0)] public UBtlEncountWipeLoader* mBtlEncountWipeLoader_;
    // [FieldOffset(0x308B8)] public ABtlEncountWipeCore* mBtlEncountWipeCore_;
    // [FieldOffset(0x308C0)] public AFldLevelPoolManager* mLevelPoolManager_;
    [FieldOffset(0x308C8)] public bool mPoolSetting_;
    [FieldOffset(0x30918)] public FSaveGameHeadder mTempSaveHeader_;
    [FieldOffset(0x309E8)] public bool bTempSaveHeaderUsed_;
    [FieldOffset(0x309F0)] public UGlobalGameData* mGameDataProc_;
    [FieldOffset(0x309F8)] public AAppActor* mSystemMonitor_;
    // [FieldOffset(0x30A18)] public AResidentReloadActor* ResidentReloadActor;
}

public unsafe class GlobalWork : IGlobalWork
{
    private UGlobalWork* Data;
    public GlobalWork(UGlobalWork* _Data) { Data = _Data; }
    private UGlobalWork* Self() => Data;
    public FDatUnitWork* GetUnit(int i) => &((FDatUnitWork*)((nint)Self() + 0x1b0))[i];

    public unsafe byte* GetPtr() => (byte*)Self();
    public List<short> GetActiveCharacters()
    {
        List<short> ids = new();
        for (int i = 0; i < 10; i++)
        {
            var curr_mem = (short)Self()->ActiveCharacters[i];
            if (curr_mem == 0) break;
            ids.Add(curr_mem);
        }
        return ids;
    }

    public bool GetBitflag(uint id)
    {
        uint section = id >> 0x1c;
        uint flag_int = (id >> 5 & 0x7fffff);
        uint flag_bit = (uint)(1 << ((int)id & 0x1f));
        switch (section)
        {
            case 0: return Self()->Section0[flag_int] % flag_bit == 1 ? true : false;
            case 1: return Self()->Section1[flag_int] % flag_bit == 1 ? true : false;
            case 2: return Self()->Section2[flag_int] % flag_bit == 1 ? true : false;
            case 3: return Self()->Section3[flag_int] % flag_bit == 1 ? true : false;
            case 4: return Self()->Section4[flag_int] % flag_bit == 1 ? true : false;
            case 5: return Self()->Section5[flag_int] % flag_bit == 1 ? true : false;
            default: return false;
        }
    }
    public int GetCounter(uint i) => Self()->Counters[i];
    public FDatUnitPersonaEntry* GetPersona(uint i) => &((FDatUnitPersonaEntry*)((nint)Self() + 0x4904))[i];
    public Mail* GetMail() => &Self()->Mail;
    public Calendar* GetCalendar() => &Self()->Calendar;
    public unsafe USequence* GetSequenceInstance() => Self()->mSequenceInstance_;
    public unsafe UCalendar* GetCalendarInstance() => Self()->mCalendarInstance_;
    public unsafe UCldCommonData* GetCldCommonData() => Self()->mCldCommonData_;
    public unsafe UFileNameManager* GetFileNameData() => Self()->mFileNameData_;
    public unsafe UFldCommonData* GetFldCommonData() => Self()->mFldCommonData_;
    public unsafe UDatItem* GetItemData() => Self()->mItemData_;
    public unsafe UTrophyManager* GetTrophy() => Self()->mTrophy_;
    public unsafe ULeaderBoardManager* GetLeaderBoard() => Self()->mLeaderBoard_;
    public unsafe USignedInDialog* GetSignedInDialog() => Self()->mSignedInDialog_;
    public unsafe UErrorDialog* GetErrorDialog() => Self()->mErrorDialog_;
    public unsafe UMessageDialog* GetMessageDialog() => Self()->mMessageDialog_;
    public unsafe UBustupController* GetBustupController() => Self()->pBustupController;
    public unsafe UCommunityWork* GetCommunityWork() => Self()->pCommunityWork;
    public unsafe UMsgWork* GetMsgWork() => Self()->pMsgWork;
    public unsafe UEvtDataLoad* GetEvtDataLoad() => Self()->pEvtDataLoad;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30A50)]
public unsafe struct UGlobalWorkUWP
{
    [FieldOffset(0x0)] public UGameInstance baseObj;
    //[FieldOffset(0x1b0)] public FDatUnitWork PlayerCharacters[13]; // 10100_3 to 10109_3
    [FieldOffset(0x24d4)] public fixed ushort ActiveCharacters[10]; // 10050_1
    [FieldOffset(0x24e8)] public ItemBag Items; // 10051_1
    [FieldOffset(0x4260)] public uint Money; // 10052_1
    [FieldOffset(0x4264)] public fixed byte Section0[384]; // 10000_1
    [FieldOffset(0x43e4)] public fixed byte Section1[384]; // 10001_2
    [FieldOffset(0x4564)] public fixed byte Section2[640]; // 10002_1
    [FieldOffset(0x47e4)] public fixed byte Section3[64]; // 10003_1
    [FieldOffset(0x4824)] public fixed byte Section4[64]; // 10004_1
    [FieldOffset(0x4864)] public fixed byte Section5[64]; // 10005_1
    [FieldOffset(0x48a4)] public fixed int Counters[384]; // 10010_1
    //[FieldOffset(0x4904)] public FDatUnitPersona Personas[464]; // 10053_1
    [FieldOffset(0xa5a4)] public fixed byte Analysis[828]; // 10054_1
    [FieldOffset(0xa8e0)] public Calendar Calendar; // 10030_1
    //[FieldOffset(0xa8f0)] public byte Shop[7424];
    [FieldOffset(0xc6d0)] public CharacterName Name; // 10061_4
    [FieldOffset(0xc82c)] public Mail Mail; // 10081_2
    [FieldOffset(0x30088)] public USequence* mSequenceInstance_;
    [FieldOffset(0x30090)] public UCalendar* mCalendarInstance_;
    [FieldOffset(0x30098)] public UCldCommonData* mCldCommonData_;
    // [FieldOffset(0x300A0)] public UAstreaProgress* mAstreaProgressInstance_;
    // [FieldOffset(0x300A8)] public UPrgssCommonData* mAstreaPrgssCommonData_;
    [FieldOffset(0x300B0)] public UFileNameManager* mFileNameData_;
    [FieldOffset(0x300B8)] public UFldCommonData* mFldCommonData_;
    [FieldOffset(0x300C0)] public UDatItem* mItemData_;
    [FieldOffset(0x300C8)] public UTrophyManager* mTrophy_;
    [FieldOffset(0x300D0)] public ULeaderBoardManager* mLeaderBoard_;
    [FieldOffset(0x300D8)] public USignedInDialog* mSignedInDialog_;
    [FieldOffset(0x300E0)] public UErrorDialog* mErrorDialog_;
    [FieldOffset(0x300E8)] public UMessageDialog* mMessageDialog_;
    [FieldOffset(0x300F0)] public UBustupController* pBustupController;
    [FieldOffset(0x300F8)] public UCommunityWork* pCommunityWork;
    [FieldOffset(0x30100)] public UMsgWork* pMsgWork;
    [FieldOffset(0x30108)] public UEvtDataLoad* pEvtDataLoad;
    // [FieldOffset(0x30110)] public UFrameBufferCapture* pFrameBufferCapture;
    [FieldOffset(0x30118)] public UPadRumble* pPadRumble;
    [FieldOffset(0x301F0)] public UFldCharParamTable* mFldCharParamTable_;
    // [FieldOffset(0x301F8)] public UAppCharFootstepsTable* mFootstepsTable_;
    // [FieldOffset(0x30200)] public UAppCharacterPoolManager* mCharacterPoolManager_;
    // [FieldOffset(0x30208)] public UDatSystemText* mSystemTextTable;
    // [FieldOffset(0x30210)] public UDatUIUseText* mUIUseTextTable;
    // [FieldOffset(0x30218)] public UDatUICalendarText* mUICalendarTextTable;
    [FieldOffset(0x30220)] public UXrd777SaveManager* mSaveManager_;
    // [FieldOffset(0x30228)] public UAddContent* mAddContent_;
    // [FieldOffset(0x308B8)] public ULoading* pLoadingInst;
    [FieldOffset(0x308C0)] public ACmpMainActor* mCmpMainActor_;
    // [FieldOffset(0x308C8)] public ABtlGuiResourcesBase* mBtlGuiResourcesActor_;
    // [FieldOffset(0x308D0)] public UBtlEncountWipeLoader* mBtlEncountWipeLoader_;
    // [FieldOffset(0x308D8)] public ABtlEncountWipeCore* mBtlEncountWipeCore_;
    // [FieldOffset(0x308E0)] public AFldLevelPoolManager* mLevelPoolManager_;
    [FieldOffset(0x308E8)] public bool mPoolSetting_;
    [FieldOffset(0x30938)] public FSaveGameHeadder mTempSaveHeader_;
    [FieldOffset(0x30A08)] public bool bTempSaveHeaderUsed_;
    [FieldOffset(0x30A10)] public UGlobalGameData* mGameDataProc_;
    [FieldOffset(0x30A18)] public AAppActor* mSystemMonitor_;
    // [FieldOffset(0x30A38)] public AResidentReloadActor* ResidentReloadActor;
}

public unsafe class GlobalWorkUWP : IGlobalWork
{
    private UGlobalWorkUWP* Data;
    public GlobalWorkUWP(UGlobalWorkUWP* _Data) { Data = _Data; }
    private UGlobalWorkUWP* Self() => Data;
    public FDatUnitWork* GetUnit(int i) => &((FDatUnitWork*)((nint)Self() + 0x1b0))[i];
    
    public unsafe byte* GetPtr() => (byte*)Self();
    public List<short> GetActiveCharacters()
    {
        List<short> ids = new();
        for (int i = 0; i < 10; i++)
        {
            var curr_mem = (short)Self()->ActiveCharacters[i];
            if (curr_mem == 0) break;
            ids.Add(curr_mem);
        }
        return ids;
    }

    public bool GetBitflag(uint id)
    {
        uint section = id >> 0x1c;
        uint flag_int = (id >> 5 & 0x7fffff);
        uint flag_bit = (uint)(1 << ((int)id & 0x1f));
        switch (section)
        {
            case 0: return Self()->Section0[flag_int] % flag_bit == 1 ? true : false;
            case 1: return Self()->Section1[flag_int] % flag_bit == 1 ? true : false;
            case 2: return Self()->Section2[flag_int] % flag_bit == 1 ? true : false;
            case 3: return Self()->Section3[flag_int] % flag_bit == 1 ? true : false;
            case 4: return Self()->Section4[flag_int] % flag_bit == 1 ? true : false;
            case 5: return Self()->Section5[flag_int] % flag_bit == 1 ? true : false;
            default: return false;
        }
    }
    public int GetCounter(uint i) => Self()->Counters[i];
    public FDatUnitPersonaEntry* GetPersona(uint i) => &((FDatUnitPersonaEntry*)((nint)Self() + 0x4904))[i];
    public Mail* GetMail() => &Self()->Mail;
    public Calendar* GetCalendar() => &Self()->Calendar;
    public unsafe USequence* GetSequenceInstance() => Self()->mSequenceInstance_;
    public unsafe UCalendar* GetCalendarInstance() => Self()->mCalendarInstance_;
    public unsafe UCldCommonData* GetCldCommonData() => Self()->mCldCommonData_;
    public unsafe UFileNameManager* GetFileNameData() => Self()->mFileNameData_;
    public unsafe UFldCommonData* GetFldCommonData() => Self()->mFldCommonData_;
    public unsafe UDatItem* GetItemData() => Self()->mItemData_;
    public unsafe UTrophyManager* GetTrophy() => Self()->mTrophy_;
    public unsafe ULeaderBoardManager* GetLeaderBoard() => Self()->mLeaderBoard_;
    public unsafe USignedInDialog* GetSignedInDialog() => Self()->mSignedInDialog_;
    public unsafe UErrorDialog* GetErrorDialog() => Self()->mErrorDialog_;
    public unsafe UMessageDialog* GetMessageDialog() => Self()->mMessageDialog_;
    public unsafe UBustupController* GetBustupController() => Self()->pBustupController;
    public unsafe UCommunityWork* GetCommunityWork() => Self()->pCommunityWork;
    public unsafe UMsgWork* GetMsgWork() => Self()->pMsgWork;
    public unsafe UEvtDataLoad* GetEvtDataLoad() => Self()->pEvtDataLoad;
}