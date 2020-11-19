using System;
using System.Web.UI;

namespace CapaPresentacion
{
    public partial class Home : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToBoolean(Session["IsOtraPagina"]))
                {
                    lblOpcionmenu.Text = Session["PanelPrincipal"].ToString();
                    Session["IsOtraPagina"] = false;
                }

                if (!Page.IsPostBack)
                {
                    Int16 TipoUsuario = Convert.ToInt16(Session["TipoUsuario"].ToString());


                    ProyectoList.Visible = false;
                    EmpleadosList.Visible = false;


                    //Si el usuario  es administrador  solo podra crear litografias
                    if (TipoUsuario == 1)
                    {
                        PanelGeneralList.Visible = false;
                        ClienteList.Visible = false;
                        CotizacionList.Visible = false;

                        Imglogo.ImageUrl = "~/img/litosoft.jpg";

                    }
                    else
                    {
                        LitografiaList.Visible = false;

                        byte[] logo = (byte[])(Session["Logo"]);

                        if (logo != null)
                        {
                            //string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(Imagenoriginal);
                            string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(logo);
                            //Esto es para mostrar la imagen seleccionada y mostrarla 
                            Imglogo.ImageUrl = ImagenDataURL64;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                //string mensaje = ex.Message;
                //ClientScript.RegisterStartupScript(this.GetType(), "Proyectos", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }


        }

    }
}