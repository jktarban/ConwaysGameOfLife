public interface IGameManagerBuilder: IBuilder
{
    public string BlockColor { get; set; }
    public string AlivePercent { get; set; }
    public string Speed { get; set; }
    public string GridHeight { get; set; }
    public string GridWidth { get; set; }
}
