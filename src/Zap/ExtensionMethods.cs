using MySqlConnector;

namespace Zap;

public static class ExtensionMethods
{
    public static MySqlParameter Add(this MySqlParameterCollection collection, string? name, object? value)
    {
        MySqlParameter parameter = new MySqlParameter(name, value);
        return collection.Add(parameter);
    }
}