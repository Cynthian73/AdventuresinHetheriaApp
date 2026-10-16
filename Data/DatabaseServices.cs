using System;
using System.Collections.Generic;   
using System.IO;
using System.Threading.Tasks;
using AdventuresinHetheriaApp.Models;
using SQLite;
using Microsoft.EntityFrameworkCore;

namespace AdventuresinHetheriaApp.Data
{
    class DatabaseServices
    {
        private readonly SQLiteConnection _database;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdventuresinHetheriaDB.db3");

        public DatabaseServices()
        {
            _database = new SQLiteConnection(DbPath);
        }

        public async Task<string> GetAppBuildInfo()   
        {
            string AppVersionInfo =  _database.ExecuteScalar<string>("SELECT AppVersion FROM AppBuildInfo");

            return AppVersionInfo;
        }
    }
}