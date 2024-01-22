using Application.Common.Interfaces;
using Application.Features.Users.Abstractions;
using Domain.Representatives;
using Domain.Users;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Infrastructure.Data;

/// <summary>
/// App db context using SqLite (in memory) for persistence.
/// </summary>
public class AppDbContext: IAppDbContext
{
    private SqliteConnection? _connection;
    private readonly IConfiguration _config;

    /// <summary>
    /// Initialize the memory database on constructor
    /// </summary>
    public AppDbContext(IConfiguration config)
    {
        _config = config;
        InitializeDatabase();
    }

    ~AppDbContext()
    {
        _connection?.Close();
    }

    /// <summary>
    /// Initialize database with the needed tables.
    /// </summary>
    void InitializeDatabase()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.Open();

        // Representatives table
        var repsTableSb = new StringBuilder("CREATE TABLE IF NOT EXISTS Representatives");
        repsTableSb.Append("(Id         INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ");
        repsTableSb.Append(" Name       TEXT NOT NULL,");
        repsTableSb.Append(" Email      TEXT,");
        repsTableSb.Append(" CellPhone  TEXT,");
        repsTableSb.Append(" Role       TEXT,");
        repsTableSb.Append(" Company    TEXT,");
        repsTableSb.Append(" Brands     TEXT,");
        repsTableSb.Append(" CreatedBy  TEXT,");
        repsTableSb.Append(" Created    INTEGER,");
        repsTableSb.Append(" ModifiedBy TEXT,");
        repsTableSb.Append(" Modified   INTEGER)");
        using var representativesCreateTable = new SqliteCommand(repsTableSb.ToString(), _connection);
        representativesCreateTable.ExecuteReader();

        // Users table
        var usersTableSb = new StringBuilder("CREATE TABLE IF NOT EXISTS Users");
        usersTableSb.Append("(UserName     TEXT NOT NULL PRIMARY KEY, ");
        usersTableSb.Append(" PasswordHash TEXT NOT NULL,");
        usersTableSb.Append(" Created      INTEGER)");
        using var usersCreateTable = new SqliteCommand(usersTableSb.ToString(), _connection);
        usersCreateTable.ExecuteReader();

        var seedDataString = _config["SeedData"];
        var seedData = false;
        if (!string.IsNullOrEmpty(seedDataString))
            seedData = Convert.ToBoolean(seedDataString);

