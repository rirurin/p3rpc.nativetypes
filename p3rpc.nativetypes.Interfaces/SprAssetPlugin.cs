using System.Runtime.InteropServices;
namespace p3rpc.nativetypes.Interfaces;
#pragma warning disable CS1591

// GENERATED FROM UE4SS CXX HEADER DUMP
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct FSprData
{
    [FieldOffset(0x0000)] float Width;
    [FieldOffset(0x0004)] float Height;
    [FieldOffset(0x0008)] float U0;
    [FieldOffset(0x000C)] float V0;
    [FieldOffset(0x0010)] float U1;
    [FieldOffset(0x0014)] float v1;
    [FieldOffset(0x0018)] nint Texture;
    [FieldOffset(0x0020)] uint RGBA0;
    [FieldOffset(0x0024)] uint RGBA1;
    [FieldOffset(0x0028)] uint RGBA2;
    [FieldOffset(0x002c)] uint RGBA3;
    [FieldOffset(0x0030)] short StretchLen0;
    [FieldOffset(0x0032)] short StretchLen1;
    [FieldOffset(0x0034)] short StretchLen2;
    [FieldOffset(0x0036)] short StretchLen3;
    [FieldOffset(0x0038)] uint ScalingSize0;
    [FieldOffset(0x003c)] uint ScalingSize1;

    public unsafe FSprData(float width, float height, FVector2D topLeft, FVector2D bottomRight, UTexture2D* texture, uint color, short stretch, uint scale)
    {
        Width = width;
        Height = height;
        U0 = topLeft.X;
        V0 = topLeft.Y;
        U1 = bottomRight.X;
        v1 = bottomRight.Y;
        Texture = (nint)texture;
        for (int i = 0; i < 4; i++)
        {
            SetColor(i, color);
            SetStretchLength(i, stretch);
        }
        for (int i = 0; i < 2; i++)
            SetScalingSize(i, scale);
    }

    public unsafe void SetColor(int index, uint color)
    {
        fixed (FSprData* self = &this)
        {
            *(uint*)((nint)self + 0x20 + index * sizeof(uint)) = color;
        }
    }
    public unsafe void SetStretchLength(int index, short stretchLen)
    {
        fixed (FSprData* self = &this)
        {
            *(short*)((nint)self + 0x30 + index * sizeof(short)) = stretchLen;
        }
    }
    public unsafe void SetScalingSize(int index, uint color)
    {
        fixed (FSprData* self = &this)
        {
            *(uint*)((nint)self + 0x38 + index * sizeof(uint)) = color;
        }
    }

}; // Size: 0x40

public struct FSprDataArray
{
    public TArray<FSprData> SprDatas;
}; // Size: 0x10

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe struct USprAsset //: public UObject
{
    [FieldOffset(0x0028)] public TArray<nint> mTexArray; // UTexture*
    [FieldOffset(0x0038)] public TMap<int, FSprDataArray> SprDatas;
};
