public class EastNeighborCheck: INeighborCheck
{
    public int Check(int height, int width, int numNeighbors, IBlockManager[,] grid)
    {
        if (width + GameSettings.Instance.CellSize < GameManager.GridWidth)
        {
            if (grid[width + GameSettings.Instance.CellSize, height].IsAlive)
            {
                numNeighbors++;
            }
        }

        return numNeighbors;
    }
}