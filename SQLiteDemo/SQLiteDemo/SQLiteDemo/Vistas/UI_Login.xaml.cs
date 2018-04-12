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
	public partial class UI_Login : ContentPage
	{
        private SQLiteAsyncConnection _conn;
        public UI_Login ()
		{
			InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }
        private void btn_Registrar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UI_Registro());
        }
        private void btn_login(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3");
                var db = new SQLiteConnection(databasePath);
                IEnumerable<T_Registro> resultado = SELECT_WHERE(db, usuario.Text, contra.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new UI_ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("XamaSharp Blog", "Verifique su usuario/contraseñ", "Ok");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static IEnumerable<T_Registro> SELECT_WHERE(SQLiteConnection db, string usuario, string contra)
        {
            return db.Query<T_Registro>("SELECT * FROM T_Registro where Usuario = ? and Contrasenia = ?", usuario, contra);
        }
    }
}