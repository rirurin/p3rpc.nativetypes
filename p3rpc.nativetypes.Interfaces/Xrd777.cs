using System.Runtime.InteropServices;
namespace p3rpc.nativetypes.Interfaces;

#pragma warning disable CS1591
#pragma warning disable CS0169

// ===================================
// GENERATED FROM UE4SS CXX HEADER DUMP
// Also thanks Ryn!
// ===================================

public enum EAppPauseObjectFlag : byte
{
    Unknown = 0,
    CampUI = 1,
    CharacterModel = 2,
    FieldLocal = 4,
    SystemUI = 8,
    FacilityUI = 16,
    FieldSound = 32,
    FieldCrowd = 64,
    Always = 255,
};

[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe struct AAppActor // : AActor
{
    [FieldOffset(0x230)] public EAppPauseObjectFlag AppPauseFlags;
}
public enum UIGenericSelectDrawTitleType : uint
{
    List = 0,
    Select = 1,
    Item = 2,
    Nothing = 3
}

[StructLayout(LayoutKind.Explicit, Size = 0x428)]
public unsafe struct AUIGenericSelectDraw // : AUIDrawBaseActor
{
    [FieldOffset(0x02B8)] public FVector2D Edit_PointA;
    [FieldOffset(0x02C0)] public FVector2D Edit_PointD;
    [FieldOffset(0x02C8)] public FVector2D Edit_PointG;
    [FieldOffset(0x02D0)] public FVector2D Edit_PointH;
    [FieldOffset(0x02D8)] public float Edit_TitleLogo_LoopAnima_Offset_Min;
    [FieldOffset(0x02DC)] public float Edit_TitleLogo_LoopAnima_Offset_Max;
    [FieldOffset(0x02E0)] public float Edit_Character_LoopAnima_Offset_Min;
    [FieldOffset(0x02E4)] public float Edit_Character_LoopAnima_Offset_Max;
    [FieldOffset(0x02E8)] public int Edit_Cursor_AnimationFrame;
    [FieldOffset(0x02EC)] public int Edit_SubCursor_AnimationFrame;
    [FieldOffset(0x02F0)] public int Edit_InAnimation_1_1;
    [FieldOffset(0x02F4)] public int Edit_InAnimation_1_1_2;
    [FieldOffset(0x02F8)] public int Edit_InAnimation_1_3;
    [FieldOffset(0x02FC)] public int Edit_InAnimation_1_3_CharacterMask_DelayFrame;
    [FieldOffset(0x0300)] public int Edit_InAnimation_1_4_ListItem_InFrame;
    [FieldOffset(0x0304)] public int Edit_InAnimation_1_4_ListItem_DelayFrame;
    [FieldOffset(0x0308)] public int Edit_InAnimation_1_4_Cursor_InFrame;
    [FieldOffset(0x030C)] public int Edit_InAnimation_1_4_Cursor_DelayFrame;
    [FieldOffset(0x0310)] public int Edit_LoopAnima_Frame_Min;
    [FieldOffset(0x0314)] public int Edit_LoopAnima_Frame_Max;
    [FieldOffset(0x0318)] public int Edit_OutAnimation_3_1;
    [FieldOffset(0x031C)] public int Edit_CharacterChange_In_Frame;
    [FieldOffset(0x0320)] public int Edit_CharacterChange_Out_Frame;
    [FieldOffset(0x0324)] public int Edit_CharacterChange_Slide_Frame;
    [FieldOffset(0x0328)] public FColor Edit_TitleLogo_MorninColor;
    [FieldOffset(0x032C)] public FColor Edit_TitleLogo_AfterschoolColor;
    [FieldOffset(0x0330)] public FColor Edit_TitleLogo_NightColor;
    [FieldOffset(0x0334)] public FColor Edit_ListAndCharacter_MorninColor;
    [FieldOffset(0x0338)] public FColor Edit_ListAndCharacter_AfterschoolColor;
    [FieldOffset(0x033C)] public FColor Edit_ListAndCharacter_NightColor;
    [FieldOffset(0x0340)] public FColor Edit_CharacterBackPlate_MorninColor;
    [FieldOffset(0x0344)] public FColor Edit_CharacterBackPlate_AfterschoolColor;
    [FieldOffset(0x0348)] public FColor Edit_CharacterBackPlate_NightColor;
    [FieldOffset(0x0350)] public USprAsset* pSprAsset;
    [FieldOffset(0x0358)] public UPlgAsset* pPlgAsset;
    [FieldOffset(0x0360)] public UGenericSelectCharacterDataAsset* pCharacterDataAsset;
    [FieldOffset(0x03dc)] public UIGenericSelectDrawTitleType DrawTitleType;
    [FieldOffset(0x03e0)] public UGenericSelectSystemBase* PSystem;
    [FieldOffset(0x03e8)] public TArray<nint> CharacterEnableList; // TArray<UUIGenericSelectCharacter*>
    [FieldOffset(0x03f8)] public TArray<nint> CharacterDisableList; // TArray<UUIGenericSelectCharacter*>
    [FieldOffset(0x0408)] public AUIGenericSelect* Field408;
}

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct FGenericSelectCharacterTextureItem
{
    uint characterId;
    UTexture* pTexture;
};

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UGenericSelectCharacterDataAsset //: public UAppDataAsset
{
    [FieldOffset(0x30)] TArray<FGenericSelectCharacterTextureItem> Assets;
};

[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public unsafe struct UGenericSelectSystemBase //: public UObject
{
};

[StructLayout(LayoutKind.Sequential, Size = 0x60)]
public unsafe struct UUIGenericSelectCharacter //: public UObject
{
};

[StructLayout(LayoutKind.Explicit, Size = 0x370)]
public unsafe struct AUIGenericSelect //: public AUIBaseActor
{
    [FieldOffset(0x02F8)] public UGenericSelectSystemBase* System_;
    [FieldOffset(0x0300)] public UObject* pAssetLoader; // UAssetLoader*
    [FieldOffset(0x0308)] public AUIGenericSelectDraw* pDrawClass;
    [FieldOffset(0x0310)] public AUIGenericSelectDraw* pDrawActor;
    [FieldOffset(0x0318)] public UDataTable* LayoutData;
    [FieldOffset(0x0320)] public UUILayoutDataTable* LayoutDataTable;
};
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UUILayoutDataTable //: public UObject
{
    [FieldOffset(0x28)] public UDataTable* LayoutTable;
    [FieldOffset(0x30)] public TArray<nint> Entries; // TArray<UUILayoutDataTableEntry*>

    public UUILayoutDataTableEntry* GetLayoutDataTableEntry(int idx)
    {
        if (idx >= 0 && idx < Entries.arr_num) return (UUILayoutDataTableEntry*)Entries.allocator_instance[idx];
        return null;
    }
    /*
    public static UUILayoutDataTable* FromDataTable(UDataTable* table)
    {

    }
    */
};

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct UUILayoutDataTableEntry
{
    [FieldOffset(0x8)] public FVector2D position;
    [FieldOffset(0x10)] public float angle;
    [FieldOffset(0x14)] public float scale;
}

[StructLayout(LayoutKind.Explicit, Size = 0x490)]
public unsafe struct AUIMailIconDraw //: public AUIBaseActor
{
    [FieldOffset(0x2a8)] public USprAsset* Sprite_;
    [FieldOffset(0x2C8)] public float Field2C8;
    [FieldOffset(0x2CC)] public float Field2CC;
    [FieldOffset(0x2D0)] public float Field2D0;
    [FieldOffset(0x318)] public float Field318;
    [FieldOffset(0x368)] public float Field368;
    [FieldOffset(0x3b8)] public float Field3B8;
    [FieldOffset(0x408)] public float Field408;
    [FieldOffset(0x458)] public float Field458;
};

// CAMP MENU

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct UCmpMenuBase //: public UObject
{
    [FieldOffset(0x0030)] public ACmpMainActor* pMainActor;
};

[StructLayout(LayoutKind.Explicit, Size = 0x30F0)]
public unsafe struct ACmpMainActor //: public AAppActor
{
    [FieldOffset(0x0)] public AAppActor baseObj;
    [FieldOffset(0x288)] public int Field288;
    [FieldOffset(0x290)] public int MenuState;
    [FieldOffset(0x12C8)] public nint pAssetLoader;
    [FieldOffset(0x12D0)] public nint SceneCaptureClass;
    [FieldOffset(0x12D8)] public nint pSceneCapture2D;
    [FieldOffset(0x12E0)] public nint pCaptureMaterial;
    [FieldOffset(0x12E8)] public nint pCaptureInstanceDynamic;
    [FieldOffset(0x12F0)] public nint pOutlineMaterial;
    [FieldOffset(0x12F8)] public nint pOutlineInstanceDynamic;
    [FieldOffset(0x1300)] public nint pSimpleCopyMaterial;
    [FieldOffset(0x1308)] public nint pSimpleCopyMateDynamic;
    [FieldOffset(0x1310)] public nint pHologramMaterial;
    [FieldOffset(0x1318)] public nint pHologramMateDynamic;
    [FieldOffset(0x1320)] public UTexture2D* HologMaskTexAAry;
    [FieldOffset(0x1328)] public UTexture2D* HologMaskTexBAry;
    [FieldOffset(0x1330)] public UTexture2D* HologMaskTexCAry;
    [FieldOffset(0x1338)] public UTexture2D* HologMaskTexDAry;
    [FieldOffset(0x1340)] public nint pGlassMateDynamic;
    [FieldOffset(0x1348)] public nint pCaptureRenderTarget;
    [FieldOffset(0x1350)] public UTexture2D* HeroGaussMaskTexAry;
    [FieldOffset(0x13A8)] public UTexture2D* pOutAnimationTexture;
    [FieldOffset(0x13B0)] public USprAsset* pSprCommon;
    [FieldOffset(0x13B8)] public UUimAsset* pUimBgAry;
    [FieldOffset(0x13C8)] public UDataTable* pParamHologTable; // FCampParamTableHologRow
    [FieldOffset(0x13D0)] public UDataTable* pParamTopTable; // FCampParamTableTopRow
    [FieldOffset(0x13D8)] public UDataTable* pParamSkillTable; // FCampParamTableSkillRow
    [FieldOffset(0x13E0)] public UDataTable* pParamItemTable; // FCampParamTableItemRow
    [FieldOffset(0x13E8)] public UDataTable* pParamEquipTable; // FCampParamTableEquipRow
    [FieldOffset(0x13F0)] public UDataTable* pParamPersonaTable; // FCampParamTablePersonaRow
    [FieldOffset(0x13F8)] public UDataTable* pParamStatusTable; // FCampParamTableStatusRow
    [FieldOffset(0x1400)] public UDataTable* pParamRankUpTable; // FCampParamTableRankUpRow
    [FieldOffset(0x1408)] public UDataTable* pParamCommuTable; // FCampParamTableCommuRow
    [FieldOffset(0x1410)] public UDataTable* pParamSystemTable; // FCampParamTableSystemRow
    [FieldOffset(0x1418)] public UDataTable* pParamCommonTable; // FCampParamTableCommonRow
    [FieldOffset(0x1420)] public UDataTable* pCameraTable;
    [FieldOffset(0x1428)] public UDataTable* pHologramTable;
    [FieldOffset(0x1430)] public nint pMateWaveCaustics;
    [FieldOffset(0x1438)] public UDataTable* pParamLayoutDataRoot;
    [FieldOffset(0x1440)] public UDataTable* pParamLayoutDataSystem;
    [FieldOffset(0x1448)] public UDataTable* pParamTriangularCursorDataRoot;
    [FieldOffset(0x1450)] public UDataTable* pParamTriangularCursorDataSystem;
    [FieldOffset(0x1458)] public UDataTable* pParamLayoutDataQuest;
    [FieldOffset(0x1460)] public UDataTable* pParamLayoutDataQuestDate;
    [FieldOffset(0x1468)] public UDataTable* pParamLayoutPersonaList;
    [FieldOffset(0x1470)] public UDataTable* pParamLayoutDataItem;
    [FieldOffset(0x1478)] public UDataTable* pParamLayoutDataSkill;
    [FieldOffset(0x1480)] public UDataTable* pParamLayoutDataSkill2;
    [FieldOffset(0x1488)] public UDataTable* pParamLayoutDataOthers;
    [FieldOffset(0x1490)] public UDataTable* pParamLayoutDataHelpOthers;
    [FieldOffset(0x1498)] public UDataTable* pParamLayoutDataPartyPanel;
    [FieldOffset(0x14A0)] public UDataTable* pParamLayoutDataTutorialText;
    [FieldOffset(0x14A8)] public UDataTable* pParamLayoutDataDictionaryText;
    [FieldOffset(0x14B0)] public UDataTable* pParamLayoutDataCalendarText;
    [FieldOffset(0x14B8)] public UDataTable* pParamLayoutDataEquipTextCol;
    [FieldOffset(0x14C0)] public UDataTable* pParamLayoutDataItemTextCol;
    [FieldOffset(0x14C8)] public UDataTable* pParamLayoutDataQuestTextCol;
    [FieldOffset(0x14D0)] public UDataTable* pParamLayoutDataQuestTextPos;
    [FieldOffset(0x14D8)] public UDataTable* pParamLayoutDataCommuTextCol;
    [FieldOffset(0x14E0)] public UDataTable* pParamLayoutDataStatusTextCol;
    [FieldOffset(0x14E8)] public UDataTable* pParamLayoutDataOkNext;
    [FieldOffset(0x14F0)] public UDataTable* pParamLayoutDataOkNextMask;
    [FieldOffset(0x14F8)] public UDataTable* pParamLayoutDataRootTouchColl;
    [FieldOffset(0x1500)] public UDataTable* pParamLayoutDataSystemTouchColl;
    [FieldOffset(0x1508)] public UUimAsset* pUimNamiRootAAry;
    [FieldOffset(0x15F8)] public UUimAsset* pUimNamiRootBAry;
    [FieldOffset(0x16E8)] public UUimAsset* pUimNamiSkillAAry;
    [FieldOffset(0x17D8)] public UUimAsset* pUimNamiSkillBAry;
    [FieldOffset(0x18C8)] public UUimAsset* pUimNamiItemAAry;
    [FieldOffset(0x19B8)] public UUimAsset* pUimNamiItemBAry;
    [FieldOffset(0x1AA8)] public UUimAsset* pUimNamiEquipAAry;
    [FieldOffset(0x1B98)] public UUimAsset* pUimNamiEquipBAry;
    [FieldOffset(0x1C88)] public UUimAsset* pUimNamiPersonaAAry;
    [FieldOffset(0x1D78)] public UUimAsset* pUimNamiPersonaBAry;
    [FieldOffset(0x1E68)] public UUimAsset* pUimNamiStatusAAry;
    [FieldOffset(0x1F58)] public UUimAsset* pUimNamiStatusBAry;
    [FieldOffset(0x2048)] public UUimAsset* pUimNamiQuestAAry;
    [FieldOffset(0x2138)] public UUimAsset* pUimNamiQuestBAry;
    [FieldOffset(0x2228)] public UUimAsset* pUimNamiCommuAAry;
    [FieldOffset(0x2318)] public UUimAsset* pUimNamiCommuBAry;
    [FieldOffset(0x2408)] public UUimAsset* pUimNamiCalendarAAry;
    [FieldOffset(0x24F8)] public UUimAsset* pUimNamiCalendarBAry;
    [FieldOffset(0x25E8)] public UUimAsset* pUimNamiSystemAAry;
    [FieldOffset(0x26D8)] public UUimAsset* pUimNamiSystemBAry;
    [FieldOffset(0x27C8)] public UUimAsset* pUimNamiTutorialAAry;
    [FieldOffset(0x28B8)] public UUimAsset* pUimNamiTutorialBAry;
    [FieldOffset(0x29A8)] public UUimAsset* pUimNamiConfigAAry;
    [FieldOffset(0x2A98)] public UUimAsset* pUimNamiConfigBAry;
    [FieldOffset(0x2B88)] public UTexture2D* pCharaGlassAry;
    [FieldOffset(0x2BD8)] public UTexture2D* pCharaDetailAry;
    [FieldOffset(0x2C28)] public UTexture2D* pCharaDetailShdAry;
    [FieldOffset(0x2C98)] public TArray<nint> MenuList;
    [FieldOffset(0x2CB0)] public UCmpMenuBase* pCurrentMenu;
    [FieldOffset(0x2CB8)] public UCmpMenuBase* pNextMenu;
    [FieldOffset(0x2CC0)] public UCmpMenuBase* pPrevMenu;
    [FieldOffset(0x2CC8)] public nint pModelController;
    [FieldOffset(0x2CD0)] public nint pCmpMainLoadActor;
    [FieldOffset(0x2CE0)] public nint pHeroCharaClass;
    [FieldOffset(0x2CE8)] public nint pHeroAnimCtrl;
    [FieldOffset(0x2CF0)] public TArray<nint> MateInterAry;
    [FieldOffset(0x2D00)] public bool bIsDisableForceTermination;
    [FieldOffset(0x2D02)] public bool bEquipChange;
    [FieldOffset(0x2D03)] public bool bReturnCommuToField;
    [FieldOffset(0x2D08)] public nint pUIRequest;
    [FieldOffset(0x2D10)] public nint pUIMissingPerson;
    [FieldOffset(0x2D18)] public nint pUITheurgia;
    [FieldOffset(0x3028)] public UUILayoutDataTable* RootLayoutDataTable;
    [FieldOffset(0x3030)] public UUILayoutDataTable* SystemLayoutDataTable;
    [FieldOffset(0x3038)] public UUILayoutDataTable* QuestLayoutDataTable;
    [FieldOffset(0x3040)] public UUILayoutDataTable* QuestDateLayoutDataTable;
    [FieldOffset(0x3048)] public UUILayoutDataTable* OthersLayoutDataTable;
    [FieldOffset(0x3050)] public UUILayoutDataTable* HelpOthersLayoutDataTable;
    [FieldOffset(0x3058)] public UUILayoutDataTable* PersonaListLayoutDataTable;
    [FieldOffset(0x3060)] public UUILayoutDataTable* ItemLayoutDataTable;
    [FieldOffset(0x3068)] public UUILayoutDataTable* SkillLayoutDataTable;
    [FieldOffset(0x3070)] public UUILayoutDataTable* SkillLayoutDataTable2;
    [FieldOffset(0x3078)] public UUILayoutDataTable* PartyPanelLayoutDataTable;
    [FieldOffset(0x3080)] public UUILayoutDataTable* TutorialTextLayoutDataTable;
    [FieldOffset(0x3088)] public UUILayoutDataTable* DictionaryTextLayoutDataTable;
    [FieldOffset(0x3090)] public UUILayoutDataTable* CalendarTextLayoutDataTable;
    [FieldOffset(0x3098)] public UUILayoutDataTable* EquipTextColLayoutDataTable;
    [FieldOffset(0x30A0)] public UUILayoutDataTable* ItemTextColLayoutDataTable;
    [FieldOffset(0x30A8)] public UUILayoutDataTable* QuestTextColLayoutDataTable;
    [FieldOffset(0x30B0)] public UUILayoutDataTable* QuestTextPosLayoutDataTable;
    [FieldOffset(0x30B8)] public UUILayoutDataTable* CommuTextColLayoutDataTable;
    [FieldOffset(0x30C0)] public UUILayoutDataTable* StatusTextColLayoutDataTable;
    [FieldOffset(0x30C8)] public UUILayoutDataTable* OkNextLayoutDataTable;
    [FieldOffset(0x30D0)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
    [FieldOffset(0x30D8)] public UUILayoutDataTable* RootTouchCollLayoutDataTable;
    [FieldOffset(0x30E0)] public UUILayoutDataTable* SystemTouchCollLayoutDataTable;
};

public unsafe class CmpMainActor : ICmpMainActor
{
    private ACmpMainActor* Data;
    public CmpMainActor(ACmpMainActor* _Data) { Data = _Data; }
    private ACmpMainActor* Self() => Data;
    public int GetField288() => Self()->Field288;
    public int GetMenuState() => Self()->MenuState;
    public UAssetLoader* GetAssetLoader() => (UAssetLoader*)Self()->pAssetLoader;
    public unsafe UMaterialInstance* GetCaptureMaterial() => (UMaterialInstance*)Self()->pCaptureMaterial;
    public unsafe UMaterialInstanceDynamic* GetCaptureInstanceDynamic() => (UMaterialInstanceDynamic*)Self()->pCaptureInstanceDynamic;
    public unsafe UMaterialInstance* GetOutlineMaterial() => (UMaterialInstance*)Self()->pOutlineMaterial;
    public unsafe UMaterialInstanceDynamic* GetOutlineInstanceDynamic() => (UMaterialInstanceDynamic*)Self()->pOutlineInstanceDynamic;
    public unsafe UMaterial* GetSimpleCopyMaterial() => (UMaterial*)Self()->pSimpleCopyMaterial;
    public unsafe UMaterialInstanceDynamic* GetSimpleCopyMateDynamic() => (UMaterialInstanceDynamic*)Self()->pSimpleCopyMateDynamic;
    public unsafe UMaterial* GetHologramMaterial() => (UMaterial*)Self()->pHologramMaterial;
    public unsafe UMaterialInstanceDynamic* GetHologramMateDynamic() => (UMaterialInstanceDynamic*)Self()->pHologramMateDynamic;
    public unsafe UTexture2D* GetHologMaskTexAAry() => Self()->HologMaskTexAAry;
    public unsafe UTexture2D* GetHologMaskTexBAry() => Self()->HologMaskTexBAry;
    public unsafe UTexture2D* GetHologMaskTexCAry() => Self()->HologMaskTexCAry;
    public unsafe UTexture2D* GetHologMaskTexDAry() => Self()->HologMaskTexDAry;
    public unsafe UMaterialInstanceDynamic* GetGlassMateDynamic() => (UMaterialInstanceDynamic*)Self()->pHologramMateDynamic;
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

public interface ICmpMainActor
{
    public int GetField288();
    public int GetMenuState();
    public unsafe UAssetLoader* GetAssetLoader();
    public unsafe UMaterialInstance* GetCaptureMaterial();
    public unsafe UMaterialInstanceDynamic* GetCaptureInstanceDynamic();
    public unsafe UMaterialInstance* GetOutlineMaterial();
    public unsafe UMaterialInstanceDynamic* GetOutlineInstanceDynamic();
    public unsafe UMaterial* GetSimpleCopyMaterial();
    public unsafe UMaterialInstanceDynamic* GetSimpleCopyMateDynamic();
    public unsafe UMaterial* GetHologramMaterial();
    public unsafe UMaterialInstanceDynamic* GetHologramMateDynamic();
    public unsafe UTexture2D* GetHologMaskTexAAry();
    public unsafe UTexture2D* GetHologMaskTexBAry();
    public unsafe UTexture2D* GetHologMaskTexCAry();
    public unsafe UTexture2D* GetHologMaskTexDAry();
    public unsafe UCmpMenuBase* GetCurrentMenu();
    public unsafe UCmpMenuBase* GetNextMenu();
    public unsafe UCmpMenuBase* GetPrevMenu();
    public unsafe UMaterialInstanceDynamic* GetGlassMateDynamic();
    public unsafe UUILayoutDataTable* GetRootLayoutDataTable();
    public unsafe UUILayoutDataTable* GetSystemLayoutDataTable();
    public unsafe UUILayoutDataTable* GetQuestLayoutDataTable();
    public unsafe UUILayoutDataTable* GetQuestDateLayoutDataTable();
    public unsafe UUILayoutDataTable* GetOthersLayoutDataTable();
    public unsafe UUILayoutDataTable* GetHelpOthersLayoutDataTable();
    public unsafe UUILayoutDataTable* GetPersonaListLayoutDataTable();
    public unsafe UUILayoutDataTable* GetItemLayoutDataTable();
    public unsafe UUILayoutDataTable* GetSkillLayoutDataTable();
    public unsafe UUILayoutDataTable* GetSkillLayoutDataTable2();
    public unsafe UUILayoutDataTable* GetPartyPanelLayoutDataTable();
    public unsafe UUILayoutDataTable* GetTutorialTextLayoutDataTable();
    public unsafe UUILayoutDataTable* GetDictionaryTextLayoutDataTable();
    public unsafe UUILayoutDataTable* GetCalendarTextLayoutDataTable();
    public unsafe UUILayoutDataTable* GetEquipTextColLayoutDataTable();
    public unsafe UUILayoutDataTable* GetItemTextColLayoutDataTable();
    public unsafe UUILayoutDataTable* GetQuestTextColLayoutDataTable();
    public unsafe UUILayoutDataTable* GetQuestTextPosLayoutDataTable();
    public unsafe UUILayoutDataTable* GetCommuTextColLayoutDataTable();
    public unsafe UUILayoutDataTable* GetStatusTextColLayoutDataTable();
    public unsafe UUILayoutDataTable* GetOkNextLayoutDataTable();
    public unsafe UUILayoutDataTable* GetOkNextMaskLayoutDataTable();
    public unsafe UUILayoutDataTable* GetRootTouchCollLayoutDataTable();
    public unsafe UUILayoutDataTable* GetSystemTouchCollLayoutDataTable();

}

public enum EOneAnimType : byte
{
    Linear = 0,
    Sin90 = 1,
    Sin180 = 2,
    Sin360 = 3,
    HSin180 = 4,
    EaseInOut = 5,
    EaseOut1 = 6,
    EaseOut2 = 7,
    EaseOut3 = 8,
    CurveUp1 = 9,
    CurveUp2 = 10,
    CurveUp3 = 11,
    CurveDown1 = 12,
    CurveDown2 = 13,
    CurveDown3 = 14,
    Haneru1 = 15,
    Haneru1ST1 = 16,
    Haneru2 = 17,
    Haneru3 = 18,
    Fuwari1 = 19,
    Bowa1 = 20,
    Gachan2 = 21,
    KaesiSlide2 = 22,
    ButtonPush = 23,
    YureruRot = 24,
    Max = 25,
};

public enum EUIGaussType : byte
{
    VeryWeak1 = 0,
    Weak2 = 1,
    Normal3 = 2,
    Strong4 = 3,
    VeryStrong5 = 4,
    MostWeak0 = 5,
    Off = 6,
    EUIGaussType_MAX = 7,
};

[StructLayout(LayoutKind.Explicit, Size = 0x4D8)]
public unsafe struct FCampParamTableCommonRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public EOneAnimType ListAllSlideAnimType;
    [FieldOffset(0x000C)] public uint ListAllSlideFrame;
    [FieldOffset(0x0010)] public uint ListAllSlideBackFrame;
    [FieldOffset(0x0014)] public EOneAnimType Edit_List_Cursor_Anim_Type;
    [FieldOffset(0x0018)] public uint Edit_List_Cursor_Slide_Frame;
    [FieldOffset(0x001C)] public EOneAnimType Edit_List_Party_RedCursor_Anim_Type;
    [FieldOffset(0x0020)] public uint Edit_List_Party_RedCursor_Slide_Frame;
    [FieldOffset(0x0024)] public EOneAnimType Edit_List_Commu_RedCursor_Anim_Type;
    [FieldOffset(0x0028)] public uint Edit_List_Commu_RedCursor_Slide_Frame;
    [FieldOffset(0x002C)] public EOneAnimType ListRedSlideAnimType;
    [FieldOffset(0x0030)] public uint ListRedSlideFrame;
    [FieldOffset(0x0034)] public uint ListRedSlideWait;
    [FieldOffset(0x0038)] public uint ListRedSlideBackFrame;
    [FieldOffset(0x003C)] public uint HPSPFlashFrame;
    [FieldOffset(0x0040)] public EOneAnimType TabShakeAnimType;
    [FieldOffset(0x0044)] public uint TabShakeFrame;
    [FieldOffset(0x0048)] public EOneAnimType TabLoopAnimType;
    [FieldOffset(0x004C)] public uint TabLoopFrame;
    [FieldOffset(0x0050)] public EOneAnimType CampOKScaleAnimType;
    [FieldOffset(0x0054)] public uint CampOKScaleFrame;
    [FieldOffset(0x0058)] public uint CampOKScaleWait;
    [FieldOffset(0x005C)] public float CampOKEndScale;
    [FieldOffset(0x0060)] public EOneAnimType CampOKInScaleAnimType;
    [FieldOffset(0x0064)] public uint CampOKInScaleFrame;
    [FieldOffset(0x0068)] public uint CampOKInScaleWait;
    [FieldOffset(0x006C)] public float CampOKInEndScale;
    [FieldOffset(0x0070)] public float CampOKCaptureScale;
    [FieldOffset(0x0074)] public EOneAnimType PartyPanelInFlagSlideAnimType;
    [FieldOffset(0x0078)] public uint PartyPanelInFlagSlideFrame;
    [FieldOffset(0x007C)] public uint PartyPanelInFlagSlideBackFrame;
    [FieldOffset(0x0080)] public EOneAnimType WipeChangeMaskAAnimType;
    [FieldOffset(0x0084)] public uint WipeChangeMaskAFrame;
    [FieldOffset(0x0088)] public EOneAnimType WipeChangeMaskBAnimType;
    [FieldOffset(0x008C)] public uint WipeChangeMaskBFrame;
    [FieldOffset(0x0090)] public uint WipeChangeMaskBWait;
    [FieldOffset(0x0094)] public float WipeChangeCaptureScale;
    [FieldOffset(0x0098)] public uint WipeCloseMaskAFrame;
    [FieldOffset(0x009C)] public uint WipeCloseMaskBWait;
    [FieldOffset(0x00A0)] public EOneAnimType SuitekiAnimType;
    [FieldOffset(0x00A4)] public uint SuitekiFrame;
    [FieldOffset(0x00A8)] public byte HighpassBrightThreshold;
    [FieldOffset(0x00AC)] public float HighpassBrightScale;
    [FieldOffset(0x00B0)] public FColor AoItaColorHigh;
    [FieldOffset(0x00B4)] public FColor AoItaColorMid;
    [FieldOffset(0x00B8)] public FColor AoItaColorLow;
    [FieldOffset(0x00BC)] public FColor GradAUpColorHigh;
    [FieldOffset(0x00C0)] public FColor GradADownColorHigh;
    [FieldOffset(0x00C4)] public FColor GradBUpColorHigh;
    [FieldOffset(0x00C8)] public FColor GradBDownColorHigh;
    [FieldOffset(0x00CC)] public FColor GradAUpColorMid;
    [FieldOffset(0x00D0)] public FColor GradADownColorMid;
    [FieldOffset(0x00D4)] public FColor GradBUpColorMid;
    [FieldOffset(0x00D8)] public FColor GradBDownColorMid;
    [FieldOffset(0x00DC)] public FColor GradAUpColorLow;
    [FieldOffset(0x00E0)] public FColor GradADownColorLow;
    [FieldOffset(0x00E4)] public FColor GradBUpColorLow;
    [FieldOffset(0x00E8)] public FColor GradBDownColorLow;
    [FieldOffset(0x00EC)] public FColor HeroCaptureBgColor;
    [FieldOffset(0x00F0)] public EUIGaussType HeroGaussType;
    [FieldOffset(0x00F1)] public byte HeroGaussHorizontal;
    [FieldOffset(0x00F2)] public byte HeroGaussVertical;
    [FieldOffset(0x00F4)] public float HeroGaussScale;
    [FieldOffset(0x00F8)] public float HeroBlurPrev1Offset;
    [FieldOffset(0x00FC)] public byte HeroBlurPrev1Alpha;
    [FieldOffset(0x0100)] public float HeroBlurPrev2Offset;
    [FieldOffset(0x0104)] public byte HeroBlurPrev2Alpha;
    [FieldOffset(0x0108)] public uint NamiOneFrame;
    [FieldOffset(0x010C)] public float NamiAlpha;
    [FieldOffset(0x0110)] public EUIGaussType NamiGaussType;
    [FieldOffset(0x0114)] public FVector2D NamiTopAOfsPos;
    [FieldOffset(0x011C)] public FVector2D NamiTopAScale;
    [FieldOffset(0x0124)] public FColor NamiTopAColor;
    [FieldOffset(0x0128)] public bool NamiTopAAddBlend;
    [FieldOffset(0x012C)] public FVector2D NamiTopBOfsPos;
    [FieldOffset(0x0134)] public FVector2D NamiTopBScale;
    [FieldOffset(0x013C)] public FColor NamiTopBColor;
    [FieldOffset(0x0140)] public bool NamiTopBAddBlend;
    [FieldOffset(0x0144)] public FVector2D NamiSkillAOfsPos;
    [FieldOffset(0x014C)] public FVector2D NamiSkillAScale;
    [FieldOffset(0x0154)] public FColor NamiSkillAColor;
    [FieldOffset(0x0158)] public bool NamiSkillAAddBlend;
    [FieldOffset(0x015C)] public FVector2D NamiSkillBOfsPos;
    [FieldOffset(0x0164)] public FVector2D NamiSkillBScale;
    [FieldOffset(0x016C)] public FColor NamiSkillBColor;
    [FieldOffset(0x0170)] public bool NamiSkillBAddBlend;
    [FieldOffset(0x0174)] public FVector2D NamiItemAOfsPos;
    [FieldOffset(0x017C)] public FVector2D NamiItemAScale;
    [FieldOffset(0x0184)] public FColor NamiItemAColor;
    [FieldOffset(0x0188)] public bool NamiItemAAddBlend;
    [FieldOffset(0x018C)] public FVector2D NamiItemBOfsPos;
    [FieldOffset(0x0194)] public FVector2D NamiItemBScale;
    [FieldOffset(0x019C)] public FColor NamiItemBColor;
    [FieldOffset(0x01A0)] public bool NamiItemBAddBlend;
    [FieldOffset(0x01A4)] public FVector2D NamiEquipAOfsPos;
    [FieldOffset(0x01AC)] public FVector2D NamiEquipAScale;
    [FieldOffset(0x01B4)] public FColor NamiEquipAColor;
    [FieldOffset(0x01B8)] public bool NamiEquipAAddBlend;
    [FieldOffset(0x01BC)] public FVector2D NamiEquipBOfsPos;
    [FieldOffset(0x01C4)] public FVector2D NamiEquipBScale;
    [FieldOffset(0x01CC)] public FColor NamiEquipBColor;
    [FieldOffset(0x01D0)] public bool NamiEquipBAddBlend;
    [FieldOffset(0x01D4)] public FVector2D NamiPersonaAOfsPos;
    [FieldOffset(0x01DC)] public FVector2D NamiPersonaAScale;
    [FieldOffset(0x01E4)] public FColor NamiPersonaAColor;
    [FieldOffset(0x01E8)] public bool NamiPersonaAAddBlend;
    [FieldOffset(0x01EC)] public FVector2D NamiPersonaBOfsPos;
    [FieldOffset(0x01F4)] public FVector2D NamiPersonaBScale;
    [FieldOffset(0x01FC)] public FColor NamiPersonaBColor;
    [FieldOffset(0x0200)] public bool NamiPersonaBAddBlend;
    [FieldOffset(0x0204)] public FVector2D NamiStatusAOfsPos;
    [FieldOffset(0x020C)] public FVector2D NamiStatusAScale;
    [FieldOffset(0x0214)] public FColor NamiStatusAColor;
    [FieldOffset(0x0218)] public bool NamiStatusAAddBlend;
    [FieldOffset(0x021C)] public FVector2D NamiStatusBOfsPos;
    [FieldOffset(0x0224)] public FVector2D NamiStatusBScale;
    [FieldOffset(0x022C)] public FColor NamiStatusBColor;
    [FieldOffset(0x0230)] public bool NamiStatusBAddBlend;
    [FieldOffset(0x0234)] public FVector2D NamiQuestAOfsPos;
    [FieldOffset(0x023C)] public FVector2D NamiQuestAScale;
    [FieldOffset(0x0244)] public FColor NamiQuestAColor;
    [FieldOffset(0x0248)] public bool NamiQuestAAddBlend;
    [FieldOffset(0x024C)] public FVector2D NamiQuestBOfsPos;
    [FieldOffset(0x0254)] public FVector2D NamiQuestBScale;
    [FieldOffset(0x025C)] public FColor NamiQuestBColor;
    [FieldOffset(0x0260)] public bool NamiQuestBAddBlend;
    [FieldOffset(0x0264)] public FVector2D NamiCommuAOfsPos;
    [FieldOffset(0x026C)] public FVector2D NamiCommuAScale;
    [FieldOffset(0x0274)] public FColor NamiCommuAColor;
    [FieldOffset(0x0278)] public bool NamiCommuAAddBlend;
    [FieldOffset(0x027C)] public FVector2D NamiCommuBOfsPos;
    [FieldOffset(0x0284)] public FVector2D NamiCommuBScale;
    [FieldOffset(0x028C)] public FColor NamiCommuBColor;
    [FieldOffset(0x0290)] public bool NamiCommuBAddBlend;
    [FieldOffset(0x0294)] public FVector2D NamiCalendarAOfsPos;
    [FieldOffset(0x029C)] public FVector2D NamiCalendarAScale;
    [FieldOffset(0x02A4)] public FColor NamiCalendarAColor;
    [FieldOffset(0x02A8)] public bool NamiCalendarAAddBlend;
    [FieldOffset(0x02AC)] public FVector2D NamiCalendarBOfsPos;
    [FieldOffset(0x02B4)] public FVector2D NamiCalendarBScale;
    [FieldOffset(0x02BC)] public FColor NamiCalendarBColor;
    [FieldOffset(0x02C0)] public bool NamiCalendarBAddBlend;
    [FieldOffset(0x02C4)] public FVector2D NamiSystemAOfsPos;
    [FieldOffset(0x02CC)] public FVector2D NamiSystemAScale;
    [FieldOffset(0x02D4)] public FColor NamiSystemAColor;
    [FieldOffset(0x02D8)] public bool NamiSystemAAddBlend;
    [FieldOffset(0x02DC)] public FVector2D NamiSystemBOfsPos;
    [FieldOffset(0x02E4)] public FVector2D NamiSystemBScale;
    [FieldOffset(0x02EC)] public FColor NamiSystemBColor;
    [FieldOffset(0x02F0)] public bool NamiSystemBAddBlend;
    [FieldOffset(0x02F4)] public FVector2D NamiTutorialAOfsPos;
    [FieldOffset(0x02FC)] public FVector2D NamiTutorialAScale;
    [FieldOffset(0x0304)] public FColor NamiTutorialAColor;
    [FieldOffset(0x0308)] public bool NamiTutorialAAddBlend;
    [FieldOffset(0x030C)] public FVector2D NamiTutorialBOfsPos;
    [FieldOffset(0x0314)] public FVector2D NamiTutorialBScale;
    [FieldOffset(0x031C)] public FColor NamiTutorialBColor;
    [FieldOffset(0x0320)] public bool NamiTutorialBAddBlend;
    [FieldOffset(0x0324)] public FVector2D NamiConfigAOfsPos;
    [FieldOffset(0x032C)] public FVector2D NamiConfigAScale;
    [FieldOffset(0x0334)] public FColor NamiConfigAColor;
    [FieldOffset(0x0338)] public bool NamiConfigAAddBlend;
    [FieldOffset(0x033C)] public FVector2D NamiConfigBOfsPos;
    [FieldOffset(0x0344)] public FVector2D NamiConfigBScale;
    [FieldOffset(0x034C)] public FColor NamiConfigBColor;
    [FieldOffset(0x0350)] public bool NamiConfigBAddBlend;
    [FieldOffset(0x0354)] public FColor LightVecOfsTop;
    [FieldOffset(0x0364)] public FColor LightVecOfsSkill;
    [FieldOffset(0x0374)] public FColor LightVecOfsItem;
    [FieldOffset(0x0384)] public FColor LightVecOfsEquip;
    [FieldOffset(0x0394)] public FColor LightVecOfsPersona;
    [FieldOffset(0x03A4)] public FColor LightVecOfsStatus;
    [FieldOffset(0x03B4)] public FColor LightVecOfsQuest;
    [FieldOffset(0x03C4)] public FColor LightVecOfsCommu;
    [FieldOffset(0x03D4)] public FColor LightVecOfsCalender;
    [FieldOffset(0x03E4)] public FColor LightVecOfsSystem;
    [FieldOffset(0x03F4)] public uint Edit_Key_Lock_Frame;
    [FieldOffset(0x03F8)] public float Edit_GuideLine_X;
    [FieldOffset(0x03FC)] public uint Edit_StatusKeyLockFrame;
    [FieldOffset(0x0400)] public FColor Edit_Root_FillColor;
    [FieldOffset(0x0410)] public float Edit_Root_Near;
    [FieldOffset(0x0414)] public float Edit_Root_Far;
    [FieldOffset(0x0418)] public FColor Edit_Skill_FillColor;
    [FieldOffset(0x0428)] public float Edit_Skill_Near;
    [FieldOffset(0x042C)] public float Edit_Skill_Far;
    [FieldOffset(0x0430)] public FColor Edit_Item_FillColor;
    [FieldOffset(0x0440)] public float Edit_Item_Near;
    [FieldOffset(0x0444)] public float Edit_Item_Far;
    [FieldOffset(0x0448)] public FColor Edit_Equip_FillColor;
    [FieldOffset(0x0458)] public float Edit_Equip_Near;
    [FieldOffset(0x045C)] public float Edit_Equip_Far;
    [FieldOffset(0x0460)] public FColor Edit_Status_FillColor;
    [FieldOffset(0x0470)] public float Edit_Status_Near;
    [FieldOffset(0x0474)] public float Edit_Status_Far;
    [FieldOffset(0x0478)] public FColor Edit_Quest_FillColor;
    [FieldOffset(0x0488)] public float Edit_Quest_Near;
    [FieldOffset(0x048C)] public float Edit_Quest_Far;
    [FieldOffset(0x0490)] public FColor Edit_Commu_FillColor;
    [FieldOffset(0x04A0)] public float Edit_Commu_Near;
    [FieldOffset(0x04A4)] public float Edit_Commu_Far;
    [FieldOffset(0x04A8)] public FColor Edit_System_FillColor;
    [FieldOffset(0x04B8)] public float Edit_System_Near;
    [FieldOffset(0x04BC)] public float Edit_System_Far;
    [FieldOffset(0x04C0)] public FColor Edit_Config_FillColor;
    [FieldOffset(0x04D0)] public float Edit_Config_Near;
    [FieldOffset(0x04D4)] public float Edit_Config_Far;
};

[StructLayout(LayoutKind.Explicit, Size = 0xa0)]
public unsafe struct FCampParamTableCommuRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public EOneAnimType CommListInSilhouetteAnimType;
    [FieldOffset(0x000C)] public uint CommListInSilhouetteFrame;
    [FieldOffset(0x0010)] public uint CommListInSilhouetteWait;
    [FieldOffset(0x0014)] public EOneAnimType CommListInSiroItaAnimType;
    [FieldOffset(0x0018)] public uint CommListInSiroItaFrame;
    [FieldOffset(0x001C)] public uint CommListInSiroItaWait;
    [FieldOffset(0x0020)] public uint CommListOutSiroItaFrame;
    [FieldOffset(0x0024)] public EOneAnimType CommListInListAnimType;
    [FieldOffset(0x0028)] public uint CommListInListFrame;
    [FieldOffset(0x002C)] public uint CommListInListWait;
    [FieldOffset(0x0030)] public uint CommListOutListFrame;
    [FieldOffset(0x0034)] public EOneAnimType CommDetlInDetailAnimType;
    [FieldOffset(0x0038)] public uint CommDetlInDetailFrame;
    [FieldOffset(0x003C)] public uint CommDetlInDetailWait;
    [FieldOffset(0x0040)] public uint CommDetlOutDetailFrame;
    [FieldOffset(0x0044)] public EOneAnimType CommDetlInDescriAnimType;
    [FieldOffset(0x0048)] public uint CommDetlInDescriFrame;
    [FieldOffset(0x004C)] public uint CommDetlInDescriWait;
    [FieldOffset(0x0050)] public EOneAnimType CommDetlInMemberAnimType;
    [FieldOffset(0x0054)] public uint CommDetlInMemberFrame;
    [FieldOffset(0x0058)] public uint CommDetlInMemberWait;
    [FieldOffset(0x005C)] public EOneAnimType CommDetlInBustupAnimType;
    [FieldOffset(0x0060)] public uint CommDetlInBustupFrame;
    [FieldOffset(0x0064)] public uint CommDetlInBustupWait;
    [FieldOffset(0x0068)] public uint CommDetlBustupChangeFrame;
    [FieldOffset(0x006C)] public EOneAnimType CommuCardAnimType;
    [FieldOffset(0x0070)] public uint CommuCardFrameMin;
    [FieldOffset(0x0074)] public uint CommuCardFrameMax;
    [FieldOffset(0x0078)] public uint CommuCardWaitMin;
    [FieldOffset(0x007C)] public uint CommuCardWaitMax;
    [FieldOffset(0x0080)] public float CommuCardScaleMin;
    [FieldOffset(0x0084)] public float CommuCardScaleMax;
    [FieldOffset(0x0088)] public float CommuCardXAccMin;
    [FieldOffset(0x008C)] public float CommuCardXAccMax;
    [FieldOffset(0x0090)] public float CommuCardRotAxis1Min;
    [FieldOffset(0x0094)] public float CommuCardRotAxis1Max;
    [FieldOffset(0x0098)] public float CommuCardRotAxis2Min;
    [FieldOffset(0x009C)] public float CommuCardRotAxis2Max;
};

[StructLayout(LayoutKind.Explicit, Size = 0x170)]
public unsafe struct FCampParamTableEquipRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public EOneAnimType CategoChangeOutAnimType;
    [FieldOffset(0x000C)] public uint CategoChangeOutFrame;
    [FieldOffset(0x0010)] public EOneAnimType CategoChangeInAnimType;
    [FieldOffset(0x0014)] public uint CategoChangeInFrame;
    [FieldOffset(0x0018)] public EOneAnimType EquipListChangeOutAnimType;
    [FieldOffset(0x001C)] public uint EquipListChangeOutFrame;
    [FieldOffset(0x0020)] public EOneAnimType EquipListChangeInAnimType;
    [FieldOffset(0x0024)] public uint EquipListChangeInFrame;
    [FieldOffset(0x0028)] public EOneAnimType EquipListEquipChangeOutAnimType;
    [FieldOffset(0x002C)] public uint EquipListEquipChangeOutFrame;
    [FieldOffset(0x0030)] public EOneAnimType EquipListEquipChangeInAnimType;
    [FieldOffset(0x0034)] public uint EquipListEquipChangeInFrame;
    [FieldOffset(0x0038)] public uint EquipListParamArrowSelectFrame;
    [FieldOffset(0x003C)] public uint EquipListParamArrowLoopFrame;
    [FieldOffset(0x0040)] public uint EquipCompChangeInInfoWait;
    [FieldOffset(0x0044)] public float EquipInPartyPanelDist;
    [FieldOffset(0x0048)] public EOneAnimType EquipInSilhouetteAnimType;
    [FieldOffset(0x004C)] public uint EquipInSilhouetteFrame;
    [FieldOffset(0x0050)] public uint EquipInSilhouetteWait;
    [FieldOffset(0x0054)] public EOneAnimType EquipInSiroItaAnimType;
    [FieldOffset(0x0058)] public uint EquipInSiroItaFrame;
    [FieldOffset(0x005C)] public uint EquipInSiroItaWait;
    [FieldOffset(0x0060)] public EOneAnimType EquipInAoItaAnimType;
    [FieldOffset(0x0064)] public uint EquipInAoItaFrame;
    [FieldOffset(0x0068)] public uint EquipInAoItaWait;
    [FieldOffset(0x006C)] public EOneAnimType EquipInTitleAnimType;
    [FieldOffset(0x0070)] public uint EquipInTitleFrame;
    [FieldOffset(0x0074)] public uint EquipInTitleWait;
    [FieldOffset(0x0078)] public EOneAnimType EquipInBgPlusAnimType;
    [FieldOffset(0x007C)] public uint EquipInBgPlusFrame;
    [FieldOffset(0x0080)] public uint EquipInBgPlusWait;
    [FieldOffset(0x0084)] public float EquipInCharaEquipDist;
    [FieldOffset(0x0088)] public EOneAnimType EquipInCharaEquipSlideAnimType;
    [FieldOffset(0x008C)] public uint EquipInCharaEquipSlideFrame;
    [FieldOffset(0x0090)] public uint EquipInCharaEquipSlideWait;
    [FieldOffset(0x0094)] public uint EquipInCharaEquipSlideInterval;
    [FieldOffset(0x0098)] public uint EquipInCharaEquipFadeFrame;
    [FieldOffset(0x009C)] public uint EquipInPartyPanelWait;
    [FieldOffset(0x00A0)] public uint ToCateCharaEquipFadeFrame;
    [FieldOffset(0x00A4)] public EOneAnimType ToCateSiroItaAnimType;
    [FieldOffset(0x00A8)] public uint ToCateSiroItaFrame;
    [FieldOffset(0x00AC)] public uint ToCateSiroItaWait;
    [FieldOffset(0x00B0)] public EOneAnimType CategoInSelPartySlideAnimType;
    [FieldOffset(0x00B4)] public uint CategoInSelPartySlideFrame;
    [FieldOffset(0x00B8)] public uint CategoInSelPartyFadeFrame;
    [FieldOffset(0x00BC)] public EOneAnimType CategoInBgPlusAnimType;
    [FieldOffset(0x00C0)] public uint CategoInBgPlusFrame;
    [FieldOffset(0x00C4)] public uint CategoInBgPlusWait;
    [FieldOffset(0x00C8)] public EOneAnimType CategoInTabSlideAnimType;
    [FieldOffset(0x00CC)] public uint CategoInTabSlideFrame;
    [FieldOffset(0x00D0)] public float CategoInCategoryDist;
    [FieldOffset(0x00D4)] public EOneAnimType CategoInCategorySlideAnimType;
    [FieldOffset(0x00D8)] public uint CategoInCategorySlideFrame;
    [FieldOffset(0x00DC)] public uint CategoInCategorySlideInterval;
    [FieldOffset(0x00E0)] public uint CategoInCategoryFadeFrame;
    [FieldOffset(0x00E4)] public EOneAnimType BackCateSelPartyOutAnimType;
    [FieldOffset(0x00E8)] public uint BackCateSelPartyOutFrame;
    [FieldOffset(0x00EC)] public EOneAnimType BackCateSiroItaAnimType;
    [FieldOffset(0x00F0)] public uint BackCateSiroItaFrame;
    [FieldOffset(0x00F4)] public uint ToListCharaEquipOutFrame;
    [FieldOffset(0x00F8)] public EOneAnimType ToListSiroItaAnimType;
    [FieldOffset(0x00FC)] public uint ToListSiroItaFrame;
    [FieldOffset(0x0100)] public EOneAnimType ListInPartyExBgSlideAnimType;
    [FieldOffset(0x0104)] public uint ListInPartyExBgSlideFrame;
    [FieldOffset(0x0108)] public uint ListInPartyExInfoFadeFrame;
    [FieldOffset(0x010C)] public float ListInEquipListDist;
    [FieldOffset(0x0110)] public EOneAnimType ListInEquipListSlideAnimType;
    [FieldOffset(0x0114)] public uint ListInEquipListSlideFrame;
    [FieldOffset(0x0118)] public uint ListInEquipListSlideWait;
    [FieldOffset(0x011C)] public uint ListInEquipListFadeFrame;
    [FieldOffset(0x0120)] public uint BackEquipListOutFrame;
    [FieldOffset(0x0124)] public EOneAnimType ToCompBg1ScaleAnimType;
    [FieldOffset(0x0128)] public uint ToCompBg1ScaleFrame;
    [FieldOffset(0x012C)] public uint ToCompBg1ScaleWait;
    [FieldOffset(0x0130)] public uint ToCompBg2ScaleFrame;
    [FieldOffset(0x0134)] public uint ToCompBg2ScaleWait;
    [FieldOffset(0x0138)] public EOneAnimType CompInSelectListSlideAnimType;
    [FieldOffset(0x013C)] public uint CompInSelectListSlideFrame;
    [FieldOffset(0x0140)] public uint CompInSelectListSlideWait;
    [FieldOffset(0x0144)] public EOneAnimType CompInScrollBarSlideAnimType;
    [FieldOffset(0x0148)] public uint CompInScrollBarSlideFrame;
    [FieldOffset(0x014C)] public EOneAnimType CompInArrowSlideAnimType;
    [FieldOffset(0x0150)] public uint CompInArrowSlideFrame;
    [FieldOffset(0x0154)] public EOneAnimType CompInDetailSlideAnimType;
    [FieldOffset(0x0158)] public uint CompInDetailSlideFrame;
    [FieldOffset(0x015C)] public uint BackEquipCompOutFrame;
    [FieldOffset(0x0160)] public EOneAnimType BackCompBgScaleAnimType;
    [FieldOffset(0x0164)] public uint BackCompBgScaleFrame;
    [FieldOffset(0x0168)] public uint BackCompBgScaleWait;
};

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FCampParamTableHologRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public EOneAnimType HologAnimType;
    [FieldOffset(0x000C)] public uint HologTransFrame;
    [FieldOffset(0x0010)] public uint HologTransWait;
    [FieldOffset(0x0014)] public uint HologColorWait;
};
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct FCampParamTableItemRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public float ItemInDist;
    [FieldOffset(0x000C)] public EOneAnimType ItemSilhouetteAnimType;
    [FieldOffset(0x0010)] public uint ItemSilhouetteFrame;
    [FieldOffset(0x0014)] public uint ItemSilhouetteWait;
    [FieldOffset(0x0018)] public EOneAnimType ItemSiroItaAnimType;
    [FieldOffset(0x001C)] public uint ItemSiroItaFrame;
    [FieldOffset(0x0020)] public uint ItemSiroItaWait;
    [FieldOffset(0x0024)] public EOneAnimType ItemTitleAnimType;
    [FieldOffset(0x0028)] public uint ItemTitleFrame;
    [FieldOffset(0x002C)] public uint ItemTitleWait;
    [FieldOffset(0x0030)] public EOneAnimType ItemListAnimType;
    [FieldOffset(0x0034)] public uint ItemListFrame;
    [FieldOffset(0x0038)] public uint ItemListWait;
    [FieldOffset(0x003C)] public EOneAnimType ItemTabAnimType;
    [FieldOffset(0x0040)] public uint ItemTabFrame;
    [FieldOffset(0x0044)] public uint ItemTabWait;
};
[StructLayout(LayoutKind.Explicit, Size = 0xa8)]
public unsafe struct FCampParamTablePersonaRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] EOneAnimType PersonaEquipScaleAnimType;
    [FieldOffset(0x000C)] uint PersonaEquipScaleFrame;
    [FieldOffset(0x0010)] uint PersonaEquipScaleWait;
    [FieldOffset(0x0014)] EOneAnimType PersonaEquipRotAnimType;
    [FieldOffset(0x0018)] uint PersonaEquipRotFrame;
    [FieldOffset(0x001C)] uint PersonaEquipRotWait;
    [FieldOffset(0x0020)] EOneAnimType PersonaEquipSlideAnimType;
    [FieldOffset(0x0024)] uint PersonaEquipSlideFrame;
    [FieldOffset(0x0028)] uint PersonaEquipSlideWait;
    [FieldOffset(0x002C)] float PersonaLightSpeed;
    [FieldOffset(0x0030)] float PersonaWaveSpeed;
    [FieldOffset(0x0034)] EOneAnimType PersonaArcanaFadeAnimType;
    [FieldOffset(0x0038)] uint PersonaArcanaFadeFrame;
    [FieldOffset(0x003C)] float PersonaInDist;
    [FieldOffset(0x0040)] EOneAnimType PersonaInSilhouetteAnimType;
    [FieldOffset(0x0044)] uint PersonaInSilhouetteFrame;
    [FieldOffset(0x0048)] uint PersonaInSilhouetteWait;
    [FieldOffset(0x004C)] EOneAnimType PersonaInPersonaAnimType;
    [FieldOffset(0x0050)] uint PersonaInPersonaFrame;
    [FieldOffset(0x0054)] uint PersonaInPersonaWait;
    [FieldOffset(0x0058)] float PersonaInPersonaDist;
    [FieldOffset(0x005C)] EOneAnimType PersonaInSiroItaAnimType;
    [FieldOffset(0x0060)] uint PersonaInSiroItaFrame;
    [FieldOffset(0x0064)] uint PersonaInSiroItaWait;
    [FieldOffset(0x0068)] EOneAnimType PersonaInTitleAnimType;
    [FieldOffset(0x006C)] uint PersonaInTitleFrame;
    [FieldOffset(0x0070)] uint PersonaInTitleWait;
    [FieldOffset(0x0074)] EOneAnimType PersonaInListAnimType;
    [FieldOffset(0x0078)] uint PersonaInListFrame;
    [FieldOffset(0x007C)] uint PersonaInListWait;
    [FieldOffset(0x0080)] EOneAnimType PersonaInArcanaAnimType;
    [FieldOffset(0x0084)] uint PersonaInArcanaFrame;
    [FieldOffset(0x0088)] uint PersonaInArcanaWait;
    [FieldOffset(0x008C)] EOneAnimType ItemPerListInAnimType;
    [FieldOffset(0x0090)] uint ItemPerListInFrame;
    [FieldOffset(0x0094)] uint ItemPerListInWait;
    [FieldOffset(0x0098)] uint ItemPerListInBackFrame;
    [FieldOffset(0x009C)] EOneAnimType ItemPerListInBgAnimType;
    [FieldOffset(0x00A0)] uint ItemPerListInBgFrame;
    [FieldOffset(0x00A4)] uint ItemPerListInBgBackFrame;

};
[StructLayout(LayoutKind.Explicit, Size = 0x318)]
public unsafe struct FCampParamTableRankUpRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public FColor HumanSankakuRed;
    [FieldOffset(0x000C)] public FColor HumanSankakuGreen;
    [FieldOffset(0x0010)] public FColor HumanBokasiRed;
    [FieldOffset(0x0014)] public FColor HumanBokasiGreen;
    [FieldOffset(0x0018)] public FColor HumanPointUpLightblue;
    [FieldOffset(0x001C)] public FColor HumanBrainBlue;
    [FieldOffset(0x0020)] public FColor HumanCharmBlue;
    [FieldOffset(0x0024)] public FColor HumanCourageBlue;
    [FieldOffset(0x0028)] public FColor CampHumanBrainBlue;
    [FieldOffset(0x002C)] public FColor CampHumanCharmBlue;
    [FieldOffset(0x0030)] public FColor CampHumanCourageBlue;
    [FieldOffset(0x0034)] public FColor ParameterNameYellow;
    [FieldOffset(0x0038)] public FColor CircleYellow;
    [FieldOffset(0x003C)] public FColor HelpTextYellow;
    [FieldOffset(0x0040)] public FVector2D PointUpTextStartPos;
    [FieldOffset(0x0048)] public FVector2D PointUpTextEndPos;
    [FieldOffset(0x0050)] public FVector2D RankUpTextStartPos;
    [FieldOffset(0x0058)] public FVector2D RankUpTextEndPos;
    [FieldOffset(0x0060)] public uint HumanInBgSankakuFrame;
    [FieldOffset(0x0064)] public uint HumanInSankakuFrame;
    [FieldOffset(0x0068)] public uint HumanInAllBGFrame;
    [FieldOffset(0x006C)] public uint HumanInHamonFrame;
    [FieldOffset(0x0070)] public uint HumanInRankRotFrame;
    [FieldOffset(0x0074)] public uint HumanInRankSlideFrame;
    [FieldOffset(0x0078)] public uint HumanInHelpSlideFrame;
    [FieldOffset(0x007C)] public uint HumanInTitleSlideFrame;
    [FieldOffset(0x0080)] public uint HumanInBgSankakuFrameWait;
    [FieldOffset(0x0084)] public uint HumanInSankakuFrameWaitWhite;
    [FieldOffset(0x0088)] public uint HumanInSankakuFrameWaitGreen;
    [FieldOffset(0x008C)] public uint HumanInSankakuFrameWaitRed;
    [FieldOffset(0x0090)] public uint HumanInAllBGFrameWait;
    [FieldOffset(0x0094)] public uint HumanInHamonFrameWait;
    [FieldOffset(0x0098)] public uint HumanInHamonFrameWaitSecond;
    [FieldOffset(0x009C)] public uint HumanInHamonFrameWaitThird;
    [FieldOffset(0x00A0)] public uint HumanInRankRotFrameWait;
    [FieldOffset(0x00A4)] public uint HumanInRankSlideFrameWait;
    [FieldOffset(0x00A8)] public uint HumanInHelpSlideFrameWait;
    [FieldOffset(0x00AC)] public uint HumanInTitleSlideFrameWait;
    [FieldOffset(0x00B0)] public EOneAnimType HumanInBgSankakuType;
    [FieldOffset(0x00B1)] public EOneAnimType HumanInSankakuType;
    [FieldOffset(0x00B2)] public EOneAnimType HumanInAllBGType;
    [FieldOffset(0x00B3)] public EOneAnimType HumanInHamonType;
    [FieldOffset(0x00B4)] public EOneAnimType HumanInRankRotType;
    [FieldOffset(0x00B5)] public EOneAnimType HumanInRankSlideType;
    [FieldOffset(0x00B6)] public EOneAnimType HumanInHelpSlideType;
    [FieldOffset(0x00B7)] public EOneAnimType HumanInTitleSlideType;
    [FieldOffset(0x00B8)] public uint HumanPointUpTextSlideOneFrame;
    [FieldOffset(0x00BC)] public uint HumanPointUpTextSlideTwoFrame;
    [FieldOffset(0x00C0)] public uint HumanPointUpTextSlideThreeFrame;
    [FieldOffset(0x00C4)] public uint HumanPointUpTextFadeOneFrame;
    [FieldOffset(0x00C8)] public uint HumanPointUpTextFadeTwoFrame;
    [FieldOffset(0x00CC)] public uint HumanPointUpTextFadeThreeFrame;
    [FieldOffset(0x00D0)] public uint HumanPointUpHamonScaleFrame;
    [FieldOffset(0x00D4)] public uint HumanPointUpHamonFadeFrame;
    [FieldOffset(0x00D8)] public uint HumanPointUpBlueCircleFadeOneFrame;
    [FieldOffset(0x00DC)] public uint HumanPointUpBlueCircleFadeTwoFrame;
    [FieldOffset(0x00E0)] public uint HumanPointUpBlueCircleFadeThreeFrame;
    [FieldOffset(0x00E4)] public uint HumanPointUpBlueCircleScaleOneFrame;
    [FieldOffset(0x00E8)] public uint HumanPointUpBlueCircleScaleTwoFrame;
    [FieldOffset(0x00EC)] public uint HumanPointUpBlueCircleScaleThreeFrame;
    [FieldOffset(0x00F0)] public uint HumanPointUpTextSlideOneFrameWait;
    [FieldOffset(0x00F4)] public uint HumanPointUpTextSlideTwoFrameWait;
    [FieldOffset(0x00F8)] public uint HumanPointUpTextSlideThreeFrameWait;
    [FieldOffset(0x00FC)] public uint HumanPointUpTextFadeOneFrameWait;
    [FieldOffset(0x0100)] public uint HumanPointUpTextFadeTwoFrameWait;
    [FieldOffset(0x0104)] public uint HumanPointUpTextFadeThreeFrameWait;
    [FieldOffset(0x0108)] public uint HumanPointUpHamonScaleFrameWait;
    [FieldOffset(0x010C)] public uint HumanPointUpHamonFadeFrameWait;
    [FieldOffset(0x0110)] public uint HumanPointUpBlueCircleFadeOneFrameWait;
    [FieldOffset(0x0114)] public uint HumanPointUpBlueCircleFadeTwoFrameWait;
    [FieldOffset(0x0118)] public uint HumanPointUpBlueCircleFadeThreeFrameWait;
    [FieldOffset(0x011C)] public uint HumanPointUpBlueCircleScaleOneFrameWait;
    [FieldOffset(0x0120)] public uint HumanPointUpBlueCircleScaleTwoFrameWait;
    [FieldOffset(0x0124)] public uint HumanPointUpBlueCircleScaleThreeFrameWait;
    [FieldOffset(0x0128)] public EOneAnimType HumanPointUpTextSlideOneType;
    [FieldOffset(0x0129)] public EOneAnimType HumanPointUpTextSlideTwoType;
    [FieldOffset(0x012A)] public EOneAnimType HumanPointUpTextSlideThreeType;
    [FieldOffset(0x012B)] public EOneAnimType HumanPointUpTextFadeOneType;
    [FieldOffset(0x012C)] public EOneAnimType HumanPointUpTextFadeTwoType;
    [FieldOffset(0x012D)] public EOneAnimType HumanPointUpTextFadeThreeType;
    [FieldOffset(0x012E)] public EOneAnimType HumanPointUpHamonScaleType;
    [FieldOffset(0x012F)] public EOneAnimType HumanPointUpHamonFadeType;
    [FieldOffset(0x0130)] public EOneAnimType HumanPointUpBlueCircleFadeScaleOneType;
    [FieldOffset(0x0131)] public EOneAnimType HumanPointUpBlueCircleFadeScaleTwoType;
    [FieldOffset(0x0132)] public EOneAnimType HumanPointUpBlueCircleFadeScaleThreeType;
    [FieldOffset(0x0134)] public uint HumanRankUpTextSlideOneFrame;
    [FieldOffset(0x0138)] public uint HumanRankUpTextSlideTwoFrame;
    [FieldOffset(0x013C)] public uint HumanRankUpTextSlideThreeFrame;
    [FieldOffset(0x0140)] public uint HumanRankUpTextFadeOneFrame;
    [FieldOffset(0x0144)] public uint HumanRankUpTextFadeTwoFrame;
    [FieldOffset(0x0148)] public uint HumanRankUpTextFadeThreeFrame;
    [FieldOffset(0x014C)] public uint HumanRankUpHamonScaleFrame;
    [FieldOffset(0x0150)] public uint HumanRankUpHamonFadeFrame;
    [FieldOffset(0x0154)] public uint HumanRankUpWhiteCircleColorOneFrame;
    [FieldOffset(0x0158)] public uint HumanRankUpWhiteCircleColorTwoFrame;
    [FieldOffset(0x015C)] public uint HumanRankUpWhiteCircleColorThreeFrame;
    [FieldOffset(0x0160)] public uint HumanRankUpWhiteCircleScaleOneFrame;
    [FieldOffset(0x0164)] public uint HumanRankUpWhiteCircleScaleTwoFrame;
    [FieldOffset(0x0168)] public uint HumanRankUpWhiteCircleScaleThreeFrame;
    [FieldOffset(0x016C)] public uint HumanRankUpTextSlideOneFrameWait;
    [FieldOffset(0x0170)] public uint HumanRankUpTextSlideTwoFrameWait;
    [FieldOffset(0x0174)] public uint HumanRankUpTextSlideThreeFrameWait;
    [FieldOffset(0x0178)] public uint HumanRankUpTextFadeOneFrameWait;
    [FieldOffset(0x017C)] public uint HumanRankUpTextFadeTwoFrameWait;
    [FieldOffset(0x0180)] public uint HumanRankUpTextFadeThreeFrameWait;
    [FieldOffset(0x0184)] public uint HumanRankUpHamonScaleFrameWait;
    [FieldOffset(0x0188)] public uint HumanRankUpHamonFadeFrameWait;
    [FieldOffset(0x018C)] public uint HumanRankUpWhiteCircleColorOneFrameWait;
    [FieldOffset(0x0190)] public uint HumanRankUpWhiteCircleColorTwoFrameWait;
    [FieldOffset(0x0194)] public uint HumanRankUpWhiteCircleColorThreeFrameWait;
    [FieldOffset(0x0198)] public uint HumanRankUpWhiteCircleScaleOneFrameWait;
    [FieldOffset(0x019C)] public uint HumanRankUpWhiteCircleScaleTwoFrameWait;
    [FieldOffset(0x01A0)] public uint HumanRankUpWhiteCircleScaleThreeFrameWait;
    [FieldOffset(0x01A4)] public EOneAnimType HumanRankUpTextSlideOneType;
    [FieldOffset(0x01A5)] public EOneAnimType HumanRankUpTextSlideTwoType;
    [FieldOffset(0x01A6)] public EOneAnimType HumanRankUpTextSlideThreeType;
    [FieldOffset(0x01A7)] public EOneAnimType HumanRankUpTextFadeOneType;
    [FieldOffset(0x01A8)] public EOneAnimType HumanRankUpTextFadeTwoType;
    [FieldOffset(0x01A9)] public EOneAnimType HumanRankUpTextFadeThreeType;
    [FieldOffset(0x01AA)] public EOneAnimType HumanRankUpHamonScaleType;
    [FieldOffset(0x01AB)] public EOneAnimType HumanRankUpHamonFadeType;
    [FieldOffset(0x01AC)] public EOneAnimType HumanRankUpWhiteCircleColorOneType;
    [FieldOffset(0x01AD)] public EOneAnimType HumanRankUpWhiteCircleColorTwoType;
    [FieldOffset(0x01AE)] public EOneAnimType HumanRankUpWhiteCircleColorThreeType;
    [FieldOffset(0x01AF)] public EOneAnimType HumanRankUpWhiteCircleScaleOneType;
    [FieldOffset(0x01B0)] public EOneAnimType HumanRankUpWhiteCircleScaleTwoType;
    [FieldOffset(0x01B1)] public EOneAnimType HumanRankUpWhiteCircleScaleThreeType;
    [FieldOffset(0x01B4)] public uint HumanRankUpAllCircleScaleFrame;
    [FieldOffset(0x01B8)] public uint HumanRankUpCurrentNumberFadeFrame;
    [FieldOffset(0x01BC)] public uint HumanRankUpNextNumberFadeSlideFrame;
    [FieldOffset(0x01C0)] public uint HumanRankUpCurrentHelpTextFadeFrame;
    [FieldOffset(0x01C4)] public uint HumanRankUpNextHelpTextFadeSlideFrame;
    [FieldOffset(0x01C8)] public uint HumanRankUpMaskCircleFrame;
    [FieldOffset(0x01CC)] public uint HumanRankUpAllCircleScaleFrameWait;
    [FieldOffset(0x01D0)] public uint HumanRankUpCurrentNumberFadeFrameWait;
    [FieldOffset(0x01D4)] public uint HumanRankUpNextNumberFadeSlideFrameWait;
    [FieldOffset(0x01D8)] public uint HumanRankUpCurrentHelpTextFadeFrameWait;
    [FieldOffset(0x01DC)] public uint HumanRankUpNextHelpTextFadeSlideFrameWait;
    [FieldOffset(0x01E0)] public uint HumanRankUpMaskCircleFrameWait;
    [FieldOffset(0x01E4)] public EOneAnimType HumanRankUpAllCircleScaleType;
    [FieldOffset(0x01E5)] public EOneAnimType HumanRankUpCurrentNumberFadeType;
    [FieldOffset(0x01E6)] public EOneAnimType HumanRankUpNextNumberFadeSlideType;
    [FieldOffset(0x01E7)] public EOneAnimType HumanRankUpCurrentHelpTextFadeType;
    [FieldOffset(0x01E8)] public EOneAnimType HumanRankUpNextHelpTextFadeSlideType;
    [FieldOffset(0x01E9)] public EOneAnimType HumanRankUpMaskCircleType;
    [FieldOffset(0x01EC)] public uint HumanRankUpNextNumberFadeFrame;
    [FieldOffset(0x01F0)] public uint HumanRankUpNextHelpTextFadeFrame;
    [FieldOffset(0x01F4)] public uint HumanRankUpNextNumberFadeFrameWait;
    [FieldOffset(0x01F8)] public uint HumanRankUpNextHelpTextFadeFrameWait;
    [FieldOffset(0x01FC)] public EOneAnimType HumanRankUpNextNumberFadeType;
    [FieldOffset(0x01FD)] public EOneAnimType HumanRankUpNextHelpTextFadeType;
    [FieldOffset(0x0200)] public uint KeyHelpFadeInFrame;
    [FieldOffset(0x0204)] public uint HumanKeyHelpInFrameWait;
    [FieldOffset(0x0208)] public uint KeyHelpFadeOutFrame;
    [FieldOffset(0x020C)] public uint HumanKeyHelpOutFrameWait;
    [FieldOffset(0x0210)] public uint KeyHelpMaskSlideOneFrame;
    [FieldOffset(0x0214)] public uint KeyHelpMaskSlideTwoFrame;
    [FieldOffset(0x0218)] public uint KeyHelpMaskSlideThreeFrame;
    [FieldOffset(0x021C)] public uint KeyHelpMaskSlideOneWaitFrame;
    [FieldOffset(0x0220)] public uint KeyHelpMaskSlideTwoWaitFrame;
    [FieldOffset(0x0224)] public uint KeyHelpMaskSlideThreeWaitFrame;
    [FieldOffset(0x0228)] public EOneAnimType KeyHelpMaskSlideOneType;
    [FieldOffset(0x0229)] public EOneAnimType KeyHelpMaskSlideTwoType;
    [FieldOffset(0x022A)] public EOneAnimType KeyHelpMaskSlideThreeType;
    [FieldOffset(0x022B)] public EOneAnimType KeyHelpMaskSlideOneWaitType;
    [FieldOffset(0x022C)] public EOneAnimType KeyHelpMaskSlideTwoWaitType;
    [FieldOffset(0x022D)] public EOneAnimType KeyHelpMaskSlideThreeWaitType;
    [FieldOffset(0x022E)] public EOneAnimType KeyHelpOutScaleType;
    [FieldOffset(0x0230)] public uint KeyHelpOutScaleFrame;
    [FieldOffset(0x0234)] public float KeyHelpFadeOutScaleSize;
    [FieldOffset(0x0238)] public uint MaxHamonShiftWaitFlame;
    [FieldOffset(0x023C)] public uint HumanMaxHamonScaleInFlame;
    [FieldOffset(0x0240)] public uint HumanMaxHamonScaleInFlameWait;
    [FieldOffset(0x0244)] public uint HumanMaxHamonFadeInAllFlameWait;
    [FieldOffset(0x0248)] public uint HumanMaxHamonFadeInFlame;
    [FieldOffset(0x024C)] public uint HumanMaxHamonFadeInFlameWait;
    [FieldOffset(0x0250)] public uint HumanMaxHamonFadeOutFlame;
    [FieldOffset(0x0254)] public uint HumanMaxHamonFadeOutFlameWait;
    [FieldOffset(0x0258)] public uint HumanMaxHamonFadeOutLastFlame;
    [FieldOffset(0x025C)] public uint HumanMaxHamonFadeOutLastFlameWait;
    [FieldOffset(0x0260)] public EOneAnimType HumanMaxHamonScaleOutType;
    [FieldOffset(0x0264)] public uint MaxTriangleBlurFadeInFlame;
    [FieldOffset(0x0268)] public uint MaxTriangleBlurFadeInFlameWait;
    [FieldOffset(0x026C)] public uint MaxTriangleBlurFadeOutFlame;
    [FieldOffset(0x0270)] public uint HumanMaxCircleFadeInFlame;
    [FieldOffset(0x0274)] public uint HumanMaxCircleFadeInFlameWait;
    [FieldOffset(0x0278)] public uint HumanMaxCircleFadeOutFlame;
    [FieldOffset(0x027C)] public uint MaxCircleFinishFlameWait;
    [FieldOffset(0x0280)] public EOneAnimType HumanMaxHamonScaleType;
    [FieldOffset(0x0281)] public EOneAnimType HumanMaxHamonFadeInType;
    [FieldOffset(0x0282)] public EOneAnimType HumanMaxHamonFadeOutType;
    [FieldOffset(0x0283)] public EOneAnimType MaxTriangleBlurFadeInType;
    [FieldOffset(0x0284)] public EOneAnimType MaxTriangleBlurFadeOutType;
    [FieldOffset(0x0285)] public EOneAnimType HumanMaxCircleFadeInType;
    [FieldOffset(0x0286)] public EOneAnimType HumanMaxCircleFadeTwoType;
    [FieldOffset(0x0288)] public uint HumanCircleFadeLoop_Wait_0;
    [FieldOffset(0x028C)] public uint HumanCircleFadeLoop_Frame_0;
    [FieldOffset(0x0290)] public uint HumanCircleFadeLoop_Wait_1;
    [FieldOffset(0x0294)] public uint HumanCircleFadeLoop_Frame_1;
    [FieldOffset(0x0298)] public uint HumanCircleColorLoop_Wait_0;
    [FieldOffset(0x029C)] public uint HumanCircleColorLoop_Frame_0;
    [FieldOffset(0x02A0)] public uint HumanCircleColorLoop_Wait_1;
    [FieldOffset(0x02A4)] public uint HumanCircleColorLoop_Frame_1;
    [FieldOffset(0x02A8)] public uint HumanCircleScaleUpLoop_Wait;
    [FieldOffset(0x02AC)] public uint HumanCircleScaleUpLoop_Frame;
    [FieldOffset(0x02B0)] public EOneAnimType HumanCircleFadeLoopType;
    [FieldOffset(0x02B1)] public EOneAnimType HumanCircleScaleLoopType;
    [FieldOffset(0x02B2)] public EOneAnimType HumanCircleColorLoopType;
    [FieldOffset(0x02B4)] public uint HumanPlusHamonFlame;
    [FieldOffset(0x02B8)] public uint HumanCircleLoopStartWait;
    [FieldOffset(0x02BC)] public uint HumanOutHelpSlideFrame;
    [FieldOffset(0x02C0)] public uint HumanOutTitleSlideFrame;
    [FieldOffset(0x02C4)] public uint HumanOutHamonFrame;
    [FieldOffset(0x02C8)] public uint HumanOutSankakuFrame;
    [FieldOffset(0x02CC)] public uint HumanOutRankRotFrame;
    [FieldOffset(0x02D0)] public uint HumanOutBgSankakuFrame;
    [FieldOffset(0x02D4)] public uint HumanOutAllBgFrame;
    [FieldOffset(0x02D8)] public uint HumanOutHelpSlideFrameWait;
    [FieldOffset(0x02DC)] public uint HumanOutTitleSlideFrameWait;
    [FieldOffset(0x02E0)] public uint HumanOutHamonFrameWait;
    [FieldOffset(0x02E4)] public uint HumanOutSankakuFrameWait;
    [FieldOffset(0x02E8)] public uint HumanOutRankRotFrameWait;
    [FieldOffset(0x02EC)] public uint HumanOutBgSankakuFrameWait;
    [FieldOffset(0x02F0)] public uint HumanOutAllBgFrameWait;
    [FieldOffset(0x02F4)] public EOneAnimType HumanOutHelpSlideType;
    [FieldOffset(0x02F5)] public EOneAnimType HumanOutTitleSlideType;
    [FieldOffset(0x02F6)] public EOneAnimType HumanOutHamonType;
    [FieldOffset(0x02F7)] public EOneAnimType HumanOutSankakuType;
    [FieldOffset(0x02F8)] public EOneAnimType HumanOutRankRotType;
    [FieldOffset(0x02F9)] public EOneAnimType HumanOutBgSankakuType;
    [FieldOffset(0x02FA)] public EOneAnimType HumanOutAllBgType;
    [FieldOffset(0x02FB)] public EOneAnimType HumanKeyHelpOutType;
    [FieldOffset(0x02FC)] public uint HumanHamonLoopScaleDownFrame;
    [FieldOffset(0x0300)] public uint HumanHamonLoopScaleUpFrameWait;
    [FieldOffset(0x0304)] public EOneAnimType HumanHamonLoopScaleDownType;
    [FieldOffset(0x0308)] public uint HumanHamonLoopWaitFrame;
    [FieldOffset(0x030C)] public EOneAnimType HumanHamonLoopWaitType;
    [FieldOffset(0x0310)] public uint HumanHamonLoopScaleUpFrame;
    [FieldOffset(0x0314)] public EOneAnimType HumanHamonLoopScaleUpType;

};

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe struct FCampParamTableSkillRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public float SkillInDist;
    [FieldOffset(0x000C)] public EOneAnimType SkillSilhouetteAnimType;
    [FieldOffset(0x0010)] public uint SkillSilhouetteFrame;
    [FieldOffset(0x0014)] public uint SkillSilhouetteWait;
    [FieldOffset(0x0018)] public EOneAnimType SkillSiroItaAnimType;
    [FieldOffset(0x001C)] public uint SkillSiroItaFrame;
    [FieldOffset(0x0020)] public uint SkillSiroItaWait;
    [FieldOffset(0x0024)] public EOneAnimType SkillTitleAnimType;
    [FieldOffset(0x0028)] public uint SkillTitleFrame;
    [FieldOffset(0x002C)] public uint SkillTitleWait;
    [FieldOffset(0x0030)] public EOneAnimType SkillListAnimType;
    [FieldOffset(0x0034)] public uint SkillListFrame;
    [FieldOffset(0x0038)] public uint SkillListWait;
    [FieldOffset(0x003C)] public EOneAnimType SkillPartyAnimType;
    [FieldOffset(0x0040)] public uint SkillPartyFrame;
    [FieldOffset(0x0044)] public uint SkillPartyWait;
    [FieldOffset(0x0048)] public uint SkillPartyFadeFrame;
    [FieldOffset(0x004C)] public uint SkillPartyInterval;
    [FieldOffset(0x0050)] public EOneAnimType GunRefRotAnimType;
    [FieldOffset(0x0054)] public uint GunRefInFrame;
    [FieldOffset(0x0058)] public uint GunRefInWait;
    [FieldOffset(0x005C)] public uint GunRefNextFrame;
    [FieldOffset(0x0060)] public FVector2D GunRefPos;
    [FieldOffset(0x0068)] public float GunRefOffset;

};
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe struct FCampParamTableStatusRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public uint ListTabChangeFrame;
    [FieldOffset(0x000C)] public uint StatListPartyRightSideFadeOutFrame;
    [FieldOffset(0x0010)] public uint StatListPartyRightSideFadeInFrame;
    [FieldOffset(0x0014)] public uint StatListKoshoLogoRotFrame;
    [FieldOffset(0x0018)] public uint StatListGlassCharaFrame;
    [FieldOffset(0x001C)] public uint StatListGlassCharaWait;
    [FieldOffset(0x0020)] public uint StatListBgNoiseRandFrameMin;
    [FieldOffset(0x0024)] public uint StatListBgNoiseRandFrameMax;
    [FieldOffset(0x0028)] public float StatListInDist;
    [FieldOffset(0x002C)] public EOneAnimType StatListInSilhouetteAnimType;
    [FieldOffset(0x0030)] public uint StatListInSilhouetteFrame;
    [FieldOffset(0x0034)] public uint StatListInSilhouetteWait;
    [FieldOffset(0x0038)] public EOneAnimType StatListInKoshoAnimType;
    [FieldOffset(0x003C)] public uint StatListInKoshoFrame;
    [FieldOffset(0x0040)] public uint StatListInKoshoWait;
    [FieldOffset(0x0044)] public EOneAnimType StatListInTabAnimType;
    [FieldOffset(0x0048)] public uint StatListInTabFrame;
    [FieldOffset(0x004C)] public uint StatListInTabWait;
    [FieldOffset(0x0050)] public EOneAnimType StatListBgNoiseAnimType;
    [FieldOffset(0x0054)] public uint StatListBgNoiseFrame;
    [FieldOffset(0x0058)] public EOneAnimType StatListBgTextAnimType;
    [FieldOffset(0x005C)] public uint StatListBgTextFrame;
    [FieldOffset(0x0060)] public EOneAnimType StatListOpeListAnimType;
    [FieldOffset(0x0064)] public uint StatListOpeListFrame;
    [FieldOffset(0x0068)] public float StatDetailRotation;
    [FieldOffset(0x006C)] public EOneAnimType StatDetailInfoSlideAnimType;
    [FieldOffset(0x0070)] public uint StatDetailInfoSlideFrame;
    [FieldOffset(0x0074)] public EOneAnimType StatDetailBgNumSlideAnimType;
    [FieldOffset(0x0078)] public uint StatDetailBgNumSlideOutFrame;
    [FieldOffset(0x007C)] public uint StatDetailBgNumSlideInFrame;
    [FieldOffset(0x0080)] public EOneAnimType StatDetailHanshaSlideAnimType;
    [FieldOffset(0x0084)] public uint StatDetailHanshaSlideFrame;
    [FieldOffset(0x0088)] public EOneAnimType StatDetailHahenShadowSlideAnimType;
    [FieldOffset(0x008C)] public uint StatDetailHahenShadowSlideFrame;
    [FieldOffset(0x0090)] public EOneAnimType StatDetailCharaShadowSlideAnimType;
    [FieldOffset(0x0094)] public uint StatDetailCharaShadowSlideFrame;
    [FieldOffset(0x0098)] public EOneAnimType StatDetailLeaderRotAnimType;
    [FieldOffset(0x009C)] public uint StatDetailLeaderRotOutFrame;
    [FieldOffset(0x00A0)] public uint StatDetailLeaderRotInFrame;
    [FieldOffset(0x00A4)] public EOneAnimType StatDetailInOutlineAnimType;
    [FieldOffset(0x00A8)] public uint StatDetailInOutlineFrame;
    [FieldOffset(0x00AC)] public uint StatDetailInOutlineWait;
    [FieldOffset(0x00B0)] public uint StatDetailInOutlineOutFrame;
    [FieldOffset(0x00B4)] public EOneAnimType StatDetailPanelSlideAnimType;
    [FieldOffset(0x00B8)] public uint StatDetailPanelSlideFrame;
    [FieldOffset(0x00BC)] public uint StatDetailToTheurLeaderRotFrame;
    [FieldOffset(0x00C0)] public EOneAnimType StatDetailToTheurDetailInfoSlideAnimType;
    [FieldOffset(0x00C4)] public uint StatDetailToTheurDetailInfoSlideFrame;
    [FieldOffset(0x00C8)] public uint StatDetailToTheurBgNumSlideFrame;
    [FieldOffset(0x00CC)] public uint HumanHamonAlphaFrameDown;
    [FieldOffset(0x00D0)] public uint HumanHamonAlphaFrameUp;
    [FieldOffset(0x00D4)] public uint HumanHamonAlphaFrameStay;
    [FieldOffset(0x00D8)] public uint HumanHamonAlphaInterval;
    [FieldOffset(0x00DC)] public FColor HumanSankakuRed;
    [FieldOffset(0x00E0)] public FColor HumanSankakuGreen;
    [FieldOffset(0x00E4)] public FColor HumanBokasiRed;
    [FieldOffset(0x00E8)] public FColor HumanBokasiGreen;
    [FieldOffset(0x00EC)] public uint HumanInBgSankakuFrame;
    [FieldOffset(0x00F0)] public uint HumanInSankakuFrame;
    [FieldOffset(0x00F4)] public uint HumanInHamonFrame;
    [FieldOffset(0x00F8)] public uint HumanInRankRotFrame;
    [FieldOffset(0x00FC)] public uint HumanInRankSlideFrame;
    [FieldOffset(0x0100)] public uint HumanInHelpSlideFrame;
    [FieldOffset(0x0104)] public uint HumanInTitleSlideFrame;
    [FieldOffset(0x0108)] public uint HumanPointUpTextSlideOneFrame;
    [FieldOffset(0x010C)] public uint HumanPointUpTextSlideTwoFrame;
    [FieldOffset(0x0110)] public uint HumanPointUpTextSlideThreeFrame;
    [FieldOffset(0x0114)] public uint HumanPointUpTextFadeOneFrame;
    [FieldOffset(0x0118)] public uint HumanPointUpTextFadeTwoFrame;
    [FieldOffset(0x011C)] public uint HumanPointUpTextFadeThreeFrame;
    [FieldOffset(0x0120)] public uint HumanPointUpHamonScaleFrame;
    [FieldOffset(0x0124)] public uint HumanPointUpHamonFadeFrame;
    [FieldOffset(0x0128)] public uint HumanPointUpBlueCircleFadeScaleOneFrame;
    [FieldOffset(0x012C)] public uint HumanPointUpBlueCircleFadeScaleTwoFrame;
    [FieldOffset(0x0130)] public uint HumanPointUpBlueCircleFadeScaleThreeFrame;
    [FieldOffset(0x0134)] public uint HumanRankUpTextSlideOneFrame;
    [FieldOffset(0x0138)] public uint HumanRankUpTextSlideTwoFrame;
    [FieldOffset(0x013C)] public uint HumanRankUpTextSlideThreeFrame;
    [FieldOffset(0x0140)] public uint HumanRankUpTextFadeOneFrame;
    [FieldOffset(0x0144)] public uint HumanRankUpTextFadeTwoFrame;
    [FieldOffset(0x0148)] public uint HumanRankUpTextFadeThreeFrame;
    [FieldOffset(0x014C)] public uint HumanRankUpHamonScaleFrame;
    [FieldOffset(0x0150)] public uint HumanRankUpHamonFadeFrame;
    [FieldOffset(0x0154)] public uint HumanRankUpWhiteCircleColorOneFrame;
    [FieldOffset(0x0158)] public uint HumanRankUpWhiteCircleColorTwoFrame;
    [FieldOffset(0x015C)] public uint HumanRankUpWhiteCircleColorThreeFrame;
    [FieldOffset(0x0160)] public uint HumanRankUpWhiteCircleScaleOneFrame;
    [FieldOffset(0x0164)] public uint HumanRankUpWhiteCircleScaleTwoFrame;
    [FieldOffset(0x0168)] public uint HumanRankUpWhiteCircleScaleThreeFrame;
    [FieldOffset(0x016C)] public uint HumanRankUpAllCircleScaleFrame;
    [FieldOffset(0x0170)] public uint HumanRankUpCurrentNumberFadeFrame;
    [FieldOffset(0x0174)] public uint HumanRankUpNextNumberFadeSlideFrame;
    [FieldOffset(0x0178)] public uint HumanRankUpCurrentHelpTextFadeFrame;
    [FieldOffset(0x017C)] public uint HumanRankUpNextHelpTextFadeSlideFrame;
    [FieldOffset(0x0180)] public uint HumanRankUpMaskCircleFrame;
    [FieldOffset(0x0184)] public uint KeyHelpFadeFrame;
    [FieldOffset(0x0188)] public uint KeyHelpMaskSlideOneFrame;
    [FieldOffset(0x018C)] public uint KeyHelpMaskSlideTwoFrame;
    [FieldOffset(0x0190)] public uint KeyHelpMaskSlideThreeFrame;
    [FieldOffset(0x0194)] public uint KeyHelpMaskSlideOneWaitFrame;
    [FieldOffset(0x0198)] public uint KeyHelpMaskSlideTwoWaitFrame;
    [FieldOffset(0x019C)] public uint KeyHelpMaskSlideThreeWaitFrame;
    [FieldOffset(0x01A0)] public uint HumanMaxHamonScaleFlame;
    [FieldOffset(0x01A4)] public uint HumanMaxHamonFadeOneFlame;
    [FieldOffset(0x01A8)] public uint HumanMaxHamonFadeTwoFlame;
    [FieldOffset(0x01AC)] public uint HumanMaxCircleFadeOneFlame;
    [FieldOffset(0x01B0)] public uint HumanMaxCircleFadeTwoFlame;
    [FieldOffset(0x01B4)] public uint HumanCircleLoopFlame;
    [FieldOffset(0x01B8)] public uint HumanPlusHamonFlame;
    [FieldOffset(0x01BC)] public uint HumanOutHelpSlideFrame;
    [FieldOffset(0x01C0)] public uint HumanOutHamonFrame;
    [FieldOffset(0x01C4)] public uint HumanOutSankakuFrame;
    [FieldOffset(0x01C8)] public uint HumanOutRankRotFrame;
    [FieldOffset(0x01CC)] public uint HumanOutBgSankakuFrame;
    [FieldOffset(0x01D0)] public uint HumanHamonLoopScaleDownFrame;
    [FieldOffset(0x01D4)] public uint HumanHamonLoopWaitFrame;
    [FieldOffset(0x01D8)] public uint HumanHamonLoopScaleUpFrame;
    [FieldOffset(0x01DC)] public EOneAnimType FldTheurPanelSlideAnimType;
    [FieldOffset(0x01E0)] public uint FldTheurPanelSlideFrame;
    [FieldOffset(0x01E4)] public uint FldTheurPanelSlideWait;
    [FieldOffset(0x01E8)] public uint FldTheurBgNumSlideFrame;
    [FieldOffset(0x01EC)] public uint FldTheurBgNumSlideWait;
    [FieldOffset(0x01F0)] public EOneAnimType FldTheurBustupSlideAnimType;
    [FieldOffset(0x01F4)] public uint FldTheurBustupSlideInFrame;
    [FieldOffset(0x01F8)] public uint FldTheurBustupSlideInWait;
    [FieldOffset(0x01FC)] public uint FldTheurBustupSlideOutFrame;
    [FieldOffset(0x0200)] public FColor TheurCharaMaskColor;
    [FieldOffset(0x0204)] public FVector2D TheurCharaPosHero;
    [FieldOffset(0x020C)] public FVector2D TheurShadowPosHero;
    [FieldOffset(0x0214)] public FVector2D TheurCharaPosYukari;
    [FieldOffset(0x021C)] public FVector2D TheurShadowPosYukari;
    [FieldOffset(0x0224)] public FVector2D TheurCharaPosJunpei;
    [FieldOffset(0x022C)] public FVector2D TheurShadowPosJunpei;
    [FieldOffset(0x0234)] public FVector2D TheurCharaPosSanada;
    [FieldOffset(0x023C)] public FVector2D TheurShadowPosSanada;
    [FieldOffset(0x0244)] public FVector2D TheurCharaPosMituru;
    [FieldOffset(0x024C)] public FVector2D TheurShadowPosMituru;
    [FieldOffset(0x0254)] public FVector2D TheurCharaPosFuka;
    [FieldOffset(0x025C)] public FVector2D TheurShadowPosFuka;
    [FieldOffset(0x0264)] public FVector2D TheurCharaPosAegis;
    [FieldOffset(0x026C)] public FVector2D TheurShadowPosAegis;
    [FieldOffset(0x0274)] public FVector2D TheurCharaPosAmada;
    [FieldOffset(0x027C)] public FVector2D TheurShadowPosAmada;
    [FieldOffset(0x0284)] public FVector2D TheurCharaPosKoromaru;
    [FieldOffset(0x028C)] public FVector2D TheurShadowPosKoromaru;
    [FieldOffset(0x0294)] public FVector2D TheurCharaPosAragaki;
    [FieldOffset(0x029C)] public FVector2D TheurShadowPosAragaki;
    [FieldOffset(0x02A4)] public EOneAnimType Edit_MaskA_InAnimation_SlideIn_Type;
    [FieldOffset(0x02A8)] public int Edit_MaskA_InAnimation_SlideIn_Frame;
    [FieldOffset(0x02AC)] public int Edit_MaskA_InAnimation_SlideIn_Delay;
    [FieldOffset(0x02B0)] public EOneAnimType Edit_MaskA_OutAnimation_SlideIn_Type;
    [FieldOffset(0x02B4)] public int Edit_MaskA_OutAnimation_SlideIn_Frame;
    [FieldOffset(0x02B8)] public int Edit_MaskA_OutAnimation_SlideIn_Delay;
    [FieldOffset(0x02BC)] public EOneAnimType Edit_MaskA_Change_SlideIn_Type;
    [FieldOffset(0x02C0)] public int Edit_MaskA_Change_SlideIn_Frame;
    [FieldOffset(0x02C4)] public int Edit_MaskA_Change_SlideIn_Delay;
    [FieldOffset(0x02C8)] public EOneAnimType Edit_MaskB_InAnimation_SlideIn_Type;
    [FieldOffset(0x02CC)] public int Edit_MaskB_InAnimation_SlideIn_Frame;
    [FieldOffset(0x02D0)] public int Edit_MaskB_InAnimation_SlideIn_Delay;
    [FieldOffset(0x02D4)] public EOneAnimType Edit_MaskB_OutAnimation_SlideIn_Type;
    [FieldOffset(0x02D8)] public int Edit_MaskB_OutAnimation_SlideIn_Frame;
    [FieldOffset(0x02DC)] public int Edit_MaskB_OutAnimation_SlideIn_Delay;
    [FieldOffset(0x02E0)] public EOneAnimType Edit_MaskB_Change_SlideIn_Type;
    [FieldOffset(0x02E4)] public int Edit_MaskB_Change_SlideIn_Frame;
    [FieldOffset(0x02E8)] public int Edit_MaskB_Change_SlideIn_Delay;
    [FieldOffset(0x02EC)] public EOneAnimType Edit_CharacterShadow_InAnimation_SlideIn_Type;
    [FieldOffset(0x02F0)] public int Edit_CharacterShadow_InAnimation_SlideIn_Frame;
    [FieldOffset(0x02F4)] public int Edit_CharacterShadow_InAnimation_SlideIn_Delay;
    [FieldOffset(0x02F8)] public EOneAnimType Edit_CharacterShadow_Change_SlideIn_Type;
    [FieldOffset(0x02FC)] public int Edit_CharacterShadow_Change_SlideIn_Frame;
    [FieldOffset(0x0300)] public int Edit_CharacterShadow_Change_SlideIn_Delay;
    [FieldOffset(0x0304)] public int Edit_Theurgia_Icon_Fade_In_Frame;
    [FieldOffset(0x0308)] public int Edit_Theurgia_Icon_Fade_In_Delay;
};

