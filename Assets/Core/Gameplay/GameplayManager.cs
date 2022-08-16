using Zenject;

public class GameplayManager : ITickable
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
        AdjustCamera();
        _gameplayModel.IsGameStart(true);
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
