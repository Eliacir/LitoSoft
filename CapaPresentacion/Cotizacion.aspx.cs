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
using CapaPresentacion.Extensions;

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
            //Recuperamos Clientes
            ddClientes.DataSource = ohelper.RecuperarClientes(IdLitografia);
            ddClientes.DataTextField = "Nombre";
            ddClientes.DataValueField = "IdCliente";
            ddClientes.DataBind();
            ddClientes.Items.Insert(0, new ListItem("Seleccionar", "0"));

            //Recuperamos Papel
            ddSustrato.DataSource = ohelper.RecuperarPapel(IdLitografia);
            ddSustrato.DataTextField = "Nombre";
            ddSustrato.DataValueField = "IdPapel";
            ddSustrato.DataBind();
            ddSustrato.Items.Insert(0, new ListItem("Seleccionar", "0"));
            // ddSustrato.SelectedItem.Text;//Nombrepapel
            // ddSustrato.SelectedValue;//precio

            //Sacamos el valor del papel
            var idPapel = Convert.ToInt32(ddSustrato.SelectedValue);
            decimal valorpapel = ohelper.RecuperarPrecioPapel(idPapel);
            txtValorpapel.Text = valorpapel.FormatoMoneda();


            //Recuperamos Corte
            ddCorte.DataSource = ohelper.RecuperarCorte(IdLitografia);
            ddCorte.DataTextField = "Corte";
            ddCorte.DataValueField = "IdCorte";
            ddCorte.DataBind();
            ddCorte.Items.Insert(0, new ListItem("Seleccionar", "0"));


            CalcularImpresionesyPliego();
            //Calculamos el valor total papel
            CalcularvalorTotalPapel();

            //Valor del montaje segun el corte escogido
            txtMontaje.Text = ddCorte.SelectedValue.Trim();

            RecuperarValorPlanchaEImpresion(false);

            //Recuperar papel extra
            Int64 PapelExtra = Convert.ToInt64(ohelper.RecuperarParametro("PapelExtra", IdLitografia));
            txtpapelextra.Value = PapelExtra.ToString();

            Separardividendo();
        }

        //protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        ////insertamos el registro
        //        //ohelper.InsertarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]),txtDescripcion.Text.Trim(), txtCantidad.Text.Trim(),Convert.ToDecimal(txtValorUnitario.Text));

        //        //LimpiarControles();
        //        //GvDetalleCotizacion.DataSource = ohelper.RecuperarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
        //        //GvDetalleCotizacion.DataBind();

        //        //Mensaje Ok
        //        string mensaje = "Item agregado satisfactoriamente.!";
        //        ClientScript.RegisterStartupScript(this.GetType(), "Detalle Cotización", "<script>swal('', '" + mensaje + "', 'success')</script>");
        //    }
        //    catch (Exception ex)
        //    {
        //        string mensaje = ex.Message;
        //        //Mensaje Error
        //        ClientScript.RegisterStartupScript(this.GetType(), "Configuración", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
        //    }
        //}

        //protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        //ohelper.ActualizarDetalleCotizacion(Convert.ToInt32(Session["IdDetalleCotizacion"]), txtDescripcion.Text.Trim(), txtCantidad.Text.Trim(), Convert.ToDecimal(txtValorUnitario.Text));

        //        //LimpiarControles();
        //        //GvDetalleCotizacion.DataSource = ohelper.RecuperarDetalleCotizacion(Convert.ToInt32(Session["IdCotizacion"]));
        //        //GvDetalleCotizacion.DataBind();

        //        //btnAgregar.Visible = true;
        //        //btnActualizar.Visible = false;

        //        //Mensaje Ok
        //        string mensaje = "Item actualizado satisfactoriamente.!";
        //        ClientScript.RegisterStartupScript(this.GetType(), "Detalle Cotización", "<script>swal('', '" + mensaje + "', 'success')</script>");
        //    }
        //    catch (Exception ex)
        //    {
        //        string mensaje = ex.Message;
        //        //Mensaje Error
        //        ClientScript.RegisterStartupScript(this.GetType(), "Configuración", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
        //    }
        //}

        protected void ddSustrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var idPapel = Cast.ToInt(ddSustrato.SelectedValue);

                decimal valorpapel = ohelper.RecuperarPrecioPapel(idPapel);
                txtValorpapel.Text = valorpapel.FormatoMoneda();
                CalcularImpresionesyPliego();
                CalcularvalorTotalPapel();

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
                var idCorte = Cast.ToInt(ddCorte.SelectedValue);

                txtMontaje.Text = ohelper.RecuperarMontaje(idCorte);

                CalcularImpresionesyPliego();
                RecuperarValorPlanchaEImpresion(false);


                CalcularvalorTotalPapel();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CalcularvalorTotalPapel()
        {
            //Calculamos el valor total papel
            if (!ddSustrato.SelectedValue.Equals("0"))
            {
                var IdPapel = Cast.ToInt(ddSustrato.SelectedValue);
                var valorpapel = ohelper.RecuperarPrecioPapel(IdPapel);
                var catidadPliegos = Cast.ToInt(txtCantidadpliego.Text);
                var ValorTotalPapel = valorpapel * catidadPliegos;

                txtValorTotalPapel.Text = ValorTotalPapel.FormatoMoneda();              
            }
            else
            {
                txtValorTotalPapel.Text = "0";
            }
        }

        private void CalcularImpresionesyPliego()
        {
            try
            { 
                var cantidad = Cast.ToInt(txtCantidad.Text);
                var cavidad = Cast.ToInt(txtCavidad.Text);
                var papelextra = Cast.ToInt(txtpapelextra.Value);

                if (cavidad == 0) cavidad = 1;

                var impresionesTotales = (cantidad / cavidad) + papelextra;

                txtImpresionestotales.Text = impresionesTotales.ToString();

                //Calcular cantidad de pliegos
                if (!ddCorte.SelectedValue.Equals("0"))
                {
                    Separardividendo();
                    var dividendo = Cast.ToInt(txtDividendo.Value);

                    if (dividendo == 0) dividendo = 1;

                    var cantidadpliego = impresionesTotales / dividendo;
                    txtCantidadpliego.Text = cantidadpliego.ToString();
                }
                else
                {
                    txtCantidadpliego.Text = "0";
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private int CalcularMillares(decimal cantidad)
        {
            const int millar = 1000;

            var millares = (int)(cantidad / millar);

            if (cantidad % millar > 0)
                millares++;

            return millares;
        }

        private void RecuperarValorPlanchaEImpresion(bool escalcular)
        {
            try
            {
                int millares = 0;
                decimal precioPlancha = 0;
                decimal PrecioImpresion = 0;
                decimal GranTotalvalorImpresion = 0;

                var cantidad = Cast.ToInt(txtCantidad.Text);

                if (ddCorte.SelectedValue.Equals("0"))
                {
                    txtvalorplancha.Text = txtValorImpresion.Text = "0";
                }
                else
                {
                    if (txtMontaje.Text.Equals("1/2") || txtMontaje.Text.Equals("1/3"))
                    {
                        //PrecioPlanchaMayor = 22000; PrecioImpresionMayor = 25000
                        precioPlancha = Cast.ToDecimal(ohelper.RecuperarParametro("PrecioPlanchaMayor", IdLitografia));
                        PrecioImpresion = Cast.ToDecimal(ohelper.RecuperarParametro("PrecioImpresionMayor", IdLitografia));                       
                    }
                    else
                    {
                        //PrecioPlanchaMenor = 12000; PrecioImpresionMayor = 12000
                        precioPlancha = Cast.ToDecimal(ohelper.RecuperarParametro("PrecioPlanchaMenor", IdLitografia));
                        PrecioImpresion = Cast.ToDecimal(ohelper.RecuperarParametro("PrecioImpresionMenor", IdLitografia));  
                    }

                    txtvalorplancha.Text = precioPlancha.FormatoMoneda();
                    txtValorImpresion.Text = PrecioImpresion.FormatoMoneda();

                    //Calculamos millares
                    if (!string.IsNullOrEmpty(txtImpresionestotales.Text))
                    {
                        millares = CalcularMillares(cantidad);
                        GranTotalvalorImpresion = PrecioImpresion * millares;
                    }
                }
        
                //Calcular Frente y respaldo                
                var valorFrente = Cast.ToDecimal(txtFrente.Text);
                var valorRespaldo = Cast.ToDecimal(txtRespaldo.Text);
                var totalPlancha = (valorFrente + valorRespaldo) * precioPlancha;
                var valorTotalImpresiones = (valorFrente + valorRespaldo) * GranTotalvalorImpresion;

                txtValorTotalImpresiones.Text = valorTotalImpresiones.FormatoMoneda();
            
                //Se establecen valores de las funciones js
                SetCamposInhabilitados();

                var valorTotalPapel = txtValorTotalPapel.Text.QuitarFormatoMoneda();
                var Totalfactura = (totalPlancha + valorTotalPapel + valorTotalImpresiones);
                var costoDiseño = Cast.ToDecimal(txtCostoDiseno.Text);

                Totalfactura += costoDiseño;             

                if (escalcular)
                {
                    txtTotalfactura.Text = Totalfactura.FormatoMoneda();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void SetCamposInhabilitados()
        {     
            var cantidad = Cast.ToInt(txtCantidad.Text);    

            int cavidad = Cast.ToInt(txtCavidad.Text);
            int papelextra = Cast.ToInt(txtpapelextra.Value);

            if (cavidad == 0) cavidad = 1;

            txtImpresionestotales.Text = ((cantidad / cavidad) + papelextra).ToString();           
        
            int imprTotales = Cast.ToInt(txtImpresionestotales.Text);
            int dividendo = Cast.ToInt(txtDividendo.Value);

            if (dividendo == 0) dividendo = 1;

            txtCantidadpliego.Text = (imprTotales / dividendo).ToString();

            var cantidadPliego = Cast.ToInt(txtCantidadpliego.Text);

            var precioPapel = Cast.ToDecimal(txtValorpapel.Text.QuitarFormatoMoneda());

            txtValorTotalPapel.Text = (cantidadPliego * precioPapel).FormatoMoneda();

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

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarValorPlanchaEImpresion(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void bntLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtCantidad.Text = String.Empty;
                txtCostoDiseno.Text = String.Empty;
                txtCavidad.Text = String.Empty;
                CargarCombos();
                txtValorpapel.Text = String.Empty;
                txtMontaje.Text = String.Empty;
                txtCantidadpliego.Text = String.Empty;
                txtvalorplancha.Text = String.Empty;
                txtValorImpresion.Text = String.Empty;
                txtValorTotalPapel.Text = String.Empty;
                txtFrente.Text = String.Empty;
                txtRespaldo.Text = String.Empty;
                ddMismaplancha.Text = "Seleccionar";
                txtFrente.Enabled = true;
                txtRespaldo.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAcabados_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAcabados.Text.Contains("Mostrar"))
                {
                    MultiView.ActiveViewIndex = 0;
                    btnAcabados.Text = "Ocultar Acabados";

                }
                else
                {
                    MultiView.ActiveViewIndex = 1;
                    btnAcabados.Text = "Mostrar Acabados";
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void ddFrente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddFrente.SelectedIndex == 1)
            {
                txtFrente.Enabled = true;
            }
            else
            {
                txtFrente.Enabled = false;
            }        
        }

        protected void ddRespaldo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddRespaldo.SelectedIndex == 1)
            {
                txtRespaldo.Enabled = true;
            }
            else
            {
                txtRespaldo.Enabled = false;
            }
        }
    }
}