[StructLayout(LayoutKind.Explicit, Size = 0x168)]
public unsafe struct FCampParamTableSystemRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public float SystemTopInMenuDist;
    [FieldOffset(0x000C)] public uint SystemTopInTopMenuFrame1;
    [FieldOffset(0x0010)] public uint SystemTopInTopMenuFrame2;
    [FieldOffset(0x0014)] public uint SystemTopInTopMenuRotFrame;
    [FieldOffset(0x0018)] public EOneAnimType SystemTopInAoItaAnimType;
    [FieldOffset(0x001C)] public uint SystemTopInAoItaFrame;
    [FieldOffset(0x0020)] public uint SystemTopInAoItaWait;
    [FieldOffset(0x0024)] public EOneAnimType SystemTopInTitleAnimType;
    [FieldOffset(0x0028)] public uint SystemTopInTitleFrame;
    [FieldOffset(0x002C)] public uint SystemTopInTitleWait;
    [FieldOffset(0x0030)] public FVector2D SystemTopTutorialOnPos;
    [FieldOffset(0x0038)] public float SystemTopTutorialOnRot;
    [FieldOffset(0x003C)] public FVector2D SystemTopConfigOnPos;
    [FieldOffset(0x0044)] public float SystemTopConfigOnRot;
    [FieldOffset(0x0048)] public FVector2D SystemTopDictionaryOnPos;
    [FieldOffset(0x0050)] public float SystemTopDictionaryOnRot;
    [FieldOffset(0x0054)] public FVector2D SystemTopDataloadOnPos;
    [FieldOffset(0x005C)] public float SystemTopDataloadOnRot;
    [FieldOffset(0x0060)] public FVector2D SystemTopDatasaveOnPos;
    [FieldOffset(0x0068)] public float SystemTopDatasaveOnRot;
    [FieldOffset(0x006C)] public FVector2D SystemTopRollbackOnPos;
    [FieldOffset(0x0074)] public float SystemTopRollbackOnRot;
    [FieldOffset(0x0078)] public FVector2D SystemTopTitleOnPos;
    [FieldOffset(0x0080)] public float SystemTopTitleOnRot;
    [FieldOffset(0x0084)] public FVector2D SystemTopTutorialOffPos;
    [FieldOffset(0x008C)] public float SystemTopTutorialOffRot;
    [FieldOffset(0x0090)] public FVector2D SystemTopConfigOffPos;
    [FieldOffset(0x0098)] public float SystemTopConfigOffRot;
    [FieldOffset(0x009C)] public FVector2D SystemTopDictionaryOffPos;
    [FieldOffset(0x00A4)] public float SystemTopDictionaryOffRot;
    [FieldOffset(0x00A8)] public FVector2D SystemTopDataloadOffPos;
    [FieldOffset(0x00B0)] public float SystemTopDataloadOffRot;
    [FieldOffset(0x00B4)] public FVector2D SystemTopDatasaveOffPos;
    [FieldOffset(0x00BC)] public float SystemTopDatasaveOffRot;
    [FieldOffset(0x00C0)] public FVector2D SystemTopRollbackOffPos;
    [FieldOffset(0x00C8)] public float SystemTopRollbackOffRot;
    [FieldOffset(0x00CC)] public FVector2D SystemTopTitleOffPos;
    [FieldOffset(0x00D4)] public float SystemTopTitleOffRot;
    [FieldOffset(0x00D8)] public FVector2D Edit_CursorOn_Tutorial_Text_Scale;
    [FieldOffset(0x00E0)] public FVector2D Edit_CursorOn_Tutorial_Cursor_Scale;
    [FieldOffset(0x00E8)] public FVector2D Edit_CursorOn_Config_Text_Scale;
    [FieldOffset(0x00F0)] public FVector2D Edit_CursorOn_Config_Cursor_Scale;
    [FieldOffset(0x00F8)] public FVector2D Edit_CursorOn_Dictionary_Text_Scale;
    [FieldOffset(0x0100)] public FVector2D Edit_CursorOn_Dictionary_Cursor_Scale;
    [FieldOffset(0x0108)] public FVector2D Edit_CursorOn_DataLoad_Text_Scale;
    [FieldOffset(0x0110)] public FVector2D Edit_CursorOn_DataLoad_Cursor_Scale;
    [FieldOffset(0x0118)] public FVector2D Edit_CursorOn_DataSave_Text_Scale;
    [FieldOffset(0x0120)] public FVector2D Edit_CursorOn_DataSave_Cursor_Scale;
    [FieldOffset(0x0128)] public FVector2D Edit_CursorOn_RollBack_Text_Scale;
    [FieldOffset(0x0130)] public FVector2D Edit_CursorOn_RollBack_Cursor_Scale;
    [FieldOffset(0x0138)] public FVector2D Edit_CursorOn_ReturnToTitle_Text_Scale;
    [FieldOffset(0x0140)] public FVector2D Edit_CursorOn_ReturnToTitle_Cursor_Scale;
    [FieldOffset(0x0148)] public float Edit_CursorOn_Tutorial_Cursor_Angle;
    [FieldOffset(0x014C)] public float Edit_CursorOn_Config_Cursor_Angle;
    [FieldOffset(0x0150)] public float Edit_CursorOn_Dictionary_Cursor_Angle;
    [FieldOffset(0x0154)] public float Edit_CursorOn_DataLoad_Cursor_Angle;
    [FieldOffset(0x0158)] public float Edit_CursorOn_DataSave_Cursor_Angle;
    [FieldOffset(0x015C)] public float Edit_CursorOn_RollBack_Cursor_Angle;
    [FieldOffset(0x0160)] public float Edit_CursorOn_ReturnToTitle_Cursor_Angle;

};
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct FCampParamTableTopRow //: public FTableRowBase
{
    [FieldOffset(0x0008)] public float TopInDist;
    [FieldOffset(0x000C)] public float TopInMenuDist;
    [FieldOffset(0x0010)] public EOneAnimType TopInTitleAnimType;
    [FieldOffset(0x0014)] public uint TopInTitleFrame;
    [FieldOffset(0x0018)] public uint TopInTitleWait;
    [FieldOffset(0x001C)] public EOneAnimType TopInMenuAnimType;
    [FieldOffset(0x0020)] public uint TopInMenuFrame;
    [FieldOffset(0x0024)] public uint TopInMenuWait;
    [FieldOffset(0x0028)] public uint TopInMenuInterval;
    [FieldOffset(0x002C)] public EOneAnimType TopInWhiteCursorAnimType;
    [FieldOffset(0x0030)] public uint TopInWhiteCursorFrame;
    [FieldOffset(0x0034)] public uint TopInWhiteCursorWait;
    [FieldOffset(0x0038)] public EOneAnimType TopInRedCursorAnimType;
    [FieldOffset(0x003C)] public uint TopInRedCursorFrame;
    [FieldOffset(0x0040)] public uint TopInRedCursorWait;
    [FieldOffset(0x0044)] public uint Edit_Top_Reselect_Key_Lock_Frame;
};

