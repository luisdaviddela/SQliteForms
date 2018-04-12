using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UI_Elemento : ContentPage
	{
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<T_Registro> Resultado;
        public UI_Elemento (int id)
		{
			InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
            IdSeleccionado = id;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            mensaje.Text = "Se afectará al ID ["+IdSeleccionado+"]";
        }
        private void btn_actualizar(object sender,EventArgs e)
        {

        }
        private void btn_eliminar(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3");
            var db = new SQLiteConnection(databasePath);
            Resultado = Delete(db,IdSeleccionado);
        }
        public static IEnumerable<T_Registro> Delete(SQLiteConnection db, int id)
        {
            return db.Query<T_Registro>("DELETE FROM T_Registro where Id = ?", id);
        }
    }
}