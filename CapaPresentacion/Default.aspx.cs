using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaPresentacion.Custom;

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


        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {

                bool auth = Membership.ValidateUser(LoginUser.UserName, LoginUser.Password);
                FormsAuthentication.SetAuthCookie(LoginUser.UserName, false);

                if (auth)
                {
                    Usuario usuario = new Usuario();

                    usuario = GetUsuario();
                    usuario = RecuperarUsuario(usuario.NomUsuario, usuario.Clave);

                    if (usuario != null)
                    {
                        SessionManager _SessionManager = new SessionManager(Session);
                        _SessionManager.UserSessionUsuario = usuario;

                        Session["TipoUsuario"] = usuario.IdTipoUsuario;
                        Session["IdLitografia"] = usuario.IdLitografia;


                        //Redireccionamos a otra pagina   
                        if (usuario.IdTipoUsuario == 2) //usuarios comunes
                        {
                            if (ImgLito != null)
                            {
                                Session["logo"] = ImgLito;

                            }
                            FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                            //Response.Redirect("Panelgeneral.aspx", false);

                        }
                        else //Administradors
                        {
                            FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
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

        //Metodo viejo sin autenticacion membership
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                bool auth = Membership.ValidateUser(LoginUser.UserName, LoginUser.Password);

                if (auth)
                {
                    Usuario usuario = new Usuario();

                    usuario = GetUsuario();
                    usuario = RecuperarUsuario(usuario.NomUsuario, usuario.Clave);

                    if (usuario != null)
                    {
                        SessionManager _SessionManager = new SessionManager(Session);
                        _SessionManager.UserSessionUsuario = usuario;
                

                        Session["TipoUsuario"] = usuario.IdTipoUsuario;
                        Session["IdLitografia"] = usuario.IdLitografia;


                        //Redireccionamos a otra pagina   
                        if (usuario.IdTipoUsuario == 2) //usuarios comunes
                        {
                            if (ImgLito != null)
                            {
                                Session["logo"] = ImgLito;
                        
                            }
                            FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                            //Response.Redirect("Panelgeneral.aspx", false);

                        }
                        else //Administradors
                        {
                            FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                            //Response.Redirect("GestionarLitografias.aspx", false);
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('USUARIO INCORRECTO.')</script>");
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

        public Usuario RecuperarUsuario(string usuario, string clave)
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
            oUsuario.NomUsuario = LoginUser.UserName;
            oUsuario.Clave = LoginUser.Password;
            return oUsuario;
        }
    }
}