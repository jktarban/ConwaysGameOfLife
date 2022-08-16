using UnityEngine;

public class Game : MonoBehaviour
{
    private const int GRID_WIDTH = 200;
    private const int GRID_HEIGHT = 50;
    private Color _blockColor = Color.red;
    private float _speed = 0.1f;
    private float _timer = 0;
    private const int UNDER_POPULATION_COUNT = 2;
    private const int OVER_POPULATION_COUNT = 3;
    private const int CELL_SIZE = 1;
    private const float ALIVE_PERCENT = 20f;

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Camera _camera;

    private Block[,] _grid = new Block[GRID_WIDTH, GRID_HEIGHT];

    // Start is called before the first frame update
    void Start()
    {
        PopulateBlocks();
        AdjustCamera();
    }


    // Update is called once per frame
    void Update()
    {
        if (_timer >= _speed)
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
        for (int height = 0; height < GRID_HEIGHT; height++)
        {
            for (int width = 0; width < GRID_WIDTH; width++)
            {
                var numNeighbors = 0;

                //North
                if (height + CELL_SIZE < GRID_HEIGHT)
                {
                    if (_grid[width, height + 1].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //EAST
                if (width + CELL_SIZE < GRID_WIDTH)
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
                if (width + CELL_SIZE < GRID_WIDTH && height + CELL_SIZE < GRID_HEIGHT)
                {
                    if (_grid[width + CELL_SIZE, height + CELL_SIZE].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //NORTHWEST
                if (width - CELL_SIZE >= 0 && height + CELL_SIZE < GRID_HEIGHT)
                {
                    if (_grid[width - CELL_SIZE, height + CELL_SIZE].IsAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SOUTHEAST
                if (width + CELL_SIZE < GRID_WIDTH && height - CELL_SIZE >= 0)
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
        for (int height = 0; height < GRID_HEIGHT; height++)
        {
            for (int width = 0; width < GRID_WIDTH; width++)
            {
                if (_grid[width, height].IsAlive)
                {
                    //RULE 1 underpopulation
                    if (_grid[width, height].NumNeighbors < UNDER_POPULATION_COUNT)
                    {
                        _grid[width, height].SetAlive(false);
                    }

                    //RULE 2 lives to next generation
                    if (_grid[width, height].NumNeighbors >= UNDER_POPULATION_COUNT && _grid[width, height].NumNeighbors == OVER_POPULATION_COUNT)
                    {
                        _grid[width, height].SetAlive(true);
                    }

                    //RULE 3 overpopulation
                    if (_grid[width, height].NumNeighbors > OVER_POPULATION_COUNT)
                    {
                        _grid[width, height].SetAlive(false);
                    }
                }
                else
                {
                    //RULE 4 reproduction
                    if (_grid[width, height].NumNeighbors == OVER_POPULATION_COUNT)
                    {
                        _grid[width, height].SetAlive(true);
                    }
                }
            }
        }
    }

    private void PopulateBlocks()
    {
        for (int height = 0; height < GRID_HEIGHT; height++)
        {
            for (int width = 0; width < GRID_WIDTH; width++)
            {
                var block = Instantiate(_prefab, new Vector2(width, height), Quaternion.identity).GetComponent<Block>();
                _grid[width, height] = block;
                block.SetAlive(GetIsAlive());
                block.SetColor(_blockColor);
            }
        }
    }

    //fit grid on camera
    //reference https://stackoverflow.com/a/71013983
    private void AdjustCamera()
    {
        //center the camera
        _camera.transform.position = new Vector3(_grid.GetLength(0) / 2, _grid.GetLength(1) / 2, _camera.transform.position.z);

        if(GRID_WIDTH > GRID_HEIGHT * _camera.aspect)
        {
            _camera.orthographicSize = ((float)GRID_WIDTH / (float)_camera.pixelWidth * _camera.pixelHeight) / 2;
        }
        else
        {
            _camera.orthographicSize = GRID_HEIGHT / 2;
        }
    }

    private bool GetIsAlive()
    {
        if (Random.value > (1 - (ALIVE_PERCENT/100)))
        {
            return true;
        }

        return false;
    }
}
