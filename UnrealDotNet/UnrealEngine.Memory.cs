using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace UnrealDotNet;

public unsafe partial class UnrealEngine
{
    private IntPtr _procHandle = IntPtr.Zero;
    public Process? Process { get; private set; }
    public nint BaseAddress => Process!.MainModule!.BaseAddress;
    private const int MaxReadSize = 0x64000;

    public void OpenUnrealProcess(Process proc)
    {
        Process = proc;
        if (Process == null)
            return;

        _procHandle = OpenProcess(0x38, 1, Process.Id);
    }

    public void OpenUnrealProcess(string name)
    {
        var process = Process.GetProcessesByName(name).FirstOrDefault();
        if (process == null)
            return;

        OpenUnrealProcess(process);
    }

    public byte[] MemoryReadBytes(nint addr, int length)
    {
        var buffer = new byte[length];
        for (var i = 0; i < length / (float)MaxReadSize; i++)
        {
            var blockSize = (i == (length / MaxReadSize)) ? length % MaxReadSize : MaxReadSize;
            var buf = new byte[blockSize];
            ReadProcessMemory2(_procHandle, addr + i * MaxReadSize, buf, blockSize, out _);
            Array.Copy(buf, 0, buffer, i * MaxReadSize, blockSize);
        }

        return buffer;
    }

    public string MemoryReadString(nint addr, int length)
    {
        var stringLength = length;
        var bytes = new List<byte>();
        var isUtf16 = false;
        for (var i = 0; i < 64; i++)
        {
            var letters8 = MemoryReadPtr(addr + i * 8);
            var tempBytes = BitConverter.GetBytes(letters8);
            for (int j = 0; j < 8 && stringLength > 0; j++)
            {
                if (tempBytes[j] == 0 && j == 1 && bytes.Count == 1)
                    isUtf16 = true;
                if (isUtf16 && j % 2 == 1)
                    continue;
                if (tempBytes[j] == 0)
                    return Encoding.UTF8.GetString(bytes.ToArray());
                if ((tempBytes[j] < 32 || tempBytes[j] > 126) && tempBytes[j] != '\n')
                    return "null";
                bytes.Add(tempBytes[j]);
                stringLength--;
            }
        }

        return Encoding.UTF8.GetString(bytes.ToArray());
    }

    public byte MemoryReadByte(nint address)
    {
        var buffer = new byte[4];
        ReadProcessMemory2(_procHandle, address, buffer, 4, out int _);
        var structPtr = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var obj = Marshal.PtrToStructure(structPtr.AddrOfPinnedObject(), typeof(int));
        structPtr.Free();
        return (byte)obj!;
    }

    public int MemoryReadInt(nint address)
    {
        var buffer = new byte[4];
        ReadProcessMemory2(_procHandle, address, buffer, 4, out int _);
        var structPtr = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var obj = Marshal.PtrToStructure(structPtr.AddrOfPinnedObject(), typeof(int));
        structPtr.Free();
        return (int)obj!;
    }

    public nint MemoryReadPtr(nint address)
    {
        var buffer = new byte[8];
        ReadProcessMemory2(_procHandle, address, buffer, 8, out int _);
        var structPtr = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var obj = Marshal.PtrToStructure(structPtr.AddrOfPinnedObject(), typeof(nint));
        structPtr.Free();
        return (nint)obj!;
    }

    public ulong MemoryReadLong(nint address)
    {
        var buffer = new byte[8];
        ReadProcessMemory2(_procHandle, address, buffer, 8, out int _);
        var structPtr = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var obj = Marshal.PtrToStructure(structPtr.AddrOfPinnedObject(), typeof(ulong));
        structPtr.Free();
        return (ulong)obj!;
    }

    public ushort MemoryReadShort(nint address)
    {
        var buffer = new byte[2];
        ReadProcessMemory2(_procHandle, address, buffer, 2, out int _);
        var structPtr = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var obj = Marshal.PtrToStructure(structPtr.AddrOfPinnedObject(), typeof(ushort));
        structPtr.Free();
        return (ushort)obj!;
    }

    public void WriteProcessMemory(nint addr, byte[] buffer)
    {
        WriteProcessMemory(_procHandle, addr, buffer, buffer.Length, out int bytesRead);
    }

    public void WriteProcessMemory<T>(nint addr, T value)
    {
        var objSize = Marshal.SizeOf(value);
        var objBytes = new byte[objSize];
        var objPtr = Marshal.AllocHGlobal(objSize);
        Marshal.StructureToPtr(value, objPtr, true);
        Marshal.Copy(objPtr, objBytes, 0, objSize);
        Marshal.FreeHGlobal(objPtr);
        WriteProcessMemory(_procHandle, addr, objBytes, objBytes.Length, out int bytesRead);
    }

