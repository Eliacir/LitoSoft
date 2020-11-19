using CapaEntidades;
using CapaLogicaNegocio.Calculations;
using CapaLogicaNegocio.Extensions;
using CapaLogicaNegocio.Helpers;
using System;

namespace CapaLogicaNegocio.Models
{
    /// <summary>
    /// Define la clase base para cotizaciones
    /// </summary>
    [Serializable]
    public class Cotizacion : EntidadCotizacion
    {
        /// <summary>
        /// Define la clase base para cotizaciones
        /// </summary>
        public Cotizacion(int idLitografia)
        {
            Parametros = new ParametrosDeCotizacion(idLitografia);

            IdLitografia = idLitografia;

            UsaFrente = true;

            UsaLaMismaPlancha = true;

            Helper = new DataHelper();

            Acabados = new ColeccionAcabados();
        }

        /// <summary>
        /// Devuelve el controlador de acceso a datos
        /// </summary>
        private DataHelper Helper { get; }

        /// <summary>
        /// Devuelve los parametros de configuracion de la cotizacion
        /// </summary>
        public ParametrosDeCotizacion Parametros { get; }

        /// <summary>
        /// Devuelve la lista de acabados
        /// </summary>
        public ColeccionAcabados Acabados { get; }

        /// <summary>
        /// Devuelve el valor de la plancha
        /// </summary>
        public decimal ValorPlancha =>
            CalcularCotizacion.CalcularValorPlancha(Montaje, Parametros);

        /// <summary>
        /// Devuelve el valor de la ipresion
        /// </summary>
        public decimal ValorImpresion =>
            CalcularCotizacion.CalcularValorImpresion(Montaje, Parametros);

        /// <summary>
        /// Indica si se debe tener en cuenta el respaldo para hacer calculos o no
        /// </summary>
        private bool UsaRespaldoParaCalculos =>
            CalcularCotizacion.UsaRespaldoEnCalculos(ColoresDelFrente, ColoresDelRespaldo, UsaLaMismaPlancha);

        /// <summary>
        /// Devuelve los millares correspondientes a la cantidad de impresiones
        /// </summary>
        public int Millares =>
            CalcularCotizacion.CalcularMillares(ImpresionesTotalesSinPapelExtra, Parametros.RangoMillar, UsaRespaldoParaCalculos);

        /// <summary>
        /// Devuelve la cantidad de pliegos de papel
        /// </summary>
        public int CantidadPliegos =>
           CalcularCotizacion.CalcularCantidadDePliegos(MontajeDecimal, ImpresionesTotales);

        /// <summary>
        /// Devuelve el numero de impresiones totales
        /// </summary>
        public int ImpresionesTotales =>
           CalcularCotizacion.CalcularImpresionesTotales(Cantidad, Cavidad, Parametros.PapelExtra);

        /// <summary>
        /// Devuelve las impresiones totales sin tener encuenta el papel extra
        /// </summary>
        public decimal ImpresionesTotalesSinPapelExtra =>
            CalcularCotizacion.CalcularImpresionesTotalesSinPapelExtra(Cantidad, Cavidad);

        /// <summary>
        /// Devuelve el valor total del papel
        /// </summary>
        public decimal ValorTotalDelPapel =>
            CalcularCotizacion.CalcularValorTotalPapel(PrecioPapel, CantidadPliegos);

        /// <summary>
        /// Devuelve el valor total por plancha
        /// </summary>
        public decimal ValorTotalEnPlancha =>
            CalcularCotizacion.CalcularValorTotalEnPlancha(ColoresDelFrente, ColoresDelRespaldo, ValorPlancha, UsaLaMismaPlancha);

        /// <summary>
        /// Devuelve el valor total de las impresiones
        /// </summary>
        public decimal ValorTotalImpresiones =>
            CalcularCotizacion.CalcularValorTotalImpresiones(ColoresDelFrente, ColoresDelRespaldo, Millares, ValorImpresion, UsaLaMismaPlancha);

        /// <summary>
        /// Devuelve el valor total de la cotizacion o factura
        /// </summary>
        public decimal TotalCotizacion =>
          CalcularCotizacion.CalcularTotalCotizacion(ValorTotalEnPlancha, ValorTotalDelPapel, ValorTotalImpresiones, CostoDiseño, Acabados.TotalAcabados);

        /// <summary>
        /// Calcula valor total de la factura y suma la ganancia
        /// </summary>
        public decimal ObtenerTotalConGanancia(decimal porcentaje) =>
            CalcularCotizacion.CalcularTotalConGanancia(porcentaje, TotalCotizacion);

        /// <summary>
        /// Calcula valor total del porcentaje de ganancia 
        /// </summary>
        public decimal ObtenerValorGanancia(decimal porcentaje) =>
            CalcularCotizacion.CalcularValorGanancia(porcentaje, TotalCotizacion);

        /// <summary>
        /// Devuelve si verdadero si usa frente y respaldo,
        /// y false si solo usa uno de los dos
        /// </summary>
        public bool UsaFrenteYRespaldo => UsaFrente && UsaRespaldo;

        /// <summary>
        /// Devuelve los valores numericos asociados al corte del papel
        /// </summary>
        public (decimal X, decimal Y) Corte => CorteXY.ObtenerCorteXY();


        /// <summary>
        /// Devuelve el montaje como una fraccion decimal
        /// </summary>
        public decimal MontajeDecimal =>
               Montaje.ObtenerFraccionDecimal();

        /// <summary>
        /// Establece el papel correspondiente al id especificado
        /// </summary>
        public void SetPapel(int idPapel, string nombrePapel)
        {
            PrecioPapel = Helper.RecuperarPrecioPapel(idPapel);

            Sustrato = nombrePapel;
        }

        /// <summary>
        /// Establece el papel correspondiente al id especificado
        /// </summary>
        public void SetCorte(int idCorte, string nombreCorte)
        {
            Montaje = Helper.RecuperarMontaje(idCorte);

            CorteXY = nombreCorte;
        }


        public void GuardarCotizacion()
        {
            var idCotizacion = Helper.InsertarCotizacion(this);

            foreach (var acabado in Acabados.ObtenerTodos())
                Helper.InsertarAcabadoCotizacion(acabado, idCotizacion);
        }

    }
}