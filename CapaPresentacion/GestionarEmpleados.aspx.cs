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
    public partial class GestionarEmpleados : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Empleados";
            if (!Page.IsPostBack)
            {
                Session["IsOtraPagina"] = false;
                CargarEmpleados();
            }
        }

        protected void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            Session["IsEditar"] = false;
            Response.Redirect("Empleados.aspx", false);
            GvEmpleado.DataBind();
        }

        protected void GvEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
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

                            Session["IdEmpleadoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[0].Text;
                            Session["NombreGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[1].Text.Replace("&nbsp;", "");
                            Session["ApellidosGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[2].Text.Replace("&nbsp;", "");
                            Session["NumeroDocumentoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[3].Text.Replace("&nbsp;", "");
                            Session["SexoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[4].Text.Replace("&nbsp;", "");
                            Session["TelefonoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[5].Text.Replace("&nbsp;", "");
                            Session["DireccionGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[6].Text.Replace("&nbsp;", "");
                            Session["EmailGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[7].Text.Replace("&nbsp;", "");
                            Session["EstadoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[8].Text.Replace("&nbsp;", "");
                            Session["IdTipoDocumentoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[9].Text.Replace("&nbsp;", "");
                            Session["TipoDocumentoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[10].Text.Replace("&nbsp;", "");
                            Session["UsuarioGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[11].Text.Replace("&nbsp;", "");
                            Session["ClaveGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[12].Text.Replace("&nbsp;", "");
                            Session["IdTipoUsuarioGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[13].Text.Replace("&nbsp;", "");
                            Session["EdadGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[14].Text.Replace("&nbsp;", "");
                            Session["IdEstadoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[15].Text.Replace("&nbsp;", "");
                            Session["IdUsuarioGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[16].Text.Replace("&nbsp;", "");
                            Response.Redirect("Empleados.aspx", false);
                            break;
                        }
                    case "Eliminar":
                        {
                            Session["IdEmpleadoGE"] = GvEmpleado.Rows[fila.RowIndex].Cells[0].Text;
                            ohelper.EliminarEmpleado(Convert.ToInt32(Session["IdEmpleadoGE"]));
                            string mensaje = "Empleado eliminado satisfactoriamente.";
                            //Mensaje ok
                            ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Empleados", "<script>swal('', '" + mensaje + "', 'success')</script>");
                            CargarEmpleados();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Empleados", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }
        }

        public  void CargarEmpleados()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = ohelper.RecuperarEmpleados();
            GvEmpleado.DataSource = ds;
            GvEmpleado.DataBind();
            dt = ds.Tables[0];
            Session["dtEmpleados"] = dt;
        }

        protected void GvEmpleado_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[16].Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvEmpleado_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtbl = new DataTable();
            dtbl = (DataTable)Session["dtEmpleados"];
            if (ViewState["SortOrder"] == null)
            {
                dtbl.DefaultView.Sort = e.SortExpression + " DESC";
                GvEmpleado.DataSource = dtbl;
                GvEmpleado.DataBind();
                ViewState["SortOrder"] = "DESC";
            }
            else
            {
                dtbl.DefaultView.Sort = e.SortExpression + "" + " ASC";
                GvEmpleado.DataSource = dtbl;
                GvEmpleado.DataBind();
                ViewState["SortOrder"] = null;
            }
        }

        protected void GvEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmpleado.PageIndex = e.NewPageIndex;
        }

        protected void btnBuscarRepresentante_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfiltro.Text.Length > 2 && DDFiltro.SelectedIndex > 0)
                {
                    GvEmpleado.DataSource = ohelper.RecuperarEmpleadosPorFiltro(Convert.ToInt32(DDFiltro.SelectedIndex), txtfiltro.Text);
                    GvEmpleado.DataBind();
                }
                else
                {
                    CargarEmpleados();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}