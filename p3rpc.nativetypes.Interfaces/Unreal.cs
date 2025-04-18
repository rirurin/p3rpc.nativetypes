﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace p3rpc.nativetypes.Interfaces;

#pragma warning disable CS1591
#pragma warning disable CS0169

// Copied from Hi-Fi RUSH Research project

// ====================
// IO STORE STRUCTS
// ====================

[StructLayout(LayoutKind.Sequential, Size = 0xc)]
public unsafe struct FIoChunkId : IMapHashable
{
    public byte GetByte(int idx) { fixed (FIoChunkId* self = &this) return *(byte*)((IntPtr)self + idx); }
    public string GetId()
    {
        string key_out = "0x";
        for (int i = 0; i < 0xc; i++) key_out += $"{GetByte(i):X2}";
        return key_out;
    }

    public uint GetTypeHash()
    {
        uint Hash = 0x1505;
        for (int i = 0; i < 0xc; i++)
            Hash = Hash * 33 + GetByte(i);
        return Hash;
    }
}

// ====================
// OBJECT DUMPER STRUCTS
// ====================

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct TArray<T> where T : unmanaged
{
    public T* allocator_instance;
    public int arr_num;
    public int arr_max;

    public T* GetRef(int index) // for arrays of type TArray<FValueType>
    {
        if (index < 0 || index >= arr_num) return null;
        return &allocator_instance[index];
    }

    public V* Get<V>(int index) where V : unmanaged // for arrays of type TArray<FValueType*>
    {
        if (index < 0 || index >= arr_num) return null;
        return *(V**)&allocator_instance[index];
    }
}

public abstract class TManagedBaseArray<T> : IList<T>, IDisposable where T : unmanaged
{
    protected IMemoryMethods MemoryMethods;
    protected unsafe TArray<T>* Self;
    protected bool bOwnsAllocation;
    protected bool bIsDisposed;
    public unsafe TManagedBaseArray(IMemoryMethods _MemoryMethods, TArray<T>* _Self)
    {
        MemoryMethods = _MemoryMethods;
        Self = _Self;
        bOwnsAllocation = false;
    }
    public unsafe TManagedBaseArray(IMemoryMethods _MemoryMethods)
    {
        MemoryMethods = _MemoryMethods;
        Self = MemoryMethods.FMemory_Malloc<TArray<T>>();
        NativeMemory.Fill(Self, (nuint)sizeof(TArray<T>), 0);
        bOwnsAllocation = true;
    }
    // Implement IList<T>
    public abstract T this[int index] { get; set; } 
    public unsafe int Count => Self->arr_num;
    public bool IsReadOnly => false;
    public abstract void Add(T item);
    public abstract void Clear();
    public abstract bool Contains(T item);
    public abstract void CopyTo(T[] array, int arrayIndex);
    public abstract IEnumerator<T> GetEnumerator();
    public abstract int IndexOf(T item);
    public abstract void Insert(int index, T item);
    public abstract bool Remove(T item);
    public abstract void RemoveAt(int index);
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    // Implement IDisposable
    ~TManagedBaseArray() => Dispose(false);
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!bIsDisposed)
        {
            //if (disposing) { } // For managed components
            if (bOwnsAllocation)
                unsafe { MemoryMethods.FMemory_Free(Self); }
            bIsDisposed = true;
        }
    }
}

public abstract class TManagedBaseArrayEnumerator<T> : IEnumerator<T>, IEnumerator where T : unmanaged
{
    protected unsafe TArray<T>* Self;
    public abstract object Current { get; }
    T IEnumerator<T>.Current => (T)Current;
    public void Dispose() {}
    public abstract bool MoveNext();
    public abstract void Reset();
}

/// <summary>
/// A managed representation of an Unreal Engine TArray, where the array elements are stored by value (e.g TArray with type constraint int)
/// </summary>
/// <typeparam name="T">Type of the Unreal type to be stored by value in this array</typeparam>
public class TManagedValueArray<T> : TManagedBaseArray<T>, IEnumerable where T : unmanaged
{
    public unsafe TManagedValueArray(IMemoryMethods _MemoryMethods, TArray<T>* _Self) : base(_MemoryMethods, _Self) { }
    public unsafe TManagedValueArray(IMemoryMethods _MemoryMethods) : base(_MemoryMethods) { }
    public unsafe override T this[int index] 
    {
        get => *Self->GetRef(index);
        set => MemoryMethods.TArray_InsertShift(Self, value, index);
    }

    public unsafe override void Add(T item) => MemoryMethods.TArray_Insert(Self, item);

    public unsafe override void Clear()
    {
        NativeMemory.Clear(Self->allocator_instance, (nuint)(sizeof(T) * Self->arr_num));
        Self->arr_num = 0;
    }

    public override bool Contains(T item)
    {
        foreach (var el in this)
            if (el.Equals(item)) return true;
        return false;
    }

    public unsafe override void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex > Self->arr_num || arrayIndex < 0) return; // lol, lmao even
        for (int i = 0; i < Self->arr_num - arrayIndex; i++)
            array[i] = Self->allocator_instance[i + arrayIndex];
    }

    public unsafe override IEnumerator<T> GetEnumerator() => new TManagedValueArrayEnumerator<T>(Self);

    public override int IndexOf(T item)
    {
        int index = 0;
        foreach (var el in this)
        {
            if (el.Equals(item)) return index;
            index++;
        }
        return -1;
    }
    public unsafe override void Insert(int index, T item) => MemoryMethods.TArray_InsertShift(Self, item, index);
    public unsafe override bool Remove(T item)
    {
        int ItemIndex = IndexOf(item);
        if (ItemIndex != -1)
        {
            RemoveAt(ItemIndex);
            return true;
        }
        return false;
    }

    public unsafe override void RemoveAt(int index) => MemoryMethods.TArray_Delete(Self, index);
    unsafe IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class TManagedValueArrayEnumerator<T> : TManagedBaseArrayEnumerator<T>, IEnumerator<T> where T : unmanaged
{
    protected unsafe TArray<T>* Self;
    private int position = -1;
    public unsafe override object Current 
    {
        get
        {
            if (position < 0 || position >= Self->arr_num)
                throw new InvalidOperationException();
            return *Self->GetRef(position);
        }
    }
    public unsafe TManagedValueArrayEnumerator(TArray<T>* _Self) => Self = _Self;
    public unsafe override bool MoveNext() => ++position < Self->arr_num;
    T IEnumerator<T>.Current => (T)Current;
    public override void Reset() => position = -1;
}

/// <summary>
/// A managed representation of an Unreal Engine TArray, where the array elements are stored by reference (e.g TArray with type constraint int* )
/// This assumes that all elements inside the pointer array are distinct objects allocated by the Unreal allocator
/// </summary>
/// <typeparam name="T">Type of the Unreal type to be stored by value in this array</typeparam>
/*
public class TManagedPointerArray<T> : TManagedBaseArray<T>, IEnumerable where T : unmanaged
{
    public unsafe TManagedPointerArray(IMemoryMethods _MemoryMethods, TArray<T>* _Self) : base(_MemoryMethods, _Self) { }
    public unsafe TManagedPointerArray(IMemoryMethods _MemoryMethods) : base(_MemoryMethods) { }
    public unsafe override T this[int index] 
    { 
        get => *Self->Get<T>(index);
        set => MemoryMethods.TArray_InsertShift((TArray<nint>*)Self, (nint)(&value), index);
    }

    public override void Add(T item)
    {
        throw new NotImplementedException();
    }

    public override void Clear()
    {
        throw new NotImplementedException();
    }

    public override bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public override void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public unsafe override IEnumerator<T> GetEnumerator() => new TManagedPointerArrayEnumerator<T>(Self);

    public override int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public override void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public override bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public override void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class TManagedPointerArrayEnumerator<T> : TManagedBaseArrayEnumerator<T>, IEnumerator<T> where T : unmanaged
{
    protected unsafe TArray<T>* Self;
    private int position = -1;
    public unsafe override object Current 
    {
        get
        {
            if (position < 0 || position >= Self->arr_num)
                throw new InvalidOperationException();
            return *Self->Get<T>(position);
        }
    }
    public unsafe TManagedPointerArrayEnumerator(TArray<T>* _Self) => Self = _Self;
    public unsafe override bool MoveNext() => ++position < Self->arr_num;
    T IEnumerator<T>.Current => (T)Current;
    public override void Reset() => position = -1;
}
*/

/// <summary>
/// An array for storing bitflags.
/// </summary>
public class TBitArray : IList<bool>, IDisposable
{
    private IMemoryMethods MemoryMethods;
    public unsafe byte* InlineBitArray { get; private set; } // Start with InlineAllocatorSize bytes of inlined flags, then a TArray with remaining flags
    private bool bOwnsAllocation;
    private bool bIsDisposed = false;
    private int InlineAllocatorSize;
    private static int BITS_PER_BYTE = 0x8;
    private const int DEFAULT_ALLOCATOR_SIZE = 0x10;
    private int GetInlineBitCount() => InlineAllocatorSize * BITS_PER_BYTE;
    private unsafe byte* GetAllocation() => *(byte**)(InlineBitArray + InlineAllocatorSize);
    private unsafe void SetAllocation(byte* alloc) => *(byte**)(InlineBitArray + InlineAllocatorSize) = alloc;
    private unsafe int GetArrayCount() => *(int*)(InlineBitArray + InlineAllocatorSize + sizeof(nint));
    private unsafe void SetArrayCount(int count) => *(int*)(InlineBitArray + InlineAllocatorSize + sizeof(nint)) = count;
    private unsafe int GetArrayMax() => *(int*)(InlineBitArray + InlineAllocatorSize + sizeof(nint) + sizeof(int));
    private unsafe void SetArrayMax(int count) => *(int*)(InlineBitArray + InlineAllocatorSize + sizeof(nint) + sizeof(int)) = count;
    public unsafe TBitArray(IMemoryMethods _MemoryMethods, nint? _InlineBitArray = null, int _InlineAllocatorSize = DEFAULT_ALLOCATOR_SIZE)
    {
        MemoryMethods = _MemoryMethods;
        InlineAllocatorSize = _InlineAllocatorSize;
        if (_InlineBitArray == null)
        {
            InlineBitArray = (byte*)MemoryMethods.FMemory_Malloc(GetStructSize(), 8);
            Initialize();
            bOwnsAllocation = true;
        } else
        {
            InlineBitArray = (byte*)_InlineBitArray;
            bOwnsAllocation = false;
        }
    }

    public unsafe void Initialize()
    {
        NativeMemory.Clear(InlineBitArray, (nuint)GetStructSize());
        SetArrayCount(0);
        SetArrayMax(GetInlineBitCount());
    }

    // Impl IList<byte>
    public unsafe bool this[int index] 
    { 
        get
        {
            // Get bit from inline allocation
            if (index < GetInlineBitCount())
                return (byte)(InlineBitArray[index / 8] & 1 << (index << 8)) == 1 ? true : false;
            // Get bit from TArray
            if (GetAllocation() == null) return false;
            return (GetAllocation()[(index - GetInlineBitCount()) / 8] & 1 << (index & 8)) == 1 ? true : false;
        }
        set
        {
            // Add to inline allocation
            if (index < InlineAllocatorSize * BITS_PER_BYTE)
            {
                if (value) InlineBitArray[index / 8] |= (byte)(1 << (index % 8));
                else InlineBitArray[index / 8] &= (byte)(0x7f ^ 1 << (index % 8));
                return;
            }
            // Add to TArray
            if (GetAllocation() == null)
            {
                SetAllocation(MemoryMethods.FMemory_MallocMultiple<byte>(DEFAULT_ALLOCATOR_SIZE));
                NativeMemory.Clear(GetAllocation(), DEFAULT_ALLOCATOR_SIZE);
                SetArrayMax(GetInlineBitCount() + (DEFAULT_ALLOCATOR_SIZE * BITS_PER_BYTE));
            } else if (index == GetArrayMax())
            {
                var oldAllocSize = (uint)(GetArrayMax() - GetInlineBitCount());
                var newAlloc = MemoryMethods.FMemory_MallocMultiple<byte>(oldAllocSize * 2);
                NativeMemory.Clear(newAlloc + oldAllocSize, oldAllocSize);
                NativeMemory.Copy(GetAllocation(), newAlloc, oldAllocSize);
                MemoryMethods.FMemory_Free((nint)GetAllocation());
                SetAllocation(newAlloc);
                SetArrayMax((GetInlineBitCount()) + (int)(oldAllocSize * 2));
            }
            if (value) GetAllocation()[(index - GetInlineBitCount()) / 8] |= (byte)(1 << (index % 8));
            else GetAllocation()[(index - GetInlineBitCount()) / 8] &= (byte)(0x7f ^ 1 << (index % 8));
        }
    }

    public int Count => GetArrayCount();
    public bool IsReadOnly => false;

    public void Add(bool item)
    {
        this[GetArrayCount()] = item;
        SetArrayCount(GetArrayCount() + 1);
    }

    public unsafe void Clear()
    {
        NativeMemory.Clear(InlineBitArray, (nuint)(InlineAllocatorSize * BITS_PER_BYTE));
        if (GetAllocation() != null)
            NativeMemory.Clear(GetAllocation(), (nuint)(GetArrayMax() - InlineAllocatorSize * BITS_PER_BYTE));
        SetArrayCount(0);
    }

    public bool Contains(bool item)
    {
        foreach (var b in this)
            if (b == item) return true;
        return false;
    }

