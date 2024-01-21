using Microsoft.Data.Sqlite;

namespace Infrastructure.Data;

public class DataAccess
{
    public static void InitializeDatabase()
    {
        using (var db = new SqliteConnection("Data Source=:memory:"))
        {
            db.Open();

            string representativesTableCommand = "CREATE TABLE IF NOT EXISTS Representatives" + 
                "(Id         INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                " Name       TEXT NOT NULL," +
                " Email      TEXT," +
                " CellPhone  TEXT," +
                " Role       TEXT," +
                " Company    TEXT," +
                " Brands     TEXT," +
                " CreatedBy  TEXT," +
                " Created    INTEGER," +
                " ModifiedBy TEXT," +
                " Modified   INTEGER" +
                ")";

            var representativesCreateTable = new SqliteCommand(representativesTableCommand, db);

            representativesCreateTable.ExecuteReader();

            string usersTableCommand = "CREATE TABLE IF NOT EXISTS Users" +
                "(UserName     TEXT NOT NULL PRIMARY KEY, " +
                " PasswordHash TEXT NOT NULL" +
                ")";

            var usersCreateTable = new SqliteCommand(usersTableCommand, db);

            usersCreateTable.ExecuteReader();

        }
    }
}


