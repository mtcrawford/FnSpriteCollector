namespace FNSpriteCollector.Shared.Models;

public class OwnedSprite
{
    public int Id { get; set; }
    public int Level { get; set; } = 0;
    public bool IsOwned { get; set; } = false;
    public bool IsMax { get; set; } = false;
    public bool IsAlive { get; set; } = true;
}
