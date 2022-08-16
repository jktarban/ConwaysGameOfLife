using UnityEngine;
using Zenject;
public class GameplayModel
{
    private const int UNDER_POPULATION_COUNT = 2;
    private const int OVER_POPULATION_COUNT = 3;
    private const int CELL_SIZE = 1;

    private float _timer = 0;
    private BlockManager[,] _grid;
    private bool _isGameStarted = false;
    [Inject]
    private BlockFactory blockFactory;

    public void PopulateBlocks()
    {
        _grid = new BlockManager[GameManager.GridWidth, GameManager.GridHeight];

        for (int height = 0; height < GameManager.GridHeight; height++)
        {
            for (int width = 0; width < GameManager.GridWidth; width++)
            {
                var blockManager = blockFactory.Create().BlockManager;
                blockManager.SetBlockPosition(new Vector2(width, height));
                _grid[width, height] = blockManager;
            }
        }

        _isGameStarted = true;
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
        if (!_isGameStarted)
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

                //North
                if (height + CELL_SIZE < GameManager.GridHeight)
                {
                    if (_grid[width, height + 1].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //EAST
                if (width + CELL_SIZE < GameManager.GridWidth)
                {
                    if (_grid[width + CELL_SIZE, height].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SOUTH
                if (height - CELL_SIZE >= 0)
                {
                    if (_grid[width, height - CELL_SIZE].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //WEST
                if (width - CELL_SIZE >= 0)
                {
                    if (_grid[width - CELL_SIZE, height].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //NORTHEAST
                if (width + CELL_SIZE < GameManager.GridWidth && height + CELL_SIZE < GameManager.GridHeight)
                {
                    if (_grid[width + CELL_SIZE, height + CELL_SIZE].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //NORTHWEST
                if (width - CELL_SIZE >= 0 && height + CELL_SIZE < GameManager.GridHeight)
                {
                    if (_grid[width - CELL_SIZE, height + CELL_SIZE].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SOUTHEAST
                if (width + CELL_SIZE < GameManager.GridWidth && height - CELL_SIZE >= 0)
                {
                    if (_grid[width + CELL_SIZE, height - CELL_SIZE].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SOUTHWEST
                if (width - CELL_SIZE >= 0 && height - CELL_SIZE >= 0)
                {
                    if (_grid[width - CELL_SIZE, height - CELL_SIZE].IsAlive)
                    {
                        numNeighbors++;
                    }
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
                    if (_grid[width, height].NumNeighbors < UNDER_POPULATION_COUNT)
                    {
                        _grid[width, height].IsAlive = false;
                    }

                    //RULE 2 lives to next generation
                    if (_grid[width, height].NumNeighbors >= UNDER_POPULATION_COUNT && _grid[width, height].NumNeighbors == OVER_POPULATION_COUNT)
                    {
                        _grid[width, height].IsAlive = true;
                    }

                    //RULE 3 overpopulation
                    if (_grid[width, height].NumNeighbors > OVER_POPULATION_COUNT)
                    {
                        _grid[width, height].IsAlive = false;
                    }
                }
                else
                {
                    //RULE 4 reproduction
                    if (_grid[width, height].NumNeighbors == OVER_POPULATION_COUNT)
                    {
                        _grid[width, height].IsAlive = true;
                    }
                }
            }
        }
    }
}
