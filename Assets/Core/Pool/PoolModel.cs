using System;
using UnityEngine;

public class PoolModel
{
    public void Reset(Transform container)
    {
        foreach (Transform child in container)
        {
            if (child.gameObject.activeInHierarchy)
            {
                child.GetComponent<BlockManager>().IsAlive = false;
                child.gameObject.SetActive(false);
            }
          
        }
    }
}