// UI DATE

[StructLayout(LayoutKind.Explicit)]
public unsafe struct UAgePanelSection
{
    [FieldOffset(0x0)] public float X1;
    [FieldOffset(0x4)] public float X2;
    [FieldOffset(0x8)] public float Y1;
    [FieldOffset(0xC)] public float Y2;
    [FieldOffset(0x20)] public UMaterialInstanceDynamic* MaterialInstance;
    [FieldOffset(0x28)] public int Field28;
}

[StructLayout(LayoutKind.Explicit, Size = 0x370)]
public unsafe struct UAgePanel //: public UObject
{
    [FieldOffset(0x0038)] public USprAsset* _readSpr;                                                        // 0x0038 (size: 0x8)
    [FieldOffset(0x0040)] public UMaterial* _readMat;                                                        // 0x0040 (size: 0x10)
    [FieldOffset(0x0050)] public UMaterialInterface* _readMatInst;                                     // 0x0050 (size: 0x10)
    [FieldOffset(0x0058)] public UMaterialInstanceDynamic* _readMatInstDyn;                                     // 0x0050 (size: 0x10)
    //FCurveVectorAnimation _fadeCurve;                                                 // 0x0060 (size: 0x30)
    [FieldOffset(0xa8)] public bool bIsDarkHour;
    [FieldOffset(0x270)] public UAgePanelSection BottomMaterial;
    [FieldOffset(0x2a0)] public UAgePanelSection TopMaterial;
    [FieldOffset(0x2e8)] public UAssetLoader* Loader_;                                                      // 0x02E8 (size: 0x8)
    [FieldOffset(0x2f0)] public uint ActiveDrawTypeId;
    [FieldOffset(0x310)] public FLinearColor BottomColorNormal;
    [FieldOffset(0x320)] public FLinearColor BottomColorDarkHour;
    [FieldOffset(0x330)] public FLinearColor TopColorNormal;
    [FieldOffset(0x340)] public FLinearColor TopColorDarkHour;
    [FieldOffset(0x350)] public FLinearColor WaterColorNormal;
    [FieldOffset(0x360)] public FLinearColor WaterColorDarkHour;
};

[StructLayout(LayoutKind.Explicit, Size = 0x7e0)]
public unsafe struct AUIDateDraw //: public AUIBaseActor
{
    [FieldOffset(0x02A8)] public UAgePanel* m_pAgePanel;
    [FieldOffset(0x02B0)] public USprAsset* m_pFieldSpr;
    [FieldOffset(0x400)] public SprDefStruct1 TimeOfDayParams;
    [FieldOffset(0x7ad)] public byte TimeOfDay;
    [FieldOffset(0x07D0)] public UDataTable* LayoutData;
    [FieldOffset(0x07D8)] public UUILayoutDataTable* LayoutDataTable;

};

// AUIMailIcon (colors are hardcoded, not in struct, check DrawMailIconInner)

