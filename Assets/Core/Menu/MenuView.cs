using System;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    private Action _onClickStartButton;

    public void SetOnClickStartButton(Action onClickStartButton)
    {
        _onClickStartButton = onClickStartButton;
    }

    public void OnClickStartButton()
    {
        _onClickStartButton.Invoke();
    }
}
