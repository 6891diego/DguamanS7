using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;//se  agrega
using System.IO;//se agrega
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel.Design;


namespace DguamanS7.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private object txtUsuario;
        private object txtContrasena;

        public Login()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();

        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        //metodo que verifique el user y  pass
        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Contrasena=?", usuario, contrasena);
        }
        private void btnIinicio_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContrasena.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());

                }
                else
                {
                    DisplayAlert("ALERTA", "USUARI/PASS iNCORRECTO", "CERRAR");
                }

            }
            catch (Exception)
            {


            }

        }

        private IEnumerable<Estudiante> Select_Where(SQLiteConnection db, object text1, object text2)
        {
            throw new NotImplementedException();
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}

