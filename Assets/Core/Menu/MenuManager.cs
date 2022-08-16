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
        _menuModel.SetColor(_menuView.GetColor);
        _menuModel.SetGridWidth(_menuView.GetGridWidth);
        _menuModel.SetGridHeight(_menuView.GetGridHeight);
        _menuModel.SetSpeed(_menuView.GetSpeed);
        _menuModel.SetAlivePercent(_menuView.GetAlivePercent);
        _menuModel.StartGame();
    }
}
