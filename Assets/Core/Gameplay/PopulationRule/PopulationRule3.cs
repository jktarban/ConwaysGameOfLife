public class PopulationRule3 : IPopulationRule
{
    public void Check(int width, int height, IBlockManager[,] grid)
    {
        //overpopulation
        if (grid[width, height].NumNeighbors > GameSettings.Instance.OverPopulationCount)
        {
            grid[width, height].IsAlive = false;
        }
    }
}
