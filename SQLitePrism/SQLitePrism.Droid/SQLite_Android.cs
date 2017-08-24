using System;
using System.IO;
using SQLite;
using SQLitePrism.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace SQLitePrism.Droid
{
    class SQLite_Android : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "myDatabase.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}