using System.Runtime.InteropServices;

#pragma warning disable CS1591

namespace p3rpc.nativetypes.Interfaces;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct UArcAsset
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public TArray<byte> mBuffer_;

    public unsafe byte* GetFile(string name, out int size)
    {
        var pBuffer = &mBuffer_.allocator_instance[0];
        int fileCount = *(int*)pBuffer;
        for (int i = 0; i < fileCount; i++)
        {
            pBuffer += 4;
            string targetFile = Marshal.PtrToStringAnsi((nint)pBuffer);
            pBuffer += 0x20;
            size = *(int*)pBuffer;
            if (targetFile != null && targetFile == name)
                return pBuffer + 4;
            pBuffer += size;
        }
        size = -1;
        return null;
    }
}