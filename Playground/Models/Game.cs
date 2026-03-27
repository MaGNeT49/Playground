namespace Playground.Models;

public class Game
{
    public int? UserId { get; set; }
    public User? User { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? CoverUrl { get; set; }
    public string? BannerUrl { get; set; }
    public GameType Type { get; set; }
    public string? DownloadUrl { get; set; }
    public string? PlayUrl { get; set; }
    public List<string> Tags { get; set; } = new();
    public DateTime UploadedAt { get; set; }
}

public enum GameType
{
    Build,
    Browser
}