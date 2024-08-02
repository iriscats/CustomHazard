using System.Runtime.InteropServices;

namespace UnrealDotNet.Types;

public class UArray<T> : UObject
{
    public UArray(UObject obj)
    {
        Address = obj.Address;
        ClassAddress = obj.ClassAddress;
        SubStructAddress = obj.SubStructAddress;
    }

    public UArray(nint addr) : base(addr)
    {
    }

    public UArray(nint addr, nint classAddress) : base(addr)
    {
        ClassAddress = classAddress;
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
                q.ClassAddress = SubStructAddress;
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