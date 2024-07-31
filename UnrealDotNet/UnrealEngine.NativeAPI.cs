using System.Runtime.InteropServices;

namespace UnrealDotNet;

public unsafe partial class UnrealEngine
{
    static readonly nint Kernel = NativeLibrary.Load("kernel32.dll");

    static readonly delegate* unmanaged[Stdcall]<int, int, int, nint> OpenProcess =
        (delegate* unmanaged[Stdcall]<int, int, int, nint>)NativeLibrary.GetExport(Kernel, nameof(OpenProcess));

    static readonly delegate* unmanaged[Stdcall]<nint, nint, byte[], int, out int, int> ReadProcessMemory2 =
        (delegate* unmanaged[Stdcall]<nint, nint, byte[], int, out int, int>)
        NativeLibrary.GetExport(Kernel, nameof(ReadProcessMemory));

    [DllImport("kernel32")]
    static extern Boolean WriteProcessMemory(nint hProcess, nint lpBaseAddress, Byte[] buffer, Int32 nSize,
        out Int32 lpNumberOfBytesWritten);

    [DllImport("kernel32")]
    static extern Int32 CloseHandle(IntPtr hObject);

    [DllImport("kernel32")]
    static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, UInt32 dwStackSize,
        IntPtr lpStartAddress, IntPtr lpParameter, UInt32 dwCreationFlags, IntPtr lpThreadId);

    [DllImport("kernel32")]
    static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

    [DllImport("kernel32")]
    static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, Int32 dwSize, Int32 flAllocationType,
        Int32 flProtect);

    [DllImport("kernel32")]
    static extern Boolean VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, Int32 dwSize, Int32 dwFreeType);

}