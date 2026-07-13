using Microsoft.JSInterop;
using System.Text.Json;

namespace FNSpriteCollector.Services;

public class IndexedDbService : IAsyncDisposable
{
    private const string DB_NAME = "Sprites";
    private const int DB_VERSION = 2;

    private readonly IJSRuntime _js;
    private IJSObjectReference? _module;

    public IndexedDbService(IJSRuntime js)
    {
        _js = js;
    }

    private async Task EnsureModuleAsync()
    {
        //Console.WriteLine("Ensuring Module Async...");
        _module ??= await _js.InvokeAsync<IJSObjectReference>(
            "import", "./js/indexedDbHelper.js");

        await _module.InvokeVoidAsync("openDb", DB_NAME, DB_VERSION);
    }

    public async Task<T?> GetItemAsync<T>(string storeName, string key)
    {
        await EnsureModuleAsync();
        var json = await _module!.InvokeAsync<string?>("getItem", storeName, key);
        return json == null ? default : JsonSerializer.Deserialize<T>(json);
    }

    public async Task SetItemAsync<T>(string storeName, string key, T value)
    {
        await EnsureModuleAsync();
        var json = JsonSerializer.Serialize(value);
        await _module!.InvokeVoidAsync("setItem", storeName, key, json);
    }

    public async Task<List<T>> GetAllAsync<T>(string storeName)
    {
        await EnsureModuleAsync();
        var jsonArray = await _module!.InvokeAsync<string>("getAll", storeName);        
        return JsonSerializer.Deserialize<List<T>>(jsonArray) ?? new();
    }

    public async Task DeleteItemAsync(string storeName, string key)
    {
        await EnsureModuleAsync();
        await _module!.InvokeVoidAsync("deleteItem", storeName, key);
    }

    public async Task ClearStoreAsync(string storeName)
    {
        await EnsureModuleAsync();
        await _module!.InvokeVoidAsync("clearStore", storeName);
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is not null)
        {
            await _module.DisposeAsync();
        }
    }
}