using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class ImagenesProyectos
    {
        public int IdCotizacion { get; set; }
        public int IdProyecto { get; set; }
        public  byte[] Imagen { get; set; }
        public string Tituloimagen { get; set; }
        public int NumeroImagen { get; set; }

        public ImagenesProyectos()
        {

        }
    }
}
