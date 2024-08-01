using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                var _process = Process.GetProcesses()
                    .FirstOrDefault(p =>p.ProcessName.Contains(GameName) && p.MainWindowHandle != IntPtr.Zero);

                if (_process != null)
                {
                    ue.OpenUnrealProcess(_process);
                    break;
                }

                Thread.Sleep(500);
            }

            ue.InitUOject();

            new DumpTool().DumpSdk();

        }
    }
}
