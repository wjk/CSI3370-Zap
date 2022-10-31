using MySqlConnector;

namespace Zap.Services;

public sealed class DatabaseConnection
{
    public MySqlConnection Open()
    {
        MySqlConnection connection = new MySqlConnection(
            "Server=localhost;" +
            "Database=Zap;" +
            "User=Zap;" +
            "Password=Zap1234;"
        );
        
        connection.Open();
        return connection;
    }
}