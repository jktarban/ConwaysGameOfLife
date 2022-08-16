using System;
using System.Collections.Generic;
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

    public void SetOnClickStartButton(Action onClickStartButton)
    {
        _onClickStartButton = onClickStartButton;
    }

    public void OnClickStartButton()
    {
        _onClickStartButton.Invoke();
        _startButtonText.text = "Restart";
    }

    public void SetGridXIField(string gridXText)
    {
        _gridXIField.text = gridXText;
    }

    public void SetGridYIField(string gridYText)
    {
        _gridYIField.text = gridYText;
    }

    public void SetSpeedIField(string speedText)
    {
        _speedIField.text = speedText;
    }

    public void SetAlivePercentIField(string alivePercentText)
    {
        _alivePercentIField.text = alivePercentText;
    }

    public void SetColorDropDown(List<string> colorOptions)
    {
        _colorDropDown.ClearOptions();
        _colorDropDown.AddOptions(colorOptions);
    }

    public string GetGridWidth => _gridXIField.text;
    public string GetGridHeight => _gridYIField.text;
    public string GetSpeed => _speedIField.text;
    public string GetAlivePercent => _alivePercentIField.text;
    public string GetColor => _colorDropDown.value.ToString();
}
