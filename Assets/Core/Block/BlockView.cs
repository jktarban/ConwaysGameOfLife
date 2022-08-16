using UnityEngine;

public class BlockView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
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
}
