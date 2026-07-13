using FNSpriteCollector.Shared.Models;

namespace FNSpriteCollector.Services.Seeder;

internal class SpriteCollection
{
    private readonly HttpClient _http;

    public List<FnSprite> Sprites { get; protected set; } = new();

    public SpriteCollection(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> GetImageAsBase64Async(string imageName)
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
