public class NorthNeighborCheck: INeighborCheck
{
    public int Check(int height, int width, int numNeighbors, IBlockManager[,] grid)
    {
        if (height + GameSettings.Instance.CellSize < GameManager.GridHeight)
        {
            if (grid[width, height + 1].IsAlive)
            {
                numNeighbors++;
            }
        }

        return numNeighbors;
    }
}