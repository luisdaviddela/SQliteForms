using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteDemo.Droid;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLiteDB))]
namespace SQLiteDemo.Droid
{
    //Accedemos a la interfaz que se creo en el proyecto compartido
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la Base de datos
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}