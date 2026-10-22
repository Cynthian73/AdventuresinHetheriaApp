using AdventuresinHetheriaApp.Models;
using Java.Lang;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using static Java.Text.Normalizer;

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
            string sql = "SELECT R.RaceName, " +
                         "       R.Speed, " +
                         "       C1.ClassName Class1, C2.ClassName Class2, " +
                         "       S1.StatName Stat1, " +
	                     "       CASE WHEN(SUBSTR(Adjustment1,1,1) <> '-') THEN('+' || Adjustment1) ELSE Adjustment1 END Adjustment1, " +
                         "       S2.StatName Stat2, " +
	                     "       CASE WHEN(SUBSTR(Adjustment2,1,1) <> '-') THEN('+' || Adjustment2) ELSE Adjustment1 END Adjustment2, " +
                         "       S3.StatName Stat3, " +
	                     "       CASE WHEN(SUBSTR(Adjustment3,1,1) <> '-') THEN('+' || Adjustment3) ELSE Adjustment3 END Adjustment3 " +
                         "   FROM Races_LT R " +
                         "   INNER JOIN(SELECT Race, " +
                         "                   SUBSTR(FavoredClasss, 1, INSTR(FavoredClasss, ',') - 1) AS FavoredClass1, " +
                         "                   SUBSTR(FavoredClasss, INSTR(FavoredClasss, ',') + 1) AS FavoredClass2 " +
                         "               FROM(SELECT Race, GROUP_CONCAT(Class, ', ') AS FavoredClasss " +
                         "                       FROM FavoredClass_LT " +
                         "                   GROUP BY Race) X) F " +
                         "     ON F.Race = R.RaceID " +
                         "   INNER JOIN Class_LT C1 " +
                         "     ON C1.ClassID = F.FavoredClass1 " +
                         "   INNER JOIN Class_LT C2 " +
                         "     ON C2.ClassID = F.FavoredClass2 " +
                         "   INNER JOIN(SELECT Race, " +
                         "                       SUBSTR(Stat, 1, INSTR(Stat, ',') - 1) AS Stat1, " +
                         "                   SUBSTR(Adjustment, 1, INSTR(Adjustment, ',') - 1) AS Adjustment1, " +
                         "                   SUBSTR(SUBSTR(Stat, INSTR(Stat, ',') + 1), 1, INSTR(SUBSTR(Stat, INSTR(Stat, ',') + 1), ',') - 1) AS Stat2, " +
                         "                   SUBSTR(SUBSTR(Adjustment, INSTR(Adjustment, ',') + 1), 1, INSTR(SUBSTR(Adjustment, INSTR(Adjustment, ',') + 1), ',') - 1) AS Adjustment2, " +
                         "                   SUBSTR(Stat, INSTR(Stat, ',') + INSTR(SUBSTR(Stat, INSTR(Stat, ',') + 1), ',') + 1) AS Stat3, " +
                         "                   SUBSTR(Adjustment, INSTR(Adjustment, ',') + INSTR(SUBSTR(Adjustment, INSTR(Adjustment, ',') + 1), ',') + 1) AS Adjustment3 " +
                         "               FROM(SELECT Race, GROUP_CONCAT(Stat, ', ') Stat, GROUP_CONCAT(Adjustment, ',') Adjustment " +
                         "                       FROM Race_Stat_LT " +
                         "                       GROUP BY Race) X) RS " +
                         "     ON RS.Race = R.RaceID " +
                         "   INNER JOIN Stat_LT S1 " +
                         "     ON S1.StatID = RS.Stat1 " +
                         "   INNER JOIN Stat_LT S2" +
                         "     ON S2.StatID = RS.Stat2 " +
                         "   INNER JOIN Stat_LT S3 " +
                         "     ON S3.StatID = RS.Stat3 " +
                         "  WHERE R.RaceID > 0";

            return await _database.QueryAsync<Race>(sql);
        }

    }
}
