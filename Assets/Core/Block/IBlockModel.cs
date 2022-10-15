public interface IBlockModel: IIsAlive, INumNeighbors
{
    bool GetRandomIsAlive { get; }
}
