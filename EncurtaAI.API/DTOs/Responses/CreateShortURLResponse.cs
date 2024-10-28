namespace EncurtaAI.API.DTOs.Responses;

public record CreateShortURLResponse(Guid Id, string URL, string ShortURL, DateTime ExpirationDate)
{
    public Guid Id { get; private set; } = Id;
    public string URL { get; private set; } = URL;
    public string ShortURL { get; private set; } = ShortURL;
    public DateTime ExpirationDate { get; private set; } = ExpirationDate;
}
