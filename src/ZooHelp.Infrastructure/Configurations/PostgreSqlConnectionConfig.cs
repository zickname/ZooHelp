namespace ZooHelp.Infrastructure.Configurations;

public sealed record PostgreSqlConnectionConfig
{
    public required string Host { get; init; }

    public required int Port { get; init; }

    public required string Database { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }

    public string GetConnectionString()
    {
        return $"Server={Host};" +
               $"Port={Port};" +
               $"Database={Database};" +
               $"User Id={Username};" +
               $"Password={Password};";
    }
}