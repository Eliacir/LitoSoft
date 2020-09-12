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
    public partial class ManoObras : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        public Int16 Idproyecto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["IsOtraPagina"] = true;
                Session["PanelPrincipal"] = "Gestionar Mano de Obra";
                if (!Page.IsPostBack)
                {
                    Boolean IsEditar = (bool)Session["IsEditar"];
                    if (IsEditar)
                    {
                        ValoresGVManoObra();
                        btnRegistrar.Text = "Actualizar";
                        Session["IsEditar"] = false;
                    }
                    else
                    {
                        //Obtenemos idproyecto
                        Idproyecto = Convert.ToInt16(Session["IdproyectoManoObra"].ToString());
                    }
                      
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Mano de obra", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
           
        }

        private void ValoresGVManoObra()
        {
            try
            {
                short IdManoObra = Cast.ToShort(Session["IdManoObraGM"]);

                using (var reader = ohelper.RecuperarManoObraPorIdManoObra(IdManoObra))
                {
                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            txtDescripcion.Text = Cast.ToString(reader["Descripcion"]);
                            txtCantidad.Text = Cast.ToString(reader["CantidadPersonas"]);
                            txtTiempo.Text = Cast.ToString(reader["Tiempo"]);

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
                    ManoObra manoObra = GetEditarEntity();
                    bool res = ohelper.ActualizarManoDeObra(manoObra);
                    if (res)
                    {
                        Response.Redirect("GestionarManoObra.aspx",false);
                    }
                }
                else
                {
                    //Obtenemos idproyecto
                    Idproyecto = Convert.ToInt16(Session["IdproyectoManoObra"].ToString());
                    ManoObra manoObra = GetEntity();
                    bool res = ohelper.InsertarmanoDeObra(manoObra);
                    if (res)
                    {
                        Response.Redirect("GestionarManoObra.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Mano de obra", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }
           
        }

        private ManoObra GetEntity()
        {
            ManoObra oManoObra = new ManoObra();
            oManoObra.IdManoObra = 0;
            oManoObra.IdProyecto = Idproyecto;
            oManoObra.Descripcion = txtDescripcion.Text;
            oManoObra.CantidadPersonas = Convert.ToInt16(txtCantidad.Text);
            oManoObra.Tiempo = txtTiempo.Text;

            return oManoObra;
        }

        private ManoObra GetEditarEntity()
        {
            ManoObra oManoObra = new ManoObra();
            oManoObra.IdManoObra = Convert.ToInt32(Session["IdManoObraGM"]);
            oManoObra.IdProyecto = Convert.ToInt16(Session["IdProyectoGM"]);
            oManoObra.Descripcion = txtDescripcion.Text;
            oManoObra.CantidadPersonas = Convert.ToInt16(txtCantidad.Text);
            oManoObra.Tiempo = txtTiempo.Text;

            return oManoObra;
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("GestionarManoObra.aspx", false);
        }
    }
}