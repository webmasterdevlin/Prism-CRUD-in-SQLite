using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLite;
using SQLitePrism.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace SQLitePrism.UWP
{
    class SQLite_UWP : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //add reference to C++ redistributable 2013
            //install sqlite bundle green
            var documentsPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, "myDatabase.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
