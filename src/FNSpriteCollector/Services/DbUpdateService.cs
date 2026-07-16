using FNSpriteCollector.Services.Seeder;
using FNSpriteCollector.Shared.Models;

namespace FNSpriteCollector.Services;

internal class DbUpdateService
{
    private DbVersionInfo _currentVersion = new DbVersionInfo
    { 
        Version = 1, 
        SpriteCount = 83 
    };

    private readonly HttpClient _http;
    private readonly SpriteDbService _spriteService;
    private readonly DbVersionService _dbVersionService;

    private DbVersionInfo _dbVersion = new();

    public List<FnSprite> Collection { get; private set; } = new List<FnSprite>();
    public List<SpriteDTO> Sprites { get; private set; } = new List<SpriteDTO>();

    public string Message { get; private set; } = string.Empty;

    public event Action? OnChange; // Event for UI updates    
    private void NotifyStateChanged() => OnChange?.Invoke();

    public DbUpdateService(HttpClient httpClient, SpriteDbService spriteService, DbVersionService dbVersionService)
    {
        _http = httpClient;
        _spriteService = spriteService;
        _dbVersionService = dbVersionService;
    }

    private void SetMessage(string message)
    {
        Message = message;
        Console.WriteLine(message);
        NotifyStateChanged();
    }

    public async Task<bool> CheckAndUpdateDbAsync()
    {
        await Task.Run(async() => {await GetDbVersionInfoAsync();});
        

        if (!CompareDb())
        {
            SetMessage("Updating Database....");

            await Task.Run(async () => { await LoadCollection(); });

            await _spriteService.InitializeAsync();
            await LoadSpritesAsync();

            await UpdateSpriteCollectionAsync();
            await SeedInitialOwnedSpritesAsync();

            await _dbVersionService.UpdateVersion(_currentVersion);

            SetMessage($"Database Updated to Version {_currentVersion.Version}, Sprite Count {_currentVersion.SpriteCount}");
        }
        else
        {
            SetMessage("Database is up to date.");
        }

        return true;
    }

    private async Task UpdateSpriteCollectionAsync()
    {
        SetMessage("Updating Sprites....");

        bool updateSprite = VersionCheck();

        int spritesAdded = 0;
        int spritesUpdated = 0;

        foreach (var sprite in Collection)
        {
            bool exists = Sprites.Exists(s => s.SpriteData.Id == sprite.Id);

            if (!exists)
            {
                SetMessage("Adding Sprite: " + sprite.Name);
                await _spriteService.AddSpriteAsync(sprite);
                spritesAdded++;
            }
            else if (exists && updateSprite)
            {
                SetMessage("Updating Sprite: " + sprite.Name);
                await _spriteService.UpdateSpriteAsync(sprite, false);
                spritesUpdated++;
            }
        }

        SetMessage($"Finished updating sprites. Added {spritesAdded} new sprites. Updated {spritesUpdated} existing sprites.");
    }

    private bool VersionCheck()
    { 
        switch (_dbVersion.Version)
        {
            case 0:
                SetMessage("Detected Version 0. Initializing Database...");                
                return true;
            case >1:
                return false;
            default:
                SetMessage($"Unknown database version {_dbVersion.Version}. Updating Sprites.");
                return true;
        }
    }

    private async Task SeedInitialOwnedSpritesAsync()
    {
        if (_spriteService.OwnedSprites.Count == _currentVersion.SpriteCount)
        { return; }

        SetMessage("Seeding Owned Sprites....");
        
        for (int i = 1; i <= _currentVersion.SpriteCount; i++)
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

    // Load Db version info
    private async Task GetDbVersionInfoAsync()
    {
        SetMessage("Getting Database Version Info....");        

        await Task.Run(async() => { await _dbVersionService.InitializeAsync();});

        _dbVersion = _dbVersionService.DbVersion;

        SetMessage($"Database Version {_dbVersion.Version}, Sprite Count {_dbVersion.SpriteCount}");
    }

    private bool CompareDb()
    { 
        if (_dbVersion.Version != _currentVersion.Version 
            || _dbVersion.SpriteCount != _currentVersion.SpriteCount)
        {
            SetMessage($"Database is outdated. Current Version: {_currentVersion.Version}, Sprite Count: {_currentVersion.SpriteCount}. Database Version: {_dbVersion.Version}, Sprite Count: {_dbVersion.SpriteCount}");
            return false;
        }

        return true;
    }

    // Load sprites from db
    private async Task LoadSpritesAsync()
    {
        SetMessage("Loading Sprites from Database....");
        
        Sprites = _spriteService.SpritesCollection;

        SetMessage($"Sprites Loaded from Database ({Sprites.Count})");
    }

    // Load sprites from collections
    private async Task LoadCollection()
    {
        SetMessage("Loading Sprites from Collections....");

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

        Collection = new List<FnSprite>();
        Collection.AddRange(baseSprites.Sprites);
        Collection.AddRange(goldSprites.Sprites);
        Collection.AddRange(gummySprites.Sprites);
        Collection.AddRange(galaxySprites.Sprites);
        Collection.AddRange(holofoilSprites.Sprites);

        SetMessage($"Sprites Loaded from Collections ({Collection.Count})");
    }
}

internal record DbVersionInfo
{
    public int Version { get; init; } = 0;
    public int SpriteCount { get; set; } = 0;
}
