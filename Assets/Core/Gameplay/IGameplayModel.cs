public interface IGameplayModel
{
    void AdjustCamera();
    void PopulateBlocks();
    void IsGameStart(bool isGameStart);
    void Tick();
}
