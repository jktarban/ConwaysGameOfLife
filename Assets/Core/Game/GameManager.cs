using UnityEngine;

public static class GameManager
{
    public static int GridWidth { get; set; } = GameSettings.Instance.DefaultGridWidth;
    public static int GridHeight { get; set; } = GameSettings.Instance.DefaultGridHeight;
    public static float Speed { get; set; } = GameSettings.Instance.DefaultSpeed;
    public static Color BlockColor { get; set; }
    public static float AlivePercent { get; set; } = GameSettings.Instance.DefaultAlivePercent;
}
