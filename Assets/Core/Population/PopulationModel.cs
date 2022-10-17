using UnityEngine;
using Zenject;

//I got the logic here from youtube, and just modify the script to look better
public class PopulationModel : IPopulationModel
{
    private IBlockManager[,] _grid;
    [Inject]
    private readonly BlockFactory _blockFactory;
    [Inject]
    private readonly IPoolManager _poolManager;
    [Inject]
    private readonly ICameraManager _cameraManager;

    public void PopulateBlocks()
    {
        _poolManager.Reset();
        _grid = new IBlockManager[GameManager.GridWidth, GameManager.GridHeight];

        for (int height = 0; height < GameManager.GridHeight; height++)
        {
            for (int width = 0; width < GameManager.GridWidth; width++)
            {
                IBlockManager blockManager = _poolManager.GetFromPool();

                if (blockManager == null)
                {
                    blockManager = _blockFactory.Create().BlockManager;
                }

                blockManager.Init();
                blockManager.SetPosition(new Vector2(width, height));
                blockManager.SetParent(_poolManager.GetContainer);
                _grid[width, height] = blockManager;
            }
        }

        //we need to get the grid position that is why camera is set here in this class
        _cameraManager.SetPosition(GetCameraPosition);
    }

    private Vector2 GetCameraPosition
    {
        get
        {
            return new Vector2(_grid.GetLength(0) / 2, _grid.GetLength(1) / 2);
        }
    }

    public void PopulationControl()
    {
        CountNeighbors();

        //Array of populationRules
        var populationRules = new IPopulationRule[]{
                    new PopulationRule1(),
                    new PopulationRule2(),
                    new PopulationRule3(),
                    new PopulationRule4()
                };


        for (int height = 0; height < GameManager.GridHeight; height++)
        {
            for (int width = 0; width < GameManager.GridWidth; width++)
            {
                //loop through all implementing the interface
                foreach (var populationRule in populationRules)
                {
                    populationRule.Check(width, height, _grid);
                }
            }
        }
    }

    private void CountNeighbors()
    {
        //Array of neighborscheck
        var neighborsCheck = new INeighborCheck[]{
                    new NorthNeighborCheck(),
                    new SouthNeighborCheck(),
                    new EastNeighborCheck(),
                    new WestNeighborCheck(),
                    new NorthEastNeighborCheck(),
                    new NorthWestNeighborCheck(),
                    new SouthEastNeighborCheck(),
                    new SouthWestNeighborCheck()
                };

        for (int height = 0; height < GameManager.GridHeight; height++)
        {
            for (int width = 0; width < GameManager.GridWidth; width++)
            {
                var numNeighbors = 0;

                //loop through all implementing the interface and get numneighbors
                foreach (var neighborCheck in neighborsCheck)
                {
                    numNeighbors = neighborCheck.Check(height, width, numNeighbors, _grid);
                }

                _grid[width, height].NumNeighbors = numNeighbors;
            }
        }
    }
}
