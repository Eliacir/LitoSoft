using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class Clientes : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["IsOtraPagina"] = true;
                Session["PanelPrincipal"] = "Gestionar Clientes";
                if (!Page.IsPostBack)
                {
                    Boolean IsEditar = (bool)Session["IsEditar"];
                    if (IsEditar)
                    {
                        ValoresGVClientes();
                        btnRegistrar.Text = "Actualizar";
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Representante", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
           
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegistrar.Text == "Actualizar")
                {
                    Cliente oCliente = GetEditarCliente();
                    bool res = ohelper.ActualizarCliente(oCliente,0);
                    if (res)
                    {
                        Response.Redirect("GestionarClientes.aspx", false);
                    }
                }
                else
                {
                    Cliente oCliente = GetCliente();
                    bool res = ohelper.InsertarCliente(oCliente,0);
                    if (res)
                    {
                        Response.Redirect("GestionarClientes.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
               string mensaje = ex.Message;
               ClientScript.RegisterStartupScript(this.GetType(), "Clientes", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }
           
        }

        private Cliente GetCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.IdCliente = 0;
            oCliente.Nombre = txtNombre.Text;
            oCliente.Documento = txtDocumento.Text;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.Telefono = txtTelefono.Text;


            return oCliente;
        }

        private Cliente GetEditarCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.IdCliente = Convert.ToInt32(Session["IdClienteGC"]);
            oCliente.Nombre = txtNombre.Text;
            oCliente.Documento = txtDocumento.Text;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.Telefono = txtTelefono.Text;


            return oCliente;
        }



        private void ValoresGVClientes()
        {
            try
            {
                short IdCliente = Cast.ToShort(Session["IdClienteGC"]);

                using (var reader = ohelper.RecuperarClientePorIdcliente(IdCliente,0))
                {
                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            txtNombre.Text = Cast.ToString(reader["Nombre"]);
                            txtDocumento.Text = Cast.ToString(reader["Ruc"]);
                            txtDireccion.Text = Cast.ToString(reader["Direccion"]);
                            txtTelefono.Text = Cast.ToString(reader["Telefono"]);
                            txtEmail.Text = Cast.ToString(reader["Email"]);
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarClientes.aspx", false);
        }
    }
}