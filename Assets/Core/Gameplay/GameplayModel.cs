using UnityEngine;
using Zenject;
public class GameplayModel : IGameplayModel
{
    private float _timer = 0;
    private bool _isStartGame = false;

    [Inject]
    private readonly IPopulationManager _populationManager;

    public void StartGame()
    {
        //do not change order
        _populationManager.Init();
        _isStartGame = true;
    }

    public void Tick()
    {
        if (!_isStartGame)
        {
            return;
        }

        if (_timer >= GameManager.Speed)
        {
            _timer = 0;
            _populationManager.PopulationControl();
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }
}
