using AdventuresinHetheriaApp.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdventuresinHetheriaApp.Models
{
    internal class RaceRepository
    {
        public async Task<string> GetRaces()
        {
            SQLiteConnection db = new SQLiteConnection(DatabaseServices.DbPath);
            string AppVersionInfo = db.ExecuteScalar<string>("SELECT RaceName, Speed " +
                "                                               FROM Race_LT R" +
                "                                             INNER JOIN STAT_LT S1 ON R.STAT1 = S1.STATID");

            return AppVersionInfo;
        }
    }
}
