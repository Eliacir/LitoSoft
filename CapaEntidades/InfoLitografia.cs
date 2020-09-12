using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class InfoLitografia
    {
        public int IdLitografia { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public  byte[] Imagen { get; set; }
        public Usuario UsuLitografia { get; set; } = null;

        public InfoLitografia()
        {

        }
    }
}
