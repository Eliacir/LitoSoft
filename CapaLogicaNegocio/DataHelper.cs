using CapaEntidades;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CapaLogicaNegocio
{

    public class DataHelper
    {
        DataAccess.DataAccess oacces = new DataAccess.DataAccess();

        #region LITOGRAFIA

        public void EliminarCliente(int Idcliente,Int32 IdLitografia)
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

        public bool InsertarCliente(Cliente ocliente,Int32 idlitografia)
        {
            try
            {
                string res = oacces.InsertarCliente(ocliente.Nombre, ocliente.Documento, ocliente.Direccion, ocliente.Telefono,idlitografia);
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

        public string RecuperarParametro(string Nombre,int IdLitografia)
        {
           return oacces.RecuperarParametro(Nombre, IdLitografia);
        }

        public DataSet RecuperarCorte()
        {
            return oacces.RecuperarCorte();
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


        public DataSet RecuperarLitografiasPorNombre( string texto)
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
                oacces.InsertarLitografia(infoLitografia.Nombre,infoLitografia.Direccion,infoLitografia.Telefono,infoLitografia.Imagen,usuario,clave,Estado);
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

        public object RecuperarDetalleCotizacionPorFiltro(int filtro, string texto)
        {
            try
            {
                return oacces.RecuperarDetalleCotizacionPorFiltro(filtro, texto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet RecuperarDetalleCotizacion(int idcotizacion)
        {
            try
            {
                return oacces.RecuperarDetalleCotizacion(idcotizacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet RecuperarCotizacionesPorFiltro(int filtro, string texto)
        {
            try
            {
                return oacces.RecuperarCotizacionesPorFiltro(filtro, texto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
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

        public DataSet RecuperarCotizaciones()
        {
            try
            {
                return oacces.RecuperarCotizaciones();
            }
            catch (Exception)
            {

                throw;
            }
        }


      
        public DataSet RecuperarProyectosPorNombre(string text)
        {
            return oacces.RecuperarProyectosPorNombre(text);
        }
        public IDataReader recuperarCotizacionPorIdCotizacion(int IdCotizacion)
        {
            try
            {
                return oacces.recuperarCotizacionPorIdCotizacion(IdCotizacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader RecuperarImagenReporteCotizacion(int IdCotizacion)
        {
            try
            {
                return oacces.RecuperarImagenReporteCotizacion(IdCotizacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertarCotizacion(CotizacionEnti ocotizacion)
        {
            try
            {
                string res = oacces.InsertarCotizacion(ocotizacion.CodigoCotizacion, ocotizacion.IdProyecto, ocotizacion.ValidezOferta, ocotizacion.TiempoEntrega, ocotizacion.LugarEntrega, ocotizacion.Garantia, ocotizacion.Nota, ocotizacion.AlcancePropuesta);
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

        public bool ActualizarCotizacion(CotizacionEnti ocotizacion)
        {
            try
            {
                string res = oacces.ActualizarCotizacion(ocotizacion.IdCotizacion, ocotizacion.CodigoCotizacion, ocotizacion.IdProyecto, ocotizacion.ValidezOferta, ocotizacion.TiempoEntrega, ocotizacion.LugarEntrega, ocotizacion.Garantia, ocotizacion.Nota, ocotizacion.AlcancePropuesta);
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

        public void InsertarDetalleCotizacion(int IdCotizacion, string Descripcion, string Cantidad, decimal Valor)
        {
            oacces.InsertarDetalleCotizacion(IdCotizacion, Descripcion, Cantidad, Valor);
        }

        public void ActualizarDetalleCotizacion(int IdDetalleCotizacion, string Descripcion, string Cantidad, decimal Valor)
        {
            oacces.ActualizarDetalleCotizacion(IdDetalleCotizacion, Descripcion, Cantidad, Valor);
        }

        public string InsertarEmpleado(Empleado oempleado)
        {
            try
            {
                string res = oacces.InsertarEmpleado(oempleado.Nombre, oempleado.Apellidos, oempleado.IdTipoDocumento, oempleado.NumeroDocumento, oempleado.Edad
                            , oempleado.Sexo, oempleado.Telefono, oempleado.Direccion, oempleado.Email, oempleado.Estado);
                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarEmpleado(Empleado oempleado)
        {
            try
            {
                string res = oacces.ActualizarEmpleado(oempleado.Nombre, oempleado.Apellidos, oempleado.IdTipoDocumento, oempleado.NumeroDocumento, oempleado.Edad
                            , oempleado.Sexo, oempleado.Telefono, oempleado.Direccion, oempleado.Email, oempleado.Estado, oempleado.IdEmpleado);
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


        public IDataReader RecuperarDetalleCotizacionPorIdDetalle(int IdDetalleCotizacion)
        {
            return oacces.RecuperarDetalleCotizacionPorIdDetalleCotizacion(IdDetalleCotizacion);
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

        public void EliminarDetalleCotizacion(int IdDetalleCotizacion)
        {
            oacces.EliminarDetalleCotizacion(IdDetalleCotizacion);
        }


        public void EliminarEmpleado(int IdEmpleado)
        {
            oacces.EliminarEmpleado(IdEmpleado);
        }


        public void EliminarImagenesPorProyecto(int IdProyecto)
        {
            oacces.EliminarImagenesPorProyecto(IdProyecto);
        }

        public void EliminarProyecto(int IdProyecto)
        {
            oacces.EliminarProyecto(IdProyecto);
        }

        public void EliminarDetalleProyecto(int IdDetalleProyecto)
        {
            oacces.EliminarDetalleProyecto(IdDetalleProyecto);
        }

        public void EliminarManoObra(int IdManoObra)
        {
            oacces.EliminarManoObra(IdManoObra);
        }


        public void EliminarCotizacion(int IdCotizacion)
        {
            oacces.EliminarCotizacion(IdCotizacion);
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

        public bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                //string res = oacces.InsertarUsuario(usuario.IdEmpleado, usuario.NomUsuario, usuario.Clave, usuario.IdTipoUsuario);
                //if (res.Contains("ok"))
                //{
                //    return true;
                //}
                //else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool ActualizarUsuario(Usuario usuario)
        {
            try
            {
                //string res = oacces.ActualizarUsuario(usuario.IdEmpleado, usuario.NomUsuario, usuario.Clave, usuario.IdTipoUsuario, usuario.IdUsuario);
                //if (res.Contains("ok"))
                //{
                //    return true;
                //}
                //else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertarDetalleProyecto(Insumo insumo)
        {
            try
            {
                string res = oacces.InsertarDetalleProyecto(insumo.IdProyecto, insumo.Cantidad, insumo.Descripcion, insumo.ValorUni, insumo.ValorTotal, insumo.Observacion);
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

        public bool ActualizarDetalleProyecto(Insumo insumo)
        {
            try
            {
                string res = oacces.ActualizarDetalleProyecto(insumo.IdProyecto, insumo.Cantidad, insumo.Descripcion, insumo.ValorUni, insumo.ValorTotal, insumo.Observacion, insumo.IdDetalleproyecto);
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


        public bool InsertarmanoDeObra(ManoObra manoObra)
        {
            try
            {
                string res = oacces.InsertarmanoDeObra(manoObra.IdProyecto, manoObra.Descripcion, manoObra.CantidadPersonas, manoObra.Tiempo);
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

        public bool ActualizarProyecto(Proyecto proyecto)
        {
            try
            {
                string res = oacces.ActualizarProyecto(proyecto.Nombre, proyecto.Descripcion, proyecto.Estado, proyecto.IdEmpleado, proyecto.IdCliente, proyecto.Area, proyecto.IdProyecto);
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

        public bool ActualizarManoDeObra(ManoObra manoObra)
        {
            try
            {
                string res = oacces.ActualizarManoDeObra(manoObra.IdProyecto, manoObra.Descripcion, manoObra.CantidadPersonas, manoObra.Tiempo, manoObra.IdManoObra);
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

        public bool InsertarProyecto(Proyecto proyecto)
        {
            try
            {
                string res = oacces.InsertarProyecto(proyecto.Nombre, proyecto.Descripcion, proyecto.Estado, proyecto.IdEmpleado, proyecto.IdCliente, proyecto.Area);
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

      
        public DataSet RecuperarProyectosPorEmpleado(short Idempleado)
        {
            try
            {
                return oacces.RecuperarProyectosPorEmpleado(Idempleado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RecuperarProyectos()
        {
            try
            {
                return oacces.RecuperarProyectos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RecuperarProyectosPorIdProyecto(short IdProyecto)
        {
            try
            {
                return oacces.RecuperarProyectosPorIdProyecto(IdProyecto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IDataReader RecuperarProyectosPorIdProyectoReader(short IdProyecto)
        {
            try
            {
                return oacces.RecuperarProyectosPorIdProyectoReader(IdProyecto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader RecuperarEmpleadoPorIdEmpleado(short IdEmpleado)
        {
            try
            {
                return oacces.RecuperarEmpleadoPorIdEmpleado(IdEmpleado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IDataReader RecuperarDetalleProyectoPorIdDetalleProyecto(short IdDetalleProyecto)
        {
            try
            {
                return oacces.RecuperarDetalleProyectoPorIdDetalleProyecto(IdDetalleProyecto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader RecuperarManoObraPorIdManoObra(short IdManoObra)
        {
            try
            {
                return oacces.RecuperarManoObraPorIdManoObra(IdManoObra);

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

        public DataSet RecuperarDetalleProyectoPorIdProyecto(short IdProyecto)
        {
            try
            {
                return oacces.RecuperarDetalleProyectoPorIdProyecto(IdProyecto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet RecuperarManoObraPorIdProyecto(short IdProyecto)
        {
            try
            {
                return oacces.RecuperarManoObraPorIdProyecto(IdProyecto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RecuperarImagenes(Int32 IdProyecto)
        {
            try
            {
                return oacces.RecuperarImagenes(IdProyecto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertarImagenProyecto(ImagenesProyectos imagenesProyectos)
        {
            try
            {
                string res = oacces.InsertarImagenProyecto(imagenesProyectos.IdProyecto, imagenesProyectos.Imagen, imagenesProyectos.Tituloimagen, imagenesProyectos.NumeroImagen);
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

        public List<Empleado> ListarEmpleados()
        {
            try
            {
                return oacces.ListarEmpleados();
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

        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image ImagenOriginal, int Alto)
        {
            var Radio = (double)Alto / ImagenOriginal.Height;
            var NuevoAncho = (int)(ImagenOriginal.Width * Radio);
            var NuevoAlto = (int)(ImagenOriginal.Height * Radio);
            var NuevaimagenRedimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(NuevaimagenRedimencionada);
            g.DrawImage(ImagenOriginal, 0, 0, NuevoAncho, NuevoAlto);
            return NuevaimagenRedimencionada;
        }
    }
}
