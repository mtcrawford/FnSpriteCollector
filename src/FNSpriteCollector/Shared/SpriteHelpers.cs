using static System.Net.WebRequestMethods;

namespace FNSpriteCollector.Shared;

public class SpriteHelpers
{
    public static string GetRarityColor(SpriteRarity sprite)
    {
        switch (sprite)
        {
            case SpriteRarity.Rare:
                return "rare";
            case SpriteRarity.Epic:
                return "epic";
            case SpriteRarity.Legendary:
                return "legendary";
            case SpriteRarity.Special:
                return "special";
            case SpriteRarity.Mythic:
                return "mythic";
            default:
                return "rare";
        }
    }
}
