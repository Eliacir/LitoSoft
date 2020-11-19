using System;

namespace CapaEntidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public Int16 IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public Int16 Edad { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public Int16 Estado { get; set; }


        public Empleado()
        {

        }
    }
}
