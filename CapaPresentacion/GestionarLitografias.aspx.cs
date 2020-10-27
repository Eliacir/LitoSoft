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
    public partial class GestionarLitografias : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Litografias";
            if (!Page.IsPostBack)
            {
                CargarLitografias();
            }
        }

        protected void btnAgregarLitografia_Click(object sender, EventArgs e)
        {
            Session["IsEditar"] = false;
            Response.Redirect("Litografia.aspx", false);
            GvLitografia.DataBind();
        }




        protected void GvCliente_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtbl = new DataTable();
            dtbl = (DataTable)Session["dtLitografia"];
            if (ViewState["SortOrder"] == null)
            {
                dtbl.DefaultView.Sort = e.SortExpression + " DESC";
                GvLitografia.DataSource = dtbl;
                GvLitografia.DataBind();
                ViewState["SortOrder"] = "DESC";
            }
            else
            {
                dtbl.DefaultView.Sort = e.SortExpression + "" + " ASC";
                GvLitografia.DataSource = dtbl;
                GvLitografia.DataBind();
                ViewState["SortOrder"] = null;
            }
        }

        protected void GvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvLitografia.PageIndex = e.NewPageIndex;
        }


        public void CargarLitografias()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = ohelper.RecuperarLitografias();
            GvLitografia.DataSource = ds;
            GvLitografia.DataBind();
            dt = ds.Tables[0];
            Session["dtLitografia"] = dt;
        }

        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GvLitografia_RowCommand(object sender, GridViewCommandEventArgs e)
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

                            Session["IdLitografia"] = GvLitografia.Rows[fila.RowIndex].Cells[0].Text;
                            GvLitografia.Rows[fila.RowIndex].Cells[1].Text.Replace("&nbsp;", "");
                            GvLitografia.Rows[fila.RowIndex].Cells[2].Text.Replace("&nbsp;", "");
                            GvLitografia.Rows[fila.RowIndex].Cells[3].Text.Replace("&nbsp;", "");
                            Response.Redirect("Litografia.aspx", false);
                            break;
                        }
                    case "Eliminar":
                        {
                           
                            try
                            {
                                Session["IdLitografia"] = GvLitografia.Rows[fila.RowIndex].Cells[0].Text;
                                ohelper.InactivarLitografia(Convert.ToInt32(Session["IdLitografia"]));
                                string mensaje = "Usuario de litografia desactivado satisfactoriamente.";
                                //Mensaje ok
                                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Litografia", "<script>swal('', '" + mensaje + "', 'success')</script>");
                                CargarLitografias();
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Litografias", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }
        }



        protected void btnBuscarLitografias_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfiltro.Text.Length > 2)
                {
                    GvLitografia.DataSource = ohelper.RecuperarLitografiasPorNombre(txtfiltro.Text);
                    GvLitografia.DataBind();
                }
                else
                {
                    CargarLitografias();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}