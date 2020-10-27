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
using CapaLogicaNegocio.Extensions;
using CapaLogicaNegocio.Models;
using CapaLogicaNegocio.Helpers;
using CapaLogicaNegocio.Types;

namespace CapaPresentacion
{
    public partial class PaginaCotizacion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;

            Session["PanelPrincipal"] = "Gestionar Cotizaciones";

            var idLitografia = Convert.ToInt16(Session["IdLitografia"]);

            Helper = new DataHelper();

            if (!Page.IsPostBack)
            {
                Cotizacion = new Cotizacion(idLitografia);

                LimpiarTodosLosDatos();
            }                   
        }    

        /// <summary>
        /// Devuelve el controlador de acceso a datos
        /// </summary>
        private DataHelper Helper { get; set; }

        /// <summary>
        /// Devuelve o establece el acabado que esta creado actualmente
        /// </summary>
        private Acabado AcabadoActual { get; set; }

        /// <summary>
        /// Devuelve el objeto cotizacion asociado
        /// </summary>
        private Cotizacion Cotizacion
        {
            get
            {
                return (Cotizacion)ViewState["Cotizacion"];
            }
            set
            {
                ViewState["Cotizacion"] = value;
            }
        }

        /// <summary>
        /// Indice de la fila de acabado modificada
        /// </summary>
        private int FilaActualAcabado
        {
            get
            {
               return Cast.ToInt(ViewState["FilaActualAcabado"]);
            }
            set
            {
                ViewState["FilaActualAcabado"] = value;
            }
        }

        #region "METODOS Y FUNCIONES"

        /// <summary>
        /// Crea una lista desplegable
        /// </summary>
        private void CrearCombo(ref DropDownList combo,
                                string field,
                                string value,
                                object source,
                                bool agregarSeleccionar = true)
        {
            combo.DataSource = source;

            if (source == null)
                combo.Items.Clear();
            else
            {
                combo.DataTextField = field;
                combo.DataValueField = value;
                combo.DataBind();
            }

            if (agregarSeleccionar)
                combo.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        /// <summary>
        /// Devuelve los valores del item seleccionado texto y id
        /// </summary>
        private (int Id, string Name) ObtenerValorCombo(DropDownList combo)
        {
            if (combo.SelectedIndex < 1)
                return (0, null);

            var id = Cast.ToInt(combo.SelectedValue);

            var value = combo.SelectedItem.Text;

            return (id, value);
        }

        /// <summary>
        /// Llena los combos con los valores de la base de datos
        /// </summary>
        private void CargarCombos()
        {
            var id = Cotizacion.IdLitografia;

            //Recuperamos Clientes
            DataSet dataSet = Helper.RecuperarClientes(id);
            CrearCombo(ref ddClientes, "Nombre", "IdCliente", dataSet);

            //Recuperamos Papel
            dataSet = Helper.RecuperarPapel(id);
            CrearCombo(ref ddSustrato, "Nombre", "IdPapel", dataSet);

            //Recuperamos Corte
            dataSet = Helper.RecuperarCorte(id);
            CrearCombo(ref ddCorte, "Corte", "IdCorte", dataSet);

            //Cargar Acabados
            CargarAcabados(true);
        }

        /// <summary>
        /// Carga los acabados en el combo 
        /// </summary>
        private void CargarAcabados(bool todos)
        {
            var id = Cotizacion.IdLitografia;

            var table = Helper.RecuperarAcabados(id).Tables[0];

            if (!todos)
            {
                table.PrimaryKey = new DataColumn[] { table.Columns["Codigo"] };

                foreach (var acabado in Cotizacion.Acabados.ObtenerTodos())
                {
                    var row = table.Rows.Find(acabado.Codigo);

                    table.Rows.Remove(row);
                }
            }

            if (table.Rows.Count < 1) table = null;

            CrearCombo(ref ddAcabados, "Descripcion", "Codigo", table);

            ddAcabados.SelectedIndex = 0;
        }

        /// <summary>
        /// Limpia todos los controles de la cotizacion
        /// </summary>
        private void LimpiarControlesCotizacion()
        {
            ddMismaplancha.SelectedValue = "Si";
            ddFrente.SelectedValue = "No";
            ddRespaldo.SelectedValue = "No";

            txtCantidad.Text = String.Empty;
            txtCostoDiseno.Text = String.Empty;
            txtCavidad.Text = String.Empty;
            txtValorpapel.Text = String.Empty;
            txtMontaje.Text = String.Empty;
            txtCantidadpliego.Text = String.Empty;
            txtvalorplancha.Text = String.Empty;
            txtValorImpresion.Text = String.Empty;
            txtValorTotalPapel.Text = String.Empty;
            txtFrente.Text = String.Empty;
            txtRespaldo.Text = String.Empty;
            txtImpresionestotales.Text = String.Empty;
            txtFrente.Enabled = false;
            txtRespaldo.Enabled = false;

            CargarCombos();

            ActualizarTotales();
        }

        /// <summary>
        /// Limpia los controles de añadir acabados
        /// </summary>
        private void LimpiarControlesAcabados()
        {
            ddAcabados.Enabled = true;

            ddAcabados.SelectedIndex = 0;
            ddTipoToquelado.SelectedIndex = 0;
            ddFrenteAcabado.SelectedValue = "Si";
            ddRespaldoAcabado.SelectedValue = "No";

            txtValorAcabado.Text = String.Empty;         
            txtValorToquelado.Text = String.Empty;

            MostrarTroquelado(ddAcabados.SelectedValue);

            btnAgregar.ImageUrl = "~/img/Agregar.png";

            FilaActualAcabado = 0;

            ActualizarTotales();
        }

        /// <summary>
        /// Limpia la grilla de acabados
        /// </summary>
        private void LimpiarGrillaAcabados()
        {
            ddAcabados.Enabled = true;

            var table = ObtenerTablaAcabados();

            if (table == null) return;

            ViewState["TablaAcabados"] = null;

            GvAcabados.DataSource = null;

            GvAcabados.DataBind();
        }

        /// <summary>
        /// Establece los valores de la pagina en la cotizacion
        /// </summary>
        private void EstablecerValoresCotizacion()
        {
            var papel = ObtenerValorCombo(ddSustrato);

            var corte = ObtenerValorCombo(ddCorte);

            Cotizacion.Cantidad = Cast.ToInt(txtCantidad.Text);

            Cotizacion.CostoDiseño = Cast.ToDecimal(txtCostoDiseno.Text);

            Cotizacion.Cavidad = Cast.ToInt(txtCavidad.Text);

            Cotizacion.UsaFrente = txtFrente.Enabled;

            Cotizacion.UsaRespaldo = txtRespaldo.Enabled;

            Cotizacion.ColoresDelFrente = Cast.ToInt(txtFrente.Text);

            Cotizacion.ColoresDelRespaldo = Cast.ToInt(txtRespaldo.Text);

            Cotizacion.UsaLaMismaPlancha = (ddMismaplancha.Text.Equals("No")) ? false : true;

            Cotizacion.SetPapel(papel.Id, papel.Name);

            Cotizacion.SetCorte(corte.Id, corte.Name);

        }

        /// <summary>
        /// Establece los valores calculados de la cotizacion en la pagina
        /// </summary>
        private void EstablecerValoresCalculados()
        {    
            txtValorpapel.Text = Cotizacion.PrecioPapel.FormatoMoneda();

            txtMontaje.Text = Cotizacion.Montaje;

            txtImpresionestotales.Text = Cotizacion.ImpresionesTotales.ToString();

            txtCantidadpliego.Text = Cotizacion.CantidadPliegos.ToString();

            txtvalorplancha.Text = Cotizacion.ValorPlancha.FormatoMoneda();

            txtValorImpresion.Text = Cotizacion.ValorImpresion.FormatoMoneda();

            txtValorTotalPapel.Text = Cotizacion.ValorTotalDelPapel.FormatoMoneda();

            txtValorTotalImpresiones.Text = Cotizacion.ValorTotalImpresiones.FormatoMoneda();

            txtValorTotalplancha.Text = Cotizacion.ValorTotalEnPlancha.FormatoMoneda();

            txtFrente.Enabled = ddFrente.SelectedValue.In("Si");

            txtRespaldo.Enabled = ddRespaldo.SelectedValue.In("Si");

            txtpapelextra.Value = Cotizacion.Parametros.PapelExtra.ToString();

            txtMontajeDecimal.Value = Cotizacion.MontajeDecimal.ToStringInvariant();

            if (!txtFrente.Enabled) txtFrente.Text = String.Empty;

            if (!txtRespaldo.Enabled) txtRespaldo.Text = String.Empty;

            ActualizarTotales();
        }

        /// <summary>
        /// Devuelve la tabla de acabados
        /// </summary>
        private DataTable ObtenerTablaAcabados() =>
            ViewState["TablaAcabados"] as DataTable;
      
        /// <summary>
        /// Crear un acabado para la cotizacion
        /// </summary>
        private Acabado CrearAcabado()
        {
            var codigo = ddAcabados.SelectedValue;

            if (String.IsNullOrEmpty(codigo)) return null;

            var usaFrenteYRespaldo = UsaFrenteYRespaldo(codigo);

            var usaTroquelado = codigo.In(TipoAcabado.Troquelado);

            bool? usaFrente = usaFrenteYRespaldo ? (bool?)ddFrenteAcabado.SelectedValue.In("Si") : null;

            bool? usaRespaldo = usaFrenteYRespaldo ? (bool?)ddRespaldoAcabado.SelectedValue.In("Si") : null;

            var tipoTroquelado = usaTroquelado ? ddTipoToquelado.SelectedValue.ToString() : null;

            var valorTroquelado = usaTroquelado ? Cast.ToDecimalNull(txtValorToquelado.Text) : null;

            return new Acabado(Cotizacion, codigo, usaFrente, usaRespaldo, tipoTroquelado, valorTroquelado);         
        }

        /// <summary>
        /// Crear una fila para la grilla de acabados
        /// </summary>
        private DataRow Crearfila(Acabado acabado, DataTable table)
        {
            if (acabado == null) return null;

            CrearPlantillaDeFila(ref table);

            var row = table.NewRow();

            row["RowId"] = acabado.Codigo;
            row["RowNumber"] = (table?.Rows?.Count ?? 0) + 1;
            row["Acabado"] = acabado.Nombre;
            row["Valor"] = acabado.ValorTotal.FormatoMoneda();
            row["TipoTroquelado"] = acabado.TipoTroquelado;
            row["ValorTroquelado"] = acabado.ValorTroquelado?.FormatoMoneda();
            row["Frente"] = acabado.UsaFrente?.ToStringBool();
            row["Respaldo"] = acabado.UsaRespaldo?.ToStringBool();

            return row;
        }

        /// <summary>
        /// Crea una plantilla de las filas de la tabla
        /// </summary>
        private void CrearPlantillaDeFila(ref DataTable table)
        {
            if (ObtenerTablaAcabados() != null) return;

            table.Columns.Add(new DataColumn("RowId", typeof(string)));
            table.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            table.Columns.Add(new DataColumn("Acabado", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(string)));
            table.Columns.Add(new DataColumn("TipoTroquelado", typeof(string)));
            table.Columns.Add(new DataColumn("ValorTroquelado", typeof(string)));
            table.Columns.Add(new DataColumn("Frente", typeof(string)));
            table.Columns.Add(new DataColumn("Respaldo", typeof(string)));          
        }

        /// <summary>
        /// Agrega una fila la grilla
        /// </summary>
        private void AgregarNuevoAcabado()
        {
            if (ddAcabados.SelectedIndex < 1)
                return;

            var table = ObtenerTablaAcabados()?? new DataTable();

            AcabadoActual = CrearAcabado();

            var row = Crearfila(AcabadoActual, table);

            if (row == null) return;

            table.Rows.Add(row);

            CargarDatosGrilla(table);

            Cotizacion.Acabados.AgregarAcabado(AcabadoActual);

            LimpiarControlesAcabados();

            CargarAcabados(false);
        }

        /// <summary>
        /// actualiza los totales de factura y acabados
        /// </summary>
        private void ActualizarTotales()
        {
            txtTotalAcabados.Text = Cotizacion.Acabados.TotalAcabados.FormatoMoneda();

            txtTotalfactura.Text = Cotizacion.TotalCotizacion.FormatoMoneda();
        }

        /// <summary>
        /// Carga los datos de la tabla en la grilla
        /// </summary>
        private void CargarDatosGrilla(DataTable table)
        {
            ViewState["TablaAcabados"] = table;

            GvAcabados.DataSource = table;

            GvAcabados.DataBind();
        }

        /// <summary>
        /// Actualiza el cuadro de texto del valor del acabado
        /// </summary>
        private void ActualizarValorAcabado()
        {
            AcabadoActual = CrearAcabado();

            if(AcabadoActual != null)
                txtValorAcabado.Text = AcabadoActual.ValorTotal.FormatoMoneda();
        }

        /// <summary>
        /// Coloca los valores del acabado en los controles para modificarlos 
        /// </summary>
        private void ActualizarAcabado(DataRow row)
        {
            if (row == null) return;

            var codigo = row["RowId"].ToString();

            CargarAcabados(true);

            MostrarTroquelado(codigo);

            ddAcabados.Enabled = false;

            ddAcabados.SelectedValue = codigo;
   
            if (codigo.In(TipoAcabado.Troquelado))
            {
                ddTipoToquelado.SelectedValue = row["TipoTroquelado"].ToString();

                txtValorToquelado.Text = row["ValorTroquelado"].ToString().QuitarFormatoMoneda().ToString();
            }

            if (UsaFrenteYRespaldo(codigo))
            {
                ddFrenteAcabado.SelectedValue = row["Frente"].ToString();

                ddRespaldoAcabado.SelectedValue = row["Respaldo"].ToString();
            }

             txtValorAcabado.Text = row["Valor"].ToString();

             btnAgregar.ImageUrl = "~/img/Accept.png";
        }

        /// <summary>
        /// Elimina la fila de acabado especificada
        /// </summary>
        private void EliminarAcabado(DataRow row)
        {
            var table = ObtenerTablaAcabados();

            if (table == null || row == null) return;

            var codigo = row["RowId"].ToString();

            table.Rows.Remove(row);

            CargarDatosGrilla(table);

            Cotizacion.Acabados.QuitarAcabado(codigo);

            CargarAcabados(false);

            ActualizarValoresDeAcabados();

            LimpiarControlesAcabados();
        }

        /// <summary>
        /// Muestra u oculta los campos para establecer los valores del troquelado
        /// </summary>
        /// <param name="visible"></param>
        private void MostrarTroquelado(string codigo)
        {
            String[] names = { "Frente", "Respaldo", "Tipo", "Valor" };

            if (String.IsNullOrEmpty(codigo)) return;

            var usaFrenteYRespaldo = UsaFrenteYRespaldo(codigo);

            lblTituloValor1.InnerText = usaFrenteYRespaldo ? names[0] : names[2];
            lblTituloValor2.InnerText = usaFrenteYRespaldo ? names[1] : names[3];

            ddFrenteAcabado.Visible = usaFrenteYRespaldo;
            ddRespaldoAcabado.Visible = usaFrenteYRespaldo;

            lblTituloValor1.Visible = true;
            lblTituloValor2.Visible = true;

            if (codigo.In(TipoAcabado.Troquelado))
            {              
                ddTipoToquelado.Visible = !usaFrenteYRespaldo;
                txtValorToquelado.Visible = !usaFrenteYRespaldo;
            }
            else
            {
                ddTipoToquelado.Visible = false;
                txtValorToquelado.Visible = false;
                txtValorToquelado.Text = null;

                if (!usaFrenteYRespaldo)
                {
                    lblTituloValor1.Visible = false;
                    lblTituloValor2.Visible = false;
                }
            }          
        }

        /// <summary>
        /// Guarda los datos modificados del acabado
        /// </summary>
        private void GuardarAcabado()
        {
            var row = ObtenerFilaActualDeTabla(FilaActualAcabado);

            if (row == null || FilaActualAcabado < 1) return;

            var codigo = ddAcabados.SelectedValue;
            var nombreAcabado = ddAcabados.SelectedItem.Text;
            var valorAcabado = txtValorAcabado.Text;

            var usaFrenteYRespaldo = UsaFrenteYRespaldo(codigo);
            var usaTroquelado = codigo.In(TipoAcabado.Troquelado);

            var usaFrente = usaFrenteYRespaldo ? ddFrenteAcabado.SelectedValue : null;
            var usaRespaldo = usaFrenteYRespaldo ? ddRespaldoAcabado.SelectedValue : null;
            var tipoTroquelado = usaTroquelado ? ddTipoToquelado.SelectedValue : null;
            var valorTroquelado = usaTroquelado ? Cast.ToDecimalNull(txtValorToquelado.Text) : null;

            row["Acabado"] = nombreAcabado;
            row["Valor"] = valorAcabado;
            row["TipoTroquelado"] = tipoTroquelado;
            row["ValorTroquelado"] = valorTroquelado?.FormatoMoneda();
            row["Frente"] = usaFrente;
            row["Respaldo"] = usaRespaldo;

            var table = ObtenerTablaAcabados();

            CargarDatosGrilla(table);

            var acabado = Cotizacion.Acabados.ObtenerAcabado(codigo);

            acabado.Nombre = nombreAcabado;
            acabado.TipoTroquelado = tipoTroquelado;
            acabado.ValorTroquelado = valorTroquelado;
            acabado.UsaFrente = usaFrente?.In("Si");
            acabado.UsaRespaldo = usaRespaldo?.In("Si");

            Cotizacion.Acabados.ModificarAcabado(acabado);

            LimpiarControlesAcabados();

            CargarAcabados(false);
        }

        /// <summary>
        /// Actualiza los valores de todos los acabados agregados
        /// </summary>
        public void ActualizarValoresDeAcabados()
        {
            var table = ObtenerTablaAcabados();

            if (table == null) return;

            var number = 1;

            foreach (DataRow row in table.Rows)
            {
                var codigo = row["RowId"].ToString();

                var acabado = Cotizacion.Acabados.ObtenerAcabado(codigo);

                row["Valor"] = acabado.ValorTotal.FormatoMoneda();

                row["RowNumber"] = number++;
            }

            CargarDatosGrilla(table);
        }

        /// <summary>
        /// Devuelve la fila del origen de datos, seleccionada actualmente en la grilla
        /// </summary>
        private DataRow ObtenerFilaActualDeTabla(int index)
        {
            var table = ObtenerTablaAcabados();

            if (table == null) return null;

            return table.Rows[index];
        }

        /// <summary>
        /// Devuelve la fila seleccionada actualmente en la grilla
        /// </summary>
        private DataRow ObtenerFilaActualDeGrilla(GridViewCommandEventArgs e)
        {
            var cell = ((e.CommandSource as ImageButton).Parent as DataControlFieldCell);

            var currentRow = cell.Parent as GridViewRow;

            FilaActualAcabado = currentRow.RowIndex;

            return ObtenerFilaActualDeTabla(FilaActualAcabado);
        }

        /// <summary>
        /// Actualiza todos los datos en la pagina
        /// </summary>
        private void ActualizarTodosLosDatos()
        {
            EstablecerValoresCotizacion();

            EstablecerValoresCalculados();

            ActualizarValoresDeAcabados();
        }

        /// <summary>
        /// Limpia todos los datos de la pagina
        /// </summary>
        private void LimpiarTodosLosDatos()
        {
            LimpiarControlesCotizacion();

            LimpiarControlesAcabados();

            LimpiarGrillaAcabados();
        }

        /// <summary>
        /// Devuelve un valor que indica si el acabado usa frente y respaldo o no
        /// </summary>
        private bool UsaFrenteYRespaldo(string codigo) =>
            !codigo.In(TipoAcabado.Troquelado,
                       TipoAcabado.Semicorte,
                       TipoAcabado.Repujado,
                       TipoAcabado.Sanduchado);
        
        #endregion


        #region "EVENTOS DE CONTROL"

        /// <summary>
        /// Limpia todos los controles de la pagina
        /// </summary>
        protected void bntLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodosLosDatos();
        }

        /// <summary>
        /// Muestra u oculta los acabados de la cotizacion
        /// </summary>
        protected void btnAcabados_Click(object sender, EventArgs e)
        {
            string[] labels = { "Ocultar Acabados", "Mostrar Acabados" };

            var index = (!btnAcabados.Text.Contains("Mostrar")) ? 1 : 0;

            MultiView.ActiveViewIndex = index;

            btnAcabados.Text = labels[index];

            LimpiarControlesAcabados();
        }

        /// <summary>
        /// Actualiza el valor del acabado en la caja de texto de txtValorAcabado
        /// </summary>
        protected void ddAcabados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigo = ddAcabados.SelectedValue;

            MostrarTroquelado(codigo);

            ActualizarValorAcabado();
        }

        /// <summary>
        /// Actualiza el valor del acabado en la caja de texto de txtValorAcabado
        /// </summary>
        protected void ddFrenteAcabado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarValorAcabado();
        }

        /// <summary>
        /// Actualiza el valor del acabado en la caja de texto de txtValorAcabado
        /// </summary>
        protected void ddRespaldoAcabado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarValorAcabado();
        }

        /// <summary>
        /// Envia el comando para agregar una fila a la grilla
        /// </summary>
        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            if (FilaActualAcabado > 0)
                GuardarAcabado();
            else
                AgregarNuevoAcabado();
        }

        /// <summary>
        /// Ejecuta los comandos de la grilla
        /// </summary>
        protected void GvAcabados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var row = ObtenerFilaActualDeGrilla(e);

            switch (e.CommandName)
            {
                case "Actualizar":
                    ActualizarAcabado(row);
                    break;

                case "Eliminar":
                    EliminarAcabado(row);
                    break;
            }
        }

        protected void ddSustrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void ddCorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void ddFrente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void ddRespaldo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void ddMismaplancha_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void txtCantidad_OnTextChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void txtCostoDiseno_OnTextChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void txtCavidad_OnTextChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void txtFrente_OnTextChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }

        protected void txtRespaldo_OnTextChanged(object sender, EventArgs e)
        {
            ActualizarTodosLosDatos();
        }     

        protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
        }

        protected void GvAcabados_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GvAcabados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }



        

        #endregion

    }
}