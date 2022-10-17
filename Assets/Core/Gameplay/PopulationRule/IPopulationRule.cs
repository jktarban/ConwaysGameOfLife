public interface IPopulationRule
{
    void Check(int width, int height, IBlockManager[,] grid);
}
