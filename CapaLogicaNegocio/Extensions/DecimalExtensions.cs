using System;
using System.Globalization;

namespace CapaLogicaNegocio.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Devuelve el numero como una cadena con formato moneda
        /// </summary>
        public static string FormatoMoneda(this decimal number) =>
             number.ToString("C0", CultureInfo.CurrentCulture);


        /// <summary>
        /// Devuelve el numero como una cadena con formata invariante para decimales
        /// </summary>
        public static string ToStringInvariant(this decimal number) =>
             String.Format(CultureInfo.InvariantCulture, "{0:N}", number);

    }
}