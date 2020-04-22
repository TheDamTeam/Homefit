using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homefit.Services
{
    public static class Constants
    {
        public const string DataBaseFilename = "Homefit.db3";
        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath,DataBaseFilename);
            }
        }
    }
}
