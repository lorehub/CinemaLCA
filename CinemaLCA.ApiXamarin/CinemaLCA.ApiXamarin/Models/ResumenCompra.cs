using CinemaLCA.ApiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaLCA.ApiXamarin.Models
{
    public class ResumenCompra
    {
        public Pelicula pelicula { get; set; }
        public Funcion funcion { get; set; }
        public int cantidad { get; set; }
        public int total { get; set; }


    }
}
