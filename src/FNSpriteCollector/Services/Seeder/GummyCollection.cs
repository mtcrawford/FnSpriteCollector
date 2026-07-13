using FNSpriteCollector.Models;
using FNSpriteCollector.Shared;

namespace FNSpriteCollector.Services.Seeder;

internal class GummyCollection : SpriteCollection
{
    public GummyCollection(HttpClient http) : base(http) 
    {                    
    }

    public async Task LoadSprites()
    {
        base.Sprites = new List<FnSprite>
        {
            new FnSprite
            {
                Id = SpriteId.Gummy_Water,
                Name = "Gummy Water",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Earth,
                Name = "Gummy Earth",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Fire,
                Name = "Gummy Fire",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Duck,
                Name = "Gummy Duck",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Duck,
                ImageBase64 = await GetImageAsBase64Async("duck_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Ghost,
                Name = "Gummy Ghost",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Dream,
                Name = "Gummy Dream",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Punk,
                Name = "Gummy Punk",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_King,
                Name = "Gummy King",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Zero_Point,
                Name = "Gummy Zero Point",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.ZeroPoint,
                ImageBase64 = await GetImageAsBase64Async("zeropoint_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Demon,
                Name = "Gummy Demon",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Demon,
                ImageBase64 = await GetImageAsBase64Async("demon_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Fishy,
                Name = "Gummy Fishy",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Striker,
                Name = "Gummy Striker",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Aura,
                Name = "Gummy Aura",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Aura,
                ImageBase64 = await GetImageAsBase64Async("aura_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Boss,
                Name = "Gummy Boss",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_candy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Gummy_Grim,
                Name = "Gummy Grim",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_candy.webp")
            },
        };
    }   
}
