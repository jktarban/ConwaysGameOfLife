public class PopulationRule1 : IPopulationRule
{
    public void Check(int width, int height, IBlockManager[,] grid)
    {
        if (!grid[width, height].IsAlive)
        {
            return;
        }

        //underpopulation
        if (grid[width, height].NumNeighbors < GameSettings.Instance.UnderPopulationCount)
        {
            grid[width, height].IsAlive = false;
        }
    }
}
