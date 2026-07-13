using FNSpriteCollector.Shared.Models;

namespace FNSpriteCollector.Services;

public class SpriteService
{
    private readonly LocalStorageService _storage;
    private const string SpriteStoreKey = "FNSprites";
    private const string OwnedStoreKey = "OwnedSprites";

    public List<FnSprite> Sprites { get; private set; } = new();
    public List<OwnedSprite> OwnedSprites { get; private set; } = new();

    public List<SpriteDTO> SpritesCollection { get; set; } = new();

    public event Action? OnChange;

    public SpriteService(LocalStorageService storage)
    {
        _storage = storage;
    }

    public async Task LoadSpritesAsync()
    {
        Console.WriteLine("Loading Sprites....");
        Sprites = await _storage.GetItemAsync<List<FnSprite>>(SpriteStoreKey)
                  ?? new List<FnSprite>();

        await LoadOwnedSpritesAsync();

        OnChange?.Invoke();
    }

    public async Task LoadOwnedSpritesAsync()
    {
        Console.WriteLine("Loading Owned Sprites....");

        OwnedSprites = await _storage.GetItemAsync<List<OwnedSprite>>(OwnedStoreKey)
                       ?? new List<OwnedSprite>();
        
        await BuildCollection();

        OnChange?.Invoke();
    }

    public async Task SaveSpritesAsync()
    {
        Console.WriteLine("Saving Sprites....");
        await _storage.SetItemAsync(SpriteStoreKey, Sprites);

        OnChange?.Invoke();
    }

    public async Task SaveOwnedSpritesAsync()
    {
        Console.WriteLine("Saving Owned Sprites....");
        await _storage.SetItemAsync(OwnedStoreKey, OwnedSprites);

        OnChange?.Invoke();
    }

    public async Task AddSpriteAsync(FnSprite sprite)
    {
        Sprites.Add(sprite);
        await SaveSpritesAsync();
    }

    public async Task AddOwnedSpriteAsync(OwnedSprite sprite)
    {
        OwnedSprites.Add(sprite);
        await SaveOwnedSpritesAsync();
    }

    public async Task UpdateSpriteAsync(SpriteDTO dto)
    {
        await UpdateOwnedSpriteAsync(dto.OwnedData);
        OnChange?.Invoke();
    }

    public async Task UpdateSpriteAsync(FnSprite updatedSprite)
    {
        var index = Sprites.FindIndex(s => s.Id == updatedSprite.Id);
        Console.WriteLine($"Updating sprite with ID {updatedSprite.Id} at index {index}");
        if (index >= 0)
        {
            Sprites[index] = updatedSprite;
            await SaveSpritesAsync();
        }
    }

    public async Task UpdateOwnedSpriteAsync(OwnedSprite updatedSprite)
    {
        var index = OwnedSprites.FindIndex(s => s.Id == updatedSprite.Id);
        Console.WriteLine($"Updating owned sprite with ID {updatedSprite.Id} at index {index}");
        if (index >= 0)
        {
            OwnedSprites[index] = updatedSprite;
            await SaveOwnedSpritesAsync();
        }

        await BuildCollection();
        //await LoadOwnedSpritesAsync();
    }

    public async Task ClearSpritesAsync()
    {
        Console.WriteLine("Clearing Sprites....");
        
        Sprites.Clear();
        SpritesCollection.Clear();

        await SaveSpritesAsync();
    }

    private async Task BuildCollection()
    {
        Console.WriteLine("Building Collection....");

        SpritesCollection.Clear();

        foreach (var sprite in Sprites)
        {
            var ownedSprite = OwnedSprites.FirstOrDefault(os => os.Id == sprite.Id);

            var dto = new SpriteDTO
            {
                SpriteData = sprite,
                OwnedData = ownedSprite ?? new OwnedSprite { Id = sprite.Id }
            };

            SpritesCollection.Add(dto);
        }
    }
}
