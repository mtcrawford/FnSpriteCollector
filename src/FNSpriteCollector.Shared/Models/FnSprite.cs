namespace FNSpriteCollector.Shared.Models;

public class FnSprite
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public SpriteRarity Rarity { get; set; }
    public SpriteVariant Variant { get; set; }
    public SpriteFamily Family { get; set; }
    public string ImageBase64 { get; set; } = string.Empty;

    public bool IsReleased { get; set; } = true;
}

