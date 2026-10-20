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
        public SQLiteConnection DatabaseConnection { get; }

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdventuresinHetheriaDB.db3");

        public DatabaseServices()
        {
            DatabaseConnection = new SQLiteConnection(DbPath);
        }

        public async Task<string> GetAppBuildInfo()
        {
            string AppVersionInfo =  DatabaseConnection.ExecuteScalar<string>("SELECT AppVersion FROM AppBuildInfo");

            return AppVersionInfo;
        }
    }
}