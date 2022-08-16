using UnityEngine;
using Zenject;

public class BlockManager : IInitializable
{
    private readonly BlockView _blockView;
    private readonly BlockModel _blockModel;

    public BlockManager(BlockView blockView, BlockModel blockModel)
    {
        _blockView = blockView;
        _blockModel = blockModel;
    }

    public void Initialize()
    {
        _blockView.Init();
        _blockView.BlockManager = this;
        _blockView.SetColor(GameManager.BlockColor);
        _blockView.SetSpriteEnabled(_blockModel.GetRandomIsAlive);
    }

    public void SetParent(Transform parent)
    {
        _blockView.SetParent(parent);
    }

    public void SetBlockPosition(Vector2 blockPosition)
    {
        _blockView.SetPosition(blockPosition);
    }

    public bool IsAlive
    {
        get
        {
            return _blockModel.IsAlive;
        }
        set
        {
            _blockModel.IsAlive = value;
            _blockView.SetSpriteEnabled(_blockModel.IsAlive);
        }
    }

    public int NumNeighbors
    {
        get
        {
            return _blockModel.NumNeighbors;
        }
        set
        {
            _blockModel.NumNeighbors = value;
        }
    }
}
