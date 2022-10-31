using MySqlConnector;

namespace Zap.Models;

public sealed class Account
{
    public static Account? LookUp(string email, DatabaseConnection connection)
    {
        using MySqlConnection conn = connection.Open();
        using MySqlCommand command = new MySqlCommand("SELECT * FROM USER WHERE EMAIL = @email", conn);
        command.Parameters.Add(new MySqlParameter("@email", email));

        using var results = command.ExecuteReader();
        results.Read();
        if (!results.HasRows) return null; // user name not found

        Account account = new Account()
        {
            EmailAddress = results.GetString("EMAIL"),
            FirstName = results.GetString("FIRST_NAME"),
            LastName = results.GetString("LAST_NAME"),
            HashedPassword = results.GetString("HASHED_PASSWORD"),
        };

        bool moreRows = results.NextResult();
        if (moreRows)
        {
            results.Close();
            throw new InvalidOperationException($"More than one user for name '{email}'");
        }

        results.Close();
        return account;
    }

    public void SaveNew(DatabaseConnection connection)
    {
        using MySqlConnection conn = connection.Open();
        using MySqlCommand command = new MySqlCommand("INSERT INTO USER (EMAIL, FIRST_NAME, LAST_NAME, HASHED_PASSWORD)" +
                                                      "VALUES (@email, @fname, @lname, @pwd)", conn);
        command.Parameters.Add(new MySqlParameter("email", EmailAddress));
        command.Parameters.Add(new MySqlParameter("fname", FirstName));
        command.Parameters.Add(new MySqlParameter("lname", LastName));
        command.Parameters.Add(new MySqlParameter("pwd", HashedPassword));

        command.ExecuteNonQuery();
    }

    public string? EmailAddress { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? HashedPassword { get; set; }
}
