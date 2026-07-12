using FNSpriteCollector.Models;
using FNSpriteCollector.Shared;

namespace FNSpriteCollector.Services.Seeder;

// Different classes for different sprite collections

internal class BaseCollection : SpriteCollection
{
    public BaseCollection(HttpClient http)
        : base(http) 
    { }

    public async Task LoadSprites()
    {
        base.Sprites = new List<FnSprite>
        {
            new FnSprite
            {
                Id = SpriteId.Water,
                Name = "Water",
                Rarity  = SpriteRarity.Rare,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Earth,
                Name = "Earth",
                Rarity = SpriteRarity.Rare,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Fire,
                Name = "Fire",
                Rarity = SpriteRarity.Rare,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Duck,
                Name = "Duck",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Duck,
                ImageBase64 = await GetImageAsBase64Async("duck_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Ghost,
                Name = "Ghost",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Dream,
                Name = "Dream",
                Rarity = SpriteRarity.Legendary,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Punk,
                Name = "Punk",
                Rarity = SpriteRarity.Legendary,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.King,
                Name = "King",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Zero_Point,
                Name = "Zero Point",
                Rarity = SpriteRarity.Mythic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.ZeroPoint,
                ImageBase64 = await GetImageAsBase64Async("zeropoint_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Demon,
                Name = "Demon",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Demon,
                ImageBase64 = await GetImageAsBase64Async("demon_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Burnt_Peanut,
                Name = "Burnt Peanut",
                Rarity = SpriteRarity.Mythic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.BurntPeanut,
                ImageBase64 = await GetImageAsBase64Async("peanut_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Fishy,
                Name = "Fishy",
                Rarity = SpriteRarity.Rare,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Striker,
                Name = "Striker",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Aura,
                Name = "Aura",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Aura,
                ImageBase64 = await GetImageAsBase64Async("aura_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Boss,
                Name = "Boss",
                Rarity = SpriteRarity.Legendary,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_base.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Grim,
                Name = "Grim",
                Rarity = SpriteRarity.Mythic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_base.webp")
            },
        };
    }
}
