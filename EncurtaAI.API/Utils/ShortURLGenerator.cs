namespace EncurtaAI.API.Utils;

public static class ShortURLGenerator
{
    public static string GenerateShortURL()
    {
        string shortURL = Guid.NewGuid().ToString("N").ToUpper().Substring(0, 10);

        return shortURL;
    }
}
