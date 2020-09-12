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

namespace CapaPresentacion
{
    public partial class GestionarCotizaciones : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Cotizaciones";
            if (!Page.IsPostBack)
            {
                CargarCotizaciones();

            }
        }

        protected void btnAgregarCotizacion_Click(object sender, EventArgs e)
        {
            Session["IsEditar"] = false;
            Response.Redirect("Cotizaciones.aspx", false);
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
                    case "Actualizar":
                        {
                            Session["IsEditar"] = true;
                            Session["IdCotizacion"] = GvCotizacion.Rows[fila.RowIndex].Cells[0].Text;
                            Response.Redirect("Cotizaciones.aspx", false);
                            break;
                        }

                    case "DetalleCotizacion":
                        {
                            Session["IdCotizacion"] = GvCotizacion.Rows[fila.RowIndex].Cells[0].Text;
                            Response.Redirect("DetalleCotizacion.aspx", false);
                            break;
                        }
                    case "GenerarPdf":
                        {
                           var IdCotizacion = GvCotizacion.Rows[fila.RowIndex].Cells[0].Text;

                            string img1 = string.Empty, img2 = string.Empty,img3 = string.Empty ;
                           using (IDataReader oReader = ohelper.RecuperarImagenReporteCotizacion(Cast.ToInt(IdCotizacion)))
                           {
                               if (oReader.Read())
                               {
                                  img1 = Cast.ToString(oReader["ImagenUno"]);
                                  img2 = Cast.ToString(oReader["ImagenDos"]);
                                  img3 = Cast.ToString(oReader["ImagenTres"]);
                                }
                           }

                            if (img1 == null || img2 == null || img3 == null)
                            {
                                Response.Redirect("CrearPDFSinImagenes.aspx?IdCotizacion=" + IdCotizacion, false);
                            }
                            else
                            {
                                Response.Redirect("CrearPDF.aspx?IdCotizacion=" + IdCotizacion, false);
                            }
                           break;
                        }
                    case "Eliminar":
                        {
                            Session["IdCotizacion"] = GvCotizacion.Rows[fila.RowIndex].Cells[0].Text;
                            ohelper.EliminarCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
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
                string mensaje = ex.Message;
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
                if (txtfiltro.Text.Length > 2 && DDFiltro.SelectedIndex > 0)
                {
                    GvCotizacion.DataSource = ohelper.RecuperarCotizacionesPorFiltro(Convert.ToInt32(DDFiltro.SelectedIndex), txtfiltro.Text);
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
            ds = ohelper.RecuperarCotizaciones();
            GvCotizacion.DataSource = ds;
            GvCotizacion.DataBind();
            dt = ds.Tables[0];
            Session["dtCotizacion"] = dt;
        }

    }
}