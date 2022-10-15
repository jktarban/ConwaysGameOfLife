using Zenject;
using static ColorHelper;

public class MenuModel: IMenuModel
{
    [Inject]
    private IGameplayManager _gameplayManager;
    public void StartGame()
    {
        _gameplayManager.StartGame();
    }

    public IMenuViewBuilder GetMenuViewBuilder { get
        {
            return new MenuViewBuilder
            {
                ColorOptions = GetColorList,
                GridXText = GameManager.GridWidth.ToString(),
                GridYText = GameManager.GridHeight.ToString(),
                SpeedText = GameManager.Speed.ToString(),
                AlivePercentText = GameManager.AlivePercent.ToString(),
            };
        }
    }
}
