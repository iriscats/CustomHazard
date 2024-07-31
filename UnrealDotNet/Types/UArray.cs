using System.Runtime.InteropServices;

namespace UnrealDotNet.Types;

public class UArray<T> : UObject
{
    private readonly UnrealEngine _unrealEngine = UnrealEngine.GetInstance();

    public UArray(UObject obj)
    {
        Address = obj.Address;
        _classAddr = obj.ClassAddr;
        _substructAddr = obj._substructAddr;
    }

    public UArray(nint addr) : base(addr)
    {
    }

    public UArray(nint addr, nint classAddr) : base(addr)
    {
        _classAddr = classAddr;
    }


    private int _num = int.MaxValue;

    public new int Num
    {
        get
        {
            if (_num != int.MaxValue)
                return _num;

            _num = _unrealEngine.ReadProcessMemory<int>(Address + 8);
            if (_num > 0x20000)
                _num = 0x20000;

            return _num;
        }
    }

    private Byte[] _arrayCache = [];

    public new Byte[] ArrayCache
    {
        get
        {
            if (_arrayCache.Length != 0) return _arrayCache;
            _arrayCache = _unrealEngine.MemoryReadBytes(Value, Num * 8);
            return _arrayCache;
        }
    }

    public new T this[int index]
    {
        get
        {
            if (index >= Num) return (T)Activator.CreateInstance(typeof(T), (nint)0);
            return (T)Activator.CreateInstance(typeof(T), (nint)BitConverter.ToUInt64(ArrayCache, index * 8));
        }
    }

    public T this[int index, bool t]
    {
        get
        {
            if (typeof(T).IsAssignableTo(typeof(UObject)))
            {
                var subStructSize = 0x28; // (int)typeof(T).GetField("size").GetValue(null);
                var obj = (T)Activator.CreateInstance(typeof(T), (nint)Value + index * subStructSize);
                var q = obj as UObject;
                q._classAddr = _substructAddr;
                obj = (T)(object)q;
                return obj;
            }
            else
            {
                var obj = (T)Activator.CreateInstance(typeof(T), (nint)Value + index * Marshal.SizeOf(typeof(T)))!;
                return obj;
            }
        }
    }
}