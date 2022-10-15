using Zenject;

public class MenuManager: IInitializable
{
    private readonly MenuView _menuView;
    private readonly MenuModel _menuModel;

    public MenuManager(MenuView menuView, MenuModel menuModel)
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
        _menuView.GetMenuModelBuilder.Build();
        _menuModel.StartGame();
    }
}
