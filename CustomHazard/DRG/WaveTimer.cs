
using UnrealDotNet;

public class WaveTimer
{
    private UnrealEngine _unrealEngine = UnrealEngine.GetInstance();
    
    public WaveTimer()
    {
    }


    public void GetTimerArray()
    {
        /*if (_unrealEngine.GWorld == 0)
            return null;


        var world = new World(_unrealEngine.MemoryReadPtr(_unrealEngine.GWorld));
        var gameMode = world.AuthorityGameMode.GetType();


        var World = new World(_unrealEngine.MemoryReadPtr(_unrealEngine.GWorld));
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
        var waveManager = gameMode.GetWaveManager();
        var point = waveManager.Address + 304;
        return UnrealEngine.Memory.ReadProcessMemory<Array<float>>(point);*/

  
    }
}