using FNSpriteCollector.Shared;
using FNSpriteCollector.Shared.Models;

namespace FNSpriteCollector.Services.Seeder;

internal class CubeCollection : SpriteCollection
{
    public CubeCollection(HttpClient http) : base(http)
    { }

    public async Task LoadSprites()
    {
        base.Sprites = new List<FnSprite>
        {
            new FnSprite
            {
                Id = SpriteId.Cube_Batman,
                Name = "Cube Batman",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Cube,
                Family = SpriteFamily.Batman,
                ImageBase64 = await GetImageAsBase64Async("batman_cube.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Cube_Earth,
                Name = "Cube Earth",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Cube,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_cube.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Cube_Fire,
                Name = "Cube Fire",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Cube,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_cube.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Cube_Dream,
                Name = "Cube Dream",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Cube,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_cube.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Cube_Punk,
                Name = "Cube Punk",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Cube,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_cube.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Cube_Fishy,
                Name = "Cube Fishy",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Cube,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_cube.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Cube_Boss,
                Name = "Cube Boss",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Cube,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_cube.webp")
            },
            new FnSprite
            {
                Id = SpriteId.Cube_Grim,
                Name = "Cube Grim",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Cube,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_cube.webp")
            },
        };
    }
}
