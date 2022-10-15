using System.Collections.Generic;
using TMPro;

public interface IMenuViewBuilder: IBuilder
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
}
