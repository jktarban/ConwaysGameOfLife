public class PopulationRule2 : IPopulationRule
{
    public void Check(int width, int height, IBlockManager[,] grid)
    {
        if (!grid[width, height].IsAlive)
        {
            return;
        }

        //lives to next generation
        if (grid[width, height].NumNeighbors >= GameSettings.Instance.UnderPopulationCount &&
        grid[width, height].NumNeighbors == GameSettings.Instance.OverPopulationCount)
        {
            grid[width, height].IsAlive = true;
        }
    }
}
