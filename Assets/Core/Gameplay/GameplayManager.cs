using UnityEngine;
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
        AdjustCamera();
    }

    public void AdjustCamera()
    {
        _gameView.SetCamera(_gameModel.GetCameraOrthoSize(_gameView.Camera.aspect, _gameView.Camera.pixelWidth, _gameView.Camera.pixelHeight), _gameModel.GetCameraPosition);
    }

    public void Tick()
    {
        _gameModel.Tick();
    }
}