    public void CopyTo(bool[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<bool> GetEnumerator() => new TBitArrayEnumerator(this);

    public int IndexOf(bool item)
    {
        int index = 0;
        foreach (var b in this)
        {
            if (b == item) return index;
            index++;
        }
        return -1;
    }

    public void Insert(int index, bool item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(bool item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    // Impl IDisposable
    ~TBitArray() => Dispose(false);
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!bIsDisposed)
        {
            //if (disposing) { } // For managed components
            if (bOwnsAllocation)
            {
                unsafe 
                { 
                    if (GetAllocation() != null) MemoryMethods.FMemory_Free(GetAllocation());
                    MemoryMethods.FMemory_Free(InlineBitArray); 
                }
            }
            bIsDisposed = true;
        }
    }

    public void Leak() => bOwnsAllocation = false;
    public unsafe int GetStructSize() => InlineAllocatorSize + sizeof(nint) + sizeof(int) * 2;
    public unsafe static int GetDefaultStructSize() => DEFAULT_ALLOCATOR_SIZE + sizeof(nint) + sizeof(int) * 2;
}

public class TBitArrayEnumerator : IEnumerator<bool>
{
    private TBitArray Owner;
    private int Index = -1;
    public TBitArrayEnumerator(TBitArray _Owner) { Owner = _Owner; }
    public bool Current => Owner[Index];
    object IEnumerator.Current => Current;
    public void Dispose() { }
    public bool MoveNext() => ++Index < Owner.Count;
    public void Reset() => Index = -1;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TMapElement<KeyType, ValueType> 
    where KeyType : unmanaged, IEquatable<KeyType>
    where ValueType : unmanaged
{
    public KeyType Key;
    public ValueType Value;
    public uint HashNextId;
    public uint HashIndex;
}
//[StructLayout(LayoutKind.Explicit, Size = 0x50)] // inherits from TSortableMapBase
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TMap<KeyType, ValueType>
    where KeyType : unmanaged, IEquatable<KeyType>
    where ValueType : unmanaged
{
    public TMapElement<KeyType, ValueType>* elements;
    public int mapNum;
    public int mapMax;
    public ValueType* TryGet(KeyType key)
    {
        if (mapNum == 0 || elements == null) return null;
        ValueType* value = null;
        for (int i = 0; i < mapNum; i++)
        {
            var currElem = &elements[i];
            if (currElem->Key.Equals(key))
            {
                value = &currElem->Value;
                break;
            }
        }
        return value;
    }
    public ValueType* GetByIndex(int idx)
    {
        if (idx < 0 || idx > mapNum) return null;
        return &elements[idx].Value;
    }
}

public interface IMapHashable
{
    public uint GetTypeHash();
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TMapElementHashable<KeyType, ValueType>
    where KeyType : unmanaged, IEquatable<KeyType>, IMapHashable
    where ValueType : unmanaged
{
    public KeyType Key;
    public ValueType Value;
    public int HashNextId;
    public int HashIndex;
}
public unsafe class TMapHashable<KeyType, ValueType>
    where KeyType : unmanaged, IEquatable<KeyType>, IMapHashable
    where ValueType : unmanaged
{
    // Each instance assumes that values are fixed at particular addresses from init onwards
    public TArray<TMapElementHashable<KeyType, ValueType>>* Elements;
    public int** Hashes;
    public uint* HashSize;
    public TMapHashable(nint ptr, nint hashArrOffset, nint hashSizeOffset) // Address of start of TMap struct (e.g &class_instance->func_map)
    {
        Elements = (TArray<TMapElementHashable<KeyType, ValueType>>*)ptr;
        Hashes = (int**)(ptr + hashArrOffset);
        HashSize = (uint*)(ptr + hashSizeOffset);
    }

    public ValueType* GetByIndex(int idx)
    {
        if (idx < 0 || idx > Elements->arr_num) return null;
        return &Elements->allocator_instance[idx].Value;
    }

    public ValueType* TryGetLinear(KeyType key)
    {
        if (Elements->arr_num == 0 || Elements->allocator_instance == null) return null;
        ValueType* value = null;
        for (int i = 0; i < Elements->arr_num; i++)
        {
            var currElem = &Elements->allocator_instance[i];
            if (currElem->Key.Equals(key))
            {
                value = &currElem->Value;
                break;
            }
        }
        return value;
    }

    public ValueType* TryGetByHash(KeyType key)
    {
        ValueType* value = null;
        // Hash alloc doesn't exist for single element maps,
        // so fallback to linear search
        if (*Hashes == null) return TryGetLinear(key);
        var elementTarget = (*Hashes)[key.GetTypeHash() & (*HashSize - 1)];
        while (elementTarget != -1)
        {
            if (Elements->allocator_instance[elementTarget].Key.Equals(key))
            {
                value = &Elements->allocator_instance[elementTarget].Value;
                break;
            }
            elementTarget = Elements->allocator_instance[elementTarget].HashNextId;
        }
        return value;
    }
}
/*
public abstract class ManagedPointerBase<T> where T : unmanaged
{
    public unsafe T* Self { get; protected set; }
    public unsafe bool IsValid() => Self != null;
    public abstract int GetStride();
}
public class ManagedPointer<T> : ManagedPointerBase<T> where T : unmanaged
{
    //public unsafe ManagedPointer(nint ptr) => Self = ptr != nint.Zero ? *(T**)ptr : null;
    public unsafe ManagedPointer(nint ptr) => Self = (T*)ptr;
    public unsafe override int GetStride() => sizeof(T*);
}

public class ManagedValue<T> : ManagedPointerBase<T> where T : unmanaged
{
    public unsafe ManagedValue(T* ptr) => Self = ptr;
    public unsafe override int GetStride() => sizeof(T);
}
*/

/// <summary>
/// Wrapper for pointers to native data which can be used as generic type parameters
/// </summary>
/// <typeparam name="T">The native pointer type to be cast to</typeparam>
public class ManagedData<T> where T : unmanaged 
{
    public unsafe T* Self { get; protected set; }
    public unsafe ManagedData(nint ptr) => Self = (T*)ptr;
    public unsafe bool IsValid() => Self != null;
}
/// <summary>
/// Defines struct layout for map elements where the values are stored by-value
/// </summary>
/// <typeparam name="TElemKey">Key type</typeparam>
/// <typeparam name="TElemValue">Data type</typeparam>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ManagedMapValueElements<TElemKey, TElemValue>
    where TElemKey : unmanaged, IEquatable<TElemKey>, IMapHashable
    where TElemValue : unmanaged
{
    public TElemKey Key;
    public TElemValue Value;
    public int HashNextId;
    public int HashIndex;
}

/// <summary>
/// Defines struct layout for map elements where the values are stored by-reference
/// </summary>
/// <typeparam name="TElemKey">Key type</typeparam>
/// <typeparam name="TElemValue">Data pointer type</typeparam>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ManagedMapPointerElements<TElemKey, TElemValue>
    where TElemKey : unmanaged, IEquatable<TElemKey>, IMapHashable
    where TElemValue : unmanaged
{
    public TElemKey Key;
    public TElemValue* Value;
    public int HashNextId;
    public int HashIndex;
}
/// <summary>
/// Managed type provide a safe(r) and more ergonomic way to access elements in a TMap or TSet
/// </summary>
/// <typeparam name="TElemKey">Type used for keys (first field in TElemLayout)</typeparam>
/// <typeparam name="TElemValue">Type used for values (second field in TElemLayout)</typeparam>
/// <typeparam name="TElemLayout">Struct layout for each entry, either a ManagedMapValueElement or ManagedMapPointerElement</typeparam>
public abstract class TMapElementAccessorBase<TElemKey, TElemValue, TElemLayout> : IEnumerable<ManagedData<TElemLayout>>
    where TElemKey : unmanaged, IEquatable<TElemKey>, IMapHashable
    where TElemValue : unmanaged
    where TElemLayout : unmanaged
{
    protected unsafe TArray<nint>* Array;
    protected int CachedIndex = -1;
    protected unsafe TElemLayout* CachedData = null;
    public unsafe TMapElementAccessorBase(TArray<nint>* _Array) => Self = _Array;
    public unsafe TArray<nint>* Self
    {
        get => Array;
        set => Array = value;
    }
    public unsafe int Size
    {
        get => Array->arr_num;
        set => Array->arr_num = value;
    }
    public unsafe int Capacity
    {
        get => Array->arr_max;
        set => Array->arr_max = value;
    }
    public abstract unsafe TElemValue* this[int Index] { get; set; }
    public abstract unsafe TElemKey GetKey(int Index);
    public abstract unsafe void SetKey(int Index, TElemKey New);
    public abstract unsafe int GetNextHashId(int Index);
    public abstract unsafe int SizeOf();
    public unsafe bool HasAllocation() => Array->allocator_instance != null;
    public unsafe nint Allocation
    {
        get => (nint)Array->allocator_instance;
        set => Array->allocator_instance = (nint*)value;
    }
    unsafe IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public unsafe IEnumerator<ManagedData<TElemLayout>> GetEnumerator() => new TMapElementEnumerator<TElemLayout>(Array);
    public abstract void SetNextHashId(int Index, int NextId);
    public abstract int GetHashIndex(int Index);
    public abstract void SetHashIndex(int Index, int HashIndex);
}

public class TMapElementEnumerator<TElemLayout> : IEnumerator<ManagedData<TElemLayout>>
    where TElemLayout : unmanaged
{
    protected int Position = -1;
    protected unsafe TArray<nint>* Array;
    public unsafe TMapElementEnumerator(TArray<nint>* _Array) => Array = _Array;
    public unsafe ManagedData<TElemLayout> Current => new ManagedData<TElemLayout>((nint)((TElemLayout*)Array->allocator_instance + Position));
    object IEnumerator.Current => Current;
    public void Dispose() { }
    public unsafe bool MoveNext() => ++Position < Array->arr_num;
    public void Reset() => Position = -1;
    public void SetPosition(int _Position) => Position = _Position;
}

/// <summary>
/// Managed type provide a safe(r) and more ergonomic way to access elements in a TMap or TSet given that the values are stored by-value
/// </summary>
/// <typeparam name="TElemKey">Type used for keys (first field in ManagedMapValueElements)</typeparam>
/// <typeparam name="TElemValue">Type used for values (second field in ManagedMapValueElements)</typeparam>
public class TValueMapElementAccessor<TElemKey, TElemValue> 
    : TMapElementAccessorBase<TElemKey, TElemValue, ManagedMapValueElements<TElemKey, TElemValue>>
    //, IEnumerable<ManagedData<ManagedMapValueElements<TElemKey, TElemValue>>>
    where TElemKey : unmanaged, IEquatable<TElemKey>, IMapHashable
    where TElemValue : unmanaged
{
    public unsafe TValueMapElementAccessor(TArray<nint>* _Array) : base(_Array) { }
    public override unsafe TElemValue* this[int Index]
    {
        get
        {
            if (CachedIndex != Index)
                CachedData = (ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance + Index;
            return &CachedData->Value;
            //& ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].Value;
        }
        set => ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].Value = *value;
    }
    public override unsafe TElemKey GetKey(int Index) => ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].Key;
    public override unsafe void SetKey(int Index, TElemKey New) => ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].Key = New;
    public override unsafe int GetNextHashId(int Index) => ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].HashNextId;
    public override unsafe int SizeOf()
    {
        var rawSizeof = sizeof(ManagedMapValueElements<TElemKey, TElemValue>);
        return rawSizeof % 8 != 0 ? rawSizeof + (8 - (rawSizeof % 8)) : rawSizeof; // alignto(8)
    }
    //public override unsafe IEnumerator GetEnumerator() => new TValueMapElementEnumerator<TElemKey, TElemValue>(Array);
    public unsafe override void SetNextHashId(int Index, int NextId) => ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].HashNextId = NextId;
    public unsafe override int GetHashIndex(int Index) => ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].HashIndex;
    public unsafe override void SetHashIndex(int Index, int HashIndex) => ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].HashIndex = HashIndex;
}
/*
public class TValueMapElementEnumerator<TElemKey, TElemValue> : IEnumerator<ManagedMapValueElements<TElemKey, TElemValue>>
    where TElemKey : unmanaged, IEquatable<TElemKey>, IMapHashable
    where TElemValue : unmanaged
{
    private int Position = -1;
    protected unsafe TArray<nint>* Array;
    public unsafe TValueMapElementEnumerator(TArray<nint>* _Array) => Array = _Array;
    public unsafe ManagedMapValueElements<TElemKey, TElemValue> Current => ((ManagedMapValueElements<TElemKey, TElemValue>*)Array->allocator_instance)[Position];
    object IEnumerator.Current => Current;
    public void Dispose() {}
    public unsafe bool MoveNext() => ++Position < Array->arr_num;
    public void Reset() => Position = -1;
}
*/
/// <summary>
/// Managed type provide a safe(r) and more ergonomic way to access elements in a TMap or TSet given that the values are stored by-reference
/// </summary>
/// <typeparam name="TElemKey">Type used for keys (first field in ManagedMapPointerElements)</typeparam>
/// <typeparam name="TElemValue">Type used for values (second field in ManagedMapPointerElements)</typeparam>
public class TPointerMapElementAccessor<TElemKey, TElemValue> 
    : TMapElementAccessorBase<TElemKey, TElemValue, ManagedMapPointerElements<TElemKey, TElemValue>>
    //, IEnumerable<ManagedData<ManagedMapPointerElements<TElemKey, TElemValue>>>
    where TElemKey : unmanaged, IEquatable<TElemKey>, IMapHashable
    where TElemValue : unmanaged
{
    public unsafe TPointerMapElementAccessor(TArray<nint>* _Array) : base(_Array) { }
    public override unsafe TElemValue* this[int Index]
    {
        get
        {
            if (CachedIndex != Index)
                CachedData = (ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance + Index;
            return CachedData->Value;
        }
        //get => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].Value;
        set => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].Value = value;
    }
    public override unsafe TElemKey GetKey(int Index) => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].Key;
    public override unsafe void SetKey(int Index, TElemKey New) => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].Key = New;
    public override unsafe int GetNextHashId(int Index) => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].HashNextId;
    public override unsafe int SizeOf() => sizeof(ManagedMapPointerElements<TElemKey, TElemValue>);
    //public override unsafe IEnumerator GetEnumerator() => new TPointerMapElementEnumerator<TElemKey, TElemValue>(Array);
    public unsafe override void SetNextHashId(int Index, int NextId) => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].HashNextId = NextId;
    public unsafe override int GetHashIndex(int Index) => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].HashIndex;
    public unsafe override void SetHashIndex(int Index, int HashIndex) => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Index].HashIndex = HashIndex;
}
/*
public class TPointerMapElementEnumerator<TElemKey, TElemValue> : IEnumerator<ManagedMapPointerElements<TElemKey, TElemValue>>
    where TElemKey : unmanaged, IEquatable<TElemKey>, IMapHashable
    where TElemValue : unmanaged
{
    private int Position = -1;
    protected unsafe TArray<nint>* Array;
    public unsafe TPointerMapElementEnumerator(TArray<nint>* _Array) => Array = _Array;
    public unsafe ManagedMapPointerElements<TElemKey, TElemValue> Current => ((ManagedMapPointerElements<TElemKey, TElemValue>*)Array->allocator_instance)[Position];
    object IEnumerator.Current => Current;
    public void Dispose() { }
    public unsafe bool MoveNext() => ++Position < Array->arr_num;
    public void Reset() => Position = -1;
}
*/

public unsafe struct TMapFreeListIndex
{
    public int FirstFreeIndex;
    public int NumFreeIndices;
    public int* FreeIndexList;
}

