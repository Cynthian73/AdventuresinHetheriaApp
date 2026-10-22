using AdventuresinHetheriaApp.Models;
using SQLite;

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
                         "       C.Class1, C.Class2, " +
                         "       S.Stat1, " +
	                     "       CASE WHEN(SUBSTR(Adj1,1,1) <> '-') THEN('+' || Adj1) ELSE Adj1 END Adjustment1, " +
                         "       S.Stat2, " +
	                     "       CASE WHEN(SUBSTR(Adj2,1,1) <> '-') THEN('+' || Adj2) ELSE Adj2 END Adjustment2, " +
                         "       S.Stat3, " +
	                     "       CASE WHEN(SUBSTR(Adj3,1,1) <> '-') THEN('+' || Adj3) ELSE Adj3 END Adjustment3 " +
                         "   FROM Races_LT R " +
                         "   INNER JOIN (SELECT Race, " +
                         "                      json_extract(json_arr, '$[0]') AS Skill1, " +
                         "                      json_extract(json_arr, '$[1]') AS Skill2, " +
                         "                      json_extract(json_arr, '$[2]') AS Skill3, " +
                         "                      json_extract(json_arr, '$[3]') AS Skill4, " +
                         "                      json_extract(json_arr, '$[4]') AS Skill5 " +
                         "                 FROM (SELECT Race,  " +
                         "                              '[\"' || replace(data, ',', '\",\"') || '\"]' AS json_arr  " +
                         "                         FROM (SELECT Race, GROUP_CONCAT( S.SkillName, ',') data " +
                         "                                 FROM Race_Skills_LT R " +
                         "                               INNER JOIN Skills_LT S " +
                         "                                 ON R.Skill = S.SkillID " +
                         "                               GROUP BY Race))) Sk" +
                         "      ON Sk.Race = R.RaceID" +
                         "   INNER JOIN(SELECT Race, " +
                         "                     json_extract(json_arr, '$[0]') AS Class1, " +
                         "                     json_extract(json_arr, '$[1]') AS Class2  " +
                         "                FROM( SELECT Race," +
                         "                             '[\"' || replace(data, ',', '\",\"') || '\"]' AS json_arr " +
                         "                        FROM (SELECT Race, GROUP_CONCAT(Class, ', ') AS data " +
                         "                                FROM FavoredClass_LT " +
                         "                               GROUP BY Race))) C" +
                         "     ON C.Race = R.RaceID " +
                         "   INNER JOIN (SELECT Race, " +
                         "                      json_extract(json_arr, '$[0]') AS Stat1, " +
                         "                      json_extract(json_arr, '$[1]') AS Stat2, " +
                         "                      json_extract(json_arr, '$[2]') AS Stat3 " +
                         "                 FROM (SELECT Race,  " +
                         "                              '[\"' || replace(data, ',', '\",\"') || '\"]' AS json_arr  " +
                         "                         FROM (SELECT Race, GROUP_CONCAT( S.StatName, ',') data " +
                         "                                 FROM Race_Stat_LT R " +
                         "                               INNER JOIN Stat_LT S " +
                         "                                 ON R.Stat= S.StatID " +
                         "                               GROUP BY Race))) S" +
                         "      ON S.Race = R.RaceID " +
                         "   INNER JOIN (SELECT Race,  " +
                         "                      json_extract(json_arr, '$[0]') AS Adj1, " +
                         "                      json_extract(json_arr, '$[1]') AS Adj2, " +
                         "                      json_extract(json_arr, '$[2]') AS Adj3 " +
                         "                 FROM (SELECT Race,  " +
                         "                              '[\"' || replace(data, ',', '\",\"') || '\"]' AS json_arr  " +
                         "                         FROM (SELECT Race, GROUP_CONCAT( R.Adjustment, ',') data   " +
                         "                                 FROM Race_Stat_LT R  " +
                         "                               INNER JOIN Stat_LT S " +
                         "                                 ON R.Stat= S.StatID " +
                         "                               GROUP BY Race))) SA" +
                         "      ON SA.Race = R.RaceID " +
                         "  WHERE R.RaceID > 0";

            return await _database.QueryAsync<Race>(sql);
        }

    }
}
