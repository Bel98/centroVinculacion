using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace centroVinculacion.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCursos : ContentPage
    {
        private const string url = "http://192.168.1.108/moviles/postCur.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<centroVinculacion.Ws.CursoDa> _post;
        public ViewCursos()
        {
            InitializeComponent();
            obtenerCurso();
        }

        private async void obtenerCurso()
        {
            var content = await client.GetStringAsync(url);
            List<centroVinculacion.Ws.CursoDa> posts = JsonConvert.DeserializeObject<List<centroVinculacion.Ws.CursoDa>>(content);
            _post = new ObservableCollection<centroVinculacion.Ws.CursoDa>(posts);

            ListViewCursos.ItemsSource = _post;
        }
        private void btnAgregar_Clicked(object sender, EventArgs e)
        {

        }

        private void ListViewCursos_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}