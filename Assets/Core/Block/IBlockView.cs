using UnityEngine;

public interface IBlockView: IInit, ISetParent, ISetPosition
{
    IBlockManager BlockManager { get; set; }
    void SetColor(Color color);
    void SetSpriteEnabled(bool isEnabled);
}
