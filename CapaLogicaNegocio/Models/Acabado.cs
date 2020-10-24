using CapaEntidades;
using CapaLogicaNegocio.Calculations;
using CapaLogicaNegocio.Helpers;
using CapaLogicaNegocio.Types;
using CapaLogicaNegocio.Util;
using System;

namespace CapaLogicaNegocio.Models
{
    /// <summary>
    /// Define la clase para los acabados de impresion
    /// </summary>
    [Serializable]
    public class Acabado : EntidadAcabado
    {
        /// <summary>
        /// Define la clase para los acabados de impresion
        /// </summary>
        public Acabado(Cotizacion cotizacion,
                       string codigo,
                       bool? usaFrente,
                       bool? usaRespaldo,
                       string tipoTroquelado = null,
                       decimal? valorTroquelado = null)
        {
            Cotizacion = cotizacion;

            UsaFrente = usaFrente;

            UsaRespaldo = usaRespaldo;

            TipoTroquelado = tipoTroquelado;

            ValorTroquelado = valorTroquelado;

            Helper = new DataHelper();

            SetData(codigo);
        }

        /// <summary>
        /// Establece los datos desde la base de daos
        /// </summary>
        private void SetData(string codigo)
        {
            using (var reader = Helper.RecuperarAcabado(Cotizacion.IdLitografia, codigo))
            {
                if (reader == null || !reader.Read())
                    return;

                Id = Cast.ToInt(reader["IdAcabado"]);

                Nombre = Cast.ToString(reader["Descripcion"]);

                Codigo = Cast.ToString(reader["Codigo"]);

                Precio = Cast.ToDecimal(reader["Precio"]);

                PrecioMinimo = Cast.ToDecimal(reader["PrecioMinimo"]);

                PrecioMaximo = Cast.ToDecimal(reader["PrecioMaximo"]);
            }
        }

        /// <summary>
        /// Devuelve el controlador de acceso a datos
        /// </summary>
        private DataHelper Helper { get; }

        /// <summary>
        /// Devuelve la contizacion a la que pertenece el acabado
        /// </summary>
        public Cotizacion Cotizacion { get; set; }

        /// <summary>
        /// Indica si el acabado usa frente y respaldo al tiempo o no
        /// </summary>
        public bool UsaFrenteYRespaldo =>
            (UsaFrente ?? false) && (UsaRespaldo ?? false);

        /// <summary>
        /// Devuelve el valor total del acabado
        /// </summary>
        public decimal ValorTotal =>
             CalcularAcabados.CalcularAcabado(Cotizacion, this);

    }
}