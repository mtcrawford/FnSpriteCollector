using FNSpriteCollector.Models;
using FNSpriteCollector.Shared;

namespace FNSpriteCollector.Services;

public class SpriteSeederDTO
{
    const int _itemCount = 61; // Total number of sprites to seed

    private readonly HttpClient _http;
    private readonly SpriteDbService _spriteService;

    public SpriteSeederDTO(HttpClient http, SpriteDbService spriteService)
    {
        _http = http;
        _spriteService = spriteService;
    }

    public async Task SeedInitialSpritesAsync()
    {
        await _spriteService.LoadSpritesAsync();

        if (_spriteService.Sprites.Count == _itemCount)
        { 
            Console.WriteLine("No Seeding Required."); 
            return; 
        } // Already seeded 

        var initialSprites = new List<FnSprite>
        {
            new FnSprite
            {
                Id = 1,
                Name = "Water",
                Rarity  = SpriteRarity.Rare,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_base.webp")
            },
            new FnSprite
            {
                Id = 2,
                Name = "Earth",
                Rarity = SpriteRarity.Rare,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_base.webp")
            },
            new FnSprite
            {
                Id = 3,
                Name = "Fire",
                Rarity = SpriteRarity.Rare,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_base.webp")
            },
            new FnSprite
            {
                Id = 4,
                Name = "Duck",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Duck,
                ImageBase64 = await GetImageAsBase64Async("duck_base.webp")
            },
            new FnSprite
            {
                Id = 5,
                Name = "Ghost",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_base.webp")
            },
            new FnSprite
            {
                Id = 6,
                Name = "Dream",
                Rarity = SpriteRarity.Legendary,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_base.webp")
            },
            new FnSprite
            {
                Id = 7,
                Name = "Punk",
                Rarity = SpriteRarity.Legendary,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_base.webp")
            },
            new FnSprite
            {
                Id = 8,
                Name = "King",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_base.webp")
            },
            new FnSprite
            {
                Id = 9,
                Name = "Zero Point",
                Rarity = SpriteRarity.Mythic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.ZeroPoint,
                ImageBase64 = await GetImageAsBase64Async("zeropoint_base.webp")
            },
            new FnSprite
            {
                Id = 10,
                Name = "Demon",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Demon,
                ImageBase64 = await GetImageAsBase64Async("demon_base.webp")
            },
            new FnSprite
            {
                Id = 11,
                Name = "Burnt Peanut",
                Rarity = SpriteRarity.Mythic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.BurntPeanut,
                ImageBase64 = await GetImageAsBase64Async("peanut_base.webp")
            },
            new FnSprite
            {
                Id = 12,
                Name = "Gold Water",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_gold.webp")
            },
            new FnSprite
            {
                Id = 13,
                Name = "Gold Earth",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_gold.webp")
            },
            new FnSprite
            {
                Id = 14,
                Name = "Gold Fire",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_gold.webp")
            },
            new FnSprite
            {
                Id = 15,
                Name = "Gold Duck",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Duck,
                ImageBase64 = await GetImageAsBase64Async("duck_gold.webp")
            },
            new FnSprite
            {
                Id = 16,
                Name = "Gold Ghost",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_gold.webp")
            },
            new FnSprite
            {
                Id = 17,
                Name = "Gold Dream",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_gold.webp")
            },
            new FnSprite
            {
                Id = 18,
                Name = "Gold Punk",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_gold.webp")
            },
            new FnSprite
            {
                Id = 19,
                Name = "Gold King",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_gold.webp")
            },
            new FnSprite
            {
                Id = 20,
                Name = "Gold Zero Point",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.ZeroPoint,
                ImageBase64 = await GetImageAsBase64Async("zeropoint_gold.webp")
            },
            new FnSprite
            {
                Id = 21,
                Name = "Gold Demon",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Demon,
                ImageBase64 = await GetImageAsBase64Async("demon_gold.webp")
            },
            new FnSprite
            {
                Id = 22,
                Name = "Gummy Water",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_candy.webp")
            },
            new FnSprite
            {
                Id = 23,
                Name = "Gummy Earth",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_candy.webp")
            },
            new FnSprite
            {
                Id = 24,
                Name = "Gummy Fire",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_candy.webp")
            },
            new FnSprite
            {
                Id = 25,
                Name = "Gummy Duck",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Duck,
                ImageBase64 = await GetImageAsBase64Async("duck_candy.webp")
            },
            new FnSprite
            {
                Id = 26,
                Name = "Gummy Ghost",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_candy.webp")
            },
            new FnSprite
            {
                Id = 27,
                Name = "Gummy Dream",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_candy.webp")
            },
            new FnSprite
            {
                Id = 28,
                Name = "Gummy Punk",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_candy.webp")
            },
            new FnSprite
            {
                Id = 29,
                Name = "Gummy King",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_candy.webp")
            },
            new FnSprite
            {
                Id = 30,
                Name = "Gummy Zero Point",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.ZeroPoint,
                ImageBase64 = await GetImageAsBase64Async("zeropoint_candy.webp")
            },
            new FnSprite
            {
                Id = 31,
                Name = "Gummy Demon",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Demon,
                ImageBase64 = await GetImageAsBase64Async("demon_candy.webp")
            },
            new FnSprite
            {
                Id = 32,
                Name = "Galaxy Water",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Water,
                ImageBase64 = await GetImageAsBase64Async("water_galaxy.webp")
            },
            new FnSprite
            {
                Id = 33,
                Name = "Galaxy Earth",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Earth,
                ImageBase64 = await GetImageAsBase64Async("earth_galaxy.webp")
            },
            new FnSprite
            {
                Id = 34,
                Name = "Galaxy Fire",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Fire,
                ImageBase64 = await GetImageAsBase64Async("fire_galaxy.webp")
            },
            new FnSprite
            {
                Id = 35,
                Name = "Galaxy Duck",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Duck,
                ImageBase64 = await GetImageAsBase64Async("duck_galaxy.webp")
            },
            new FnSprite
            {
                Id = 36,
                Name = "Galaxy Ghost",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Ghost,
                ImageBase64 = await GetImageAsBase64Async("ghost_galaxy.webp")
            },
            new FnSprite
            {
                Id = 37,
                Name = "Galaxy Dream",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Dream,
                ImageBase64 = await GetImageAsBase64Async("dream_galaxy.webp")
            },
            new FnSprite
            {
                Id = 38,
                Name = "Galaxy Punk",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Punk,
                ImageBase64 = await GetImageAsBase64Async("punk_galaxy.webp")
            },
            new FnSprite
            {
                Id = 39,
                Name = "Galaxy King",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.King,
                ImageBase64 = await GetImageAsBase64Async("king_galaxy.webp")
            },
            new FnSprite
            {
                Id = 40,
                Name = "Galaxy Zero Point",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.ZeroPoint,
                ImageBase64 = await GetImageAsBase64Async("zeropoint_galaxy.webp")
            },
            new FnSprite
            {
                Id = 41,
                Name = "Galaxy Demon",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Demon,
                ImageBase64 = await GetImageAsBase64Async("demon_galaxy.webp")
            },

            // Fishy
            new FnSprite
            {
                Id = 42,
                Name = "Fishy",
                Rarity = SpriteRarity.Rare,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_base.webp")
            },
            new FnSprite
            {
                Id = 43,
                Name = "Gold Fishy",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_gold.webp")
            },
            new FnSprite
            {
                Id = 44,
                Name = "Gummy Fishy",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_candy.webp")
            },
            new FnSprite
            {
                Id = 45,
                Name = "Galaxy Fishy",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Fishy,
                ImageBase64 = await GetImageAsBase64Async("fishy_galaxy.webp")
            },

            // Striker
            new FnSprite
            {
                Id = 46,
                Name = "Striker",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_base.webp")
            },
            new FnSprite
            {
                Id = 47,
                Name = "Gold Striker",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_gold.webp")
            },
            new FnSprite
            {
                Id = 48,
                Name = "Gummy Striker",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_candy.webp")
            },
            new FnSprite
            {
                Id = 49,
                Name = "Galaxy Striker",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Striker,
                ImageBase64 = await GetImageAsBase64Async("striker_galaxy.webp")
            },

            // Aura
            new FnSprite
            {
                Id = 50,
                Name = "Aura",
                Rarity = SpriteRarity.Epic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Aura,
                ImageBase64 = await GetImageAsBase64Async("aura_base.webp")
            },
            new FnSprite
            {
                Id = 51,
                Name = "Gold Aura",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Aura,
                ImageBase64 = await GetImageAsBase64Async("aura_gold.webp")
            },
            new FnSprite
            {
                Id = 52,
                Name = "Gummy Aura",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Aura,
                ImageBase64 = await GetImageAsBase64Async("aura_candy.webp")
            },
            new FnSprite
            {
                Id = 53,
                Name = "Galaxy Aura",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Aura,
                ImageBase64 = await GetImageAsBase64Async("aura_galaxy.webp")
            },

            // Boss
            new FnSprite
            {
                Id = 54,
                Name = "Boss",
                Rarity = SpriteRarity.Legendary,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_base.webp")
            },
            new FnSprite
            {
                Id = 55,
                Name = "Gold Boss",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_gold.webp")
            },
            new FnSprite
            {
                Id = 56,
                Name = "Gummy Boss",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_candy.webp")
            },
            new FnSprite
            {
                Id = 57,
                Name = "Galaxy Boss",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Boss,
                ImageBase64 = await GetImageAsBase64Async("boss_galaxy.webp")
            },

            // Grim
            new FnSprite
            {
                Id = 58,
                Name = "Grim",
                Rarity = SpriteRarity.Mythic,
                Variant = SpriteVariant.Base,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_base.webp")
            },
            new FnSprite
            {
                Id = 59,
                Name = "Gold Grim",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Gold,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_gold.webp")
            },
            new FnSprite
            {
                Id = 60,
                Name = "Gummy Grim",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Candy,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_candy.webp")
            },
            new FnSprite
            {
                Id = 61,
                Name = "Galaxy Grim",
                Rarity = SpriteRarity.Special,
                Variant = SpriteVariant.Galaxy,
                Family = SpriteFamily.Grim,
                ImageBase64 = await GetImageAsBase64Async("grim_galaxy.webp")
            },

        };

        Console.WriteLine("Seeding Sprites....");
        
        foreach (var sprite in initialSprites)
        {
            await _spriteService.AddSpriteAsync(sprite);
        }

        await SeedInitialOwnedSpritesAsync();
    }

