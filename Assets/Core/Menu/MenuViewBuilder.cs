using System.Collections.Generic;
using TMPro;

public class MenuViewBuilder: IMenuViewBuilder
{
    public TMP_InputField GridXIField { get; set; }
    public TMP_InputField GridYIField { get; set; }
    public TMP_InputField SpeedIField { get; set; }
    public TMP_InputField AlivePercentIField { get; set; }
    public TMP_Dropdown ColorDropDown { get; set; }

    public string GridXText { get; set; }
    public string GridYText { get; set; }
    public string SpeedText { get; set; }
    public string AlivePercentText { get; set; }
    public List<string> ColorOptions { get; set; }

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
