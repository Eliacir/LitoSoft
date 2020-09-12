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
using System.Globalization;

namespace CapaPresentacion
{
    public partial class Cotizacion : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        Int32 IdLitografia;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["IsOtraPagina"] = true;
                Session["PanelPrincipal"] = "Gestionar Cotizaciones";
                IdLitografia = Convert.ToInt16(Session["IdLitografia"]);
                if (!Page.IsPostBack)
                {
                    CargarCombos();

                    //Boolean IsEditar = (bool)Session["IsEditar"];
                    //if (IsEditar)
                    //{
                    //   // btnRegistrar.Text = "Actualizar";
                    //    Session["IsEditar"] = false;
                    //}

                }


            }
            catch (Exception)
            {
                throw;
            }

        }



        public void CargarCombos()
        {

            //Recuperamos Papel
            ddSustrato.DataSource = ohelper.RecuperarPapel(IdLitografia);
            ddSustrato.DataTextField = "Nombre";
            ddSustrato.DataValueField = "Precio";
            ddSustrato.DataBind();
            ddSustrato.Items.Insert(0, new ListItem("Seleccionar", "0"));
            // ddSustrato.SelectedItem.Text;//Nombrepapel
            // ddSustrato.SelectedValue;//precio

            //Sacamos el valor del papel
            decimal valorpapel = Convert.ToDecimal(ddSustrato.SelectedValue);
            txtValorpapel.Text = valorpapel.ToString("C0", CultureInfo.CurrentCulture);

            //Calculamos el valor total papel
            if (!string.IsNullOrEmpty(txtCantidadpliego.Text))
            {
                decimal ValorTotalPapel = Convert.ToDecimal(valorpapel * Convert.ToInt32(txtCantidadpliego.Text));
                txtValorTotalPapel.Text = ValorTotalPapel.ToString("C0", CultureInfo.CurrentCulture);
            }

            //Recuperamos Corte
            ddCorte.DataSource = ohelper.RecuperarCorte();
            ddCorte.DataTextField = "Corte";
            ddCorte.DataValueField = "Montaje";
            ddCorte.DataBind();
            ddCorte.Items.Insert(0, new ListItem("Seleccionar", "0"));

            //Valor del montaje segun el corte escogido
            txtMontaje.Text = ddCorte.SelectedValue.Trim();

            RecuperarValorPlanchaEImpresion();

            //Recuperar papel extra
            Int64 PapelExtra = Convert.ToInt64(ohelper.RecuperarParametro("PapelExtra", IdLitografia));
            txtpapelextra.Value = PapelExtra.ToString();

            Separardividendo();
        }



        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ////insertamos el registro
                //ohelper.InsertarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]),txtDescripcion.Text.Trim(), txtCantidad.Text.Trim(),Convert.ToDecimal(txtValorUnitario.Text));

                //LimpiarControles();
                //GvDetalleCotizacion.DataSource = ohelper.RecuperarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
                //GvDetalleCotizacion.DataBind();

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
                //ohelper.ActualizarDetalleCotizacion(Convert.ToInt32(Session["IdDetalleCotizacion"]), txtDescripcion.Text.Trim(), txtCantidad.Text.Trim(), Convert.ToDecimal(txtValorUnitario.Text));

                //LimpiarControles();
                //GvDetalleCotizacion.DataSource = ohelper.RecuperarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
                //GvDetalleCotizacion.DataBind();

                //btnAgregar.Visible = true;
                //btnActualizar.Visible = false;

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


        protected void ddSustrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal valorpapel = Convert.ToDecimal(ddSustrato.SelectedValue);
                txtValorpapel.Text = valorpapel.ToString("C0", CultureInfo.CurrentCulture);
                CalcularImpresionesyPliego();


                //Calculamos el valor total papel
                if (!string.IsNullOrEmpty(txtCantidadpliego.Text))
                {
                    decimal ValorTotalPapel = Convert.ToDecimal(valorpapel * Convert.ToInt32(txtCantidadpliego.Text));
                    txtValorTotalPapel.Text = ValorTotalPapel.ToString("C0", CultureInfo.CurrentCulture);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddCorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Valor del montaje segun el corte escogido
                txtMontaje.Text = ddCorte.SelectedValue.Trim();

                RecuperarValorPlanchaEImpresion();
                CalcularImpresionesyPliego();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CalcularImpresionesyPliego()
        {
            try
            {
                //Calcular impresiones impresiones Totales
                if (!string.IsNullOrEmpty(txtCantidad.Text) && (!string.IsNullOrEmpty(txtCavidad.Text)))
                {
                    Int64 cantidad = Convert.ToInt64(txtCantidad.Text);
                    Int64 cavidad = Convert.ToInt64(txtCavidad.Text);
                    int papelextra = Convert.ToInt32(txtpapelextra.Value);
                    Int64 impresionesTotales = (cantidad / cavidad) + papelextra;

                    txtImpresionestotales.Text = impresionesTotales.ToString();

                    //Calcular cantidad de pliegos
                    if (!ddCorte.SelectedValue.Equals("0"))
                    {
                        Separardividendo();
                        int dividendo = Convert.ToInt32(txtDividendo.Value);
                        Int64 cantidadpliego = impresionesTotales / dividendo;
                        txtCantidadpliego.Text = cantidadpliego.ToString();
                    }
                
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void RecuperarValorPlanchaEImpresion()
        {
            decimal precioPlancha;
            decimal PrecioImpresion;
            if (!ddCorte.SelectedValue.Equals("0"))
            {
                if (txtMontaje.Text.Equals("1/2") || txtMontaje.Text.Equals("1/3"))
                {
                    //PrecioPlanchaMayor = 22000; PrecioImpresionMayor = 25000
                    precioPlancha = Convert.ToDecimal(ohelper.RecuperarParametro("PrecioPlanchaMayor", IdLitografia));
                    PrecioImpresion = Convert.ToDecimal(ohelper.RecuperarParametro("PrecioImpresionMayor", IdLitografia));
                    txtvalorplanchaeimpresion.Text = precioPlancha.ToString("C0", CultureInfo.CurrentCulture) + " - " + PrecioImpresion.ToString("C0", CultureInfo.CurrentCulture);
                }
                else
                {
                    //PrecioPlanchaMenor = 12000; PrecioImpresionMayor = 12000
                    precioPlancha = Convert.ToDecimal(ohelper.RecuperarParametro("PrecioPlanchaMenor", IdLitografia));
                    PrecioImpresion = Convert.ToDecimal(ohelper.RecuperarParametro("PrecioImpresionMenor", IdLitografia));
                    txtvalorplanchaeimpresion.Text = precioPlancha.ToString("C0", CultureInfo.CurrentCulture) + " - " + PrecioImpresion.ToString("C0", CultureInfo.CurrentCulture);
                }
            }
            else
            {
                txtvalorplanchaeimpresion.Text = "0" + " - " + "0";
            }

        }

        private void LimpiarControles()
        {

        }

        private void Separardividendo()
        {

            //Calcular el dividendo
            if (!ddCorte.SelectedValue.Equals("0"))
            {
                string montaje = txtMontaje.Text;
                string[] separador = montaje.Split('/');
                txtDividendo.Value = separador[1];
            }          
        }
    }
}