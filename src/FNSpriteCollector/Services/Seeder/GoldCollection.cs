using FNSpriteCollector.Shared.Models;
using FNSpriteCollector.Shared;

namespace FNSpriteCollector.Services.Seeder;

internal class GoldCollection : SpriteCollection
{
    public GoldCollection(HttpClient http) : base(http)
    {
    }

    public async Task LoadSprites()
    {
        base.Sprites = new List<FnSprite>
        {
        new FnSprite
            {
                Id = SpriteId.Gold_Water,
                Name = "Gold Water",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Earth,
                Name = "Gold Earth",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Fire,
                Name = "Gold Fire",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Duck,
                Name = "Gold Duck",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Duck,
                ImageBase64 = await GetImageAsBase64Async("duck_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Ghost,
                Name = "Gold Ghost",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Dream,
                Name = "Gold Dream",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Punk,
                Name = "Gold Punk",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_King,
                Name = "Gold King",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Zero_Point,
                Name = "Gold Zero Point",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.ZeroPoint,
                ImageBase64 = await GetImageAsBase64Async("zeropoint_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Demon,
                Name = "Gold Demon",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Demon,
                ImageBase64 = await GetImageAsBase64Async("demon_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Fishy,
                Name = "Gold Fishy",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Striker,
                Name = "Gold Striker",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Aura,
                Name = "Gold Aura",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Aura,
                ImageBase64 = await GetImageAsBase64Async("aura_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Boss,
                Name = "Gold Boss",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Grim,
                Name = "Gold Grim",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Air,
                Name = "Gold Air",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Air,
                ImageBase64 = await GetImageAsBase64Async("air_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Seven,
                Name = "Gold Seven",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Seven,
                ImageBase64 = await GetImageAsBase64Async("seven_gold.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gold_Batman,
                Name = "Gold Batman",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Batman,
                ImageBase64 = await GetImageAsBase64Async("batman_gold.webp")
            },
        };
    }
}
