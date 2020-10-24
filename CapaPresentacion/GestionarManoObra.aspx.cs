using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using System.Data;
using CapaLogicaNegocio.Helpers;

namespace CapaPresentacion
{
    public partial class GestionarManoObra : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        public Int16 Idproyecto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnAgregaManoObra.Enabled = true;
                Session["IsOtraPagina"] = true;
                Session["PanelPrincipal"] = "Gestionar Mano de Obra";
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
                        CargarGrillaManoObra(Idproyecto);

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
                            btnAgregaManoObra.Enabled = false;
                        }
                        else
                        {
                            Idproyecto = Convert.ToInt16(ddlProyectos.SelectedValue);
                            CargarGrillaManoObra(Idproyecto);
                        }
                    }                  
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btnAgregarManoObra_Click(object sender, EventArgs e)
        {
            Session["IsEditar"] = false;
            Session["IdproyectoManoObra"] = Convert.ToInt16(ddlProyectos.SelectedValue);

            Response.Redirect("ManoObras.aspx", true);
            GvManoObra.DataBind();
        }


        protected void ddlProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Idproyecto = Convert.ToInt16(ddlProyectos.SelectedValue);
            CargarGrillaManoObra(Idproyecto);

        }

        private void CargarGrillaManoObra(Int16 idproyecto)
        {

           DataSet ds;
           DataTable dt;
           ds = ohelper.RecuperarManoObraPorIdProyecto(Idproyecto);
           GvManoObra.DataSource = ds;
           GvManoObra.DataBind();
           dt = ds.Tables[0];
           Session["dtManoObra"] = dt;
        }

        protected void GvManoObra_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //Ocultamos la columna 1 "Codigo proyecto"
            e.Row.Cells[1].Visible = false;
        }

        protected void GvManoObra_RowCommand(object sender, GridViewCommandEventArgs e)
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
                            Session["IdManoObraGM"] = GvManoObra.Rows[fila.RowIndex].Cells[0].Text;
                            Session["IdProyectoGM"] = GvManoObra.Rows[fila.RowIndex].Cells[1].Text;
                            Session["DescripcionGM"] = GvManoObra.Rows[fila.RowIndex].Cells[2].Text.Replace("&nbsp;", "");
                            Session["CantidadPersonasGM"] = GvManoObra.Rows[fila.RowIndex].Cells[3].Text.Replace("&nbsp;", "");
                            Session["TempoGM"] = GvManoObra.Rows[fila.RowIndex].Cells[4].Text.Replace("&nbsp;", "");

                            Response.Redirect("ManoObras.aspx", false);
                            break;
                        }
                    case "Eliminar":
                        {
                            Session["IdManoObraGM"] = GvManoObra.Rows[fila.RowIndex].Cells[0].Text;
                            ohelper.EliminarManoObra(Convert.ToInt32(Session["IdManoObraGM"]));
                            string mensaje = "Mano de obra eliminada satisfactoriamente.";
                            //Mensaje ok
                            ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Mano Obra", "<script>swal('', '" + mensaje + "', 'success')</script>");
                            Idproyecto = Convert.ToInt16(ddlProyectos.SelectedValue);
                            CargarGrillaManoObra(Idproyecto);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Mano Obra", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }
        }

        protected void GvManoObra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvManoObra.PageIndex = e.NewPageIndex;
        }

        protected void GvManoObra_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtbl = new DataTable();
            dtbl = (DataTable)Session["dtManoObra"];
            if (ViewState["SortOrder"] == null)
            {
                dtbl.DefaultView.Sort = e.SortExpression + " DESC";
                GvManoObra.DataSource = dtbl;
                GvManoObra.DataBind();
                ViewState["SortOrder"] = "DESC";
            }
            else
            {
                dtbl.DefaultView.Sort = e.SortExpression + "" + " ASC";
                GvManoObra.DataSource = dtbl;
                GvManoObra.DataBind();
                ViewState["SortOrder"] = null;
            }
        }
    }
}