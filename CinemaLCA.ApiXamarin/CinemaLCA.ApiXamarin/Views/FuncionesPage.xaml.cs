using CinemaLCA.ApiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaLCA.ApiXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncionesPage : ContentPage
	{
        Pelicula peliculaSeleccionada;
  

		public FuncionesPage (Pelicula peliculaSeleccionadaDesdeCartelera)
		{
           
			InitializeComponent ();
            BindingContext = peliculaSeleccionadaDesdeCartelera;
      
            //Lo de la izquierda sera igual a lo de la derecha, con esto rescatamos la variable de entrada de ser destruida en el cierre

            peliculaSeleccionada = peliculaSeleccionadaDesdeCartelera;
            //listFunciones.ItemsSource = pelicula.Funciones;
        }

        private async void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            
            Funcion funcionElegida = e.SelectedItem as Funcion;
            if (boletaEntry.Text == null)
            {
                DisplayAlert("ERROR","Digite Cantidad de Boletas","OK");
                return;
            }
            int boletas = Convert.ToInt32( boletaEntry.Text);

            ResumenCompra rc = new ResumenCompra();

            rc.funcion = funcionElegida;
            rc.pelicula = peliculaSeleccionada;
            rc.cantidad = boletas;
            rc.total = funcionElegida.Precio * boletas;
            
            

            await Navigation.PushAsync(new ResumenCompraPage(rc));
        }
    }
}