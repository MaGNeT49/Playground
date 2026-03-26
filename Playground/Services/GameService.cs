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
}