using System.Runtime.InteropServices;
namespace p3rpc.nativetypes.Interfaces;

#pragma warning disable CS1591
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct UBmdAsset //: public UObject
{
    [FieldOffset(0x28)] public TArray<byte> mBuf;
};
