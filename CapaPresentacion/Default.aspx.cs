using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;


namespace CapaPresentacion
{
    public partial class Default : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        private byte[] ImgLito = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                if (string.IsNullOrEmpty(RqClave.Text))
                {
                    usuario = GetUsuario();
                    usuario = RecuperarUsuario(usuario.NomUsuario,usuario.Clave);
                    if (usuario != null)
                    {
                        Session["TipoUsuario"] = usuario.IdTipoUsuario;
                        Session["IdLitografia"] = usuario.IdLitografia;

                     
                        //Redireccionamos a otra pagina   
                        if (usuario.IdTipoUsuario == 2) //usuarios comunes
                        {
                            if (ImgLito != null)
                            {                            
                                Session["logo"] = ImgLito;
                                Response.Redirect("Panelgeneral.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("Panelgeneral.aspx", false);
                            }
                           

                        }
                        else //Administradors
                        {
                            Response.Redirect("GestionarLitografias.aspx", false);
                        }
                       
                    }
                } 

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Iniciar sesión", "<script>swal('', '" + mensaje + "', 'error')</script>");
                //Mensaje Ok
                //ClientScript.RegisterStartupScript(this.GetType(), "BIEN ECHO", "<script>swal('', '" + mensaje + "', 'success')</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>swal('"  + mensaje + "')</script>");
            }
        }

        private  Usuario RecuperarUsuario(string usuario, string clave)
        {
            DataHelper ohelper = new DataHelper();
            Usuario ousuario = new Usuario();
            try
            {
                using (IDataReader readerusuario = ohelper.RecuperarUsuario(usuario, clave))
                {
                    if (readerusuario.Read())
                    {
                        ousuario.IdUsuario = Convert.ToInt32(readerusuario["IdUsuario"].ToString());
                        ousuario.NomUsuario = readerusuario["Usuario"].ToString();
                        ousuario.Clave = readerusuario["Clave"].ToString();
                        ousuario.IdTipoUsuario = Int16.Parse(readerusuario["IdTipoUsuario"].ToString());
                        if (ousuario.IdTipoUsuario == 2)
                        {
                            ousuario.IdLitografia = Int16.Parse(readerusuario["IdLitografia"].ToString());
                            ImgLito = (byte[])readerusuario["Logo"];                 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ousuario = null;
                throw ex;
            }
            return ousuario;
        }

        private Usuario GetUsuario()
        {
            Usuario oUsuario = new Usuario();
            oUsuario.NomUsuario = txtUsuario.Text;
            oUsuario.Clave = txtpassword.Text;
            return oUsuario;
        }
    }
}