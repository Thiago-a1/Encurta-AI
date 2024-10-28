using System;

namespace EncurtaAI.API.Entities;

public class Link
{
    private Link() {}

    public Link(string originalURL, string shortURL)
    {
        Id = Guid.NewGuid();
        URL = originalURL;
        ShortURL = shortURL;
        ExpirationDate = DateTime.UtcNow.AddDays(5);
    }

    public Guid Id { get; private set; }
    public string URL { get; private set; }
    public string ShortURL { get; private set; }
    public DateTime ExpirationDate { get; private set; }
}
