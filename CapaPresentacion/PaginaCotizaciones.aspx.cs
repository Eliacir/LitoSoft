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

                ViewState["idcliente"] = 0;

                ViewState["idcliente"]  = Cast.ToInt(Request.QueryString["Id"]);

                if (Cast.ToInt(ViewState["idcliente"]) == 0)
                {
                    DDFiltro.Items.Insert(3, "Cliente");
                }

                //Comentado mientras se implementa la recuperacion los datos
                CargarCotizaciones();

            }
        }

        protected void btnAgregarCotizacion_Click(object sender, EventArgs e)
        {
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

                ViewState["IdCotizacion"] = Convert.ToInt32(this.GvCotizacion.DataKeys[fila.RowIndex].Value);

                var IdCotizacion = ViewState["IdCotizacion"];

                switch (e.CommandName)
                {

                    case "Imprimir":
                        {
     
                            Response.Redirect("ImprimirCotizacion.aspx?IdCotizacion=" + IdCotizacion, false);

                            break;
                        }
                    case "Eliminar":
                        {
                            ohelper.EliminarCotizacion(Cast.ToInt(IdCotizacion));
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
               // e.Row.Cells[0].Visible = false;

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
                    if (Cast.ToInt(ViewState["idcliente"]) > 0)
                    {
                        GvCotizacion.DataSource = ohelper.RecuperarCotizacionIdClientePorFiltro(Convert.ToInt32(DDFiltro.SelectedIndex), txtfiltro.Text, Cast.ToInt(ViewState["idcliente"]));
                        GvCotizacion.DataBind();
                    }
                    else 
                    {
                        GvCotizacion.DataSource = ohelper.RecuperarCotizacionesPorFiltro(Convert.ToInt32(DDFiltro.SelectedIndex), txtfiltro.Text);
                        GvCotizacion.DataBind();
                    }               
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

            if (Cast.ToInt(ViewState["idcliente"]) > 0)
            {
                ds = ohelper.RecuperarCotizacionPorIdCliente(Cast.ToInt(ViewState["idcliente"]));
                GvCotizacion.Columns[1].Visible = false;
                btnAgregarCotizacion.Visible = false;
            }
            else
            {
                ds = ohelper.RecuperarCotizaciones();
            }
                             
            GvCotizacion.DataSource = ds;
            GvCotizacion.DataBind();
            dt = ds.Tables[0];
            Session["dtCotizacion"] = dt;
        }

    }
}