using System;
using System.Collections.Generic;
using UnityEngine;
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

    public List<string> GetColorList
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

    public string GetGridWidth => GameManager.GridWidth.ToString();
    public string GetGridHeight => GameManager.GridHeight.ToString();
    public string GetSpeed => GameManager.Speed.ToString();
    public string GetAlivePercent => GameManager.AlivePercent.ToString();

}
