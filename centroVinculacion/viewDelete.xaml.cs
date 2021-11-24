using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace centroVinculacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewDelete : ContentPage
    {
        public viewDelete()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtIdPerfil.Text);
                //delete por id
                HttpClient client = new HttpClient();
                var resultado = await client.DeleteAsync(String.Concat("http://192.168.1.108/moviles/post1.php", txtIdPerfil.Text));
                if (resultado.IsSuccessStatusCode)
                {
                    await DisplayAlert("Exito", "Registro eliminado", "Ok");
                }
            }
            catch (Exception ex)
            {
               //DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());

        }
    }

        
}