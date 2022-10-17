public interface IMenuModel
{
    void StartGame();
    IMenuViewBuilder GetMenuViewBuilder { get; }
}
