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
	public partial class ResumenCompraPage : ContentPage
	{
		public ResumenCompraPage (ResumenCompra resumenCompra)
		{
			InitializeComponent ();
            BindingContext = resumenCompra;
        
		}
	}
}