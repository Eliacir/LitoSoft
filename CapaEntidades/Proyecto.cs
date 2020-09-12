using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public Int16 IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Area { get; set; }
        public Int16 Estado { get; set; }
        public Int16 IdEmpleado { get; set; }
        //public byte Imagen { get; set; }

        public Proyecto()
        {

        }
    }
}
