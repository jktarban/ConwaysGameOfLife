using UnityEngine;

public class Game : MonoBehaviour
{
    private static int GRID_WIDTH = 50;
    private static int GRID_HEIGHT = 20;
    private Color _blockColor = Color.red;
    private float _speed = 10f;

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
        
    }

    private void PopulateBlocks()
    {
        for (int height = 0; height < GRID_HEIGHT; height++)
        {
            for(int width = 0; width <GRID_WIDTH; width++)
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
        _camera.orthographicSize = ((GRID_WIDTH > GRID_HEIGHT * _camera.aspect) ? (float)GRID_WIDTH / (float)_camera.pixelWidth * _camera.pixelHeight : GRID_HEIGHT) / 2;
    }

    private bool GetIsAlive()
    {
        //%20 percent chance
        if (Random.value > 0.8)
        {
            return true;
        }

        return false;
    }
}
