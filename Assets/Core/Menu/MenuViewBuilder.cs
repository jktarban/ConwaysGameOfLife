using System.Collections.Generic;
using TMPro;

public class MenuViewBuilder
{
    public TMP_InputField GridXIField;
    public TMP_InputField GridYIField;
    public TMP_InputField SpeedIField;
    public TMP_InputField AlivePercentIField;
    public TMP_Dropdown ColorDropDown;

    public string GridXText;
    public string GridYText;
    public string SpeedText;
    public string AlivePercentText;
    public List<string> ColorOptions;

    public void Build()
    {
        GridXIField.text = GridXText;
        GridYIField.text = GridYText;
        SpeedIField.text = SpeedText;
        AlivePercentIField.text = AlivePercentText;
        ColorDropDown.ClearOptions();
        ColorDropDown.AddOptions(ColorOptions);
    }
}
