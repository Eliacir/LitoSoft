using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class Insumos : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        public Int16 Idproyecto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["IsOtraPagina"] = true;
                Session["PanelPrincipal"] = "Gestionar Insumos";
                if (!Page.IsPostBack)
                {
                    Boolean IsEditar = (bool)Session["IsEditar"];
                    if (IsEditar)
                    {
                        ValoresGVInsumos();
                        btnRegistrar.Text = "Actualizar";
                        Session["IsEditar"] = false;
                    }
                    else
                    {
                        //Obtenemos idproyecto
                        Idproyecto = Convert.ToInt16(Session["IdproyectoInsumos"].ToString());
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void ValoresGVInsumos()
        {
            try
            {
                short IdDetalleProyecto = Cast.ToShort(Session["IdDetalleProyectoGI"]);

                using (var reader = ohelper.RecuperarDetalleProyectoPorIdDetalleProyecto(IdDetalleProyecto))
                {
                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            txtCantidad.Text = Cast.ToString(reader["Cantidad"]);
                            txtDescripcion.Text = Cast.ToString(reader["Descripcion"]);
                            txtValor.Text = Cast.ToString(reader["ValorUnitario"]);
                            txtValorTotal.Text = Cast.ToString(reader["ValorTotal"]);
                            txtObservacion.Text = Cast.ToString(reader["Observacion"]);
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegistrar.Text == "Actualizar")
                {
                    Insumo insumo = GetEditarEntity();
                    bool res = ohelper.ActualizarDetalleProyecto(insumo);
                    if (res)
                    {
                        Response.Redirect("GestionarInsumos.aspx", false);
                    }
                }
                else
                {
                    //Obtenemos idproyecto
                    Idproyecto = Convert.ToInt16(Session["IdproyectoInsumos"].ToString());
                    Insumo insumo = GetEntity();
                    bool res = ohelper.InsertarDetalleProyecto(insumo);
                    if (res)
                    {
                        Response.Redirect("GestionarInsumos.aspx", false);
                    }

                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Insumos", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
           
        }

        private Insumo GetEntity()
        {
            Insumo oInsumo = new Insumo();
            oInsumo.IdDetalleproyecto= 0;
            oInsumo.IdProyecto = Idproyecto; 
            oInsumo.Cantidad = Convert.ToInt16(txtCantidad.Text);
            oInsumo.Descripcion = txtDescripcion.Text;
            oInsumo.ValorUni = Convert.ToDecimal(txtValor.Text);
            oInsumo.ValorTotal = Convert.ToDecimal(txtValorTotal.Text);
            oInsumo.Observacion = txtObservacion.Text;

            return oInsumo;
        }

        private Insumo GetEditarEntity()
        {
            Insumo oInsumo = new Insumo();
            oInsumo.IdDetalleproyecto = Convert.ToInt32(Session["IdDetalleProyectoGI"]);
            oInsumo.IdProyecto = Convert.ToInt16(Session["IdProyectoGI"]);
            oInsumo.Cantidad = Convert.ToInt16(txtCantidad.Text);
            oInsumo.Descripcion = txtDescripcion.Text;
            oInsumo.ValorUni = Convert.ToDecimal(txtValor.Text);
            oInsumo.ValorTotal = Convert.ToDecimal(txtValorTotal.Text);
            oInsumo.Observacion = txtObservacion.Text;

            return oInsumo;
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarInsumos.aspx",false);
        }
    }
}