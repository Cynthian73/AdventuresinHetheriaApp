using AdventuresinHetheriaApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventuresinHetheriaApp.Repositories
{
    class RaceRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public RaceRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task<List<Race>> GetRaces()
        {
            string sql = "SELECT * FROM Races_LT";

            return await _database.QueryAsync<Race>(sql);
        }

    }
}