    public nint Execute(nint fPtr, nint a1, nint a2, nint a3, nint a4, params nint[] args)
    {
        var retValPtr = VirtualAllocEx(_procHandle, IntPtr.Zero, 0x40, 0x1000, 0x40);
        WriteProcessMemory(retValPtr, BitConverter.GetBytes((nint)0xcafeb00));

        var asm = new List<byte>();
        asm.AddRange(new byte[] { 0x48, 0x83, 0xEC }); // sub rsp
        asm.Add(104);

        asm.AddRange(new byte[] { 0x48, 0xB9 }); // mov rcx
        asm.AddRange(BitConverter.GetBytes(a1));

        asm.AddRange(new byte[] { 0x48, 0xBA }); // mov rdx
        asm.AddRange(BitConverter.GetBytes(a2));

        asm.AddRange(new byte[] { 0x49, 0xB8 }); // mov r8
        asm.AddRange(BitConverter.GetBytes(a3));

        asm.AddRange(new byte[] { 0x49, 0xB9 }); // mov r9
        asm.AddRange(BitConverter.GetBytes(a4));

        var offset = 0u;
        foreach (var obj in args)
        {
            asm.AddRange(new byte[] { 0x48, 0xB8 }); // mov rax
            asm.AddRange(BitConverter.GetBytes(obj));
            asm.AddRange(new byte[] { 0x48, 0x89, 0x44, 0x24, (byte)(0x28 + 8 * offset++) }); // mov rax to stack
        }

        asm.AddRange(new byte[] { 0x48, 0xB8 }); // mov rax
        asm.AddRange(BitConverter.GetBytes(fPtr));

        asm.AddRange(new byte[] { 0xFF, 0xD0 }); // call rax
        asm.AddRange(new byte[] { 0x48, 0x83, 0xC4 }); // add rsp
        asm.Add(104);

        asm.AddRange(new byte[] { 0x48, 0xA3 }); // mov rax to
        asm.AddRange(BitConverter.GetBytes((ulong)retValPtr));
        asm.Add(0xC3); // ret
        var codePtr = VirtualAllocEx(_procHandle, IntPtr.Zero, asm.Count, 0x1000, 0x40);
        WriteProcessMemory(_procHandle, codePtr, asm.ToArray(), asm.Count, out int bytesRead);

        var thread = CreateRemoteThread(_procHandle, IntPtr.Zero, 0, codePtr, IntPtr.Zero, 0, IntPtr.Zero);
        WaitForSingleObject(thread, 10000);
        var returnValue = MemoryReadPtr(retValPtr);
        VirtualFreeEx(_procHandle, codePtr, 0, 0x8000);
        VirtualFreeEx(_procHandle, retValPtr, 0, 0x8000);
        CloseHandle(thread);
        return returnValue;
    }

    public T ExecuteUFunction<T>(nint vtableAddr, nint objAddr, nint funcAddr, params object[] args)
    {
        //var retValPtr = VirtualAllocEx(procHandle, IntPtr.Zero, 0x40, 0x1000, 0x40);
        //WriteProcessMemory((UInt64)retValPtr, BitConverter.GetBytes((UInt64)0xdeadbeefcafef00d));
        var dummyParms = VirtualAllocEx(_procHandle, IntPtr.Zero, 0x100, 0x1000, 0x40);

        WriteProcessMemory(dummyParms, BitConverter.GetBytes(0xffffffffffffffff));
        var offset = 0;
        foreach (var obj in args)
        {
            WriteProcessMemory(dummyParms + offset, obj);
            offset += Marshal.SizeOf(obj);
        }

        var asm = new List<byte>();
        asm.AddRange(new byte[] { 0x48, 0x83, 0xEC }); // sub rsp
        asm.Add(40);
        asm.AddRange(new byte[] { 0x48, 0xB8 }); // mov rax
        asm.AddRange(BitConverter.GetBytes((ulong)vtableAddr));

        asm.AddRange(new byte[] { 0x48, 0xB9 }); // mov rcx
        asm.AddRange(BitConverter.GetBytes((ulong)objAddr));

        asm.AddRange(new byte[] { 0x48, 0xBA }); // mov rdx
        asm.AddRange(BitConverter.GetBytes((ulong)funcAddr));

        asm.AddRange(new byte[] { 0x49, 0xB8 }); // mov r8
        asm.AddRange(BitConverter.GetBytes((ulong)dummyParms));

        asm.AddRange(new byte[] { 0xFF, 0xD0 }); // call rax
        asm.AddRange(new byte[] { 0x48, 0x83, 0xC4 }); // add rsp
        asm.Add(40);
        //asm.AddRange(new byte[] { 0x48, 0xA3 }); // mov rax to
        //asm.AddRange(BitConverter.GetBytes((UInt64)retValPtr));
        asm.Add(0xC3); // ret
        var codePtr = VirtualAllocEx(_procHandle, IntPtr.Zero, asm.Count, 0x1000, 0x40);
        WriteProcessMemory(_procHandle, codePtr, asm.ToArray(), asm.Count, out int bytesRead);

        IntPtr thread = CreateRemoteThread(_procHandle, IntPtr.Zero, 0, codePtr, IntPtr.Zero, 0, IntPtr.Zero);
        WaitForSingleObject(thread, 10000);

        var returnValue = MemoryReadPtr(dummyParms);
        VirtualFreeEx(_procHandle, dummyParms, 0, 0x8000);
        VirtualFreeEx(_procHandle, codePtr, 0, 0x8000);
        //VirtualFreeEx(procHandle, retValPtr, 0, 0x8000);
        CloseHandle(thread);

        return (T)Marshal.PtrToStructure(returnValue, typeof(T))!;
    }

