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
    public partial class Cotizaciones : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        public string IdEmpeladoInsertado = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Gestionar Cotizaciones";
            if (!Page.IsPostBack)
            {
                Boolean IsEditar = (bool)Session["IsEditar"];
                if (IsEditar)
                {
                    int IdCotizacion = Convert.ToInt32(Session["IdCotizacion"]);
                    RecuperarCotizacione(IdCotizacion);
                    btnRegistrar.Text = "Actualizar";
                    Session["IsEditar"] = false;
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegistrar.Text == "Actualizar")
                {
                    CotizacionEnti oCotizacion = GetEditarCotizacion(Convert.ToInt32(Session["IdProyecto"]));
                    bool res = ohelper.ActualizarCotizacion(oCotizacion);
                    if (res)
                    {
                        Response.Redirect("GestionarCotizaciones.aspx", false);
                    }
                }
                else
                {
                    CotizacionEnti oCotizacion = GetCotizacion();
                    bool res = ohelper.InsertarCotizacion(oCotizacion);
                    if (res)
                    {
                        Response.Redirect("GestionarCotizaciones.aspx", false);
                    }
                }
            }

            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Cotizaciones", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
           
        }

        private void RecuperarCotizacione(int IdCotizacion)
        {
            try
            {
                using (IDataReader oReader = ohelper.recuperarCotizacionPorIdCotizacion(IdCotizacion))
                {
                    if (oReader.Read())
                    {
                        txtCodigoCotizacion.Text = Convert.ToString(oReader["CodigoCotizacion"].ToString());
                        Session["IdProyecto"] = Convert.ToInt32(oReader["IdProyecto"]);
                        dpProyecto.SelectedValue = Convert.ToString(Session["IdProyecto"]);
                        txtValidezOferta.Text = Convert.ToString(oReader["ValidezOferta"]);
                        txtTiempoEntrega.Text = Convert.ToString(oReader["TiempoEntrega"]);
                        txtLugarEntrega.Text = Convert.ToString(oReader["LugarEntrega"]);
                        txtGarantia.Text = Convert.ToString(oReader["Garantia"]);
                        txtNota.Text = Convert.ToString(oReader["Nota"]);
                        txtAlcance.Text = Convert.ToString(oReader["AlcancePropuesta"]);
                        GetEditarCotizacion(Convert.ToInt32(Session["IdProyecto"]));
                    }            
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private CotizacionEnti GetCotizacion()
        {
            CotizacionEnti cotizacion = new CotizacionEnti();
            cotizacion.IdCotizacion = 0;
            cotizacion.CodigoCotizacion = txtCodigoCotizacion.Text;
            cotizacion.IdProyecto = Convert.ToInt32(dpProyecto.SelectedValue);
            cotizacion.ValidezOferta = txtValidezOferta.Text;
            cotizacion.TiempoEntrega = txtTiempoEntrega.Text;
            cotizacion.LugarEntrega = txtLugarEntrega.Text;
            cotizacion.Garantia = txtGarantia.Text;
            cotizacion.Nota = txtNota.Text;
            cotizacion.ValidezOferta = txtAlcance.Text;

            return cotizacion;
        }

        private CotizacionEnti GetEditarCotizacion(int idProyecto)
        {

            CotizacionEnti cotizacion = new CotizacionEnti();
            cotizacion.IdCotizacion = Convert.ToInt32(Session["IdCotizacion"]);
            cotizacion.CodigoCotizacion = txtCodigoCotizacion.Text;
            cotizacion.IdProyecto = idProyecto;
            cotizacion.ValidezOferta = txtValidezOferta.Text;
            cotizacion.TiempoEntrega = txtTiempoEntrega.Text;
            cotizacion.LugarEntrega = txtLugarEntrega.Text;
            cotizacion.Garantia = txtGarantia.Text;
            cotizacion.Nota = txtNota.Text;
            cotizacion.AlcancePropuesta = txtAlcance.Text;

            return cotizacion;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarCotizaciones.aspx",false);
        }
    }
}