//Development by Kelmer Ashley Comas Cardona © 2019

using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogicaNegocio.Extensions
{
    /// <summary>
    /// Metodos de extension comun para los todos los tipos de datos base
    /// </summary>
    public static class CommonExtensions
    {
        /// <summary>
        /// Indica si el valor entero, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this int value, params int[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor entero largo, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this long value, params long[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor entero corto, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this short value, params short[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor del byte, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this byte value, params byte[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor del entero sin signo, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this uint value, params uint[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor del entero largo sin signo, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this ulong value, params ulong[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor del entero corto sin signo, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this ushort value, params ushort[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor del decimal, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this decimal value, params decimal[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor del decimal flotante simple, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this float value, params float[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor del decimal flotante doble, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this double value, params double[] list) =>
            list.Contains(value);

        /// <summary>
        /// Indica si el valor de la cadena, se encuentra dentro de la lista especificada
        /// </summary>
        public static bool In(this string value, params string[] list) =>
            list.Contains(value, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Indica si los valores de cadena de un enumerable, se encuentran dentro de la lista especificada
        /// </summary>
        public static bool In(this IEnumerable<string> values, params string[] list)
        {
            if (values.Count() < 1 || list.Length < 1)
                return false;

            foreach (var value in values)
                foreach (var item in list)
                {
                    if (item.Contains(value))
                        return false;
                }

            return true;
        }

        /// <summary>
        /// Convierte un valor booleano a texto Si o No
        /// </summary>
        public static string ToStringBool(this bool value) => (value) ? "Si" : "No";

    }
}
