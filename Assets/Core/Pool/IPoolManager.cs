using UnityEngine;

public interface IPoolManager
{
    void Reset();
    Transform GetContainer { get; }
    IBlockManager GetFromPool();
}
