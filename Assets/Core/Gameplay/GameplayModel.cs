using UnityEngine;
using Zenject;
public class GameplayModel
{
    private float _timer = 0;
    private IBlockManager[,] _grid;
    private bool _isGameStart = false;
   
    [Inject]
    private readonly BlockFactory _blockFactory;
    [Inject]
    private readonly IPoolManager _poolManager;

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
                blockManager.SetBlockPosition(new Vector2(width, height));
                blockManager.SetParent(_poolManager.GetContainer);
                _grid[width, height] = blockManager;
            }
        }
    }

    public void IsGameStart(bool isGameStart)
    {
        _isGameStart = isGameStart;
    }
   
    public Vector2 GetCameraPosition
    {
        get
        {
            return new Vector2(_grid.GetLength(0) / 2, _grid.GetLength(1) / 2);
        }
    }

    public float GetCameraOrthoSize(float cameraAspect, float pixelWidth, float pixelHeight)
    {
        if (GameManager.GridWidth > GameManager.GridHeight * cameraAspect)
        {
            return (GameManager.GridWidth / (float)pixelWidth * pixelHeight) / 2;
        }

        return GameManager.GridHeight / 2;
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

    //reference https://www.youtube.com/watch?v=BHqfkMu1Syw&list=PLiRrp7UEG13YiTwVr1wPnYtTvt12ZKg1r&index=2
    private void CountNeighbors()
    {
        for (int height = 0; height < GameManager.GridHeight; height++)
        {
            for (int width = 0; width < GameManager.GridWidth; width++)
            {
                var numNeighbors = 0;

                //North
                if (height + GameSettings.Instance.CellSize < GameManager.GridHeight)
                {
                    if (_grid[width, height + 1].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //EAST
                if (width + GameSettings.Instance.CellSize < GameManager.GridWidth)
                {
                    if (_grid[width + GameSettings.Instance.CellSize, height].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SOUTH
                if (height - GameSettings.Instance.CellSize >= 0)
                {
                    if (_grid[width, height - GameSettings.Instance.CellSize].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //WEST
                if (width - GameSettings.Instance.CellSize >= 0)
                {
                    if (_grid[width - GameSettings.Instance.CellSize, height].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //NORTHEAST
                if (width + GameSettings.Instance.CellSize < GameManager.GridWidth && height + GameSettings.Instance.CellSize < GameManager.GridHeight)
                {
                    if (_grid[width + GameSettings.Instance.CellSize, height + GameSettings.Instance.CellSize].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //NORTHWEST
                if (width - GameSettings.Instance.CellSize >= 0 && height + GameSettings.Instance.CellSize < GameManager.GridHeight)
                {
                    if (_grid[width - GameSettings.Instance.CellSize, height + GameSettings.Instance.CellSize].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SOUTHEAST
                if (width + GameSettings.Instance.CellSize < GameManager.GridWidth && height - GameSettings.Instance.CellSize >= 0)
                {
                    if (_grid[width + GameSettings.Instance.CellSize, height - GameSettings.Instance.CellSize].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SOUTHWEST
                if (width - GameSettings.Instance.CellSize >= 0 && height - GameSettings.Instance.CellSize >= 0)
                {
                    if (_grid[width - GameSettings.Instance.CellSize, height - GameSettings.Instance.CellSize].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                _grid[width, height].NumNeighbors = numNeighbors;
            }
        }
    }

    //reference https://www.youtube.com/watch?v=BHqfkMu1Syw&list=PLiRrp7UEG13YiTwVr1wPnYtTvt12ZKg1r&index=2
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
                    if (_grid[width, height].NumNeighbors >= GameSettings.Instance.UnderPopulationCount && _grid[width, height].NumNeighbors == GameSettings.Instance.OverPopulationCount)
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
