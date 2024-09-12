using System.Runtime.InteropServices;
namespace p3rpc.nativetypes.Interfaces;

#pragma warning disable CS1591

public enum EUIOTPRESET_BLEND_TYPE : uint
{
    EUI_Defult_Value = 0,
    UI_OT_PRESET_BLEND_OPAQUE = 0,
    UI_OT_PRESET_BLEND_SEMITRANS = 1,
    UI_OT_PRESET_BLEND_ADDTRANS = 2,
    UI_OT_PRESET_BLEND_SUBTRANS = 3,
    UI_OT_PRESET_BLEND_MULTRANS = 4,
    UI_OT_PRESET_BLEND_MUL2TRANS = 5,
    UI_OT_PRESET_BLEND_ADVANCED = 6,
    UI_OT_PRESET_BLEND_MAKE_MASK = 7,
    UI_OT_PRESET_BLEND_MAKE_MASK_MUL = 8,
    UI_OT_PRESET_BLEND_DRAW_ONLY_MASK = 9,
};

public enum EUIBlendOperation : byte
{
    EUI_Defult_Value = 0,
    UI_BO_Add = 0,
    UI_BO_Subtract = 1,
    UI_BO_Min = 2,
    UI_BO_Max = 3,
    UI_BO_ReverseSubtract = 4,
    UI_EBlendOperation_Num = 5,
    //UI_EBlendOperation_NumBits = 3,
};

public enum EUIBlendFactor : byte
{
    EUI_Defult_Value = 0,
    UI_BF_Zero = 0,
    UI_BF_One = 1,
    UI_BF_SourceColor = 2,
    UI_BF_InverseSourceColor = 3,
    UI_BF_SourceAlpha = 4,
    UI_BF_InverseSourceAlpha = 5,
    UI_BF_DestAlpha = 6,
    UI_BF_InverseDestAlpha = 7,
    UI_BF_DestColor = 8,
    UI_BF_InverseDestColor = 9,
    UI_BF_ConstantBlendFactor = 10,
    UI_BF_InverseConstantBlendFactor = 11,
    UI_BF_Source1Color = 12,
    UI_BF_InverseSource1Color = 13,
    UI_BF_Source1Alpha = 14,
    UI_BF_InverseSource1Alpha = 15,
    UI_EBlendFactor_Num = 16,
    //UI_EBlendFactor_NumBits = 4,
};

public enum ECldSceneChangeType : byte
{
    None = 0,
    TimeChange = 1,
    DayChange = 2,
};

public enum ECldDateColor : byte
{
    Normal = 0,
    Red = 1,
};

public enum EFldCharKeyType : byte
{
    Triangle = 1,
    Ok_Cross = 2,
    Square = 3,
    Cancel_Circle = 4,
    Up = 5,
    Down = 6,
    Right = 7,
    Left = 8,
    L1 = 9,
    L2 = 10,
    L3 = 11,
    R1 = 12,
    R2 = 13,
    R3 = 14,
    OPTION = 15,
    TOUCH = 16,
};

public enum EDungeonAnimID : uint
{
    BLANK = 0,
    Idel = 1,
    Walk = 2,
    Talk = 3,
    SatMain = 4,
    SatTalk = 5,
    SatA = 6,
    SatB = 7,
    SatN = 8,
    TurnL90 = 9,
    TurnR90 = 10,
    TurnL180 = 11,
    TurnR180 = 12,
    Run = 13,
    Dash = 14,
    AttackA = 50,
    AttackB = 51,
    AttackAssault = 52,
    DashStop = 53,
    DashStopTurn = 54,
    AttackDashA = 55,
    DoorOpen00 = 115,
    PersonalAction1 = 200,
    PersonalAction2 = 201,
    PersonalAction3 = 202,
    PersonalAction4 = 203,
    PersonalAction5 = 204,
    PersonalAction6 = 205,
    TurnL = 210,
    TurnR = 211,
};

public enum ECldDateMsgPeriod : byte
{
    Single = 0,
    Start = 1,
    Mid = 2,
    End = 3,
};

public enum appCalculationType
{
    Default_value = 0,
    LINEAR = 0,
    DEC = 1,
    ACC = 2,
    COS2 = 3,
    H_DEC = 4,
    H_ACC = 5,
    ACC_DEC = 6,
    SIN_2 = 7,
    AD_SIN = 8,
    LOOP = 9,
    //appCalculationType_MAX = 10,
};

