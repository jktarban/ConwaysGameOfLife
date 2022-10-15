using System;
using TMPro;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    private Action _onClickStartButton;

    [SerializeField]
    private TextMeshProUGUI _startButtonText;
    [SerializeField]
    private TMP_InputField _gridXIField;
    [SerializeField]
    private TMP_InputField _gridYIField;
    [SerializeField]
    private TMP_InputField _speedIField;
    [SerializeField]
    private TMP_InputField _alivePercentIField;
    [SerializeField]
    private TMP_Dropdown _colorDropDown;

    private const string Restart = "Restart";

    public void SetOnClickStartButton(Action onClickStartButton)
    {
        _onClickStartButton = onClickStartButton;
    }

    public void OnClickStartButton()
    {
        _onClickStartButton.Invoke();
        _startButtonText.text = Restart;
    }

    public void SetMenu(MenuViewBuilder menuViewBuilder)
    {
        menuViewBuilder.GridXIField = _gridXIField;
        menuViewBuilder.GridYIField = _gridYIField;
        menuViewBuilder.SpeedIField = _speedIField;
        menuViewBuilder.AlivePercentIField = _alivePercentIField;
        menuViewBuilder.ColorDropDown = _colorDropDown;
        menuViewBuilder.Build();
    }

    public GameManagerBuilder GetMenuModelBuilder => new()
    {
        BlockColor = _colorDropDown.value.ToString(),
        AlivePercent = _alivePercentIField.text,
        Speed = _speedIField.text,
        GridWidth = _gridXIField.text,
        GridHeight = _gridYIField.text
    };
}
