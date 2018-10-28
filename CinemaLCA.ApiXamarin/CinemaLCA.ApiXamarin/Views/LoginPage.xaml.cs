using CinemaLCA.ApiXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaLCA.ApiXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void Ingresar(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://misapis.azurewebsites.net/");
            string usuario = usuarioEntry.Text;
            string pass = passwordEntry.Text;
            string jsonData = "{\"Usuario\" : \""+ usuario + "\", \"Password\" : \""+ pass +"\"}";   

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/Seguridad", content);

            var result = await response.Content.ReadAsStringAsync();
            var mensaje = JsonConvert.DeserializeObject<Response>(result);
        
            if (mensaje.EsPermitido)
            {
                await Navigation.PushAsync(new CarteleraPage());
            }
            else
            {
                labelMensaje.Text = mensaje.Mensaje;


            }

        }
    }
}