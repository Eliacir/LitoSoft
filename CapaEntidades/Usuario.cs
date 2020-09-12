using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string Clave { get; set; }
        public Int16 IdTipoUsuario { get; set; }
        public Int16 IdLitografia { get; set; }
        public bool Estado { get; set; }



        public  Usuario()
        {

        }
    }
}
