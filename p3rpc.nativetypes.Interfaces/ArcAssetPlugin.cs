using System.Runtime.InteropServices;

#pragma warning disable CS1591

namespace p3rpc.nativetypes.Interfaces;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct UArcAsset
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public TArray<byte> mBuffer_;
}