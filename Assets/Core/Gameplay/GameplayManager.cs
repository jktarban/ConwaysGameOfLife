using Zenject;

public class GameplayManager : IInitializable, ITickable
{
    private readonly GameplayView _gameplayView;
    private readonly GameplayModel _gameplayModel;

    public GameplayManager(GameplayView gameView, GameplayModel gameModel)
    {
        _gameplayView = gameView;
        _gameplayModel = gameModel;
    }

    public void Initialize()
    {
        _gameplayModel.PopulateBlocks();
        AdjustCamera();
    }

    public void AdjustCamera()
    {
        _gameplayView.SetCamera(_gameplayModel.GetCameraOrthoSize(_gameplayView.GetCameraAspect, _gameplayView.GetCameraPixelWidth, _gameplayView.GetCameraPixelHeight), _gameplayModel.GetCameraPosition);
    }

    public void Tick()
    {
        _gameplayModel.Tick();
    }
}
