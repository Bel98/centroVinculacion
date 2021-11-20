using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace centroVinculacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewInsertar : ContentPage
    {
        public viewInsertar()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtIdPerfil.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("cedula", txtCedula.Text);
                parametros.Add("telefono", txtTelefono.Text);
                parametros.Add("institucion", txtInstitucion.Text);
                cliente.UploadValues("http://192.168.1.108/moviles/post.php", "POST", parametros);
                await DisplayAlert("alerta", "Ingreso correcto", "OK");
            }catch(Exception ex)
            {
               // DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}