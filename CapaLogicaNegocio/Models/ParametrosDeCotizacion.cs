using CapaLogicaNegocio.Helpers;
using CapaLogicaNegocio.Types;
using CapaLogicaNegocio.Util;
using System;

namespace CapaLogicaNegocio.Models
{
    /// <summary>
    /// Define los parametros de configuracion de una cotizacion
    /// </summary>
    [Serializable]
    public class ParametrosDeCotizacion
    {
        /// <summary>
        /// Define los parametros de configuracion de una cotizacion
        /// </summary>
        public ParametrosDeCotizacion(int idLitografia)
        {
            Helper = new DataHelper();

            IdLitografia = idLitografia;

            PrecioPlanchaMayor =
                Cast.ToDecimal(Helper.RecuperarParametro(TipoParametroCotizacion.PrecioPlanchaMayor, IdLitografia));

            PrecioPlanchaMenor =
                Cast.ToDecimal(Helper.RecuperarParametro(TipoParametroCotizacion.PrecioPlanchaMenor, IdLitografia));

            PrecioImpresionMenor =
                Cast.ToDecimal(Helper.RecuperarParametro(TipoParametroCotizacion.PrecioImpresionMenor, IdLitografia));

            PrecioImpresionMayor =
                Cast.ToDecimal(Helper.RecuperarParametro(TipoParametroCotizacion.PrecioImpresionMayor, IdLitografia));

            RangoMillar =
                Cast.ToInt(Helper.RecuperarParametro(TipoParametroCotizacion.RangoMillar, IdLitografia));

            PapelExtra =
                Cast.ToInt(Helper.RecuperarParametro(TipoParametroCotizacion.PapelExtra, IdLitografia));
        }

        /// <summary>
        /// Define el acceso a datos
        /// </summary>
        private DataHelper Helper { get; }

        /// <summary>
        /// Devuelve el id de la Litogafia
        /// </summary>
        public int IdLitografia { get; }

        /// <summary>
        /// Devuelve el precio menor de la plancha
        /// </summary>
        public decimal PrecioPlanchaMenor { get; }

        /// <summary>
        /// Devuelve el precio mayor de la plancha
        /// </summary>
        public decimal PrecioPlanchaMayor { get; }

        /// <summary>
        /// Devuelve el precio menor de la impresion
        /// </summary>
        public decimal PrecioImpresionMenor { get; }

        /// <summary>
        /// Devuelve el precio mayor de la plancha
        /// </summary>
        public decimal PrecioImpresionMayor { get; }

        /// <summary>
        /// Devuelve el rango minimo de los millares
        /// </summary>
        public int RangoMillar { get; }

        /// <summary>
        /// Devuelve el papel extra
        /// </summary>
        public int PapelExtra { get; }

    }
}
