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

namespace CapaPresentacion
{
    public partial class DetalleCotizacion : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["IsOtraPagina"] = true;
                Session["PanelPrincipal"] = "Gestionar Cotizaciones";
                if (!Page.IsPostBack)
                {
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds = ohelper.RecuperarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
                    GvDetalleCotizacion.DataSource = ds;
                    GvDetalleCotizacion.DataBind();
                    dt = ds.Tables[0];
                    Session["dtDetalleCotizacion"] = dt;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void LimpiarControles()
        {
            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtValorUnitario.Text = string.Empty;
        }

        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //insertamos el registro
                ohelper.InsertarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]),txtDescripcion.Text.Trim(), txtCantidad.Text.Trim(),Convert.ToDecimal(txtValorUnitario.Text));

                LimpiarControles();
                GvDetalleCotizacion.DataSource = ohelper.RecuperarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
                GvDetalleCotizacion.DataBind();

                //Mensaje Ok
                string mensaje = "Item agregado satisfactoriamente.!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Detalle Cotización", "<script>swal('', '" + mensaje + "', 'success')</script>");
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Configuración", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
        }

        protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ohelper.ActualizarDetalleCotizacion(Convert.ToInt32(Session["IdDetalleCotizacion"]), txtDescripcion.Text.Trim(), txtCantidad.Text.Trim(), Convert.ToDecimal(txtValorUnitario.Text));

                LimpiarControles();
                GvDetalleCotizacion.DataSource = ohelper.RecuperarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
                GvDetalleCotizacion.DataBind();

                btnAgregar.Visible = true;
                btnActualizar.Visible = false;

                //Mensaje Ok
                string mensaje = "Item actualizado satisfactoriamente.!";
                ClientScript.RegisterStartupScript(this.GetType(), "Detalle Cotización", "<script>swal('', '" + mensaje + "', 'success')</script>");
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Configuración", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
        }

        protected void GvDetalleCotizacion_RowCommand(object sender, GridViewCommandEventArgs e)
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
                            Session["IdDetalleCotizacion"] = GvDetalleCotizacion.Rows[fila.RowIndex].Cells[1].Text;
                            try
                            {
                                using (IDataReader reader = ohelper.RecuperarDetalleCotizacionPorIdDetalle(Convert.ToInt32(Session["IdDetalleCotizacion"])))
                                {
                                    if (reader.Read())
                                    {
                                        txtDescripcion.Text = reader["Descripcion"].ToString();
                                        txtCantidad.Text = reader["Cantidad"].ToString();
                                        txtValorUnitario.Text = reader["ValorUnitario"].ToString();

                                        btnAgregar.Visible = false;
                                        btnActualizar.Visible = true;
                                    }
                                }

                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        }
                    case "Eliminar":
                        {
                            Session["IdDetalleCotizacion"] = GvDetalleCotizacion.Rows[fila.RowIndex].Cells[1].Text;
                            ohelper.EliminarDetalleCotizacion(Convert.ToInt32(Session["IdDetalleCotizacion"]));
                            break;
                        }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GvDetalleCotizacion_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //Ocultamos la columna 1 "Codigo proyecto"
            //e.Row.Cells[1].Visible = false;
        }

        protected void GvDetalleCotizacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDetalleCotizacion.PageIndex = e.NewPageIndex;
        }

        protected void GvDetalleCotizacion_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataTable dtbl = new DataTable();
                dtbl = (DataTable)Session["dtDetalleCotizacion"];
                if (ViewState["SortOrder"] == null)
                {
                    dtbl.DefaultView.Sort = e.SortExpression + " DESC";
                    GvDetalleCotizacion.DataSource = dtbl;
                    GvDetalleCotizacion.DataBind();
                    ViewState["SortOrder"] = "DESC";
                }
                else
                {
                    dtbl.DefaultView.Sort = e.SortExpression + "" + " ASC";
                    GvDetalleCotizacion.DataSource = dtbl;
                    GvDetalleCotizacion.DataBind();
                    ViewState["SortOrder"] = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarCotizaciones.aspx", false);
        }

        protected void btnBuscarRepresentante_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfiltro.Text.Length > 2 && DDFiltro.SelectedIndex > 0)
                {
                    GvDetalleCotizacion.DataSource = ohelper.RecuperarDetalleCotizacionPorFiltro(Convert.ToInt32(DDFiltro.SelectedIndex), txtfiltro.Text);
                    GvDetalleCotizacion.DataBind();
                }
                else
                {
                    GvDetalleCotizacion.DataSource = ohelper.RecuperarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
                    GvDetalleCotizacion.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}