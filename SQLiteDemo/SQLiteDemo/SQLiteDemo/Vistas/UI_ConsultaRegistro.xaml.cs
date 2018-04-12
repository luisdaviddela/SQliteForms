using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UI_ConsultaRegistro : ContentPage
	{
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<T_Registro> _TablaRegistro;
        public UI_ConsultaRegistro ()
		{
			InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }
        protected async override void OnAppearing()
        {
            var ResulRegistros = await _conn.Table<T_Registro>().ToListAsync();
            _TablaRegistro = new ObservableCollection<T_Registro>(ResulRegistros);
            ListaUsuarios.ItemsSource = _TablaRegistro;
            base.OnAppearing();
        }
    }
}