    public static List<nint> Scan(byte[] buf, int[] pattern)
    {
        var addresses = new List<nint>();

        for (int i = 0; i <= buf.Length - pattern.Length; i++)
        {
            var found = true;
            for (int j = 0; j < pattern.Length; j++)
            {
                if (pattern[j] == -1)
                    continue;
                if (buf[i + j] != pattern[j])
                {
                    found = false;
                    break;
                }
            }

            if (found)
                addresses.Add(i);
        }

        return addresses;
    }


    public nint FindStringRef(string str)
    {
        var stringAddr = FindPattern(BitConverter.ToString(Encoding.Unicode.GetBytes(str)).Replace("-", " "));
        var sigScan = new SigScan(Process, Process!.MainModule!.BaseAddress, Process.MainModule.ModuleMemorySize);
        sigScan.DumpMemory();
        for (var i = 0; i < sigScan.Size; i++)
        {
            if ((sigScan.VDumpedRegion[i] == 0x48 || sigScan.VDumpedRegion[i] == 0x4c) &&
                sigScan.VDumpedRegion[i + 1] == 0x8d)
            {
                var jmpTo = BitConverter.ToInt32(sigScan.VDumpedRegion, i + 3);
                var addr = sigScan.Address + i + jmpTo + 7;
                if (addr == stringAddr)
                {
                    return Process.MainModule.BaseAddress + i;
                }
            }
        }

        return 0;
    }

    public nint FindPattern(string pattern)
    {
        return FindPattern(pattern, Process!.MainModule!.BaseAddress, Process.MainModule.ModuleMemorySize);
    }

    public nint FindPattern(string pattern, nint start, int length)
    {
        var sigScan = new SigScan(Process, start, length);
        var arrayOfBytes = pattern.Split(' ').Select(b => b.Contains("?") ? (byte)0 : (byte)Convert.ToInt32(b, 16))
            .ToArray();
        var strMask = string.Join("", pattern.Split(' ').Select(b => b.Contains("?") ? '?' : 'x'));
        return sigScan.FindPattern(arrayOfBytes, strMask, 0);
    }

    public List<nint>? FindAllPattern(string pattern)
    {
        var sigScan = new SigScan(Process, Process!.MainModule!.BaseAddress, Process.MainModule.ModuleMemorySize);
        var arrayOfBytes = pattern.Split(' ').Select(b => b.Contains("?") ? (byte)0 : (byte)Convert.ToInt32(b, 16))
            .ToArray();
        var strMask = string.Join("", pattern.Split(' ').Select(b => b.Contains("?") ? '?' : 'x'));
        return sigScan.FindPatterns(arrayOfBytes, strMask, 0);
    }


    public string DumpHexString(nint start)
    {
        var buffer = new byte[0x1000];
        ReadProcessMemory2(_procHandle, start, buffer, buffer.Length, out int bytesRead);
        return string.Join(",", buffer.Select(b => "0x" + b.ToString("X2")));
    }

    public string DumpSurroundString(ulong start)
    {
        var buffer = new byte[0x100];
        ReadProcessMemory2(_procHandle, (nint)(start - 0x80), buffer, buffer.Length, out int bytesRead);
        var val = "";
        for (int i = 0x7f; i > 0; i--)
        {
            if (buffer[i] == 0)
                break;
            val = Encoding.UTF8.GetString(buffer, i, 1) + val;
        }

        for (int i = 0x80; i < 0x100; i++)
        {
            if (buffer[i] == 0)
                break;
            val += Encoding.UTF8.GetString(buffer, i, 1);
        }

        return val;
    }
}