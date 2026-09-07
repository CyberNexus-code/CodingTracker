using CodingTracker;
using CodingTracker.Services;
using Spectre.Console;
using System.Data.SQLite;
using System.Text.Json;

string json = File.ReadAllText("appsettings.json");

var config = JsonSerializer.Deserialize<AppSettings>(json);

string connectionString = config!.ConnectionString;

SQLiteConnection _connection = new(connectionString);

DatabaseInit database = new();

database.CreateDirectory();
database.InitTable(_connection);

