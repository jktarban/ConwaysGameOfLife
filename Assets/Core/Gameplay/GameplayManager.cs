using Zenject;

public class GameplayManager : IInitializable, ITickable
{
    private readonly GameplayView _gameView;
    private readonly GameplayModel _gameModel;

    public GameplayManager(GameplayView gameView, GameplayModel gameModel)
    {
        _gameView = gameView;
        _gameModel = gameModel;
    }

    public void Initialize()
    {
        _gameModel.PopulateBlocks(_gameView.BlockPrefab);
        _gameModel.AdjustCamera(_gameView.Camera);
    }

    public void Tick()
    {
        _gameModel.Tick();
    }
}
