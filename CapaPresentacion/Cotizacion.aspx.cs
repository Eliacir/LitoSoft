﻿using System;
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
            ddSustrato.DataValueField = "Precio";
            ddSustrato.DataBind();
            ddSustrato.Items.Insert(0, new ListItem("Seleccionar", "0"));
            // ddSustrato.SelectedItem.Text;//Nombrepapel
            // ddSustrato.SelectedValue;//precio

            //Sacamos el valor del papel
            decimal valorpapel = Convert.ToDecimal(ddSustrato.SelectedValue);
            txtValorpapel.Text = valorpapel.ToString("C0", CultureInfo.CurrentCulture);


            //Recuperamos Corte
            ddCorte.DataSource = ohelper.RecuperarCorte();
            ddCorte.DataTextField = "Corte";
            ddCorte.DataValueField = "Montaje";
            ddCorte.DataBind();
            ddCorte.Items.Insert(0, new ListItem("Seleccionar", "0"));

          
            CalcularImpresionesyPliego();
            //Calculamos el valor total papel
            CalcularvalorTotalPapel();

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
                txtMontaje.Text = ddCorte.SelectedValue.Trim();

                CalcularImpresionesyPliego();
                RecuperarValorPlanchaEImpresion();


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
                decimal valorpapel = Convert.ToDecimal(ddSustrato.SelectedValue);
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
                if (!string.IsNullOrEmpty(txtCantidad.Text) && (!string.IsNullOrEmpty(txtCavidad.Text))  && (!txtCantidad.Text.Equals("0")) && (!txtCavidad.Text.Equals("0")))
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

        private void RecuperarValorPlanchaEImpresion()
        {
            try
            {
                decimal precioPlancha = 0;
                decimal PrecioImpresion = 0;
                Int32 imptotales = 0;
                Int32 Rangomillar;
                Int32 contarmillar = 0;
                decimal GranTotalvalorImpresion = 0;

                Rangomillar = Convert.ToInt32(ohelper.RecuperarParametro("RangoMillar", IdLitografia));

                if (!ddCorte.SelectedValue.Equals("0"))
                {
                    if (txtMontaje.Text.Equals("1/2") || txtMontaje.Text.Equals("1/3"))
                    {
                        //PrecioPlanchaMayor = 22000; PrecioImpresionMayor = 25000
                        precioPlancha = Convert.ToDecimal(ohelper.RecuperarParametro("PrecioPlanchaMayor", IdLitografia));
                        PrecioImpresion = Convert.ToDecimal(ohelper.RecuperarParametro("PrecioImpresionMayor", IdLitografia));
                        txtvalorplancha.Text = precioPlancha.ToString("C0", CultureInfo.CurrentCulture);
                        txtValorImpresion.Text = PrecioImpresion.ToString("C0", CultureInfo.CurrentCulture);

                        //Calculamos millares
                        if (!string.IsNullOrEmpty(txtImpresionestotales.Text))
                        {
                            imptotales = Convert.ToInt32(txtImpresionestotales.Text);
                            if (Rangomillar > imptotales)
                            {
                                contarmillar = 1;
                                GranTotalvalorImpresion = PrecioImpresion;
                            }
                            else
                            {
                                while (Rangomillar < imptotales)
                                {
                                    contarmillar++;
                                    Rangomillar = Rangomillar + 1000;
                                    GranTotalvalorImpresion = GranTotalvalorImpresion + PrecioImpresion;
                                }
                            }
                        }

                    }
                    else
                    {
                        //PrecioPlanchaMenor = 12000; PrecioImpresionMayor = 12000
                        precioPlancha = Convert.ToDecimal(ohelper.RecuperarParametro("PrecioPlanchaMenor", IdLitografia));
                        PrecioImpresion = Convert.ToDecimal(ohelper.RecuperarParametro("PrecioImpresionMenor", IdLitografia));
                        txtvalorplancha.Text = precioPlancha.ToString("C0", CultureInfo.CurrentCulture);
                        txtValorImpresion.Text = PrecioImpresion.ToString("C0", CultureInfo.CurrentCulture);

                        //Calculamos millares
                        if (!string.IsNullOrEmpty(txtImpresionestotales.Text))
                        {
                            imptotales = Convert.ToInt32(txtImpresionestotales.Text);
                            if (Rangomillar > imptotales)
                            {
                                contarmillar = 1;
                                GranTotalvalorImpresion = PrecioImpresion;
                            }
                            else
                            {
                                while (Rangomillar < imptotales)
                                {
                                    contarmillar++;
                                    Rangomillar = Rangomillar + 1000;
                                    GranTotalvalorImpresion = GranTotalvalorImpresion + PrecioImpresion;
                                }
                            }
                        }

                    }
                }
                else
                {
                    txtvalorplancha.Text = "0" ;
                    txtValorImpresion.Text = "0";
                }

                //Calcular Frente y respaldo
                decimal valorRespaldo;
                decimal valorImpresionFrente;
                decimal valorImpresionRespaldo;
                decimal totalPlancha = 0;
                decimal valorTotalImpresiones = 0;
                decimal valorFrente;

                if (!string.IsNullOrEmpty(txtFrente.Text) && !string.IsNullOrEmpty(txtRespaldo.Text))
                {
                    if (!txtFrente.Text.Equals(0) && txtRespaldo.Text.Equals(0) && ddMismaplancha.SelectedValue.Equals("No"))
                    {
                        totalPlancha = Convert.ToInt32(txtFrente.Text) * precioPlancha;
                        valorTotalImpresiones = Convert.ToInt32(txtFrente.Text) * GranTotalvalorImpresion;
                    }
                    if (!txtFrente.Text.Equals(0) && !txtRespaldo.Text.Equals(0) && ddMismaplancha.SelectedValue.Equals("No"))
                    {
                        valorFrente = Convert.ToInt32(txtFrente.Text) * precioPlancha;
                        valorRespaldo = Convert.ToInt32(txtRespaldo.Text) * precioPlancha;
                        totalPlancha = valorFrente + valorRespaldo;
                        valorImpresionFrente = Convert.ToInt32(txtFrente.Text) * GranTotalvalorImpresion;
                        valorImpresionRespaldo = Convert.ToInt32(txtRespaldo.Text) * GranTotalvalorImpresion;
                        valorTotalImpresiones = valorImpresionFrente + valorImpresionRespaldo;
                    }

                    if (!txtFrente.Text.Equals(0) && !txtRespaldo.Text.Equals(0) && ddMismaplancha.SelectedValue.Equals("Si"))
                    {                     
                        Int32 PapelExtra = Convert.ToInt32(ohelper.RecuperarParametro("PapelExtra", IdLitografia));
                        contarmillar = 0;
                        Rangomillar = Convert.ToInt32(ohelper.RecuperarParametro("RangoMillar", IdLitografia));
                        Int32 uno = ((imptotales - PapelExtra) * 2) + PapelExtra;
                        while (Rangomillar < uno)
                        {
                            contarmillar++; 
                            Rangomillar = Rangomillar + 1000;
                        }
                        totalPlancha = Convert.ToInt32(txtFrente.Text) * precioPlancha;
                        valorTotalImpresiones = (Convert.ToInt32(txtFrente.Text) * contarmillar) * GranTotalvalorImpresion;
                    }

                    txtValorTotalPapel.Text = txtValorTotalPapel.Text.Replace("$", "");
                    decimal Totalfactura = (totalPlancha + Convert.ToDecimal(txtValorTotalPapel.Text) + valorTotalImpresiones);
                    txtTotalfactura.Text = Totalfactura.ToString("C0", CultureInfo.CurrentCulture);

                }

            }
            catch (Exception)
            {
                throw;
            }
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
                RecuperarValorPlanchaEImpresion();
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
                txttamano.Text = String.Empty;
                txtCavidad.Text = String.Empty;
                CargarCombos();
                txtValorpapel.Text = String.Empty; 
                txtMontaje.Text = String.Empty; 
                txtCantidadpliego.Text =  String.Empty;
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