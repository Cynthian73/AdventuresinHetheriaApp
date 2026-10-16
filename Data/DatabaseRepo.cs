using AdventuresinHytheriaApp.Models;
using SQLite;
namespace AdventuresinHytheriaApp.Data
{
    class DatabaseRepo
    {
        private readonly SQLiteConnection _database;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdventuresinHetheriaDB.db3");

    }
}
    