using EncurtaAI.API.Contexts;
using EncurtaAI.API.DTOs.Responses;
using EncurtaAI.API.Entities;
using EncurtaAI.API.Repositories.Contracts;
using EncurtaAI.API.Utils;
using Microsoft.EntityFrameworkCore;

namespace EncurtaAI.API.Repositories;

public class URLRepository : IURLRepository
{
    private readonly DataContext _context;

    public URLRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<CreateShortURLResponse> CreateURL(string URL, string baseURL)
    {
        var newLink = new Link(
            URL,
            ShortURLGenerator.GenerateShortURL()
        );

        await _context.Links.AddAsync(newLink);
        await _context.SaveChangesAsync();

        return new CreateShortURLResponse(
            newLink.Id, 
            newLink.URL, 
            $"{baseURL}{newLink.ShortURL}", 
            newLink.ExpirationDate
        );
    }

    public async Task<string?> GetURLByShortURL(string ShortURL)
    {
        var URL = await _context.Links.FirstOrDefaultAsync(x => x.ShortURL == ShortURL);

        if (URL == null)
        {
            return null;
        }

        if (URL.ExpirationDate < DateTime.UtcNow)
        {
            throw new Exception("Expired URL.");
        }

        return URL.URL;
    }
}
