using UnityEngine;

public class BlockModel: IBlockModel
{
    public bool IsAlive { get; set; } = false;
    public int NumNeighbors { get; set; } = 0;

    //0-100% range to return is alive
    public bool GetRandomIsAlive
    {
        get
        {
            IsAlive = Random.value > (1 - (GameManager.AlivePercent / 100));
            return IsAlive;
        }
    }
}
