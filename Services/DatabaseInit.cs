using Dapper;
using Spectre.Console;
using System.Data.SQLite;

namespace CodingTracker.Services
{
    internal class DatabaseInit
    {
        public void CreateDirectory()
        {
            string path = @"./db";

            if (!Directory.Exists(path))
            {
                AnsiConsole.MarkupLine($"[yellow]Database Directory does not exist, creating...[/]");
                try
                {
                    Directory.CreateDirectory("./db");
                }catch(Exception ex)
                {
                    AnsiConsole.MarkupLine($"[red]Error initializing the database: {ex.Message}[/]");
                }
                finally
                {
                    AnsiConsole.MarkupLine("[yellow]Press any key to continue...[/]");
                    Console.ReadKey();
                }
            }
        }

        public void InitTable(SQLiteConnection connection)
        {
            try
            {
                using (connection)
                {
                    string query = @"CREATE TABLE IF NOT EXISTS Sessions (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Project TEXT NOT NULL,
                                    StartTime TEXT NOT NULL,
                                    EndTime TEXT,
                                    Duration TEXT)";

                    connection.Execute(query);
                }
            }catch(Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error initializing the database: {ex.Message}[/]");
            }
        }
    }
}
