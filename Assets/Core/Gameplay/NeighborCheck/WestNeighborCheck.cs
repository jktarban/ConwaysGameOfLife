public class WestNeighborCheck: INeighborCheck
{
    public int Check(int height, int width, int numNeighbors, IBlockManager[,] grid)
    {
        if (width - GameSettings.Instance.CellSize >= 0)
        {
            if (grid[width - GameSettings.Instance.CellSize, height].IsAlive)
            {
                numNeighbors++;
            }
        }

        return numNeighbors;
    }
}