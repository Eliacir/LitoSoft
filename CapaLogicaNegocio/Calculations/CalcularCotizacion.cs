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
        public static int CalcularMillares(decimal impresionesTotalesSinPapelExtra,
                                           int rangoMillar,
                                           bool usaRespaldoParaCalculos)
        {
            const int millar = 1000;

            var factor = usaRespaldoParaCalculos ? 1 : 2;

            var impresionesTotales = impresionesTotalesSinPapelExtra * factor;

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

            if (!UsaRespaldoEnCalculos(coloresDelFrente, coloresDelRespaldo, usaLaMismaPlancha))
                respaldo = 0;

            return (coloresDelFrente + respaldo);
        }

        /// <summary>
        /// Indica si se debe tener en cuenta el respaldo para hacer calculos o no
        /// </summary>
        public static bool UsaRespaldoEnCalculos(int coloresDelFrente,
                                                int coloresDelRespaldo,
                                                bool usaLaMismaPlancha) =>
            !usaLaMismaPlancha || coloresDelFrente != coloresDelRespaldo;
       

        /// <summary>
        /// Calcula valor total en plancha
        /// </summary>
        public static decimal CalcularValorTotalEnPlancha(int coloresDelFrente,
                                                          int coloresDelRespaldo,
                                                          decimal precioPlancha,
                                                          bool usaLaMismaPlancha) =>
               CalcularColores(coloresDelFrente, coloresDelRespaldo, usaLaMismaPlancha) * precioPlancha;

      

        /// <summary>
        /// Calcula valor total de las impresiones
        /// </summary>
        public static decimal CalcularValorTotalImpresiones(int coloresDelFrente,
                                                            int coloresDelRespaldo,
                                                            int millares,
                                                            decimal precioImpresion,
                                                            bool usaLaMismaPlancha) =>
             CalcularColores(coloresDelFrente, coloresDelRespaldo, usaLaMismaPlancha) * millares * precioImpresion;

     

        /// <summary>
        /// Calcula el valor total de la cotizacion o factura
        /// </summary>
        public static decimal CalcularTotalCotizacion(decimal valorTotalEnPlancha,
                                                      decimal valorTotalDelPapel,
                                                      decimal valorTotalImpresiones,
                                                      decimal costoDiseño,
                                                      decimal totalAcabados) =>
           (valorTotalEnPlancha + valorTotalDelPapel + valorTotalImpresiones + costoDiseño + totalAcabados);


        /// <summary>
        /// Calcula valor total de las impresiones
        /// </summary>
        public static decimal CalcularTotalConGanancia(decimal porcentaje, decimal totalFactura) =>
                 (1 + (porcentaje / 100m)) * totalFactura;

       


    }
}
