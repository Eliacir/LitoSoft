using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogicaNegocio.Models
{

    /// <summary>
    /// Define una coleccion de acabados
    /// </summary>
    [Serializable]
    public class ColeccionAcabados
    {
        /// <summary>
        /// Define una coleccion de acabados
        /// </summary>
        public ColeccionAcabados()
        {
            Acabados = new List<Acabado>();
        }

        /// <summary>
        /// Devuelve la lista de acabados
        /// </summary>
        private IList<Acabado> Acabados { get; }

        /// <summary>
        /// Devuelve la lista de acabados
        /// </summary>
        public IList<Acabado> ObtenerTodos() => Acabados;

        /// <summary>
        /// Devuelve el acabado asociado al id especificado como parametro
        /// </summary>
        public Acabado ObtenerAcabado(string codigo) =>
               Acabados.Where(x => x.Codigo == codigo).FirstOrDefault();

        /// <summary>
        /// Agrega un acabado a la lista de acabados
        /// </summary>
        public void AgregarAcabado(Acabado acabado)
        {
            if (acabado == null) return;

            Acabados.Add(acabado);
        }

        /// <summary>
        /// Modifica un acabado a la lista de acabados
        /// </summary>
        public void ModificarAcabado(Acabado acabado)
        {
            if (acabado == null) return;

            var acabadoAModificar = ObtenerAcabado(acabado.Codigo);

            QuitarAcabado(acabadoAModificar);

            AgregarAcabado(acabado);
        }

        /// <summary>
        /// Elimina un acabado de la lista
        /// </summary>
        public void QuitarAcabado(Acabado acabado)
        {
            if (acabado == null) return;

            Acabados.Remove(acabado);
        }

        /// <summary>
        /// Elimina un acabado de la lista identificado con el id especificado
        /// </summary>
        public void QuitarAcabado(string codigo)
        {
            var acabado = ObtenerAcabado(codigo);

            if (acabado == null) return;

            Acabados.Remove(acabado);
        }

        /// <summary>
        /// Devuelve el numero de acabados de la coleccion
        /// </summary>
        public int ContarAcabados => Acabados.Count();

        /// <summary>
        /// Devuelve la sumatoria total del valor de los acabados
        /// </summary>
        public decimal TotalAcabados => Acabados.Sum(x => x.ValorTotal + (x.ValorTroquelado ?? 0));


    }
}
