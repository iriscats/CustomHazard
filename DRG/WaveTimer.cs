using SDK.Script.EngineSDK;
using SDK.Script.FSDSDK;
using UnrealSharp;


public class WaveTimer
{
    public WaveTimer()
    {
    }


    public Array<float>? GetTimerArray()
    {
        if (UnrealEngine.GWorldPtr == 0)
            return null;


        

        var world = new World(UnrealEngine.Memory.ReadProcessMemory<nint>(UnrealEngine.GWorldPtr));
        var gameMode = world.AuthorityGameMode.GetType();





        /*        var waveManager = gameMode.GetWaveManager();
                var point = waveManager.Address + 304;
                return UnrealEngine.Memory.ReadProcessMemory<Array<float>>(point);*/

        return null;
    }
}