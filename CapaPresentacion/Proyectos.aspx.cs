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
    public partial class Proyectos : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Proyectos";
            if (!Page.IsPostBack)
            {
                Boolean IsEditar = (bool)Session["IsEditar"];
                if (IsEditar)
                {
                    ValoresGVProyectos();
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
                    Proyecto proyecto = GetEditarEntity();
                    bool res = ohelper.ActualizarProyecto(proyecto);
                    if (res)
                    {
                        Response.Redirect("GestionarProyectos.aspx",false);
                    }
                }
                else
                {
                    Proyecto proyecto = GetEntity();
                    bool res = ohelper.InsertarProyecto(proyecto);
                    if (res)
                    {
                        Response.Redirect("GestionarProyectos.aspx",false);
                    }
                }             
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Proyectos", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
           
        }

        private void ValoresGVProyectos()
        {

            short IdProyecto = Cast.ToShort(Session["CodigoGP"]);

            using (var reader = ohelper.RecuperarProyectosPorIdProyectoReader(IdProyecto))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        txtNombre.Text = Cast.ToString(reader["Nombre"]);
                        txtDescripcion.Text = Cast.ToString(reader["Descripcion"]);
                        string estados = Cast.ToString(reader["Estado"]);
                        if (estados == "Activo")
                            dpEstadoProyecto.SelectedValue = "1";
                        else if (estados == "Inactivo")
                            dpEstadoProyecto.SelectedValue = "2";
                        else if (estados == "En Proceso")
                            dpEstadoProyecto.SelectedValue = "3";
                        else if (estados == "Finalizado")
                            dpEstadoProyecto.SelectedValue = "4";

                        txtArea.Text = Cast.ToString(reader["Area"]);
                        string IdEmp = Cast.ToString(reader["IdEmpleado"]);
                        if (!string.IsNullOrEmpty(IdEmp))
                        {
                            ddlEmpleados.SelectedValue = IdEmp;
                        }

                        string IdCliente = Cast.ToString(reader["IdCliente"]);
                        if (!string.IsNullOrEmpty(IdCliente))
                        {
                            DDLClientes.SelectedValue = IdCliente;
                        }
                    }

                }

            }



        }


        private Proyecto GetEntity()
        {
            Proyecto oProyecto = new Proyecto();
            oProyecto.IdProyecto = 0;
            oProyecto.Nombre = txtNombre.Text;
            oProyecto.Descripcion = txtDescripcion.Text;
            oProyecto.Estado = Convert.ToInt16(dpEstadoProyecto.SelectedValue);
            oProyecto.IdEmpleado = Convert.ToInt16(ddlEmpleados.SelectedValue);
            oProyecto.IdCliente = Convert.ToInt16(DDLClientes.SelectedValue);
            oProyecto.Area = txtArea.Text;

            return oProyecto;
        }



        private Proyecto GetEditarEntity()
        {
            Proyecto oProyecto = new Proyecto();
            oProyecto.IdProyecto = Convert.ToInt32(Session["CodigoGP"]);
            oProyecto.Nombre = txtNombre.Text;
            oProyecto.Descripcion = txtDescripcion.Text;
            oProyecto.Estado = Convert.ToInt16(dpEstadoProyecto.SelectedValue);
            oProyecto.IdEmpleado = Convert.ToInt16(ddlEmpleados.SelectedValue);
            oProyecto.IdCliente = Convert.ToInt16(DDLClientes.SelectedValue);
            oProyecto.Area = txtArea.Text;

            return oProyecto;
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProyectos.aspx");
        }
    }
}