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
            ue.InitUObject();
            new DumpTool().DumpSdk();
        }
    }
}