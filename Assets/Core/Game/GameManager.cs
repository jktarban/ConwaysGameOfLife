using UnityEngine;

public static class GameManager
{
    public static int GridWidth { get; set; } = 50;
    public static int GridHeight { get; set; } = 50;
    public static float Speed { get; set; } = 0.1f;
    public static Color BlockColor { get; set; } = Color.red;
    public static float AlivePercent { get; set; } = 20f;
}
