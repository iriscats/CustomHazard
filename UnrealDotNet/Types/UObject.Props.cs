namespace UnrealDotNet.Types;

public partial class UObject
{
    private string? _className;

    public string ClassName
    {
        get { return _className ??= GetFullPath(); }
    }


    private nint _classAddress = nint.MaxValue;

    public nint ClassAddress
    {
        get
        {
            if (_classAddress != nint.MaxValue)
                return _classAddress;

            if (AddrToClass.TryGetValue(Address, out var value))
            {
                _classAddress = value;
                return _classAddress;
            }

            _classAddress = _unrealEngine.MemoryReadPtr(Address + ClassOffset);
            AddrToClass[Address] = _classAddress;
            return _classAddress;
        }
        set => _classAddress = value;
    }


    private nint _value = nint.MaxValue;

    public nint Value
    {
        get
        {
            if (_value != nint.MaxValue)
                return _value;

            _value = _unrealEngine.MemoryReadPtr(Address);
            return _value;
        }
        set
        {
            _value = value;
            _unrealEngine.WriteProcessMemory(Address, value);
        }
    }

    public nint Address { get; set; } = nint.MaxValue;

    public nint SubStructAddress { get; set; } = nint.MaxValue;


    private int _num = int.MaxValue;

    public int Num
    {
        get
        {
            if (_num != int.MaxValue)
                return _num;

            _num = _unrealEngine.MemoryReadInt(Address + 8);
            //TODO: 
            if (_num > 0x10000)
                _num = 0x10000;

            return _num;
        }
    }


    private byte[] _arrayCache = [];

    public byte[] ArrayCache
    {
        get
        {
            if (_arrayCache.Length != 0)
                return _arrayCache;

            _arrayCache = _unrealEngine.MemoryReadBytes(Value, Num * 8);
            return _arrayCache;
        }
    }


    private nint _vTableFunc = nint.MaxValue;

    public nint VTableFunc
    {
        get
        {
            if (_vTableFunc != nint.MaxValue)
                return _vTableFunc;

            _vTableFunc = _unrealEngine.MemoryReadPtr(Address) + VTableFuncNum * 8;
            _vTableFunc = _unrealEngine.MemoryReadPtr(_vTableFunc);
            return _vTableFunc;
        }
    }


    private ulong _boolMask;

    public bool Flag
    {
        get
        {
            var val = _unrealEngine.MemoryReadLong(Address);
            return (val & _boolMask) == _boolMask;
        }
        set
        {
            var val = _unrealEngine.MemoryReadLong(Address);
            if (value)
                val |= _boolMask;
            else
                val &= ~_boolMask;

            _unrealEngine.WriteProcessMemory(Address, val);
        }
    }
}