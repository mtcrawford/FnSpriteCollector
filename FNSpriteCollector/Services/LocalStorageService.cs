using Microsoft.JSInterop;
using System.Text.Json;

namespace FNSpriteCollector.Services;

public class LocalStorageService
{
    private readonly IJSRuntime _js;

    public LocalStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async ValueTask<T?> GetItemAsync<T>(string key)
    {
        var json = await _js.InvokeAsync<string?>("localStorage.getItem", key);
        return json == null ? default : JsonSerializer.Deserialize<T>(json);
    }

    public async ValueTask SetItemAsync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value);
        await _js.InvokeVoidAsync("localStorage.setItem", key, json);
    }

    public async ValueTask RemoveItemAsync(string key)
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", key);
    }

    public async ValueTask ClearAsync()
    {
        await _js.InvokeVoidAsync("localStorage.clear");
    }
}
