public class SouthNeighborCheck: INeighborCheck
{
    public int Check(int height, int width, int numNeighbors, IBlockManager[,] grid)
    {
        if (height - GameSettings.Instance.CellSize >= 0)
        {
            if (grid[width, height - GameSettings.Instance.CellSize].IsAlive)
            {
                numNeighbors++;
            }
        }

        return numNeighbors;
    }
}