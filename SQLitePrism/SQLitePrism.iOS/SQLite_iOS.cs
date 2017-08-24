using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using SQLitePrism.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace SQLitePrism.iOS
{
    class SQLite_iOS : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "myDatabase.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
