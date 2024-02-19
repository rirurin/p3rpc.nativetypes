using System.Runtime.InteropServices;
namespace p3rpc.nativetypes.Interfaces;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct UBfAsset //: public UObject
{
    [FieldOffset(0x28)] TArray<byte> mBuf;
};
