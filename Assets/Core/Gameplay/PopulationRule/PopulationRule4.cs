public class PopulationRule4 : IPopulationRule
{
    public void Check(int width, int height, IBlockManager[,] grid)
    {
        if (grid[width, height].IsAlive)
        {
            return;
        }

        //reproduction
        if (grid[width, height].NumNeighbors == GameSettings.Instance.OverPopulationCount)
        {
            grid[width, height].IsAlive = true;
        }
    }
}
