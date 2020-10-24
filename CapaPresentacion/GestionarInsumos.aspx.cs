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
    public partial class GestionarInsumos : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        public Int16 Idproyecto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnAgregarInsumo.Enabled = true;
                Session["IsOtraPagina"] = true;
                Session["PanelPrincipal"] = "Gestionar Insumos";
                if (!Page.IsPostBack)
                {
                    bool IsEditar = Convert.ToBoolean(Session["IsEditar"]);
                    if (IsEditar)
                    {
                        Int16 CodProyecto = Convert.ToInt16(Session["CodigoGP"]);

                        ddlProyectos.DataSource = ohelper.RecuperarProyectosPorIdProyecto(CodProyecto);
                        ddlProyectos.DataTextField = "Nombre";
                        ddlProyectos.DataValueField = "IdProyecto";
                        ddlProyectos.DataBind();
                        //ddlProyectos.Items.Insert(0, new ListItem("[Seleccionar]","0"));

                        Idproyecto = Convert.ToInt16(ddlProyectos.SelectedValue);
                        CargarGrillaInsumos(Idproyecto);

                        Session["IsEditar"] = false;
                    }
                    else
                    {
                        short IdEmpleado = Convert.ToInt16(Session["IdEmpleado"].ToString());
                        ddlProyectos.DataSource = ohelper.RecuperarProyectosPorEmpleado(IdEmpleado);
                        ddlProyectos.DataTextField = "Nombre";
                        ddlProyectos.DataValueField = "IdProyecto";
                        ddlProyectos.DataBind();
                        //ddlProyectos.Items.Insert(0, new ListItem("[Seleccionar]","0"));
                        if (ddlProyectos.Items.Count <= 0)
                        {
                            string mensaje = "No tienes proyectos asignados.";
                            //Mensaje Error
                            ClientScript.RegisterStartupScript(this.GetType(), "Gestion Insumos", "<script>swal('" + mensaje + "')</script>");
                            btnAgregarInsumo.Enabled = false;
                        }
                        else
                        {
                            Idproyecto = Convert.ToInt16(ddlProyectos.SelectedValue);
                            CargarGrillaInsumos(Idproyecto);
                        }

                    }


                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {

            Session["IsEditar"] = false;
            Session["IdproyectoInsumos"] = Convert.ToInt16(ddlProyectos.SelectedValue);

            Response.Redirect("Insumos.aspx", false);
            GvInsumos.DataBind();
        }


        protected void ddlProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Idproyecto = Convert.ToInt16(ddlProyectos.SelectedValue);
            CargarGrillaInsumos(Idproyecto);

        }

        private void CargarGrillaInsumos(Int16 idproyecto)
        {
            GvInsumos.DataSource = ohelper.RecuperarDetalleProyectoPorIdProyecto(Idproyecto);
            GvInsumos.DataBind();
        }

        protected void GvInsumos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //Ocultamos la columna 1 "Codigo proyecto"
            e.Row.Cells[1].Visible = false;
        }

        protected void GvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ImageButton Imagen = (ImageButton)e.CommandSource;
                DataControlFieldCell Celda = (DataControlFieldCell)Imagen.Parent;
                GridViewRow fila = (GridViewRow)Celda.Parent;
                switch (e.CommandName)
                {
                    case "Actualizar":
                        {
                            Session["IsEditar"] = true;
                            Session["IdDetalleProyectoGI"] = GvInsumos.Rows[fila.RowIndex].Cells[0].Text;
                            Session["IdProyectoGI"] = GvInsumos.Rows[fila.RowIndex].Cells[1].Text;
                            Session["CantidadGI"] = GvInsumos.Rows[fila.RowIndex].Cells[2].Text.Replace("&nbsp;", "");
                            Session["DescripcionGI"] = GvInsumos.Rows[fila.RowIndex].Cells[3].Text.Replace("&nbsp;", "");
                            Session["ValorUnitarioGI"] = GvInsumos.Rows[fila.RowIndex].Cells[4].Text.Replace("&nbsp;", "");
                            Session["ValorTotalG1"] = GvInsumos.Rows[fila.RowIndex].Cells[5].Text.Replace("&nbsp;", "");
                            Session["ObservacionG1"] = GvInsumos.Rows[fila.RowIndex].Cells[6].Text.Replace("&nbsp;", "");

                            // Response.Redirect("EditarHojaVidaVehiculo.aspx?Id=" & IdHojaVidaVehiculo, True) envio
                            // ViewState("IdHojaVida") = Request.QueryString("Id") recibe
                            Response.Redirect("Insumos.aspx", false);
                            break;
                        }
                    case "Eliminar":
                        {
                            Session["IdDetalleProyectoGI"] = GvInsumos.Rows[fila.RowIndex].Cells[0].Text;
                            ohelper.EliminarDetalleProyecto(Convert.ToInt32(Session["IdDetalleProyectoGI"]));
                            string mensaje = "Insumo eliminado satisfactoriamente.";
                            //Mensaje ok
                            ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Insumos", "<script>swal('', '" + mensaje + "', 'success')</script>");
                            Idproyecto = Convert.ToInt16(ddlProyectos.SelectedValue);
                            CargarGrillaInsumos(Idproyecto);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Insumos", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }
        }
    }
}