[StructLayout(LayoutKind.Explicit, Size = 0x1060)]
public unsafe struct AUIAccessInfoDraw //: public AUIBaseActor
{
    [FieldOffset(0x02F0)] public USprAsset* m_pMiniMapSpr;
    [FieldOffset(0x02F8)] public USprAsset* m_pPlaceSpr;
    [FieldOffset(0x0300)] public UUIMiniMapDraw* m_pMiniMap;
    //[FieldOffset(0x0308)] public UAssetLoader* m_pLoader;
    //[FieldOffset(0x0310)] public AScrActor* m_pScrActor;
    [FieldOffset(0x0318)] public UBfAsset* m_pBfAsset;
    [FieldOffset(0x0320)] public UBmdAsset* m_pBmdAsset;
    //[FieldOffset(0x0328)] public UUILocationSelect* m_pLocationSelect;
    [FieldOffset(0x0330)] public UPlgAsset* m_pPlacePlg;
    [FieldOffset(0x630)] public LocationSelectParams1 mapBg;
    [FieldOffset(0x0E00)] public FGetUIParameter m_tagUip;
    [FieldOffset(0x0E78)] public FCurveFloatAnimation m_tagFadeInCurve;
    [FieldOffset(0x0EA8)] public FCurveFloatAnimation m_tagFadeOutCurve;
    [FieldOffset(0xee0)] public FVector2D PlaceInfoBgPosition;
    [FieldOffset(0xf04)] public FSprColor PlaceInfoBgColor;
    [FieldOffset(0xf24)] public int PlaceTitleId;
    [FieldOffset(0x0F30)] public UDataTable* LayoutData;
    [FieldOffset(0x0F38)] public UUILayoutDataTable* LayoutDataTable;
    [FieldOffset(0x0F40)] public UDataTable* LayoutParamData;
    [FieldOffset(0x0F48)] public UDataTable* PlaceNameLayoutData;
    [FieldOffset(0x0F50)] public UUILayoutDataTable* PlaceNameLayoutDataTable;
    [FieldOffset(0x0F58)] public UDataTable* MapNameLayoutData;
    [FieldOffset(0x0F60)] public UUILayoutDataTable* MapNameLayoutDataTable;
    [FieldOffset(0x0F68)] public UDataTable* IwatodaiFloorNoLayoutData;
    [FieldOffset(0x0F70)] public UUILayoutDataTable* IwatodaiFloorNoLayoutDataTable;
    [FieldOffset(0x0F78)] public UDataTable* MallFloorNoLayoutData;
    [FieldOffset(0x0F80)] public UUILayoutDataTable* MallFloorNoLayoutDataTable;
    [FieldOffset(0x0F88)] public UDataTable* SchoolFloorNoLayoutData;
    [FieldOffset(0x0F90)] public UUILayoutDataTable* SchoolFloorNoLayoutDataTable;
    [FieldOffset(0x0F98)] public UDataTable* DormitoryFloorNoLayoutData;
    [FieldOffset(0x0FA0)] public UUILayoutDataTable* DormitoryFloorNoLayoutDataTable;
    [FieldOffset(0x0FA8)] public UDataTable* RyokanFloorNoLayoutData;
    [FieldOffset(0x0FB0)] public UUILayoutDataTable* RyokanFloorNoLayoutDataTable;
    [FieldOffset(0x0FB8)] public UDataTable* HotelFloorNoLayoutData;
    [FieldOffset(0x0FC0)] public UUILayoutDataTable* HotelFloorNoLayoutDataTable;
    [FieldOffset(0x0FC8)] public UDataTable* ThebelFloorNoLayoutData;
    [FieldOffset(0x0FD0)] public UUILayoutDataTable* ThebelFloorNoLayoutDataTable;
    [FieldOffset(0x0FD8)] public UDataTable* ArqaFloorNoLayoutData;
    [FieldOffset(0x0FE0)] public UUILayoutDataTable* ArqaFloorNoLayoutDataTable;
    [FieldOffset(0x0FE8)] public UDataTable* YabbashahFloorNoLayoutData;
    [FieldOffset(0x0FF0)] public UUILayoutDataTable* YabbashahFloorNoLayoutDataTable;
    [FieldOffset(0x0FF8)] public UDataTable* TziahFloorNoLayoutData;
    [FieldOffset(0x1000)] public UUILayoutDataTable* TziahFloorNoLayoutDataTable;
    [FieldOffset(0x1008)] public UDataTable* HarabahFloorNoLayoutData;
    [FieldOffset(0x1010)] public UUILayoutDataTable* HarabahFloorNoLayoutDataTable;
    [FieldOffset(0x1018)] public UDataTable* AdamahFloorNoLayoutData;
    [FieldOffset(0x1020)] public UUILayoutDataTable* AdamahFloorNoLayoutDataTable;
};

[StructLayout(LayoutKind.Explicit, Size = 0x680)]
public unsafe struct UUIMiniMapDraw //: public UObject
{
    [FieldOffset(0x0058)] public USprAsset* m_pMiniMapIcon00Spr;
    [FieldOffset(0x0060)] public USprAsset* m_pMiniMapIcon01Spr;
    [FieldOffset(0x0068)] public USprAsset* m_pPartMaskSpr;
    [FieldOffset(0x0070)] public USprAsset* m_pNoiseSpr;
    [FieldOffset(0x0078)] public UTexture* m_pMapTex;
    [FieldOffset(0x0080)] public UTexture* m_pPrevMapTex1;
    [FieldOffset(0x0088)] public UTexture* m_pPrevMapTex2;
    [FieldOffset(0x0090)] public UTexture* m_pPrevMapTex3;
    [FieldOffset(0x0098)] public UMaterial* m_pVelvetRoomIconMat;
    [FieldOffset(0x00A0)] public UMaterialInstanceDynamic* m_pVelvetRoomIconMID;
    //[FieldOffset(0x00A8)] public UMiniMapIconListTable* m_pFldMiniMapIconTable;
    [FieldOffset(0x00B0)] public UAssetLoader* m_pIconLoader;
    [FieldOffset(0x00B8)] public UAssetLoader* m_pMapLoader;
    [FieldOffset(0x00C0)] public TArray<nint> m_pMapLoaders;
    [FieldOffset(0xF250)] public UTexture* m_pMapParts;
    [FieldOffset(0xF660)] public UTexture* m_pWallTex;
    //[FieldOffset(0xF668)] public UFldDungeonPartVariationDataAsset* m_pPartVariationDataAsset;
    [FieldOffset(0xF760)] public UDataTable* m_pSchoolUpDownLayoutData;
    [FieldOffset(0xF768)] public UUILayoutDataTable* m_pSchoolUpDownLayoutDataTable;
    [FieldOffset(0xF770)] public UDataTable* m_pDormitoryUpDownLayoutData;
    [FieldOffset(0xF778)] public UUILayoutDataTable* m_pDormitoryUpDownLayoutDataTable;
    [FieldOffset(0xF780)] public UDataTable* m_pArcadeUpDownLayoutData;
    [FieldOffset(0xF788)] public UUILayoutDataTable* m_pArcadeUpDownLayoutDataTable;
    [FieldOffset(0xF790)] public UDataTable* m_pMallUpDownLayoutData;
    [FieldOffset(0xF798)] public UUILayoutDataTable* m_pMallUpDownLayoutDataTable;
    [FieldOffset(0xF7A0)] public UDataTable* m_pClubUpDownLayoutData;
    [FieldOffset(0xF7A8)] public UUILayoutDataTable* m_pClubUpDownLayoutDataTable;
    [FieldOffset(0xF7B0)] public UDataTable* m_pRyokanUpDownLayoutData;
    [FieldOffset(0xF7B8)] public UUILayoutDataTable* m_pRyokanUpDownLayoutDataTable;
    [FieldOffset(0xF7C0)] public UDataTable* m_pHotelUpDownLayoutData;
    [FieldOffset(0xF7C8)] public UUILayoutDataTable* m_pHotelUpDownLayoutDataTable;
    [FieldOffset(0xF7D0)] public UDataTable* m_pDungeonUpDownLayoutData;
    [FieldOffset(0xF7D8)] public UUILayoutDataTable* m_pDungeonUpDownLayoutDataTable;
    [FieldOffset(0xF7E0)] public UDataTable* m_pIconLayoutData;
    [FieldOffset(0xF7E8)] public UUILayoutDataTable* m_pIconLayoutDataTable;
};

[StructLayout(LayoutKind.Explicit, Size = 0x680)]
public unsafe struct AUIConfigurationDraw //: public AUIDrawBaseActor
{
    [FieldOffset(0x02F8)] public FVector2D ItemDrawOffset;
    //[FieldOffset(0x0340)] public TArray<FDrawBGMParam> BgmParams;
    [FieldOffset(0x0350)] public USprAsset* pKeySpr;
    [FieldOffset(0x0668)] public UUILayoutDataTable* LayoutDataTable;
    [FieldOffset(0x0670)] public UUILayoutDataTable* HelpLayoutDataTable;
    [FieldOffset(0x0678)] public UUILayoutDataTable* ConfigTextLayoutDataTable;
};
[StructLayout(LayoutKind.Explicit, Size = 0x40f0)]
public unsafe struct AUITownMapActor //: public AUIBaseActor
{
    [FieldOffset(0x02F0)] public UDataTable* m_pTownMapDT;
    [FieldOffset(0x02F8)] public USprAsset* m_pTownMapSpr;
    [FieldOffset(0x0300)] public USprAsset* m_pMiniMapIcon00Spr;
    [FieldOffset(0x0308)] public USprAsset* m_pMiniMapIcon01Spr;
    //[FieldOffset(0x0310)] public UAssetLoader* m_pLoader;
    //[FieldOffset(0x0318)] public FGetUIParameter m_tagUip;
    //[FieldOffset(0x0390)] public FCurveVectorAnimation m_curveHeadInAnim;
    //[FieldOffset(0x03C0)] public FCurveVectorAnimation m_curveBlueDiamondAnim;
    //[FieldOffset(0x03F0)] public FCurveVectorAnimation m_curveWhiteDiamondAnim;
    //[FieldOffset(0x0420)] public FCurveVectorAnimation m_curveInfoInAnim;
    //[FieldOffset(0x0450)] public FCurveVectorAnimation m_curveIconAnim;
    [FieldOffset(0x0480)] public UUILocationSelect* m_pLocationSelect;
    //[FieldOffset(0x0488)] public AFldAnimObj* m_pSymbolRefList;
    //[FieldOffset(0x04B8)] public USkinnedMeshComponent* m_pSymbolSkinnedRefList;
    [FieldOffset(0x04E8)] public AActor* m_pFieldCamera;
    [FieldOffset(0x04F0)] public AActor* m_pMainCamera;
    [FieldOffset(0x04F8)] public AActor* m_pStartCamera;
    [FieldOffset(0x0500)] public AActor* m_pInfoCamera;
    [FieldOffset(0x0530)] public AActor* m_pNameLocator;
    [FieldOffset(0x0560)] public UBmdAsset* m_pTownMapDetailText;
    [FieldOffset(0x3ED8)] public FVector MarginRot;
    [FieldOffset(0x3F20)] public UUILayoutDataTable* m_notSelectedLayoutDataTables;
    [FieldOffset(0x3F50)] public UUILayoutDataTable* m_selectedLayoutDataTables;
    [FieldOffset(0x3F80)] public UUILayoutDataTable* m_infoLayoutDataTable;
    [FieldOffset(0x3F88)] public UUILayoutDataTable* m_infoLayoutDataTable2;
    [FieldOffset(0x3F90)] public UDataTable* m_notSelectedParamLayouts;
    [FieldOffset(0x3FC0)] public UDataTable* m_selectedParamLayouts;
    [FieldOffset(0x3FF0)] public UDataTable* m_infoParamLayout;
    [FieldOffset(0x3FF8)] public UDataTable* m_infoParamLayout2;
};

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe struct UAssetLoader //: public UObject
{
    [FieldOffset(0x0)] public UObject baseObj;
    [FieldOffset(0x28)] public nint StreamHandle;
    [FieldOffset(0x38)] public TArray<int> ObjectWeakReferences;
    [FieldOffset(0x48)] public TArray<nint> ObjectReferences; // TArray<UObject*>
};

// SAVE FILE

public enum ECldTimeZone : byte
{
    None = 0,
    EarlyMorning = 1,
    Morning = 2,
    AM = 3,
    Noon = 4,
    PM = 5,
    AfterSchool = 6,
    Night = 7,
    Shadow = 8,
    Midnight = 9,
    TimeMax = 10,
    ECldTimeZone_MAX = 11,
};

public enum ECldWeek : byte
{
    Sunday = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    WeekMax = 7,
    ECldWeek_MAX = 8,
};

public enum ECldMoonAge : byte
{
    Moon01 = 0,
    Moon02 = 1,
    Moon03 = 2,
    Moon04 = 3,
    Moon05 = 4,
    Moon06 = 5,
    Moon07 = 6,
    Moon08 = 7,
    Moon09 = 8,
    Moon10 = 9,
    Moon11 = 10,
    Moon12 = 11,
    Moon13 = 12,
    Moon14 = 13,
    Moon15 = 14,
    Moon16 = 15,
    Moon17 = 16,
    Moon18 = 17,
    Moon19 = 18,
    Moon20 = 19,
    Moon21 = 20,
    Moon22 = 21,
    Moon23 = 22,
    Moon24 = 23,
    Moon25 = 24,
    Moon26 = 25,
    Moon27 = 26,
    Moon28 = 27,
    Moon29 = 28,
    Moon30 = 29,
    MoonMax = 30,
    ECldMoonAge_MAX = 31,
};

[StructLayout(LayoutKind.Explicit, Size = 0xd0)]
public unsafe struct FSaveGameHeadder
{
    [FieldOffset(0x0000)] public FString GameName;
    [FieldOffset(0x0010)] public FString SaveSlotName;
    [FieldOffset(0x0020)] public uint UserIndex;
    [FieldOffset(0x0024)] public byte FirstName;
    [FieldOffset(0x0064)] public byte LastName;
    [FieldOffset(0x00A4)] public int Month;
    [FieldOffset(0x00A8)] public int Day;
    [FieldOffset(0x00AC)] public ECldWeek Week;
    [FieldOffset(0x00AD)] public ECldTimeZone TimeZone;
    [FieldOffset(0x00B0)] public int FldMajorID;
    [FieldOffset(0x00B4)] public int FldMinorID;
    [FieldOffset(0x00B8)] public int FldPartsID;
    [FieldOffset(0x00BC)] public uint PlayerLevel;
    [FieldOffset(0x00C0)] public ushort Difficulty;
    [FieldOffset(0x00C4)] public uint PlayTime;
    [FieldOffset(0x00C8)] public ECldMoonAge Age;
    [FieldOffset(0x00CC)] public int ClearStatus;
};

[StructLayout(LayoutKind.Explicit, Size = 0x3806F8)]
public unsafe struct UXRD777SaveGame //: public USaveGame
{
    [FieldOffset(0x0028)] public FSaveGameHeadder SaveDataHeadder;
    [FieldOffset(0x00F8)] public uint SaveDataArea;
};
[StructLayout(LayoutKind.Explicit, Size = 0x32C0)]
public unsafe struct UTCSSaveData //: public UObject
{
};

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe struct UXrd777SaveManager //: public UObject
{
    [FieldOffset(0x0058)] public UTCSSaveData* TCSSaveData;
    [FieldOffset(0x0070)] public UXRD777SaveGame* NetworkSaveInstance;
};


[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct FDatUnitStatus
{
    [FieldOffset(0x0000)] public int Hp;
    [FieldOffset(0x0004)] public int Sp;
    [FieldOffset(0x0008)] public int tp;
    [FieldOffset(0x000C)] public uint bad;
    [FieldOffset(0x0010)] public short Level;
    [FieldOffset(0x0014)] public uint Exp;
    [FieldOffset(0x0018)] public ushort affinity;
    [FieldOffset(0x001C)] public uint personalSkill;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe struct FDatUnitSupport
{
    [FieldOffset(0x0000)] public uint valid;
    [FieldOffset(0x0004)] public uint appointment;
    //[FieldOffset(0x0008)] public sbyte Point;
    //[FieldOffset(0x0012)] public sbyte Turn;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FDatUnitPersonaEntry
{
    [FieldOffset(0x0)] public short Flags;
    [FieldOffset(0x2)] public ushort Id;
    [FieldOffset(0x4)] public ushort Level;
    [FieldOffset(0x6)] public ushort Field08;
    [FieldOffset(0x8)] public uint Experience;
    //uint16 Skills[8];
    [FieldOffset(0x1c)] public byte Strength;
    [FieldOffset(0x1d)] public byte Magic;
    [FieldOffset(0x1e)] public byte Endurance;
    [FieldOffset(0x1f)] public byte Agility;
    [FieldOffset(0x20)] public byte Luck;
    // statsEx, statsExpTemp

    public ushort GetSkill(int i)
    {
        fixed (FDatUnitPersonaEntry* self = &this) { return ((ushort*)((nint)self + 0xc))[i]; }
    }
    public byte GetParamTotal(int pId) // FUN_1411acc90
    {
        if (pId < 0 || pId > 4) return 0;
        fixed (FDatUnitPersonaEntry* self = &this)
        {
            var pTotal = (byte)(*((byte*)self + 0x1c + pId) + *((byte*)self + 0x21 + pId) + *((byte*)self + 0x26 + pId));
            if (pTotal > 99) pTotal = 99;
            return pTotal;
        }
    }
};

[StructLayout(LayoutKind.Explicit, Size = 0x244)]
public unsafe struct FDatUnitPersona
{
    [FieldOffset(0x0000)] public ushort equip;

    public FDatUnitPersonaEntry* GetPersona(int i)
    {
        fixed (FDatUnitPersona* self = &this) { return &((FDatUnitPersonaEntry*)((nint)self + 0x4))[i]; }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0xA)]
public unsafe struct FDatUnitItem
{
    [FieldOffset(0x0000)] public ushort equip;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct FDatUnitSpecialSkill
{
    [FieldOffset(0x0000)] public ushort skillId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2B4)]
public unsafe struct FDatUnitWork
{
    [FieldOffset(0x0000)] public uint flags;
    [FieldOffset(0x0004)] public ushort genus;
    [FieldOffset(0x0008)] public uint ID;
    [FieldOffset(0x000C)] public FDatUnitStatus Status;
    [FieldOffset(0x002C)] public FDatUnitSupport support;
    [FieldOffset(0x0048)] public FDatUnitPersona persona;
    [FieldOffset(0x028C)] public FDatUnitItem Item;
    [FieldOffset(0x0296)] public ushort Operation;
    [FieldOffset(0x0298)] public ushort Message;
    [FieldOffset(0x029A)] public short maxHpUp;
    [FieldOffset(0x029C)] public short maxSpUp;
    [FieldOffset(0x029E)] public FDatUnitSpecialSkill specialSkill;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1d78)]
public unsafe struct ItemBag
{
    public byte GetWeaponCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self))[i]; } } // 1024 entries
    public byte GetArmorCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self) + 0x400)[i]; } } // 1024 entries
    public byte GetArmorFootwearCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self) + 0x800)[i]; } } // 1024 entries
    public byte GetAccessoryCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self) + 0xc00)[i]; } } // 512 entries
    public byte GetConsumableCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self) + 0xe00)[i]; } } // 1024 entries
    public byte GetMiscItemCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self) + 0x1200)[i]; } } // 256 entries
    public byte GetMaterialCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self) + 0x1300)[i]; } } // 1024 entries
    public byte GetSkillCardCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self) + 0x1700)[i]; } } // 1024 entries
    public byte GetOutfitCount(int i) { fixed (ItemBag* self = &this) { return ((byte*)((nint)self) + 0x1b00)[i]; } } // 512 entries
    public uint GetItemFlag(int i) { fixed (ItemBag* self = &this) { return ((uint*)((nint)self) + 0x1d00)[i]; } } // 30 entries
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct CmmEntry
{
    [FieldOffset(0x0)] public ushort Rank;
    [FieldOffset(0x2)] public ushort Points;
}

