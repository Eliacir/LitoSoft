using CapaLogicaNegocio.Extensions;
using CapaLogicaNegocio.Models;
using CapaLogicaNegocio.Types;
using System;

namespace CapaLogicaNegocio.Calculations
{
    /// <summary>
    /// Realiza las operaciones de los campos calculados de los acabados
    /// </summary>
    public static class CalcularAcabados
    {
        /// <summary>
        /// Calcula cualquier tipo de acabado
        /// </summary>
        public static decimal CalcularAcabado(Cotizacion cotizacion, Acabado acabado)
        {
            var tipo = acabado.Codigo;

            switch (tipo)
            {
                case TipoAcabado.LaminadoMate:
                case TipoAcabado.LaminadoDry:
                case TipoAcabado.UVTotal:
                    return (acabado.UsaFrenteYRespaldo) ?
                               CalcularDobleComun(cotizacion, acabado) :
                               CalcularAcabadoComun(cotizacion, acabado);

                case TipoAcabado.Semicorte:
                case TipoAcabado.Repujado:
                    return CalcularSemicorteORepujado(cotizacion, acabado);

                case TipoAcabado.Troquelado:
                    return CalcularTroquelado(cotizacion, acabado);

                case TipoAcabado.UVReserva:
                    return (acabado.UsaFrenteYRespaldo) ?
                                  CalcularDobleUVReserva(cotizacion, acabado) :
                                  CalcularUVReserva(cotizacion, acabado);

                case TipoAcabado.Sanduchado:
                    return CalcularSanduchado(cotizacion, acabado);

                default: return 0;

            }
        }

        /// <summary>
        /// Calcula el valor del acabado Laminado Mate, Laminado Dry y UVTotal
        /// </summary>
        public static decimal CalcularAcabadoComun(Cotizacion cotizacion, Acabado acabado)
        {
            var x = cotizacion.Corte.X;
            var y = cotizacion.Corte.Y;
            var precio = acabado.Precio;
            var precioMinimo = acabado.PrecioMinimo;
            var impresionesTotales = cotizacion.ImpresionesTotales;

            var total = (x * y) * precio * impresionesTotales;

            if (total <= precioMinimo)
                total = precioMinimo;

            return total;
        }

        /// <summary>
        /// Calcula el valor del acabado Laminado Mate, Laminado Dry y UVTotal doble
        /// </summary>
        public static decimal CalcularDobleComun(Cotizacion cotizacion, Acabado acabado) =>
               CalcularAcabadoComun(cotizacion, acabado) * 2;

        /// <summary>
        /// Calcula el valor del acabado Toquelado
        /// </summary>
        public static decimal CalcularTroquelado(Cotizacion cotizacion, Acabado acabado)
        {
            var precioMaximo = acabado.PrecioMaximo;
            var precioMinimo = acabado.PrecioMinimo;
            var millares = cotizacion.Millares;

            return ((cotizacion.Montaje.In("1/2", "1/3")) ?
                           precioMaximo : precioMinimo) * millares;
        }

        /// <summary>
        /// Calcula el valor del acabado Semicorte o Repujado
        /// </summary>
        public static decimal CalcularSemicorteORepujado(Cotizacion cotizacion, Acabado acabado)
        {
            var precioMaximo = acabado.PrecioMaximo;
            var precioMinimo = acabado.PrecioMinimo;
            var millares = cotizacion.Millares;

            return ((!cotizacion.Montaje.In("1/2")) ?
                           precioMaximo : precioMinimo) * millares;
        }

        /// <summary>
        /// Calcula el valor del acabado UV Reserva
        /// </summary>
        public static decimal CalcularUVReserva(Cotizacion cotizacion, Acabado acabado)
        {
            var x = cotizacion.Corte.X;
            var y = cotizacion.Corte.Y;
            var precio = acabado.Precio;
            var precioMaximo = acabado.PrecioMaximo;
            var precioMinimo = acabado.PrecioMinimo;
            var impresionesTotales = cotizacion.ImpresionesTotales;

            var total = (x * y) * precio * impresionesTotales;

            total += (cotizacion.Montaje.In("1/2", "1/3")) ?
                                precioMaximo : precioMinimo;

            return total;
        }

        /// <summary>
        /// Calcula el valor del acabado UV Reserva doble
        /// </summary>
        public static decimal CalcularDobleUVReserva(Cotizacion cotizacion, Acabado acabado) =>
               CalcularUVReserva(cotizacion, acabado) * 2;

        /// <summary>
        /// Calcula el valor del acabado Sanduchado
        /// </summary>
        public static decimal CalcularSanduchado(Cotizacion cotizacion, Acabado acabado)
        {
            var precioMaximo = acabado.PrecioMaximo;
            var precioMinimo = acabado.PrecioMinimo;
            var millares = cotizacion.Millares;

            if (cotizacion.Montaje.In("1/2"))
                return 0;

            return ((!cotizacion.Montaje.In("1/4")) ?
                          precioMaximo : precioMinimo) * millares;
        }


    }
}
