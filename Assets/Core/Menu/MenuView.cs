using System;
using UnityEngine;
using TMPro;

public class MenuView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI startButtonText;
    private Action _onClickStartButton;

    public void SetOnClickStartButton(Action onClickStartButton)
    {
        _onClickStartButton = onClickStartButton;
    }

    public void OnClickStartButton()
    {
        _onClickStartButton.Invoke();
        startButtonText.text = "Restart";
    }
}
