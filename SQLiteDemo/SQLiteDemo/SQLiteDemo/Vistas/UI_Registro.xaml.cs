using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UI_Registro : ContentPage
	{
        private SQLiteAsyncConnection _conn;
        public UI_Registro ()
		{
			InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }
        protected void btn_agregar(object sender, EventArgs e)
        {
            var DatosRegistro = new T_Registro { Nombre = Nombre.Text, Usuario = Usuario.Text, Contrasenia = Contrasenia.Text };
            _conn.InsertAsync(DatosRegistro);
            limpiarFormulario();
        }
        void limpiarFormulario()
        {
            Nombre.Text = "";
            Usuario.Text = "";
            Contrasenia.Text = "";
            DisplayAlert("XamSharp demo","Se agregó correctamente","Ok");
        }

    }
}