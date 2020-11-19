using System;

namespace CapaEntidades
{
    /// <summary>
    /// Define la clase para entidades de acabados
    /// </summary>
    [Serializable]
    public class EntidadAcabado
    {
        /// <summary>
        /// Devuelve o establece el id del acabado
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Devuelve o establece el nombre del acabado
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Devuelve o establece el codigo del acabado
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Devuelve o establece el precio por cm2 del acabado
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Devuelve o establece el precio minimo del acabado
        /// </summary>
        public decimal PrecioMinimo { get; set; }

        /// <summary>
        /// Devuelve o establece el precio maximo del acabado
        /// </summary>
        public decimal PrecioMaximo { get; set; }

        /// <summary>
        /// Devuelve o establece el valor del troquelado
        /// </summary>
        public decimal? ValorTroquelado { get; set; }

        /// <summary>
        /// Devuelve o establece el tipo de troquelado
        /// </summary>
        public string TipoTroquelado { get; set; }

        /// <summary>
        /// Indica si el acabado usa frente o no
        /// </summary>
        public bool? UsaFrente { get; set; }

        /// <summary>
        /// Indica si el acabado usa respaldo o no
        /// </summary>
        public bool? UsaRespaldo { get; set; }
    }
}
