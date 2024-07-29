using System.Diagnostics;
using UnrealSharp;

namespace CustomHazard;

public class Mod
{
    private static string GameName => "FSD-Win64-Shipping";
    private Process? _process;
    private bool _isStop;

    public Mod()
    {
    }

    public void InitMod()
    {
        while (true)
        {
            _process = Process.GetProcesses().FirstOrDefault(p =>
                p.ProcessName.Contains(GameName) && p.MainWindowHandle != IntPtr.Zero);

            if (_process != null)
                break;

            Thread.Sleep(500);
        }

        new UnrealEngine(new Memory(_process!)).UpdateAddresses();
    }

    public void Start()
    {
        while (!_isStop)
        {
            this.Update();
        }

        UEObject.ClearCache();
    }

    public void Stop()
    {
        _isStop = true;
    }


    public void Update()
    {
    }
}