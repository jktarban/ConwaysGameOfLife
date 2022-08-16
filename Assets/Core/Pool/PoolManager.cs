using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private readonly PoolView _poolView;
    private readonly PoolModel _poolModel;

    public PoolManager(PoolView poolView, PoolModel poolModel)
    {
        _poolView = poolView;
        _poolModel = poolModel;
    }

    public Transform GetContainer => _poolView.transform;

    public void Reset()
    {
        _poolModel.Reset(_poolView.transform);
    }
}
