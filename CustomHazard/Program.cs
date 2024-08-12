using SDK.Script.FSDSDK;
using System.Diagnostics;
using UnrealDotNet;
using UnrealDotNet.Types;

namespace CustomHazard;

static class Program
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

        new WaveTimer();
        FSDGameMode gameMode = UObjectCache.FindObject("FSDGameMode /Script/FSD.Default__FSDGameMode").As<FSDGameMode>();
        gameMode.GetWaveManager();


    }

}