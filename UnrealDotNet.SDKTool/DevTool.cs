using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealDotNet.Types;

namespace UnrealDotNet.SDKTool
{
    internal class DevTool
    {

        private readonly UnrealEngine _ue = UnrealEngine.GetInstance();

        public void EnableConsole()
        {
            var engine = new UObject(_ue.GEngine);
            var console = new UObject(_ue.Execute(_ue.GStaticCtor,
                engine["ConsoleClass"].Value,
                engine["GameViewport"].Address,
                0, 0, 0, 0, 0, 0, 0));
            engine["GameViewport"]["ViewportConsole"] = console;
        }


        public void DumpGNames()
        {
            var testObj = new UObject(0);
            var sb = new StringBuilder();
            var i = 0;
            while (true)
            {
                var name = UObject.GetName(i);

                if (name == "badIndex")
                {
                    if ((i & 0xffff) > 0xff00)
                    {
                        i += 0x10000 - (i % 0x10000);
                        continue;
                    }

                    break;
                }

                sb.AppendLine("[" + i + " | " + (i).ToString("X") + "] " + name);
                i += name.Length / 2 + name.Length % 2 + 1;
            }

            Directory.CreateDirectory(_ue.Process.ProcessName);
            File.WriteAllText(_ue.Process.ProcessName + @"\GNamesDump.txt", sb.ToString());
        }


        public void DumpObjects()
        {
            var entityList = _ue.MemoryReadPtr(_ue.BaseAddress + _ue.GObjects);
            var count = _ue.MemoryReadInt(_ue.BaseAddress + _ue.GObjects + 0x14);

            entityList = _ue.MemoryReadPtr(entityList);
            var packages = new Dictionary<nint, List<nint>>();
            for (var i = 0; i < count; i++)
            {
                // var entityAddr = _unrealEngine.ReadProcessMemory<UInt64>((entityList + 8 * (i / 0x10400)) + 24 * (i % 0x10400));
                var entityAddr = _ue.MemoryReadPtr((entityList + 8 * (i >> 16)) + 24 * (i % 0x10000));
                if (entityAddr == 0) continue;
                var outer = entityAddr;
                while (true)
                {
                    var tempOuter = _ue.MemoryReadPtr(outer + UObject.ObjectOuterOffset);
                    if (tempOuter == 0) break;
                    outer = tempOuter;
                }

                if (!packages.ContainsKey(outer)) packages.Add(outer, new List<nint>());
                packages[outer].Add(entityAddr);
            }

            var dumpedPackages = new List<Package>();
            var sb = new StringBuilder();
            foreach (var package in packages)
            {
                var packageObj = new UObject(package.Key);
                var fullPackageName = packageObj.GetName();

                if (fullPackageName.Contains("TypedElementFrameworkSDK"))
                    Console.WriteLine("");

                var dumpedClasses = new List<string>();
                var sdkPackage = new Package { FullName = fullPackageName };
                foreach (var objAddr in package.Value)
                {
                    var obj = new UObject(objAddr);
                    if (dumpedClasses.Contains(obj.ClassName))
                        continue;

                    if (obj.ClassName.IndexOf("Default__FSDGameMode") > 0)
                    {

                    }

                    sb.AppendLine(obj.ClassName);
                }

            }

            Directory.CreateDirectory(_ue.Process.ProcessName);
            File.WriteAllText(_ue.Process.ProcessName + @"\DumpObjects.txt", sb.ToString());

        }

    }
}
