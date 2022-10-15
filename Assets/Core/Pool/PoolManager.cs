using UnityEngine;

public class PoolManager: IPoolManager
{
    private readonly IPoolView _poolView;
    private readonly IPoolModel _poolModel;

    public PoolManager(IPoolView poolView, IPoolModel poolModel)
    {
        _poolView = poolView;
        _poolModel = poolModel;
    }

    public Transform GetContainer => _poolView.Transform;

    public void Reset()
    {
        _poolModel.Reset(_poolView.Transform);
    }

    public IBlockManager GetFromPool()
    {
        return _poolModel.GetFromPool(_poolView.Transform);
    }
}
