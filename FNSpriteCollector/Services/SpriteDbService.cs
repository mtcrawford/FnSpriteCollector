using FNSpriteCollector.Models;

namespace FNSpriteCollector.Services;

public class SpriteDbService
{
    private readonly IndexedDbService _db;
    private const string SpriteStoreName = "FNSprites";
    private const string OwnedStoreName = "OwnedSprites";

    public List<FnSprite> Sprites { get; private set; } = new();
    public List<OwnedSprite> OwnedSprites { get; private set; } = new();

    public List<SpriteDTO> SpritesCollection { get; set; } = new();

    // Event for UI updates
    public event Action? OnChange;  

    public SpriteDbService(IndexedDbService db)
    {
        _db = db;
    }

    public async Task InitializeAsync()
    {
        Console.WriteLine("Initializing SpriteDbService....");

        // Open the database (this will create it if it doesn't exist)
        await _db.GetAllAsync<FnSprite>(SpriteStoreName); // Ensures DB is initialized
        await _db.GetAllAsync<OwnedSprite>(OwnedStoreName); // Ensures DB is initialized

        await BuildCollection(); // Build the collection after initialization
    }

    public async Task LoadSpritesAsync()
    {
        Console.WriteLine("Loading Sprites....");

        Sprites = await _db.GetAllAsync<FnSprite>(SpriteStoreName);

        await LoadOwnedSpritesAsync();

        OnChange?.Invoke();
    }

    public async Task LoadOwnedSpritesAsync()
    {
        Console.WriteLine("Loading Owned Sprites....");
        OwnedSprites = await _db.GetAllAsync<OwnedSprite>(OwnedStoreName);

        await BuildCollection();

        OnChange?.Invoke();
    }

    public async Task AddSpriteAsync(FnSprite sprite)
    {
        await _db.SetItemAsync(SpriteStoreName, sprite.Id.ToString(), sprite);
        //await LoadSpritesAsync();        // Refresh list
    }

    public async Task AddOwnedSpriteAsync(OwnedSprite sprite)
    {
        await _db.SetItemAsync(OwnedStoreName, sprite.Id.ToString(), sprite);
        //await LoadOwnedSpritesAsync();        // Refresh list
    }
    
    public async Task UpdateSpriteAsync(SpriteDTO dto)
    {
        Console.WriteLine($"Updating sprite with ID {dto.OwnedData.Id}");

        await UpdateOwnedSpriteAsync(dto.OwnedData);

        OnChange?.Invoke();
    }

    public async Task UpdateSpriteAsync(FnSprite sprite)
    {
        Console.WriteLine($"Updating sprite with ID {sprite.Id}");

        await _db.SetItemAsync(SpriteStoreName, sprite.Id.ToString(), sprite);
        await LoadSpritesAsync();
    }

    public async Task UpdateOwnedSpriteAsync(OwnedSprite sprite)
    {
        Console.WriteLine($"Updating owned sprite with ID {sprite.Id}");

        await _db.SetItemAsync(OwnedStoreName, sprite.Id.ToString(), sprite);
        await LoadOwnedSpritesAsync();
    }

    public async Task DeleteSpriteAsync(int id)
    {
        await _db.DeleteItemAsync(SpriteStoreName, id.ToString());
        await LoadSpritesAsync();
    }

    public async Task DeleteOwnedSpriteAsync(int id)
    {
        await _db.DeleteItemAsync(OwnedStoreName, id.ToString());
        await LoadOwnedSpritesAsync();
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
                OwnedData = ownedSprite ?? new OwnedSprite { Id = sprite.Id}
            };

            SpritesCollection.Add(dto);
        }
    }
}
