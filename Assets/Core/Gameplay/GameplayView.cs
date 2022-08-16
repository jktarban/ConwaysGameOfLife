using UnityEngine;

public class GameplayView : MonoBehaviour
{
    [SerializeField]
    private GameObject _blockPrefab;
    [SerializeField]
    private Camera _camera;

    public Camera Camera => _camera;
    public GameObject BlockPrefab => _blockPrefab;
}
