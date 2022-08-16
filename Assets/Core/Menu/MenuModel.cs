using Zenject;

public class MenuModel
{
    [Inject]
    private GameplayManager _gameplayManager;
    public void StartGame()
    {
        _gameplayManager.StartGame();
    }
}