        if (seedData)
        {
            var repString = "INSERT INTO Representatives (Name, Email, CellPhone, Role, Company, Brands) values (@Name, @Email, @CellPhone, @Role, @Company, @Brands);";
            using var dataCommand = new SqliteCommand(repString, _connection);
            dataCommand.Parameters.AddWithValue("@Name", "Shelly Smith");
            dataCommand.Parameters.AddWithValue("@CellPhone", "(217) 436-2287");
            dataCommand.Parameters.AddWithValue("@Email", "SSmith@lilly.com");
            dataCommand.Parameters.AddWithValue("@Role", "Sales Representative");
            dataCommand.Parameters.AddWithValue("@Company", "Eli Lilly");
            dataCommand.Parameters.AddWithValue("@Brands", "Trulicity, Verzenio, Emgality");
            dataCommand.ExecuteNonQuery();

            using var dataCommand2 = new SqliteCommand(repString, _connection);
            dataCommand2.Parameters.AddWithValue("@Name", "Terry Lawson");
            dataCommand2.Parameters.AddWithValue("@CellPhone", "(917) 446-0087");
            dataCommand2.Parameters.AddWithValue("@Email", "Terry@Bayer.com");
            dataCommand2.Parameters.AddWithValue("@Role", "Sales Representative");
            dataCommand2.Parameters.AddWithValue("@Company", "Bayer");
            dataCommand2.Parameters.AddWithValue("@Brands", "Glucobay, Adalat, Adempas");
            dataCommand2.ExecuteNonQuery();

            using var dataCommand3 = new SqliteCommand(repString, _connection);
            dataCommand3.Parameters.AddWithValue("@Name", "Emily Dickinson");
            dataCommand3.Parameters.AddWithValue("@CellPhone", "(314) 501-3342");
            dataCommand3.Parameters.AddWithValue("@Email", "Emily@Roche.com");
            dataCommand3.Parameters.AddWithValue("@Role", "Sales Representative");
            dataCommand3.Parameters.AddWithValue("@Company", "Roche");
            dataCommand3.Parameters.AddWithValue("@Brands", "Hemlibre, Cellcept");
            dataCommand3.ExecuteNonQuery();

            using var dataCommand4 = new SqliteCommand("INSERT INTO Users (UserName, PasswordHash, Created) VALUES (@UserName, @PasswordHash, @Created)", _connection);
            dataCommand4.Parameters.AddWithValue("@UserName", "admin");
            dataCommand4.Parameters.AddWithValue("@PasswordHash", "admin");
            dataCommand4.Parameters.AddWithValue("@Created", ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds());
            dataCommand4.ExecuteNonQuery();

        }
    }

    /// <summary>
    /// Get a representative.
    /// </summary>
    /// <param name="id">Representative Id.</param>
    /// <returns>Representative.</returns>
    public async Task<Representative> GetRepresentative(long id)
    {
        var result = new Representative();
        using var readCommand = new SqliteCommand("SELECT * FROM Representatives WHERE Id = @Id", _connection);
        readCommand.Parameters.AddWithValue("@Id", id);
        using var reader = await readCommand.ExecuteReaderAsync();
        if (reader.Read())
        {
            result.Id = (long)reader["Id"];
            result.Name = (string?)(reader["Name"] == DBNull.Value ? null : reader["Name"]);
            result.CellPhone = (string?)(reader["CellPhone"] == DBNull.Value ? null : reader["CellPhone"]);
            result.Email = (string?)(reader["Email"] == DBNull.Value ? null : reader["Email"]);
            result.Role = (string?)(reader["Role"] == DBNull.Value ? null : reader["Role"]);
            result.Company = (string?)(reader["Company"] == DBNull.Value ? null : reader["Company"]);
            result.Brands = (string?)(reader["Brands"] == DBNull.Value ? null : reader["Brands"]);
        }
        return result;
    }

    /// <summary>
    /// Get all representatives.
    /// </summary>
    /// <returns>List of Representatives.</returns>
    public async Task<List<Representative>> GetRepresentatives()
    {
        var result = new List<Representative>();
        using var readCommand = new SqliteCommand("SELECT * FROM Representatives", _connection);
        using var reader = await readCommand.ExecuteReaderAsync();
        while (reader.Read())
        {
            result.Add(new Representative
            {
                Id = (long)reader["Id"],
                Name = (string?)(reader["Name"] == DBNull.Value ? null: reader["Name"]),
                CellPhone = (string?)(reader["CellPhone"] == DBNull.Value ? null : reader["CellPhone"]),
                Email = (string?)(reader["Email"] == DBNull.Value ? null : reader["Email"]),
                Role = (string?)(reader["Role"] == DBNull.Value ? null : reader["Role"]),
                Company = (string?)(reader["Company"] == DBNull.Value ? null : reader["Company"]),
                Brands = (string?)(reader["Brands"] == DBNull.Value ? null : reader["Brands"])
            });
        }
        return result;
    }

    /// <summary>
    /// Add representative.
    /// </summary>
    /// <param name="representative">The element to add.</param>
    /// <returns>The added element.</returns>
    public async Task<Representative> AddRepresentative(Representative representative)
    {
        // Set Date
        representative.Created = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
        // Insert
        var insertSb = new StringBuilder("INSERT INTO Representatives");
        insertSb.Append("(Name, Email, CellPhone, Role, Company, Brands, CreatedBy, Created)");
        insertSb.Append("VALUES");
        insertSb.Append("(@Name, @Email, @CellPhone, @Role, @Company, @Brands, @CreatedBy, @Created);");
        using var insertCommand = new SqliteCommand(insertSb.ToString(), _connection);
        insertCommand.Parameters.AddWithValue("@Name", representative.Name);
        insertCommand.Parameters.AddWithValue("@Email", representative.Email);
        insertCommand.Parameters.AddWithValue("@CellPhone", representative.CellPhone);
        insertCommand.Parameters.AddWithValue("@Role", representative.Role);
        insertCommand.Parameters.AddWithValue("@Company", representative.Company);
        insertCommand.Parameters.AddWithValue("@Brands", representative.Brands);
        insertCommand.Parameters.AddWithValue("@CreatedBy", representative.CreatedBy);
        insertCommand.Parameters.AddWithValue("@Created", representative.Created);
        _ = await insertCommand.ExecuteNonQueryAsync();

        // Query for the last Id
        long lastId = 1;
        using var getMaxIdCommand = new SqliteCommand("SELECT MAX(Id) FROM Representatives;", _connection);
        using var reader = await getMaxIdCommand.ExecuteReaderAsync();
        if (reader.Read())
            lastId = reader.GetInt64(0);

        // Return the last entry
        return await GetRepresentative(lastId);
        
    }

    /// <summary>
    /// Update representative.
    /// </summary>
    /// <param name="representative">The element to modify.</param>
    /// <returns>The modified element.</returns>
    public async Task<Representative> UpdateRepresentative(Representative representative)
    {
        representative.Modified = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
        // Update all values
        var updateSb = new StringBuilder("UPDATE Representatives SET ");
        updateSb.Append("Name = @Name, Email = @Email, CellPhone = @CellPhone, Role = @Role, ");
        updateSb.Append("Company = @Company, Brands = @Brands, ModifiedBy = @ModifiedBy, Modified = @Modified ");
        updateSb.Append("WHERE Id = @Id;");
        using var updateCommand = new SqliteCommand(updateSb.ToString(), _connection);
        updateCommand.Parameters.AddWithValue("@Id", representative.Id);
        updateCommand.Parameters.AddWithValue("@Name", representative.Name);
        updateCommand.Parameters.AddWithValue("@Email", representative.Email);
        updateCommand.Parameters.AddWithValue("@CellPhone", representative.CellPhone);
        updateCommand.Parameters.AddWithValue("@Role", representative.Role);
        updateCommand.Parameters.AddWithValue("@Company", representative.Company);
        updateCommand.Parameters.AddWithValue("@Brands", representative.Brands);
        updateCommand.Parameters.AddWithValue("@ModifiedBy", representative.ModifiedBy);
        updateCommand.Parameters.AddWithValue("@Modified", representative.Modified);
        _ = await updateCommand.ExecuteNonQueryAsync();

        // Return the modified entry
        return await GetRepresentative(representative.Id);
    }

    /// <summary>
    /// Remove a representative.
    /// </summary>
    /// <param name="id">The representative id to removde</param>
    /// <returns>Task</returns>
    public async Task DeleteRepresentative(long id)
    {
        // Delete
        using var deleteCommand = new SqliteCommand("DELETE FROM Representatives WHERE Id = @Id;", _connection);
        deleteCommand.Parameters.AddWithValue("@Id", id);
        _ = await deleteCommand.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Add user.
    /// </summary>
    /// <param name="user">The element to add.</param>
    /// <returns>The added element.</returns>
    public async Task<User?> AddUser(User user)
    {
        // Check if user exists
        using var queryCommand = new SqliteCommand("SELECT COUNT(*) FROM Users WHERE UPPER(UserName) = @UserName;", _connection);
        queryCommand.Parameters.AddWithValue("@UserName", user.UserName.ToUpper());
        // Query for the count
        long count = 0;
        using var reader = await queryCommand.ExecuteReaderAsync();
        if (reader.Read())
            count = reader.GetInt64(0);
        if (count > 0)
        {
            return null;
        }

        user.Created = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
        // Insert
        using var insertCommand = new SqliteCommand("INSERT INTO Users (UserName, PasswordHash, Created) VALUES (@UserName, @PasswordHash, @Created)", _connection);
        insertCommand.Parameters.AddWithValue("@UserName", user.UserName);
        insertCommand.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
        insertCommand.Parameters.AddWithValue("@Created", user.Created);
        _ = await insertCommand.ExecuteNonQueryAsync();

        // Return the last entry
        return user;
    }

    /// <summary>
    /// Login user.
    /// </summary>
    /// <param name="user">User details.</param>
    /// <returns>Login Status.</returns>
    public async Task<LoginResult> LoginUser(User user)
    {
        // Check with DB
        using var queryCommand = new SqliteCommand("SELECT COUNT(*) FROM Users WHERE UPPER(UserName) = @UserName AND PasswordHash = @PasswordHash;", _connection);
        queryCommand.Parameters.AddWithValue("@UserName", user.UserName.ToUpper());
        queryCommand.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
        // Query for the count
        long count = 0;
        using var reader = await queryCommand.ExecuteReaderAsync();
        if (reader.Read())
            count = reader.GetInt64(0);
        if (count == 1)
            return new LoginResult
            {
                Success = true,
                Message = "Successful login."
            };
        else
            return new LoginResult
            {
                Success = false,
                Message = "Failed to login."
            };
    }
}


