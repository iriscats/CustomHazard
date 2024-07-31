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


        var World = new World(UnrealEngine.Memory.ReadProcessMemory<nint>(UnrealEngine.GWorldPtr));
        if (!World.IsA<World>())
            return null;

        var OwningGameInstance = World.OwningGameInstance;
        if (!OwningGameInstance.IsA<GameInstance>())
            return null;


        var LocalPlayers = OwningGameInstance.LocalPlayers;
        var PlayerController = LocalPlayers[0].PlayerController.As<FSDPlayerController>();
        if (!PlayerController.IsA<PlayerController>())
            return null;


        var Player = PlayerController.Player;
        var AcknowledgedPawn = PlayerController.AcknowledgedPawn.As<PlayerCharacter>();
        if (AcknowledgedPawn == null || !AcknowledgedPawn.IsA<PlayerCharacter>())
            return null;

        AcknowledgedPawn.SetCameraMode(ECharacterCameraMode.Follow);

        /*        var waveManager = gameMode.GetWaveManager();
                var point = waveManager.Address + 304;
                return UnrealEngine.Memory.ReadProcessMemory<Array<float>>(point);*/

        return null;
    }
}