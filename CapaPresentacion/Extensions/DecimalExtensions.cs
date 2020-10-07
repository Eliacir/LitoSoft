using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CapaPresentacion.Extensions
{
    public static class DecimalExtensions
    {
        public static string FormatoMoneda(this decimal number)
        {
            return number.ToString("C0", CultureInfo.CurrentCulture);
        }
       
    }
}