using UnityEngine;

public interface IPoolModel
{
    void Reset(Transform container);
    IBlockManager GetFromPool(Transform container);
}
