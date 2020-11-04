using CapaLogicaNegocio.Extensions;
using CapaLogicaNegocio.Models;

namespace CapaLogicaNegocio.Calculations
{
    /// <summary>
    /// Realiza las operaciones de los campos calculados de la cotizacion
    /// </summary>
    public static class CalcularCotizacion
    {
        /// <summary>
        /// Calcula la cantidad de pliegos
        /// </summary>
        public static int CalcularCantidadDePliegos(decimal montaje, int impresionesTotales) =>
              (int)(impresionesTotales * montaje);

        /// <summary>
        /// Calcula el valor o precio de la plancha
        /// </summary>
        public static decimal CalcularValorPlancha(string montaje, ParametrosDeCotizacion parametros)
        {
            return (montaje.In("1/2", "1/3")) ?
                            parametros.PrecioPlanchaMayor :
                            parametros.PrecioPlanchaMenor;
        }

        /// <summary>
        /// Calcula el valor o precio de la impresion
        /// </summary>
        public static decimal CalcularValorImpresion(string montaje, ParametrosDeCotizacion parametros)
        {
            return (montaje.In("1/2", "1/3")) ?
                            parametros.PrecioImpresionMayor :
                            parametros.PrecioImpresionMenor;
        }

        /// <summary>
        /// Calcula el valor o precio de la plancha
        /// </summary>
        public static decimal CalcularSubtotalImpresiones(decimal precioImpresion, int millares) =>
              precioImpresion * millares;

        /// <summary>
        /// Calcula el valor total del papel
        /// </summary>
        public static decimal CalcularValorTotalPapel(decimal precioPapel, int cantidadPliegos) =>
               precioPapel * cantidadPliegos;

        /// <summary>
        /// Calcula el total de las impresiones si incluir el papel extra
        /// </summary>
        public static int CalcularImpresionesTotalesSinPapelExtra(int cantidad, int cavidad)
        {
            if (cavidad == 0 || cantidad == 0) return 0;

            return (int)(cantidad / cavidad);
        }

        /// <summary>
        /// Calcula el total de las impresiones
        /// </summary>
        public static int CalcularImpresionesTotales(int cantidad, int cavidad, int papelExtra)
        {
            if (cavidad == 0) return 0;

            return (int)(CalcularImpresionesTotalesSinPapelExtra(cantidad, cavidad) + papelExtra);
        }

        /// <summary>
        /// Calcula los millares en base a la cantidad
        /// </summary>
        public static int CalcularMillares(int cantidad, int cavidad, int rangoMillar)
        {
            const int millar = 1000;

            var impresionesTotales = CalcularImpresionesTotalesSinPapelExtra(cantidad, cavidad);

            var millares = (int)(impresionesTotales / millar);

            if (impresionesTotales % millar > rangoMillar)
                millares++;

            return millares;
        }

        /// <summary>
        /// Calcula valor total en plancha
        /// </summary>
        public static decimal CalcularColores(int coloresDelFrente,
                                              int coloresDelRespaldo,
                                              bool usaLaMismaPlancha)
        {
            var respaldo = coloresDelRespaldo;

            if (usaLaMismaPlancha && coloresDelFrente == coloresDelRespaldo)
                respaldo = 0;

            return (coloresDelFrente + respaldo);
        }

        /// <summary>
        /// Calcula valor total en plancha
        /// </summary>
        public static decimal CalcularValorTotalEnPlancha(int coloresDelFrente,
                                                          int coloresDelRespaldo,
                                                          decimal precioPlancha,
                                                          bool usaLaMismaPlancha)
        {
            var frenteRespaldo = CalcularColores(coloresDelFrente, coloresDelRespaldo, usaLaMismaPlancha);

            return frenteRespaldo * precioPlancha;
        }

        /// <summary>
        /// Calcula valor total de las impresiones
        /// </summary>
        public static decimal CalcularValorTotalImpresiones(int coloresDelFrente,
                                                            int coloresDelRespaldo,
                                                            decimal subTotalImpresiones,
                                                            bool usaLaMismaPlancha) =>
             CalcularColores(coloresDelFrente, coloresDelRespaldo, usaLaMismaPlancha) * subTotalImpresiones;

        /// <summary>
        /// Calcula el valor total de la cotizacion o factura
        /// </summary>
        public static decimal CalcularTotalCotizacion(decimal valorTotalEnPlancha,
                                                      decimal valorTotalDelPapel,
                                                      decimal valorTotalImpresiones,
                                                      decimal costoDiseño,
                                                      decimal totalAcabados) =>
           (valorTotalEnPlancha + valorTotalDelPapel + valorTotalImpresiones + costoDiseño + totalAcabados);


    }
}
