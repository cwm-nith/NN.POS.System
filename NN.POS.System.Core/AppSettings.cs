namespace NN.POS.System.Core;

public class AppSettings
{
    public Database Database { get; set; } = new();
    public JwtSetting Jwt { get; set; } = new();
}

public class JwtSetting
{
    public int ExpiryInMinutes { get; set; }

    public string SigningKey { get; set; } = string.Empty;

    public string Site { get; set; } = string.Empty;

    public string Audience { get; set; } = string.Empty;
}

public class Database
{
    public string ConnectionString { get; set; } = string.Empty;
}