    private async Task SeedInitialOwnedSpritesAsync()
    {
        await _spriteService.LoadOwnedSpritesAsync();

        if (_spriteService.OwnedSprites.Count == _itemCount)
        { return; }

        Console.WriteLine("Seeding Owned Sprites....");

        for (int i = 1; i <= _itemCount; i++)
        {
            bool owned = _spriteService.OwnedSprites.Exists(s => s.Id == i);

            if (!owned)
            {
                var ownedSprite = new OwnedSprite
                {
                    Id = i,
                    Level = 1,
                    IsOwned = false,
                    IsMax = false,
                    IsAlive = true
                };

                await _spriteService.AddOwnedSpriteAsync(ownedSprite);
            }
        }
    }


    private async Task<string> GetImageAsBase64Async(string imageName)
    {
        var imageUrl = $"/images/{imageName}"; // Assuming images are in wwwroot/images

        try
        {
            using var response = await _http.GetAsync(imageUrl);
            response.EnsureSuccessStatusCode();

            var bytes = await response.Content.ReadAsByteArrayAsync();
            var base64 = Convert.ToBase64String(bytes);
            var mimeType = GetMimeType(imageUrl);
            return $"data:{mimeType};base64,{base64}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load image {imageUrl}: {ex.Message}");
            return string.Empty; // Fallback if image fails
        }
    }

    private string GetMimeType(string fileName)
    {
        return fileName.ToLower().EndsWith(".webp") ? "image/webp" :
               fileName.ToLower().EndsWith(".png") ? "image/png" :
               fileName.ToLower().EndsWith(".jpg") || fileName.ToLower().EndsWith(".jpeg") ? "image/jpeg" :
               "image/png";
    }
}
