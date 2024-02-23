﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.nativetypes.Interfaces
{
    #pragma warning disable CS1591
    public enum FlowLib
    {
        SYNC = 0,
        WAIT,
        PUT,
        PUTS,
        PUTF,
        MSG,
        MSG_SEL,
        FADE_IN,
        FADE_OUT,
        FADEEND_CHECK,
        FADE_SYNC,
        SET_EXIT_VALUE,
        BIT_ON,
        BIT_OFF,
        BIT_CHK,
        SEL,
        MESSAGE_REF,
        CALL_TUTORIAL,
        MSG_WND_DSP,
        MSG_WND_CLS,
        CALL_CALENDAR,
        CALL_NEXTTIME,
        GET_TIME,
        GET_DAYOFWEEK,
        CHK_DAY,
        CHK_DAYS_STARTEND,
        CHK_TIME,
        CHK_DAYOFWEEK,
        CALL_LEVEL,
        SET_MSG_VAR,
        GET_COUNT,
        SET_COUNT,
        DBG_PUT,
        DBG_PUTS,
        RND,
        GET_AND,
        GET_OR,
        GET_XOR,
        GET_L_SHIFT,
        GET_R_SHIFT,
        REM,
        SIN,
        COS,
        TAN,
        ASIN,
        ACOS,
        ATAN,
        ATAN2,
        SQRT,
        GET_MAX,
        GET_MIN,
        SEL_DEFKEY,
        SET_NEXT_DAY,
        SEL_MASK,
        SEL_INDEX_MASK,
        SEL_GENERIC_EX,
        GET_MONEY,
        BGM,
        BGM_STOP,
        BGM_FADEIN,
        PARTY_IN,
        PARTY_OUT,
        GET_PARTY,
        CHK_PARTY_FULL,
        IS_PARTY_EXISTS,
        GET_MONTH,
        GET_DAY,
        GET_TOTAL_DAY,
        GET_MONTH_TOTAL_DAY,
        GET_DAY_TOTAL_DAY,
        MOVIE_PLAY,
        MOVIE_SYNC,
        SCHE_CALL_MORNING_EVENT,
        SCHE_CALL_TEACHING_EVENT,
        RECOVERY_ALL,
        RANDOM_BOX_CLEAR,
        RANDOM_BOX_SET_NUM,
        RANDOM_BOX_GET_NUM,
        RANDOM_BOX_CHECK_DATANUM,
        GET_EQUIP,
        SET_EQUIP,
        SET_PERSONA_LV,
        CLEAR_PERSONA_STOCK,
        ADD_PERSONA_STOCK,
        SET_EQUIP_PERSONA,
        ADD_PERSONA_SKILL,
        REMOVE_PERSONA_SKILL,
        PERSONA_EVOLUTION,
        CHK_PERSONA_EVOLUTION,
        CHECK_FULLHPSP_ALL,
        FADE_COLOR,
        GET_HP,
        GET_MAXHP,
        SET_HP,
        GET_SP,
        GET_MAXSP,
        SET_SP,
        GET_PC_LEVEL,
        SEL_GENERIC_MASK,
        SEL_GENERIC_INDEX_MASK,
        DBG_SCRIPT_START,
        ADD_PC_MONEY,
        CALL_TITLE,
        GET_PLAYER_LV,
        SEL_GENERIC_ITEM_EX,
        SEL_GENERIC_CAN_OPEN,
        SEL_GENERIC_ITEM_CAN_OPEN,
        SCHE_GET_PICTID_TEACH_QUESTION,
        SCHE_GET_PICTID_TEACH_ANSWER,
        ADD_SPECIAL_SKILL,
        REMOVE_SPECIAL_SKILL,
        CLEAR_SPECIAL_SKILL,
        SET_TP,
        GET_TP,
        GET_MAXTP,
        GET_EQUIP_PERSONA_PARAM,
        ADD_EQUIP_PERSONA_PARAMS,
        ADD_EQUIP_PERSONA_PARAMS_INC,
        COMSE_PLAY,
        COMSE_STOP,
        SET_HUMAN_LV,
        ADD_MAXHP_UP,
        GET_MAXHP_UP,
        ADD_MAXSP_UP,
        GET_MAXSP_UP,
        GET_SKILL_COST,
        DEBUG_SET_DAY,
        MDL_ICON,
        MDL_ICON_END,
        MDL_ICON_EX,
        MDL_ICON_SET_SCALE,
        CALL_DICTIONARY,
        SYNC_ACTIVITY,
        CHK_CHUNK_INSTALL,
        MSG_WINDOW_LAST,
        CHK_CHUNK_INSTALL_DIALOG,
        GET_ITEM_TYPE,
        GET_EQUIP_ENABLE_PLAYER,
        GET_ITEM_ATTACK,
        CHANGE_EQUIP_ITEM,
        SEL_GENERIC_SHOP,
        GET_ITEM_DEFENCE,
        GET_ITEM_EVASION,
        GET_PERSONA_STOCK_NUM,
        GET_PERSONA_STOCK_MAX,
        GET_STOCK_PERSONA_MAX_LEVEL,
        CHK_ARBEIT_ENABLE,
        MOVIE_LOAD,
        MOVIE_PLAY_WITHOUT_LOAD,
        MOVIE_SYNC_AND_FADE_OUT_WITH_COLOR,
        REQUEST_DAY_CHANGE_EFFECT,
        SEL_DEFKEY_CLEAR,
        MOVIE_ENABLE_BGM_PAUSE,
        MOVIE_ENABLE_PLAY_BATTLEWIPE_SE,

        AI_SEQUENCE_BEGIN = 0x1000,
        AI_ACT_ATTACK,
        AI_ACT_SKILL,
        AI_ACT_GUARDORDER,
        AI_TAR_HERO,
        AI_TAR_MINE,
        AI_TAR_RND,
        AI_TAR_MYAI,
        AI_TAR_HPMIN,
        AI_TAR_HPMAX,
        AI_TAR_BAD,
        AI_TAR_NOTBAD,
        AI_TAR_HOJO,
        AI_TAR_NOTHOJO,
        AI_TAR_DOWN,
        AI_TAR_STAND,
        AI_TAR_ID,
        AI_TAR_NOTID,
        AI_TAR_APPOINT,
        AI_TAR_MPMAX,
        AI_TAR_SPMAX,
        AI_CHK_MORE,
        AI_CHK_FRID,
        AI_CHK_ENID,
        AI_CHK_TURN,
        AI_CHK_TURN_O,
        AI_CHK_BOSS,
        AI_CHK_ESCAPE,
        AI_CHK_ANALYZE,
        AI_CHK_DOWN,
        AI_CHK_SLIP,
        AI_CHK_MYWEAK,
        AI_CHK_FRWEAK,
        AI_CHK_ENWEAK,
        AI_CHK_MYMUKOU,
        AI_CHK_FRMUKOU,
        AI_CHK_ENMUKOU,
        AI_CHK_ENTAISEI,
        AI_CHK_MYHANSYA,
        AI_CHK_FRHANSYA,
        AI_CHK_ENHANSYA,
        AI_CHK_MYKYUSYU,
        AI_CHK_FRKYUSYU,
        AI_CHK_ENKYUSYU,
        AI_CHK_PREV_ATK,
        AI_CHK_PREV_WAIT,
        AI_CHK_MYUSESKIL,
        AI_CHK_FRUSESKIL,
        AI_CHK_ENUSESKIL,
        AI_CHK_MYHP,
        AI_CHK_MYMP,
        AI_CHK_MYSP,
        AI_CHK_FRHP,
        AI_CHK_ENHP,
        AI_CHK_ENHP_O,
        AI_CHK_UNIHP,
        AI_CHK_FRCNT,
        AI_CHK_ENCNT,
        AI_CHK_MYBAD,
        AI_CHK_FRBAD,
        AI_CHK_ENBAD,
        AI_CHK_UNIBAD,
        AI_CHK_NOTMYBAD,
        AI_CHK_NOTFRBAD,
        AI_CHK_NOTENBAD,
        AI_CHK_MYHOJO,
        AI_CHK_FRHOJO,
        AI_CHK_ENHOJO,
        AI_CHK_NOTMYHOJO,
        AI_CHK_NOTFRHOJO,
        AI_CHK_NOTENHOJO,
        AI_CHK_FRIDHP,
        AI_CHK_FRIDBAD,
        AI_CHK_FRIDBAD_ALL,
        AI_CHK_FRIDHOJO,
        AI_CHK_FRIDWEAK,
        AI_CHK_FRIDMUKOU,
        AI_CHK_FRIDHANSYA,
        AI_CHK_FRIDKYUSYU,
        AI_CHK_FRIDUSESKIL,
        AI_GET_FIRST_ACTION,
        AI_GET_ENBADOFF,
        AI_GET_MYATTRATTACK,
        AI_GET_ENID_MAXSERIAL,
        AI_GET_P_NUM,
        AI_GET_E_NUM,
        AI_GET_FRHP,
        AI_GET_UNIRANDOM,
        AI_GET_UNIATAB,
        AI_GET_UNIATAB_ST,
        AI_GET_UNIATAB_DW,
        AI_GET_UNIWEAK,
        AI_GET_UNIWEAK_ST,
        AI_GET_UNIWEAK_DW,
        AI_GET_UNIHANSYA,
        AI_GET_UNIKYUSYU,
        AI_GET_UNIMUKOU,
        AI_GET_UNIRESIST,
        AI_RND,
        AI_GET_GLOBAL,
        BTL_GET_COUNTER,
        AI_SET_GLOBAL,
        BTL_SET_COUNTER,
        BTL_GET_CURRENT_CHARAID,
        CALL_FIELDBATTLE,
        CALL_EVENTBATTLE,
        AI_CHK_MYGROUP,
        AI_CHK_FRGROUP,
        AI_CHK_ENGROUP,
        AI_ACT_ESCAPE,
        AI_ADD_REINFORCEMENT,
        AI_CHK_SUMMONCNT,
        AI_TAR_HANSYA,
        AI_TAR_KYUSYU,
        AI_TAR_MUKOU,
        AI_TAR_WEAK,
        AI_TAR_NOTHANSYA,
        AI_TAR_NOTKYUSYU,
        AI_TAR_NOTMUKOU,
        AI_TAR_NOTWEAK,
        AI_TAR_HANSYA_ST,
        AI_TAR_KYUSYU_ST,
        AI_TAR_MUKOU_ST,
        AI_TAR_WEAK_ST,
        AI_TAR_NOTHANSYA_ST,
        AI_TAR_NOTKYUSYU_ST,
        AI_TAR_NOTMUKOU_ST,
        AI_TAR_NOTWEAK_ST,
        AI_ACT_WAIT,
        AI_ACT_SKIP,
        AI_ACT_WAIT2,
        BTL_SHUFFLE_DECIDE_MAJORARCANA,
        BTL_SHUFFLE_CLEAN_FLAG_ALL,
        BTL_SHUFFLE_CLEAN_FLAG_ENTRANCE,
        AI_CHK_FMTPINCH,
        AI_CHK_FMTADVANTAGE,
        AI_CHK_FMTNML,
        AI_CHK_FRALLHP,
        AI_CHK_ENALLHP,
        AI_CHK_ENBAD_ALL,
        AI_CHK_FRBAD_NOTALL,
        AI_CHK_ENBAD_NOTALL,
        AI_CHK_MYID,
        AI_CHK_MYTAISEI,
        AI_CHK_FRTAISEI,
        AI_CHK_FRWEAK_ST,
        AI_CHK_ENWEAK_ST,
        AI_CHK_FRMUKOU_ST,
        AI_CHK_ENMUKOU_ST,
        AI_CHK_FRTAISEI_ST,
        AI_CHK_ENTAISEI_ST,
        AI_CHK_FRHANSYA_ST,
        AI_CHK_ENHANSYA_ST,
        AI_CHK_FRKYUSYU_ST,
        AI_CHK_ENKYUSYU_ST,
        AI_CHK_MYUSEATTR,
        AI_CHK_FRUSEATTR,
        AI_CHK_ENUSEATTR,
        AI_CHK_MYABLESKIL,
        AI_CHK_MYATTRSKIL,
        AI_CHK_MYHREC,
        AI_CHK_SUMMONED,
        AI_CHK_ENCOUNT,
        AI_TAR_MAN_RND,
        AI_TAR_WOMAN_RND,
        AI_TAR_NOTSUPPORTID,
        AI_TAR_NOTBADID,
        AI_CHK_FRIDSP,
        AI_CHK_FRIDLV_O,
        AI_CHK_FRIDUSEATTR,
        AI_CHK_FRIDUSEGROUP,
        AI_CHK_FRIDHREC,
        AI_CHK_ENIDHP,
        AI_CHK_ENIDSP,
        AI_CHK_ENIDLV_O,
        AI_CHK_ENIDBAD,
        AI_CHK_ENIDBAD_ALL,
        AI_CHK_ENIDHOJO,
        AI_CHK_ENIDWEAK,
        AI_CHK_ENIDMUKOU,
        AI_CHK_ENIDHANSYA,
        AI_CHK_ENIDKYUSYU,
        AI_CHK_ENIDUSESKIL,
        AI_CHK_ENIDUSEATTR,
        AI_CHK_ENIDUSEGROUP,
        AI_CHK_ENIDHREC,
        AI_CHK_SEQUENCE,
        AI_CHK_TURNEQUAL,
        AI_CHK_TURNDIVI,
        AI_GET_P_ORDER,
        AI_GET_MY_ID,
        AI_GET_UNI,
        BTL_COUNTDOWN_START,
        BTL_COUNTDOWN_STOP,
        BTL_COUNTDOWN_PLAY,
        BTL_COUNTDOWN_SPEED,
        BTL_CINEMASCOPE_START,
        BTL_CINEMASCOPE_END,
        BTL_CUTSCENE_LOAD,
        BTL_CUTSCENE_LOADSYNC,
        BTL_CUTSCENE_PLAY,
        BTL_CUTSCENE_SYNC,
        BTL_CUTSCENE_END,
        BTL_COUNTDOWN_VISIBLE,
        BTL_COUNTDOWN_HIDDEN,
        BTL_UI_VISIBLE,
        BTL_UI_HIDDEN,
        BTL_PLAY_BG_RAIL_ANIM,
        BTL_REQ_ASSIST,
        BTL_PLAY_BG_STRAP_ANIM,
        AI_ACT_SKILL_EX,
        BTL_PLAY_BG_ANIM,
        BTL_CUTSCENE_PLAY_ACTOR3,
        AI_GET_ENID_ACTTURNCOUNT,
        AI_SET_ENID_MAXACTTURN,
        AI_GET_FRID_ACTTURNCOUNT,
        AI_SET_FRID_MAXACTTURN,
        AI_CHK_FRBAD_ALL,
        BTL_REQ_ASSIST_SEQ,
        BTL_CHK_PARTYIN_ID,
        AI_ACT_TAKEOVER,
        AI_CHK_TAKEOVER,
        BTL_GET_NYX_ID,
        AI_CHK_UNIATTACK,
        AI_TAR_UID,
        AI_GET_P_NOW_HP,
        AI_GET_P_NOW_SP,
        AI_GET_P_MAX_HP,
        AI_GET_P_MAX_SP,
        AI_GET_UNIHPMIN,
        AI_CHK_UNIANALYZE_OPEN,
        AI_CHK_ID_FRTARGET,
        AI_GET_UNI_NOANALYZE,
        AI_GET_UNI_ATTACK,
        AI_CHK_UNINOMAL,
        AI_GET_FRBAD_ON,
        AI_GET_ENBAD_ON,
        AI_CHK_UNIHOJO,
        AI_GET_ATTRSKIL,
        AI_CHK_EXCEPT_ENCOUNT,
        AI_CHK_ABLEWEAK,
        AI_GET_UNIBESTATTRSKIL,
        AI_ACT_HIGHSKILL,
        AI_ACT_HEAL,
        AI_ACT_ATTACK_WEAK,
        AI_ACT_REZ,
        AI_ACT_BADSKILL,
        AI_ACT_BADSTATE,
        AI_ACT_DEBUFF,
        AI_ACT_FIXED,
        AI_ACT_UNKNOWN_ATTR,
        AI_CHK_THEURGIA,
        AI_ACT_THEURGIA,
        AI_GET_UNIQUE_HIT_HPMIN,
        BTL_KEY_ENABLE,
        AI_GET_ENCOUNT_ID,
        AI_SET_MANUAL_OPERATE,
        AI_TAR_TAKAYAJOIN_ID,
        BTL_RELOCATION,
        BTL_PLAY_EVENT_VOICE,
        BTL_EVENT_RETURN_VALUE,
        BTL_GET_ERZ_ID,
        AI_CHK_PREV_DAMAGE_ATTR,
        BTL_COUNTDOWN_REDUCE,
        BTL_COUNTDOWN_TIME_GET,
        BTL_TP_ANIMATION,
        BTL_PARTYPANEL_DISP,
        BTL_PARTYPANEL_HIDE,
        BTL_END_FADE_IN,
        BTL_RELOCATION_BTLEND,
        BTL_SET_FORCE_MSG_MODE,
        BTL_TUTORIAL_REQUEST,
        BTL_CUTSCENE_ALLLOAD,
        BTL_CUTSCENE_ALLLOADSYNC,
        AI_TAR_BAD_ST,
        AI_TAR_NOTBAD_ST,
        BTL_SET_SHOW_BADSTATUS_ICON,
        BTL_WIPE_IN,
        BTL_WIPE_SYNC,
        BTL_CHK_HIGH_ANALYZE,

        FLD_LOCAL_FLAG_ON = 0x2000,
        FLD_LOCAL_FLAG_OFF,
        FLD_LOCAL_FLAG_CHECK,
        FLD_LOCAL_COUNTER_SET,
        FLD_LOCAL_COUNTER_GET,
        CALL_FIELD,
        CALL_KEYFREE_EVENT,
        CALL_DUNGEON,
        DUNGEON_NEXTFLOOR,
        DUNGEON_TRANSFER,
        DUNGEON_CONTINUATION,
        DUNGEON_EVACUATION,
        GET_FIELD_PARTS_ID,
        FLD_GET_MAJOR,
        FLD_GET_MINOR,
        FLD_GET_KEYFREE_EVENT_ID,
        GOTO_TARTARUS,
        FLD_RETURN_FIELD,
        GET_FIELD_START_ID,
        DUNGEON_MOVE_FDOOR,
        FLD_SOUND_VOICE_SETUP,
        FLD_SOUND_VOICE_SYNC,
        FLD_SOUND_VOICE_FREE,
        DUNGEON_GET_FLOORNO,
        DUNGEON_GET_ARRIVAL_FLOORNO,
        DUNGEON_CHECK_MISSING_FLOOR,
        FLD_GET_FAM_INDEX_OBJECT,
        FLD_GET_FAM_INDEX_NPC,
        FLD_GET_FAM_INDEX_CMMNPC,
        FLD_FAM_ANIM,
        FLD_FAM_ACTOR_SET_VISIBLE,
        FLD_START_FIELD_EVENT,
        FLD_PC_MODEL_SET_POS,
        FLD_REQ_BGM,
        DUNGEON_DESTORY_DIRECT_SYMBOL,
        DUNGEON_SPSKILL_TARTARUSSEARCH,
        DUNGEON_SPSKILL_JAMMING,
        DUNGEON_SPSKILL_ESCAPEROAD,
        DUNGEON_PARTY_DISPERSED,
        DUNGEON_PARTY_ASSEMBLE,
        DUNGEON_TBOX_GET_ITEM_ID,
        DUNGEON_TBOX_GET_ITEM_NUM,
        DUNGEON_TBOX_GET_MONEY,
        DUNGEON_REMOVE_TBOX_ITEMINFO,
        FLD_CHARA_WALK_TRANSLATE,
        FLD_CHARA_SYNC_TRANSLATE,
        DUNGEON_TBOX_GET_TYPE,
        DUNGEON_PARTNER_TBOX_NUM,
        DUNGEON_PARTNER_ITEM_ID,
        DUNGEON_PARTNER_ITEM_NUM,
        DUNGEON_PARTNER_MONEY,
        DUNGEON_ACCIDENT_CHANGE_SYMBOL,
        DUNGEON_ACCIDENT_DARK_ZONE,
        DUNGEON_ACCIDENT_PARTY_DIVISION,
        DUNGEON_ACCIDENT_ABNORMAL_STATE,
        DUNGEON_ACCIDENT_IMMEDJATE_EFFECT,
        DUNGEON_ACCIDENT_LIMITED_BATTLE,
        DUNGEON_OPEN_TBOX,
        FLD_NPC_FLAG_ON,
        FLD_NPC_FLAG_OFF,
        FLD_NPC_FLAG_CHECK,
        DUNGEON_MOVE_FREEID,
        DUNGEON_INFO_SUPPORT,
        DUNGEON_BEGINEVENT,
        DUNGEON_ENDEVENT,
        SET_FIELD_PARTS_ID,
        FLDANIMOBJ_REQUEST_ANIMATION,
        DUNGEON_CHECK_OPEN_FDOOR,
        DUNGEON_PARTNER_ITEM_PAC_NUM,
        DUNGEON_PARTNER_ITEM_REFLECT,
        DUNGEON_CHECK_GATEKEEPER_FLOOR,
        DUNGEON_CHECK_FDOOR_FLOOR,
        FLD_FAM_SYNC_ANIM,
        DUNGEON_ATOMFOG_HIDDEN,
        DUNGEON_TBOX_CHECK_ENCOUNT,
        FLD_TV_PROGRAM_ON,
        FLD_TV_PROGRAM_OFF,
        FLD_TV_PROGRAM_CHECK,
        FLD_TV_MODEL_REQ_ANIME,
        FLD_COMSE_PLAY,
        FLD_COMSE_STOP,
        DUNGEON_FLOORFLAGS_CHECK_EXIST,
        DUNGEON_FLOORFLAGS_CHECK_FLAG,
        DUNGEON_FLOORFLAGS_SET_FLAG,
        FLD_MAIL_ORDER_CHECK,
        FLD_MAIL_ORDER_RECIEVE_CHECK,
        FLD_MAIL_ORDER_GET_INDEX,
        FLD_MAIL_ORDER_VSET,
        FLD_MAIL_ORDER_GET_MONEY,
        FLD_MAIL_ORDER_SET_ITEM,
        FLD_MAIL_ORDER_GET_ITEM_MSGID,
        FLD_MAIL_ORDER_CALL_SCRIPT,
        FLD_MAIL_ORDER_PAY_THE_PRICE,
        FLD_CAMERA_LOCK_INTERP,
        FLD_CAMERA_LOCK_SYNC_INTERP,
        FLD_CAMERA_DEFAULT_INTERP,
        FLD_CAMERA_LOCK,
        FLD_CAMERA_UNLOCK,
        FLD_GET_FAM_INDEX_PLAYER,
        FLD_OPEN_ORD_DOOR_FADE,
        FLD_PC_MODEL_SET_ROTATOR,
        FLD_SET_DOOR_STATE,
        FLD_SET_HERO_NO_WEAPON,
        FLD_SET_HERO_NO_FOLLOWER,
        DUNGEON_FIELDBATTLE_END,
        DUNGEON_GET_ENEMY_NUM,
        FLD_START_BOSS,
        DUNGEON_SET_ENEMY_CONDITION,
        FLD_FAM_SET_DELAY_STOP,
        FLD_FAM_CLEAR_DELAY_STOP,
        FLD_FAM_CLEAR_DELAY_STOP_ALL,
        DUNGEON_RETRY_BACKUP,
        DUNGEON_RETRY_RESTORE,
        FLD_FAM_ICON_START,
        FLD_FAM_ICON_START_EX,
        FLD_FAM_ICON_END,
        FLD_FAM_ICON_SET_SCALE,
        DUNGEON_SET_FLOOR_OPEN,
        DUNGEON_CHECK_FLOOR_OPEN,
        DUNGEON_FIELDBATTLE_CLEAR_KEYLOCK,
        DUNGEON_INFO_SUPPORT_TALK,
        DUNGEON_GET_MISSING_ID,
        DUNGEON_INFO_SUPPORT_WAIT,
        DUNGEON_ROLLBACK,
        DUNGEON_REAPER_APPEAR_TIME,
        DUNGEON_REAPER_CONTINUE_APPEAR_TIME,
        DUNGEON_REAPER_SPAWN_START_PART,
        DUNGEON_CHECK_PLAYER_START_PART,
        SCHE_CHECK_MORNING_EVENT_MSGREF,
        SCHE_CHECK_TEACHING_EVENT_MSGREF,
        DUNGEON_SET_EVENT_TRANS_ORIGIN,
        FLD_FAM_FACE_ANIM,
        FLD_FAM_NECK_ANIM,
        FLD_FAM_SYNC_NECK_ANIM,
        DUNGEON_AUTO_RECOVER,
        DUNGEON_SUPPORT_SKILL,
        FLD_GET_FAM_INDEX_DOOR,
        DUNGEON_CHECK_PC_SKILL,
        DUNGEON_SET_PARTNER_POS,
        DUNGEON_EXECUTE_PARTNER_POS,
        DUNGEON_GET_AREA,
        DUNGEON_GET_AREA_MINOR,
        FLD_FAM_SET_IMD_STOP,
        FLD_CHARA_START_TURN,
        FLD_CHARA_SYNC_TURN,
        FLD_FAM_END_ANIM,
        FLD_MODEL_DIR_TRANSLATE,
        FLD_PC_MODEL_SET_LOCATION,
        DUNGEON_GET_TBOX_NUM,
        FLD_CHARA_MOVE_TO_FRONT_CHARA,
        FLD_CHK_HERO_HAVE_BAG,
        DUNGEON_EVENT_BATTLE_WIPE_START,
        FLD_CHK_CAMERA_LOCK,
        DUNGEON_GET_MONAD_ENCOUNTID,
        DUNGEON_FORCED_OPEN_TBOX,
        DUNGEON_CLEAR_EVENT_TRANS_ORIGIN,
        DUNGEON_TBOXSE_STOP,
        FLD_SET_FIELD_EVENT_NO_WEAPON,
        DUNGEON_DESTROY_MISSING_NPC,
        DUNGEON_MISSING_SE_STOP,
        FLD_CAMERA_LOCK_INTERP_RELATIVE,
        DUNGEON_SITUATION_HELP,
        DUNGEON_SITUATION_HELP_ITEM,
        DUNGEON_PARTNER_RELOAD,
        FLD_HERO_MODEL_RELOAD,
        FLD_OVERWRITE_CAMERA_PITCH,
        FLD_HERO_REGIST_PHONE_MODEL,
        FLD_CAMERA_SHAKE_START,
        FLD_CAMERA_SHAKE_END,
        FLD_HERO_FUKIDASHI_START,
        FLD_HERO_FUKIDASHI_END,
        FLD_FREECAMERA_RESET,
        DUNGEON_SITUATION_HELP_MONEY,
        FLD_CAMERA_GET_DOT_HORIZON,
        FLD_NPC_RELOAD,
        DUNGEON_SECRETGATE_SPAWN,
        DUNGEON_TALK_SETDELAY,
        DUNGEON_TALK_WAITDELAY,
        DUNGEON_CHARACOSTUME_RELOAD,
        DUNGEON_SEPARATELEY_REQUEST,
        DUNGEON_SEPARATELEY_GETITEMTYPENUM,
        DUNGEON_SEPARATELEY_GETITEMID,
        DUNGEON_SEPARATELEY_GETITENUM,
        DUNGEON_SEPARATELEY_PARTYIN,
        FLD_FOLLOWER_MODEL_RESET_POS,
        FLD_CHARA_SET_LOOKAT_ROTATION,
        FLD_CHARA_CLEAR_LOOKAT,
        FLD_NPC_PAUSE_IDOL_TALK,
        FLD_NPC_RESTART_IDOL_TALK,
        FLD_CHARA_SET_LOOKAT_TARGET,
        DUNGEON_GET_PARTNUM,
        DUNGEON_RESET_CHARA_BEHAVIOR,
        DUNGEON_ENEMY_DIE,
        FLD_MOVE_FLOOR_DAILY,
        DUNGEON_GET_TBOX_ITEM_SET_COUNTER,
        FLD_FAM_MODEL_LOOKAT_ROTATION,
        FLD_FAM_MODEL_LOOKAT_TARGET,
        FLD_FAM_MODEL_CLEAR_LOOKAT,
        DUNGEON_ENEMY_DIE_EFFECT,
        FLD_SOUND_POST_VOLUME_SET_LOCK,
        FLD_SOUND_POST_VOLUME_CLEAR_LOCK,
        FLD_CHARA_START_TURN_TO_NPC,
        FLD_MODEL_START_TURN_TO_MODEL,
        FLD_CHECK_INIT_AFTER_LOAD_SAVEDATA,
        FLD_REQ_ALL_LINK_ANIM_OBJ_END_MOTION,
        FLD_RECREATE_MODEL_HEAD_ICON,
        FLD_REQ_TURN_DOWN_VOLUME,
        FLD_RESET_TURN_DOWN_VOLUME,
        FLD_SYNC_TURN_DOWN_VOLUME,
        FLD_RESET_HERO_OPACITY,
        FLD_REQ_ALL_LINK_ANIM_OBJ_MOTION_FORCE,
        DUNGEON_RESET_CHARA_QUICK,
        FLD_SOUND_AISAC_CTRL_FORCE_LOCK,
        FLD_SOUND_AISAC_CTRL_FORCE_UNLOCK,
        FLD_FAM_OBJ_GET_NOW_ANIM_INDEX,

        CMM_GET_LV = 0x3000,
        CMM_SET_LV,
        CMM_LVUP,
        CMM_CHK_LVUP,
        CMM_EXEC_EVENT,
        CMM_SET_REVERSE_POINT,
        CMM_CHK_ARCANA_PSSTOCK,
        CMM_CALL_CONF_COMMUNITY,
        CMM_CHECK_HERO_PARAM_LOCK,
        GET_HERO_PARAM_LV,
        DISP_HERO_PARAM_METER,
        DISP_HERO_PARAM_RANK_UP,
        ADD_HERO_PARAM_EXP,
        CMM_GET_REVERSE_POINT,
        GET_STOCK_PERSONA_ID,
        CMM_PC_NAME,
        CMM_NAME,
        HERO_PARAM_ALL_ADD_EXP,
        CMM_ADD_ID,
        CMM_CHECK_HOLIDAY_EVENT,
        CMM_HOLIDAY_EVENT_GET_ARCANAID,
        CMM_CALL_EVENT_SET_ARCANAID,
        CMM_EXEC_HOLIDAY_EVENT,
        CMM_GET_PRESENT_REACTION_MESSAGE_LABEL,
        CMM_GET_PRESENT_HERO_MESSAGE_LABEL,
        CMM_GET_PRESENT_POINT,
        CMM_CHECK_SUMMER_FESTIVAL_EVENT,
        CMM_GET_SUMMER_FESTIVAL_EVENT_MAILID,
        CMM_EXEC_SUMMER_FESTIVAL_EVENT,
        CMM_CHECK_MOVIES_EVENT,
        CMM_GET_MOVIES_EVENT_MAILID,
        CMM_EXEC_MOVIES_EVENT,
        CMM_CHECK_CHRISTMAS_EVENT,
        CMM_GET_CHRISTMAS_EVENT_MAILID,
        CMM_EXEC_CHRISTMAS_EVENT,
        CMM_SET_PC_NAME_V,
        CMM_GET_PRESENT_CHRISTMAS_REACTION_MESSAGE_LABEL,

        CALL_EVENT = 0x4000,
        CALL_EVENT_CMM,
        CUTIN_START,
        CUTIN_STOP,
        EVT_SET_LOCAL_COUNT,
        EVT_GET_LOCAL_COUNT,
        EVT_SET_LOCAL_DATA,
        EVT_GET_LOCAL_DATA,
        CUTIN_START_EX,
        BACKLOG_ADD_INVALID_ON,
        BACKLOG_ADD_INVALID_OFF,
        NET_START_ANSWER,
        NET_END_ANSWER,
        EVT_ASSET_OVERWRITE,
        EVT_SE_PLAY,
        EVT_SE_STOP,
        EVT_SEND_ANSWER_SELINFO,
        EVT_ATTACH_BAG,
        EVT_DESTROY_BAG,
        EVT_PUSH_TEXTURE_TO_LOAD,
        EVT_START_LODING_TEXTURE,
        EVT_LOAD_TEXTURE_SYNC,
        EVT_SHOW_TEXTURE,
        EVT_HIDE_TEXTURE,
        EVT_CALL_BATTLE_WIPE,
        EVT_SHOW_TEXTURE_DEFAULT,
        EVT_ENABLE_SKIP_BC,
        EVT_GAMEOVER_POEM,
        EVT_HIDE_CHARACTER,
        EVT_GET_FADE_COLOR,
        EVT_FCL_VOICE_STOP,

        CALL_WEAPON_SHOP_LV = 0x5000,
        CALL_ITEM_SHOP_LV,
        CALL_VELVET_ROOM_LV,
        CALL_PUBLIC_SHOP,
        CALL_ANTIQUE_SHOP_LV,
        UI_DUMMY4,
        UI_DUMMY5,
        UI_DUMMY6,
        UI_DUMMY7,
        UI_DUMMY8,
        UI_DUMMY9,
        UI_DUMMY10,
        UI_DUMMY11,
        UI_DUMMY12,
        UI_DUMMY13,
        UI_DUMMY14,
        CALL_MONEY_PANEL,
        CLOSE_MONEY_PANEL,
        CALL_ADD_MONEY,
        CINEMASCOPE_START,
        CINEMASCOPE_END,
        ADD_GET_ITEM_LIST,
        OPEN_GET_ITEM,
        RESET_GET_ITEM_LIST,
        GET_ITEM_NUM,
        SET_ITEM_NUM,
        CALL_LMAP,
        CLOSE_LMAP,
        CMM_RANKUP,
        ADD_GET_ITEM_LIST_MONEY,
        OPEN_SUPPORT_PARTY_PANEL,
        CLOSE_SUPPORT_PARTY_PANEL,
        FAKE_DATE_SET,
        FAKE_DATE_RESET,
        CHANGE_MINIMAP,
        OPEN_MAIL_MENU,
        CLOSE_MAIL_MENU,
        RECEIVE_MAIL_CONDITIONAL,
        RECEIVE_MAIL_FORCIBLY,
        RESET_MAIL_BOX,
        GET_SAVED_DISAPPEAR_ID,
        GET_DISAPPEAR_AWARD,
        MASTERY_THEURGIA_DRAW,
        DUNGEON_LMAP_OPEN,
        SET_HIDE_MINIMAP,
        SET_MONAD_MINIMAP,
        GET_RECEIVED_MAIL_NUM,
        CINEMASCOPE_START_ANIME,
        CINEMASCOPE_END_ANIME,
        CALL_DISAPPEAR_LIST,
        SET_ACTION_RECORD,
        OPEN_PICTURE,
        CLOSE_PICTURE,
        CALL_CAMP_CALENDAR,
        CALL_NAME_ENTRY,
        OPEN_MAIL_MENU_WITH_SET_ID,
        FRIEND_SKILL_ADD,
        CHK_FRIEND_SKILL_ADD,
        SET_ADD_MONEY_PLANS,
        SET_VELVET_VTAG,
        CALL_ADD_MONEY_AUTO_CLOSE,
        MONEY_PANEL_COLOR_CHANGE,
        CALL_VELVET_REQUEST,
        GET_ORDERED_REQUEST_ID,
        ADD_REQUEST_ITEM_AND_CLEAR_FLAG_ON,
        GET_ORDERED_REQUEST_TOTAL,
        LIMIT_DISP,
        GET_CANCEL_REQUEST_TOTAL,
        GET_HAVE_PERSONA,
        GET_HAVE_PERSONA_LV,
        TROPHY_REQUEST,
        ORDER_QUEST,
        QUEST_LIST_ALL_INFO_DISPLAY,
        GET_ADC_ITEM_WINDOW,
        CHECK_ADC_ITEM_VALID,
        CHECK_NEW_QUEST_EXIST,
        GET_PERSONA_REGIST_PERCENT,
        CMM_POINT_ANIM_SYNC,
        SET_ITEM_NUM_EX,
        CHECK_DATA_INHERITANCE,
        GET_THEURGIA_SKILL_ADD_DRAW_LIST,
        GET_THEURGIA_SKILL_DRAW,
        GET_ORDERED_REQUEST_ID_SELECT,
        GET_REQUEST_STATUS,
        CALL_CLEAR_SAVE,
        LOAD_STAFFROLL,
        CALL_STAFFROLL,
        GET_ADC_ITEM_WINDOW_SYNC,
        IN_NAMEENTRY,
        OUT_NAMEENTRY,
        RECOVERY_EFFECT_FIELD_PARTY_PANEL,
        VELVET_WIPE_WITH_FADE_FLAG_TRUE,
        RESET_FOOT_MINIMAP,
    }
}