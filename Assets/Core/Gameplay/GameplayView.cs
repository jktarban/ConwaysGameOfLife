using UnityEngine;

public class GameplayView : MonoBehaviour
{
    [SerializeField]
    private GameObject _blockPrefab;
    [SerializeField]
    private Camera _camera;

    public Camera Camera => _camera;
    public GameObject BlockPrefab => _blockPrefab;

    public void SetCamera(float orthoSize, Vector2 cameraPosition )
    {
        _camera.orthographicSize = orthoSize;
        _camera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, _camera.transform.position.z);
    }
}
