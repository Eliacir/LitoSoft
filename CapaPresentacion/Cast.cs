using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion
{
    public static class Cast
    {

        public static String ToString(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : Convert.ToString(value);
            }
            catch { return null; }
        }

        public static char ToChar(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (char)'\0' : Convert.ToChar(value);
            }
            catch { return (char)'\0'; }
        }

        public static char? ToCharNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (char?)Convert.ToChar(value);
            }
            catch { return null; }
        }

        public static byte ToByte(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (byte)0 : Convert.ToByte(value);
            }
            catch { return (byte)0; }
        }

        public static byte? ToByteNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (byte?)Convert.ToByte(value);
            }
            catch { return null; }
        }

        public static short ToShort(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (short)0 : Convert.ToInt16(value);
            }
            catch { return (short)0; }
        }

        public static short? ToShortNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (short?)Convert.ToInt16(value);
            }
            catch { return null; }
        }

        public static int ToInt(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (int)0 : Convert.ToInt32(value);
            }
            catch { return (int)0; }
        }

        public static int? ToIntNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (int?)Convert.ToInt32(value);
            }
            catch { return null; }
        }

        public static long ToLong(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (long)0 : Convert.ToInt64(value);
            }
            catch { return (long)0; }
        }

        public static long? ToLongNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (long?)Convert.ToInt64(value);
            }
            catch { return null; }
        }

        public static float ToFloat(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (float)0 : Convert.ToSingle(value);
            }
            catch { return (float)0; }
        }


        public static float? ToFloatNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (float?)Convert.ToSingle(value);
            }
            catch { return null; }
        }

        public static double ToDouble(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (double)0 : Convert.ToDouble(value);
            }
            catch { return (double)0; }
        }

        public static double? ToDoubleNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (double?)Convert.ToDouble(value);
            }
            catch { return null; }
        }

        public static decimal ToDecimal(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (decimal)0 : Convert.ToDecimal(value);
            }
            catch { return (decimal)0; }
        }

        public static decimal? ToDecimalNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (decimal?)Convert.ToDecimal(value);
            }
            catch { return null; }
        }

        public static bool ToBool(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (bool)false : Convert.ToBoolean(value);
            }
            catch { return (bool)false; }
        }

        public static bool? ToBoolNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (bool?)Convert.ToBoolean(value);
            }
            catch { return null; }
        }

        public static DateTime ToDateTime(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? (DateTime)DateTime.Now : Convert.ToDateTime(value);
            }
            catch { return (DateTime)DateTime.Now; }
        }

        public static DateTime? ToDateTimeNull(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (DateTime?)Convert.ToDateTime(value);
            }
            catch { return null; }
        }

        public static byte[] ToBytes(object value)
        {
            try
            {
                return (value is DBNull || value == null) ? null : (byte[])value;
            }
            catch { return null; }
        }

    }
}