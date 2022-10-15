using System;
using System.Collections.Generic;
using Zenject;
using static ColorHelper;

public class MenuModel
{
    [Inject]
    private IGameplayManager _gameplayManager;
    public void StartGame()
    {
        _gameplayManager.StartGame();
    }

    public MenuViewBuilder GetMenuViewBuilder { get
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

    private List<string> GetColorList
    {
        get
        {
            List<string> colors = new();

            foreach (EnumColors color in Enum.GetValues(typeof(EnumColors)))
            {
                colors.Add(color.ToString());
            }

            return colors;
        }
    }
}
