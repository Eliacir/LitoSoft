using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Helpers;

namespace CapaPresentacion
{
    public partial class GestionarClientes : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        Int32 IdLitografia;

        public object lblIPBehindProxy { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {        
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Clientes";
            IdLitografia = Convert.ToInt16(Session["IdLitografia"]);
            if (!Page.IsPostBack)
            {
               
                Session["IsOtraPagina"] = false;
                CargarClientes();
                //  MostrarOcultarCamposRegistro(false);
            }
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {


            try
            {
                if (Convert.ToBoolean(ViewState["esEditar"]))
                {
                    Cliente oCliente = GetEditarCliente();
                    bool res = ohelper.ActualizarCliente(oCliente, IdLitografia);
                    if (res)
                    {
                        string mensaje = "Cliente actualizado con exito";
                        ClientScript.RegisterStartupScript(this.GetType(), "Clientes", "<script>swal('', '" + mensaje + "', 'success')</script>");
                        btnRegistrar.Text = "Registrar";
                        ViewState["esEditar"] = false;
                    }

                }
                else
                {

                    Cliente oCliente = GetCliente();
                    bool res = ohelper.InsertarCliente(oCliente,IdLitografia);
                    if (res)
                    {
                        string mensaje = "Cliente agregado con exito";
                        ClientScript.RegisterStartupScript(this.GetType(), "Clientes", "<script>swal('', '" + mensaje + "', 'success')</script>");
                    }
                }
                LimpiarControles();
                CargarClientes();

                //  MostrarOcultarCamposRegistro(false);
            }
            catch (Exception ex)
            {
                CargarClientes();
                string mensaje = ex.Message.Replace("'","");
                ClientScript.RegisterStartupScript(this.GetType(), "Clientes", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }

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
                            ViewState["esEditar"] = true;
                            btnRegistrar.Text = "Actualizar";
                            Session["IdClienteGC"] = Convert.ToInt32(GvCliente.Rows[fila.RowIndex].Cells[0].Text);
                            ValoresGVClientes();
                            btnCancelar.Visible = true;
                            break;
                        }
                    case "Eliminar":
                        {

                            Session["IdClienteGC"] = Convert.ToInt32(GvCliente.Rows[fila.RowIndex].Cells[0].Text);
                            ohelper.EliminarCliente(Convert.ToInt32(Session["IdClienteGC"]),IdLitografia);
                            string mensaje = "Cliente eliminado satisfactoriamente.";
                            //Mensaje ok
                            CargarClientes();
                            ClientScript.RegisterStartupScript(this.GetType(), "Clientes", "<script>swal('', '" + mensaje + "', 'success')</script>");
                            break;
                        }


                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Replace("'","");
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Clientes", "<script>swal('', '" + mensaje + "', 'error')</script>");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfiltro.Text.Length > 2 && DDFiltro.SelectedIndex > 0)
                {
                    GvCliente.DataSource = ohelper.RecuperarClientesPorFiltro(Convert.ToInt32(DDFiltro.SelectedIndex), txtfiltro.Text);
                    GvCliente.DataBind();
                }
                else
                {
                    CargarClientes();
                }
            }
            catch (Exception)
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
            ds = ohelper.RecuperarClientes(IdLitografia);
            GvCliente.DataSource = ds;
            GvCliente.DataBind();
            dt = ds.Tables[0];
            Session["dtCliente"] = dt;

        }

        private Cliente GetCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.IdCliente = 0;
            oCliente.Nombre = txtnombre.Text;
            oCliente.Documento = txtdocumento.Text;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.Telefono = txttelefono.Text;

            return oCliente;
        }

        private Cliente GetEditarCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.IdCliente = Convert.ToInt32(Session["IdClienteGC"]);
            oCliente.Nombre = txtnombre.Text;
            oCliente.Documento = txtdocumento.Text;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.Telefono = txttelefono.Text;

            return oCliente;
        }

        private void ValoresGVClientes()
        {
            try
            {
                short IdCliente = Cast.ToShort(Session["IdClienteGC"]);

                using (var reader = ohelper.RecuperarClientePorIdcliente(IdCliente,IdLitografia))
                {
                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            txtnombre.Text = Cast.ToString(reader["Nombre"]);
                            txtdocumento.Text = Cast.ToString(reader["Documento"]);
                            txtDireccion.Text = Cast.ToString(reader["Direccion"]);
                            txttelefono.Text = Cast.ToString(reader["Telefono"]);
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LimpiarControles()
        {
            txtnombre.Text = String.Empty;
            txtdocumento.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txttelefono.Text = String.Empty;
            btnCancelar.Visible = false;
        }


        //private void MostrarOcultarCamposRegistro(bool mostrar)
        //{
        //    txtnombre.Visible = mostrar;
        //    txtdocumento.Visible = mostrar;
        //    txtDireccion.Visible = mostrar;
        //    txttelefono.Visible = mostrar;

        //    lblNombre.Visible = mostrar;
        //    lbldireccion.Visible = mostrar;
        //    lbltelefono.Visible = mostrar;
        //    lbldocumento.Visible = mostrar;


        //    btnRegistrar.Visible = mostrar;
        //    btnCancelar.Visible = mostrar;
        //}

    }
}