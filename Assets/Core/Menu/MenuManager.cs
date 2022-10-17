using Zenject;

public class MenuManager: IInitializable, IMenuManager
{
    private readonly IMenuView _menuView;
    private readonly IMenuModel _menuModel;

    public MenuManager(IMenuView menuView, IMenuModel menuModel)
    {
        _menuView = menuView;
        _menuModel = menuModel;
    }

    public void Initialize()
    {
        _menuView.SetOnClickStartButton(StartGame);
        _menuView.SetMenu(_menuModel.GetMenuViewBuilder);
    }

    private void StartGame()
    {
        IBuilder builder = _menuView.GetGameManagerBuilder;
        builder.Build();
        _menuModel.StartGame();
    }
}
