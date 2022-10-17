public class SouthEastNeighborCheck: INeighborCheck
{
    public int Check(int height, int width, int numNeighbors, IBlockManager[,] grid)
    {
        if (width + GameSettings.Instance.CellSize < GameManager.GridWidth && height - GameSettings.Instance.CellSize >= 0)
        {
            if (grid[width + GameSettings.Instance.CellSize, height - GameSettings.Instance.CellSize].IsAlive)
            {
                numNeighbors++;
            }
        }

        return numNeighbors;
    }
}