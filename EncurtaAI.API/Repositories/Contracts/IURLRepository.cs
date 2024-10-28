using EncurtaAI.API.DTOs.Responses;

namespace EncurtaAI.API.Repositories.Contracts;

public interface IURLRepository
{
    Task<CreateShortURLResponse> CreateURL(string URL, string baseURL);
    Task<string?> GetURLByShortURL(string ShortURL);
}