[StructLayout(LayoutKind.Explicit, Size = 0xc8)]
public unsafe struct CmmData
{
    public CmmEntry* GetCounter(uint i) { fixed (CmmData* self = &this) { return &((CmmEntry*)self)[i]; } }
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct Calendar
{
    [FieldOffset(0x0)] public uint DaysSinceApril1;
    [FieldOffset(0x4)] public ECldTimeZone TimeOfDay;
    [FieldOffset(0x8)] public uint NextTimeskipDay;
    [FieldOffset(0xc)] public ECldTimeZone NextTimeskipTime;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct MailInner
{
    [FieldOffset(0x0)] public ushort MailIncomingKey;
    [FieldOffset(0x2)] public byte Read;
}

[StructLayout(LayoutKind.Explicit, Size = 0x184)]
public unsafe struct Mail
{
    [FieldOffset(0xa0)] public int MailCount;

    public MailInner* GetMailEntry(uint i) { fixed (Mail* self = &this) { return &((MailInner*)self)[i]; } }
}

[StructLayout(LayoutKind.Explicit, Size = 0x15c)]
public unsafe struct CharacterName
{
    public string GetFirstName() { fixed (CharacterName* self = &this) { return Marshal.PtrToStringAnsi((nint)self + 0x58); } }
    public string GetLastName() { fixed (CharacterName* self = &this) { return Marshal.PtrToStringAnsi((nint)self + 0x98); } }
    public string GetFullName() { fixed (CharacterName* self = &this) { return Marshal.PtrToStringAnsi((nint)self + 0xd8); } }
}

[StructLayout(LayoutKind.Explicit, Size = 0x250E0)]
public unsafe struct UGlobalWork //: public UGameInstance
{
    [FieldOffset(0x0)] public UGameInstance Super;
    //[FieldOffset(0x1b0)] public FDatUnitWork PlayerCharacters[11]; // 10100_3 to 10109_3
    //[FieldOffset(0x1f6c)] public ushort ActiveCharacters[10]; // 10050_1
    [FieldOffset(0x1f80)] public ItemBag Items; // 10051_1
    [FieldOffset(0x3cf8)] public uint Money; // 10052_1
    //[FieldOffset(0x3cfc)] public byte Section0[384]; // 10000_1
    //[FieldOffset(0x3e7c)] public byte Section1[384]; // 10001_2
    //[FieldOffset(0x3ffc)] public byte Section2[640]; // 10002_1
    //[FieldOffset(0x427c)] public byte Section3[64]; // 10003_1
    //[FieldOffset(0x42bc)] public byte Section4[64]; // 10004_1
    //[FieldOffset(0x42fc)] public byte Section5[64]; // 10005_1
    //[FieldOffset(0x433c)] public int Counters[384]; // 10010_1
    //[FieldOffset(0x439c)] public FDatUnitPersona Personas[464]; // 10053_1
    //[FieldOffset(0xa03c)] public byte Analysis[828]; // 10054_1
    [FieldOffset(0xa378)] public Calendar Calendar; // 10030_1
    //[FieldOffset(0xa388)] public byte Shop[7424];
    [FieldOffset(0xc168)] public CharacterName Name; // 10061_4
    [FieldOffset(0xc2c4)] public Mail Mail; // 10081_2

    [FieldOffset(0x24778)] public USequence* mSequenceInstance_;
    [FieldOffset(0x24780)] public UCalendar* mCalendarInstance_;
    [FieldOffset(0x24788)] public UCldCommonData* mCldCommonData_;
    [FieldOffset(0x24790)] public UFileNameManager* mFileNameData_;
    [FieldOffset(0x24798)] public UFldCommonData* mFldCommonData_;
    [FieldOffset(0x247A0)] public UDatItem* mItemData_;
    [FieldOffset(0x247A8)] public UTrophyManager* mTrophy_;
    [FieldOffset(0x247B0)] public ULeaderBoardManager* mLeaderBoard_;
    [FieldOffset(0x247B8)] public USignedInDialog* mSignedInDialog_;
    [FieldOffset(0x247C0)] public UErrorDialog* mErrorDialog_;
    [FieldOffset(0x247C8)] public UMessageDialog* mMessageDialog_;
    [FieldOffset(0x247D0)] public UBustupController* pBustupController;
    [FieldOffset(0x247D8)] public UCommunityWork* pCommunityWork;
    [FieldOffset(0x247E0)] public UMsgWork* pMsgWork;
    [FieldOffset(0x247E8)] public UEvtDataLoad* pEvtDataLoad;
    //[FieldOffset(0x247F0)] public UFrameBufferCapture* pFrameBufferCapture;
    [FieldOffset(0x247F8)] public UPadRumble* pPadRumble;
    [FieldOffset(0x248C8)] public UFldCharParamTable* mFldCharParamTable_;
    //[FieldOffset(0x248D0)] public UAppCharFootstepsTable* mFootstepsTable_;
    //[FieldOffset(0x248D8)] public UAppCharacterPoolManager* mCharacterPoolManager_;
    //[FieldOffset(0x248E0)] public UDatSystemText* mSystemTextTable;
    //[FieldOffset(0x248E8)] public UDatUIUseText* mUIUseTextTable;
    //[FieldOffset(0x248F0)] public UDatUICalendarText* mUICalendarTextTable;
    [FieldOffset(0x248F8)] public UXrd777SaveManager* mSaveManager_;
    //[FieldOffset(0x24900)] public UAddContent* mAddContent_;
    //[FieldOffset(0x24F78)] public ULoading* pLoadingInst;
    [FieldOffset(0x24F80)] public ACmpMainActor* mCmpMainActor_;
    //[FieldOffset(0x24F88)] public ABtlGuiResourcesBase* mBtlGuiResourcesActor_;
    //[FieldOffset(0x24F90)] public UBtlEncountWipeLoader* mBtlEncountWipeLoader_;
    //[FieldOffset(0x24F98)] public ABtlEncountWipeCore* mBtlEncountWipeCore_;
    //[FieldOffset(0x24FA0)] public AFldLevelPoolManager* mLevelPoolManager_;
    [FieldOffset(0x24FA8)] public bool mPoolSetting_;
    [FieldOffset(0x24FE8)] public FSaveGameHeadder mTempSaveHeader_;
    [FieldOffset(0x250B8)] public bool bTempSaveHeaderUsed_;
    [FieldOffset(0x250C0)] public UGlobalGameData* mGameDataProc_;
    [FieldOffset(0x250C8)] public AAppActor* mSystemMonitor_;

    public FDatUnitWork* GetUnit(int i) { fixed (UGlobalWork* self = &this) { return &((FDatUnitWork*)((nint)self + 0x1b0))[i]; } }

    public List<short> GetActiveCharacters()
    {
        List<short> ids = new();
        fixed (UGlobalWork* self = &this)
        {
            for (int i = 0; i < 10; i++)
            {
                var curr_mem = ((short*)((nint)self + 0x1f6c))[i];
                if (curr_mem == 0) break;
                ids.Add(curr_mem);
            }
        }
        return ids;
    }

    public bool GetBitflag(uint id)
    {
        uint section = id >> 0x1c;
        uint flag_int = (id >> 5 & 0x7fffff);
        uint flag_bit = (uint)(1 << ((int)id & 0x1f));
        fixed (UGlobalWork* self = &this)
        {
            switch (section)
            {
                case 0: return ((int*)((nint)self + 0x3cfc))[flag_int] % flag_bit == 1 ? true : false;
                case 1: return ((int*)((nint)self + 0x3e7c))[flag_int] % flag_bit == 1 ? true : false;
                case 2: return ((int*)((nint)self + 0x3ffc))[flag_int] % flag_bit == 1 ? true : false;
                case 3: return ((int*)((nint)self + 0x427c))[flag_int] % flag_bit == 1 ? true : false;
                case 4: return ((int*)((nint)self + 0x42bc))[flag_int] % flag_bit == 1 ? true : false;
                case 5: return ((int*)((nint)self + 0x42fc))[flag_int] % flag_bit == 1 ? true : false;
                default: return false;
            }
        }
    }

    public int GetCounter(uint i) { fixed (UGlobalWork* self = &this) { return ((int*)((nint)self + 0x433c))[i]; } }

    public FDatUnitPersonaEntry* GetPersona(uint i) { fixed (UGlobalWork* self = &this) { return &((FDatUnitPersonaEntry*)((nint)self + 0x439c))[i]; } }
};

public unsafe class GlobalWork : IGlobalWork
{
    private UGlobalWork* Data;
    public GlobalWork(UGlobalWork* _Data) { Data = _Data; }
    private UGlobalWork* Self() => Data;
    public FDatUnitWork* GetUnit(int i) => &((FDatUnitWork*)((nint)Self() + 0x1b0))[i];

    public List<short> GetActiveCharacters()
    {
        List<short> ids = new();
        for (int i = 0; i < 10; i++)
        {
            var curr_mem = ((short*)((nint)Self() + 0x1f6c))[i];
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
            case 0: return ((int*)((nint)Self() + 0x3cfc))[flag_int] % flag_bit == 1 ? true : false;
            case 1: return ((int*)((nint)Self() + 0x3e7c))[flag_int] % flag_bit == 1 ? true : false;
            case 2: return ((int*)((nint)Self() + 0x3ffc))[flag_int] % flag_bit == 1 ? true : false;
            case 3: return ((int*)((nint)Self() + 0x427c))[flag_int] % flag_bit == 1 ? true : false;
            case 4: return ((int*)((nint)Self() + 0x42bc))[flag_int] % flag_bit == 1 ? true : false;
            case 5: return ((int*)((nint)Self() + 0x42fc))[flag_int] % flag_bit == 1 ? true : false;
            default: return false;
        }
    }
    public int GetCounter(uint i) => ((int*)((nint)Self() + 0x433c))[i];
    public FDatUnitPersonaEntry* GetPersona(uint i) => &((FDatUnitPersonaEntry*)((nint)Self() + 0x439c))[i];
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

public interface IGlobalWork
{
    public unsafe FDatUnitWork* GetUnit(int i);
    public List<short> GetActiveCharacters();
    public bool GetBitflag(uint id);
    public int GetCounter(uint i);
    public unsafe FDatUnitPersonaEntry* GetPersona(uint i);
    public unsafe Mail* GetMail();
    public unsafe Calendar* GetCalendar();
    public unsafe USequence* GetSequenceInstance();
    public unsafe UCalendar* GetCalendarInstance();
    public unsafe UCldCommonData* GetCldCommonData();
    public unsafe UFileNameManager* GetFileNameData();
    public unsafe UFldCommonData* GetFldCommonData();
    public unsafe UDatItem* GetItemData();
    public unsafe UTrophyManager* GetTrophy();
    public unsafe ULeaderBoardManager* GetLeaderBoard();
    public unsafe USignedInDialog* GetSignedInDialog();
    public unsafe UErrorDialog* GetErrorDialog();
    public unsafe UMessageDialog* GetMessageDialog();
    public unsafe UBustupController* GetBustupController();
    public unsafe UCommunityWork* GetCommunityWork();
    public unsafe UMsgWork* GetMsgWork();
    public unsafe UEvtDataLoad* GetEvtDataLoad();
}

[StructLayout(LayoutKind.Explicit, Size = 0x64)]
public unsafe struct SprDefStruct1
{
    [FieldOffset(0x0)] public FVector2D Position;
    
    [FieldOffset(0x8)] public float Field08;
    [FieldOffset(0xC)] public float Field0C;
    [FieldOffset(0x10)] public float Field10;
    [FieldOffset(0x14)] public float Field14;
    [FieldOffset(0x18)] public FSprColor color;
    [FieldOffset(0x1C)] public float Field1C;
    [FieldOffset(0x20)] public FVector4 Size;
    [FieldOffset(0x30)] public float Field30;
    [FieldOffset(0x34)] public float Field34;
    [FieldOffset(0x38)] public float Field38;
    [FieldOffset(0x3c)] public float Field3C;
    [FieldOffset(0x40)] public float Field40;
    [FieldOffset(0x44)] public float Field44;
    [FieldOffset(0x48)] public uint Field48;
    [FieldOffset(0x4c)] public int SpriteIndex2;
    [FieldOffset(0x64)] public int SpriteIndex;

    [FieldOffset(0x0)] public FVector PositionEx;
    [FieldOffset(0xc)] public FVector Stretch;

    public SprDefStruct1(FVector2D Position, float Field08, float Field0C, float Field10, float Field14, FSprColor color, float Field1C,
        FVector4 Size, float Field30, float Field34, float Field38, float Field3C, float Field40, float Field44, int spriteIndex)
    {
        this.Position = Position;
        this.Field08 = Field08;
        this.Field0C = Field0C;
        this.Field10 = Field10;
        this.Field14 = Field14;
        this.color = color;
        this.Field1C = Field1C;
        this.Size = Size;
        this.Field30 = Field30;
        this.Field34 = Field34;
        this.Field38 = Field38;
        this.Field3C = Field3C;
        this.Field40 = Field40;
        this.Field44 = Field44;
        this.Field48 = 0;
        this.SpriteIndex = spriteIndex;
        this.SpriteIndex2 = SpriteIndex;
    }

    public SprDefStruct1(int spriteIndex, FVector2D Position, FSprColor color, float Field0C, float Field08, float Field14)
    {
        Size = new FVector4(960, 540, 0, 1);
        Field30 = 0;
        Field34 = 0;
        this.Field14 = Field14;
        Field40 = 1;
        Field44 = 0;
        Field38 = 0;
        Field3C = 1;
        Field48 = 0;
        Field1C = 1;
        this.color = color;
        this.Position = Position;
        this.Field0C = Field0C;
        Field10 = Field0C;
        this.Field08 = Field08;
        this.SpriteIndex = spriteIndex;
        this.SpriteIndex2 = SpriteIndex;
    }

    public SprDefStruct1(int spriteIndex, FVector position, FVector stretch, FSprColor color, float Field1C, float Field30, float Field34, float Field38, float Field3C, float Field40, float Field44)
    {
        Size = new FVector4(960, 540, 0, 1);
        this.Field30 = Field30;
        this.Field34 = Field34;
        this.Field40 = Field40;
        this.Field44 = Field44;
        this.Field38 = Field38;
        this.Field3C = Field3C;
        this.Field1C = Field1C;
        this.color = color;
        PositionEx = position;
        Stretch = stretch;
        this.SpriteIndex = spriteIndex;
        this.SpriteIndex2 = SpriteIndex;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct PlgDefStruct1
{
    [FieldOffset(0x0)] public FVector Position;
    [FieldOffset(0xc)] public FVector Stretch;
    [FieldOffset(0x18)] public FVector Rotation;
    [FieldOffset(0x24)] public FSprColor Color;
    [FieldOffset(0x28)] public int VertexIndex;
    [FieldOffset(0x2c)] public FVector4 Size;
    [FieldOffset(0x3c)] public int Field3C;

    public PlgDefStruct1(FVector position, FVector stretch, FVector rotation, FSprColor color, int vertexIndex)
    {
        Position = position;
        Stretch = stretch;
        Rotation = rotation;
        Color = color;
        VertexIndex = vertexIndex;
        Size = new FVector4(960, 540, 0, 1);
        Field3C = 0;
    }

    public void SetColor(FSprColor color) => Color = color;
}

// MESSAGE BOX

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct FMsgItemInfo
{
}; // Size: 0x10

[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe struct UMsgProcWindowBase //: public UObject
{
    [FieldOffset(0x88)] public byte MessageBoxStatus;
    [FieldOffset(0x90)] public UMsgItem* pMsgWork;                                                         // 0x0090 (size: 0x8)
    [FieldOffset(0x98)] public UTutorialManager* pTutorialManager;                                         // 0x0098 (size: 0x8)

}; // Size: 0x108

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct UMsgItem //: public UObject
{
    [FieldOffset(0x28)] public FCurrentBmdPage* CurrentPage;
    [FieldOffset(0x30)] public FCurrentBmdPage* CurrentSpeaker;
    [FieldOffset(0x0068)] public TArray<FMsgItemInfo> MssageList;
    [FieldOffset(0x0078)] public TArray<FMsgItemInfo> SpeakerList;
    [FieldOffset(0x0088)] public UMsgProcWindowBase* mpMsgProcWindow;
};

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct UMsgAssist //: public UMsgItem
{
}; // Size: 0xB0

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct UMsgDLC //: public UMsgItem
{
}; // Size: 0xC8
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct UMsgDictionary //: public UMsgItem
{
}; // Size: 0xC8
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct UMsgMessage //: public UMsgItem
{
}; // Size: 0xB0
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe struct UMsgMind //: public UMsgItem
{
}; // Size: 0xC0
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe struct UMsgMindSubtitles //: public UMsgItem
{
    [FieldOffset(0x0100)] public UTexture* pTexture;
    [FieldOffset(0x0108)] public UAssetLoader* pAssetLoader;
}; // Size: 0x110
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe struct UMsgPerformance //: public UMsgItem
{
}; // Size: 0xE0
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe struct UMsgSubtitles //: public UMsgItem
{
}; // Size: 0xD0
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe struct UMsgSystem //: public UMsgItem
{
}; // Size: 0xE8
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct UMsgTutorial //: public UMsgItem
{
}; // Size: 0xC8

public enum EMsgProcWindowLayout_ASSIST
{
    ASSIST_POSITION = 0,
    LINE_SPACE_OFFSET = 1,
    SUPPORT_INTERVAL = 2,
};

public enum EMsgProcWindowLayout_DIALOG
{
    TITLE_TEXT = 0,
    MAIN_TEXT = 1,
};

public enum EMsgProcWindowLayout_MIND
{
    MSG_OFFSET = 0,
    MSG_ROW = 1,
    SELECT_OFS = 2,
};

public enum EMsgProcWindowLayout_SELECT
{
    SELECT_TEXT_COL = 0,
    NON_SELECT_TEXT_COL = 1,
    SELECT_TEXT_OFFSET = 2,
    NON_SELECT_TEXT_OFFSET = 3,
};

public enum EMsgProcWindowLayout_SIMPLE
{
    MSG_TEXT_COL = 0,
    MSG_OFFSET = 1,
    MSG_ROW = 2,
};

public enum EMsgProcWindowTextColLayout_ASSIST
{
    TEXT_SIZE = 0,
};
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe struct UTutorialManager //: public UObject
{
    [FieldOffset(0x0048)] public UAssetLoader* pAssetLoader;
    [FieldOffset(0x0050)] public UBmdAsset* pBmdAsset;
    [FieldOffset(0x0058)] public TArray<nint> Textures;
    [FieldOffset(0x0068)] public TArray<FString> Paths;

}; // Size: 0x78
[StructLayout(LayoutKind.Explicit, Size = 0x528)]
public unsafe struct AitfMsgProgWindow_TUTRIALDraw //: public AUIDrawBaseActor
{
    [FieldOffset(0x02B8)] public float FadeInNonThumbnailMovePosFrame;
    [FieldOffset(0x02BC)] public float FadeInWaitNonThumbnailMovePosFrame;
    [FieldOffset(0x02C0)] public float FadeOutNonThumbnailMovePosFrame;
    [FieldOffset(0x02C4)] public float FadeOutWaitNonThumbnailMovePosFrame;
    [FieldOffset(0x02C8)] public float FadeInNonThumbnailAlphaFrame;
    [FieldOffset(0x02CC)] public float FadeInWaitNonThumbnailAlphaFrame;
    [FieldOffset(0x02D0)] public float FadeOutNonThumbnailAlphaFrame;
    [FieldOffset(0x02D4)] public float FadeOutWaitNonThumbnailAlphaFrame;
    [FieldOffset(0x02D8)] public float FadeInThumbnailMovePosFrame;
    [FieldOffset(0x02DC)] public float FadeInWaitThumbnailMovePosFrame;
    [FieldOffset(0x02E0)] public float FadeOutThumbnailMovePosFrame;
    [FieldOffset(0x02E4)] public float FadeOutWaitThumbnailMovePosFrame;
    [FieldOffset(0x02E8)] public float FadeInThumbnailAlphaFrame;
    [FieldOffset(0x02EC)] public float FadeInWaitThumbnailAlphaFrame;
    [FieldOffset(0x02F0)] public float FadeOutThumbnailAlphaFrame;
    [FieldOffset(0x02F4)] public float FadeOutWaitThumbnailAlphaFrame;
    [FieldOffset(0x02F8)] public float FadeInThumbnailAngleFrame;
    [FieldOffset(0x02FC)] public float FadeInWaitThumbnailAngleFrame;
    [FieldOffset(0x0300)] public float FadeOutThumbnailAngleFrame;
    [FieldOffset(0x0304)] public float FadeOutWaitThumbnailAngleFrame;
    [FieldOffset(0x0308)] public float FixThumbnailAngle;
    [FieldOffset(0x030C)] public float FixThumbnailPosX;
    [FieldOffset(0x0310)] public float FixThumbnailPosY;
    [FieldOffset(0x0314)] public float FixThumbnailPlusAngle;
    [FieldOffset(0x0318)] public float FadeInGroundAlphaFrame;
    [FieldOffset(0x031C)] public float FadeInWaitGroundAlphaFrame;
    [FieldOffset(0x0320)] public float FadeOutGroundAlphaFrame;
    [FieldOffset(0x0324)] public float FadeOutWaitGroundAlphaFrame;
    [FieldOffset(0x0328)] public FColor NavyColor;
    [FieldOffset(0x032C)] public FColor GradationColor;
    [FieldOffset(0x0330)] public FColor UnderShadowColor;
    [FieldOffset(0x0334)] public FColor BackColor;
    [FieldOffset(0x0338)] public float PageOutButtonFrame;
    [FieldOffset(0x033C)] public float PageOutWaitButtonFrame;
    [FieldOffset(0x0340)] public float PageInButtonFrame;
    [FieldOffset(0x0344)] public float PageInWaitButtonFrame;
    [FieldOffset(0x0348)] public float PageOutTextFrame;
    [FieldOffset(0x034C)] public float PageOutWaitTextFrame;
    [FieldOffset(0x0350)] public float PageInTextFrame;
    [FieldOffset(0x0354)] public float PageInWaitTextFrame;
    [FieldOffset(0x0358)] public float PageOutTextAlphaFrame;
    [FieldOffset(0x035C)] public float PageOutWaitTextAlphaFrame;
    [FieldOffset(0x0360)] public float PageInTextAlphaFrame;
    [FieldOffset(0x0364)] public float PageInWaitTextAlphaFrame;
    [FieldOffset(0x0368)] public float PageOutThumbnailFrame;
    [FieldOffset(0x036C)] public float PageOutWaitThumbnailFrame;
    [FieldOffset(0x0370)] public float PageInThumbnailFrame;
    [FieldOffset(0x0374)] public float PageInWaitThumbnailFrame;
    [FieldOffset(0x0378)] public float InWaitThumbnailShadowFrame;
    [FieldOffset(0x037C)] public float InThumbnailShadowFrame;
    [FieldOffset(0x0380)] public int MaskLoopWaitFrameFirst;
    [FieldOffset(0x0384)] public int MaskLoopWaitFrameSecond;
    [FieldOffset(0x0388)] public int MaskLoopWaitFrameThird;
    [FieldOffset(0x038C)] public int MaskLoopMoveFrameFirst;
    [FieldOffset(0x0390)] public int MaskLoopMoveFrameSecond;
    [FieldOffset(0x0394)] public int MaskLoopMoveFrameThird;
    [FieldOffset(0x0398)] public int ButtonScaleWaitFrameFirst;
    [FieldOffset(0x039C)] public int ButtonScaleWaitFrameSecond;
    [FieldOffset(0x03A0)] public int ButtonScaleWaitFrameThird;
    [FieldOffset(0x03A4)] public int ButtonScaleMoveFrameFirst;
    [FieldOffset(0x03A8)] public int ButtonScaleMoveFrameSecond;
    [FieldOffset(0x03AC)] public int ButtonScaleMoveFrameThird;
    [FieldOffset(0x03B0)] public int Edit_Icon_Animation_Start_Delay;
    [FieldOffset(0x03B4)] public int Edit_Icon_Angle_Frame;
    [FieldOffset(0x03B8)] public int Edit_Icon_Angle_Delay;
    [FieldOffset(0x03BC)] public int Edit_Icon_Scale_1Loop_Frame;
}; // Size: 0x528

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct USelItem //: public UObject
{
    [FieldOffset(0x40)] public uint selIndex;
    [FieldOffset(0x48)] public uint selCount;
    [FieldOffset(0x50)] public TArray<nint> selEntries; // TArray<SelBoxStruct2*>
    [FieldOffset(0x00A0)] UMsgProcWindow_Select* mpSelProcWindow;
}; // Size: 0xB0
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct SelBoxStruct1
{
    [FieldOffset(0x0)] public int selIndex;
    [FieldOffset(0x4)] public int field04;
    [FieldOffset(0x8)] public int selCount;
    [FieldOffset(0xc)] public int selType; // 0 = mind, 1 = simple
    [FieldOffset(0x10)] public TArray<nint> selEntries; // TArray<SelBoxStruct2*>
}
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public struct SelBoxStruct2
{

}
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct UBustupAnimDataAsset //: public UAppMultiDataAsset
{
    [FieldOffset(0x0030)] public TArray<FBustupAnim> EyeAnim;
    [FieldOffset(0x0040)] public TArray<FBustupMouthAnim> MouthAnim;

}; // Size: 0x50
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct USupportBustupDataAsset //: public UAppDataAsset
{
    [FieldOffset(0x30)] TArray<FSupportBustupParam> Data;
}; // Size: 0x40

public struct FBustupAnim
{
    byte Type;                                                                       // 0x0000 (size: 0x1)
    float Duration;                                                                   // 0x0004 (size: 0x4)
    float Random;                                                                     // 0x0008 (size: 0x4)

}; // Size: 0xC

public struct FBustupMouthAnim
{
    TArray<FBustupAnim> Anim;                                                         // 0x0000 (size: 0x10)

}; // Size: 0x10

public struct FSupportBustupParam
{
    ushort CharaID;                                                                   // 0x0000 (size: 0x2)
    FString Pose;                                                                     // 0x0008 (size: 0x10)
    float OffsetLeft_X;                                                               // 0x0018 (size: 0x4)
    float OffsetLeft_Y;                                                               // 0x001C (size: 0x4)
    float MaskOffsetLeft_Y;                                                           // 0x0020 (size: 0x4)
    float OffsetRight_X;                                                              // 0x0024 (size: 0x4)
    float OffsetRight_Y;                                                              // 0x0028 (size: 0x4)
    float MaskOffsetRight_Y;                                                          // 0x002C (size: 0x4)

}; // Size: 0x30

[StructLayout(LayoutKind.Explicit, Size = 0x128)]
public unsafe struct UBustupObject //: public UObject
{
    [FieldOffset(0x0028)] public UMaterialInterface* BaseMaterial_;
    [FieldOffset(0x0030)] public UMaterialInstanceDynamic* DrawableMaterial_;
    [FieldOffset(0x0038)] public UMaterialInstanceDynamic* ShadowMaterial;
    [FieldOffset(0x0040)] public UTexture* BaseTex_;
    [FieldOffset(0x0048)] public UTexture* ShadowMask_;
    [FieldOffset(0x0050)] public UTexture* RimLightMask_;
    [FieldOffset(0x0058)] public UTexture* EyeTex_;
    [FieldOffset(0x0070)] public UTexture* MouthTex_;
    [FieldOffset(0x0088)] public UTexture* BlushTex_;
    [FieldOffset(0x0090)] public UTexture* SweatTex_;
    [FieldOffset(0x0098)] public UTexture* BaseMask_;
    [FieldOffset(0x00A0)] public UTexture* DropMask_;
    [FieldOffset(0x00A8)] public UAssetLoader* Loader_;
    [FieldOffset(0xb0)] public byte FieldB0;
    [FieldOffset(0x0118)] public UBustupAnimDataAsset* BustupAnim_;
    [FieldOffset(0x0120)] public USupportBustupDataAsset* SupportBustupOffset_;

}; // Size: 0x128

[StructLayout(LayoutKind.Explicit, Size = 0x1D8)]
public unsafe struct UMsgProcWindow_Assist //: public UMsgProcWindowBase
{
    [FieldOffset(0x0108)] public UAssetLoader* Loader_;
    [FieldOffset(0x0110)] public USprAsset* MsgSpr_;
    [FieldOffset(0x0118)] public TArray<FVector> SupportPos;
    [FieldOffset(0x18c)] public float Opacity;
}; // Size: 0x1D8

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct BmdDataLetter
{
    // 0x0: utf8Character
    [FieldOffset(0x14)] public FSprColor color;
    [FieldOffset(0x20)] public BmdDataLetter* prev;
    [FieldOffset(0x28)] public BmdDataLetter* next;
}

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct FCurrentBmdCharacterOverview
{
    [FieldOffset(0x8)] public int Id;
    [FieldOffset(0x20)] public ulong LetterCount;
    [FieldOffset(0x28)] public BmdDataLetter* FirstCharacter;
    [FieldOffset(0x30)] public BmdDataLetter* LastCharacter;
    [FieldOffset(0x40)] public FCurrentBmdCharacterOverview* Previous;
    [FieldOffset(0x48)] public FCurrentBmdCharacterOverview* Next;
    [FieldOffset(0x48)] public nint Field48;
}
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe struct FCurrentBmdPage
{
    [FieldOffset(0x4)] public int LineCount;
    [FieldOffset(0x18)] public nint BmdBufferStart;
    [FieldOffset(0x20)] public nint BmdBufferPage;
    [FieldOffset(0x28)] public FCurrentBmdCharacterOverview* CharacterData;
    [FieldOffset(0x30)] public uint cursorPos;
    [FieldOffset(0x3c)] public FSprColor baseColor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x228)]
public unsafe struct UMsgProcWindow_Mind //: public UMsgProcWindowBase
{
    [FieldOffset(0x0108)] public UAssetLoader* Loader_;
    [FieldOffset(0x0110)] public UMaterial* ReadMat_;
    [FieldOffset(0x0118)] public UMaterial* ReadaddMat_;
    [FieldOffset(0x0120)] public UMaterial* ReadblurMat_;
    [FieldOffset(0x0128)] public UMaterialInstanceDynamic* ReadMatInst_;
    [FieldOffset(0x0130)] public UMaterialInstanceDynamic* ReadaddMatInst_;
    [FieldOffset(0x0138)] public UMaterialInstanceDynamic* ReadblurMatInst_;
    [FieldOffset(0x0140)] public USprAsset* _readSpr;
    [FieldOffset(0x0148)] public UPlgAsset* MsgPlg_;
    [FieldOffset(0x150)] public UMsgProcWindow_Simple_NextPageParams NextPage;
    [FieldOffset(0x190)] public float leftSpotBgOpacity1;
    [FieldOffset(0x1a4)] public float leftSpotBgOpacity2;
    [FieldOffset(0x1ec)] public FLinearColor OuterBorderColor;
    [FieldOffset(0x1fc)] public FLinearColor InnerContentsColor;
    [FieldOffset(0x20c)] public FLinearColor OutsideMistColor;
    [FieldOffset(0x0220)] public UUILayoutDataTable* LayoutDataTable;
}; // Size: 0x228

[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe struct UMsgProcWindow_Performance //: public UMsgProcWindowBase
{
    [FieldOffset(0x0108)] public UAssetLoader* m_pPerformanceLoader;
    [FieldOffset(0x0110)] public AitfMsgProgWindow_TUTRIALDraw* PerformanceDrawClass;
    [FieldOffset(0x0118)] public AitfMsgProgWindow_TUTRIALDraw* pPerformanceDraw;
    [FieldOffset(0x0120)] public UDataTable* TextColDataTable;
    [FieldOffset(0x0128)] public UUILayoutDataTable* TextColLayoutDataTable;
    [FieldOffset(0x0130)] public UDataTable* OkNextLayoutData;
    [FieldOffset(0x0138)] public UUILayoutDataTable* OkNextLayoutDataTable;
    [FieldOffset(0x0140)] public UDataTable* OkNextMaskLayoutData;
    [FieldOffset(0x0148)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
}; // Size: 0x158

[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe struct UMsgProcWindow_Select //: public UMsgProcWindowBase
{
    [FieldOffset(0x0108)] public USelItem* pSelWork;
}; // Size: 0x110

[StructLayout(LayoutKind.Explicit, Size = 0x238)]
public unsafe struct UMsgProcWindow_Select_Mind //: public UMsgProcWindow_Select
{
    [FieldOffset(0x0128)] public UBustupObject* BustupObject_;
    [FieldOffset(0x0130)] public USprAsset* MsgSpr_;
    [FieldOffset(0x0138)] public UPlgAsset* MsgPlg_;
    [FieldOffset(0x0228)] public UAssetLoader* Loader_;
    [FieldOffset(0x0230)] public UUILayoutDataTable* LayoutDataTable;
}; // Size: 0x238

[StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
public unsafe struct UMsgProcWindow_Select_Simple //: public UMsgProcWindow_Select
{
    [FieldOffset(0x124)] public float speechShadowOffsetX;
    [FieldOffset(0x128)] public FVector2D speechShadowMod;
    [FieldOffset(0x130)] public float speechShadowOpacity;
    [FieldOffset(0x138)] public float speechShadowRotation;
    [FieldOffset(0x13c)] public float bustupMainX;
    [FieldOffset(0x140)] public float bustupShadowX;
    [FieldOffset(0x144)] public FVector2D scrollbarOffset1;
    [FieldOffset(0x14c)] public FVector2D scrollbarOffset2;
    [FieldOffset(0x154)] public FVector2D selBoxFill;
    [FieldOffset(0x16c)] public FVector2D selBoxShadow;
    [FieldOffset(0x188)] public int BRIndex1;
    [FieldOffset(0x18c)] public int BRIndex2;
    [FieldOffset(0x0190)] public UBustupObject* BustupObject_;
    [FieldOffset(0x0198)] public USprAsset* MsgSpr_;
    [FieldOffset(0x01A0)] public UPlgAsset* MsgPlg_;
    [FieldOffset(0x01A8)] public UUILayoutDataTable* LayoutDataTable;
}; // Size: 0x1D0

[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public unsafe struct UMsgProcWindow_Simple_NextPageParams
{
    [FieldOffset(0x1c)] public FSprColor NextPageColor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1B8)]
public unsafe struct UMsgProcWindow_Simple //: public UMsgProcWindowBase
{
    [FieldOffset(0x0108)] public UAssetLoader* Loader_;
    [FieldOffset(0x0110)] public USprAsset* MsgSpr_;
    [FieldOffset(0x0118)] public UPlgAsset* MsgPlg_;
    [FieldOffset(0x120)] public UMsgProcWindow_Simple_NextPageParams NextPageParams;
    [FieldOffset(0x144)] public float Field144;
    [FieldOffset(0x158)] public float OffsetX;
    [FieldOffset(0x15c)] public float SizeX;
    [FieldOffset(0x160)] public float Opacity;
    [FieldOffset(0x164)] public float Field164;
    [FieldOffset(0x168)] public float BgPieceRotation;
    [FieldOffset(0x170)] public float PositionLerp;
    [FieldOffset(0x174)] public float BgPieceTransparency;
    [FieldOffset(0x180)] public uint MsgProcWindowStatus;
    [FieldOffset(0x184)] public int MessageBoxWidth;
    [FieldOffset(0x188)] public int MessageBoxHeight;
    [FieldOffset(0x18c)] public int MessageBoxSubWidth;
    [FieldOffset(0x190)] public int MessageBoxSubHeight;
    [FieldOffset(0x01B0)] public UUILayoutDataTable* LayoutDataTable;

    public unsafe bool ShowSpeakerName()
    {
        fixed (UMsgProcWindow_Simple* self = &this) { return self->IsMsgBoxSpeakerStatusValid() && self->HasSpeakerName(); }
    }
    public unsafe bool IsMsgBoxSpeakerStatusValid()
    {
        fixed (UMsgProcWindow_Simple* self = &this) { return (self->MsgProcWindowStatus & 4) != 0 && ((UMsgProcWindowBase*)self)->MessageBoxStatus != 3; }
    }
    public unsafe bool HasSpeakerName()
    {
        fixed (UMsgProcWindow_Simple* self = &this) { return ((UMsgProcWindowBase*)self)->pMsgWork->CurrentSpeaker != null; }
    }

}; // Size: 0x1B8

[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe struct UMsgProcWindow_System //: public UMsgProcWindowBase
{
    [FieldOffset(0x0108)] public UAssetLoader* m_pSystemLoader;
    [FieldOffset(0x0110)] public AitfMsgProgWindow_TUTRIALDraw* SystemDrawClass;
    [FieldOffset(0x0118)] public AitfMsgProgWindow_TUTRIALDraw* pSystemDraw;
    [FieldOffset(0x0120)] public UDataTable* TextColDataTable;
    [FieldOffset(0x0128)] public UUILayoutDataTable* TextColLayoutDataTable;
    [FieldOffset(0x0130)] public UDataTable* OkNextLayoutData;
    [FieldOffset(0x0138)] public UUILayoutDataTable* OkNextLayoutDataTable;
    [FieldOffset(0x0140)] public UDataTable* OkNextMaskLayoutData;
    [FieldOffset(0x0148)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
}; // Size: 0x158

[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe struct UMsgProcWindow_Tutorial //: public UMsgProcWindowBase
{
    [FieldOffset(0x0108)] public UAssetLoader* m_pTutrialLoader;
    [FieldOffset(0x0110)] public AitfMsgProgWindow_TUTRIALDraw* TutrialDrawClass;
    [FieldOffset(0x0118)] public AitfMsgProgWindow_TUTRIALDraw* pTutrialDraw;
    [FieldOffset(0x0120)] public UDataTable* TextColDataTable;
    [FieldOffset(0x0128)] public UUILayoutDataTable* TextColLayoutDataTable;
    [FieldOffset(0x0130)] public UDataTable* OkNextLayoutData;
    [FieldOffset(0x0138)] public UUILayoutDataTable* OkNextLayoutDataTable;
    [FieldOffset(0x0140)] public UDataTable* OkNextMaskLayoutData;
    [FieldOffset(0x0148)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
}; // Size: 0x158

public struct FSaveSlotItem
{
    int SlotNo;                                                                     // 0x0000 (size: 0x4)
    int Month;                                                                      // 0x0004 (size: 0x4)
    int Day;                                                                        // 0x0008 (size: 0x4)
    int PLV;                                                                        // 0x000C (size: 0x4)
    int Week;                                                                       // 0x0010 (size: 0x4)
    bool bHoliday;                                                                    // 0x0014 (size: 0x1)
    int PTimeHour;                                                                  // 0x0018 (size: 0x4)
    int PTimeMin;                                                                   // 0x001C (size: 0x4)
    int Diff;                                                                       // 0x0020 (size: 0x4)
    int MoonAge;                                                                    // 0x0024 (size: 0x4)
    int TimeZone;                                                                   // 0x0028 (size: 0x4)
    FString PlayerName;                                                               // 0x0030 (size: 0x10)
    FString LocationName;                                                             // 0x0040 (size: 0x10)
    bool bIsGoodEnd;                                                                  // 0x0050 (size: 0x1)
    bool bIsBadEnd;                                                                   // 0x0051 (size: 0x1)
    bool bIsLoaded;                                                                   // 0x0052 (size: 0x1)
    bool bHasData;                                                                    // 0x0053 (size: 0x1)
    bool bUseDefaultHeroName;                                                         // 0x0054 (size: 0x1)

}; // Size: 0x58

public enum ESaveDrawOpenType
{
    TYPE_FIELD = 0,
    TYPE_CAMP = 1,
    TYPE_TITLE = 2,
};

[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe struct ASaveLoadDraw //: public AUIDrawBaseActor
{
    [FieldOffset(0x02EC)] public int BootMode;
    [FieldOffset(0x02F0)] public bool bIsStartInAnim;
    [FieldOffset(0x02F1)] public bool bIsUseCapture;
    [FieldOffset(0x02F2)] public bool bIsOpenCamp;
    [FieldOffset(0x02F3)] public bool bIsUseScrollBar;
    [FieldOffset(0x02F4)] public bool bIsStartCloseAnim;
    [FieldOffset(0x02F8)] public int CursorIndex;
    [FieldOffset(0x02FC)] public int ListTopIndex;
    [FieldOffset(0x0300)] public int CurrentIndex;
    [FieldOffset(0x0308)] public TArray<FSaveSlotItem> SaveSlotItems;
    [FieldOffset(0x0318)] public ESaveDrawOpenType OpenType;
    [FieldOffset(0x031C)] public int AllSlotNum;
    [FieldOffset(0x0320)] public int CheckOverListIndex;
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe struct FGetUIParameter
{
    //[FieldOffset(0x0018)] public UUIParameterAsset* ParameterAsset;                                          //  (size: 0x8)
    //[FieldOffset(0x0020)] public TMap ParameterMap;                                                //  (size: 0x50)
    [FieldOffset(0x0070)] public UAssetLoader* AssetLoader;                                                  //  (size: 0x8)
}; // Size: 0x78

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FCurveLinearColorAnimation //: public FBaseCurveAnimation
{
    [FieldOffset(0x0028)] UCurveLinearColor* m_pCurveLinearColor;                                     //  (size: 0x8)

}; // Size: 0x30

[StructLayout(LayoutKind.Explicit, Size = 0x74)]
public unsafe struct LocationSelectParams1
{
    [FieldOffset(0x0)] public float Field00;
    [FieldOffset(0x4)] public float Field04;
    [FieldOffset(0x8)] public float Field08;
    [FieldOffset(0xc)] public float Field0C;
    [FieldOffset(0x10)] public float Field10;
    [FieldOffset(0x14)] public float Field14;
    [FieldOffset(0x18)] public float Field18;
    [FieldOffset(0x1C)] public float Field1C;
    [FieldOffset(0x20)] public float Field20;
    [FieldOffset(0x24)] public float Field24;
    [FieldOffset(0x28)] public float Field28;
    [FieldOffset(0x2C)] public float Field2C;
    [FieldOffset(0x30)] public float Field30;
    [FieldOffset(0x34)] public float Field34;
    [FieldOffset(0x38)] public float Field38;
    [FieldOffset(0x3c)] public FSprColor Color;
    [FieldOffset(0x40)] public float Field40;
    [FieldOffset(0x44)] public float Field44;
    [FieldOffset(0x48)] public float Field48;
    [FieldOffset(0x4c)] public float Field4C;
    [FieldOffset(0x50)] public float Field50;
    [FieldOffset(0x54)] public float Field54;
    [FieldOffset(0x58)] public float Field58;
    [FieldOffset(0x5c)] public ulong Field5C;
    [FieldOffset(0x64)] public ulong Field64;
    [FieldOffset(0x5c)] public FSprColor ColorCornerTopLeft;
    [FieldOffset(0x60)] public FSprColor ColorCornerTopRight;
    [FieldOffset(0x64)] public FSprColor ColorCornerBottomLeft;
    [FieldOffset(0x68)] public FSprColor ColorCornerBottomRight;
    [FieldOffset(0x6c)] public uint Field6C;
    [FieldOffset(0x70)] public uint Field70;
}

[StructLayout(LayoutKind.Explicit, Size = 0x11c0)]
public unsafe struct AUIMiscCheckDraw //: public AUIBaseActor
{
    [FieldOffset(0x02B8)] public USprAsset* m_pAlphaSpr;
    [FieldOffset(0x02C0)] public USprAsset* m_pKeySpr;
    [FieldOffset(0x02C8)] public UAssetLoader* m_pLoader;
    [FieldOffset(0x02D0)] public FCurveLinearColorAnimation m_tagMaxColorWave;
    [FieldOffset(0x0300)] public FGetUIParameter m_uip;
    [FieldOffset(0x354)] public SprDefStruct1 sprDefParamsAlpha;
    [FieldOffset(0x378)] public SprDefStruct1 sprDefParamsAlphaNew;
    [FieldOffset(0x448)] public SprDefStruct1 sprDefAlphaSpr1;
    [FieldOffset(0x4b0)] public SprDefStruct1 sprDefAlphaSpr2;
    [FieldOffset(0x518)] public SprDefStruct1 sprDefParamsKey1;
    [FieldOffset(0x580)] public SprDefStruct1 sprDefParamsKey2;
    [FieldOffset(0x808)] public LocationSelectParams1 checkBgFront;
    [FieldOffset(0x87c)] public LocationSelectParams1 checkBgBack;
    [FieldOffset(0x988)] public FSprColor CheckBgFrontBorderColor;
    [FieldOffset(0xae0)] public CheckDrawUIStruct1 FieldAE0;
    [FieldOffset(0x1198)] public UDataTable* LayoutData;
    [FieldOffset(0x11A0)] public UDataTable* TextLayoutData;
    [FieldOffset(0x11A8)] public UUILayoutDataTable* LayoutDataTable;
    [FieldOffset(0x11B0)] public UUILayoutDataTable* TextLayoutDataTable;
};

public unsafe struct FCurveFloatAnimation //: public FBaseCurveAnimation
{
    //UCurveFloat* m_pCurveFloat;                                                 // 0x0028 (size: 0x8)
}; // Size: 0x30

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct FFldShortcutData
{
    [FieldOffset(0x0000)] public short mShortcutIndex;                                                             //  (size: 0x2)
    [FieldOffset(0x0008)] public FString mName;                                                                    //  (size: 0x10)
    [FieldOffset(0x0018)] public bool mEnable;                                                                     //  (size: 0x1)

}; // Size: 0x30

[StructLayout(LayoutKind.Explicit, Size = 0xf0)]
public struct FShortcutItem
{
    [FieldOffset(0x0)] FFldShortcutData Data;                                                            // 0x0000 (size: 0x30)
}; // Size: 0xF0

[StructLayout(LayoutKind.Explicit, Size = 0x358)]
public unsafe struct UUILocationSelect //: public UObject
{
    [FieldOffset(0x0048)] public USprAsset* m_pMiniMapSpr;
    [FieldOffset(0x0050)] public UAssetLoader* m_pLoader;
    [FieldOffset(0x0058)] public FGetUIParameter m_tagUip;
    [FieldOffset(0x00D0)] public TArray<FShortcutItem> m_aShortcutList;
    [FieldOffset(0x0308)] public UDataTable* m_pLayoutData;
    [FieldOffset(0x0310)] public UUILayoutDataTable* m_pLayoutDataTable;
    [FieldOffset(0x0318)] public UDataTable* m_pLayoutData2;
    [FieldOffset(0x0320)] public UUILayoutDataTable* m_pLayoutDataTable2;

}; // Size: 0x358

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct CheckDrawUIStruct1
{
    [FieldOffset(0x14)] public byte Field14;
    [FieldOffset(0x20)] public float Field20;
    [FieldOffset(0x28)] public float Field28;
}

// https://helpx.adobe.com/au/photoshop/using/blending-modes.html
public enum UIComponentBlendType : uint
{
    None = 0,
    Multiply = 1,
    Add = 2,
    Subtract = 3,
    Divide = 4,
    Type5 = 5,
    NoneAddAlpha = 6,
    Add2 = 7,
    NoneAddAlpha2 = 8,
    Type9 = 9,
    None4 = 10,
    Multiply2 = 11,
    Add3 = 12
}
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct FBustupObjectBuffer
{
    UBustupObject* BustupObject;                                                // 0x0000 (size: 0x8)

}; // Size: 0x10

[StructLayout(LayoutKind.Explicit, Size = 0xf0)]
public unsafe struct UBustupDraw //: public UObject
{
    [FieldOffset(0x0038)] public UBustupObject* BustupObject_;                                               //  (size: 0x8)
    [FieldOffset(0x0040)] public UBustupObject* PrevBustupObject_;                                           //  (size: 0x8)
    [FieldOffset(0x0048)] public TArray<FBustupObjectBuffer> ObjectBuffer_;                                        //  (size: 0x10)

}; // Size: 0xF0

// CAMP SYSTEM SUBMENU

[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe struct UCmpSystem // : UCmpMenuBase
{
    [FieldOffset(0x0000)] public UCmpMenuBase baseObj;
    [FieldOffset(0x00A8)] public UCmpSystemDraw* pSystemDraw;
    [FieldOffset(0x00B0)] public UCmpSystemSystem* pSystemSystem;
    //[FieldOffset(0x00B8)] public AUISaveLoad* pSaveMenu;
    //[FieldOffset(0x00C0)] public AUITutorial* pTutorial;
    //[FieldOffset(0x00C8)] public AUIDictionary* pDictionary;
    //[FieldOffset(0x00D0)] public TSubclassOf<AUITutorialDraw> pTutorialDrawClass;
    //[FieldOffset(0x00D8)] public AUIConfiguration* pConfig;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1408)]
public unsafe struct UCmpSystemDraw // : UObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0048)] public TArray<nint> SubMenuMateDynamicAry;
    [FieldOffset(0x13F8)] public ACmpMainActor* pMainActor;
    [FieldOffset(0x1400)] public UCmpSystem* pParent;
}

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct UCmpSystemSystem // : UObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0040)] public ACmpMainActor* pCmpMainActor;
    //[FieldOffset(0x0048)] public AUISaveLoad* pSaveMenu;
    //[FieldOffset(0x0050)] public AUIRestore* pRestoreMenu;
}

[StructLayout(LayoutKind.Explicit, Size = 0x160)]
public unsafe struct UCmpSkill // : UCmpMenuBase
{
    [FieldOffset(0x0000)] public UCmpMenuBase baseObj;
    [FieldOffset(0x0100)] public UCmpSkillDraw* pSkillDraw;
    [FieldOffset(0x0108)] public UCmpSkillSystem* pSkillSystem;
}

[StructLayout(LayoutKind.Explicit, Size = 0x548)]
public unsafe struct UCmpSkillDraw // : UObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0038)] public ACmpMainActor* pMainActor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct UCmpSkillSystem // : UObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x240)]
public unsafe struct UCmpItem // : UCmpMenuBase
{
    [FieldOffset(0x0000)] public UCmpMenuBase baseObj;
    [FieldOffset(0x0188)] public UCmpItemSystem* PSystem;
    [FieldOffset(0x0190)] public UCmpItemDraw* pDraw;
    [FieldOffset(0x0198)] public APersonaStatus* pPersonaStatus;
}

[StructLayout(LayoutKind.Explicit, Size = 0x608)]
public unsafe struct UCmpItemDraw // : UObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0038)] public ACmpMainActor* pMainActor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct FItemListItem
{
    [FieldOffset(0x0)] public int ItemId;
    [FieldOffset(0x4)] public int ItemCount;
    [FieldOffset(0x8)] public int MsgToken;
    [FieldOffset(0xc)] public int bIsNew;
}

[StructLayout(LayoutKind.Explicit, Size = 0x798)]
public unsafe struct UCmpItemSystem // : UObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0768)] public TArray<short> PartyMemberList;
    [FieldOffset(0x0778)] public TArray<int> PersonaStockIDList;
    [FieldOffset(0x0788)] public TArray<FItemListItem> ItemList;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FEquipListItem
{
    [FieldOffset(0x0)] public uint ItemId;
    [FieldOffset(0x4)] public uint ItemCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe struct UCmpEquipSystem
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public TArray<short> PartyMemberList;
    [FieldOffset(0x0038)] public TArray<FEquipListItem> EquipList;
    [FieldOffset(0x0048)] public TArray<FEquipListItem> LastEquipList;
    [FieldOffset(0x0060)] public ACmpMainActor* pMainActor;
    [FieldOffset(0x0068)] public UCmpEquip* pParent;
}

[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public unsafe struct UCmpEquip
{
    [FieldOffset(0x0000)] public UCmpMenuBase baseObj;
    [FieldOffset(0x0278)] public UCmpEquipSystem* PSystem;
    [FieldOffset(0x0280)] public UCmpEquipDraw* pDraw;
}

[StructLayout(LayoutKind.Explicit, Size = 0x3528)]
public unsafe struct UCmpEquipDraw
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x34C0)] public ACmpMainActor* pMainActor;
    [FieldOffset(0x34C8)] public UCmpEquip* pParent;
}

[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe struct UCmpStatus // : UCmpMenuBase
{
    [FieldOffset(0x0000)] public UCmpMenuBase baseObj;
    [FieldOffset(0x0058)] public UUICmpStatus* Actor_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe struct UCmpStatusCharacterList // : UUIScene
{
    //[FieldOffset(0x0000)] public UUIScene baseObj;
    [FieldOffset(0x00B8)] public UUICmpStatus* Owner_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x870)]
public unsafe struct UCmpStatusCharacterListDraw // : UObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public UUICmpStatus* pParent;
    [FieldOffset(0x0030)] public ACmpMainActor* pMainActor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x348)]
public unsafe struct UUICmpStatus // : UObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
    //[FieldOffset(0x02B0)] public UUISceneFSM* SceneFSM_;
    //[FieldOffset(0x02B8)] public TMap<int, UUIScene*> Scenes_;
    [FieldOffset(0x0308)] public APersonaStatus* PSStatusActor_;
    //[FieldOffset(0x0310)] public AUIDialogSingle* SingleDialog_;
    [FieldOffset(0x0318)] public UCmpStatusCharacterListDraw* CharaListDraw_;
    //[FieldOffset(0x0320)] public UCmpCharacterStatusDraw* CharaStatusDraw_;
    [FieldOffset(0x0330)] public ACmpMainActor* pMainActor;
    [FieldOffset(0x0338)] public UCmpStatus* pParent;
}

[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe struct UUIResources // : UGameInstanceSubsystem
{
    //[FieldOffset(0x0000)] public UGameInstanceSubsystem baseObj;
    [FieldOffset(0x30)] public byte bIsReady;
    [FieldOffset(0x0038)] public UAssetLoader* Loader_;
    [FieldOffset(0x0040)] public TArray<nint> Assets_;
    [FieldOffset(0x00D0)] public UDataTable* HandwritingLayoutData_;
    //[FieldOffset(0x00D8)] public UFontStyleAsset* FontStyleAsset_;
    //[FieldOffset(0x00E0)] public UFont* SystemFont_;

    public UObject* GetAssetEntry(byte index)
    {
        UObject* asset = null;
        if ((bIsReady & 1) != 0 && index < Assets_.arr_num)
            asset = (UObject*)Assets_.allocator_instance[index];
        return asset;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x4138)]
public unsafe struct UCmpHeroHumanStatusDraw
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x38)] public uint MenuState;
    [FieldOffset(0x4048)] public ACmpMainActor* pMainActor;
    [FieldOffset(0x4050)] public UUICmpStatus* pParent;
    [FieldOffset(0x40b0)] public FColor statUpPulseFadeColor;
    [FieldOffset(0x40b4)] public FColor statUpPulseMainColor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe struct USequence
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe struct UCalendar
{
    [FieldOffset(0x0000)] public UObject baseObj;
    //[FieldOffset(0x0090)] public ACldBindingEventActor* mEventActor_;
    [FieldOffset(0x0098)] public uint mChangeFlag_;
    [FieldOffset(0x009C)] public ECldSceneChangeType mChangeType_;
    [FieldOffset(0x009D)] public ECldSceneChangeType mChangeSetted_;
    [FieldOffset(0x00A0)] public int mChangePrevDay_;
    [FieldOffset(0x00A4)] public ECldTimeZone mChangePrevTimeZone_;
    [FieldOffset(0x00A8)] public int mChangeNextDay_;
    [FieldOffset(0x00AC)] public ECldTimeZone mChangeNextTimeZone_;
    [FieldOffset(0x00B0)] public int cursorDay;
}

[StructLayout(LayoutKind.Explicit, Size = 0x298)]
public unsafe struct ACldCmnDataActor
{
    [FieldOffset(0x0000)] public AAppActor baseObj;
    [FieldOffset(0x0288)] public UAssetLoader* mAssetLoader_;
    [FieldOffset(0x0290)] public UArcAsset* mArcAsset_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct UCldCommonData
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0030)] public ACldCmnDataActor* mActor_;
    [FieldOffset(0x0048)] public UCldDateDataAsset* mDatesData_;
    [FieldOffset(0x0050)] public UClass* mBpClass_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UCldDateDataAsset
{
    //[FieldOffset(0x0000)] public UAppDataAsset baseObj;
    [FieldOffset(0x0030)] public TArray<FCldDateTableItem> Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x6)]
public unsafe struct FCldDateTableItem
{
    [FieldOffset(0x0000)] public byte Month;
    [FieldOffset(0x0001)] public byte Day;
    [FieldOffset(0x0002)] public byte MoonAge;
    [FieldOffset(0x0003)] public bool IsHoliday;
    [FieldOffset(0x0004)] public bool IsPublicHoliday;
    [FieldOffset(0x0005)] public ECldDateColor NumColorType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe struct AUFileNameManagerrActor
{
    [FieldOffset(0x0000)] public AAppActor baseObj;
    [FieldOffset(0x0280)] public UAssetLoader* mAssetLoader_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct UFileNameManager
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public UAssetLoader* Loader;
    //[FieldOffset(0x0030)] public UDataAsset* TableFileName;
    [FieldOffset(0x0040)] public AUFileNameManagerrActor* mActor_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe struct ADatItemActor
{
    [FieldOffset(0x0000)] public AAppActor baseObj;
    [FieldOffset(0x0280)] public UAssetLoader* mAssetLoader_;
}

[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe struct UDatItem
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public UAssetLoader* Loader;
    [FieldOffset(0x0030)] public UDataAsset* TableAccs;
    [FieldOffset(0x0038)] public UDataAsset* TableArmor;
    [FieldOffset(0x0040)] public UDataAsset* TableCommon;
    [FieldOffset(0x0048)] public UDataAsset* TableCostume;
    [FieldOffset(0x0050)] public UDataAsset* TableEvitem;
    [FieldOffset(0x0058)] public UDataAsset* TableMaterial;
    [FieldOffset(0x0060)] public UDataAsset* TableShoes;
    [FieldOffset(0x0068)] public UDataAsset* TableSkillcard;
    [FieldOffset(0x0070)] public UDataAsset* TableWeapon;
    [FieldOffset(0x0078)] public UDataAsset* TableAccsName;
    [FieldOffset(0x0080)] public UDataAsset* TableArmorName;
    [FieldOffset(0x0088)] public UDataAsset* TableCommonName;
    [FieldOffset(0x0090)] public UDataAsset* TableCostumeName;
    [FieldOffset(0x0098)] public UDataAsset* TableEvitemName;
    [FieldOffset(0x00A0)] public UDataAsset* TableMaterialName;
    [FieldOffset(0x00A8)] public UDataAsset* TableShoesName;
    [FieldOffset(0x00B0)] public UDataAsset* TableSkillcardName;
    [FieldOffset(0x00B8)] public UDataAsset* TableWeaponName;
    [FieldOffset(0x00C8)] public ADatItemActor* mActor_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe struct AFldCmnDataActor
{
    //[FieldOffset(0x0000)] public AFldLocalActor baseObj;
    [FieldOffset(0x0288)] public UFldCommonData* mParent_;
    [FieldOffset(0x0290)] public UAssetLoader* mAssetLoader_;
    [FieldOffset(0x0298)] public UArcAsset* mArcAsset_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x280)]
public unsafe struct AFldLocalActor
{
    [FieldOffset(0x0000)] public AAppActor baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public unsafe struct AFldScriptManagerCore
{
    [FieldOffset(0x0000)] public AFldLocalActor baseObj;
    [FieldOffset(0x0290)] public UAssetLoader* mAssetLoader_;
    [FieldOffset(0x0298)] public UBfAsset* mBfAsset_;
    [FieldOffset(0x02A0)] public UBmdAsset* mBmdAsset_;
    [FieldOffset(0x02A8)] public AFldScriptActor* mScriptActor_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe struct AFldScriptActor
{
    [FieldOffset(0x0000)] public AFldLocalActor baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public unsafe struct AFldTvProgramScript
{
    [FieldOffset(0x0000)] public AFldScriptManagerCore baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public unsafe struct AFldMailOrderScript
{
    [FieldOffset(0x0000)] public AFldScriptManagerCore baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public unsafe struct AFldBossBattleScript
{
    [FieldOffset(0x0000)] public AFldScriptManagerCore baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe struct UFldCommonData
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0030)] public AFldCmnDataActor* mActor_;
    [FieldOffset(0x40)] public TArray<FBD_CmmExistEntry>** CmmExistEntry;
    [FieldOffset(0x00B8)] public AFldTvProgramScript* mTvProgramActor_;
    [FieldOffset(0x00C0)] public AFldMailOrderScript* mMailOrderActor_;
    [FieldOffset(0x00C8)] public AFldBossBattleScript* mBossBattleActor_;
    [FieldOffset(0x00D0)] public UDataTable* mTableDat_;
    [FieldOffset(0x0188)] public UClass* mBpClass_;

    public UDataTable* GetDataTable(int id)
    {
        fixed (UFldCommonData* self = &this)
        {
            return ((UDataTable**)((nint)self + 0xd0))[id];
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
public unsafe struct UTrophyManager
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1F8)]
public unsafe struct ULeaderBoardManager
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct USignedInDialog
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UErrorDialog
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct UMessageDialog
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UBustupController
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0030)] public UBustupModel* pModel;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct UBustupModel
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0040)] public UBustupDraw* pBustupDraw;
}

// SOCIAL LINK

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct CmmPtr
{
    [FieldOffset(0x0)] public ushort ArcanaId;
    [FieldOffset(0x8)] public CmmEntry* entry;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct UAppMultiDataAsset
{
    [FieldOffset(0x0000)] public UDataAsset baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public unsafe struct FCommunityEventData
{
    [FieldOffset(0x0000)] public int Rank;
    [FieldOffset(0x0004)] public int major;
    [FieldOffset(0x0008)] public int Minor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe struct FCommunityRankUpEventData
{
    [FieldOffset(0x0000)] public short Rank;
    [FieldOffset(0x0002)] public short Point;
    [FieldOffset(0x0004)] public short major;
    [FieldOffset(0x0006)] public short Minor;
    [FieldOffset(0x0008)] public sbyte Brain;
    [FieldOffset(0x0009)] public sbyte charm;
    [FieldOffset(0x000A)] public sbyte Courage;
    [FieldOffset(0x000C)] public uint Flag0;
    [FieldOffset(0x0010)] public uint Flag1;
    [FieldOffset(0x0014)] public uint Flag2;
    [FieldOffset(0x0018)] public uint Flag3;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FCommunityEventTable
{
    [FieldOffset(0x0000)] public TArray<FCommunityEventData> NotRankUpTable;
    [FieldOffset(0x0010)] public TArray<FCommunityRankUpEventData> RankUpTable;
    [FieldOffset(0x0020)] public TArray<FCommunityRankUpEventData> LoverRankUpTable;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UCommunityEventDataAsset
{
    [FieldOffset(0x0000)] public UAppMultiDataAsset baseObj;
    [FieldOffset(0x0030)] public TArray<FCommunityEventTable> Tables;
}

[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe struct UCommunityHandler
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x00F0)] public UCommunityEventDataAsset* pEventDataAsset; // Xrd777/Community/Event/CommunityEventDataAsset
    //[FieldOffset(0x00F8)] public UHolidayEventDataAsset* pHolidayEventDataAsset;
    //[FieldOffset(0x0100)] public UHolidayScheduleDataAsset* pHolidayScheduleDataAsset;
    [FieldOffset(0x0108)] public UDataTable* pMemberFormatTable; // Xrd777/Community/Format/Member/DT_CommunityFormat_Member
    [FieldOffset(0x0110)] public UDataTable* pNameFormatTable; // Xrd777/Community/Format/Name/DT_CommunityFormat_Name
    //[FieldOffset(0x0118)] public UCoefficientDataAsset* pCoefficientDataAsset;
    //[FieldOffset(0x0120)] public UCommunityPresentDataAsset* pPresentDataAsset;
    //[FieldOffset(0x0128)] public UMoviesEventDataAsset* pMoviesEventDataAsset;
    //[FieldOffset(0x0130)] public USummerFestivalEventDataAsset* pSummerFestivalEventDataAsset;
    //[FieldOffset(0x0138)] public UChristmasEventDataAsset* pChristmasEventDataAsset;
    //[FieldOffset(0x0140)] public ACommunityEventManager* pEventManager;

    public CmmPtr* GetCmmEntry(int id) { fixed (UCommunityHandler* self = &this) { return ((CmmPtr**)((nint)self + 0x28))[id]; } }
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FHeroParameterTable
{
    [FieldOffset(0x0000)] public TArray<int> Points;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UHeroParameterDataAsset
{
    //[FieldOffset(0x0000)] public UAppMultiDataAsset baseObj;
    [FieldOffset(0x0030)] public TArray<FHeroParameterTable> Tables;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UHeroParameterHandle
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0030)] public UHeroParameterDataAsset* pDataAsset;
    [FieldOffset(0x0038)] public UDataTable* pParameterNameTable;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct UCommunityWork
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public UAssetLoader* pAssetLoader;
    [FieldOffset(0x0030)] public UCommunityHandler* pCommunityHandle;
    //[FieldOffset(0x0038)] public UVeveWork* pVeveWork;
    [FieldOffset(0x0040)] public UHeroParameterHandle* pHeroParameterHandle;
}

[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe struct UMsgManager
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0038)] public TArray<IntPtr> ProcList;
    [FieldOffset(0x0050)] public TArray<IntPtr> MsgReleaseList;
    [FieldOffset(0x0070)] public UDataTable* Simple_LayoutData;
    [FieldOffset(0x0078)] public UDataTable* SelectSimple_LayoutData;
    [FieldOffset(0x0080)] public UDataTable* CS_A_LayoutData;
    [FieldOffset(0x0088)] public UUILayoutDataTable* CS_A_LayoutDataTable;
    [FieldOffset(0x0090)] public UDataTable* AssistLayoutDataTextCol;
    [FieldOffset(0x0098)] public UDataTable* AssistLayoutData;
    [FieldOffset(0x00A0)] public UDataTable* BacklogLayoutDataTextCol;
    [FieldOffset(0x00A8)] public UUILayoutDataTable* AssistTextColLayoutDataTable;
    [FieldOffset(0x00B0)] public UUILayoutDataTable* AssistLayoutDataTable;
    [FieldOffset(0x00B8)] public UUILayoutDataTable* BacklogTextColLayoutDataTable;
    [FieldOffset(0x00C0)] public UDataTable* Mind_LayoutData;
    [FieldOffset(0x00C8)] public UAssetLoader* pAssetLoader;
    [FieldOffset(0x00D0)] public UAssetLoader* pCSAssetLoader;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct UMsgWork
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0038)] public UMsgManager* pMsgManager;
    [FieldOffset(0x0040)] public UTutorialManager* pTutorialManager;
}

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe struct UEvtDataLoad
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public UAssetLoader* pAssetLoader;
    //[FieldOffset(0x0030)] public UDataAsset* pDataOffTable;
    //[FieldOffset(0x0038)] public UDataAsset* pFadeOutTable;
    //[FieldOffset(0x0040)] public UDataAsset* pAssetOverWriteTable;
    //[FieldOffset(0x0048)] public UDataAsset* pAssetOverWriteEventTable;
    //[FieldOffset(0x0050)] public UDataAsset* pBagEnableTable;
    //[FieldOffset(0x0058)] public UDataAsset* pEvtPreDataTable;
    //[FieldOffset(0x0060)] public UDataAsset* pPersonaCombineAdjustTable;
    //[FieldOffset(0x0068)] public UDataAsset* pObjectVisibleTable;
}

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe struct UPadRumble
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public UForceFeedbackEffect* haveRumble;
    [FieldOffset(0x0030)] public UForceFeedbackEffect* haveRumble2;
    [FieldOffset(0x0038)] public UForceFeedbackEffect* ProgramEffect;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FFldCharSpeed
{
    [FieldOffset(0x0000)] public float Walk;
    [FieldOffset(0x0004)] public float Run;
    [FieldOffset(0x0008)] public float Dash;
    [FieldOffset(0x000C)] public float Assault;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct FFldPlayerInputInterpolationData
{
    [FieldOffset(0x0000)] public float MinAgnle;
    [FieldOffset(0x0004)] public int MinFrame;
    [FieldOffset(0x0008)] public float MaxAgnle;
    [FieldOffset(0x000C)] public int MaxFrame;
    [FieldOffset(0x0010)] public float Border;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FFldPlayerAttackData
{
    [FieldOffset(0x0000)] public EDungeonAnimID AnimId;
    [FieldOffset(0x0004)] public float AnimBlendTime;
    [FieldOffset(0x0008)] public int WeaponAnimId;
    [FieldOffset(0x000C)] public float BeginReceivingInputTime;
    [FieldOffset(0x0010)] public float EndReceivingInputTime;
    [FieldOffset(0x0014)] public float SwitchNextAttackTime;
    [FieldOffset(0x0018)] public float SwitchFreeStateTime;
    [FieldOffset(0x001C)] public float SlideRot;
    [FieldOffset(0x0020)] public float SlideScaleTime;
    [FieldOffset(0x0024)] public float SlideScale;
    [FieldOffset(0x0028)] public int VoiceId;
    [FieldOffset(0x002C)] public int NextAttackId;
}

[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public unsafe struct FFldPlayerAttackGuideData
{
    [FieldOffset(0x0000)] public float Range;
    [FieldOffset(0x0004)] public float Angle;
    [FieldOffset(0x0008)] public float GuideAngle;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct FRumbleParam
{
    [FieldOffset(0x0000)] public int power;
    [FieldOffset(0x0004)] public int Frame;
    [FieldOffset(0x0008)] public int WaitFrame;
    [FieldOffset(0x000C)] public int Num;
    [FieldOffset(0x0010)] public int TotalFram;
}

[StructLayout(LayoutKind.Explicit, Size = 0x3C)]
public unsafe struct FRumbleData
{
    [FieldOffset(0x0000)] public FRumbleParam Encount;
    [FieldOffset(0x0014)] public FRumbleParam PinchEncount;
    [FieldOffset(0x0028)] public FRumbleParam Broken;
}

[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe struct FFldPlayerData
{
    [FieldOffset(0x0000)] public float InputDeadZone;
    [FieldOffset(0x0004)] public float InputWalkZone;
    [FieldOffset(0x0008)] public FFldPlayerInputInterpolationData InputInterpolation;
    [FieldOffset(0x001C)] public float Acceleration;
    [FieldOffset(0x0020)] public float Deceleration;
    [FieldOffset(0x0024)] public float RotSpeed;
    [FieldOffset(0x0028)] public float RotSpeed_Walk;
    [FieldOffset(0x002C)] public float TurnSpeed;
    [FieldOffset(0x0030)] public float TurnMoveRot;
    [FieldOffset(0x0034)] public float BrakingTime;
    [FieldOffset(0x0038)] public float BrakingSlideTime;
    [FieldOffset(0x003C)] public float ReverseBrakingTime;
    [FieldOffset(0x0040)] public float ReverseBrakingSlideTime;
    [FieldOffset(0x0044)] public float EncoutRadius;
    [FieldOffset(0x0048)] public float SwitchingTimeToAssault;
    [FieldOffset(0x004C)] public float SwitchingTimeToAssaultLv2;
    [FieldOffset(0x0050)] public float AssaultGetTpLv1;
    [FieldOffset(0x0054)] public float AssaultGetTpLv2;
    [FieldOffset(0x0058)] public int AssaultUpsetRateLv1;
    [FieldOffset(0x005C)] public int AssaultUpsetRateLv2;
    [FieldOffset(0x0060)] public int IdleAttackId;
    [FieldOffset(0x0064)] public int WalkAttackId;
    [FieldOffset(0x0068)] public int RunAttackId;
    [FieldOffset(0x006C)] public int DashAttackId;
    [FieldOffset(0x0070)] public int AssaultAttackId;
    [FieldOffset(0x0074)] public float AttackToMoveBlendTime;
    //[FieldOffset(0x0078)] public TMap<int, FFldPlayerAttackData> attack;
    [FieldOffset(0x00C8)] public TArray<FFldPlayerAttackGuideData> AttackGuide;
    [FieldOffset(0x00D8)] public FRumbleData Rumble;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FFldPartnerData
{
    [FieldOffset(0x0000)] public float TrackingBeginDistance;
    [FieldOffset(0x0004)] public float TrackingNearDistance;
    [FieldOffset(0x0008)] public float TrackingUpdateDistance;
    [FieldOffset(0x000C)] public float AvoidPlayerDistance;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct FFldCharKeyParam
{
    [FieldOffset(0x0000)] public EFldCharKeyType Save;
    [FieldOffset(0x0001)] public EFldCharKeyType AutoRecover;
    [FieldOffset(0x0002)] public EFldCharKeyType DailyMenu;
    [FieldOffset(0x0003)] public EFldCharKeyType DungeonMenu;
    [FieldOffset(0x0004)] public EFldCharKeyType Camp;
    [FieldOffset(0x0005)] public EFldCharKeyType LargeMap;
    [FieldOffset(0x0006)] public EFldCharKeyType BackLog;
    [FieldOffset(0x0007)] public EFldCharKeyType VoiceActionDisp;
    [FieldOffset(0x0008)] public EFldCharKeyType Check;
    [FieldOffset(0x0009)] public EFldCharKeyType attack;
    [FieldOffset(0x000A)] public EFldCharKeyType CameraZoomIn;
    [FieldOffset(0x000B)] public EFldCharKeyType CameraZoomOut;
    [FieldOffset(0x0010)] public TArray<EFldCharKeyType> CameraDefault;
    [FieldOffset(0x0020)] public EFldCharKeyType DebugCamera;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1F0)]
public unsafe struct UFldCharDataAsset
{
    //[FieldOffset(0x0000)] public UDataAsset baseObj;
    [FieldOffset(0x0030)] public FFldCharSpeed DailySpeed;
    [FieldOffset(0x0040)] public FFldCharSpeed DungeonSpeed;
    //[FieldOffset(0x0050)] public TMap<int, FFldCharMajorBgData> MajorBg;
    [FieldOffset(0x00A0)] public FFldPlayerData Player;
    [FieldOffset(0x01B8)] public FFldPartnerData Partner;
    [FieldOffset(0x01C8)] public FFldCharKeyParam Key;
}

[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe struct UFldCharParamTable
{
    [FieldOffset(0x0000)] public UObject baseObj;
    //[FieldOffset(0x0028)] public TSoftObjectPtr<UFldCharDataAsset> Path;
    [FieldOffset(0x0050)] public UFldCharDataAsset* Data;
    [FieldOffset(0x0058)] public bool bLoaded;
}

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe struct UGlobalGameData
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public TArray<int> mFlags_ALWAYS_;
    [FieldOffset(0x0038)] public TArray<int> mFlags_ANY_;
    [FieldOffset(0x0048)] public TArray<int> mCounters_ALWAYS_;
    [FieldOffset(0x0058)] public TArray<int> mCounters_ANY_;
    [FieldOffset(0x0068)] public TArray<ushort> mComItems_ALWAYS_;
    [FieldOffset(0x0078)] public TArray<ushort> mComItems_ANY_;
    [FieldOffset(0x0088)] public TArray<ushort> mEvtItems_ALWAYS_;
    [FieldOffset(0x0098)] public TArray<ushort> mEvtItems_ANY_;
    [FieldOffset(0x00A8)] public TArray<ushort> mDlcItems_ALWAYS_;
    [FieldOffset(0x00B8)] public TArray<ushort> mNotInheritanceItems_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x410)]
public unsafe struct UUICmpCalendarDraw
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x28)] public BPDrawSpr DrawSpr;
    [FieldOffset(0x6c)] public int PartJobBgInAnimDelay;
    [FieldOffset(0x70)] public int Field70;
    [FieldOffset(0x98)] public int PartJobBgInAnimDstFrame;
    [FieldOffset(0x9C)] public int PartJobBgOutAnimDelay;
    [FieldOffset(0xA0)] public int PartJobBgOutAnimDstFrame;
    [FieldOffset(0x178)] public int CalendarDrawQueue;
    [FieldOffset(0x1e0)] public TArray<nint> PartTimeJobs;
    [FieldOffset(0x214)] public float TimePartTimeJobOpen;
    [FieldOffset(0x218)] public float TimePartTimeJobClosed;
    [FieldOffset(0x248)] public float Field248;
    [FieldOffset(0x03C8)] public UMaterialInstance* pBackgroundMaterialInstance;
    [FieldOffset(0x03D0)] public UMaterialInstanceDynamic* pBackgroundMaterialDaynamic;
    [FieldOffset(0x03D8)] public UDataTable* pEditParameterDataTable;
    [FieldOffset(0x03E0)] public UDataTable* pMonthTable;
    [FieldOffset(0x03E8)] public UDataTable* pDayTable;
    [FieldOffset(0x03F0)] public UDataTable* pWeekTable;
    [FieldOffset(0x03F8)] public UAssetLoader* pAssetLoader;
    [FieldOffset(0x0400)] public ACmpMainActor* pMainActor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct FCldDateMessage
{
    [FieldOffset(0x0000)] public int Key;
    [FieldOffset(0x0004)] public ushort TotalDay;
    [FieldOffset(0x0006)] public byte Month;
    [FieldOffset(0x0007)] public byte Day;
    [FieldOffset(0x0008)] public ECldDateMsgPeriod Period;
    [FieldOffset(0x000C)] public uint MsgLabel;
    [FieldOffset(0x0010)] public uint VisibleFlag;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FCldDateMessageMonth
{
    [FieldOffset(0x0000)] public TArray<FCldDateMessage> Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UCldDateMessageDataAsset
{
    //[FieldOffset(0x0000)] public UAppDataAsset baseObj;
    [FieldOffset(0x0030)] public TArray<FCldDateMessageMonth> Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct BPDrawSpr
{
    [FieldOffset(0x0)] public nint vtable;
    [FieldOffset(0x8)] public byte Flags;
    [FieldOffset(0xc)] public uint Flags2;

    public void Flag2Set_141301af0(byte flag)
    {
        Flags2 &= 0xfffffffe;
        Flags2 |= flag;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FAppCalculaterComponentWork
{
    [FieldOffset(0x0000)] public float Timer;
    [FieldOffset(0x0008)] public TArray<FAppCalculationItem> List;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct FAppCalculationItem
{
    [FieldOffset(0x0000)] public float SrcValue;
    [FieldOffset(0x0004)] public float DstValue;
    [FieldOffset(0x0008)] public int Delay;
    [FieldOffset(0x000C)] public int DstFrame;
    [FieldOffset(0x0010)] public appCalculationType Type;

    public FAppCalculationItem(float SrcValue, float DstValue, int Delay, int DstFrame, appCalculationType Type)
    {
        this.SrcValue = SrcValue;
        this.DstValue = DstValue;
        this.Delay = Delay;
        this.DstFrame = DstFrame;
        this.Type = Type;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0xA60)]
public unsafe struct AUIBackLogDraw
{
    //[FieldOffset(0x0000)] public AUIDrawBaseActor baseObj;
    [FieldOffset(0x02B8)] public float CursorMoveSpeed;
    [FieldOffset(0x02C0)] public TArray<float> CursorPosFix;
    [FieldOffset(0x02D0)] public float IconWaveMoveSpeed;
    [FieldOffset(0x02D8)] public TArray<int> IconWaveSmallWaitFrameList;
    [FieldOffset(0x02E8)] public TArray<int> IconWaveMediumWaitFrameList;
    [FieldOffset(0x02F8)] public TArray<int> IconWaveLargeWaitFrameList;
    [FieldOffset(0x0308)] public TArray<int> IconWaitAngleFrame;
    [FieldOffset(0x0318)] public TArray<int> IconMoveAngleFrame;
    [FieldOffset(0x0328)] public TArray<FColor> IconWaveSelColorList;
    [FieldOffset(0x0338)] public TArray<FColor> IconWaveNonSelColorList;
    [FieldOffset(0x0348)] public TArray<FColor> IconColor;
    [FieldOffset(0x0358)] public FColor BlackBoardColor;
    [FieldOffset(0x035C)] public FColor GladationBoardColor;
    [FieldOffset(0x0360)] public FColor BlueBoardColor;
    [FieldOffset(0x0364)] public FColor BlackBoardCoverColor;
    [FieldOffset(0x0368)] public TArray<int> CursorWaitMoveSlideFrame;
    [FieldOffset(0x0378)] public TArray<int> CursorMoveSlideFrame;
    [FieldOffset(0x0388)] public TArray<float> BlackBoardMoveSpeed;
    [FieldOffset(0x0398)] public TArray<float> BlueBoardMoveSpeed;
    [FieldOffset(0x03A8)] public TArray<float> BlueBoardRollSpeed;
    [FieldOffset(0x03B8)] public TArray<float> DayMoveSpeed;
    [FieldOffset(0x03C8)] public TArray<float> ScrollBarMoveSpeed;
    [FieldOffset(0x03D8)] public TArray<float> LogMoveSpeed;
    [FieldOffset(0x03E8)] public TArray<float> IconMoveSpeed;
    [FieldOffset(0x03F8)] public TArray<float> NoneMoveSpeed;
    [FieldOffset(0x0408)] public TArray<float> DecoMoveSpeed;
    [FieldOffset(0x0418)] public TArray<float> BlackBoardAlphaSpeed;
    [FieldOffset(0x0428)] public TArray<float> BlueBoardAlphaSpeed;
    [FieldOffset(0x0438)] public TArray<float> GradationAlphaSpeed;
    [FieldOffset(0x0448)] public TArray<float> DayAlphaSpeed;
    [FieldOffset(0x0458)] public TArray<float> ScrollBarAlphaSpeed;
    [FieldOffset(0x0468)] public TArray<float> LogAlphaSpeed;
    [FieldOffset(0x0478)] public TArray<float> IconAlphaSpeed;
    [FieldOffset(0x0488)] public TArray<float> NoneAlphaSpeed;
    [FieldOffset(0x0498)] public TArray<float> DecoAlphaSpeed;
    [FieldOffset(0x04A8)] public TArray<float> CursorWhiteMoveSpeed;
    [FieldOffset(0x04B8)] public TArray<float> CursorWhiteAlphaSpeed;
    [FieldOffset(0x04C8)] public TArray<float> CursorBlueMoveSpeed;
    [FieldOffset(0x04D8)] public TArray<float> CursorBlueAlphaSpeed;
    [FieldOffset(0x04E8)] public float AnimFinishTime;
    [FieldOffset(0x04EC)] public float SelMsgInterval;
    [FieldOffset(0x04F0)] public float MingMsgInterval;
    [FieldOffset(0x04F4)] public float SoundPlusPosX;
    [FieldOffset(0x04F8)] public float SoundPlusPosY;
    [FieldOffset(0x04FC)] public byte BlackboardOpacity;
    [FieldOffset(0x04FD)] public byte BlueboardOpacity;
    [FieldOffset(0x04FE)] public byte GladationOpacity;
    [FieldOffset(0x05C0)] public UTexture* tex;
    //[FieldOffset(0x05C8)] public UFrameBufferCapture* captureBackGround;
    [FieldOffset(0x0A58)] public UUILayoutDataTable* pLayoutDataTable;
}

[StructLayout(LayoutKind.Explicit, Size = 0xFA8)]
public unsafe struct AUIDayChange
{
    //[FieldOffset(0x0000)] public AUIBaseActor baseObj;
    [FieldOffset(0x02B0)] public UAssetLoader* m_pLoader;
    [FieldOffset(0x02B8)] public USprAsset* m_pSpr;
    [FieldOffset(0x02C0)] public UPlgAsset* m_pPlg;
    [FieldOffset(0x02C8)] public FGetUIParameter m_tagUip;
    //[FieldOffset(0x0340)] public FDayChangeRipple m_tagRipple;
    //[FieldOffset(0x0370)] public FDayChangeRipple m_tagLoadRipple;
    [FieldOffset(0x03A0)] public FCurveFloatAnimation m_curveInAnim;
    [FieldOffset(0x03D0)] public FCurveFloatAnimation m_curveInRectMaskAnim;
    [FieldOffset(0x0400)] public FCurveFloatAnimation m_curveCenterBlueBandMaskAnim;
    [FieldOffset(0x0430)] public FCurveFloatAnimation m_curve1DaySpeedAnim;
    [FieldOffset(0x0460)] public FCurveFloatAnimation m_curveSkipSpeedAnim;
    [FieldOffset(0x0490)] public FCurveFloatAnimation m_curveSuperSkipSpeedAnim;
    //[FieldOffset(0x04C0)] public FCurveVectorAnimation m_curveCenterMoonAgeInOutAnim;
    //[FieldOffset(0x04F0)] public FCurveVectorAnimation m_curveBigMoonAgeInOutAnim;
    [FieldOffset(0x0520)] public FCurveFloatAnimation m_curveCommonMoveAnim;
    //[FieldOffset(0x0550)] public FCurveVectorAnimation m_curveDaysGroupInAnim;
    //[FieldOffset(0x0580)] public FCurveVectorAnimation m_curveDayInAnim;
    //[FieldOffset(0x05B0)] public FCurveVectorAnimation m_curveDayOutAnim;
    [FieldOffset(0x05E0)] public FCurveFloatAnimation m_curveBlueBandAnim;
    //[FieldOffset(0x0610)] public FCurveVectorAnimation m_curveSkipMoonAgeFadeAnim;
    [FieldOffset(0x0640)] public UDataTable* m_pLayoutData;
    [FieldOffset(0x0648)] public UUILayoutDataTable* m_pLayoutDataParam;
    [FieldOffset(0x870)] public FSprColor LimitTextColor; // #3664ad
    [FieldOffset(0x924)] public FSprColor MoonColor; // #474343
    [FieldOffset(0xae4)] public FSprColor BandColorPrevDay; // #0049a2
    [FieldOffset(0xb58)] public FSprColor BandColorNextDay; // #0049a2
}

[StructLayout(LayoutKind.Explicit, Size = 0x8D8)]
public unsafe struct AUITimeChange
{
    //[FieldOffset(0x0000)] public AUIBaseActor baseObj;
    [FieldOffset(0x02B0)] public UAssetLoader* m_pLoader;
    [FieldOffset(0x02B8)] public USprAsset* m_pSpr;
    //[FieldOffset(0x02C0)] public FCurveVectorAnimation m_curveRotateAnim1;
    //[FieldOffset(0x02F0)] public FCurveVectorAnimation m_curveRotateAnim2;
    //[FieldOffset(0x0320)] public FCurveVectorAnimation m_curveRotateAnim3;
    //[FieldOffset(0x0350)] public FCurveVectorAnimation m_curveRotateAnim4;
    //[FieldOffset(0x0380)] public FCurveVectorAnimation m_curveRotateAnim5;
    //[FieldOffset(0x03B0)] public FCurveVectorAnimation m_curveOutAnim;
    [FieldOffset(0x03E0)] public FGetUIParameter m_uip;
    [FieldOffset(0x0458)] public UDataTable* m_pTimeChangeUIDT;
    [FieldOffset(0x740)] public FSprColor MainBarColor;
    [FieldOffset(0x828)] public FSprColor TopBarColor;
    [FieldOffset(0x08B8)] public UDataTable* m_pTimeChangeDataTable;
    [FieldOffset(0x08C0)] public UUILayoutDataTable* m_pTimeChangeLayoutDataTable;
    [FieldOffset(0x08C8)] public UDataTable* m_pTimeChangeMaskDataTable;
    [FieldOffset(0x08D0)] public UUILayoutDataTable* m_pTimeChangeMaskLayoutDataTable;
}

[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public struct FKeyHelpInterpolate
{
    [FieldOffset(0x1c)] public float Field1C;
    [FieldOffset(0x20)] public float Field20;
}

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public struct FKeyHelpButtonUILayout
{
    [FieldOffset(0x0)] public FSprColor Color;
}
[StructLayout(LayoutKind.Explicit, Size = 0x508)]
public unsafe struct FKeyHelpButtonBase
{
    [FieldOffset(0x10)] public USprAsset* keyHelpSpr;
    [FieldOffset(0x18)] public USprAsset* keyHelpSpr2;
    [FieldOffset(0x20)] public UPlgAsset* keyHelpPlg;
    //[FieldOffset(0x48)] public FKeyHelpButtonUILayout Sprites;
    [FieldOffset(0x1e8)] public FKeyHelpButtonUILayout TextLayout;
    [FieldOffset(0x244)] public float KeyHelpTransparency;
    [FieldOffset(0x258)] public int SpriteCount;
    [FieldOffset(0x414)] public FSprColor moviePauseMainColor;
    [FieldOffset(0x4d4)] public FSprColor moviePausePulseColor;

    public FKeyHelpButtonUILayout* GetSpriteLayout(int i) { fixed (FKeyHelpButtonBase* self = &this) { return &((FKeyHelpButtonUILayout*)((nint)self + 0x48))[i]; } }
}
[StructLayout(LayoutKind.Explicit, Size = 0x598)]
public unsafe struct FKeyHelpButtonAuto
{
    [FieldOffset(0x0)] public FKeyHelpButtonBase Super;
    [FieldOffset(0x540)] public FKeyHelpInterpolate Field540;
    [FieldOffset(0x590)] public int ActivationState;
}
[StructLayout(LayoutKind.Explicit, Size = 0x590)]
public unsafe struct FKeyHelpButtonFastForward
{
    [FieldOffset(0x0)] public FKeyHelpButtonBase Super;
    [FieldOffset(0x538)] public FKeyHelpInterpolate Field538;
    [FieldOffset(0x588)] public int ActivationState;
}

[StructLayout(LayoutKind.Explicit, Size = 0xE38)]
public unsafe struct AUIMiscGetItemDraw
{
    //[FieldOffset(0x0000)] public AUIBaseActor baseObj;
    [FieldOffset(0x0308)] public USprAsset* m_pGetItemSpr;
    [FieldOffset(0x0310)] public UPlgAsset* m_pGetPlg;
    [FieldOffset(0x0318)] public UDataTable* m_pItemGetDT;
    [FieldOffset(0x0320)] public USprAsset* m_pSpecialKeyHelpSpr;
    [FieldOffset(0x0328)] public USprAsset* m_pSpecialKeyHelpTextSpr;
    [FieldOffset(0x0330)] public UDataTable* m_pLayoutTextColDT;
    [FieldOffset(0x0338)] public UDataTable* m_pLayoutOkNextDT;
    [FieldOffset(0x0340)] public UDataTable* m_pLayoutOkNextMaskDT;
    [FieldOffset(0x0348)] public UUILayoutDataTable* m_pLayoutTextCol;
    [FieldOffset(0x0350)] public UUILayoutDataTable* m_pLayoutOkNext;
    [FieldOffset(0x0358)] public UUILayoutDataTable* m_pLayoutOkNextMask;
    [FieldOffset(0x440)] public SprDefStruct1 ItemCountBg;
    [FieldOffset(0x7e8)] public LocationSelectParams1 FirstArrowBg;
    [FieldOffset(0x85c)] public LocationSelectParams1 SecondArrowBg;
    [FieldOffset(0xaa0)] public PlgDefStruct1 GotGraphicLeftOutline;
    [FieldOffset(0xae0)] public PlgDefStruct1 GotGraphicRightFill;
}

[StructLayout(LayoutKind.Explicit, Size = 0x858)]
public unsafe struct AUIMiscMoneyDraw
{
    //[FieldOffset(0x0000)] public AUIBaseActor baseObj;
    [FieldOffset(0x02D8)] public USprAsset* m_pMoneySpr;
    [FieldOffset(0x310)] public FSprColor PayMoneyMarginColor;
    [FieldOffset(0x378)] public FSprColor BuyItemAmountSubtractColor;
    [FieldOffset(0x3e0)] public FSprColor White3E0;
    [FieldOffset(0x448)] public FSprColor BuyItemBlankAmountColor;
    [FieldOffset(0x4d4)] public FSprColor BgImageTintColorFill;
    [FieldOffset(0x548)] public FSprColor BgImageTintColorBorder;
    [FieldOffset(0x5bc)] public FSprColor MoneyTiltShadowColor;
    [FieldOffset(0x630)] public FSprColor Field630;
    [FieldOffset(0x67c)] public FSprColor White67C;
    [FieldOffset(0x6cc)] public FSprColor BuyItemAmountSubtractNumberColor;
    [FieldOffset(0x708)] public int MoneyDialogType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public unsafe struct DrawCircle // used in AUIDrawBaseActor::BPUICommand_DrawSircle
{
    [FieldOffset(0x0)] public FVector position;
    [FieldOffset(0xc)] public FVector2D radius;
    [FieldOffset(0x18)] public float Antialiasing;
    [FieldOffset(0x1c)] public FSprColor Color;
}

[StructLayout(LayoutKind.Explicit, Size = 0xCA0)]
public unsafe struct FBaseHeadPanel
{
    [FieldOffset(0x10)] public ushort PlayerId; // P3RE colorful party panel when????
}

[StructLayout(LayoutKind.Explicit, Size = 0x4010)]
public unsafe struct FBattleHeadPanel
{
    [FieldOffset(0x0000)] public FBaseHeadPanel baseObj;
    [FieldOffset(0xca0)] public SprDefStruct1 cardBlueBgTrans;
    [FieldOffset(0xd08)] public SprDefStruct1 lineShadowBgTrans;
    [FieldOffset(0x12C8)] public UMaterialInstanceDynamic* materialSmokeInst;
    [FieldOffset(0x12D0)] public UMaterialInstanceDynamic* materialSmokeInstGrey;
}

[StructLayout(LayoutKind.Explicit, Size = 0xEF0)]
public unsafe struct FFieldHeadPanel
{
    [FieldOffset(0x0000)] public FBaseHeadPanel baseObj;
    [FieldOffset(0xca0)] public SprDefStruct1 cardBlueBgTrans;
}

[StructLayout(LayoutKind.Explicit, Size = 0x428)]
public unsafe struct FTownMapMarker2
{
    [FieldOffset(0xf0)] public FSprColor IconColor;
    [FieldOffset(0x70)] public SprDefStruct1 MarkerShapeMask;
    [FieldOffset(0xd8)] public SprDefStruct1 InsideIconMask;
    [FieldOffset(0x140)] public SprDefStruct1 PlaceTextMask;
    [FieldOffset(0x1a8)] public SprDefStruct1 MarkerOutline;
    [FieldOffset(0x210)] public SprDefStruct1 SocialLinkCircle;
    [FieldOffset(0x278)] public SprDefStruct1 PlaceImageMask;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe struct AUIDrawBaseActor
{
    [FieldOffset(0x0000)] public AAppActor baseObj;
    [FieldOffset(0x278)] public BPDrawSpr drawer;
    [FieldOffset(0x288)] public int QueueId;
    [FieldOffset(0x0290)] public UAssetLoader* pAssetLoader;
    //[FieldOffset(0x0298)] public UUIDataAsset* ResourceDataAsset;
}
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FPersonaStatusDraw
{
    public byte GetEquipBonusStat(int i) { fixed (FPersonaStatusDraw* self = &this) { return *(byte*)((nint)self + 0x1c + i); } }
    public byte GetNextLevelStat(int i) { fixed (FPersonaStatusDraw* self = &this) { return *(byte*)((nint)self + 0x21 + i); } }
    public void SetEquipBonusStat(int i, byte v) { fixed (FPersonaStatusDraw* self = &this) { *(byte*)((nint)self + 0x1c + i) = v; } }
    public void SetNextLevelStat(int i, byte v) { fixed (FPersonaStatusDraw* self = &this) { *(byte*)((nint)self + 0x21 + i) = v; } }
}
[StructLayout(LayoutKind.Explicit, Size = 0x900)]
public unsafe struct APersonaStatusDraw
{
    [FieldOffset(0x0000)] public AUIDrawBaseActor baseObj;
    [FieldOffset(0x02B8)] public bool IsMemoryCheckPersonaModel;
    [FieldOffset(0x02D8)] public int Edit_L1R1_Loop_Animation_Frame;
    [FieldOffset(0x02DC)] public int Edit_L1R1_Push_Animation_Frame;
    [FieldOffset(0x02E0)] public int Edit_Flickering_Loop_Frame;
    [FieldOffset(0x02E4)] public int Edit_Persona_Change_SlideIn_Frame;
    [FieldOffset(0x02E8)] public float Edit_Persona_Change_Slide_Value;
    [FieldOffset(0x02EC)] public EPERSONA_STATUS_DRAW_SCENE Scene;
    [FieldOffset(0x02F0)] public UMaterialInstanceDynamic* pBackgroundMaterial;
    [FieldOffset(0x2f8)] public float NextLevelColorFlicker;
    //[FieldOffset(0x03A8)] public APersonaModelCaptureUpdater* ModelCaptureUpdater;
    [FieldOffset(0x309)] public byte Field309;
    [FieldOffset(0x30a)] public byte Field30A;
    [FieldOffset(0x34a)] public ushort PlayerId;
    [FieldOffset(0x34c)] public FDatUnitPersonaEntry CurrentPersona;
    [FieldOffset(0x380)] public FDatUnitPersonaEntry* pCurrentPersona;
    [FieldOffset(0x388)] public FPersonaStatusDraw* pPersonaEquipEffect;
    [FieldOffset(0x03B0)] public int Edit_Background_FadeIn_Frame;
    [FieldOffset(0x03B4)] public int Edit_Caustics_SlideIn_Delay;
    [FieldOffset(0x03B8)] public int Edit_Caustics_SlideIn_Frame;
    [FieldOffset(0x03BC)] public int Edit_Caustics_RectMask_ScaleUp_Delay;
    [FieldOffset(0x03C0)] public int Edit_Caustics_RectMask_ScaleUp_Frame;
    [FieldOffset(0x03C4)] public int Edit_PersonaInfo_SlideIn_Delay;
    [FieldOffset(0x03C8)] public int Edit_PersonaInfo_SlideIn_Frame;
    [FieldOffset(0x03CC)] public int Edit_Attribute_Effect_Frame;
    [FieldOffset(0x03D0)] public int Edit_SkillList_SlideIn_Delay;
    [FieldOffset(0x03D4)] public int Edit_SkillList_SlideIn_Frame;
    [FieldOffset(0x03D8)] public int Edit_Parameter_SlideIn_Delay;
    [FieldOffset(0x03DC)] public int Edit_Parameter_SlideIn_Frame;
    [FieldOffset(0x03E0)] public int Edit_Persona_SlideIn_Delay;
    [FieldOffset(0x03E4)] public int Edit_Persona_SlideIn_Frame;
    [FieldOffset(0x042C)] public int Edit_Parameter_Gage_Animation_Frame;
    [FieldOffset(0x0430)] public int Edit_Parameter_Gage_Animation_Delay;
    [FieldOffset(0x0434)] public int Edit_Parameter_UpGage_Animation_Frame;
    [FieldOffset(0x0438)] public int Edit_Parameter_Incense_Value_FadeIn_Frame;
    [FieldOffset(0x440)] public float Field440;
    [FieldOffset(0x444)] public float Field444;
    [FieldOffset(0x470)] public int BaseStrengthStat;
    [FieldOffset(0x474)] public int BaseMagicStat;
    [FieldOffset(0x478)] public int BaseEnduranceStat;
    [FieldOffset(0x47c)] public int BaseAgilityStat;
    [FieldOffset(0x480)] public int BaseLuckStat;
    [FieldOffset(0x0484)] public int Edit_LevelUp_SlideIn_Frame;
    [FieldOffset(0x0488)] public int Edit_LevelUp_Plate_FadeOut_Frame;
    [FieldOffset(0x48e)] public byte Field48E;
    [FieldOffset(0x0598)] public byte CombineStrengthStatGrowth;
    [FieldOffset(0x0599)] public byte CombineMagicStatGrowth;
    [FieldOffset(0x059A)] public byte CombineEnduranceStatGrowth;
    [FieldOffset(0x059B)] public byte CombineAgilityStatGrowth;
    [FieldOffset(0x059C)] public byte CombineLuckStatGrowth;
    [FieldOffset(0x05A0)] public int Edit_SkillAdd_Next_Skill_Start_Delay;
    [FieldOffset(0x05A4)] public float Edit_SkillAdd_Next_Skill_Plate_Color_Fade_Wait;
    [FieldOffset(0x05A8)] public float Edit_SkillAdd_Next_Skill_Plate_Color_Fade_Time;
    [FieldOffset(0x05AC)] public int Edit_SkillAdd_Next_Skill_Move_Frame;
    [FieldOffset(0x05B0)] public int Edit_SkillAdd_Next_Skill_In_Frame;
    [FieldOffset(0x05B4)] public int Edit_SkillAdd_Next_Skill_New_Slide_In_Frame;
    [FieldOffset(0x05B8)] public int Edit_SkillAdd_Next_Skill_New_Fade_In_Frame;
    [FieldOffset(0x5c4)] public float Field5C4;
    [FieldOffset(0x5c4)] public float TimeSinceSwitchedPersona;
    [FieldOffset(0x05E8)] public int Edit_Conception_Level3_LoopAnimation_Frame;
    [FieldOffset(0x05EC)] public int Edit_Conception_Level1_LoopAnimation_Frame;
    [FieldOffset(0x05F0)] public int Edit_Conception_GetEffect_Scale_Frame;
    [FieldOffset(0x05F4)] public int Edit_Conception_GetEffect_FadeOut_Delay;
    [FieldOffset(0x05F8)] public int Edit_Conception_GetEffect_FadeOut_Frame;
    [FieldOffset(0x05FC)] public int Edit_Conception_Icon_Get_FadeOut_Delay;
    [FieldOffset(0x0600)] public int Edit_Conception_Icon_Get_FadeOut_Frame;
    [FieldOffset(0x0614)] public int Edit_SkillCard_FadeIn_Frame;
    [FieldOffset(0x0618)] public int Edit_SkillCard_SlideIn_Frame;
    [FieldOffset(0x061C)] public int Edit_SkillCard_Used_FadeOut_Frame;
    [FieldOffset(0x0620)] public int Edit_SkillCard_Used_SlideeOut_Frame;
    [FieldOffset(0x0624)] public int Edit_SkillCard_Used_Plate_AddEffect_Frame;
    [FieldOffset(0x0628)] public int Edit_SkillCard_Used_Plate_LoopAnimation_Frame;
    [FieldOffset(0x062C)] public int Edit_SkillCard_Used_GetIcon_SlideIn_Frame;
    [FieldOffset(0x0648)] public int Edit_ChangeSkill_Skill_Name_Color_LoopAnimation_Frame;
    [FieldOffset(0x064C)] public int Edit_ChangeSkill_1Effect_Delay;
    [FieldOffset(0x0650)] public int Edit_ChangeSkill_BluePlate_SlideIn_Frame;
    [FieldOffset(0x0654)] public int Edit_ChangeSkill_BluePlate_Slide_Wait_Frame;
    [FieldOffset(0x0658)] public int Edit_ChangeSkill_BluePlate_SlideOut_Frame;
    [FieldOffset(0x065C)] public int Edit_ChangeSkill_Change_Font_SlideIn_Delay;
    [FieldOffset(0x0660)] public int Edit_ChangeSkill_Change_Font_SlideIn_Frame;
    [FieldOffset(0x0664)] public int Edit_ChangeSkill_Change_Font_Slide_Wait_Frame;
    [FieldOffset(0x0668)] public int Edit_ChangeSkill_Change_Font_SlideOut_Frame;
    [FieldOffset(0x066C)] public int Edit_ChangeSkill_Change_Font_FadeIn_Delay;
    [FieldOffset(0x0670)] public int Edit_ChangeSkill_Change_Font_FadeIn_Frame;
    [FieldOffset(0x0674)] public int Edit_ChangeSkill_Change_Font_Fade_Wait_Frame;
    [FieldOffset(0x0678)] public int Edit_ChangeSkill_Change_Font_FadeOut_Frame;
    [FieldOffset(0x067C)] public int Edit_ChangeSkill_ChangeIcon_FadeIn_Frame;
    [FieldOffset(0x0680)] public int Edit_ChangeSkill_ChangeIcon_SlideIn_Frame;
    [FieldOffset(0x06A8)] public int Edit_SkillInfo_SlideIn_Frame;
    [FieldOffset(0x06AC)] public int Edit_SkillInfo_FadeIn_Frame;
    [FieldOffset(0x06B0)] public int Edit_SkillInfo_SlideOut_Frame;
    [FieldOffset(0x06B4)] public int Edit_SkillInfo_FadeOut_Frame;
    [FieldOffset(0x06B8)] public int Edit_SkillInfo_Cursor_FadeIn_Frame;
    [FieldOffset(0x06BC)] public int Edit_SkillInfo_Cursor_FadeOut_Frame;
    [FieldOffset(0x06C0)] public int Edit_SkillInfo_Cursor_Frame;
    [FieldOffset(0x06C4)] public int Edit_SkillInfo_SubCursor_Frame;
    [FieldOffset(0x072C)] public int Edit_AffinityCheck_Icon_Move_Frame;
    [FieldOffset(0x0730)] public int Edit_AffinityCheck_Icon_1_Move_Delay;
    [FieldOffset(0x0734)] public int Edit_AffinityCheck_Font_Delay;
    [FieldOffset(0x0738)] public int Edit_AffinityCheck_Font_Move_Frame;
    [FieldOffset(0x073C)] public int Edit_AffinityCheck_Font_1_Move_Delay;
    [FieldOffset(0x0740)] public int Edit_AffinityCheck_Font_FadeIn_Frame;
    [FieldOffset(0x0744)] public int Edit_AffinityCheck_Font_1_FadeIn_Delay;
    [FieldOffset(0x0750)] public int Edit_SkillSelectList_SlideIn_Delay;
    [FieldOffset(0x0754)] public int Edit_SkillSelectList_SlideIn_Frame;
    [FieldOffset(0x0758)] public int Edit_SkillSelectList_FadeIn_Delay;
    [FieldOffset(0x075C)] public int Edit_SkillSelectList_FadeIn_Frame;
    [FieldOffset(0x0760)] public int Edit_SkillSelectList_SlideOut_Delay;
    [FieldOffset(0x0764)] public int Edit_SkillSelectList_SlideOut_Frame;
    [FieldOffset(0x0768)] public int Edit_SkillSelectList_FadeOut_Delay;
    [FieldOffset(0x076C)] public int Edit_SkillSelectList_FadeOut_Frame;
    [FieldOffset(0x0770)] public int Edit_SkillSelectList_RectScale_Delay;
    [FieldOffset(0x0774)] public int Edit_SkillSelectList_RectScale_Frame;
    [FieldOffset(0x0778)] public int Edit_SkillSelectList_Cursor_FadeIn_Delay;
    [FieldOffset(0x077C)] public int Edit_SkillSelectList_Cursor_FadeIn_Frame;
    [FieldOffset(0x0780)] public int Edit_SkillSelectList_Cursor_SlideIn_Delay;
    [FieldOffset(0x0784)] public int Edit_SkillSelectList_Cursor_SlideIn_Frame;
    [FieldOffset(0x0788)] public int Edit_SkillSelectList_SubCursor_SlideIn_Frame;
    [FieldOffset(0x078C)] public int Edit_SkillSelectList_Cursor_Frame;
    [FieldOffset(0x0790)] public int Edit_SkillSelectList_SubCursor_Frame;
    [FieldOffset(0x0794)] public int Edit_SkillSelectList_Info_SlideIn_Frame;
    [FieldOffset(0x0798)] public int Edit_SkillSelectList_Info_FadeIn_Frame;
    [FieldOffset(0x079C)] public int Edit_SkillSelectList_Info_ChangeSlideIn_Frame;
    [FieldOffset(0x07A0)] public int Edit_SkillSelectList_Info_ChangeFadeIn_Frame;
    [FieldOffset(0x07A4)] public int Edit_Selected_Succession_Skill_SlideIn_Delay;
    [FieldOffset(0x07A8)] public int Edit_Selected_Succession_Skill_SlideIn_Frame;
    [FieldOffset(0x07AC)] public int Edit_Selected_Succession_Skill_FadeIn_Delay;
    [FieldOffset(0x07B0)] public int Edit_Selected_Succession_Skill_FadeIn_Frame;
    [FieldOffset(0x07E8)] public int Edit_Commentary_FadeIn_Frame;
    [FieldOffset(0x7bc)] public float Field7BC;
    [FieldOffset(0x7c0)] public float Field7C0;
    [FieldOffset(0x07EC)] public int Edit_Commentary_SlideIn_Frame;
    [FieldOffset(0x07F0)] public int Edit_Commentary_Persona_Slide_Delay;
    [FieldOffset(0x07F4)] public int Edit_Commentary_Persona_Slide_Frame;
    [FieldOffset(0x07F8)] public int Edit_Commentary_Info_FadeOut_Delay;
    [FieldOffset(0x07FC)] public int Edit_Commentary_Info_FadeOut_Frame;
    [FieldOffset(0x0800)] public int Edit_Commentary_SkillList_Move_Delay;
    [FieldOffset(0x0804)] public int Edit_Commentary_SkillList_Move_Frame;
    [FieldOffset(0x0808)] public int Edit_Commentary_Paramter_Move_Delay;
    [FieldOffset(0x080C)] public int Edit_Commentary_Paramter_Move_Frame;
    [FieldOffset(0x0810)] public int Edit_Commentary_Affinity_FadeOut_Delay;
    [FieldOffset(0x0814)] public int Edit_Commentary_Affinity_FadeOut_Frame;
    [FieldOffset(0x0818)] public int Edit_Commentary_Affinity_SlideOut_Delay;
    [FieldOffset(0x081C)] public int Edit_Commentary_Affinity_SlideOut_Frame;
    [FieldOffset(0x0820)] public int Edit_Commentary_Rect_ScaleUp_Delay;
    [FieldOffset(0x0824)] public int Edit_Commentary_Rect_ScaleUp_Frame;
    [FieldOffset(0x0828)] public int Edit_Commentary_Font_Change_Frame;
    [FieldOffset(0x830)] public float PersonaInfoBottomBarMod;
    [FieldOffset(0x0834)] public int Edit_Combine_CommuBonus_SlideIn_Frame;
    [FieldOffset(0x0838)] public int Edit_Combine_CommuBonus_Plate_FadeOut_Frame;
    [FieldOffset(0x083C)] public int Edit_Combine_CommuBonus_Font_FadeOut_Frame;
    [FieldOffset(0x0840)] public int Edit_Combine_CommuBonus_Fix_Point_ColorChange_Frame1;
    [FieldOffset(0x0844)] public int Edit_Combine_CommuBonus_Fix_Point_ColorChange_Frame2;
    [FieldOffset(0x0848)] public int Edit_Combine_CommuBonus_ColorChange_Frame;
    [FieldOffset(0x084C)] public int Edit_Combine_BonusExp_SlideIn_Delay;
    [FieldOffset(0x0850)] public int Edit_Combine_BonusExp_SlideIn_Frame;
    [FieldOffset(0x0854)] public int Edit_Combine_BonusExp_Fade_Frame;
    [FieldOffset(0x858)] public int ArcanaRank;
    [FieldOffset(0x85c)] public int ExpBonusPoints;
    [FieldOffset(0x0870)] public int Edit_Registry_LockIcon_InAnimation_Delay;
    [FieldOffset(0x0874)] public int Edit_Registry_LockIcon_InAnimation_Frame;
    [FieldOffset(0x0878)] public int Edit_Registry_Switch_Heading_SlideOut_Delay;
    [FieldOffset(0x087C)] public int Edit_Registry_Switch_Heading_SlideOut_Frame;
    [FieldOffset(0x0880)] public int Edit_Registry_Switch_Heading_FadeOut_Delay;
    [FieldOffset(0x0884)] public int Edit_Registry_Switch_Heading_FadeOut_Frame;
    [FieldOffset(0x0888)] public int Edit_Registry_Switch_Heading_SlideIn_Delay;
    [FieldOffset(0x088C)] public int Edit_Registry_Switch_Heading_SlideIn_Frame;
    [FieldOffset(0x0890)] public int Edit_Registry_Switch_Heading_FadeIn_Delay;
    [FieldOffset(0x0894)] public int Edit_Registry_Switch_Heading_FadeIn_Frame;
    [FieldOffset(0x0898)] public int Edit_Registry_Switch_Mark_Rotate_Animation_Frame;
    [FieldOffset(0x08B0)] public UDataTable* LayoutTable;
    [FieldOffset(0x08B8)] public UDataTable* TextLayoutTable;
    [FieldOffset(0x08C0)] public UDataTable* TextPosRowLayoutTable;
    [FieldOffset(0x08C8)] public UUILayoutDataTable* LayoutDataTable;
    [FieldOffset(0x08D0)] public UUILayoutDataTable* TextLayoutDataTable;
    [FieldOffset(0x08D8)] public UUILayoutDataTable* TextPosRowLayoutDataTable;
    [FieldOffset(0x8e0)] public byte madeLayoutDataTable;
    [FieldOffset(0x8e1)] public byte madeTextLayoutDataTable;
    [FieldOffset(0x8e2)] public byte madeTextPosRowLayoutDataTable;

    public int GetBasePersonaStat(int i) { fixed (APersonaStatusDraw* self = &this) { return *(int*)((nint)self + 0x470 + i * 4); } }
    public float GetParamDisplayValueFrom(int i) { fixed (APersonaStatusDraw* self = &this) { return *(float*)((nint)self + 0x45C + i * 4); } }
    public float GetParamDisplayValueTo(int i) { fixed (APersonaStatusDraw* self = &this) { return *(float*)((nint)self + 0x448 + i * 4); } }
    public void SetParamDisplayValueTo(int i, float v) { fixed (APersonaStatusDraw* self = &this) { *(float*)((nint)self + 0x448 + i * 4) = v; } }
    public byte GetCombinePersonaStatGrowth(int i) { fixed (APersonaStatusDraw* self = &this) { return *(byte*)((nint)self + 0x598 + i); } }
}

// EVENTS

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FFieldEventInfo
{
    [FieldOffset(0x0000)] public AActor* FieldCameraActor;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FAtlEvtPlayBindingTagParameter
{
    [FieldOffset(0x0000)] public AActor* BindingActor;
    [FieldOffset(0x0008)] public FString BindingTag;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct FAtlEvtPlayParameter
{
    [FieldOffset(0x0000)] public FString EventAssetName;
    [FieldOffset(0x0010)] public bool bEnableBinding;
    [FieldOffset(0x0018)] public TArray<FAtlEvtPlayBindingTagParameter> BindingTagActors;
    [FieldOffset(0x0028)] public bool bDisableTimeZone;
    [FieldOffset(0x0030)] public FFieldEventInfo FieldEventInfo;
}

[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public unsafe struct AAtlEvtPlayObject
{
    [FieldOffset(0x0000)] public AAppActor baseObj;
    [FieldOffset(0x0278)] public FString LevelName;
    [FieldOffset(0x0288)] public FAtlEvtPlayParameter EvtPlayParam;
    [FieldOffset(0x02C0)] public FString EventRank;
    [FieldOffset(0x02E8)] public ALevelSequenceActor* LevelSequenceActor;
}

// ATLUS MOVIE TRACKS

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct FEvtDialoguePayload
{
    [FieldOffset(0x0000)] public FName EventName;
    [FieldOffset(0x0008)] public int MessageNo;
    [FieldOffset(0x000C)] public int MessageMajorID;
    [FieldOffset(0x0010)] public int MessageMinorID;
    [FieldOffset(0x0014)] public int MessageSubID;
    [FieldOffset(0x0018)] public int MessagePageID;
    [FieldOffset(0x0020)] public UBmdAsset* BmdAsset;
    [FieldOffset(0x0028)] public bool bMessageRefAffected;
    [FieldOffset(0x0029)] public bool bPauseSequencer;
    [FieldOffset(0x002C)] public int EventMessageID;
    [FieldOffset(0x0030)] public int SeqEventMessageID;
    [FieldOffset(0x0034)] public bool bWithSelect;
    [FieldOffset(0x0038)] public int SelectID;
    [FieldOffset(0x003C)] public int SelectMessageMajorID;
    [FieldOffset(0x0040)] public int SelectMessageMinorID;
    [FieldOffset(0x0044)] public int SelectMessageSubID;
    [FieldOffset(0x0048)] public int SelectResponceToLocalDataID;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct FMovieSceneEvtDialogueSectionData
{
    [FieldOffset(0x0000)] public FMovieSceneChannel baseObj;
    [FieldOffset(0x0008)] public TArray<FFrameNumber> Times;
    [FieldOffset(0x0018)] public TArray<FEvtDialoguePayload> KeyValues;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1E8)]
public unsafe struct UMovieSceneEvtDialogueSection
{
    [FieldOffset(0x0000)] public UMovieSceneSection baseObj;
    [FieldOffset(0x00E8)] public FMovieSceneEvtDialogueSectionData EventData;
    //[FieldOffset(0x0170)] public FNameCurve Events;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct FEvtScriptPayload
{
    [FieldOffset(0x0000)] public FName EventName;
    [FieldOffset(0x0008)] public int ProcNo;
    [FieldOffset(0x0010)] public UBfAsset* BfAsset;
    [FieldOffset(0x0018)] public bool bPauseSequencer;
    [FieldOffset(0x0019)] public bool bUseBmdAssetInBfAsset;
    [FieldOffset(0x0020)] public UBmdAsset* BmdAsset;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct FMovieSceneEvtScriptSectionData
{
    [FieldOffset(0x0000)] public FMovieSceneChannel baseObj;
    [FieldOffset(0x0008)] public TArray<FFrameNumber> Times;
    [FieldOffset(0x0018)] public TArray<FEvtScriptPayload> KeyValues;
}

[StructLayout(LayoutKind.Explicit, Size = 0x170)]
public unsafe struct UMovieSceneEvtScriptSection
{
    [FieldOffset(0x0000)] public UMovieSceneSection baseObj;
    [FieldOffset(0x00E8)] public FMovieSceneEvtScriptSectionData EventData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct FAtlSlotMultiAnimationParam
{
    [FieldOffset(0x0000)] public UAnimSequenceBase* Animation;
    [FieldOffset(0x0008)] public float StartOffset;
    [FieldOffset(0x000C)] public float EndOffset;
    [FieldOffset(0x0010)] public float BlendIn;
    [FieldOffset(0x0014)] public float BlendOut;
    [FieldOffset(0x0018)] public float PlayRate;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct FEvtCharaAnimationPayload
{
    [FieldOffset(0x0000)] public UAnimSequenceBase* Animation;
    [FieldOffset(0x0008)] public FName SlotName;
    [FieldOffset(0x0010)] public EEvtCharaAnimationSlotType SlotType;
    [FieldOffset(0x0014)] public float StartOffset;
    [FieldOffset(0x0018)] public float EndOffset;
    [FieldOffset(0x001C)] public float BlendIn;
    [FieldOffset(0x0020)] public float BlendOut;
    [FieldOffset(0x0024)] public float PlayRate;
    [FieldOffset(0x0028)] public EEvtCharaAnimationType CharaAnimationType;
    [FieldOffset(0x0030)] public TArray<FAtlSlotMultiAnimationParam> AnimArray;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct FMovieSceneEvtCharaAnimationSectionData
{
    [FieldOffset(0x0000)] public FMovieSceneChannel baseObj;
    [FieldOffset(0x0008)] public TArray<FFrameNumber> Times;
    [FieldOffset(0x0018)] public TArray<FEvtCharaAnimationPayload> KeyValues;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1E8)]
public unsafe struct UMovieSceneEvtCharaAnimationSection
{
    [FieldOffset(0x0000)] public UMovieSceneSection baseObj;
    //[FieldOffset(0x00E8)] public FNameCurve Events;
    [FieldOffset(0x0160)] public FMovieSceneEvtCharaAnimationSectionData EventData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FEvtFadeScreenPayload
{
    [FieldOffset(0x0000)] public FName EventName;
    [FieldOffset(0x0008)] public EEvtFadeScreenType FadeScreenType;
    [FieldOffset(0x000C)] public int FadeType;
    [FieldOffset(0x0010)] public int FadeFrame;
    [FieldOffset(0x0014)] public byte ColorR;
    [FieldOffset(0x0015)] public byte ColorG;
    [FieldOffset(0x0016)] public byte ColorB;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct FMovieSceneEvtFadeScreenSectionData
{
    [FieldOffset(0x0000)] public FMovieSceneChannel baseObj;
    [FieldOffset(0x0008)] public TArray<FFrameNumber> Times;
    [FieldOffset(0x0018)] public TArray<FEvtFadeScreenPayload> KeyValues;
}

[StructLayout(LayoutKind.Explicit, Size = 0x170)]
public unsafe struct UMovieSceneEvtFadeScreenSection
{
    [FieldOffset(0x0000)] public UMovieSceneSection baseObj;
    [FieldOffset(0x00E8)] public FMovieSceneEvtFadeScreenSectionData EventData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe struct AUIBaseActor
{
    [FieldOffset(0x0000)] public AAppActor baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0xAC8)]
public unsafe struct ACutInDraw
{
    [FieldOffset(0x0000)] public AUIBaseActor baseObj;
    [FieldOffset(0x5ac)] public LocationSelectParams1 EmotionGradientMain;
    [FieldOffset(0x6a0)] public PlgDefStruct1 EmotionPlgTint;
    [FieldOffset(0x6e0)] public SprDefStruct1 EmotionHighlight;
    [FieldOffset(0x08D8)] public UAssetLoader* AssetLoader_;
    [FieldOffset(0x08E0)] public UPlgAsset* EmotionIconPlg_;
    [FieldOffset(0x08E8)] public UTexture* BustUpTexture_;
    [FieldOffset(0x08F0)] public UTexture* BustUpDummyTexture_;
    [FieldOffset(0x08F8)] public FGetUIParameter UIP_;
    [FieldOffset(0x0970)] public FCurveVectorAnimation Curve1_;
    [FieldOffset(0x09A0)] public FCurveVectorAnimation Curve2_;
    [FieldOffset(0x09D0)] public FCurveVectorAnimation Curve3_;
    [FieldOffset(0x0A00)] public FCurveVectorAnimation Curve4_;
    [FieldOffset(0x0A30)] public FCurveVectorAnimation Curve5_;
    [FieldOffset(0x0A60)] public FCurveVectorAnimation Curve6_;
    [FieldOffset(0x0A90)] public FCurveVectorAnimation Curve7_;
    [FieldOffset(0x0AC0)] public USprAsset* Spr_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct FBaseCurveAnimation
{
    [FieldOffset(0x0018)] public UAssetLoader* m_pAssetLoader;
    [FieldOffset(0x0020)] public UCurveBase* m_pCurve;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FCurveVectorAnimation
{
    [FieldOffset(0x0000)] public FBaseCurveAnimation baseObj;
    [FieldOffset(0x0028)] public UCurveVector* m_pCurveVector;
}

[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public unsafe struct FMissingParamTableRow
{
    //[FieldOffset(0x0000)] public FTableRowBase baseObj;
    [FieldOffset(0x0008)] public int PlateQuestInAllFrame;
    [FieldOffset(0x000C)] public int PlateQuestInStartFrame;
    [FieldOffset(0x0010)] public int PlateChangeAllFrame;
    [FieldOffset(0x0014)] public int PlateChangeStartFrame;
    [FieldOffset(0x0018)] public int PlateChangeOutAllFrame;
    [FieldOffset(0x001C)] public int PlateChangeOutStartFrame;
    [FieldOffset(0x0020)] public int ListChangeAllFrame;
    [FieldOffset(0x0024)] public int ListChangeStartFrame;
    [FieldOffset(0x0028)] public int AlphaBGNoCampAllFrame;
    [FieldOffset(0x002C)] public int AlphaBGNoCampStartFrame;
    [FieldOffset(0x0030)] public int BGPlateNoCampAllFrame;
    [FieldOffset(0x0034)] public int BGPlateNoCampStartFrame;
    [FieldOffset(0x0038)] public int MissingPlateNoCampAllFrame;
    [FieldOffset(0x003C)] public int MissingPlateNoCampStartFrame;
    [FieldOffset(0x0040)] public int ListNoCampAllFrame;
    [FieldOffset(0x0044)] public int ListNoCampStartFrame;
    [FieldOffset(0x0048)] public int DetailInPlateAllFrame;
    [FieldOffset(0x004C)] public int DetailInPlateStartFrame;
    [FieldOffset(0x0050)] public int DetailInInfoAllFrame;
    [FieldOffset(0x0054)] public int DetailInInfoStartFrame;
    [FieldOffset(0x0058)] public int DetailInCursorAllFrame;
    [FieldOffset(0x005C)] public int DetailInCursorStartFrame;
    [FieldOffset(0x0060)] public int DetailInMoreInfoAllFrame;
    [FieldOffset(0x0064)] public int DetailInMoreInfoStartFrame;
    [FieldOffset(0x0068)] public int DetailInNotSelectAllFrame;
    [FieldOffset(0x006C)] public int DetailInNotSelectStartFrame;
    [FieldOffset(0x0070)] public int DetailInCompleteAllFrame;
    [FieldOffset(0x0074)] public int DetailInCompleteStartFrame;
    [FieldOffset(0x0078)] public int DetailOutPlateAllFrame;
    [FieldOffset(0x007C)] public int DetailOutPlateStartFrame;
    [FieldOffset(0x0080)] public int DetailOutInfoAllFrame;
    [FieldOffset(0x0084)] public int DetailOutInfoStartFrame;
    [FieldOffset(0x0088)] public int DetailOutCursorAllFrame;
    [FieldOffset(0x008C)] public int DetailOutCursorStartFrame;
    [FieldOffset(0x0090)] public int DetailOutMoreInfoAllFrame;
    [FieldOffset(0x0094)] public int DetailOutMoreInfoStartFrame;
    [FieldOffset(0x0098)] public int DetailOutNotSelectAllFrame;
    [FieldOffset(0x009C)] public int DetailOutNotSelectStartFrame;
    [FieldOffset(0x00A0)] public int DetailOutCompleteAllFrame;
    [FieldOffset(0x00A4)] public int DetailOutCompleteStartFrame;
    [FieldOffset(0x00A8)] public int DetailShowPrevContentFrame;
    [FieldOffset(0x00AC)] public int DetailChangeInfoAllFrame;
    [FieldOffset(0x00B0)] public int DetailChangeInfoStartFrame;
    [FieldOffset(0x00B4)] public int DetailChangeCompleteAllFrame;
    [FieldOffset(0x00B8)] public int DetailChangeCompleteStartFrame;
    [FieldOffset(0x00BC)] public int SortPrevAllFrame;
    [FieldOffset(0x00C0)] public int SortPrevStartFrame;
    [FieldOffset(0x00C4)] public int SortNewAllFrame;
    [FieldOffset(0x00C8)] public int SortNewStartFrame;
    [FieldOffset(0x00CC)] public int SortListAllFrame;
    [FieldOffset(0x00D0)] public int SortListStartFrame;
    [FieldOffset(0x00D4)] public float PlateWhenMissingX;
    [FieldOffset(0x00D8)] public float PlateWhenMissingY;
    [FieldOffset(0x00DC)] public float PlateWhenQuestX;
    [FieldOffset(0x00E0)] public float PlateWhenQuestY;
    [FieldOffset(0x00E4)] public float PlateInY;
    [FieldOffset(0x00E8)] public float TatumiY;
    [FieldOffset(0x00EC)] public float CursorRedInAllFrame;
    [FieldOffset(0x00F0)] public float CursorRedInStartFrame;
}

[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public unsafe struct FMissingEntry
{
    [FieldOffset(0x2)] public ushort Field02;
}

[StructLayout(LayoutKind.Explicit, Size = 0xBF8)]
public unsafe struct UUIMissingPerson
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x34)] public int State;
    [FieldOffset(0x40)] public FVector2D missingNamesPos;
    [FieldOffset(0x48)] public float missingNamesPaddingY;
    [FieldOffset(0x4c)] public byte bTryLeaveMenu;
    [FieldOffset(0x4d)] public byte bLeftMenu;
    [FieldOffset(0x58)] public CheckDrawUIStruct1 Field58;
    [FieldOffset(0x88)] public CheckDrawUIStruct1 Field88;
    [FieldOffset(0xe8)] public CheckDrawUIStruct1 LabelRowOpacity;
    [FieldOffset(0x118)] public CheckDrawUIStruct1 Field118;
    [FieldOffset(0x148)] public CheckDrawUIStruct1 Field148;
    [FieldOffset(0x178)] public CheckDrawUIStruct1 Field178;
    [FieldOffset(0x1a8)] public float Field1A8;
    [FieldOffset(0x1ac)] public ushort currentMissing;
    [FieldOffset(0x1b0)] public byte bOverrideMissing;
    [FieldOffset(0x2a8)] public byte bHideSortedRow;
    [FieldOffset(0x218)] public CheckDrawUIStruct1 Field218;
    [FieldOffset(0x248)] public CheckDrawUIStruct1 Field248;
    [FieldOffset(0x2b0)] public CheckDrawUIStruct1 Field2B0;
    [FieldOffset(0x2e0)] public CheckDrawUIStruct1 Field2E0;
    [FieldOffset(0x310)] public CheckDrawUIStruct1 Field310;
    [FieldOffset(0x340)] public int SortByStatus;
    [FieldOffset(0x378)] public CheckDrawUIStruct1 Field378;
    [FieldOffset(0x3a8)] public CheckDrawUIStruct1 Field3A8;
    [FieldOffset(0x538)] public nint Field538;
    [FieldOffset(0x0408)] public USprAsset* pSpr_;
    [FieldOffset(0x0410)] public UAssetLoader* pLoader_;
    [FieldOffset(0x0418)] public UMaterialInterface* m_pBGMat;
    [FieldOffset(0x0420)] public UMaterialInstanceDynamic* m_pBGMatInst;
    [FieldOffset(0x0428)] public UDataTable* m_pDT;
    [FieldOffset(0x0430)] public FMissingParamTableRow ParamDT;
    [FieldOffset(0x0528)] public UWorld* pRefWorld_;
    [FieldOffset(0x531)] public byte bInCampMenu;
    [FieldOffset(0x532)] public byte Field532;
    [FieldOffset(0x730)] public SprDefStruct1 arrowUpA;
    [FieldOffset(0x798)] public SprDefStruct1 arrowUpB;
    [FieldOffset(0x800)] public SprDefStruct1 arrowDownA;
    [FieldOffset(0x868)] public SprDefStruct1 arrowDownB;
    [FieldOffset(0x8d0)] public CheckDrawUIStruct1 Field8D0;
    [FieldOffset(0x900)] public CheckDrawUIStruct1 Field900;
    [FieldOffset(0x938)] public float Field938;
    [FieldOffset(0x970)] public float Field970;
    [FieldOffset(0x9a8)] public float Field9A8;
    [FieldOffset(0xb48)] public TArray<FMissingEntry> MissingPersons;
    [FieldOffset(0xb58)] public int SortByNumber;
    [FieldOffset(0x0B60)] public UUILayoutDataTable* LayoutData;
    [FieldOffset(0x0B68)] public UUILayoutDataTable* TextColLayoutData;
    [FieldOffset(0x0B70)] public UUILayoutDataTable* TextPosLayoutData;
    [FieldOffset(0x0B78)] public UUILayoutDataTable* DateLayoutData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public unsafe struct AFldLevelManager
{
    [FieldOffset(0x0000)] public AFldLocalActor baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public unsafe struct UAppCharBaseComp
{
    [FieldOffset(0x0000)] public UActorComponent baseObj;
    [FieldOffset(0x00E0)] public AActor* mMotionAttached_;
    [FieldOffset(0x00E8)] public FName mMotionAttachedSocketName_;
    [FieldOffset(0x00F0)] public FTransform mMotionAttachedTransform;
    [FieldOffset(0x0120)] public bool mMotionDetachPrepared_;
    [FieldOffset(0x0121)] public bool bMotionDetachPreparedTransKeep_;
    [FieldOffset(0x0122)] public bool bMotionDetachPreparedRelativeTrans_;
    [FieldOffset(0x0124)] public FRotator mMotionDetachPreparedRelativeRotator_;
    [FieldOffset(0x0130)] public FVector mMotionDetachPreparedRelativeLocation_;
    [FieldOffset(0x0150)] public int mFadeType_;
    [FieldOffset(0x0154)] public int mFadeFrame_;
    [FieldOffset(0x0158)] public int mFadePattern_;
    [FieldOffset(0x0190)] public bool mDelayPauseAnimReq_;
    [FieldOffset(0x0191)] public bool mDelayPauseAnimFlag_;
    [FieldOffset(0x0194)] public float mDelayPauseAnimSpeedRate_;
    //[FieldOffset(0x0198)] public TSoftClassPtr<AAppPropsCore> mBagClassPtr_;
    //[FieldOffset(0x01C0)] public FName mBagAttachSocketName;
    //[FieldOffset(0x01C8)] public FName mBagAnimSlotName_;
    //[FieldOffset(0x01D0)] public TMap<EAppCharBagAnimType, IntPtr> mBagAnims_;
    //[FieldOffset(0x0220)] public AAppPropsCore* mBagActor_;
    //[FieldOffset(0x0228)] public bool bIsLockedLookAt_;
    //[FieldOffset(0x0229)] public byte mLockedLookAtType_;
    //[FieldOffset(0x022C)] public float mLockedLookAtSpeed_;
    //[FieldOffset(0x0230)] public USkeletalMeshComponent* CostumeMesh;
    //[FieldOffset(0x0238)] public USkeletalMeshComponent* HairMesh;
    //[FieldOffset(0x0240)] public USkeletalMeshComponent* FaceMesh;
    //[FieldOffset(0x0248)] public UAppCharFootstepsAtom* FootstepsAtom;
    //[FieldOffset(0x0250)] public UAnimMontage* AnimMontage_DefaultSlot;
    //[FieldOffset(0x0258)] public UAnimMontage* AnimMontage_FacialSlot;
    //[FieldOffset(0x0260)] public UAnimMontage* AnimMontage_NeckSlot;
    //[FieldOffset(0x0268)] public UAnimMontage* AnimMontage_TurnSlot;
    //[FieldOffset(0x0278)] public UAnimMontage* AnimMontage_HavBagSlot;
    //[FieldOffset(0x0280)] public EAppCharCategoryType CategoryID;
    //[FieldOffset(0x0284)] public int IndexID;
    //[FieldOffset(0x0288)] public int CostumeID;
    //[FieldOffset(0x028C)] public EAnimPackID AnimPackID;
    //[FieldOffset(0x0290)] public UAppCharAnimDataAsset* AnimPack;
    //[FieldOffset(0x0298)] public UAppCharFaceAnimDataAsset* FaceAnimPack;
    //[FieldOffset(0x02A0)] public EAppCharWeaponType WeaponType;
    //[FieldOffset(0x02A4)] public int WeaponId;
    //[FieldOffset(0x02A8)] public TArray<IntPtr> Weapons;
    //[FieldOffset(0x02B8)] public bool bBagEnable;
    //[FieldOffset(0x02BC)] public int ShoesID;
    //[FieldOffset(0x02C0)] public EAppCharState State;
    //[FieldOffset(0x02C4)] public FVector MoveLocation;
    //[FieldOffset(0x02D0)] public float MoveSpeed;
    //[FieldOffset(0x02D4)] public bool bTransparencyEnable;
    //[FieldOffset(0x02D8)] public FAppCharTransparency Transparency;
}


[StructLayout(LayoutKind.Explicit, Size = 0x370)]
public unsafe struct UAppCharacterComp
{
    [FieldOffset(0x0000)] public UAppCharBaseComp baseObj;
    [FieldOffset(0x02F8)] public float mBagMotionBlendTime_StandToRun_;
    [FieldOffset(0x02FC)] public float mBagMotionBlendTime_RunToStand_;
    [FieldOffset(0x0300)] public bool bIsBagSetting_;
    [FieldOffset(0x0301)] public bool bIsBagRun_;
    [FieldOffset(0x0304)] public int mBagKeyID_;
    [FieldOffset(0x0308)] public int mOverwirteBagKeyID_;
    [FieldOffset(0x030C)] public bool bIsBagInvalidIK_;
    //[FieldOffset(0x0310)] public ACharacterBaseCore* Character;
    [FieldOffset(0x0318)] public bool bNeedInitialize;
    //[FieldOffset(0x0320)] public UAppCharLoader* Loader;
    [FieldOffset(0x0328)] public TArray<nint> EffectWeapons;
    [FieldOffset(0x0338)] public TArray<int> HideMaterialIDs;
    [FieldOffset(0x0358)] public int mSetCostumeID;
    [FieldOffset(0x035C)] public int mSetWeaponType;
    [FieldOffset(0x0360)] public int mSetWeaponModelID;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe struct AFldInitScriptManager
{
    [FieldOffset(0x0000)] public AFldScriptManagerCore baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x3F0)]
public unsafe struct UFldManagerSubsystem
{
    [FieldOffset(0x0000)] public UGameInstanceSubsystem baseObj;
    [FieldOffset(0x00B0)] public AFldLevelManager* mLevelManager_;
    [FieldOffset(0x00C0)] public UAppCharacterComp* mPlayerComp_;
    [FieldOffset(0x00D0)] public FTransform mPlayerTransform;
    [FieldOffset(0x0100)] public AFldOperator* mOparetator_;
    [FieldOffset(0x0108)] public AFldInitScriptManager* mInitScrManager_;
    //[FieldOffset(0x0140)] public AFldKeyFreeAnnounceActor* mKeyFreeAnnounceActor_;
    //[FieldOffset(0x0148)] public AFldKeyFreeEventActor* mKeyFreeEventActor_;
    //[FieldOffset(0x0150)] public AFldFieldEventActor* mFieldEventActor_;
    [FieldOffset(0x0158)] public AAppActor* mLargeMapActor_;
    //[FieldOffset(0x0160)] public UFldSoundManager* mSoundManager_;
    //[FieldOffset(0x0168)] public UFldMiniMapManager* mMiniMapManager_;
    //[FieldOffset(0x02C8)] public AFldDungeonMenuScript* mDungeonMenuScript_;
    //[FieldOffset(0x02D0)] public AFldDailyMenuScript* mDailyMenuScript_;
    //[FieldOffset(0x02D8)] public AUISaveLoad* mSaveMenu_;
    //[FieldOffset(0x02E0)] public AUIBackLog* mBackLogDisp_;
    [FieldOffset(0x02E8)] public AActor* mVoiceActionDisp_;
    //[FieldOffset(0x02F0)] public AFldHitCore* mKeyLockedActor_;
    //[FieldOffset(0x02F8)] public AFldAutoRecoverMenuScript* mAutoRecoverMenuScript_;
    [FieldOffset(0x0300)] public TArray<nint> mHiddenActorArray_;
    //[FieldOffset(0x0310)] public AFldMiscCharBaseReload* mCharBaseReload_;
    //[FieldOffset(0x0318)] public TMap<EFldCmnProps, IntPtr> mCmnPropsActors_;
    //[FieldOffset(0x0368)] public AFldMiscCameraShake* mCameraShake_;
    [FieldOffset(0x0370)] public float mKeyHelpDelayTimer_;
    [FieldOffset(0x0374)] public float mMoveFloorTimer_;
    //[FieldOffset(0x0378)] public TSubclassOf<ACharacterBaseCore> mDefaultPlayerClass_;
    //[FieldOffset(0x0380)] public TSubclassOf<ACharacterBaseCore> mDungeonPlayerClass_;
    //[FieldOffset(0x0388)] public TSubclassOf<AFldCameraBase> mDefaultCameraClass_;
    //[FieldOffset(0x0390)] public TSubclassOf<AFldCameraBase> mDungeonCameraClass_;
    //[FieldOffset(0x0398)] public TSubclassOf<AFldCamera> mTransCameraClass_;
    //[FieldOffset(0x03A0)] public TSubclassOf<ACharacterBaseCore> mFollowerClass_;
    //[FieldOffset(0x03A8)] public TSubclassOf<ACharacterBaseCore> mFollowerKoromaruClass_;
    [FieldOffset(0x03B0)] public UObject* mWorldContextObject_;
    //[FieldOffset(0x03B8)] public AFldMiscCharaBaseMove* mMoveActor_;
    [FieldOffset(0x03C0)] public bool mCameraLock_;
    //[FieldOffset(0x03C8)] public AFldMiscCameraMove* mCameraMoveActor_;
    [FieldOffset(0x03D0)] public TArray<nint> mOverlapedHitArray_;
    [FieldOffset(0x03E0)] public AAppActor* mDebugMenu_;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe struct AFldOperator
{
    [FieldOffset(0x0000)] public AActor baseObj;
    //[FieldOffset(0x0220)] public UFldOperationCamera* OpCameraComp;
    //[FieldOffset(0x0228)] public UFldOperationPlayer* OpPlayerComp;
    //[FieldOffset(0x0230)] public UFldOperationPrePhysics* OpPrePhysicsComp;
    //[FieldOffset(0x0238)] public AFldCamera* MainCamera;
    //[FieldOffset(0x0240)] public AFldCameraFree* FreeCamera;
    //[FieldOffset(0x0248)] public FFldPlayerHolder PlayerHolder;
    //[FieldOffset(0x0260)] public AController* PlayerController;
    //[FieldOffset(0x0268)] public AKernelInput* KernelInput;
    [FieldOffset(0x0270)] public TArray<nint> OverloapHits;
    //[FieldOffset(0x0280)] public EFldOperatorKeyState KeyState;
    //[FieldOffset(0x0284)] public EFldOperatorState State;
    //[FieldOffset(0x0288)] public EFldOperatorState NextState;
    //[FieldOffset(0x0290)] public FFldEnemyHolder EncountEnemy;
    //[FieldOffset(0x02A0)] public EFldOperatorEncountType EncountType;
    //[FieldOffset(0x02A8)] public FFldPartnerHolder AssembleEvent;
    [FieldOffset(0x02B8)] public bool bDebugStandalone;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct FAtlEvtPreSublevelData
{
    [FieldOffset(0x0000)] public TArray<FString> EventBGLevels;
    [FieldOffset(0x0010)] public int BGFieldMajorID;
    [FieldOffset(0x0014)] public int BGFieldMinorID;
    [FieldOffset(0x0018)] public FString BGFieldSeasonSubLevel;
    [FieldOffset(0x0028)] public FString BGFieldSoundSubLevel;

    public FAtlEvtPreSublevelData(int MajorId, int MinorId)
    {
        BGFieldMajorID = MajorId;
        BGFieldMinorID = MinorId;
    }
}


[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FAtlEvtPreDungeonSublevelData
{
    [FieldOffset(0x0000)] public FName EventBGFloorLevel;
    [FieldOffset(0x0008)] public FName BGEnvironmentSubLevel;
}

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe struct FAtlEvtPreData
{
    [FieldOffset(0x0000)] public int EventMajorID;
    [FieldOffset(0x0004)] public int EventMinorID;
    [FieldOffset(0x0008)] public int EventCategoryTypeID;
    [FieldOffset(0x000C)] public FName EventRank;
    [FieldOffset(0x0014)] public FName EventCategory;
    [FieldOffset(0x0020)] public FString EventLevel;
    [FieldOffset(0x0030)] public TArray<FAtlEvtPreSublevelData> EventSublevels;
    [FieldOffset(0x0040)] public TArray<FName> LightScenarioSublevels;
    [FieldOffset(0x0050)] public FAtlEvtPreDungeonSublevelData DungeonSublevel;
    [FieldOffset(0x0060)] public bool bDisableAutoLoadFirstLightingScenarioLevel;
    [FieldOffset(0x0061)] public bool bForceDisableUseCurrentTimeZone;
    [FieldOffset(0x0062)] public byte ForcedCldTimeZoneValue;
    [FieldOffset(0x0064)] public int ForceMonth;
    [FieldOffset(0x0068)] public int ForceDay;

    public FAtlEvtPreData(int eventMajorID, int eventMinorID, int eventCategoryTypeID, FName eventRank, FName eventCategory)
    {
        EventMajorID = eventMajorID;
        EventMinorID = eventMinorID;
        EventCategoryTypeID = eventCategoryTypeID;
        EventRank = eventRank;
        EventCategory = eventCategory;
    }

    public bool IsValid() => EventMajorID != -1 && EventMinorID != -1 && EventCategoryTypeID != -1;

    public void MakeInvalidEvent()
    {
        EventMajorID = -1;
        EventMinorID = -1;
        EventCategoryTypeID = -1;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UAtlEvtPreDataAsset
{
    [FieldOffset(0x0000)] public UDataAsset baseObj;
    [FieldOffset(0x0030)] public TArray<FAtlEvtPreData> Data;
}


[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe struct UAtlEvtSubsystem
{
    [FieldOffset(0x0000)] public UGameInstanceSubsystem baseObj;
    /*[FieldOffset(0x0030)] public TMap<uint, FAtlEvtPlayingCharacterInfo> AppEvtCharactersMap;
    [FieldOffset(0x0080)] public TMap<int, FAtlEvtPlayingCharacterInfo> AppEvtLipUniqueIDCharactersMap;
    [FieldOffset(0x00D0)] public TArray<FAtlEvtSoundSEInfo> EventSEInfoArray;
    [FieldOffset(0x00E0)] public AAtlEvtLightScenarioTransitionController* LightScenarioTransitionController;
    [FieldOffset(0x00E8)] public FEvtLocalData EvtLocalData;
    [FieldOffset(0x00F8)] public UAssetLoader* pLSAssetLoader;
    [FieldOffset(0x0100)] public UObject* LevelSequenceObject;
    */
    [FieldOffset(0x0148)] public UAtlEvtPreDataAsset* EvtPreDataAsset;
    [FieldOffset(0x0150)] public TMap<uint, FAtlEvtPreData> EvtPreDataMap;
    /*[FieldOffset(0x01A0)] public TWeakObjectPtr<UWorld> EventSublevelWorldObjPtr;
    [FieldOffset(0x01B8)] public TArray<FAtlEvtPlayLoadSublevelInfo> LoadedEventSublevelInfos;
    [FieldOffset(0x0270)] public TArray<FName> CurrentLoadedEventSublevels;
    [FieldOffset(0x0280)] public TArray<FAtlEvtAssetOverrideParameter> ReserveAssetOverrideParameter;
    [FieldOffset(0x0298)] public UAssetLoader* AssetOverrideLoader;
    [FieldOffset(0x02A0)] public TSubclassOf<ACharacter> AssetOverrideSubClass;
    [FieldOffset(0x02C8)] public AActor* BagActor;
    [FieldOffset(0x02D0)] public AAtlEvtOnePicture* OnePicture;
    */

    public static uint GetEvtPreDataHash(EAtlEvtEventCategoryType category, uint major, uint minor) // FUN_141097f20
    {
        uint uVar3 = major - minor ^ (uint)minor >> 0xd;
        uint uVar1 = (uint)(-0x61c88647 - uVar3) - minor ^ uVar3 << 8;
        uint uVar4 = (minor - uVar1) - uVar3 ^ uVar1 >> 0xd;
        uVar3 = (uVar3 - uVar1) - uVar4 ^ uVar4 >> 0xc;
        uVar1 = (uVar1 - uVar3) - uVar4 ^ uVar3 << 0x10;
        uVar4 = (uVar4 - uVar1) - uVar3 ^ uVar1 >> 5;
        uVar3 = (uVar3 - uVar1) - uVar4 ^ uVar4 >> 3;
        uVar1 = (uVar1 - uVar3) - uVar4 ^ uVar3 << 10;
        uVar1 = (uVar4 - uVar1) - uVar3 ^ uVar1 >> 0xf;
        uint iVar2 = uVar1 - (uint)category;
        uVar3 = 0x9e3779b9 - uVar1 ^ iVar2 * 0x100;
        uVar4 = ((uint)category - uVar3) - iVar2 ^ uVar3 >> 0xd;
        uVar1 = (iVar2 - uVar3) - uVar4 ^ uVar4 >> 0xc;
        uVar3 = (uVar3 - uVar1) - uVar4 ^ uVar1 << 0x10;
        uVar4 = (uVar4 - uVar3) - uVar1 ^ uVar3 >> 5;
        uVar1 = (uVar1 - uVar3) - uVar4 ^ uVar4 >> 3;
        uVar3 = (uVar3 - uVar1) - uVar4 ^ uVar1 << 10;
        return (uVar4 - uVar3) - uVar1 ^ uVar3 >> 0xf;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe struct FPersonaStatusListItem
{
}

[StructLayout(LayoutKind.Explicit, Size = 0x640)]
public unsafe struct APersonaStatus
{
    [FieldOffset(0x0000)] public AAppActor baseObj;
    //[FieldOffset(0x0520)] public UPersonaStatusSeq* Sequence_;
    [FieldOffset(0x0538)] public TArray<FPersonaStatusListItem> PersonaList;
    [FieldOffset(0x0548)] public TArray<FPersonaStatusListItem> RegistList;
    [FieldOffset(0x0580)] public APersonaStatusDraw* pPersonaStatusDraw;
}

[StructLayout(LayoutKind.Explicit, Size = 0x314)]
public unsafe struct FBD_CmmExistEntry
{
    [FieldOffset(0x0)] public short ArcanaId;
    [FieldOffset(0x4)] public int OkBitflag;
    [FieldOffset(0x8)] public int preOpenBitflag;
    [FieldOffset(0x10)] public int NGPlusBitflag;
    [FieldOffset(0x18c)] public int NPCBitflag;
    [FieldOffset(0x198)] public int SysHolidayBitflag;
    [FieldOffset(0x19c)] public int NationalHolidayBitflag;
    public unsafe bool GetCmmAvailable(int day)
    {
        fixed (FBD_CmmExistEntry* self = &this)
        {
            return ((byte*)((nint)self + 0x1c))[day] == 1 ? true : false;
        }
    }
    public unsafe void SetCmmAvailable(int day, byte value)
    {
        fixed (FBD_CmmExistEntry* self = &this)
        {
            ((byte*)((nint)self + 0x1c))[day] = value;
        }
    }
    public unsafe bool GetNormalAvailable(int day)
    {
        fixed (FBD_CmmExistEntry* self = &this)
        {
            return ((byte*)((nint)self + 0x1a4))[day] == 1 ? true : false;
        }
    }
    public unsafe void SetNormalAvailable(int day, byte value)
    {
        fixed (FBD_CmmExistEntry* self = &this)
        {
            ((byte*)((nint)self + 0x1a4))[day] = value;
        }
    }
}

public interface IContactManagerPayload
{
    public unsafe TPayload* Get<TPayload>() where TPayload : unmanaged, IContactManagerPayload;
    public unsafe UUIContactManagerPayload* Base();
    public EAppActorId GetPayloadType();
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct UUIContactManagerPayload : IContactManagerPayload
{
    [FieldOffset(0x0)] public EAppActorId payloadType;
    [FieldOffset(0x4)] public int msgId;
    public unsafe TPayload* Get<TPayload>() where TPayload : unmanaged, IContactManagerPayload
    { fixed (UUIContactManagerPayload* self = &this) { return (TPayload*)(self + 1); } }
    public unsafe UUIContactManagerPayload* Base()
    { fixed (UUIContactManagerPayload* self = &this) { return self; } }
    public EAppActorId GetPayloadType() => payloadType;
}

// from FieldActorGetInteractNameImpl
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe struct UICheckDrawPayload : IContactManagerPayload
{
    [FieldOffset(0x1c)] public int rank;
    [FieldOffset(0x20)] public int arcana;
    [FieldOffset(0x24)] public EFldHitCoreCheckIconType iconType;
    [FieldOffset(0x28)] public byte bIsCmmNpc;
    [FieldOffset(0x50)] public FString charName;
    public unsafe TPayload* Get<TPayload>() where TPayload : unmanaged, IContactManagerPayload
    { fixed (UICheckDrawPayload* self = &this) { return (TPayload*)self; } }
    public unsafe UUIContactManagerPayload* Base()
    { fixed (UICheckDrawPayload* self = &this) { return (UUIContactManagerPayload*)((nint)self - 0x8); } }
    public EAppActorId GetPayloadType() => Base()->payloadType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe struct UIRankupDrawPayload : IContactManagerPayload
{
    [FieldOffset(0x2c)] public int ArcanaNo;
    [FieldOffset(0x30)] public int ModeNo;
    public unsafe TPayload* Get<TPayload>() where TPayload : unmanaged, IContactManagerPayload
    { fixed (UIRankupDrawPayload* self = &this) { return (TPayload*)self; } }
    public unsafe UUIContactManagerPayload* Base()
    { fixed (UIRankupDrawPayload* self = &this) { return (UUIContactManagerPayload*)((nint)self - 0x8); } }

    public EAppActorId GetPayloadType() => Base()->payloadType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct UArcNpcExistField
{
    [FieldOffset(0x0)] public ushort FieldMajor;
    [FieldOffset(0x8)] public TArray<UArcNpcExistEntry> Entries;
}
[StructLayout(LayoutKind.Explicit, Size = 0x2f8)]
public unsafe struct UArcNpcExistEntry
{
    [FieldOffset(0x0)] public ushort NpcMajor;
    [FieldOffset(0x2)] public ushort NpcMinor;
    [FieldOffset(0x4)] public fixed uint EnableFlags[3];
    [FieldOffset(0x10)] public fixed uint DisableFlags[3];
    [FieldOffset(0x1c)] public fixed byte IsAvailable0[365];
    [FieldOffset(0x189)] public fixed byte IsAvailable1[365];
}

// 0x144290b20 (Episode Aigis)
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FldNpcExistTableEntry
{
    [FieldOffset(0x0)] public uint Major;
    [FieldOffset(0x4)] public uint Minor;
    [FieldOffset(0x8)] public nint pName; // char*
}

[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe struct FFldLoadLevelListData // DT_FldSubLevelList
{
    [FieldOffset(0x0000)] public FTableRowBase baseObj;
    [FieldOffset(0x0008)] public int FieldMajor;
    [FieldOffset(0x000C)] public int FieldMinor;
    [FieldOffset(0x0010)] public TArray<FString> Bg;
    [FieldOffset(0x0020)] public TArray<FString> Lighting_NOON;
    [FieldOffset(0x0030)] public TArray<FString> Lighting_EVENING;
    [FieldOffset(0x0040)] public TArray<FString> Lighting_NIGHT;
    [FieldOffset(0x0050)] public TArray<FString> Lighting_SHADOW;
    [FieldOffset(0x0060)] public TArray<FString> Sound;
    [FieldOffset(0x0070)] public TArray<FString> AreaChange;
    [FieldOffset(0x0080)] public TArray<FString> Hit;
    [FieldOffset(0x0090)] public TArray<FString> Hit_SHADOW;
    [FieldOffset(0x00A0)] public TArray<FString> NPC;
    [FieldOffset(0x00B0)] public TArray<FString> Npc_NOON;
    [FieldOffset(0x00C0)] public TArray<FString> Npc_EVENING;
    [FieldOffset(0x00D0)] public TArray<FString> Npc_NIGHT;
    [FieldOffset(0x00E0)] public TArray<FString> Npc_SHADOW;
    [FieldOffset(0x00F0)] public TArray<FString> Cmm_NOON;
    [FieldOffset(0x0100)] public TArray<FString> Cmm_EVENING;
    [FieldOffset(0x0110)] public TArray<FString> Cmm_NIGHT;
    [FieldOffset(0x0120)] public TArray<FString> CrowdTarget;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FFldLoadCrowdLevelDays
{
    [FieldOffset(0x0000)] public int StartMonth;
    [FieldOffset(0x0004)] public int StartDay;
    [FieldOffset(0x0008)] public int EndMonth;
    [FieldOffset(0x000C)] public int EndDay;
}

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe struct FFldLoadCrowdLevel // DT_FldCrowdSubLevelTable
{
    [FieldOffset(0x0000)] public FTableRowBase baseObj;
    [FieldOffset(0x0008)] public int FieldMajor;
    [FieldOffset(0x000C)] public int FieldMinor;
    [FieldOffset(0x0010)] public int FieldPartsID;
    [FieldOffset(0x0018)] public TArray<FFldLoadCrowdLevelDays> DayDatas;
    [FieldOffset(0x0028)] public int Time;
    [FieldOffset(0x0030)] public TArray<int> OnFlags;
    [FieldOffset(0x0040)] public TArray<int> OffFlags;
    [FieldOffset(0x0050)] public int Type;
    [FieldOffset(0x0058)] public FString LevelName;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct FFldLoadVariationLevel // DT_FldVariationSubLevelTable
{
    [FieldOffset(0x0000)] public FTableRowBase baseObj;
    [FieldOffset(0x0008)] public int FieldMajor;
    [FieldOffset(0x000C)] public int FieldMinor;
    [FieldOffset(0x0010)] public int StartMonth;
    [FieldOffset(0x0014)] public int StartDay;
    [FieldOffset(0x0018)] public int EndMonth;
    [FieldOffset(0x001C)] public int EndDay;
    [FieldOffset(0x0020)] public int Time;
    [FieldOffset(0x0024)] public int OnFlag;
    [FieldOffset(0x0028)] public int OffFlag;
    [FieldOffset(0x0030)] public FString LevelName;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct FFldPlaceNameNameTableRowBase // DT_FldPlaceName
{
    [FieldOffset(0x0000)] public FTableRowBase baseObj;
    [FieldOffset(0x0008)] public int Index;
    [FieldOffset(0x0010)] public FString Name;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct FFldShortcutNameTableRowBase // DT_FldShortcutName
{
    [FieldOffset(0x0000)] public FTableRowBase baseObj;
    [FieldOffset(0x0008)] public int Index;
    [FieldOffset(0x0010)] public FString Name;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct FFldHitNameTableRow // DT_FldDailyHitName, DT_FldDungeonHitName
{
    [FieldOffset(0x0000)] public FTableRowBase baseObj;
    [FieldOffset(0x0008)] public FString Name;
    [FieldOffset(0x0018)] public FString flag;
    [FieldOffset(0x0028)] public FString Name2;
}

[StructLayout(LayoutKind.Explicit, Size = 0x180)]
public unsafe struct FAppCharTableRow // DT_Costume
{
    [FieldOffset(0x0000)] public FTableRowBase baseObj;
    [FieldOffset(0x0008)] public float CapsuleHalfHeight;
    [FieldOffset(0x000C)] public FVector MeshLocation;
    //[FieldOffset(0x0018)] public TMap<EAnimPackID, TSoftObjectPtr<UAppCharAnimDataAsset>> Anims;
    [FieldOffset(0x0018)] public TMap<byte, TSoftObjectPtr<UAppCharAnimDataAsset>> Anims;
    [FieldOffset(0x0068)] public TSoftObjectPtr<UAppCharFaceAnimDataAsset> FaceAnim;
    [FieldOffset(0x0090)] public TMap<HashableInt8, FAppCharCostumeData> Costumes;
    [FieldOffset(0x00E0)] public TMap<HashableInt8, FAppCharWeaponData> WeaponType;
    [FieldOffset(0x0130)] public TMap<HashableInt8, FAppCharBagData> BagType;
}

[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe struct UAppCharAnimDataAsset
{
    [FieldOffset(0x0000)] public UDataAsset baseObj;
    [FieldOffset(0x0030)] public EAnimPackID PackId;
    //[FieldOffset(0x0031)] public EAppCharCategoryType Category;
    [FieldOffset(0x0034)] public int CharId;
    [FieldOffset(0x0038)] public UClass* AnimInstance;
    [FieldOffset(0x0040)] public TMap<int, IntPtr> SpecialAnimInstance;
    [FieldOffset(0x0090)] public TMap<int, IntPtr> Anims;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct UAppCharFaceAnimDataAsset
{
    [FieldOffset(0x0000)] public UDataAsset baseObj;
    //[FieldOffset(0x0030)] public EAppCharCategoryType Category;
    [FieldOffset(0x0034)] public int CharId;
    [FieldOffset(0x0038)] public TMap<int, IntPtr> Anims;
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct FAppCharCostumePartsData
{
    [FieldOffset(0x0000)] public TSoftObjectPtr<USkeletalMesh> Mesh;
    [FieldOffset(0x0028)] public TSoftClassPtr<UObject> Anim;
}

[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe struct FAppCharCostumeData
{
    [FieldOffset(0x0000)] public FAppCharCostumePartsData Base;
    [FieldOffset(0x0050)] public FAppCharCostumePartsData Costume;
    [FieldOffset(0x00A0)] public FAppCharCostumePartsData Hair;
    [FieldOffset(0x00F0)] public FAppCharCostumePartsData Face;
    [FieldOffset(0x0140)] public int BagKeyID;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FAppCharWeaponData
{
    //[FieldOffset(0x0000)] public TArray<TSoftClassPtr<AAppCharWeaponBase>> BluePrints;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct FAppCharBagData
{
    //[FieldOffset(0x0000)] public TSoftClassPtr<AAppPropsCore> Base;
    [FieldOffset(0x0028)] public FName AttachSocketName;
    [FieldOffset(0x0030)] public FName SetAnimSlotName;
    //[FieldOffset(0x0038)] public TMap<EAppCharBagAnimType, TSoftObjectPtr<UAnimSequenceBase>> AnimSeqs;
}