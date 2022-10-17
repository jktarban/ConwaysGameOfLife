public class GameManagerBuilder: IGameManagerBuilder
{
    public string BlockColor { get; set; }
    public string AlivePercent { get; set; }
    public string Speed { get; set; }
    public string GridHeight { get; set; }
    public string GridWidth { get; set; }

    public void Build()
    {
        GameManager.BlockColor = ColorHelper.ParseColor(BlockColor);

        if (float.TryParse(AlivePercent, out float alivePercent))
        {
            GameManager.AlivePercent = alivePercent;
        }

        if (float.TryParse(Speed, out float speed))
        {
            GameManager.Speed = speed;
        }

        if (int.TryParse(GridHeight, out int gridHeight))
        {
            GameManager.GridHeight = gridHeight;
        }

        if (int.TryParse(GridWidth, out int gridWidth))
        {
            GameManager.GridWidth = gridWidth;
        }

    }
}
