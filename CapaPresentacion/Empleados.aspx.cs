using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Helpers;

namespace CapaPresentacion
{
    public partial class Empleados : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        public string IdEmpeladoInsertado = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Empleados";
            if (!Page.IsPostBack)
            {
                Boolean IsEditar = (bool)Session["IsEditar"];
                if (IsEditar)
                {
                    ValoresGVEmpleados();
                    btnRegistrar.Text = "Actualizar";
                    Session["IsEditar"] = false;
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegistrar.Text == "Actualizar")
                {
                    Empleado oEmpleado = GetEditarEmpleado();
                    bool res = ohelper.ActualizarEmpleado(oEmpleado);
                    if (res)
                    {
                        Usuario usuario = GetEditarUsuario();
                        ohelper.ActualizarUsuario(usuario);

                        Response.Redirect("GestionarEmpleados.aspx", false);
                    }
                }
                else
                {
                    Empleado oEmpleado = GetEmpleado();
                     IdEmpeladoInsertado = ohelper.InsertarEmpleado(oEmpleado);
                    if (IdEmpeladoInsertado != "")
                    {
                        Usuario usuario = GetUsuario();
                        if (!string.IsNullOrEmpty(usuario.NomUsuario) && (!string.IsNullOrEmpty(usuario.Clave)))
                        {
                            ohelper.InsertarUsuario(usuario);
                        }

                        Response.Redirect("GestionarEmpleados.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Empleados", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
           
        }

        private void ValoresGVEmpleados()
        {
            try
            {
                short IdEmpleado = Cast.ToShort(Session["IdEmpleadoGE"]);

                using (var reader = ohelper.RecuperarEmpleadoPorIdEmpleado(IdEmpleado))
                {
                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            string IdTipoDocumento = Convert.ToString(reader["IdTipoDocumento"]);
                            if (!string.IsNullOrEmpty(IdTipoDocumento))
                            {
                                dpTipoDocumento.SelectedValue = IdTipoDocumento;
                            }
       
                            txtNombres.Text = Cast.ToString(reader["Nombre"]);
                            txtApellidos.Text = Cast.ToString(reader["Apellidos"]);
                            txtNumeroDocumento.Text = Cast.ToString(reader["NumeroDocumento"]);
                            txtEdad.Text = Cast.ToString(reader["Edad"]);

                            string sexo = Cast.ToString(reader["Sexo"]);
                            if (sexo == "Masculino")
                            {
                                ddLSexo.SelectedValue = "1";
                            }
                            else
                            {
                                ddLSexo.SelectedValue = "2";
                            }


                            txtTelefono.Text = Cast.ToString(reader["Telefono"]);
                            txtDireccion.Text = Cast.ToString(reader["Direccion"]);
                            txtEmail.Text = Cast.ToString(reader["Email"]);

                            string estado = Cast.ToString(reader["IdEstado"]); 
                            if (!string.IsNullOrEmpty(estado))
                            {
                                dpEstadoEmpleado.SelectedValue = estado;
                            }

                            txtUsuario.Text = Cast.ToString(reader["Usuario"]); 
                            txtClave.Text = Cast.ToString(reader["Clave"]); 

                            string TipoUsuario = Cast.ToString(reader["IdTipoUsuario"]); 
                            if (!String.IsNullOrEmpty(TipoUsuario) && TipoUsuario != "0")
                            {
                                DdlTipoUsuario.Text = TipoUsuario;
                            }

                        }

                    }

                }




            }
            catch (Exception)
            {

                throw;
            }

        }

        private Empleado GetEmpleado()
        {
            Empleado oEmpleado = new Empleado();
            oEmpleado.IdEmpleado = 0;
            oEmpleado.Nombre = txtNombres.Text;
            oEmpleado.Apellidos = txtApellidos.Text;
            oEmpleado.IdTipoDocumento = Convert.ToInt16(dpTipoDocumento.SelectedValue);
            oEmpleado.NumeroDocumento = txtNumeroDocumento.Text;
            oEmpleado.Edad = Convert.ToInt16(txtEdad.Text);
            oEmpleado.Telefono = txtTelefono.Text;
            oEmpleado.Sexo = (ddLSexo.SelectedValue == "Femenino") ? "F" : "M";
            oEmpleado.Direccion = txtDireccion.Text;
            oEmpleado.Email = txtEmail.Text;
            oEmpleado.Estado = Convert.ToInt16(dpEstadoEmpleado.SelectedValue);

            return oEmpleado;
        }

        private Empleado GetEditarEmpleado()
        {
            Empleado oEmpleado = new Empleado();
            oEmpleado.IdEmpleado = Convert.ToInt32(Session["IdEmpleadoGE"]);
            oEmpleado.Nombre = txtNombres.Text;
            oEmpleado.Apellidos = txtApellidos.Text;
            oEmpleado.IdTipoDocumento = Convert.ToInt16(dpTipoDocumento.SelectedValue);
            oEmpleado.NumeroDocumento = txtNumeroDocumento.Text;
            oEmpleado.Edad = Convert.ToInt16(txtEdad.Text);
            oEmpleado.Telefono = txtTelefono.Text;
            oEmpleado.Sexo = (ddLSexo.SelectedValue == "Femenino") ? "F" : "M";
            oEmpleado.Direccion = txtDireccion.Text;
            oEmpleado.Email = txtEmail.Text;
            oEmpleado.Estado = Convert.ToInt16(dpEstadoEmpleado.SelectedValue);

            return oEmpleado;
        }

        private Usuario GetUsuario()
        {
            Usuario oUsuario = new Usuario();
            oUsuario.IdUsuario = 0;
           // oUsuario.IdEmpleado = Convert.ToInt32(IdEmpeladoInsertado);
            oUsuario.NomUsuario = txtUsuario.Text;
            oUsuario.Clave = txtClave.Text;
            oUsuario.IdTipoUsuario = Convert.ToInt16(DdlTipoUsuario.SelectedValue);
            return oUsuario;
        }

        private Usuario GetEditarUsuario()
        {
            Usuario oUsuario = new Usuario();
            oUsuario.IdUsuario = Convert.ToInt32(Session["IdUsuarioGE"]);
           // oUsuario.IdEmpleado = Convert.ToInt32(Session["IdEmpleadoGE"]);
            oUsuario.NomUsuario = txtUsuario.Text;
            oUsuario.Clave = txtClave.Text;
            oUsuario.IdTipoUsuario = Convert.ToInt16(DdlTipoUsuario.SelectedValue);
            return oUsuario;
        }

        #region MetodosaJAX

        public static List<Empleado> ListarEmpleados()
        {
            DataHelper ohelper = new DataHelper();
            List<Empleado> Lista = null;
            try
            {
                Lista = ohelper.ListarEmpleados();
            }
            catch (Exception ex)
            {
                Lista = null;
            }
            return Lista;
        }



        #endregion

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarEmpleados.aspx",false);
        }
    }
}