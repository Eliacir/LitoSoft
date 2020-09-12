using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class CotizacionEnti
    {
        public int IdCotizacion { get; set; }
        public string CodigoCotizacion { get; set; }
        public int IdProyecto { get; set; }
        public string ValidezOferta { get; set; }
        public string TiempoEntrega { get; set; }
        public string LugarEntrega { get; set; }
        public string Garantia { get; set; }
        public string Nota { get; set; }
        public string AlcancePropuesta { get; set; }

        public  CotizacionEnti()
        {

        }
    }
}
