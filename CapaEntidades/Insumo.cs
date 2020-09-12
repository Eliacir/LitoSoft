using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class Insumo
    {
        public int IdDetalleproyecto { get; set; }
        public short IdProyecto { get; set; }
        public short Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorUni { get; set; }
        public decimal ValorTotal { get; set; }
        public string Observacion { get; set; }
        //public byte Imagen { get; set; }

        public Insumo()
        {

        }
    }
}
