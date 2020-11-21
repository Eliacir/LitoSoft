using System;

namespace CapaEntidades
{
    /// <summary>
    /// Define la clase para entidades de cotizacion
    /// </summary>
    [Serializable]
    public class EntidadCotizacion
    {

        /// <summary>
        /// Devuelve el id de la litografia
        /// </summary>
        public int IdLitografia { get; set; }

        /// <summary>
        /// Devuelve el id del cliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Devuelve el id del producto
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Devuelve el id del Papel
        /// </summary>
        public int IdPapel { get; set; }

        /// <summary>
        /// Devuelve el id del Papel
        /// </summary>
        public int IdCorte { get; set; }

        /// <summary>
        /// Devuelve o establece el precio del papel
        /// </summary>
        public decimal PrecioPapel { get; set; }

        /// <summary>
        /// Devuelve o establece la cantidad de impresiones 
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Devuelve o establece el costo del diseño de las impresiones
        /// </summary>
        public decimal CostoDiseño { get; set; }

        /// <summary>
        /// Devuelve la cavidad 
        /// </summary>
        public int Cavidad { get; set; }

        /// <summary>
        /// Devuelve o establece el tipo de papel de la impresion
        /// </summary>
        public string Sustrato { get; set; }

        /// <summary>
        /// Devuelve o establece el tamaño del corte de la impresion
        /// </summary>
        public string CorteXY { get; set; }

        /// <summary>
        /// Devuelve o establece el montaje asociado al corte del papel
        /// </summary>
        public string Montaje { get; set; }

        /// <summary>
        /// Devuelve o establece si va a usar frente o no
        /// </summary>
        public bool UsaFrente { get; set; }

        /// <summary>
        /// Devuelve o establece si va a usar respaldo o no
        /// </summary>
        public bool UsaRespaldo { get; set; }

        /// <summary>
        /// Devuelve o establece la cantidad de coleres del frente, 
        /// con los cuales se realizara la impresion
        /// </summary>
        public int ColoresDelFrente { get; set; }

        /// <summary>
        /// Devuelve o establece la cantidad de coleres del respaldo,  
        /// con los cuales se realizara la impresion
        /// </summary>
        public int ColoresDelRespaldo { get; set; }

        /// <summary>
        /// Devuelve o establece un flag que indica si usara o no 
        /// la misma plancha para la impresion de frente y respaldo
        /// </summary>
        public bool UsaLaMismaPlancha { get; set; }

        #region Totales

        public decimal TotalAcabados { get; set; }

        public decimal SubtotalFactura { get; set; }

        public decimal ValorGanancia { get; set; }

        public decimal PorcentajeGanancia { get; set; }

        public decimal TotalFactura { get; set; }

        #endregion

    }
}
