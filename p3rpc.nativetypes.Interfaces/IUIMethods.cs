using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591

namespace p3rpc.nativetypes.Interfaces
{
    public interface IUIMethods
    {
        public unsafe delegate nint GetSpriteItemMaskInstance();
        public unsafe delegate void UIDraw_SetPresetBlendState(nint worldOuter, EUIOTPRESET_BLEND_TYPE idx);
        public unsafe delegate void USprAsset_FUN_141323540(SprDefStruct1* fields, nint masker, USprAsset* sprite, float a4, float a5);
        public unsafe delegate void UPlgAsset_FUN_14131f0d0(PlgDefStruct1* fields, nint masker, UPlgAsset* vector, float a4, float a5);
        public unsafe delegate void UIDraw_SetBlendState(nint masker, EUIBlendOperation opColor, EUIBlendFactor srcColor, EUIBlendFactor dstColor, EUIBlendOperation opAlpha, EUIBlendFactor srcAlpha, EUIBlendFactor dstAlpha, int a8, int queueId);
        public unsafe delegate void DrawComponentMask_FUN_140cb27f0(nint masker, float posX, float posY, float sizeX, float sizeY, FSprColor a6, int drawTypeId);
        public unsafe delegate void DrawComponentMask_FUN_14bffbdd0(nint masker, int a2, int a3);
        public unsafe delegate void DrawComponentMask_FUN_140cc8760(nint masker, nint a2, uint queueId);
        public unsafe delegate void UMsgProcWindow_Simple_DrawMessageText(UMsgProcWindow_Simple* self, nint masker, byte opacity, float posX, float posY);
        public unsafe delegate void DrawSingleLineText(float posX, float posY, float posZ, FSprColor color, float a5, nint a6, int drawTypeId, int a8, long a9, byte a10);
        public unsafe delegate void AUIDrawBaseActor_DrawPlg(BPDrawSpr* drawer, float X, float Y, float Z, FColor* color, uint plgId, float scaleX, float scaleY, float angle, UPlgAsset* plgHandle, int queueId);
        public unsafe delegate void AUIDrawBaseActor_DrawSpr(BPDrawSpr* drawer, float X, float Y, float Z, FColor* color, uint sprId, float scaleX, float scaleY, float angle, USprAsset* sprHandle, EUI_DRAW_POINT drawPoint, int queueId);
        public unsafe delegate void AUIDrawBaseActor_SetRenderTarget(BPDrawSpr* drawer, nint kernelCanvas, uint queueId); // FRenderTargetCanvas*
        public unsafe delegate void AUIDrawBaseActor_DrawRect(BPDrawSpr* drawer, float X, float Y, float Z, float width, float height, FColor* color, float sX, float sY, float angle, float antialias, EUI_DRAW_POINT drawPoint, int queueId);
        public unsafe delegate void AUIDrawBaseActor_DrawRectV4(BPDrawSpr* drawer, float X, float Y, float Z, FVector* V0, FVector* V1, FVector* V2, FVector* V3, FColor* color, float sX, float sY, float angle, float antialias, EUI_DRAW_POINT drawPoint, int queueId);
        public unsafe delegate void BPDrawSpr_TransformMatrixDel(BPDrawSpr* self, float* mtx, FVector* pos);
        public unsafe delegate void BPDrawSpr_RotateMatrixDel(BPDrawSpr* self, float* mtx, FVector* center, float angle);
    }
}
