using UnityEngine;
using Zenject;
public class GameplayModel: IGameplayModel
{
    private float _timer = 0;
    private IBlockManager[,] _grid;
    private bool _isGameStart = false;
   
    [Inject]
    private readonly BlockFactory _blockFactory;
    [Inject]
    private readonly IPoolManager _poolManager;
    [Inject]
    private readonly ICameraManager _cameraManager;

    public void AdjustCamera()
    {
        _cameraManager.SetPosition(GetCameraPosition);
    }

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
    }

    public void IsGameStart(bool isGameStart)
    {
        _isGameStart = isGameStart;
    }
   
    private Vector2 GetCameraPosition
    {
        get
        {
            return new Vector2(_grid.GetLength(0) / 2, _grid.GetLength(1) / 2);
        }
    }

    public void Tick()
    {
        if (!_isGameStart)
        {
            return;
        }

        if (_timer >= GameManager.Speed)
        {
            _timer = 0;
            CountNeighbors();
            PopulationControl();
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void CountNeighbors()
    {
        for (int height = 0; height < GameManager.GridHeight; height++)
        {
            for (int width = 0; width < GameManager.GridWidth; width++)
            {
                var numNeighbors = 0;

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

                //loop through all implementing the interface and get numneighbors
                foreach (var neighborCheck in neighborsCheck)
                {
                    numNeighbors = neighborCheck.Check(height, width, numNeighbors, _grid);
                }

                _grid[width, height].NumNeighbors = numNeighbors;
            }
        }
    }

    private void PopulationControl()
    {
        for (int height = 0; height < GameManager.GridHeight; height++)
        {
            for (int width = 0; width < GameManager.GridWidth; width++)
            {

                if (_grid[width, height].IsAlive)
                {
                   
                    //RULE 1 underpopulation
                    if (_grid[width, height].NumNeighbors < GameSettings.Instance.UnderPopulationCount)
                    {
                        _grid[width, height].IsAlive = false;
                    }

                    //RULE 2 lives to next generation
                    if (_grid[width, height].NumNeighbors >= GameSettings.Instance.UnderPopulationCount && 
                        _grid[width, height].NumNeighbors == GameSettings.Instance.OverPopulationCount)
                    {
                        _grid[width, height].IsAlive = true;
                    }

                    //RULE 3 overpopulation
                    if (_grid[width, height].NumNeighbors > GameSettings.Instance.OverPopulationCount)
                    {
                        _grid[width, height].IsAlive = false;
                    }
                }
                else
                {
                    //RULE 4 reproduction
                    if (_grid[width, height].NumNeighbors == GameSettings.Instance.OverPopulationCount)
                    {
                        _grid[width, height].IsAlive = true;
                    }
                }
            }
        }
    }
}
