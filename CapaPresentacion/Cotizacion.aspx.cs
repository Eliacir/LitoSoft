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
            txtValorpapel.Text = valorpapel.ToString("C0", CultureInfo.CurrentCulture);


            //Recuperamos Corte
            ddCorte.DataSource = ohelper.RecuperarCorte();
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
                var idPapel = Convert.ToInt32(ddSustrato.SelectedValue);

                decimal valorpapel = ohelper.RecuperarPrecioPapel(idPapel);
                txtValorpapel.Text = valorpapel.ToString("C0", CultureInfo.CurrentCulture);
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
                var idCorte = Convert.ToInt32(ddCorte.SelectedValue);

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
                int IdPapel = Convert.ToInt32(ddSustrato.SelectedValue);

                decimal valorpapel = ohelper.RecuperarPrecioPapel(IdPapel);
                if (!string.IsNullOrEmpty(txtCantidadpliego.Text))
                {
                    decimal ValorTotalPapel = Convert.ToDecimal(valorpapel * Convert.ToInt32(txtCantidadpliego.Text));
                    txtValorTotalPapel.Text = ValorTotalPapel.ToString("C0", CultureInfo.CurrentCulture);
                }
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
                //Calcular impresiones impresiones Totales
                if (!string.IsNullOrEmpty(txtCantidad.Text) && (!string.IsNullOrEmpty(txtCavidad.Text)) && (!txtCantidad.Text.Equals("0")) && (!txtCavidad.Text.Equals("0")))
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
                    else
                    {
                        txtCantidadpliego.Text = "0";
                    }

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

            if (cantidad - (millares * millar) > 0)
                millares++;

            return millares;
        }

        private decimal QuitarFormatoMoneda(string moneda)
        {
            return decimal.Parse(moneda, NumberStyles.Currency, CultureInfo.GetCultureInfo("es-CO"));
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

                if (!ddCorte.SelectedValue.Equals("0"))
                {
                    if (txtMontaje.Text.Equals("1/2") || txtMontaje.Text.Equals("1/3"))
                    {
                        //PrecioPlanchaMayor = 22000; PrecioImpresionMayor = 25000
                        precioPlancha = Cast.ToDecimal(ohelper.RecuperarParametro("PrecioPlanchaMayor", IdLitografia));
                        PrecioImpresion = Cast.ToDecimal(ohelper.RecuperarParametro("PrecioImpresionMayor", IdLitografia));
                        txtvalorplancha.Text = precioPlancha.ToString("C0", CultureInfo.CurrentCulture);
                        txtValorImpresion.Text = PrecioImpresion.ToString("C0", CultureInfo.CurrentCulture);

                        //Calculamos millares
                        if (!string.IsNullOrEmpty(txtImpresionestotales.Text))
                        {
                            millares = CalcularMillares(cantidad);

                            GranTotalvalorImpresion = PrecioImpresion * millares;
                        }
                    }
                    else
                    {
                        //PrecioPlanchaMenor = 12000; PrecioImpresionMayor = 12000
                        precioPlancha =Cast.ToDecimal(ohelper.RecuperarParametro("PrecioPlanchaMenor", IdLitografia));
                        PrecioImpresion =Cast.ToDecimal(ohelper.RecuperarParametro("PrecioImpresionMenor", IdLitografia));
                        txtvalorplancha.Text = precioPlancha.ToString("C0", CultureInfo.CurrentCulture);
                        txtValorImpresion.Text = PrecioImpresion.ToString("C0", CultureInfo.CurrentCulture);

                        //Calculamos millares
                        if (!string.IsNullOrEmpty(txtImpresionestotales.Text))
                        {
                            millares = CalcularMillares(cantidad);

                            GranTotalvalorImpresion = PrecioImpresion * millares;
                        }

                    }
                }
                else
                {
                    txtvalorplancha.Text = "0";
                    txtValorImpresion.Text = "0";
                }

                //Calcular Frente y respaldo
                decimal valorRespaldo;
                decimal valorImpresionFrente;
                decimal valorImpresionRespaldo;
                decimal totalPlancha = 0;
                decimal valorTotalImpresiones = 0;
                decimal valorFrente;


                if (!txtFrente.Text.Equals("0") && txtRespaldo.Text.Equals("0") && ddMismaplancha.SelectedValue.Equals("No"))
                {
                    totalPlancha = Cast.ToInt(txtFrente.Text) * precioPlancha;
                    valorTotalImpresiones = Cast.ToInt(txtFrente.Text) * GranTotalvalorImpresion;
                }

                if (!txtFrente.Text.Equals("0") && !txtRespaldo.Text.Equals("0") && ddMismaplancha.SelectedValue.Equals("No"))
                {
                    valorFrente = Cast.ToInt(txtFrente.Text) * precioPlancha;
                    valorRespaldo = Cast.ToInt(txtRespaldo.Text) * precioPlancha;
                    totalPlancha = valorFrente + valorRespaldo;
                    valorImpresionFrente = Cast.ToInt(txtFrente.Text) * GranTotalvalorImpresion;
                    valorImpresionRespaldo = Cast.ToInt(txtRespaldo.Text) * GranTotalvalorImpresion;
                    valorTotalImpresiones = valorImpresionFrente + valorImpresionRespaldo;
                }

                if (!txtFrente.Text.Equals("0") && !txtRespaldo.Text.Equals("0") && ddMismaplancha.SelectedValue.Equals("Si"))
                {
                    var PapelExtra = Cast.ToInt(ohelper.RecuperarParametro("PapelExtra", IdLitografia));

                    totalPlancha = Cast.ToInt(txtFrente.Text) * precioPlancha;

                    valorTotalImpresiones = Cast.ToInt(txtFrente.Text) * GranTotalvalorImpresion;
                }

                //Se establecen valores de las funciones js
                SetCamposInhabilitados();

                var valorTotalPapel = QuitarFormatoMoneda(txtValorTotalPapel.Text);

                var Totalfactura = (totalPlancha + valorTotalPapel + valorTotalImpresiones);

                var costoDiseño = Cast.ToDecimal(txtCostoDiseno.Text);

                Totalfactura += costoDiseño;             

                if (escalcular)
                {
                    txtTotalfactura.Text = Totalfactura.ToString("C0", CultureInfo.CurrentCulture);
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
            var valorImpresion = QuitarFormatoMoneda(txtValorImpresion.Text);
            var millares = CalcularMillares(cantidad);
            var frente = Cast.ToInt(txtFrente.Text);
            var totalImpresiones = frente * (valorImpresion * millares);
            txtValorTotalImpresiones.Text = totalImpresiones.ToString("C0", CultureInfo.CurrentCulture);            

            int cavidad = Cast.ToInt(txtCavidad.Text);
            int papelextra = Cast.ToInt(txtpapelextra.Value);

            if (cavidad == 0) cavidad = 1;

            txtImpresionestotales.Text = ((cantidad / cavidad) + papelextra).ToString();           
        
            int imprTotales = Cast.ToInt(txtImpresionestotales.Text);
            int dividendo = Cast.ToInt(txtDividendo.Value);

            if (dividendo == 0) dividendo = 1;

            txtCantidadpliego.Text = (imprTotales / dividendo).ToString();            
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
    }
}