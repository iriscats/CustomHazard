using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnrealDotNet.SDKTool
{
    internal class Program
    {
        private static string GameName => "FSD-Win64-Shipping";

        static void Main()
        {
            ulong value = 1;
            var objSize = Marshal.SizeOf(value);
            Console.WriteLine(objSize);
            
            ushort a = 1;
            objSize = Marshal.SizeOf(a);
            Console.WriteLine(objSize);
            
            return;
            
            var ue = UnrealEngine.GetInstance();
            while (true)
            {
                var process = Process.GetProcesses()
                    .FirstOrDefault(p => p.ProcessName.Contains(GameName) && p.MainWindowHandle != IntPtr.Zero);
                if (process != null)
                {
                    ue.OpenUnrealProcess(process);
                    break;
                }

                Thread.Sleep(100);
            }
            ue.InitUOject();
            new DumpTool().DumpSdk();
        }
    }
}