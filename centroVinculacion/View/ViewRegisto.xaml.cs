using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace centroVinculacion.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewRegisto : ContentPage
    {
        public ViewRegisto()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idPerfil", txtIdPerfil.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("cedula", txtCedula.Text);
                parametros.Add("telefono", txtTelefono.Text);
                parametros.Add("institucion", txtInstitucion.Text);
                cliente.UploadValues("http://192.168.1.108/moviles/post1.php", "POST", parametros);
                await DisplayAlert("alerta", "Ingreso correcto", "OK");
                await Navigation.PushModalAsync(new ViewCursos());
            }
            catch (Exception ex)
            {
                // DisplayAlert("alerta", ex.Message, "ok");
            }

        }
    }
}