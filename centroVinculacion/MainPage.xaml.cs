using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace centroVinculacion
{
    public partial class MainPage : ContentPage
    {
        private const string url = "http://192.168.1.108/moviles/post1.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<centroVinculacion.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
           

        }


        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(url);
            List<centroVinculacion.Ws.Datos> posts = JsonConvert.DeserializeObject<List<centroVinculacion.Ws.Datos>>(content);
            _post = new ObservableCollection<centroVinculacion.Ws.Datos>(posts);

            MyListView.ItemsSource=_post;
        }

        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new viewInsertar());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new viewDelete());
        }

        
    }
}
