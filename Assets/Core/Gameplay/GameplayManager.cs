using Zenject;

public class GameplayManager : ITickable, IGameplayManager
{
    private readonly IGameplayModel _gameplayModel;

    public GameplayManager(IGameplayModel gameplayModel)
    {
        _gameplayModel = gameplayModel;
    }

    public void StartGame()
    {
        _gameplayModel.StartGame();
    }


    public void Tick()
    {
        _gameplayModel.Tick();
    }
}
