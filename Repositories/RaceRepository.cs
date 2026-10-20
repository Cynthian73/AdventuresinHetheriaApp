using AdventuresinHetheriaApp.Data;
using AdventuresinHetheriaApp.Models;
using SQLite;
using System.Text;

namespace AdventuresinHetheriaApp.Repositories
{
    internal class RaceRepository
    {
        public async Task<List<Race>> GetRaces()
        {
            SQLiteConnection db = new SQLiteConnection(DatabaseServices.DbPath);
            return db.Query<Race>("SELECT RaceName, Speed FROM Races_LT R");
        }
    }
}
