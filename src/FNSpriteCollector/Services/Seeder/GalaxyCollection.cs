using FNSpriteCollector.Shared.Models;
using FNSpriteCollector.Shared;

namespace FNSpriteCollector.Services.Seeder;

internal class GalaxyCollection : SpriteCollection
{
    public GalaxyCollection(HttpClient http) : base(http)
    {
    }

    public async Task LoadSprites()
    {
        base.Sprites = new List<FnSprite>
        {
            new FnSprite
            {
                Id = SpriteId.Water,
                Name = "Galaxy Water",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Earth,
                Name = "Galaxy Earth",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Fire,
                Name = "Galaxy Fire",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Duck,
                Name = "Galaxy Duck",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Duck,
                ImageBase64 = await GetImageAsBase64Async("duck_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Ghost,
                Name = "Galaxy Ghost",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Dream,
                Name = "Galaxy Dream",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Punk,
                Name = "Galaxy Punk",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_King,
                Name = "Galaxy King",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Zero_Point,
                Name = "Galaxy Zero Point",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.ZeroPoint,
                ImageBase64 = await GetImageAsBase64Async("zeropoint_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Demon,
                Name = "Galaxy Demon",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Demon,
                ImageBase64 = await GetImageAsBase64Async("demon_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Grim,
                Name = "Galaxy Grim",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Fishy,
                Name = "Galaxy Fishy",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Striker,
                Name = "Galaxy Striker",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Aura,
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Aura,
                ImageBase64 = await GetImageAsBase64Async("aura_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Boss,
                Name = "Galaxy Boss",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_galaxy.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Galaxy_Grim,
                Name = "Galaxy Grim",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_galaxy.webp")
            },
        };
    }
}
