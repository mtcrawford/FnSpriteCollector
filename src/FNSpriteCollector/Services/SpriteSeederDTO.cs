using FNSpriteCollector.Models;
using FNSpriteCollector.Shared;
using FNSpriteCollector.Services.Seeder;

namespace FNSpriteCollector.Services;

public class SpriteSeederDTO
{
    const int _itemCount = 66; // Total number of sprites to seed

    private readonly HttpClient _http;
    private readonly SpriteDbService _spriteService;

    public string Message { get; private set; } = string.Empty; // Message for UI feedback

    public event Action? OnChange; // Event for UI updates    
    private void NotifyStateChanged() => OnChange?.Invoke();

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
            Message = "No Seeding Required.";
            NotifyStateChanged();

            return; 
        } // Already seeded 

        var baseSprites = new BaseCollection(_http);
        var goldSprites = new GoldCollection(_http);
        var gummySprites = new GummyCollection(_http);
        var galaxySprites = new GalaxyCollection(_http);
        var holofoilSprites = new HolofoilCollection(_http);

        await baseSprites.LoadSprites();
        await goldSprites.LoadSprites();
        await gummySprites.LoadSprites();
        await galaxySprites.LoadSprites();
        await holofoilSprites.LoadSprites();

        var initialSprites = new List<FnSprite>();
        initialSprites.AddRange(baseSprites.Sprites);
        initialSprites.AddRange(goldSprites.Sprites);
        initialSprites.AddRange(gummySprites.Sprites);
        initialSprites.AddRange(galaxySprites.Sprites);
        initialSprites.AddRange(holofoilSprites.Sprites);

        Console.WriteLine("Seeding Sprites....");
        Message = "Seeding Sprites....";
        NotifyStateChanged();

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

        Message = "Seeding Owned Sprites....";
        NotifyStateChanged();

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
}
