using CapaLogicaNegocio.Util;
using System;
using System.Globalization;

namespace CapaLogicaNegocio.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Quita el formato moneda de una cadena de texto
        /// </summary>
        public static decimal QuitarFormatoMoneda(this string moneda)
        {
            if (String.IsNullOrEmpty(moneda)) return 0;

            return decimal.Parse(moneda, NumberStyles.Currency, CultureInfo.GetCultureInfo("es-CO"));
        }

        /// <summary>
        /// Obtiene los valores X y Y de un corte expresado como cadena de texto (#x#)
        /// </summary>
        public static (decimal X, decimal Y) ObtenerCorteXY(this string corte)
        {
            if (String.IsNullOrEmpty(corte))
                return (0, 0);

            var xyCorte = corte.ToLower().Split('x');

            if (xyCorte.Length != 2)
                throw new Exception("el formato de corte debe ser por ejemplo => #x# => 0.5x50");

            var x = Cast.ToInt(xyCorte[0]);

            var y = Cast.ToInt(xyCorte[1]);

            return (x, y);
        }

        /// <summary>
        /// Obtiene los valores del numerador y denominador 
        /// de una fraccion expresada como cadena de texto (#/#).
        /// </summary>
        public static (int Numerador, int Denominador) ObtenerFraccion(this string fraccion)
        {
            if (String.IsNullOrEmpty(fraccion))
                return (0, 0);

            var partesDeFraccion = fraccion.ToLower().Split('/');

            if (partesDeFraccion.Length != 2)
                throw new Exception("el formato de la fraccion debe ser por ejemplo => #/# => 1/2");

            var numerador = Cast.ToInt(partesDeFraccion[0]);

            var denominador = Cast.ToInt(partesDeFraccion[1]);

            return (numerador, denominador);
        }


        /// <summary>
        /// Obtiene el valor decimal de una fraccion 
        /// expresada como cadena de texto (#/#).
        /// </summary>
        public static decimal ObtenerFraccionDecimal(this string fraccion)
        {
            if (String.IsNullOrEmpty(fraccion))
                return 0;

            var value = ObtenerFraccion(fraccion);

            if (value.Denominador == 0) return 0;

            return (value.Numerador / (decimal)value.Denominador);
        }

    }
}