using UnityEngine;

public class BlockModel
{
    public bool IsAlive { get; set; } = false;
    public int NumNeighbors { get; set; } = 0;

    public bool GetRandomIsAlive
    {
        get
        {
            IsAlive = Random.value > (1 - (GameManager.AlivePercent / 100));
            return IsAlive;
        }
    }
}
