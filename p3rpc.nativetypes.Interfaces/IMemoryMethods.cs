#pragma warning disable CS1591
namespace p3rpc.nativetypes.Interfaces
{
    public interface IMemoryMethods
    {
        // Memory Allocation
        public unsafe void FMemory_Free(nint ptr);
        public unsafe void FMemory_Free<TType>(TType* ptr) where TType : unmanaged;
        public unsafe nint FMemory_Realloc(nint ptr, nint size, uint alignment);
        public unsafe nint FMemory_GetAllocSize(nint ptr);
        public unsafe nint FMemory_Malloc(nint size, uint alignment);
        public unsafe TType* FMemory_Malloc<TType>(uint alignment) where TType : unmanaged;
        public unsafe TType* FMemory_Malloc<TType>() where TType : unmanaged;
        public unsafe TType* FMemory_MallocMultiple<TType>(uint count, uint alignment) where TType : unmanaged;
        public unsafe TType* FMemory_MallocMultiple<TType>(uint count) where TType : unmanaged;
        public unsafe TType* FMemory_MallocZeroed<TType>() where TType : unmanaged;
        public unsafe TType* FMemory_MallocMultipleZeroed<TType>(uint count) where TType : unmanaged;

        // Array modification

        public unsafe bool TArray_Insert<TArrayType>(TArray<TArrayType>* arr, TArrayType entry) where TArrayType : unmanaged;
        public unsafe bool TArray_Insert<TArrayType>(TArray<TArrayType>* arr, TArrayType entry, int index) where TArrayType : unmanaged;
        public unsafe bool TArray_Delete<TArrayType>(TArray<TArrayType>* arr, int index) where TArrayType : unmanaged;
    }
}
