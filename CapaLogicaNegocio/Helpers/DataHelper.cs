using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace CapaLogicaNegocio.Helpers
{
    [Serializable]
    public class DataHelper
    {
        DataAccess.DataAccess oacces = new DataAccess.DataAccess();

        #region LITOGRAFIA

        public IDataReader RecuperarAcabado(int idLitografia, string codigo)
        {
            return oacces.RecuperarAcabado(idLitografia, codigo);
        }

        public DataSet RecuperarAcabados(int idLitografia)
        {
            return oacces.RecuperarAcabados(idLitografia);
        }

        public void EliminarCliente(int Idcliente, Int32 IdLitografia)
        {
            oacces.EliminarCliente(Idcliente, IdLitografia);
        }

        public DataSet RecuperarClientesPorFiltro(int filtro, string texto)
        {
            try
            {
                return oacces.RecuperarClientesPorFiltro(filtro, texto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertarCliente(Cliente ocliente, Int32 idlitografia)
        {
            try
            {
                string res = oacces.InsertarCliente(ocliente.Nombre, ocliente.Documento, ocliente.Direccion, ocliente.Telefono, idlitografia);
                if (res.Contains("ok"))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RecuperarClientes(Int32 Idlitografia)
        {
            try
            {
                return oacces.RecuperarClientes(Idlitografia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RecuperarProductos(Int32 Idlitografia)
        {
            try
            {
                return oacces.RecuperarProductos(Idlitografia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RecuperarPapel(Int32 idLitografia)
        {
            try
            {
                return oacces.RecuperarPapel(idLitografia);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string RecuperarParametro(string Nombre, int IdLitografia)
        {
            return oacces.RecuperarParametro(Nombre, IdLitografia);
        }

        public DataSet RecuperarCorte(int idLitografia)
        {
            return oacces.RecuperarCorte(idLitografia);
        }

        public string RecuperarMontaje(int idCorte)
        {
            return oacces.RecuperarMontaje(idCorte);
        }

        public decimal RecuperarPrecioPapel(int idPapel)
        {
            return oacces.RecuperarPrecioPapel(idPapel);
        }

        public void ActualizarLitografia(InfoLitografia infoLitografia)
        {
            try
            {
                string usuario, clave;
                bool Estado;
                usuario = infoLitografia.UsuLitografia.NomUsuario;
                clave = infoLitografia.UsuLitografia.Clave;
                Estado = infoLitografia.UsuLitografia.Estado;

                oacces.ActualizarLitografia(infoLitografia.IdLitografia, infoLitografia.Nombre, infoLitografia.Direccion, infoLitografia.Telefono, infoLitografia.Imagen, usuario, clave, Estado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InactivarLitografia(int IdLitografia)
        {
            try
            {
                oacces.InactivarLitografia(IdLitografia);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataSet RecuperarLitografiasPorNombre(string texto)
        {
            try
            {
                return oacces.RecuperarLitografiasPorNombre(texto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader RecuperarLitografiaPorIdLitografia(short idLitografia)
        {
            try
            {
                return oacces.RecuperarLitografiaPorIdLitografia(idLitografia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RecuperarLitografias()
        {
            try
            {
                return oacces.RecuperarLitografias();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarLitografia(InfoLitografia infoLitografia)
        {
            try
            {
                string usuario, clave;
                bool Estado;
                usuario = infoLitografia.UsuLitografia.NomUsuario;
                clave = infoLitografia.UsuLitografia.Clave;
                Estado = infoLitografia.UsuLitografia.Estado;
                oacces.InsertarLitografia(infoLitografia.Nombre, infoLitografia.Direccion, infoLitografia.Telefono, infoLitografia.Imagen, usuario, clave, Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader RecuperarUsuario(string usuario, string clave)
        {
            try
            {
                return oacces.RecuperarUsuario(usuario, clave);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public DataSet RecuperarEmpleadosPorFiltro(int filtro, string texto)
        {
            try
            {
                return oacces.RecuperarEmpleadosPorFiltro(filtro, texto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RecuperarEmpleados()
        {
            try
            {
                return oacces.RecuperarEmpleados();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InsertarEmpresa(Empresa oEmpresa)
        {
            try
            {
                string res = oacces.InsertarEmpresa(oEmpresa.Nombre, oEmpresa.Ruc, oEmpresa.Direccion, oEmpresa.Telefono, oEmpresa.Correo);
                if (res.Contains("ok"))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarEmpresa(Empresa oEmpresa)
        {
            try
            {
                string res = oacces.ActualizarEmpresa(oEmpresa.IdEmpresa, oEmpresa.Nombre, oEmpresa.Ruc, oEmpresa.Direccion, oEmpresa.Telefono, oEmpresa.Correo);
                if (res.Contains("ok"))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEmpleado(int IdEmpleado)
        {
            oacces.EliminarEmpleado(IdEmpleado);
        }

        public bool ActualizarCliente(Cliente ocliente, Int32 idlitografia)
        {
            try
            {
                string res = oacces.ActualizarCliente(ocliente.Nombre, ocliente.Documento, ocliente.Direccion, ocliente.IdCliente, ocliente.Telefono, idlitografia);
                if (res.Contains("ok"))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader RecuperarClientePorIdcliente(short IdCliente, Int32 IdLitografia)
        {
            try
            {
                return oacces.RecuperarClientePorIdcliente(IdCliente, IdLitografia);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader RecuperarEmpresa()
        {
            try
            {
                return oacces.RecuperarEmpresa();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
