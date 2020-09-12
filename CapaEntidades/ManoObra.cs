using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class ManoObra
    {
        public int IdManoObra { get; set; }
        public short IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public Int16 CantidadPersonas { get; set; }
        public string Tiempo { get; set; }

        public ManoObra()
        {

        }
    }
}
