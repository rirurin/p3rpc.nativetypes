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
        public unsafe bool TArray_InsertShift<TArrayType>(TArray<TArrayType>* arr, TArrayType entry, int index) where TArrayType : unmanaged;
        public unsafe bool TArray_Delete<TArrayType>(TArray<TArrayType>* arr, int index) where TArrayType : unmanaged;
        // (1.7.0) Managed array factory methods
        public unsafe TManagedValueArray<T> MakeManagedValueArray<T>(TArray<T>* arr) where T : unmanaged;
        public unsafe TManagedValueArray<T> MakeManagedValueArray<T>() where T : unmanaged;
        public unsafe TBitArray MakeBitArray(nint alloc);
        public unsafe TBitArray MakeBitArray();

        // Map modification (no hashing atm)
        public unsafe bool TMap_Insert<KeyType, ValueType>(TMap<KeyType, ValueType>* map, KeyType key, ValueType val)
            where KeyType : unmanaged, IEquatable<KeyType>
            where ValueType : unmanaged;

        public unsafe bool TMap_InsertNoInit<KeyType, ValueType>(TMap<KeyType, ValueType>* map, KeyType key, ValueType val)
            where KeyType : unmanaged, IEquatable<KeyType>, IMapHashable
            where ValueType : unmanaged;
        // (1.7.0) Managed map factory methods
        /*
        public unsafe TManagedMap<TKey, TValueMapElementAccessor<TKey, TValue>, TValue> MakeValueMap<TKey, TValue>(nint? alloc = null)
            where TKey : unmanaged, IEquatable<TKey>, IMapHashable
            where TValue : unmanaged;
        public unsafe TManagedMap<TKey, TValueMapElementAccessor<TKey, TValue>, TValue> MakeValueMap<TKey, TValue>(TMap<TKey, TValue>* alloc)
            where TKey : unmanaged, IEquatable<TKey>, IMapHashable
            where TValue : unmanaged;
        public unsafe TManagedMap<TKey, TPointerMapElementAccessor<TKey, TValue>, TValue> MakePointerMap<TKey, TValue>(nint? alloc = null)
            where TKey : unmanaged, IEquatable<TKey>, IMapHashable
            where TValue : unmanaged;
        public unsafe TManagedMap<TKey, TPointerMapElementAccessor<TKey, TValue>, TValue> MakePointerMap<TKey, TValue>(TMap<TKey, TValue>* alloc)
            where TKey : unmanaged, IEquatable<TKey>, IMapHashable
            where TValue : unmanaged;
        public unsafe TManagedMap<FName, TPointerMapElementAccessor<FName, TValue>, TValue> MakeMapFromDataTable<TValue>(UDataTable* DataTable)
            where TValue : unmanaged;
        */
        public unsafe TManagedMap<TKey, TValueMapElementAccessor<TKey, TValue>, ManagedMapValueElements<TKey, TValue>, TValue> MakeValueMap<TKey, TValue>(nint? alloc = null)
            where TKey : unmanaged, IEquatable<TKey>, IMapHashable
            where TValue : unmanaged;
        public unsafe TManagedMap<TKey, TValueMapElementAccessor<TKey, TValue>, ManagedMapValueElements<TKey, TValue>, TValue> MakeValueMap<TKey, TValue>(TMap<TKey, TValue>* alloc)
            where TKey : unmanaged, IEquatable<TKey>, IMapHashable
            where TValue : unmanaged;
        public unsafe TManagedMap<TKey, TPointerMapElementAccessor<TKey, TValue>, ManagedMapPointerElements<TKey, TValue>, TValue> MakePointerMap<TKey, TValue>(nint? alloc = null)
            where TKey : unmanaged, IEquatable<TKey>, IMapHashable
            where TValue : unmanaged;
        public unsafe TManagedMap<TKey, TPointerMapElementAccessor<TKey, TValue>, ManagedMapPointerElements<TKey, TValue>, TValue> MakePointerMap<TKey, TValue>(TMap<TKey, TValue>* alloc)
            where TKey : unmanaged, IEquatable<TKey>, IMapHashable
            where TValue : unmanaged;
        public unsafe TManagedMap<FName, TPointerMapElementAccessor<FName, TValue>, ManagedMapPointerElements<FName, TValue>, TValue> MakeMapFromDataTable<TValue>(UDataTable* DataTable)
            where TValue : unmanaged;
    }
}
