using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuModel
{
    [Inject]
    private GameplayManager _gameplayManager;
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

    public void SetColor(string color)
    {
        Enum.TryParse(color, out EnumColors enumColor);
        switch (enumColor)
        {
            case EnumColors.White:
                GameManager.BlockColor = Color.white;
                break;
            case EnumColors.Green:
                GameManager.BlockColor = Color.green;
                break;
            case EnumColors.Red:
                GameManager.BlockColor = Color.red;
                break;
            case EnumColors.Blue:
                GameManager.BlockColor = Color.blue;
                break;
            case EnumColors.Cyan:
                GameManager.BlockColor = Color.cyan;
                break;
            case EnumColors.Gray:
                GameManager.BlockColor = Color.gray;
                break;
            case EnumColors.Magenta:
                GameManager.BlockColor = Color.magenta;
                break;
            case EnumColors.Yellow:
                GameManager.BlockColor = Color.yellow;
                break;
        }
    }

    public void SetAlivePercent(string alivePercent)
    {
        GameManager.AlivePercent = float.Parse(alivePercent);
    }

    public void SetSpeed(string speed)
    {
        GameManager.Speed = float.Parse(speed);
    }

    public void SetGridHeight(string gridHeight)
    {
        GameManager.GridHeight = int.Parse(gridHeight);
    }

    public void SetGridWidth(string gridWidth)
    {
        GameManager.GridWidth = int.Parse(gridWidth);
    }

    public enum EnumColors
    {
        White,
        Green,
        Red,
        Blue,
        Cyan,
        Gray,
        Magenta,
        Yellow
    }
}
