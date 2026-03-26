using Microsoft.EntityFrameworkCore;
using Playground.Data;
using Playground.Models;

namespace Playground.Services;

public class GameService
{
    private readonly ApplicationDbContext _context;

    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Game>> GetAllGames()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game?> GetGameById(int id)
    {
        return await _context.Games.FindAsync(id);
    }
    public async Task AddGame(Game game, int userId)
    {
        game.UserId = userId;
        game.UploadedAt = DateTime.UtcNow;
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Game>> GetGamesByUserId(int userId)
    {
        return await _context.Games.Where(g => g.UserId == userId).ToListAsync();
    }

    public async Task DeleteGame(int gameId, int userId)
    {
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId && g.UserId == userId);
        if (game != null)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}