using Zenject;

public class GameplayManager : ITickable, IGameplayManager
{
    private readonly GameplayModel _gameplayModel;

    public GameplayManager(GameplayModel gameplayModel)
    {
        _gameplayModel = gameplayModel;
    }

    public void StartGame()
    {
        _gameplayModel.PopulateBlocks();
        _gameplayModel.AdjustCamera();
        _gameplayModel.IsGameStart(true);
    }


    public void Tick()
    {
        _gameplayModel.Tick();
    }
}
