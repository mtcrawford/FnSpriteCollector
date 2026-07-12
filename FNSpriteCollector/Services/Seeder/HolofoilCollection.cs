using FNSpriteCollector.Models;
using FNSpriteCollector.Shared;

namespace FNSpriteCollector.Services.Seeder;

internal class HolofoilCollection : SpriteCollection
{
    public HolofoilCollection(HttpClient http) : base(http)    
    { }

    public  async Task LoadSprites()
    {
        base.Sprites = new List<FnSprite>
        {
            new FnSprite
            {
                Id = SpriteId.Holofoil_Water,
                Name = "Holofoil Water",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Holofoil,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_holofoil.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Holofoil_Fire,
                Name = "Holofoil Fire",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Holofoil,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_holofoil.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Holofoil_Ghost,
                Name = "Holofoil Ghost",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Holofoil,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_holofoil.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Holofoil_King,
                Name = "Holofoil King",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Holofoil,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_holofoil.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Holofoil_Striker,
                Name = "Holofoil Striker",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Holofoil,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_holofoil.webp")
            },
        };
    }
}
