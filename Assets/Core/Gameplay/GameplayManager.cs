using Zenject;

public class GameplayManager : ITickable, IGameplayManager
{
    private readonly GameplayView _gameplayView;
    private readonly GameplayModel _gameplayModel;

    public GameplayManager(GameplayView gameplayView, GameplayModel gameplayModel)
    {
        _gameplayView = gameplayView;
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
