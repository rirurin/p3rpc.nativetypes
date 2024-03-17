using p3rpc.nativetypes.Interfaces;
using SharedScans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.nativetypes.Components
{
    internal class UIMethods
    {
        private string GetSpriteItemMaskInstance_SIG = "E8 ?? ?? ?? ?? 33 D2 48 8D 58 ?? 48 8B CB";
        private string UIDraw_SetPresetBlendState_SIG = "48 83 EC 58 83 FA 0C";
        private string USprAsset_FUN_141323540_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 0F 57 C9 8B 87 ?? ?? ?? ??";
        private string UPlgAsset_FUN_14131f0d0_SIG = "48 8B C4 48 89 58 ?? 4C 89 40 ?? 48 89 50 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC 00 01 00 00";
        private string UIDraw_SetBlendState_SIG = "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC 20 48 8D 99 ?? ?? ?? ?? 4C 8B F9 48 8B CB 41 8B E9";
        private string DrawComponentMask_FUN_140cb27f0_SIG = "E8 ?? ?? ?? ?? 48 63 87 ?? ?? ?? ?? 45 0F 28 D0";
        private string DrawComponentMask_FUN_14bffbdd0_SIG = "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 50 31 F6";
        private string DrawComponentMask_FUN_140cc8760_SIG = "E8 ?? ?? ?? ?? C7 44 24 ?? 23 00 00 00 45 33 E4";
        private string SpriteMaskType_ActiveDrawTypeId_SIG = "89 0D ?? ?? ?? ?? 41 8B CF"; // 0x141118a1f
        private string DrawSingleLineText_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? F3 44 0F 58 0D ?? ?? ?? ??";
        private string AUIDrawBaseActor_DrawPlg_SIG = "E8 ?? ?? ?? ?? 33 D2 48 8D 4E ?? E8 ?? ?? ?? ?? 0F B6 86 ?? ?? ?? ??";
        private string AUIDrawBaseActor_DrawSpr_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 48 8D 68 ?? 48 81 EC C0 00 00 00 48 8B 5D ??";
        private string AUIDrawBaseActor_SetRenderTarget_SIG = "48 89 5C 24 ?? 57 48 83 EC 20 41 8B F8 45 8B C8 45 33 C0";
        private string AUIDrawBaseActor_DrawRect_SIG = "4C 8B DC 48 81 EC C8 00 00 00 0F B6 84 24 ?? ?? ?? ??";
        private string AUIDrawBaseActor_DrawRectV4_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 41 56 41 57 48 8D 68 ?? 48 81 EC 30 01 00 00 48 8B 9D ?? ?? ?? ??";

        public UIMethods(ISharedScans scans)
        {
            scans.AddScan<IUIMethods.GetSpriteItemMaskInstance>(GetSpriteItemMaskInstance_SIG);
            scans.AddScan<IUIMethods.UIDraw_SetPresetBlendState>(UIDraw_SetPresetBlendState_SIG);
            scans.AddScan<IUIMethods.USprAsset_FUN_141323540>(USprAsset_FUN_141323540_SIG);
            scans.AddScan<IUIMethods.UPlgAsset_FUN_14131f0d0>(UPlgAsset_FUN_14131f0d0_SIG);
            scans.AddScan<IUIMethods.UIDraw_SetBlendState>(UIDraw_SetBlendState_SIG);
            scans.AddScan<IUIMethods.DrawComponentMask_FUN_140cb27f0>(DrawComponentMask_FUN_140cb27f0_SIG);
            scans.AddScan<IUIMethods.DrawComponentMask_FUN_14bffbdd0>(DrawComponentMask_FUN_14bffbdd0_SIG);
            scans.AddScan<IUIMethods.DrawComponentMask_FUN_140cc8760>(DrawComponentMask_FUN_140cc8760_SIG);
            scans.AddScan("DrawComponentMask_ActiveDrawTypeId", SpriteMaskType_ActiveDrawTypeId_SIG);
            scans.AddScan<IUIMethods.DrawSingleLineText>(DrawSingleLineText_SIG);
            scans.AddScan<IUIMethods.AUIDrawBaseActor_DrawPlg>(AUIDrawBaseActor_DrawPlg_SIG);
            scans.AddScan<IUIMethods.AUIDrawBaseActor_DrawSpr>(AUIDrawBaseActor_DrawSpr_SIG);
            scans.AddScan<IUIMethods.AUIDrawBaseActor_SetRenderTarget>(AUIDrawBaseActor_SetRenderTarget_SIG);
            scans.AddScan<IUIMethods.AUIDrawBaseActor_DrawRect>(AUIDrawBaseActor_DrawRect_SIG);
            scans.AddScan<IUIMethods.AUIDrawBaseActor_DrawRectV4>(AUIDrawBaseActor_DrawRectV4_SIG);
        }
    }
}
