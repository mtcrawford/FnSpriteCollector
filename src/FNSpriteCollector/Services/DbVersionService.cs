namespace FNSpriteCollector.Services;

internal class DbVersionService
{
    private readonly IndexedDbService _db;
    private const string DbVersionStoreName = "SpritesDbVersion";

    public DbVersionInfo DbVersion { get; private set; } = new();

    public DbVersionService(IndexedDbService db)
    {
        _db = db;
    }

    public async Task InitializeAsync()
    {
        Console.WriteLine("Initializing DbVersionService....");

        // Open the database (this will create it if it doesn't exist)
        var versionInfo = await _db.GetAllAsync<DbVersionInfo>(DbVersionStoreName);

        if (versionInfo.Count > 0)
        {
            DbVersion = versionInfo.MaxBy(v => v.Version);
        }
    }

    public async Task UpdateVersion(DbVersionInfo versionInfo)
    {
        Console.WriteLine("Updating database version from {0} ({1}) to {2} ({3})....",
            DbVersion.Version, DbVersion.SpriteCount, versionInfo.Version, versionInfo.SpriteCount);

        await ClearVersions();

        Console.WriteLine("Storing new version info....");
        await _db.SetItemAsync(DbVersionStoreName, versionInfo.ToString(), versionInfo);

        DbVersion = versionInfo;
    }

    private async Task ClearVersions()
    {
        await _db.ClearStoreAsync(DbVersionStoreName);
    }
}
