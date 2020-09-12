using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class Configuracion : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        public int IdEmpresa;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Configuración";
            if (!Page.IsPostBack)
            {
                RecuperarEmpresa();
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegistrar.Text.Equals("Registrar"))
                {
                    Empresa oEmpresa = GetEmpresa();
                    bool res = ohelper.InsertarEmpresa(oEmpresa);
                    if (res)
                    {
                        btnRegistrar.Text = "Actualizar";
                        string mensaje = "Registro  creado satisfactoriamente.!";
                        //Mensaje Ok
                        ClientScript.RegisterStartupScript(this.GetType(), "Configuración", "<script>swal('', '" + mensaje + "', 'success')</script>");

                    }
                }
                else
                {
                    Empresa oEmpresa = EditarEmpresa();
                    bool res = ohelper.ActualizarEmpresa(oEmpresa);
                    if (res)
                    {
                        string mensaje = "Registro  actualizado satisfactoriamente.!";
                        //Mensaje Ok
                        ClientScript.RegisterStartupScript(this.GetType(), "Configuración", "<script>swal('', '" + mensaje + "', 'success')</script>");
                    }
                }              
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Configuración", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }

        }

        private Empresa GetEmpresa()
        {
            Empresa oEmpresa = new Empresa();
            oEmpresa.IdEmpresa = 0;
            oEmpresa.Nombre = txtNombre.Text;
            oEmpresa.Ruc = txtDocumento.Text;
            oEmpresa.Direccion = txtDireccion.Text;
            oEmpresa.Telefono = txtTelefono.Text;
            oEmpresa.Correo = txtEmail.Text;
            return oEmpresa;
        }



        private Empresa EditarEmpresa()
        {
            Empresa oEmpresa = new Empresa();
            oEmpresa.IdEmpresa = (int)Session["IdEmpresa"];
            oEmpresa.Nombre = txtNombre.Text;
            oEmpresa.Ruc = txtDocumento.Text;
            oEmpresa.Direccion = txtDireccion.Text;
            oEmpresa.Telefono = txtTelefono.Text;
            oEmpresa.Correo = txtEmail.Text;

            return oEmpresa;
        }

        public void RecuperarEmpresa()
        {
            Empresa oEmpresa = new Empresa();
            try
            {

                //  [Nombre],[Ruc],[Direccion],[Telefono],[Correo]
                using (IDataReader rEmpresa = ohelper.RecuperarEmpresa())
                {
                    if (rEmpresa.Read())
                    {
                        IdEmpresa = Convert.ToInt32(rEmpresa["IdEmpresa"].ToString());
                        txtNombre.Text = rEmpresa["Nombre"].ToString();
                        txtDocumento.Text = rEmpresa["Ruc"].ToString();
                        txtDireccion.Text = rEmpresa["Direccion"].ToString();
                        txtTelefono.Text = rEmpresa["Telefono"].ToString();
                        txtEmail.Text = rEmpresa["Correo"].ToString();

                        Session["IdEmpresa"] = IdEmpresa;

                        btnRegistrar.Text = "Actualizar";
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
            Response.Redirect("PanelGeneral.aspx",false);
        }

    }
}