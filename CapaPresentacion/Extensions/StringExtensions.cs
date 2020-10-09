using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CapaPresentacion.Extensions
{
    public static class StringExtensions
    {
        public static decimal QuitarFormatoMoneda(this string moneda)
        {
            if (String.IsNullOrEmpty(moneda)) return 0;

            return decimal.Parse(moneda, NumberStyles.Currency, CultureInfo.GetCultureInfo("es-CO"));
        }
    }
}