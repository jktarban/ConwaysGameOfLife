using Zenject;

public class BlockManager: IInitializable, ITickable
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
    }

    public void Tick()
    {
    }
}
