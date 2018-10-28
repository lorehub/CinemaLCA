using CinemaLCA.ApiXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaLCA.ApiXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarteleraPage : ContentPage
	{
		public CarteleraPage ()
		{
			InitializeComponent ();
            CargarPeliculas();

        }

        //invocar api
        private async Task CargarPeliculas()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://misapis.azurewebsites.net/ ");
            HttpResponseMessage request = await client.GetAsync("api/Cartelera");
            

            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<Pelicula>>(responseJson);
                listPeliculas.ItemsSource = response;
            }
            else
            {
               // string ReasonPhrase = request.ReasonPhrase;
               // HttpRequestMessage RequestMessage = request.RequestMessage;
                HttpStatusCode StatusCode = request.StatusCode;
               // Version Version = request.Version;
               // bool IsSuccessStatusCode = request.IsSuccessStatusCode;
               // HttpContent Content = request.Content;


                var mensaje = StatusCode.ToString() ;
                DisplayAlert("Sin acceso a la Api", mensaje, "ok");
            }
            

        }

        private async void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var pelicula = e.SelectedItem as Pelicula;
            await Navigation.PushAsync(new FuncionesPage(pelicula));
        }
    }
}