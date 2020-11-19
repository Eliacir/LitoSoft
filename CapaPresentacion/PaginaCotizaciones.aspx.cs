using CapaLogicaNegocio.Helpers;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class PaginaCotizaciones : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;

            Session["PanelPrincipal"] = "Gestionar Cotizaciones";

            var idLitografia = Cast.ToInt(Session["IdLitografia"]);

            if (!Page.IsPostBack)
            {
                //Comentado mientras se implementa la recuperacion los datos
                //CargarCotizaciones();

            }
        }

        protected void btnAgregarCotizacion_Click(object sender, EventArgs e)
        {
            Session["IsEditar"] = false;
            Response.Redirect("PaginaCotizacion.aspx", false);
            GvCotizacion.DataBind();
        }

        protected void GvCotizacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ImageButton Imagen = (ImageButton)e.CommandSource;
                DataControlFieldCell Celda = (DataControlFieldCell)Imagen.Parent;
                GridViewRow fila = (GridViewRow)Celda.Parent;

                switch (e.CommandName)
                {

                    case "Imprimir":
                        {
                            var IdCotizacion = GvCotizacion.Rows[fila.RowIndex].Cells[0].Text;

                            //Comentado mientras se implementa la carga de los daos en la grilla 
                            // Response.Redirect("ImprimirCotizacion.aspx?IdCotizacion=" + IdCotizacion, false);

                            break;
                        }
                    case "Actualizar":
                        {
                            Session["IsEditar"] = true;
                            Session["IdCotizacion"] = GvCotizacion.Rows[fila.RowIndex].Cells[0].Text;
                            Response.Redirect("PaginaCotizacion.aspx", false);
                            break;
                        }
                    case "Eliminar":
                        {
                            Session["IdCotizacion"] = GvCotizacion.Rows[fila.RowIndex].Cells[0].Text;
                            // ohelper.EliminarCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
                            string mensaje = "Cotización eliminada satisfactoriamente.";
                            //Mensaje ok
                            ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Cotización", "<script>swal('', '" + mensaje + "', 'success')</script>");
                            CargarCotizaciones();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Replace("'", "");
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Cotización", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }
        }

        protected void GvCotizacion_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[8].Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnBuscarCotizaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtfiltro.Text) && DDFiltro.SelectedIndex > 0)
                {
                    //GvCotizacion.DataSource = ohelper.RecuperarCotizacionesPorFiltro(Convert.ToInt32(DDFiltro.SelectedIndex), txtfiltro.Text,idLitografia);
                    GvCotizacion.DataBind();
                }
                else
                {
                    CargarCotizaciones();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GvCotizacion_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtbl = new DataTable();
            dtbl = (DataTable)Session["dtCotizacion"];
            if (ViewState["SortOrder"] == null)
            {
                dtbl.DefaultView.Sort = e.SortExpression + " DESC";
                GvCotizacion.DataSource = dtbl;
                GvCotizacion.DataBind();
                ViewState["SortOrder"] = "DESC";
            }
            else
            {
                dtbl.DefaultView.Sort = e.SortExpression + "" + " ASC";
                GvCotizacion.DataSource = dtbl;
                GvCotizacion.DataBind();
                ViewState["SortOrder"] = null;
            }
        }

        protected void GvCotizacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCotizacion.PageIndex = e.NewPageIndex;
        }


        public void CargarCotizaciones()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //ds = ohelper.RecuperarCotizaciones(idlitografia);
            GvCotizacion.DataSource = ds;
            GvCotizacion.DataBind();
            dt = ds.Tables[0];
            Session["dtCotizacion"] = dt;
        }

    }
}