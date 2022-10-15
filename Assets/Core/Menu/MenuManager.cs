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
        _menuView.SetGridXIField(_menuModel.GetGridWidth);
        _menuView.SetGridYIField(_menuModel.GetGridHeight);
        _menuView.SetAlivePercentIField(_menuModel.GetAlivePercent);
        _menuView.SetSpeedIField(_menuModel.GetSpeed);
        _menuView.SetColorDropDown(_menuModel.GetColorList);
    }

    private void StartGame()
    {
        _menuView.GetMenuModelBuilder.Build();
        _menuModel.StartGame();
    }
}