public class TManagedMap<TKey, TElem, TElemIter, TValue> : IDictionary<TKey, ManagedData<TValue>>, IDisposable
    where TKey : unmanaged, IEquatable<TKey>, IMapHashable
    where TElem : TMapElementAccessorBase<TKey, TValue, TElemIter>
    where TElemIter : unmanaged
    where TValue : unmanaged
{
    private IMemoryMethods MemoryMethods;
    private bool bOwnsAllocation;
    private bool bIsDisposed = false;
    private Action<string>? DebugCb;
    private TMapElementAccessorBase<TKey, TValue, TElemIter> Elements; // 0x0
    public unsafe nint Allocation { get => (nint)Elements.Self; }
    private unsafe nint GetBitAllocatorPtr() => (nint)Elements.Self + sizeof(TArray<nint>);
    private TBitArray BitAllocator; // 0x10
    private unsafe TMapFreeListIndex* GetFreeList() => (TMapFreeListIndex*)((nint)Elements.Self + sizeof(TArray<nint>) + TBitArray.GetDefaultStructSize());
    private unsafe int GetFreeListSize() => sizeof(TMapFreeListIndex);
    private unsafe int FirstFreeIndex // 0x38
    {
        get => GetFreeList()->FirstFreeIndex;
        set => GetFreeList()->FirstFreeIndex = value;
    }
    // Hashes: 0x40
    private unsafe int** GetHashesPtr() => (int**)((nint)Elements.Self + sizeof(TArray<nint>) + TBitArray.GetDefaultStructSize() + GetFreeListSize());
    private unsafe int* Hashes // 0x40
    {
        get => *GetHashesPtr();
        set => *GetHashesPtr() = value;
    }
    private unsafe int* GetHashSizePtr() => (int*)((nint)Elements.Self + sizeof(TArray<nint>) + TBitArray.GetDefaultStructSize() + GetFreeListSize() + sizeof(int*));
    private unsafe int HashSize // 0x48
    {
        get => *GetHashSizePtr();
        set => *GetHashSizePtr() = value;
    }
    private static int MIN_SIZE_FOR_HASH_LIST = 0x4;
    private static int HASH_INITIAL_SIZE = 0x10;
    private unsafe int GetStructSize() => sizeof(TArray<nint>) + TBitArray.GetDefaultStructSize() + GetFreeListSize() + sizeof(int*) + sizeof(int) * 2;

    private unsafe void InitMap(IMemoryMethods _MemoryMethods, TMapElementAccessorBase<TKey, TValue, TElemIter> _Elements, Action<string>? _DebugCb = null)
    {
        MemoryMethods = _MemoryMethods;
        if (_Elements.Self == null)
        {
            _Elements.Self = (TArray<nint>*)MemoryMethods.FMemory_Malloc(GetStructSize(), 8);
            Elements = _Elements;
            NativeMemory.Clear(Elements.Self, (nuint)GetStructSize());
            BitAllocator = new TBitArray(MemoryMethods, GetBitAllocatorPtr());
            BitAllocator.Initialize();
            FirstFreeIndex = -1;
            HashSize = 1;
            bOwnsAllocation = true;
        } else
        {
            Elements = _Elements;
            BitAllocator = new TBitArray(MemoryMethods, GetBitAllocatorPtr());
            bOwnsAllocation = false;
        }
        DebugCb = _DebugCb;
    }
    public TManagedMap(IMemoryMethods _MemoryMethods, TMapElementAccessorBase<TKey, TValue, TElemIter> _Elements, Action<string>? _DebugCb = null) => InitMap(_MemoryMethods, _Elements, _DebugCb);
    private unsafe TValue* TryGetLinear(TKey key)
    {
        if (Elements.Size == 0 || !Elements.HasAllocation()) return null;
        TValue* value = null;
        for (int i = 0; i < Elements.Size; i++)
        {
            if (Elements.GetKey(i).Equals(key))
            {
                value = Elements[i];
                break;
            }
        }
        return value;
    }
    private unsafe TValue* TryGetByHash(TKey key)
    {
        TValue* value = null;
        // Hash alloc doesn't exist for single element maps,
        // so fallback to linear search
        if (*GetHashesPtr() == null) return TryGetLinear(key);
        var elementTarget = (*GetHashesPtr())[key.GetTypeHash() & (*GetHashSizePtr() - 1)];
        while (elementTarget != -1)
        {
            if (DebugCb != null) DebugCb($"Element Id: {elementTarget} @ 0x{(nint)(Elements[elementTarget]):X}, next id {Elements.GetNextHashId(elementTarget)}");
            if (Elements.GetKey(elementTarget).Equals(key))
            {
                value = Elements[elementTarget];
                break;
            }
            elementTarget = Elements.GetNextHashId(elementTarget);
        }
        return value;
    }
    public unsafe int Count => Elements.Size;

    public bool IsReadOnly => false;
    private unsafe ICollection<TKey> GetKeys()
    {
        ICollection<TKey> Keys = new List<TKey>();
        for (int i = 0; i < Elements.Size; i++)
            Keys.Add(Elements.GetKey(i));
        return Keys;
    }
    public ICollection<TKey> Keys => GetKeys();
    ICollection<ManagedData<TValue>> IDictionary<TKey, ManagedData<TValue>>.Values => throw new NotImplementedException();

    unsafe ManagedData<TValue> IDictionary<TKey, ManagedData<TValue>>.this[TKey key] 
    { 
        get => new ManagedData<TValue>((nint)TryGetByHash(key));
        set => *TryGetByHash(key) = *value.Self;
    }
    public unsafe TValue* this[TKey key]
    {
        get => new ManagedData<TValue>((nint)TryGetByHash(key)).Self;
        set
        {
            *TryGetByHash(key) = *value;
        }
    }

    private unsafe int GetBucketListTail(int HashIndex)
    {
        int currentIndex = Hashes[HashIndex];
        while (true)
        {
            if (Elements.GetNextHashId(currentIndex) == -1) break;
            currentIndex = Elements.GetNextHashId(currentIndex);
        }
        return currentIndex;
    }

    private unsafe void Rehash(int NewSize)
    {
        int* NewHashAlloc = MemoryMethods.FMemory_MallocMultiple<int>((uint)NewSize);
        NativeMemory.Fill(NewHashAlloc, (nuint)(NewSize * sizeof(int)), 0xff);
        if (Hashes != null)
        {
            MemoryMethods.FMemory_Free((nint)Hashes);
        }
        Hashes = NewHashAlloc;
        for (int i = 0; i < Elements.Size; i++)
        {
            var newHashIndex = (int)Elements.GetKey(i).GetTypeHash() & (NewSize - 1);
            Elements.SetHashIndex(i, newHashIndex);
            if (Hashes[newHashIndex] == -1) Hashes[newHashIndex] = i;
            else Elements.SetNextHashId(GetBucketListTail(newHashIndex), i);
            Elements.SetNextHashId(i, -1);
        }
        HashSize = NewSize;
    }

    private unsafe void Resize(int NewSize)
    {
        nint NewElementAlloc = MemoryMethods.FMemory_Malloc(NewSize * Elements.SizeOf(), 8);
        if (Elements.HasAllocation())
        {
            NativeMemory.Copy((byte*)Elements.Allocation, (byte*)NewElementAlloc, (nuint)(Elements.Size * Elements.SizeOf()));
            MemoryMethods.FMemory_Free(Elements.Allocation);
        }
        Elements.Allocation = NewElementAlloc;
        Elements.Capacity = NewSize;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private unsafe void Resize() => Resize(Elements.HasAllocation() ? Elements.Capacity * 2 : 4);

    public unsafe void Add(TKey key, ManagedData<TValue> value)
    {
        if (ContainsKey(key)) return; // Don't allow duplicate keys
        if (Hashes == null && Elements.Size + 1 >= MIN_SIZE_FOR_HASH_LIST) Rehash(HASH_INITIAL_SIZE);
        else if (Hashes != null && Elements.Size == HashSize) Rehash(HashSize * 2);
        if (Elements.Size == Elements.Capacity) Resize();
        // Get hash index for new key
        if (Hashes != null)
        {
            var hashIndex = (int)(key.GetTypeHash() & (HashSize - 1));
            if (Hashes[hashIndex] == -1) Hashes[hashIndex] = Elements.Size;
            else Elements.SetNextHashId(GetBucketListTail(hashIndex), Elements.Size);
            Elements.SetNextHashId(Elements.Size, -1);
            Elements.SetHashIndex(Elements.Size, hashIndex);
        } else
        {
            Elements.SetNextHashId(Elements.Size, Elements.Size - 1);
            Elements.SetHashIndex(Elements.Size, 0);
        }
        // Add a new element to the array
        Elements.SetKey(Elements.Size, key);
        Elements[Elements.Size] = value.Self;
        // Update the bit allocator
        BitAllocator.Add(true);
        Elements.Size++;
    }
    public unsafe void Add(TKey key, TValue value) => Add(key, new ManagedData<TValue>((nint)(&value)));
    public unsafe void Add(TKey key, TValue* value) => Add(key, new ManagedData<TValue>((nint)value));

    public bool ContainsKey(TKey key) => Keys.Contains(key);

    public bool Remove(TKey key)
    {
        throw new NotImplementedException();
    }

    public unsafe bool TryGetValue(TKey key, [MaybeNullWhen(false)] out ManagedData<TValue> value)
    {
        TValue* GotValue = TryGetByHash(key);
        value = GotValue != null ? new ManagedData<TValue>((nint)GotValue) : null;
        return GotValue != null;
    }

    public void Add(KeyValuePair<TKey, ManagedData<TValue>> item) => Add(item.Key, item.Value);

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(KeyValuePair<TKey, ManagedData<TValue>> item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(KeyValuePair<TKey, ManagedData<TValue>>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<TKey, ManagedData<TValue>> item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<TKey, ManagedData<TValue>>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Leak() => bOwnsAllocation = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!bIsDisposed)
        {
            if (disposing) { }
            unsafe
            {
                if (bOwnsAllocation)
                {
                    MemoryMethods.FMemory_Free((nint)Elements.Self);
                }
            }
            bIsDisposed = true;
        }
    }

    ~TManagedMap() => Dispose(false);
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct FWeakObjectPtr
{
    public int ObjectIndex;
    public int ObjectSerialNumber;
}

[StructLayout(LayoutKind.Sequential)]
public struct TPersistentObjectPtr<T> where T : unmanaged
{
    public FWeakObjectPtr WeakPtr;
    public int TagAtLastTest;
    public T ObjectId;
}

[StructLayout(LayoutKind.Sequential)]
public struct FUniqueObjectGuid
{
    public FGuid Guid;
}

[StructLayout(LayoutKind.Sequential)]
public struct FLazyObjectPtr
{
    public TPersistentObjectPtr<FUniqueObjectGuid> baseObj;
}

[StructLayout(LayoutKind.Sequential)]
public struct TLazyObjectPtr<T> where T : unmanaged
{
    public FLazyObjectPtr baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FSoftObjectPath
{
    [FieldOffset(0x0000)] public FName AssetPathName;
    [FieldOffset(0x0008)] public FString SubPathString;
    public bool IsNull() => AssetPathName.IsNone();
}

[StructLayout(LayoutKind.Sequential)]
public struct FSoftObjectPtr
{
    public TPersistentObjectPtr<FSoftObjectPath> baseObj;
}

[StructLayout(LayoutKind.Sequential)]
public struct TSoftObjectPtr<T> where T : unmanaged
{
    public FSoftObjectPtr baseObj;
    public unsafe TSoftObjectPtr(FName _Name)
    {
        baseObj.baseObj.WeakPtr.ObjectIndex = -1;
        baseObj.baseObj.ObjectId.AssetPathName = _Name;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct TSoftClassPtr<T> where T : unmanaged
{
    public FSoftObjectPtr baseObj;
    public unsafe TSoftClassPtr(FName _Name)
    {
        baseObj.baseObj.WeakPtr.ObjectIndex = -1;
        baseObj.baseObj.ObjectId.AssetPathName = _Name;
    }
}

public enum EObjectFlags : uint
{
    Public = 1 << 0x0,
    Standalone = 1 << 0x1,
    MarkAsNative = 1 << 0x2,
    Transactional = 1 << 0x3,
    ClassDefaultObject = 1 << 0x4,
    ArchetypeObject = 1 << 0x5,
    Transient = 1 << 0x6,
    MarkAsRootSet = 1 << 0x7,
    TagGarbageTemp = 1 << 0x8,
    NeedInitialization = 1 << 0x9,
    NeedLoad = 1 << 0xa,
    KeepForCooker = 1 << 0xb,
    NeedPostLoad = 1 << 0xc,
    NeedPostLoadSubobjects = 1 << 0xd,
    NewerVersionExists = 1 << 0xe,
    BeginDestroyed = 1 << 0xf,
    FinishDestroyed = 1 << 0x10,
    BeingRegenerated = 1 << 0x11,
    DefaultSubObject = 1 << 0x12,
    WasLoaded = 1 << 0x13,
    TextExportTransient = 1 << 0x14,
    LoadCompleted = 1 << 0x15,
    InheritableComponentTemplate = 1 << 0x16,
    DuplicateTransient = 1 << 0x17,
    StrongRefOnFrame = 1 << 0x18,
    NonPIEDuplicateTransient = 1 << 0x19,
    Dynamic = 1 << 0x1a,
    WillBeLoaded = 1 << 0x1b,
    HasExternalPackage = 1 << 0x1c,
    PendingKill = 1 << 0x1d,
    Garbage = 1 << 0x1e,
    AllocatedInSharedPage = (uint)1 << 0x1f
}
public enum EInternalObjectFlags : uint
{
    None = 0,
    LoaderImport = 1 << 20, //< Object is ready to be imported by another package during loading
	    Garbage = 1 << 21, //< Garbage from logical point of view and should not be referenced. This flag is mirrored in EObjectFlags as RF_Garbage for performance
	    PersistentGarbage = 1 << 22, //< Same as above but referenced through a persistent reference so it can't be GC'd
	    ReachableInCluster = 1 << 23, //< External reference to object in cluster exists
	    ClusterRoot = 1 << 24, //< Root of a cluster
	    Native = 1 << 25, //< Native (UClass only). 
	    Async = 1 << 26, //< Object exists only on a different thread than the game thread.
	    AsyncLoading = 1 << 27, //< Object is being asynchronously loaded.
	    Unreachable = 1 << 28, //< Object is not reachable on the object graph.
	    PendingKill = 1 << 29, //< Objects that are pending destruction (invalid for gameplay but valid objects). This flag is mirrored in EObjectFlags as RF_PendingKill for performance
	    RootSet = 1 << 30, //< Object will not be garbage collected, even if unreferenced.
	    PendingConstruction = (uint)1 << 31, //< Object didn't have its class constructor called yet (only the UObject one to initialize its most basic member
};
[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public unsafe struct UObject
{
    public IntPtr _vtable; // @ 0x0
    public EObjectFlags ObjectFlags; // @ 0x8
    public uint InternalIndex; // @ 0xc
    public UClass* ClassPrivate; // @ 0x10 Type of this object. Used for reflection
    public FName NamePrivate; // @ 0x18
    public UObject* OuterPrivate; // @ 0x20 Object that is containing this object
}
// Class data
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct UField
{
    [FieldOffset(0x0)] public UObject _super;
    [FieldOffset(0x28)] public UField* next;
}
[StructLayout(LayoutKind.Explicit, Size = 0xb0)]
public unsafe struct UStruct
{
    [FieldOffset(0x0)] public UField _super;
    [FieldOffset(0x40)] public UStruct* super_struct;
    [FieldOffset(0x48)] public UField* children; // anything not a type field (e.g a class method) - beginning of linked list
    [FieldOffset(0x50)] public FField* child_properties; // the data model - beginning of linked list
    [FieldOffset(0x58)] public int properties_size;
    [FieldOffset(0x5c)] public int min_alignment;
    [FieldOffset(0x60)] public TArray<byte> Script;
    [FieldOffset(0x70)] public FProperty* prop_link;
    [FieldOffset(0x78)] public FProperty* ref_link;
    [FieldOffset(0x80)] public FProperty* dtor_link;
    [FieldOffset(0x88)] public FProperty* post_ct_link;
}
[StructLayout(LayoutKind.Explicit, Size = 0xc0)]
public unsafe struct UScriptStruct
{
    [FieldOffset(0x0)] public UStruct _super;
    [FieldOffset(0xb0)] public uint flags;
    [FieldOffset(0xb4)] public bool b_prepare_cpp_struct_ops_completed;
    [FieldOffset(0xb8)] public IntPtr cpp_struct_ops;
}

/*
public struct FNativeFuncPtr
{
    public IntPtr NameUTF8;
    public IntPtr Pointer;
}
*/

public enum EFunctionFlags : uint
{
    // Function flags.
    FUNC_None = 0x00000000,

    FUNC_Final = 0x00000001,    // Function is final (prebindable, non-overridable function).
    FUNC_RequiredAPI = 0x00000002,  // Indicates this function is DLL exported/imported.
    FUNC_BlueprintAuthorityOnly = 0x00000004,   // Function will only run if the object has network authority
    FUNC_BlueprintCosmetic = 0x00000008,   // Function is cosmetic in nature and should not be invoked on dedicated servers
                                           // FUNC_				= 0x00000010,   // unused.
                                           // FUNC_				= 0x00000020,   // unused.
    FUNC_Net = 0x00000040,   // Function is network-replicated.
    FUNC_NetReliable = 0x00000080,   // Function should be sent reliably on the network.
    FUNC_NetRequest = 0x00000100,   // Function is sent to a net service
    FUNC_Exec = 0x00000200, // Executable from command line.
    FUNC_Native = 0x00000400,   // Native function.
    FUNC_Event = 0x00000800,   // Event function.
    FUNC_NetResponse = 0x00001000,   // Function response from a net service
    FUNC_Static = 0x00002000,   // Static function.
    FUNC_NetMulticast = 0x00004000, // Function is networked multicast Server -> All Clients
    FUNC_UbergraphFunction = 0x00008000,   // Function is used as the merge 'ubergraph' for a blueprint, only assigned when using the persistent 'ubergraph' frame
    FUNC_MulticastDelegate = 0x00010000,    // Function is a multi-cast delegate signature (also requires FUNC_Delegate to be set!)
    FUNC_Public = 0x00020000,   // Function is accessible in all classes (if overridden, parameters must remain unchanged).
    FUNC_Private = 0x00040000,  // Function is accessible only in the class it is defined in (cannot be overridden, but function name may be reused in subclasses.  IOW: if overridden, parameters don't need to match, and Super.Func() cannot be accessed since it's private.)
    FUNC_Protected = 0x00080000,    // Function is accessible only in the class it is defined in and subclasses (if overridden, parameters much remain unchanged).
    FUNC_Delegate = 0x00100000, // Function is delegate signature (either single-cast or multi-cast, depending on whether FUNC_MulticastDelegate is set.)
    FUNC_NetServer = 0x00200000,    // Function is executed on servers (set by replication code if passes check)
    FUNC_HasOutParms = 0x00400000,  // function has out (pass by reference) parameters
    FUNC_HasDefaults = 0x00800000,  // function has structs that contain defaults
    FUNC_NetClient = 0x01000000,    // function is executed on clients
    FUNC_DLLImport = 0x02000000,    // function is imported from a DLL
    FUNC_BlueprintCallable = 0x04000000,    // function can be called from blueprint code
    FUNC_BlueprintEvent = 0x08000000,   // function can be overridden/implemented from a blueprint
    FUNC_BlueprintPure = 0x10000000,    // function can be called from blueprint code, and is also pure (produces no side effects). If you set this, you should set FUNC_BlueprintCallable as well.
    FUNC_EditorOnly = 0x20000000,   // function can only be called from an editor scrippt.
    FUNC_Const = 0x40000000,    // function can be called from blueprint code, and only reads state (never writes state)
    FUNC_NetValidate = 0x80000000,  // function must supply a _Validate implementation
};

[StructLayout(LayoutKind.Explicit, Size = 0xe0)]
public unsafe struct UFunction
{
    [FieldOffset(0x0)] public UStruct _super;
    [FieldOffset(0xb0)] public EFunctionFlags func_flags;
    [FieldOffset(0xb4)] public byte num_params;
    [FieldOffset(0xb6)] public ushort params_size;
    [FieldOffset(0xc0)] public FProperty* first_prop_to_init;
    [FieldOffset(0xc8)] public UFunction* event_graph_func;
    [FieldOffset(0xd8)] public IntPtr exec_func_ptr;
}

public enum EClassFlags : uint
{
    /* No Flags */
    CLASS_None = 0x00000000u,
    /* Class is abstract and can't be instantiated directly. */
    CLASS_Abstract = 0x00000001u,
    /* Save object configuration only to Default INIs, never to local INIs. Must be combined with CLASS_Config */
    CLASS_DefaultConfig = 0x00000002u,
    /* Load object configuration at construction time. */
    CLASS_Config = 0x00000004u,
    /* This object type can't be saved; null it out at save time. */
    CLASS_Transient = 0x00000008u,
    /* This object type may not be available in certain context. (i.e. game runtime or in certain configuration). Optional class data is saved separately to other object types. (i.e. might use sidecar files) */
    CLASS_Optional = 0x00000010u,
    /* */
    CLASS_MatchedSerializers = 0x00000020u,
    /* Indicates that the config settings for this class will be saved to Project/User*.ini (similar to CLASS_GlobalUserConfig) */
    CLASS_ProjectUserConfig = 0x00000040u,
    /* Class is a native class - native interfaces will have CLASS_Native set, but not RF_MarkAsNative */
    CLASS_Native = 0x00000080u,
    /* Don't export to C++ header. */
    CLASS_NoExport = 0x00000100u,
    /* Do not allow users to create in the editor. */
    CLASS_NotPlaceable = 0x00000200u,
    /* Handle object configuration on a per-object basis, rather than per-class. */
    CLASS_PerObjectConfig = 0x00000400u,

    /* Whether SetUpRuntimeReplicationData still needs to be called for this class */
    CLASS_ReplicationDataIsSetUp = 0x00000800u,

    /* Class can be constructed from editinline New button. */
    CLASS_EditInlineNew = 0x00001000u,
    /* Display properties in the editor without using categories. */
    CLASS_CollapseCategories = 0x00002000u,
    /* Class is an interface **/
    CLASS_Interface = 0x00004000u,
    /*  Do not export a constructor for this class, assuming it is in the cpptext **/
    CLASS_CustomConstructor = 0x00008000u,
    /* all properties and functions in this class are const and should be exported as const */
    CLASS_Const = 0x00010000u,

    /* Class flag indicating objects of this class need deferred dependency loading */
    CLASS_NeedsDeferredDependencyLoading = 0x00020000u,

    /* Indicates that the class was created from blueprint source material */
    CLASS_CompiledFromBlueprint = 0x00040000u,

    /* Indicates that only the bare minimum bits of this class should be DLL exported/imported */
    CLASS_MinimalAPI = 0x00080000u,

    /* Indicates this class must be DLL exported/imported (along with all of it's members) */
    CLASS_RequiredAPI = 0x00100000u,

    /* Indicates that references to this class default to instanced. Used to be subclasses of UComponent, but now can be any UObject */
    CLASS_DefaultToInstanced = 0x00200000u,

    /* Indicates that the parent token stream has been merged with ours. */
    CLASS_TokenStreamAssembled = 0x00400000u,
    /* Class has component properties. */
    CLASS_HasInstancedReference = 0x00800000u,
    /* Don't show this class in the editor class browser or edit inline new menus. */
    CLASS_Hidden = 0x01000000u,
    /* Don't save objects of this class when serializing */
    CLASS_Deprecated = 0x02000000u,
    /* Class not shown in editor drop down for class selection */
    CLASS_HideDropDown = 0x04000000u,
    /* Class settings are saved to <AppData>/..../Blah.ini (as opposed to CLASS_DefaultConfig) */
    CLASS_GlobalUserConfig = 0x08000000u,
    /* Class was declared directly in C++ and has no boilerplate generated by UnrealHeaderTool */
    CLASS_Intrinsic = 0x10000000u,
    /* Class has already been constructed (maybe in a previous DLL version before hot-reload). */
    CLASS_Constructed = 0x20000000u,
    /* Indicates that object configuration will not check against ini base/defaults when serialized */
    CLASS_ConfigDoNotCheckDefaults = 0x40000000u,
    /* Class has been consigned to oblivion as part of a blueprint recompile, and a newer version currently exists. */
    CLASS_NewerVersionExists = 0x80000000u,
};
public enum EClassCastFlags : ulong
{
    CASTCLASS_None = 0x0000000000000000,

    CASTCLASS_UField = 0x0000000000000001,
    CASTCLASS_FInt8Property = 0x0000000000000002,
    CASTCLASS_UEnum = 0x0000000000000004,
    CASTCLASS_UStruct = 0x0000000000000008,
    CASTCLASS_UScriptStruct = 0x0000000000000010,
    CASTCLASS_UClass = 0x0000000000000020,
    CASTCLASS_FByteProperty = 0x0000000000000040,
    CASTCLASS_FIntProperty = 0x0000000000000080,
    CASTCLASS_FFloatProperty = 0x0000000000000100,
    CASTCLASS_FUInt64Property = 0x0000000000000200,
    CASTCLASS_FClassProperty = 0x0000000000000400,
    CASTCLASS_FUInt32Property = 0x0000000000000800,
    CASTCLASS_FInterfaceProperty = 0x0000000000001000,
    CASTCLASS_FNameProperty = 0x0000000000002000,
    CASTCLASS_FStrProperty = 0x0000000000004000,
    CASTCLASS_FProperty = 0x0000000000008000,
    CASTCLASS_FObjectProperty = 0x0000000000010000,
    CASTCLASS_FBoolProperty = 0x0000000000020000,
    CASTCLASS_FUInt16Property = 0x0000000000040000,
    CASTCLASS_UFunction = 0x0000000000080000,
    CASTCLASS_FStructProperty = 0x0000000000100000,
    CASTCLASS_FArrayProperty = 0x0000000000200000,
    CASTCLASS_FInt64Property = 0x0000000000400000,
    CASTCLASS_FDelegateProperty = 0x0000000000800000,
    CASTCLASS_FNumericProperty = 0x0000000001000000,
    CASTCLASS_FMulticastDelegateProperty = 0x0000000002000000,
    CASTCLASS_FObjectPropertyBase = 0x0000000004000000,
    CASTCLASS_FWeakObjectProperty = 0x0000000008000000,
    CASTCLASS_FLazyObjectProperty = 0x0000000010000000,
    CASTCLASS_FSoftObjectProperty = 0x0000000020000000,
    CASTCLASS_FTextProperty = 0x0000000040000000,
    CASTCLASS_FInt16Property = 0x0000000080000000,
    CASTCLASS_FDoubleProperty = 0x0000000100000000,
    CASTCLASS_FSoftClassProperty = 0x0000000200000000,
    CASTCLASS_UPackage = 0x0000000400000000,
    CASTCLASS_ULevel = 0x0000000800000000,
    CASTCLASS_AActor = 0x0000001000000000,
    CASTCLASS_APlayerController = 0x0000002000000000,
    CASTCLASS_APawn = 0x0000004000000000,
    CASTCLASS_USceneComponent = 0x0000008000000000,
    CASTCLASS_UPrimitiveComponent = 0x0000010000000000,
    CASTCLASS_USkinnedMeshComponent = 0x0000020000000000,
    CASTCLASS_USkeletalMeshComponent = 0x0000040000000000,
    CASTCLASS_UBlueprint = 0x0000080000000000,
    CASTCLASS_UDelegateFunction = 0x0000100000000000,
    CASTCLASS_UStaticMeshComponent = 0x0000200000000000,
    CASTCLASS_FMapProperty = 0x0000400000000000,
    CASTCLASS_FSetProperty = 0x0000800000000000,
    CASTCLASS_FEnumProperty = 0x0001000000000000,
    CASTCLASS_USparseDelegateFunction = 0x0002000000000000,
    CASTCLASS_FMulticastInlineDelegateProperty = 0x0004000000000000,
    CASTCLASS_FMulticastSparseDelegateProperty = 0x0008000000000000,
    CASTCLASS_FFieldPathProperty = 0x0010000000000000,
};
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe struct UClass
{
    [FieldOffset(0x0)] public UStruct _super;
    [FieldOffset(0xb0)] public IntPtr class_ctor; // InternalConstructor<class_UClassName> => UClassName::UClassName
    [FieldOffset(0xb8)] public IntPtr class_vtable_helper_ctor_caller;
    [FieldOffset(0xc0)] public IntPtr class_add_ref_objects;
    [FieldOffset(0xc8)] public uint class_status; // ClassUnique : 31, bCooked : 1
    [FieldOffset(0xcc)] public EClassFlags class_flags;
    [FieldOffset(0xd0)] public EClassCastFlags class_cast_flags;
    [FieldOffset(0xd8)] public UClass* class_within; // type of object containing the current object
    [FieldOffset(0xe0)] public UObject* class_gen_by;
    [FieldOffset(0xe8)] public FName class_conf_name;
    [FieldOffset(0x100)] public TArray<UField> net_fields;
    [FieldOffset(0x118)] public UObject* class_default_obj; // Default object of type described in UClass instance
    [FieldOffset(0x130)] public TMap<FName, nint> func_map; // TMap<FName, UFunction*>
    [FieldOffset(0x180)] public TMap<FName, nint> super_func_map;
    [FieldOffset(0x1d8)] public TArray<IntPtr> interfaces;
    [FieldOffset(0x220)] public TArray<FNativeFunctionLookup> native_func_lookup;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FNativeFunctionLookup
{
    [FieldOffset(0x0)] FName name;
    [FieldOffset(0x8)] /*FNativeFuncPtr*/ nint Pointer;
}

public unsafe delegate void FNativeFuncPtr(UObject* context, nuint stack, nuint returnValue);

public unsafe struct UEnumEntry // TTuple<FName, long>
{
    public FName name;
    public long value; // Size : 0x10
}

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct UEnum
{
    [FieldOffset(0x0)] public UField _super;
    [FieldOffset(0x30)] public FString cpp_type;
    [FieldOffset(0x40)] public TArray<UEnumEntry> entries;
    [FieldOffset(0x58)] public IntPtr enum_disp_name_fn;
}
// Properties
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct FFieldObjectUnion
{
    public IntPtr field_or_obj;
    public bool b_is_uobj;
}
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct FFieldClass
{
    [FieldOffset(0x0)] public FName name;
    [FieldOffset(0x20)] public FFieldClass* super;
    [FieldOffset(0x28)] public FField* default_obj;
    [FieldOffset(0x30)] public IntPtr ctor; // [PropertyName]::Construct (e.g for ArrayProperty, this would be FArrayProperty::Construct)
}

[StructLayout(LayoutKind.Sequential, Size = 0x38)]
public unsafe struct FField
{
    public IntPtr _vtable; // @ 0x0
    public FFieldClass* class_private; // @ 0x8
    public FFieldObjectUnion owner; // @ 0x10
    public FField* next; // @ 0x20
    public FName name_private; // @ 0x28
    public EObjectFlags flags_private; // @ 0x30

}
public enum EPropertyFlags : ulong
{
    CPF_None = 0,

    CPF_Edit = 0x0000000000000001,  //< Property is user-settable in the editor.
    CPF_ConstParm = 0x0000000000000002, //< This is a constant function parameter
    CPF_BlueprintVisible = 0x0000000000000004,  //< This property can be read by blueprint code
    CPF_ExportObject = 0x0000000000000008,  //< Object can be exported with actor.
    CPF_BlueprintReadOnly = 0x0000000000000010, //< This property cannot be modified by blueprint code
    CPF_Net = 0x0000000000000020,   //< Property is relevant to network replication.
    CPF_EditFixedSize = 0x0000000000000040, //< Indicates that elements of an array can be modified, but its size cannot be changed.
    CPF_Parm = 0x0000000000000080,  //< Function/When call parameter.
    CPF_OutParm = 0x0000000000000100,   //< Value is copied out after function call.
    CPF_ZeroConstructor = 0x0000000000000200,   //< memset is fine for construction
    CPF_ReturnParm = 0x0000000000000400,    //< Return value.
    CPF_DisableEditOnTemplate = 0x0000000000000800, //< Disable editing of this property on an archetype/sub-blueprint
    CPF_NonNullable = 0x0000000000001000,   //< Object property can never be null
    CPF_Transient = 0x0000000000002000, //< Property is transient: shouldn't be saved or loaded, except for Blueprint CDOs.
    CPF_Config = 0x0000000000004000,    //< Property should be loaded/saved as permanent profile.
    //CPF_								= 0x0000000000008000,	//< 
    CPF_DisableEditOnInstance = 0x0000000000010000, //< Disable editing on an instance of this class
    CPF_EditConst = 0x0000000000020000, //< Property is uneditable in the editor.
    CPF_GlobalConfig = 0x0000000000040000,  //< Load config from base class, not subclass.
    CPF_InstancedReference = 0x0000000000080000,    //< Property is a component references.
    //CPF_								= 0x0000000000100000,	//<
    CPF_DuplicateTransient = 0x0000000000200000,    //< Property should always be reset to the default value during any type of duplication (copy/paste, binary duplication, etc.)
    //CPF_								= 0x0000000000400000,	//< 
    //CPF_    							= 0x0000000000800000,	//< 
    CPF_SaveGame = 0x0000000001000000,  //< Property should be serialized for save games, this is only checked for game-specific archives with ArIsSaveGame
    CPF_NoClear = 0x0000000002000000,   //< Hide clear (and browse) button.
    //CPF_  							= 0x0000000004000000,	//<
    CPF_ReferenceParm = 0x0000000008000000, //< Value is passed by reference; CPF_OutParam and CPF_Param should also be set.
    CPF_BlueprintAssignable = 0x0000000010000000,   //< MC Delegates only.  Property should be exposed for assigning in blueprint code
    CPF_Deprecated = 0x0000000020000000,    //< Property is deprecated.  Read it from an archive, but don't save it.
    CPF_IsPlainOldData = 0x0000000040000000,    //< If this is set, then the property can be memcopied instead of CopyCompleteValue / CopySingleValue
    CPF_RepSkip = 0x0000000080000000,   //< Not replicated. For non replicated properties in replicated structs 
    CPF_RepNotify = 0x0000000100000000, //< Notify actors when a property is replicated
    CPF_Interp = 0x0000000200000000,    //< interpolatable property for use with cinematics
    CPF_NonTransactional = 0x0000000400000000,  //< Property isn't transacted
    CPF_EditorOnly = 0x0000000800000000,    //< Property should only be loaded in the editor
    CPF_NoDestructor = 0x0000001000000000,  //< No destructor
    //CPF_								= 0x0000002000000000,	//<
    CPF_AutoWeak = 0x0000004000000000,  //< Only used for weak pointers, means the export type is autoweak
    CPF_ContainsInstancedReference = 0x0000008000000000,    //< Property contains component references.
    CPF_AssetRegistrySearchable = 0x0000010000000000,   //< asset instances will add properties with this flag to the asset registry automatically
    CPF_SimpleDisplay = 0x0000020000000000, //< The property is visible by default in the editor details view
    CPF_AdvancedDisplay = 0x0000040000000000,   //< The property is advanced and not visible by default in the editor details view
    CPF_Protected = 0x0000080000000000, //< property is protected from the perspective of script
    CPF_BlueprintCallable = 0x0000100000000000, //< MC Delegates only.  Property should be exposed for calling in blueprint code
    CPF_BlueprintAuthorityOnly = 0x0000200000000000,    //< MC Delegates only.  This delegate accepts (only in blueprint) only events with BlueprintAuthorityOnly.
    CPF_TextExportTransient = 0x0000400000000000,   //< Property shouldn't be exported to text format (e.g. copy/paste)
    CPF_NonPIEDuplicateTransient = 0x0000800000000000,  //< Property should only be copied in PIE
    CPF_ExposeOnSpawn = 0x0001000000000000, //< Property is exposed on spawn
    CPF_PersistentInstance = 0x0002000000000000,    //< A object referenced by the property is duplicated like a component. (Each actor should have an own instance.)
    CPF_UObjectWrapper = 0x0004000000000000,    //< Property was parsed as a wrapper class like TSubclassOf<T>, FScriptInterface etc., rather than a USomething*
    CPF_HasGetValueTypeHash = 0x0008000000000000,   //< This property can generate a meaningful hash value.
    CPF_NativeAccessSpecifierPublic = 0x0010000000000000,   //< Public native access specifier
    CPF_NativeAccessSpecifierProtected = 0x0020000000000000,    //< Protected native access specifier
    CPF_NativeAccessSpecifierPrivate = 0x0040000000000000,  //< Private native access specifier
    CPF_SkipSerialization = 0x0080000000000000, //< Property shouldn't be serialized, can still be exported to text
};

[StructLayout(LayoutKind.Sequential, Size = 0x78)]
public unsafe struct FProperty
// FInt8Property, FInt16Property, FIntProperty, FInt64Property
// FUint8Property, FUint16Property, FUintProperty, FUint64Property
// FFloatProperty, FDoubleProperty, FNameProperty, FStrProperty
{
    public FField _super; // @ 0x0
    public int array_dim; // @ 0x38
    public int element_size; // @ 0x3c
    public EPropertyFlags property_flags; // @ 0x40
    public ushort rep_index; // @ 0x48
    public byte blueprint_rep_cond; // @ 0x4a
    public byte Field4B; // @ 0x4b
    public int offset_internal; // @ 0x4c
    public FName rep_notify_func; // @ 0x50
    public FProperty* prop_link_next; // @ 0x58
    public FProperty* next_ref; // @ 0x60
    public FProperty* dtor_link_next; // @ 0x68
    public FProperty* post_ct_link_next; // @ 0x70
}
[StructLayout(LayoutKind.Sequential, Size = 0x80)]
public unsafe struct FByteProperty
{
    public FProperty _super; // @ 0x0
    public UEnum* enum_data; // @ 0x78 // TEnumAsByte<EEnum>
}
[StructLayout(LayoutKind.Sequential, Size = 0x80)]
public unsafe struct FBoolProperty
{
    public FProperty _super; // @ 0x0
    public byte field_size; // @ 0x78
    public byte byte_offset; // @ 0x79
    public byte byte_mask; // @ 0x7a
    public byte field_mask; // @ 0x7b
}
[StructLayout(LayoutKind.Sequential, Size = 0x80)]
public unsafe struct FObjectProperty
// FObjectPtrProperty, FWeakObjectProperty, FLazyObjectProperty, FSoftObjectProperty, FInterfaceProperty
{
    // Defines a reference variable to another object
    public FProperty _super; // @ 0x0
    public UClass* prop_class; // @ 0x78
}
[StructLayout(LayoutKind.Sequential, Size = 0x88)]
public unsafe struct FClassProperty
// FClassPtrProperty, FSoftClassProperty
{
    public FObjectProperty _super; // @ 0x0
    public UClass* meta; // @ 0x80
}
[StructLayout(LayoutKind.Sequential, Size = 0x88)]
public unsafe struct FArrayProperty
{
    public FProperty _super; // @ 0x0
    public FProperty* inner; // @ 0x78
    public uint flags; // @ 0x80
}
[StructLayout(LayoutKind.Sequential, Size = 0xa8)]
public unsafe struct FMapProperty
{
    public FProperty _super; // @ 0x0
    public FProperty* key_prop; // @ 0x78
    public FProperty* value_prop; // @ 0x80
}
[StructLayout(LayoutKind.Sequential, Size = 0x98)]
public unsafe struct FSetProperty
{
    public FProperty _super; // @ 0x0
    public FProperty* elem_prop; // @ 0x78
}
[StructLayout(LayoutKind.Sequential, Size = 0x80)]
public unsafe struct FStructProperty
{
    // Structure embedded inside an object
    public FProperty _super; // @ 0x0
    public UScriptStruct* struct_data; // @ 0x78
}
[StructLayout(LayoutKind.Sequential, Size = 0x80)]
public unsafe struct FDelegateProperty
// FMulticastDelegateProperty, FMulticastInlineDelegateProperty, FMulticastSparseDelegateProperty
{
    public FProperty _super;
    public UFunction* func;
}
[StructLayout(LayoutKind.Sequential, Size = 0x88)]
public unsafe struct FEnumProperty
{
    public FProperty _super; // @ 0x0
    public FProperty* underlying_type; // @ 0x78
    public UEnum* enum_data; // @ 0x80
}
// For g_namePool
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FName : IEquatable<FName>, IMapHashable
{
    [FieldOffset(0x0)] public uint pool_location;
    [FieldOffset(0x4)] public uint field04;
    public bool Equals(FName other) => pool_location == other.pool_location;

    public uint GetTypeHash()
    {
        uint block = pool_location >> 0x10;
        uint offset = pool_location & 0xffff;
        return (block << 19) + block + (offset << 0x10) + offset + (offset >> 4) + field04;
    }
    public bool IsNone() => pool_location == 0;
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FString : IEquatable<FString>
{
    public TArray<nint> text;
    public override string ToString() => Marshal.PtrToStringUni((nint)text.allocator_instance, text.arr_num - 1);
    public bool Equals(FString other) => ToString().Equals(other.ToString());
}

[StructLayout(LayoutKind.Explicit, Size = 0x2)]
public unsafe struct FNamePoolString
{
    // Flags:
    // bIsWide : 1;
    // probeHashBits : 5;
    // Length : 10;
    // Get Length: flags >> 6
    [FieldOffset(0x0)] public short flags;
    public string GetString() {
        fixed (FNamePoolString* self = &this)
        {
            return ((flags & 1) == 0) 
                ? Marshal.PtrToStringAnsi((IntPtr)(self + 1), flags >> 6) 
                : Marshal.PtrToStringUni((IntPtr)(self + 1), flags >> 6);
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FNamePool
{
    [FieldOffset(0x8)] public uint pool_count;
    [FieldOffset(0xc)] public uint name_count;
    public IntPtr GetPool(uint pool_idx) { fixed (FNamePool* self = &this) return *((IntPtr*)(self + 1) + pool_idx); }
    public string GetString(FName name) => GetString(name.pool_location);
    public string GetString(uint pool_loc)
    {
        fixed (FNamePool* self = &this)
        {
            // Get appropriate pool
            IntPtr ptr = GetPool(pool_loc >> 0x10); // 0xABB2B - pool 0xA
            // Go to name entry in pool
            ptr += (nint)((pool_loc & 0xFFFF) * 2);
            return ((FNamePoolString*)ptr)->GetString();
        }
    }

}
// For g_objectArray
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FUObjectArray
{
    [FieldOffset(0x0)] public int ObjFirstGCIndex;
    [FieldOffset(0x4)] public int ObjLastNonGCIndex;
    [FieldOffset(0x10)] public FUObjectItem** Objects;
    [FieldOffset(0x24)] public int NumElements;
    // Max number of elements is 0x210000 (2162688)
    // Each chunk can hold 0x10000 elements
    // Max number of chunks is 0x21 (33)
    [FieldOffset(0x2c)] public int NumChunks;
    // 0x30: Critical Section
}
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FUObjectItem
{
    [FieldOffset(0x0)] public UObject* Object;
    [FieldOffset(0x8)] public EInternalObjectFlags Flags;
}
// For StaticConstructObject_Internal
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct FStaticConstructObjectParameters
{
    [FieldOffset(0x0)] public UClass* Class; // Type Info
    [FieldOffset(0x8)] public UObject* Outer; // The created object will be a child of this object
    [FieldOffset(0x10)] public FName Name;
    [FieldOffset(0x18)] public EObjectFlags SetFlags;
    [FieldOffset(0x1c)] public EInternalObjectFlags InternalSetFlags;
    [FieldOffset(0x20)] public byte bCopyTransientsFromClassDefaults;
    [FieldOffset(0x21)] public byte bAssumeTemplateIsArchetype;
    [FieldOffset(0x28)] public UObject* Template;
    [FieldOffset(0x30)] public IntPtr InstanceGraph;
    [FieldOffset(0x38)] public IntPtr ExternalPackage;
}

// ===================================
// GENERATED FROM UE4SS CXX HEADER DUMP
// ===================================
// CoreUObject.hpp

[StructLayout(LayoutKind.Sequential, Size = 0xc)]
public struct FVector
{
    public float X;                                                                          // 0x0000 (size: 0x4)
    public float Y;                                                                          // 0x0004 (size: 0x4)
    public float Z;                                                                          // 0x0008 (size: 0x4)

    public FVector(float x, float y, float z) { X = x; Y = y; Z = z; }
    public override string ToString() => $"({X}, {Y}, {Z})";
}; // Size: 0xC

[StructLayout(LayoutKind.Sequential, Size = 0x8)]
public struct FVector2D
{
    public float X;                                                                          // 0x0000 (size: 0x4)
    public float Y;                                                                          // 0x0004 (size: 0x4)

    public FVector2D(float x, float y) { X = x; Y = y; }

    public override string ToString() => $"({X}, {Y})";
}; // Size: 0x8

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct FVector4
{
    public float X;                                                                          // 0x0000 (size: 0x4)
    public float Y;                                                                          // 0x0004 (size: 0x4)
    public float Z;                                                                          // 0x0008 (size: 0x4)
    public float W;                                                                          // 0x000C (size: 0x4)

    public FVector4(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }
    public override string ToString() => $"({X}, {Y}, {Z}, {W})";

}; // Size: 0x10

[StructLayout(LayoutKind.Sequential, Size = 0x4)]
public struct FColor
{
    public byte B; // 0x0000 (size: 0x1)
    public byte G; // 0x0001 (size: 0x1)
    public byte R; // 0x0002 (size: 0x1)
    public byte A; // 0x0003 (size: 0x1)

    public override string ToString() => $"#{R:X2}{G:X2}{B:X2}{A:X2}";

    public FColor(byte r, byte g, byte b, byte a)
    {
        B = a;
        G = b;
        R = g;
        A = r;
    }

    public FColor(uint color)
    {
        R = (byte)((color >> 0x18) & 0xff);
        G = (byte)((color >> 0x10) & 0xff);
        B = (byte)((color >> 0x8) & 0xff);
        A = (byte)(color & 0xff);
    }

    public void SetColor(uint color)
    {
        R = (byte)((color >> 0x18) & 0xff);
        G = (byte)((color >> 0x10) & 0xff);
        B = (byte)((color >> 0x8) & 0xff);
        A = (byte)(color & 0xff);
    }

}; // Size: 0x4
public struct FSprColor
{
    // Different color component order
    public byte A;
    public byte B;
    public byte G;
    public byte R;

    public override string ToString() => $"#{R:X2}{G:X2}{B:X2}{A:X2}";
    public FSprColor(byte r, byte g, byte b, byte a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }
    public FSprColor(uint color)
    {
        R = (byte)((color >> 0x18) & 0xff);
        G = (byte)((color >> 0x10) & 0xff);
        B = (byte)((color >> 0x8) & 0xff);
        A = (byte)(color & 0xff);
    }
    public void SetColor(uint color)
    {
        R = (byte)((color >> 0x18) & 0xff);
        G = (byte)((color >> 0x10) & 0xff);
        B = (byte)((color >> 0x8) & 0xff);
        A = (byte)(color & 0xff);
    }
}
[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public struct FLinearColor
{
    public float R;
    public float G;
    public float B;
    public float A;

    public override string ToString() => $"#{(uint)(R * 255):X2}{(uint)(G * 255):X2}{(uint)(B * 255):X2}{(uint)(A * 255):X2}";

    public void SetColor(uint color)
    {
        R = (float)(byte)((color >> 0x18) & 0xff) / 256;
        G = (float)(byte)((color >> 0x10) & 0xff) / 256;
        B = (float)(byte)((color >> 0x8) & 0xff) / 256;
        A = (float)(byte)(color & 0xff) / 256;
    }

    public FLinearColor(float r, float g, float b, float a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

}; // Size: 0x10
[StructLayout(LayoutKind.Sequential, Size = 0xc)]
public struct FRotator
{
    float Pitch;                                                                      // 0x0000 (size: 0x4)
    float Yaw;                                                                        // 0x0004 (size: 0x4)
    float Roll;                                                                       // 0x0008 (size: 0x4)

    public FRotator(float pitch, float yaw, float roll) { Pitch = pitch; Yaw = yaw; Roll = roll; }

}; // Size: 0xC

[StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
public unsafe struct UTexture2D // : UTexture
{
    [FieldOffset(0x0000)] public UTexture baseObj;
    [FieldOffset(0x0178)] public int LevelIndex;
    [FieldOffset(0x017C)] public int FirstResourceMemMip;
    [FieldOffset(0x0180)] public byte bTemporarilyDisableStreaming;
    //[FieldOffset(0x0181)] public TextureAddress AddressX;
    //[FieldOffset(0x0182)] public TextureAddress AddressY;
    //[FieldOffset(0x0184)] public FIntPoint ImportedSize;
}

[StructLayout(LayoutKind.Explicit, Size = 0x180)]
public unsafe struct UTexture // : UStreamableRenderAsset
{
    [FieldOffset(0x0000)] public UStreamableRenderAsset baseObj;
    [FieldOffset(0x0068)] public FGuid LightingGuid;
    [FieldOffset(0x0078)] public int LODBias;
    //[FieldOffset(0x007C)] public TextureCompressionSettings CompressionSettings;
    //[FieldOffset(0x007D)] public TextureFilter Filter;
    //[FieldOffset(0x007E)] public ETextureMipLoadOptions MipLoadOptions;
    //[FieldOffset(0x007F)] public TextureGroup LODGroup;
    //[FieldOffset(0x0080)] public FPerPlatformFloat Downscale;
    //[FieldOffset(0x0084)] public ETextureDownscaleOptions DownscaleOptions;
    //[FieldOffset(0x0085)] public byte sRGB;
    //[FieldOffset(0x0085)] public byte bNoTiling;
    //[FieldOffset(0x0085)] public byte VirtualTextureStreaming;
    //[FieldOffset(0x0085)] public byte CompressionYCoCg;
    //[FieldOffset(0x0085)] public byte bNotOfflineProcessed;
    //[FieldOffset(0x0085)] public byte bAsyncResourceReleaseHasBeenStarted;
    [FieldOffset(0x0088)] public TArray<IntPtr> AssetUserData;
}

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct UDataTable //: public UObject
{
    [FieldOffset(0x0028)] public UScriptStruct* RowStruct;
    [FieldOffset(0x30)] public TMap<FName, nint> RowMap;
    [FieldOffset(0x0080)] public byte bStripFromClientBuilds;
    [FieldOffset(0x0080)] public byte bIgnoreExtraFields;
    [FieldOffset(0x0080)] public byte bIgnoreMissingFields;
    [FieldOffset(0x0088)] public FString ImportKeyField;
};

public enum EActorUpdateOverlapsMethod : byte
{
    UseConfigDefault = 0,
    AlwaysUpdate = 1,
    OnlyUpdateMovable = 2,
    NeverUpdate = 3,
    EActorUpdateOverlapsMethod_MAX = 4,
};

public enum ENetRole : byte
{
    ROLE_None = 0,
    ROLE_SimulatedProxy = 1,
    ROLE_AutonomousProxy = 2,
    ROLE_Authority = 3,
    ROLE_MAX = 4,
};

public enum EVectorQuantization : byte
{
    RoundWholeNumber = 0,
    RoundOneDecimal = 1,
    RoundTwoDecimals = 2,
    EVectorQuantization_MAX = 3,
};

public enum ERotatorQuantization : byte
{
    ByteComponents = 0,
    ShortComponents = 1,
    ERotatorQuantization_MAX = 2,
};

[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public unsafe struct FRepMovement
{
    [FieldOffset(0x0000)] public FVector LinearVelocity;
    [FieldOffset(0x000C)] public FVector AngularVelocity;
    [FieldOffset(0x0018)] public FVector Location;
    [FieldOffset(0x0024)] public FRotator Rotation;
    [FieldOffset(0x0030)] public byte bSimulatedPhysicSleep;
    [FieldOffset(0x0030)] public byte bRepPhysics;
    [FieldOffset(0x0031)] public EVectorQuantization LocationQuantizationLevel;
    [FieldOffset(0x0032)] public EVectorQuantization VelocityQuantizationLevel;
    [FieldOffset(0x0033)] public ERotatorQuantization RotationQuantizationLevel;

}; // Size: 0x34
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct FRepAttachment
{
    [FieldOffset(0x0000)] public AActor* AttachParent;
    [FieldOffset(0x0008)] public FVector LocationOffset;
    [FieldOffset(0x0014)] public FVector RelativeScale3D;
    [FieldOffset(0x0020)] public FRotator RotationOffset;
    [FieldOffset(0x002C)] public FName AttachSocket;
    //[FieldOffset(0x0038)] public USceneComponent* AttachComponent;
    [FieldOffset(0x0038)] public nint AttachComponent;
};

public enum ENetDormancy : byte
{
    DORM_Never = 0,
    DORM_Awake = 1,
    DORM_DormantAll = 2,
    DORM_DormantPartial = 3,
    DORM_Initial = 4,
    DORM_MAX = 5,
};

public enum ESpawnActorCollisionHandlingMethod : byte
{
    Undefined = 0,
    AlwaysSpawn = 1,
    AdjustIfPossibleButAlwaysSpawn = 2,
    AdjustIfPossibleButDontSpawnIfColliding = 3,
    DontSpawnIfColliding = 4,
    ESpawnActorCollisionHandlingMethod_MAX = 5,
};

public enum EAutoReceiveInputType : byte
{
    Disabled = 0,
    Player0 = 1,
    Player1 = 2,
    Player2 = 3,
    Player3 = 4,
    Player4 = 5,
    Player5 = 6,
    Player6 = 7,
    Player7 = 8,
    EAutoReceiveInput_MAX = 9,
};

[StructLayout(LayoutKind.Explicit, Size = 0x220)]
public unsafe struct AActor // : UObject
{
    [FieldOffset(0x005D)] public EActorUpdateOverlapsMethod UpdateOverlapsMethodDuringLevelStreaming;
    [FieldOffset(0x005E)] public EActorUpdateOverlapsMethod DefaultUpdateOverlapsMethodDuringLevelStreaming;
    [FieldOffset(0x005F)] public ENetRole RemoteRole;
    [FieldOffset(0x0060)] public FRepMovement ReplicatedMovement;
    [FieldOffset(0x0094)] public float InitialLifeSpan;
    [FieldOffset(0x0098)] public float CustomTimeDilation;
    [FieldOffset(0x00A0)] public FRepAttachment AttachmentReplication;
    [FieldOffset(0x00E0)] public AActor* Owner;
    [FieldOffset(0x00E8)] public FName NetDriverName;
    [FieldOffset(0x00F0)] public ENetRole Role;
    [FieldOffset(0x00F1)] public ENetDormancy NetDormancy;
    [FieldOffset(0x00F2)] public ESpawnActorCollisionHandlingMethod SpawnCollisionHandlingMethod;
    [FieldOffset(0x00F3)] public EAutoReceiveInputType AutoReceiveInput;
    [FieldOffset(0x00F4)] public int InputPriority;
    //[FieldOffset(0x00F8)] public UInputComponent* InputComponent;
    [FieldOffset(0x00F8)] public nint InputComponent;
    [FieldOffset(0x0100)] public float NetCullDistanceSquared;
    [FieldOffset(0x0104)] public int NetTag;
    [FieldOffset(0x0108)] public float NetUpdateFrequency;
    [FieldOffset(0x010C)] public float MinNetUpdateFrequency;
    [FieldOffset(0x0110)] public float NetPriority;
    //[FieldOffset(0x0118)] public APawn* Instigator;
    [FieldOffset(0x0118)] public nint Instigator;
    [FieldOffset(0x0120)] public TArray<nint> Children;
    //[FieldOffset(0x0130)] public USceneComponent* RootComponent;
    [FieldOffset(0x0130)] public nint RootComponent;
    [FieldOffset(0x0138)] public TArray<nint> ControllingMatineeActors;
    [FieldOffset(0x0150)] public TArray<FName> Layers;
    //[FieldOffset(0x0160)] public UChildActorComponent* ParentComponent;
    [FieldOffset(0x0160)] public nint ParentComponent;
    [FieldOffset(0x0170)] public TArray<FName> Tags;
}
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FGuid
{
    [FieldOffset(0x0)] public uint A;
    [FieldOffset(0x4)] public uint B;
    [FieldOffset(0x8)] public uint C;
    [FieldOffset(0xc)] public uint D;

    public override string ToString() => $"{A:X}-{B:X}-{C:X}-{D:X}";
}

[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe struct UMaterial //: public UMaterialInterface
{
};

[StructLayout(LayoutKind.Explicit, Size = 0xb8)]
public unsafe struct USubsurfaceProfile //: public UObject
{
    [FieldOffset(0x0028)] FSubsurfaceProfileStruct Settings;

};
[StructLayout(LayoutKind.Explicit, Size = 0x8c)]
public unsafe struct FSubsurfaceProfileStruct
{
    [FieldOffset(0x0000)] public FColor SurfaceAlbedo;
    [FieldOffset(0x0010)] public FColor MeanFreePathColor;
    [FieldOffset(0x0020)] public float MeanFreePathDistance;
    [FieldOffset(0x0024)] public float WorldUnitScale;
    [FieldOffset(0x0028)] public bool bEnableBurley;
    [FieldOffset(0x002C)] public float ScatterRadius;
    [FieldOffset(0x0030)] public FColor SubsurfaceColor;
    [FieldOffset(0x0040)] public FColor FalloffColor;
    [FieldOffset(0x0050)] public FColor BoundaryColorBleed;
    [FieldOffset(0x0060)] public float ExtinctionScale;
    [FieldOffset(0x0064)] public float NormalScale;
    [FieldOffset(0x0068)] public float ScatteringDistribution;
    [FieldOffset(0x006C)] public float IOR;
    [FieldOffset(0x0070)] public float Roughness0;
    [FieldOffset(0x0074)] public float Roughness1;
    [FieldOffset(0x0078)] public float LobeMix;
    [FieldOffset(0x007C)] public FColor TransmissionTintColor;

};

public unsafe struct FLightmassMaterialInterfaceSettings
{
    float EmissiveBoost;                                                              // 0x0000 (size: 0x4)
    float DiffuseBoost;                                                               // 0x0004 (size: 0x4)
    float ExportResolutionScale;                                                      // 0x0008 (size: 0x4)
    //byte bCastShadowAsMasked;                                                        // 0x000C (size: 0x1)
    //byte bOverrideCastShadowAsMasked;                                                // 0x000C (size: 0x1)
    //byte bOverrideEmissiveBoost;                                                     // 0x000C (size: 0x1)
    //byte bOverrideDiffuseBoost;                                                      // 0x000C (size: 0x1)
    //byte bOverrideExportResolutionScale;                                             // 0x000C (size: 0x1)

}; // Size: 0x10

public unsafe struct FMaterialTextureInfo
{
    float SamplingScale;                                                              // 0x0000 (size: 0x4)
    int UVChannelIndex;                                                                 // 0x0004 (size: 0x4)
    FName TextureName;                                                                // 0x0008 (size: 0x8)

}; // Size: 0x10

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct UMaterialInterface //: public UObject
{
    [FieldOffset(0x0038)] public USubsurfaceProfile* SubsurfaceProfile;
    [FieldOffset(0x0050)] public FLightmassMaterialInterfaceSettings LightmassSettings;
    [FieldOffset(0x0060)] public TArray<FMaterialTextureInfo> TextureStreamingData;
    [FieldOffset(0x0070)] public TArray<nint> AssetUserData;
};

public enum EFrictionCombineModeType : byte
{
    Average = 0,
    Min = 1,
    Multiply = 2,
    Max = 3,
};

public enum EPhysicalSurface : byte
{
    SurfaceType_Default = 0,
    SurfaceType1 = 1,
    SurfaceType2 = 2,
    SurfaceType3 = 3,
    SurfaceType4 = 4,
    SurfaceType5 = 5,
    SurfaceType6 = 6,
    SurfaceType7 = 7,
    SurfaceType8 = 8,
    SurfaceType9 = 9,
    SurfaceType10 = 10,
    SurfaceType11 = 11,
    SurfaceType12 = 12,
    SurfaceType13 = 13,
    SurfaceType14 = 14,
    SurfaceType15 = 15,
    SurfaceType16 = 16,
    SurfaceType17 = 17,
    SurfaceType18 = 18,
    SurfaceType19 = 19,
    SurfaceType20 = 20,
    SurfaceType21 = 21,
    SurfaceType22 = 22,
    SurfaceType23 = 23,
    SurfaceType24 = 24,
    SurfaceType25 = 25,
    SurfaceType26 = 26,
    SurfaceType27 = 27,
    SurfaceType28 = 28,
    SurfaceType29 = 29,
    SurfaceType30 = 30,
    SurfaceType31 = 31,
    SurfaceType32 = 32,
    SurfaceType33 = 33,
    SurfaceType34 = 34,
    SurfaceType35 = 35,
    SurfaceType36 = 36,
    SurfaceType37 = 37,
    SurfaceType38 = 38,
    SurfaceType39 = 39,
    SurfaceType40 = 40,
    SurfaceType41 = 41,
    SurfaceType42 = 42,
    SurfaceType43 = 43,
    SurfaceType44 = 44,
    SurfaceType45 = 45,
    SurfaceType46 = 46,
    SurfaceType47 = 47,
    SurfaceType48 = 48,
    SurfaceType49 = 49,
    SurfaceType50 = 50,
    SurfaceType51 = 51,
    SurfaceType52 = 52,
    SurfaceType53 = 53,
    SurfaceType54 = 54,
    SurfaceType55 = 55,
    SurfaceType56 = 56,
    SurfaceType57 = 57,
    SurfaceType58 = 58,
    SurfaceType59 = 59,
    SurfaceType60 = 60,
    SurfaceType61 = 61,
    SurfaceType62 = 62,
    SurfaceType_Max = 63,
    EPhysicalSurface_MAX = 64,
};

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe struct UPhysicalMaterial //: public UObject
{
    [FieldOffset(0x0028)] public float Friction;
    [FieldOffset(0x002C)] public float StaticFriction;
    [FieldOffset(0x0030)] public EFrictionCombineModeType FrictionCombineMode;
    [FieldOffset(0x0031)] public bool bOverrideFrictionCombineMode;
    [FieldOffset(0x0034)] public float Restitution;
    [FieldOffset(0x0038)] public EFrictionCombineModeType RestitutionCombineMode;
    [FieldOffset(0x0039)] public bool bOverrideRestitutionCombineMode;
    [FieldOffset(0x003C)] public float Density;
    [FieldOffset(0x0040)] public float SleepLinearVelocityThreshold;
    [FieldOffset(0x0044)] public float SleepAngularVelocityThreshold;
    [FieldOffset(0x0048)] public int SleepCounterThreshold;
    [FieldOffset(0x004C)] public float RaiseMassToPower;
    [FieldOffset(0x0050)] public float DestructibleDamageThresholdScale;
    [FieldOffset(0x0060)] public EPhysicalSurface SurfaceType;
};

public enum EMaterialParameterAssociation : byte
{
    LayerParameter = 0,
    BlendParameter = 1,
    GlobalParameter = 2,
    EMaterialParameterAssociation_MAX = 3,
};
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FMaterialParameterInfo
{
    [FieldOffset(0x0000)] public FName Name;
    [FieldOffset(0x0008)] public EMaterialParameterAssociation Association;
    [FieldOffset(0x000C)] public int Index;

    public string FormatString(FNamePool* namePool) => $"{namePool->GetString(Name.pool_location)}, {Association}, {Index}";
};

[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public unsafe struct FScalarParameterValue
{
    [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
    [FieldOffset(0x0010)] public float ParameterValue;
    [FieldOffset(0x0014)] public FGuid ExpressionGUID;

};
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FVectorParameterValue
{
    [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
    [FieldOffset(0x0010)] public FColor ParameterValue;
    [FieldOffset(0x0020)] public FGuid ExpressionGUID;

}; // Size: 0x30
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct FTextureParameterValue
{
    [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
    [FieldOffset(0x0010)] public UTexture* ParameterValue;
    [FieldOffset(0x0018)] public FGuid ExpressionGUID;

}; // Size: 0x28
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct FRuntimeVirtualTextureParameterValue
{
    [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
    //[FieldOffset(0x0010)] public URuntimeVirtualTexture* ParameterValue;
    [FieldOffset(0x0018)] public FGuid ExpressionGUID;

}; // Size: 0x28
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FFontParameterValue
{
    [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
    //[FieldOffset(0x0010)] public class UFont* FontValue;
    [FieldOffset(0x0018)] public int FontPage;
    [FieldOffset(0x001C)] public FGuid ExpressionGUID;

}; // Size: 0x30

[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe struct UMaterialInstance //: public UMaterialInterface
{
    [FieldOffset(0x0088)] public UPhysicalMaterial* PhysMaterial;
    [FieldOffset(0x0090)] public UPhysicalMaterial* PhysicalMaterialMap;
    [FieldOffset(0x00D0)] public UMaterialInterface* Parent;
    //[FieldOffset(0x00D8)] public //uint8 bHasStaticPermutationResource;
    //[FieldOffset(0x00D8)] public //uint8 bOverrideSubsurfaceProfile;
    [FieldOffset(0x00E0)] public TArray<FScalarParameterValue> ScalarParameterValues;
    [FieldOffset(0x00F0)] public TArray<FVectorParameterValue> VectorParameterValues;
    [FieldOffset(0x0100)] public TArray<FTextureParameterValue> TextureParameterValues;
    [FieldOffset(0x0110)] public TArray<FRuntimeVirtualTextureParameterValue> RuntimeVirtualTextureParameterValues;
    [FieldOffset(0x0120)] public TArray<FFontParameterValue> FontParameterValues;
    //[FieldOffset(0x0130)] public //FMaterialInstanceBasePropertyOverrides BasePropertyOverrides;
    //[FieldOffset(0x0148)] public //FStaticParameterSet StaticParameters;
    //[FieldOffset(0x0188)] public //FMaterialCachedParameters CachedLayerParameters;
    //[FieldOffset(0x02D8)] public //TArray<class UObject*> CachedReferencedTextures;
};
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public unsafe struct UMaterialInstanceDynamic // : public UMaterialInstance
{
    public void SetVectorParamteterValue(FName name, FLinearColor* vector)
    {

    }
}

// FOR BLUEPRINTS

[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe struct FFrame
{
    [FieldOffset(0x10)] public UFunction* Node;
    [FieldOffset(0x18)] public UFunction* Object;
    [FieldOffset(0x20)] public byte* Code;
    [FieldOffset(0x28)] public byte* Locals;
    [FieldOffset(0x30)] public FProperty* MostRecentProperty;
    [FieldOffset(0x38)] public byte* MostRecentPropertyAddress;
    [FieldOffset(0x70)] public FFrame* PreviousFrame;
    [FieldOffset(0x80)] public FField* PropertyChainForCompiledIn;
    [FieldOffset(0x88)] public UFunction* CurrentNativeFunction;
    [FieldOffset(0x90)] public bool bArrayContextFailed;
}

[StructLayout(LayoutKind.Explicit, Size = 0x798)]
public unsafe struct UWorld //: public UObject
{
    [FieldOffset(0x0030)] public ULevel* PersistentLevel;
    //[FieldOffset(0x0038)] public UNetDriver* NetDriver;
    //[FieldOffset(0x0040)] public ULineBatchComponent* LineBatcher;
    //[FieldOffset(0x0048)] public ULineBatchComponent* PersistentLineBatcher;
    //[FieldOffset(0x0050)] public ULineBatchComponent* ForegroundLineBatcher;
    //[FieldOffset(0x0058)] public AGameNetworkManager* NetworkManager;
    //[FieldOffset(0x0060)] public UPhysicsCollisionHandler* PhysicsCollisionHandler;
    //[FieldOffset(0x0068)] public TArray<nint> ExtraReferencedObjects;
    //[FieldOffset(0x0078)] public TArray<nint> PerModuleDataObjects;
    [FieldOffset(0x0088)] public TArray<nint> StreamingLevels; // TArray<ULevelStreaming*>
    //[FieldOffset(0x0098)] public FStreamingLevelsToConsider StreamingLevelsToConsider;
    [FieldOffset(0x00C0)] public FString StreamingLevelsPrefix;
    [FieldOffset(0x00D0)] public ULevel* CurrentLevelPendingVisibility;
    [FieldOffset(0x00D8)] public ULevel* CurrentLevelPendingInvisibility;
    //[FieldOffset(0x00E0)] public UDemoNetDriver* DemoNetDriver;
    //[FieldOffset(0x00E8)] public AParticleEventManager* MyParticleEventManager;
    //[FieldOffset(0x00F0)] public APhysicsVolume* DefaultPhysicsVolume;
    //[FieldOffset(0x010E)] public byte bAreConstraintsDirty;
    //[FieldOffset(0x0110)] public UNavigationSystemBase* NavigationSystem;
    //[FieldOffset(0x0118)] public AGameModeBase* AuthorityGameMode;
    //[FieldOffset(0x0120)] public AGameStateBase* GameState;
    //[FieldOffset(0x0128)] public UAISystemBase* AISystem;
    //[FieldOffset(0x0130)] public UAvoidanceManager* AvoidanceManager;
    //[FieldOffset(0x0138)] public TArray<nint> Levels;
    //[FieldOffset(0x0148)] public TArray<FLevelCollection> LevelCollections;
    //[FieldOffset(0x0180)] public UGameInstance* OwningGameInstance;
    //[FieldOffset(0x0188)] public TArray<nint> ParameterCollectionInstances;
    //[FieldOffset(0x0198)] public UCanvas* CanvasForRenderingToTarget;
    //[FieldOffset(0x01A0)] public UCanvas* CanvasForDrawMaterialToRenderTarget;
    //[FieldOffset(0x01F8)] public UPhysicsFieldComponent* PhysicsField;
    //[FieldOffset(0x0200)] public TSet<UActorComponent*> ComponentsThatNeedPreEndOfFrameSync;
    //[FieldOffset(0x0250)] public TArray<nint> ComponentsThatNeedEndOfFrameUpdate;
    //[FieldOffset(0x0260)] public TArray<nint> ComponentsThatNeedEndOfFrameUpdate_OnGameThread;
    //[FieldOffset(0x05E0)] public UWorldComposition* WorldComposition;
    //[FieldOffset(0x0678)] public FWorldPSCPool PSCPool;
};

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct ULevelStreaming
{

}

public enum ERichCurveExtrapolation : byte
{
    RCCE_Cycle = 0,
    RCCE_CycleWithOffset = 1,
    RCCE_Oscillate = 2,
    RCCE_Linear = 3,
    RCCE_Constant = 4,
    RCCE_None = 5,
};

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe struct FRealCurve //: public FIndexedCurve
{
    [FieldOffset(0x0068)] public float DefaultValue;                                                               //  (size: 0x4)
    [FieldOffset(0x006C)] public ERichCurveExtrapolation PreInfinityExtrap;                           //  (size: 0x1)
    [FieldOffset(0x006D)] public ERichCurveExtrapolation PostInfinityExtrap;                          //  (size: 0x1)

}; // Size: 0x70

public enum ERichCurveInterpMode : byte
{
    RCIM_Linear = 0,
    RCIM_Constant = 1,
    RCIM_Cubic = 2,
    RCIM_None = 3,
};

public enum ERichCurveTangentMode : byte
{
    RCTM_Auto = 0,
    RCTM_User = 1,
    RCTM_Break = 2,
    RCTM_None = 3,
};

public enum ERichCurveTangentWeightMode : byte
{
    RCTWM_WeightedNone = 0,
    RCTWM_WeightedArrive = 1,
    RCTWM_WeightedLeave = 2,
    RCTWM_WeightedBoth = 3,
};

public unsafe struct FRichCurveKey
{
    ERichCurveInterpMode InterpMode;                                     // 0x0000 (size: 0x1)
    ERichCurveTangentMode TangentMode;                                   // 0x0001 (size: 0x1)
    ERichCurveTangentWeightMode TangentWeightMode;                       // 0x0002 (size: 0x1)
    float Time;                                                                       // 0x0004 (size: 0x4)
    float Value;                                                                      // 0x0008 (size: 0x4)
    float ArriveTangent;                                                              // 0x000C (size: 0x4)
    float ArriveTangentWeight;                                                        // 0x0010 (size: 0x4)
    float LeaveTangent;                                                               // 0x0014 (size: 0x4)
    float LeaveTangentWeight;                                                         // 0x0018 (size: 0x4)

}; // Size: 0x1C

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public struct FRichCurve //: public FRealCurve
{
    [FieldOffset(0x0070)] TArray<FRichCurveKey> Keys;                                                       // 0x0070 (size: 0x10)
}; // Size: 0x80

[StructLayout(LayoutKind.Explicit, Size = 0x1b0)]
public unsafe struct UCurveVector
{
    [FieldOffset(0x0)] public UCurveBase baseObj;
    [FieldOffset(0x30)] public FRichCurve FloatCurves;
}

[StructLayout(LayoutKind.Explicit, Size = 0x250)]
public unsafe struct UCurveLinearColor //: public UCurveBase
{
    [FieldOffset(0x0030)] public FRichCurve FloatCurves;
    [FieldOffset(0x0230)] public float AdjustHue;
    [FieldOffset(0x0234)] public float AdjustSaturation;
    [FieldOffset(0x0238)] public float AdjustBrightness;
    [FieldOffset(0x023C)] public float AdjustBrightnessCurve;
    [FieldOffset(0x0240)] public float AdjustVibrance;
    [FieldOffset(0x0244)] public float AdjustMinAlpha;
    [FieldOffset(0x0248)] public float AdjustMaxAlpha;
}; // Size: 0x250

public enum EFindType : int
{
    FNAME_Find = 0,
    FNAME_Add = 1,
    FNAME_Replace_Not_Safe_For_Threading = 2
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe struct FForceFeedbackChannelDetails
{
    [FieldOffset(0x0000)] public byte bAffectsLeftLarge;
    [FieldOffset(0x0000)] public byte bAffectsLeftSmall;
    [FieldOffset(0x0000)] public byte bAffectsRightLarge;
    [FieldOffset(0x0000)] public byte bAffectsRightSmall;
    [FieldOffset(0x0008)] public FRuntimeFloatCurve Curve;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct FRuntimeFloatCurve
{
    [FieldOffset(0x0000)] public FRichCurve EditorCurveData;
    [FieldOffset(0x0080)] public UCurveFloat* ExternalCurve;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct UCurveBase
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe struct UCurveFloat
{
    [FieldOffset(0x0000)] public UCurveBase baseObj;
    [FieldOffset(0x0030)] public FRichCurve FloatCurve;
    [FieldOffset(0x00B0)] public bool bIsEventCurve;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UForceFeedbackEffect
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public TArray<FForceFeedbackChannelDetails> ChannelDetails;
    [FieldOffset(0x0038)] public float Duration;
}

// LEVEL SEQUENCE/MOVIE
public enum EMoviePlaybackType : byte
{
    MT_Normal = 0,
    MT_Looped = 1,
    MT_LoadingLoop = 2,
};

public enum EMovieScenePlayerStatus : byte
{
    Stopped = 0,
    Playing = 1,
    Scrubbing = 2,
    Jumping = 3,
    Stepping = 4,
    Paused = 5,
};

[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public unsafe struct FFrameNumber
{
    [FieldOffset(0x0000)] public int Value;
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct UMovieSceneSignedObject
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public FGuid Signature;
}

[StructLayout(LayoutKind.Explicit, Size = 0x160)]
public unsafe struct FMovieSceneEvaluationTemplate
{
    //[FieldOffset(0x0000)] public TMap<FMovieSceneTrackIdentifier, FMovieSceneEvaluationTrack> Tracks;
    [FieldOffset(0x00A0)] public FGuid SequenceSignature;
    //[FieldOffset(0x00B0)] public FMovieSceneEvaluationTemplateSerialNumber TemplateSerialNumber;
    //[FieldOffset(0x00B8)] public FMovieSceneTemplateGenerationLedger TemplateLedger;
}

[StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
public unsafe struct UMovieSceneCompiledData
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0028)] public FMovieSceneEvaluationTemplate EvaluationTemplate;
    //[FieldOffset(0x0188)] public FMovieSceneSequenceHierarchy Hierarchy;
    //[FieldOffset(0x02A0)] public FMovieSceneEntityComponentField EntityComponentField;
    //[FieldOffset(0x0390)] public FMovieSceneEvaluationField TrackTemplateField;
    [FieldOffset(0x03C0)] public TArray<FFrameTime> DeterminismFences;
    [FieldOffset(0x03D0)] public FGuid CompiledSignature;
    [FieldOffset(0x03E0)] public FGuid CompilerVersion;
    //[FieldOffset(0x03F0)] public FMovieSceneSequenceCompilerMaskStruct AccumulatedMask;
    //[FieldOffset(0x03F1)] public FMovieSceneSequenceCompilerMaskStruct AllocatedMask;
    //[FieldOffset(0x03F2)] public EMovieSceneSequenceFlags AccumulatedFlags;
}

public enum EMovieSceneCompletionMode : byte
{
    KeepState = 0,
    RestoreState = 1,
    ProjectDefault = 2,
    //EMovieSceneCompletionMode_MAX = 3,
};

public enum EMovieSceneSequenceFlags : byte
{
    None = 0,
    Volatile = 1,
    BlockingEvaluation = 2,
    InheritedFlags = 1,
    //EMovieSceneSequenceFlags_MAX = 3,
};

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct UMovieSceneSequence
{
    [FieldOffset(0x0000)] public UMovieSceneSignedObject baseObj;
    [FieldOffset(0x0050)] public UMovieSceneCompiledData* CompiledData;
    [FieldOffset(0x0058)] public EMovieSceneCompletionMode DefaultCompletionMode;
    [FieldOffset(0x0059)] public bool bParentContextsAreSignificant;
    [FieldOffset(0x005A)] public bool bPlayableDirectly;
    [FieldOffset(0x005B)] public EMovieSceneSequenceFlags SequenceFlags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct FLevelSequenceObject
{
    [FieldOffset(0x0000)] public TLazyObjectPtr<UObject> ObjectOrOwner;
    [FieldOffset(0x0020)] public FString ComponentName;
    //[FieldOffset(0x0030)] public TWeakObjectPtr<UObject> CachedComponent;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C8)]
public unsafe struct ULevelSequence
{
    [FieldOffset(0x0000)] public UMovieSceneSequence baseObj;
    [FieldOffset(0x0068)] public UMovieScene* MovieScene;
    //[FieldOffset(0x0070)] public FLevelSequenceObjectReferenceMap ObjectReferences;
    //[FieldOffset(0x00C0)] public FLevelSequenceBindingReferences BindingReferences;
    [FieldOffset(0x0160)] public TMap<FString, FLevelSequenceObject> PossessedObjects;
    [FieldOffset(0x01B0)] public UClass* DirectorClass;
    [FieldOffset(0x01B8)] public TArray<IntPtr> AssetUserData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe struct FMovieSceneSpawnable
{
    //[FieldOffset(0x0000)] public FTransform SpawnTransform;
    [FieldOffset(0x0030)] public TArray<FName> Tags;
    [FieldOffset(0x0040)] public bool bContinuouslyRespawn;
    [FieldOffset(0x0041)] public bool bNetAddressableName;
    [FieldOffset(0x0042)] public bool bEvaluateTracksWhenNotSpawned;
    [FieldOffset(0x0044)] public FGuid Guid;
    [FieldOffset(0x0058)] public FString Name;
    [FieldOffset(0x0068)] public UObject* ObjectTemplate;
    [FieldOffset(0x0070)] public TArray<FGuid> ChildPossessables;
    //[FieldOffset(0x0080)] public ESpawnOwnership Ownership;
    [FieldOffset(0x0084)] public FName LevelName;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct FMovieScenePossessable
{
    [FieldOffset(0x0000)] public TArray<FName> Tags;
    [FieldOffset(0x0010)] public FGuid Guid;
    [FieldOffset(0x0020)] public FString Name;
    [FieldOffset(0x0030)] public UClass* PossessedObjectClass;
    [FieldOffset(0x0038)] public FGuid ParentGuid;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FMovieSceneBinding
{
    [FieldOffset(0x0000)] public FGuid ObjectGuid;
    [FieldOffset(0x0010)] public FString BindingName;
    [FieldOffset(0x0020)] public TArray<IntPtr> Tracks; // TArray<UMovieSceneTrack*>
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FMovieSceneObjectBindingID
{
    [FieldOffset(0x0000)] public FGuid Guid;
    [FieldOffset(0x0010)] public int SequenceID;
    [FieldOffset(0x0014)] public int ResolveParentIndex;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FMovieSceneObjectBindingIDs
{
    [FieldOffset(0x0000)] public TArray<FMovieSceneObjectBindingID> IDs;
}


[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe struct UMovieSceneSection
{
    [FieldOffset(0x0000)] public UMovieSceneSignedObject baseObj;
    //[FieldOffset(0x0050)] public FMovieSceneSectionEvalOptions EvalOptions;
    //[FieldOffset(0x0058)] public FMovieSceneEasingSettings Easing;
    [FieldOffset(0x0090)] public FMovieSceneFrameRange SectionRange;
    [FieldOffset(0x00A0)] public FFrameNumber PreRollFrames;
    [FieldOffset(0x00A4)] public FFrameNumber PostRollFrames;
    [FieldOffset(0x00A8)] public int RowIndex;
    [FieldOffset(0x00AC)] public int OverlapPriority;
    [FieldOffset(0x00B0)] public byte bIsActive;
    [FieldOffset(0x00B0)] public byte bIsLocked;
    [FieldOffset(0x00B4)] public float StartTime;
    [FieldOffset(0x00B8)] public float EndTime;
    [FieldOffset(0x00BC)] public float PrerollTime;
    [FieldOffset(0x00C0)] public float PostrollTime;
    [FieldOffset(0x00C4)] public byte bIsInfinite;
    [FieldOffset(0x00C8)] public bool bSupportsInfiniteRange;
    //[FieldOffset(0x00C9)] public FOptionalMovieSceneBlendType BlendType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct FMovieScenePropertyBinding
{
    [FieldOffset(0x0000)] public FName PropertyName;
    [FieldOffset(0x0008)] public FName PropertyPath;
    [FieldOffset(0x0010)] public bool bCanUseClassLookup;
}

public enum ERangeBoundTypes
{
    Exclusive = 0,
    Inclusive = 1,
    Open = 2,
    //ERangeBoundTypes_MAX = 3,
};

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FFrameNumberRangeBound
{
    [FieldOffset(0x0000)] public ERangeBoundTypes Type;
    [FieldOffset(0x0004)] public FFrameNumber Value;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FFrameNumberRange
{
    [FieldOffset(0x0000)] public FFrameNumberRangeBound LowerBound;
    [FieldOffset(0x0008)] public FFrameNumberRangeBound UpperBound;
}

[StructLayout(LayoutKind.Explicit, Size = 0x5)]
public unsafe struct FMovieSceneTrackEvalOptions
{
    [FieldOffset(0x0000)] public byte bCanEvaluateNearestSection;
    [FieldOffset(0x0001)] public byte bEvalNearestSection;
    [FieldOffset(0x0002)] public byte bEvaluateInPreroll;
    [FieldOffset(0x0003)] public byte bEvaluateInPostroll;
    [FieldOffset(0x0004)] public byte bEvaluateNearestSection;
}

public enum ESectionEvaluationFlags
{
    None = 0,
    PreRoll = 1,
    PostRoll = 2,
    //ESectionEvaluationFlags_MAX = 3,
};

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct FMovieSceneTrackEvaluationFieldEntry
{
    [FieldOffset(0x0000)] public UMovieSceneSection* Section;
    [FieldOffset(0x0008)] public FFrameNumberRange Range;
    [FieldOffset(0x0018)] public FFrameNumber ForcedTime;
    [FieldOffset(0x001C)] public ESectionEvaluationFlags flags;
    [FieldOffset(0x001E)] public short LegacySortOrder;
}

// MOVIE TRACKS

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe struct UMovieSceneTrack
{
    [FieldOffset(0x0000)] public UMovieSceneSignedObject baseObj;
    [FieldOffset(0x0050)] public FMovieSceneTrackEvalOptions EvalOptions;
    [FieldOffset(0x0055)] public bool bIsEvalDisabled;
    [FieldOffset(0x0058)] public TArray<int> RowsDisabled;
    [FieldOffset(0x006C)] public FGuid EvaluationFieldGuid;
    [FieldOffset(0x0080)] public TArray<FMovieSceneTrackEvaluationFieldEntry> EvaluationFields;
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe struct UMovieSceneNameableTrack
{
    [FieldOffset(0x0000)] public UMovieSceneTrack baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe struct UMovieScenePropertyTrack
{
    [FieldOffset(0x0000)] public UMovieSceneNameableTrack baseObj;
    [FieldOffset(0x0090)] public UMovieSceneSection* SectionToKey;
    [FieldOffset(0x0098)] public FMovieScenePropertyBinding PropertyBinding;
    [FieldOffset(0x00B0)] public TArray<IntPtr> Sections; // UMovieSceneSection*
}

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe struct UMovieSceneFloatTrack
{
    [FieldOffset(0x0000)] public UMovieScenePropertyTrack baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FMovieSceneFrameRange
{
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct FMovieSceneMarkedFrame
{
    [FieldOffset(0x0000)] public FFrameNumber FrameNumber;
    [FieldOffset(0x0008)] public FString Label;
    [FieldOffset(0x0018)] public bool bIsDeterminismFence;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FMovieSceneChannel
{
}

public enum EUpdateClockSource : byte
{
    Tick = 0,
    Platform = 1,
    Audio = 2,
    RelativeTimecode = 3,
    Timecode = 4,
    Custom = 5,
    //EUpdateClockSource_MAX = 6,
};

public enum EMovieSceneEvaluationType : byte
{
    FrameLocked = 0,
    WithSubFrames = 1,
    //EMovieSceneEvaluationType_MAX = 2,
};

[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe struct UMovieScene
{
    [FieldOffset(0x0000)] public UMovieSceneSignedObject baseObj;
    [FieldOffset(0x0050)] public TArray<FMovieSceneSpawnable> Spawnables;
    [FieldOffset(0x0060)] public TArray<FMovieScenePossessable> Possessables;
    [FieldOffset(0x0070)] public TArray<FMovieSceneBinding> ObjectBindings;
    [FieldOffset(0x0080)] public TMap<FName, FMovieSceneObjectBindingIDs> BindingGroups;
    [FieldOffset(0x00D0)] public TArray<IntPtr> MasterTracks;
    [FieldOffset(0x00E0)] public UMovieSceneTrack* CameraCutTrack;
    [FieldOffset(0x00E8)] public FMovieSceneFrameRange SelectionRange;
    [FieldOffset(0x00F8)] public FMovieSceneFrameRange PlaybackRange;
    [FieldOffset(0x0108)] public FFrameRate TickResolution;
    [FieldOffset(0x0110)] public FFrameRate DisplayRate;
    [FieldOffset(0x0118)] public EMovieSceneEvaluationType EvaluationType;
    [FieldOffset(0x0119)] public EUpdateClockSource ClockSource;
    //[FieldOffset(0x0120)] public FSoftObjectPath CustomClockSourcePath;
    [FieldOffset(0x0138)] public TArray<FMovieSceneMarkedFrame> MarkedFrames;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)] // from CoreUObject
public unsafe struct FFrameTime
{
    [FieldOffset(0x0000)] public FFrameNumber FrameNumber;
    [FieldOffset(0x0004)] public float SubFrame;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FFrameRate
{
    [FieldOffset(0x0000)] public int Numerator;
    [FieldOffset(0x0004)] public int Denominator;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct FMovieSceneSequencePlaybackSettings
{
    [FieldOffset(0x0000)] public byte bAutoPlay;
    [FieldOffset(0x0004)] public int LoopCount;
    [FieldOffset(0x0008)] public float PlayRate;
    [FieldOffset(0x000C)] public float StartTime;
    [FieldOffset(0x0010)] public byte bRandomStartTime;
    [FieldOffset(0x0010)] public byte bRestoreState;
    [FieldOffset(0x0010)] public byte bDisableMovementInput;
    [FieldOffset(0x0010)] public byte bDisableLookAtInput;
    [FieldOffset(0x0010)] public byte bHidePlayer;
    [FieldOffset(0x0010)] public byte bHideHud;
    [FieldOffset(0x0010)] public byte bDisableCameraCuts;
    [FieldOffset(0x0010)] public byte bPauseAtEnd;
}

[StructLayout(LayoutKind.Explicit, Size = 0x4E8)]
public unsafe struct UMovieSceneSequencePlayer
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x02B0)] public EMovieScenePlayerStatus Status;
    [FieldOffset(0x02B4)] public byte bReversePlayback;
    [FieldOffset(0x02B8)] public UMovieSceneSequence* Sequence; // or ULevelSequence if inside ULevelSequencePlayer*
    [FieldOffset(0x02C0)] public FFrameNumber StartTime;
    [FieldOffset(0x02C4)] public int DurationFrames;
    [FieldOffset(0x02C8)] public float DurationSubFrames;
    [FieldOffset(0x02CC)] public int CurrentNumLoops;
    [FieldOffset(0x02D0)] public FMovieSceneSequencePlaybackSettings PlaybackSettings;
    //[FieldOffset(0x02E8)] public FMovieSceneRootEvaluationTemplateInstance RootTemplateInstance;
    [FieldOffset(0x3d0)] public FFrameRate FrameRate;
    [FieldOffset(0x3e4)] public FFrameTime FrameTime;
    //[FieldOffset(0x0438)] public FMovieSceneSequenceReplProperties NetSyncProps;
    //[FieldOffset(0x0448)] public TScriptInterface<IMovieScenePlaybackClient> PlaybackClient;
    //[FieldOffset(0x0458)] public UMovieSceneSequenceTickManager* TickManager;
}

[StructLayout(LayoutKind.Explicit, Size = 0x600)]
public unsafe struct ULevelSequencePlayer
{
    [FieldOffset(0x0000)] public UMovieSceneSequencePlayer baseObj;

    public ULevelSequence* GetLevelSequence() => (ULevelSequence*)baseObj.Sequence;
}

[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe struct ALevelSequenceActor
{
    [FieldOffset(0x0000)] public AActor baseObj;
    [FieldOffset(0x0238)] public FMovieSceneSequencePlaybackSettings PlaybackSettings;
    [FieldOffset(0x0250)] public ULevelSequencePlayer* SequencePlayer;
    //[FieldOffset(0x0258)] public FSoftObjectPath LevelSequence;
    //[FieldOffset(0x0270)] public FLevelSequenceCameraSettings CameraSettings;
    //[FieldOffset(0x0278)] public ULevelSequenceBurnInOptions* BurnInOptions;
    //[FieldOffset(0x0280)] public UMovieSceneBindingOverrides* BindingOverrides;
    [FieldOffset(0x0288)] public byte bAutoPlay;
    [FieldOffset(0x0288)] public byte bOverrideInstanceData;
    [FieldOffset(0x0288)] public byte bReplicatePlayback;
    [FieldOffset(0x0290)] public UObject* DefaultInstanceData;
    //[FieldOffset(0x0298)] public ULevelSequenceBurnIn* BurnInInstance;
    [FieldOffset(0x02A0)] public bool bShowBurnin;
}

[StructLayout(LayoutKind.Explicit, Size = 0x298)]
public unsafe struct ULevel
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x00B8)] public UWorld* OwningWorld;
    //[FieldOffset(0x00C0)] public UModel* Model;
    [FieldOffset(0x00C8)] public TArray<IntPtr> ModelComponents;
    //[FieldOffset(0x00D8)] public ULevelActorContainer* ActorCluster;
    [FieldOffset(0x00E0)] public int NumTextureStreamingUnbuiltComponents;
    [FieldOffset(0x00E4)] public int NumTextureStreamingDirtyResources;
    //[FieldOffset(0x00E8)] public ALevelScriptActor* LevelScriptActor;
    //[FieldOffset(0x00F0)] public ANavigationObjectBase* NavListStart;
    //[FieldOffset(0x00F8)] public ANavigationObjectBase* NavListEnd;
    [FieldOffset(0x0100)] public TArray<IntPtr> NavDataChunks;
    [FieldOffset(0x0110)] public float LightmapTotalSize;
    [FieldOffset(0x0114)] public float ShadowmapTotalSize;
    [FieldOffset(0x0118)] public TArray<FVector> StaticNavigableGeometry;
    [FieldOffset(0x0128)] public TArray<FGuid> StreamingTextureGuids;
    [FieldOffset(0x01D0)] public FGuid LevelBuildDataId;
    //[FieldOffset(0x01E0)] public UMapBuildDataRegistry* MapBuildData;
    //[FieldOffset(0x01E8)] public FIntVector LightBuildLevelOffset;
    [FieldOffset(0x01F4)] public byte bIsLightingScenario;
    [FieldOffset(0x01F4)] public byte bTextureStreamingRotationChanged;
    [FieldOffset(0x01F4)] public byte bStaticComponentsRegisteredInStreamingManager;
    [FieldOffset(0x01F4)] public byte bIsVisible;
    //[FieldOffset(0x0258)] public AWorldSettings* WorldSettings;
    [FieldOffset(0x0268)] public TArray<IntPtr> AssetUserData;
    //[FieldOffset(0x0288)] public TArray<FReplicatedStaticActorDestructionInfo> DestroyedReplicatedStaticActors;
}

[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe struct UAnimSequenceBase
{
    //[FieldOffset(0x0000)] public UAnimationAsset baseObj;
    //[FieldOffset(0x0080)] public TArray<FAnimNotifyEvent> Notifies;
    //[FieldOffset(0x0090)] public float SequenceLength;
    //[FieldOffset(0x0094)] public float RateScale;
    //[FieldOffset(0x0098)] public FRawCurveTracks RawCurveData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct UDataAsset
{
    [FieldOffset(0x0)] public UObject baseObj;
    [FieldOffset(0x28)] public UDataAsset* nativeClass;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct UOnlineSession
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0xc8)]
public unsafe struct FSubsystemCollectionBase
{
    [FieldOffset(0x10)] public TMap<nint, nint> SubsystemMap; // TMap<UClass*, USubsystem*>
    [FieldOffset(0x60)] public TMap<nint, nint> SubsystemArrayMap; // TMap<UClass*, USubsystem*>
}

[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe struct UGameInstance
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0038)] public TArray<nint> LocalPlayers;
    [FieldOffset(0x0048)] public UOnlineSession* OnlineSession;
    [FieldOffset(0x0050)] public TArray<nint> ReferencedObjects;
    [FieldOffset(0xe0)] public FSubsystemCollectionBase Subsystems;
}

public unsafe struct HashablePointer : IMapHashable, IEquatable<HashablePointer>
{
    public nint Ptr;
    public HashablePointer(nint ptr) { Ptr = ptr; }
    public uint GetTypeHash() // FUN_140904980
    {
        uint iVar4 = (uint)(Ptr >> 4);
        uint uVar3 = 0x9e3779b9U - iVar4 ^ iVar4 << 8;
        uint uVar1 = (uint)-(uVar3 + iVar4) ^ uVar3 >> 0xd;
        uint uVar5 = (iVar4 - uVar3) - uVar1 ^ uVar1 >> 0xc;
        uVar3 = (uVar3 - uVar5) - uVar1 ^ uVar5 << 0x10;
        uVar1 = (uVar1 - uVar3) - uVar5 ^ uVar3 >> 5;
        uVar5 = (uVar5 - uVar3) - uVar1 ^ uVar1 >> 3;
        uVar3 = (uVar3 - uVar5) - uVar1 ^ uVar5 << 10;
        uint ret = ((uVar1 - uVar3) - uVar5) ^ (uVar3 >> 0xf);
        return ret;
    }
    public bool Equals(HashablePointer other) => Ptr == other.Ptr;
}
public unsafe struct HashableInt : IMapHashable, IEquatable<HashableInt>
{
    public int Value;
    public HashableInt(int value) { Value = value; }
    public uint GetTypeHash() => (uint)Value;
    public bool Equals(HashableInt other) => other.Value == Value;
    public override string ToString() => Value.ToString();
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct HashableInt8 : IMapHashable, IEquatable<HashableInt8>
{
    [FieldOffset(0x0)] public int Value;
    public HashableInt8(int value) { Value = value; }
    public uint GetTypeHash() => (uint)Value;
    public bool Equals(HashableInt8 other) => other.Value == Value;
    public override string ToString() => Value.ToString();
}
public static class TypeExtensions
{
    public static HashablePointer AsHashable(this nint ptr) => new HashablePointer(ptr);
    public static HashableInt AsHashable(this int val) => new HashableInt(val);
    public static uint HashCombine(uint a, uint b)
    { // FUN_141cbc830
        uint uVar1 = a - b ^ b >> 0xd;
        uint uVar3 = (uint)(-0x61c88647 - uVar1) - b ^ uVar1 << 8;
        uint uVar2 = (b - uVar3) - uVar1 ^ uVar3 >> 0xd;
        uVar1 = (uVar1 - uVar3) - uVar2 ^ uVar2 >> 0xc;
        uVar3 = (uVar3 - uVar1) - uVar2 ^ uVar1 << 0x10;
        uVar2 = (uVar2 - uVar3) - uVar1 ^ uVar3 >> 5;
        uVar1 = (uVar1 - uVar3) - uVar2 ^ uVar2 >> 3;
        uVar3 = (uVar3 - uVar1) - uVar2 ^ uVar1 << 10;
        return (uVar2 - uVar3) - uVar1 ^ uVar3 >> 0xf;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FActorSpawnParameters
{
    [FieldOffset(0x0)] public FName name;
    [FieldOffset(0x8)] public AActor* template;
    [FieldOffset(0x10)] public AActor* owner;
    [FieldOffset(0x18)] public AActor* /* APawn* */ instigator;
    [FieldOffset(0x20)] public ULevel* overrideLevel;
    [FieldOffset(0x2c)] public uint objectFlags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe struct FUObjectHashTables
{
    // 0x0: Critical Section
    [FieldOffset(0x28)] public TMap<int, nint> Hashes; // TMap<int, FHashBucket>
    [FieldOffset(0x78)] public TMap<int, nint> HashesOuter; // TMap<int, FHashBucket>
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FTransform
{
    [FieldOffset(0x0000)] public FVector4 Rotation;
    [FieldOffset(0x0010)] public FVector Translation;
    [FieldOffset(0x0020)] public FVector Scale3D;

    public FTransform()
    {
        Rotation = new FVector4(0, 0, 0, 1);
        Translation = new FVector(0, 0, 0);
        Scale3D = new FVector(1, 1, 1);
    }
    public FTransform(FVector4 rotation, FVector translation, FVector scale)
    {
        Rotation = rotation;
        Translation = translation;
        Scale3D = scale;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct USubsystem
{
    [FieldOffset(0x0000)] public UObject baseObj;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct UGameInstanceSubsystem
{
    [FieldOffset(0x0000)] public USubsystem baseObj;
}

public enum EComponentCreationMethod : int
{
    Native = 0,
    SimpleConstructionScript = 1,
    UserConstructionScript = 2,
    Instance = 3,
    //EComponentCreationMethod_MAX = 4,
}

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct UActorComponent
{
    [FieldOffset(0x0000)] public UObject baseObj;
    //[FieldOffset(0x0030)] public FActorComponentTickFunction PrimaryComponentTick;
    [FieldOffset(0x0060)] public TArray<FName> ComponentTags;
    [FieldOffset(0x0070)] public TArray<IntPtr> AssetUserData;
    [FieldOffset(0x0084)] public int UCSSerializationIndex;
    [FieldOffset(0x0088)] public byte bNetAddressable;
    [FieldOffset(0x0088)] public byte bReplicates;
    [FieldOffset(0x0089)] public byte bAutoActivate;
    [FieldOffset(0x008A)] public byte bIsActive;
    [FieldOffset(0x008A)] public byte bEditableWhenInherited;
    [FieldOffset(0x008A)] public byte bCanEverAffectNavigation;
    [FieldOffset(0x008A)] public byte bIsEditorOnly;
    [FieldOffset(0x008C)] public EComponentCreationMethod CreationMethod;
    //[FieldOffset(0x0090)] public TArray<FSimpleMemberReference> UCSModifiedProperties;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FTableRowBase
{
}

public enum EBoneTranslationRetargetingMode
{
    Animation = 0,
    Skeleton = 1,
    AnimationScaled = 2,
    AnimationRelative = 3,
    OrientAndScale = 4,
};

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FBoneNode
{
    [FieldOffset(0x0000)] public FName Name;
    [FieldOffset(0x0008)] public int ParentIndex;
    [FieldOffset(0x000C)] public EBoneTranslationRetargetingMode TranslationRetargetingMode;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FVirtualBone
{
    [FieldOffset(0x0000)] public FName SourceBoneName;
    [FieldOffset(0x0008)] public FName TargetBoneName;
    [FieldOffset(0x0010)] public FName VirtualBoneName;
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct FSmartNameContainer
{
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct FAnimSlotGroup
{
    [FieldOffset(0x0000)] public FName GroupName;
    [FieldOffset(0x0008)] public TArray<FName> SlotNames;
}

[StructLayout(LayoutKind.Explicit, Size = 0x390)]
public unsafe struct USkeleton
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0038)] public TArray<FBoneNode> BoneTree;
    [FieldOffset(0x0048)] public TArray<FTransform> RefLocalPoses;
    [FieldOffset(0x0170)] public FGuid VirtualBoneGuid;
    [FieldOffset(0x0180)] public TArray<FVirtualBone> VirtualBones;
    [FieldOffset(0x0190)] public TArray<IntPtr> Sockets;
    [FieldOffset(0x01F0)] public FSmartNameContainer SmartNames;
    [FieldOffset(0x0270)] public TArray<IntPtr> BlendProfiles;
    [FieldOffset(0x0280)] public TArray<FAnimSlotGroup> SlotGroups;
    [FieldOffset(0x0380)] public TArray<IntPtr> AssetUserData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct UStreamableRenderAsset
{
    [FieldOffset(0x0000)] public UObject baseObj;
    [FieldOffset(0x0040)] public double ForceMipLevelsToBeResidentTimestamp;
    [FieldOffset(0x0048)] public int NumCinematicMipLevels;
    [FieldOffset(0x004C)] public int StreamingIndex;
    [FieldOffset(0x0050)] public int CachedCombinedLODBias;
    [FieldOffset(0x0054)] public byte NeverStream;
    [FieldOffset(0x0054)] public byte bGlobalForceMipLevelsToBeResident;
    [FieldOffset(0x0054)] public byte bHasStreamingUpdatePending;
    [FieldOffset(0x0054)] public byte bForceMiplevelsToBeResident;
    [FieldOffset(0x0054)] public byte bIgnoreStreamingMipBias;
    [FieldOffset(0x0054)] public byte bUseCinematicMipLevels;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe struct FBoxSphereBounds
{
    [FieldOffset(0x0000)] public FVector Origin;
    [FieldOffset(0x000C)] public FVector BoxExtent;
    [FieldOffset(0x0018)] public float SphereRadius;
}

[StructLayout(LayoutKind.Explicit, Size = 0x3A0)]
public unsafe struct USkeletalMesh
{
    [FieldOffset(0x0000)] public UStreamableRenderAsset baseObj;
    [FieldOffset(0x0080)] public USkeleton* Skeleton;
    [FieldOffset(0x0088)] public FBoxSphereBounds ImportedBounds;
    [FieldOffset(0x00A4)] public FBoxSphereBounds ExtendedBounds;
    [FieldOffset(0x00C0)] public FVector PositiveBoundsExtension;
    [FieldOffset(0x00CC)] public FVector NegativeBoundsExtension;
    //[FieldOffset(0x00D8)] public TArray<FSkeletalMaterial> Materials;
    //[FieldOffset(0x00E8)] public TArray<FBoneMirrorInfo> SkelMirrorTable;
    //[FieldOffset(0x00F8)] public TArray<FSkeletalMeshLODInfo> LODInfo;
    //[FieldOffset(0x0158)] public FPerPlatformInt MinLOD;
    //[FieldOffset(0x015C)] public FPerPlatformBool DisableBelowMinLodStripping;
    //[FieldOffset(0x015D)] public EAxis SkelMirrorAxis;
    //[FieldOffset(0x015E)] public EAxis SkelMirrorFlipAxis;
    [FieldOffset(0x015F)] public byte bUseFullPrecisionUVs;
    [FieldOffset(0x015F)] public byte bUseHighPrecisionTangentBasis;
    [FieldOffset(0x015F)] public byte bHasBeenSimplified;
    [FieldOffset(0x015F)] public byte bHasVertexColors;
    [FieldOffset(0x015F)] public byte bEnablePerPolyCollision;
    //[FieldOffset(0x0160)] public UBodySetup* BodySetup;
    //[FieldOffset(0x0168)] public UPhysicsAsset* PhysicsAsset;
    //[FieldOffset(0x0170)] public UPhysicsAsset* ShadowPhysicsAsset;
    [FieldOffset(0x0178)] public TArray<IntPtr> NodeMappingData;
    [FieldOffset(0x0188)] public byte bSupportRayTracing;
    [FieldOffset(0x0190)] public TArray<IntPtr> MorphTargets;
    //[FieldOffset(0x0318)] public TSubclassOf<UAnimInstance> PostProcessAnimBlueprint;
    [FieldOffset(0x0320)] public TArray<IntPtr> MeshClothingAssets;
    //[FieldOffset(0x0330)] public FSkeletalMeshSamplingInfo SamplingInfo;
    [FieldOffset(0x0360)] public TArray<IntPtr> AssetUserData;
    [FieldOffset(0x0370)] public TArray<IntPtr> Sockets;
    //[FieldOffset(0x0390)] public TArray<FSkinWeightProfileInfo> SkinWeightProfiles;
}