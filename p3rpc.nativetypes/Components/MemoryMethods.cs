using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using SharedScans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.nativetypes.Components
{
    internal class MemoryMethods : IMemoryMethods
    {
        private string GMalloc_SIG = "48 8B 0D ?? ?? ?? ?? 48 85 C9 75 ?? E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 48 8B 01 48 8B D3 FF 50 ?? 48 83 C4 20";
        private unsafe nint* gMallocPtr;

        private long _baseAddress;
        private IStartupScanner _scanner;
        private ILogger _logger;
        private IReloadedHooks _hooks;

        private IFunctionPtr<FMallocInternal_Free>? _freeInternal;
        private IFunctionPtr<FMallocInternal_Malloc>? _mallocInternal;
        private IFunctionPtr<FMallocInternal_Realloc>? _reallocInternal;
        private IFunctionPtr<FMallocInternal_GetAllocSize>? _getMallocSizeInternal;

        public unsafe MemoryMethods(IStartupScanner scans, long baseAddress, ILogger logger, IReloadedHooks hooks, string modName)
        {
            _baseAddress = baseAddress;
            _scanner = scans;
            _logger = logger;
            _hooks = hooks;

            _scanner.AddMainModuleScan(GMalloc_SIG, addr =>
            {
                if (!addr.Found)
                {
                    _logger.WriteLine($"[{modName}] Couldn't find location for gMalloc, stuff will break :(");
                    return;
                }
                var realAddr = _baseAddress + addr.Offset;
                gMallocPtr = (nint*)GetGlobalAddress((nint)(realAddr + 3));
                _logger.WriteLine($"[{modName}] Found gMalloc at {(nint)gMallocPtr:X}");
            });
        }

        public static unsafe nuint GetGlobalAddress(nint ptrAddress) => (nuint)((*(int*)ptrAddress) + ptrAddress + 4);

        // TODO: GCreateMalloc (although that probably shouldn't be needed,
        // are you really gonna be the first caller of the memory allocator?)
        public unsafe void FMemory_Free<TType>(TType* ptr) where TType : unmanaged => FMemory_Free((nint)ptr);
        public unsafe void FMemory_Free(nint ptr)
        {
            if (_freeInternal == null)
                _freeInternal = _hooks.CreateFunctionPtr<FMallocInternal_Free>(**(ulong**)gMallocPtr + 0x30);
            _freeInternal.GetDelegate()(*gMallocPtr, ptr);
        }
        public unsafe delegate void FMallocInternal_Free(nint gMalloc, nint ptr);
        public unsafe TType* FMemory_Malloc<TType>(uint alignment) where TType : unmanaged => (TType*)FMemory_Malloc(sizeof(TType), alignment);
        public unsafe TType* FMemory_Malloc<TType>() where TType : unmanaged => (TType*)FMemory_Malloc(sizeof(TType), (uint)sizeof(nint));
        public unsafe TType* FMemory_MallocMultiple<TType>(uint count, uint alignment) where TType : unmanaged => (TType*)FMemory_Malloc(sizeof(TType) * (nint)count, alignment);
        public unsafe TType* FMemory_MallocMultiple<TType>(uint count) where TType : unmanaged => (TType*)FMemory_Malloc(sizeof(TType) * (nint)count, (uint)sizeof(nint));
        public unsafe nint FMemory_Malloc(nint size, uint alignment)
        {
            if (_mallocInternal == null)
                _mallocInternal = _hooks.CreateFunctionPtr<FMallocInternal_Malloc>(**(ulong**)gMallocPtr + 0x10);
            return _mallocInternal.GetDelegate()(*gMallocPtr, size, alignment);
        }
        public unsafe delegate nint FMallocInternal_Malloc(nint gMalloc, nint size, uint alignment);
        public unsafe nint FMemory_Realloc(nint ptr, nint size, uint alignment)
        {
            if (_reallocInternal == null)
                _reallocInternal = _hooks.CreateFunctionPtr<FMallocInternal_Realloc>(**(ulong**)gMallocPtr + 0x20);
            return _reallocInternal.GetDelegate()(*gMallocPtr, ptr, size, alignment);
        }
        public unsafe delegate nint FMallocInternal_Realloc(nint gMalloc, nint ptr, nint size, uint alignment);

        public unsafe nint FMemory_GetAllocSize(nint ptr)
        {
            if (_getMallocSizeInternal == null)
                _getMallocSizeInternal = _hooks.CreateFunctionPtr<FMallocInternal_GetAllocSize>(**(ulong**)gMallocPtr + 0x40);
            nint retSize = 0;
            nint finalSize = 0;
            var result = _getMallocSizeInternal.GetDelegate()(*gMallocPtr, ptr, ref retSize);
            if (result != 0) finalSize = retSize;
            return finalSize;
        }
        public unsafe delegate char FMallocInternal_GetAllocSize(nint gMalloc, nint ptr, ref nint size);

        public unsafe TType* FMemory_MallocZeroed<TType>() where TType : unmanaged
        {
            var alloc = FMemory_Malloc<TType>();
            NativeMemory.Clear(alloc, (nuint)sizeof(TType));
            return alloc;
        }
        public unsafe TType* FMemory_MallocMultipleZeroed<TType>(uint count) where TType : unmanaged
        {
            var alloc = FMemory_MallocMultiple<TType>(count);
            NativeMemory.Clear(alloc, (nuint)(sizeof(TType) * count));
            return alloc;
        }

        // Array modification

        public unsafe void TArray_Resize<TArrayType>(TArray<TArrayType>* arr) where TArrayType : unmanaged
        {
            // Resize allocation
            uint newEntrySize = (arr->allocator_instance != null) ? (uint)arr->arr_max * 2 : 4;
            var newAlloc = FMemory_MallocMultiple<TArrayType>(newEntrySize);
            if (arr->allocator_instance != null)
            {
                NativeMemory.Copy(arr->allocator_instance, newAlloc, (nuint)(arr->arr_max * sizeof(TArrayType)));
                FMemory_Free(arr->allocator_instance);
            }
            arr->allocator_instance = newAlloc;
            arr->arr_max = (int)newEntrySize;
        }

        public unsafe bool TArray_Insert<TArrayType>(TArray<TArrayType>* arr, TArrayType entry) where TArrayType : unmanaged
        {
            if (arr == null)
                return false;

            if (arr->arr_num == arr->arr_max)
            {
                // Resize allocation
                uint newEntrySize = (arr->allocator_instance != null) ? (uint)arr->arr_max * 2 : 4;
                var newAlloc = FMemory_MallocMultiple<TArrayType>(newEntrySize);
                if (arr->allocator_instance != null)
                {
                    NativeMemory.Copy(arr->allocator_instance, newAlloc, (nuint)(arr->arr_max * sizeof(TArrayType)));
                    FMemory_Free(arr->allocator_instance);
                }
                arr->allocator_instance = newAlloc;
                arr->arr_max = (int)newEntrySize;
            }
            arr->allocator_instance[arr->arr_num] = entry;
            arr->arr_num++;
            return true;
        }

        public unsafe bool TArray_Insert<TArrayType>(TArray<TArrayType>* arr, TArrayType entry, int index) where TArrayType : unmanaged
        {
            if (arr == null || index > arr->arr_num || index < 0)
                return false;
            if (index == arr->arr_num)
                return TArray_Insert(arr, entry);
            arr->allocator_instance[index] = entry;
            return true;
        }

        public unsafe bool TArray_InsertShift<TArrayType>(TArray<TArrayType>* arr, TArrayType entry, int index) where TArrayType : unmanaged
        {
            if (arr == null || index > arr->arr_num || index < 0)
                return false;
            if (index == arr->arr_num)
                return TArray_Insert(arr, entry);
            // Shift elements down by one, then insert entry at index
            if (arr->arr_num + 1 > arr->arr_num)
                TArray_Resize(arr);
            for (int i = arr->arr_num - 1; i >= index; i--)
                arr->allocator_instance[i + 1] = arr->allocator_instance[i];
            arr->allocator_instance[index] = entry;
            arr->arr_num++;
            return true;
        }

        public unsafe bool TArray_Delete<TArrayType>(TArray<TArrayType>* arr, int index) where TArrayType : unmanaged
        {
            if (arr == null || index >= arr->arr_num || index < 0)
                return false;
            for (int i = index; i < arr->arr_num - 1; i++)
                arr->allocator_instance[i] = arr->allocator_instance[i + 1];
            arr->arr_num--;
            return true;
        }
        // (1.7.0) Managed array factory methods
        public unsafe TManagedValueArray<T> MakeManagedValueArray<T>(TArray<T>* arr) where T : unmanaged
            => new TManagedValueArray<T>(this, arr);
        public unsafe TManagedValueArray<T> MakeManagedValueArray<T>() where T : unmanaged
            => new TManagedValueArray<T>(this);
        /*
        public unsafe TManagedPointerArray<T> MakeManagedPointerArray<T>(TArray<T>* arr) where T : unmanaged
            => new TManagedPointerArray<T>(this, arr);
        public unsafe TManagedPointerArray<T> MakeManagedPointerArray<T>() where T : unmanaged
            => new TManagedPointerArray<T>(this);
        */
        public unsafe TBitArray MakeBitArray(nint alloc) => new TBitArray(this, alloc);
        public unsafe TBitArray MakeBitArray() => new TBitArray(this);

        // Map modification (very rough)

        public unsafe bool TMap_Insert<KeyType, ValueType>(TMap<KeyType, ValueType>* map, KeyType key, ValueType val)
            where KeyType : unmanaged, IEquatable<KeyType>
            where ValueType : unmanaged
        {
            if (map == null)
                return false;
            if (map->mapNum == map->mapMax)
            {
                // Resize allocation
                uint newEntrySize = (map->elements != null) ? (uint)map->mapNum * 2 : 4;
                var newAlloc = FMemory_MallocMultiple<TMapElement<KeyType, ValueType>>(newEntrySize);
                if (map->elements != null)
                {
                    NativeMemory.Copy(map->elements, newAlloc, (nuint)(map->mapMax * sizeof(TMapElement<KeyType, ValueType>)));
                    FMemory_Free(map->elements);
                }
                map->elements = newAlloc;
                map->mapMax = (int)newEntrySize;
            }
            var newEntry = &map->elements[map->mapNum];
            newEntry->Key = key;
            newEntry->Value = val;
            newEntry->HashIndex = uint.MaxValue;
            newEntry->HashNextId = uint.MaxValue;
            // based on state of other sprite maps
            *(int*)((nint)map + 0x10) = 1;
            *(int*)((nint)map + 0x28) = 1;
            *(int*)((nint)map + 0x2c) = 0x80;
            *(int*)((nint)map + 0x30) = -1;
            *(int*)((nint)map + 0x48) = 1; // hash size
            map->mapNum++;
            return false;
        }

        public unsafe bool TMap_InsertNoInit<KeyType, ValueType>(TMap<KeyType, ValueType>* map, KeyType key, ValueType val)
            where KeyType : unmanaged, IEquatable<KeyType>, IMapHashable
            where ValueType : unmanaged
        {
            if (map == null)
                return false;
            // Get respective hash index
            var hashes = (int**)((nint)map + 0x40);
            var hashSize = (int*)((nint)map + 0x48);
            var hashIndex = (uint)(key.GetTypeHash() & (*hashSize - 1));
            var currHash = (*hashes)[hashIndex];
            // Add a new hash if required
            if (currHash == -1)
                (*hashes)[hashIndex] = map->mapNum;
            // Add a new element in the array
            var newEntry = &map->elements[map->mapNum];
            NativeMemory.Clear(newEntry, (nuint)sizeof(TMapElement<KeyType, ValueType>));
            newEntry->Key = key;
            newEntry->Value = val;
            newEntry->HashNextId = uint.MaxValue;
            newEntry->HashIndex = hashIndex;
            // Link element to hash map
            var linkElement = &map->elements[currHash];
            while (linkElement->HashNextId != uint.MaxValue)
                linkElement = &map->elements[linkElement->HashNextId];
            linkElement->HashNextId = (uint)map->mapNum;
            // Add to bit allocator
            var inlineAlloc = (byte*)((nint)map + 0x10);
            var alloc = *(byte**)((nint)map + 0x20);
            var allocCount = (int*)((nint)map + 0x28);
            if (alloc == null) // we haven't filled the inline allocator yet...
            {
                inlineAlloc[(*allocCount / 8) + 1] |= (byte)(1 << (*allocCount % 8));
            } else
            {
                alloc[(*allocCount / 8) + 1] |= (byte)(1 << (*allocCount % 8));
            }
            *allocCount += 1;
            map->mapNum++;
            if (map->mapNum == map->mapMax)
            {
                // Resize allocation
                uint newEntrySize = (map->elements != null) ? (uint)map->mapNum * 2 : 4;
                var newAlloc = FMemory_MallocMultiple<TMapElement<KeyType, ValueType>>(newEntrySize);
                if (map->elements != null)
                {
                    NativeMemory.Copy(map->elements, newAlloc, (nuint)(map->mapMax * sizeof(TMapElement<KeyType, ValueType>)));
                    FMemory_Free(map->elements);
                }
                map->elements = newAlloc;
                map->mapMax = (int)newEntrySize;
            }
            return true;
        }
    }
}
