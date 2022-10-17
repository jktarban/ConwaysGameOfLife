using UnityEngine;
public class BlockView : MonoBehaviour, IBlockView
{
    private SpriteRenderer _spriteRenderer;
    public IBlockManager BlockManager { get; set; }

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

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }
}
