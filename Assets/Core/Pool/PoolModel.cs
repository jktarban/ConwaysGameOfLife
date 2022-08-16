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
                child.GetComponent<BlockView>().BlockManager.IsAlive = false;
                child.gameObject.SetActive(false);
            }
          
        }
    }

    public IBlockManager GetFromPool(Transform container)
    {
        foreach (Transform child in container)
        {
            if (child.gameObject.activeInHierarchy)
            {
                continue;
            }
            child.gameObject.SetActive(true);
            return child.GetComponent<BlockView>().BlockManager;
        }

        return null;
    }
}
