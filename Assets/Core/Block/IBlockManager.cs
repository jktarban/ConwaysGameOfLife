using UnityEngine;

public interface IBlockManager
{
    void Init();
    void SetParent(Transform parent);
    void SetBlockPosition(Vector2 blockPosition);
    bool IsAlive { get; set; }
    int NumNeighbors { get; set; }
}
