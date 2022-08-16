using System;
using UnityEngine;
public class BlockView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public BlockManager BlockManager { get; set; }

    public void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void SetSpriteEnabled(bool isEnabled)
    {
        _spriteRenderer.enabled = isEnabled;
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    internal void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }
}
