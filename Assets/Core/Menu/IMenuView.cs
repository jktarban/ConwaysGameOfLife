using System;

public interface IMenuView
{
    void SetOnClickStartButton(Action onClickStartButton);
    void OnClickStartButton();
    void SetMenu(IMenuViewBuilder menuViewBuilder);
    GameManagerBuilder GetGameManagerBuilder { get; }
}
