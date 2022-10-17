using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings",
                 menuName = "Conways/GameSettings")]
public class GameSettings : SingletonScriptableObject<GameSettings>
{
    [SerializeField]
    private int _defaultGridWidth;
    [SerializeField]
    private int _defaultGridHeight;
    [SerializeField]
    private float _defaultSpeed;
    [SerializeField]
    private float _defaultAlivePercent;
    [SerializeField]
    private int _underPopulationCount;
    [SerializeField]
    private int _overPopulationCount;
    [SerializeField]
    private int _cellSize;

    public int DefaultGridWidth => _defaultGridWidth;
    public int DefaultGridHeight => _defaultGridHeight;
    public float DefaultSpeed => _defaultSpeed;
    public float DefaultAlivePercent => _defaultAlivePercent;
    public int UnderPopulationCount => _underPopulationCount;
    public int OverPopulationCount => _overPopulationCount;
    public int CellSize => _cellSize;
}
