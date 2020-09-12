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
    public partial class GestionarClientes : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Clientes";
            if (!Page.IsPostBack)
            {
                Session["IsOtraPagina"] = false;
                CargarClientes();
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Session["IsEditar"] = false;
            Response.Redirect("Clientes.aspx", false);
            GvCliente.DataBind();
        }

        protected void GvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
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

                            Session["IdClienteGC"] = GvCliente.Rows[fila.RowIndex].Cells[0].Text;
                            Session["NombreGC"] = GvCliente.Rows[fila.RowIndex].Cells[1].Text.Replace("&nbsp;", "");
                            Session["RucGC"] = GvCliente.Rows[fila.RowIndex].Cells[2].Text.Replace("&nbsp;", "");
                            Session["DireccionGC"] = GvCliente.Rows[fila.RowIndex].Cells[3].Text.Replace("&nbsp;", "");
                            Session["TelefonoGC"] = GvCliente.Rows[fila.RowIndex].Cells[4].Text.Replace("&nbsp;", "");
                            Session["EmailGC"] = GvCliente.Rows[fila.RowIndex].Cells[5].Text.Replace("&nbsp;", ""); ;
                            Response.Redirect("Clientes.aspx", false);
                            break;
                        }
                    case "Eliminar":
                        {
                            Session["IdClienteGC"] = GvCliente.Rows[fila.RowIndex].Cells[0].Text;
                            ohelper.EliminarCliente(Convert.ToInt32(Session["IdClienteGC"]));
                            string mensaje = "Cliente eliminado satisfactoriamente.";
                            //Mensaje ok
                            ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Clientes", "<script>swal('', '" + mensaje + "', 'success')</script>");
                            CargarClientes();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Clientes", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }
        }

        protected void btnBuscarRepresentante_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfiltro.Text.Length > 2 && DDFiltro.SelectedIndex > 0)
                {
                    GvCliente.DataSource = ohelper.RecuperarClientesPorFiltro(Convert.ToInt32(DDFiltro.SelectedIndex),txtfiltro.Text);
                    GvCliente.DataBind();
                }
                else
                {
                    CargarClientes();
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        protected void GvCliente_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtbl = new DataTable();
            dtbl = (DataTable)Session["dtCliente"];
            if (ViewState["SortOrder"] == null)
            {
                dtbl.DefaultView.Sort = e.SortExpression + " DESC";
                GvCliente.DataSource = dtbl;
                GvCliente.DataBind();
                ViewState["SortOrder"] = "DESC";
            }
            else
            {
                dtbl.DefaultView.Sort = e.SortExpression + "" + " ASC";
                GvCliente.DataSource = dtbl;
                GvCliente.DataBind();
                ViewState["SortOrder"] = null;
            }
        }

        protected void GvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCliente.PageIndex = e.NewPageIndex;
        }


        public void CargarClientes()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = ohelper.RecuperarClientes();
            GvCliente.DataSource = ds;
            GvCliente.DataBind();
            dt = ds.Tables[0];
            Session["dtCliente"] = dt;
        }

        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}