public enum EUI_DRAW_POINT
{
    UI_DRAW_LEFT_TOP = 0,
    UI_DRAW_LEFT_CENTER = 1,
    UI_DRAW_LEFT_BOTTOM = 2,
    UI_DRAW_CENTER_TOP = 3,
    UI_DRAW_CENTER_CENTER = 4,
    UI_DRAW_CENTER_BOTTOM = 5,
    UI_DRAW_RIGHT_TOP = 6,
    UI_DRAW_RIGHT_CENTER = 7,
    UI_DRAW_RIGHT_BOTTOM = 8,
    //UI_DRAW_MAX = 9,
};

public enum EPERSONA_STATUS_DRAW_SCENE : byte
{
    NONE = 0,
    LIST = 1,
    MAIN = 2,
    LEVEL_UP = 3,
    PARAMETER_UP = 4,
    COMBINE = 5,
    DRAWER = 6,
    REGISTRY = 7,
    SKILL_CARD = 8,
    //EPERSONA_STATUS_DRAW_MAX = 9,
};

public enum EEvtCharaAnimationSlotType : byte
{
    User = 0,
    DefaultSlot = 1,
    EventSlot = 2,
    NodSlot = 3,
    FacialSlot = 4,
    ArmL = 5,
    ArmR = 6,
    //EEvtCharaAnimationSlotType_MAX = 7,
};

public enum EEvtCharaAnimationType : byte
{
    SimpleMontage = 0,
    LoopAnimationSingle = 1,
    LoopAnimationOnLastFrame = 2,
    StopSlotAnimation = 3,
    LoopAnimationSingleWithStartOffset = 4,
    KeepWorld = 5,
    //EEvtCharaAnimationType_MAX = 6,
};

public enum EEvtFadeScreenType : byte
{
    EVT_FADESCREEN_FADE_IN = 0,
    EVT_FADESCREEN_FADE_OUT = 1,
    EVT_FADESCREEN_CROSSFADE_IN = 2,
    EVT_FADESCREEN_CROSSFADE_OUT = 3,
    //EVT_FADESCREEN_MAX = 4,
};

public enum EAtlEvtEventCategoryType : byte
{
    MAIN = 0,
    CMMU = 1,
    QEST = 2,
    EXTR = 3,
    FILD = 4,
};

public enum EAppActorId : uint
{
    UIMiscMoneyDraw = 0,
    UIMiscCinemascopeDraw,
    UIMiscGetItemDraw,
    UIMiscCheckDraw,
    UITownMapActorDraw,
    UIDateDraw,
    UIKeyhelpDraw,
    UIActionSuggestionDraw,
    UIAccessInfoDraw,
    UIMailIconDraw,
    UIPartyPanel,
    UIFieldPartyPanel,
    UICampPartyPanel,
    UIRankupDraw,
    UIVelvetRoom,
    UIVelvetRoomRequest,
    UIMiscEnemySymbolDraw = 0x14,
    UIGetHeroParameterDraw,
    UICommunityPointDraw,
    UIMiscSupportPartyPanel,
    UITimeChange,
    UIDayChange,
    UIDungeonTransfer,
    UIMiscPictureDraw,
    UIHeroParameterStatus,
    CutinDraw,
    FclWeaponShop,
    FclItemShop,
    MailActor,
    TheurgiaActor,
    FclSimpleShop,
    FclAntiqueShop,
    GenericSelect,
    NameEntry,
    VoiceAction,
    VoiceAnswer,
    VoiceConnect,
    UIConfiguration,
    UIMissingPersonActor,
    UIVoiceConnectWatching
};

public enum EFldHitCoreCheckIconType
{
    Check = 0,
    Speak = 1,
    Listen = 2,
    Goto = 3,
    Action = 4,
    Shop = 5,
    None = 6,
    Max = 7,
};

public enum EAnimPackID : byte
{
    None = 0,
    Common = 1,
    Dungeon = 2,
    Combine = 3,
    Event = 4,
};

public enum EAppCharBagAnimType : byte
{
    EC_None = 0,
    EC_Stand = 1,
    EC_Run = 2,
};

public enum EAppCharCategoryType : byte
{
    None = 0,
    MainCharacter = 1,
    SubCharacter = 2,
    NpcCharacter = 3,
};