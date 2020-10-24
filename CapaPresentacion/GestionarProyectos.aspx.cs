using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class GestionarProyectos : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Proyectos";
            if (!Page.IsPostBack)
            {
                CargarProyectos();
            }
        }


        protected void btnAgregarProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                Session["IsEditar"] = false;
                Response.Redirect("Proyectos.aspx");
                GvProyecto.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected void GvProyecto_RowCommand(object sender, GridViewCommandEventArgs e)
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
                            Session["CodigoGP"] = GvProyecto.Rows[fila.RowIndex].Cells[0].Text;
                            Session["NombreGP"] = GvProyecto.Rows[fila.RowIndex].Cells[1].Text.Replace("&nbsp;", "");
                            Session["DescripcionGP"] = GvProyecto.Rows[fila.RowIndex].Cells[2].Text;
                            Session["EstadoGP"] = GvProyecto.Rows[fila.RowIndex].Cells[3].Text;
                            Session["AreaGP"] = GvProyecto.Rows[fila.RowIndex].Cells[4].Text.Replace("&nbsp;", "");
                            Session["IdEmpleadoGP"] = GvProyecto.Rows[fila.RowIndex].Cells[5].Text;
                            Session["IdClienteGP"] = GvProyecto.Rows[fila.RowIndex].Cells[7].Text;

                            Response.Redirect("Proyectos.aspx", false);
                            break;
                        }
                    case "DetalleInsumo":
                        {
                            Session["IsEditar"] = true;
                            Session["CodigoGP"] = GvProyecto.Rows[fila.RowIndex].Cells[0].Text;

                            Response.Redirect("GestionarInsumos.aspx", false);
                            break;
                        }
                    case "DetalleManoObra":
                        {
                            Session["IsEditar"] = true;
                            Session["CodigoGP"] = GvProyecto.Rows[fila.RowIndex].Cells[0].Text;

                            Response.Redirect("GestionarManoObra.aspx", false);
                            break;
                        }
                    case "Eliminar":
                        {
                            Session["CodigoGP"] = GvProyecto.Rows[fila.RowIndex].Cells[0].Text;
                            ohelper.EliminarProyecto(Convert.ToInt32(Session["CodigoGP"]));
                            string mensaje = "Proyecto eliminado satisfactoriamente.";
                            //Mensaje ok
                            ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Proyectos", "<script>swal('', '" + mensaje + "', 'success')</script>");
                            CargarProyectos();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Proyectos", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }

        }

        protected void GvProyecto_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCargarImagenes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestionarimagenes.aspx", false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text.Length > 2)
                {
                    GvProyecto.DataSource = ohelper.RecuperarProyectosPorNombre(txtBuscar.Text);
                    GvProyecto.DataBind();
                }
                else
                {
                    CargarProyectos();
                }
            }
            catch (Exception)
            {

                throw;
            }           
        }

        protected void GvProyecto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvProyecto.PageIndex = e.NewPageIndex;
        }

        protected void GvProyecto_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtbl = new DataTable();
            dtbl = (DataTable)Session["dtProyectos"];
            if (ViewState["SortOrder"] == null)
            {
                dtbl.DefaultView.Sort = e.SortExpression + " DESC";
                GvProyecto.DataSource = dtbl;
                GvProyecto.DataBind();
                ViewState["SortOrder"] = "DESC";
            }
            else
            {
                dtbl.DefaultView.Sort = e.SortExpression + "" + " ASC";
                GvProyecto.DataSource = dtbl;
                GvProyecto.DataBind();
                ViewState["SortOrder"] = null;
            }
        }


        public void CargarProyectos()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = ohelper.RecuperarProyectos();
            GvProyecto.DataSource = ds;
            GvProyecto.DataBind();
            dt = ds.Tables[0];
            Session["dtProyectos"] = dt;
        }

    }
     
}