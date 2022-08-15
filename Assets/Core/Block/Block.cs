using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool IsAlive = false;
    public int NumNeighbors = 0;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAlive(bool isAlive)
    {
        IsAlive = isAlive;

        _spriteRenderer.enabled = IsAlive;
    }
}
