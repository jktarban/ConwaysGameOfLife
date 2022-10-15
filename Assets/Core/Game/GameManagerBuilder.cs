public class GameManagerBuilder
{
    public string BlockColor;
    public string AlivePercent;
    public string Speed;
    public string GridHeight;
    public string GridWidth;

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
