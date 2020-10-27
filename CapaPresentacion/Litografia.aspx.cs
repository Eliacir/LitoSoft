using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Helpers;

namespace CapaPresentacion
{
    public partial class Litografia : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["IsOtraPagina"] = true;
                Session["PanelPrincipal"] = "Gestionar Litografia";
                if (!Page.IsPostBack)
                {
                    Boolean IsEditar = (bool)Session["IsEditar"];
                    if (IsEditar)
                    {
                        ValoresGVLitografia();
                        btnRegistrar.Text = "Actualizar";
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Representante", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegistrar.Text == "Actualizar")
                {
                    InfoLitografia infoLitografia = GetEditarLitografia();
                     ohelper.ActualizarLitografia(infoLitografia);
                     Response.Redirect("GestionarLitografias.aspx", false);
                    
                }
                else
                {
                    InfoLitografia infoLitografia = GetLitografia();
                    ohelper.InsertarLitografia(infoLitografia);
                    Response.Redirect("GestionarLitografias.aspx", false);

                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "Gestionar Litografia", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }

        }


        protected void btnSubir_Click(object sender, EventArgs e)
        {
            ViewState["ImagenLito"] = GetImagen();
        }

        private InfoLitografia GetLitografia()
        {
            var img = (byte[])ViewState["ImagenLito"];
            InfoLitografia oLitografia = new InfoLitografia();
            oLitografia.IdLitografia = 0;
            oLitografia.Nombre = txtNombre.Text;
            oLitografia.Direccion = txtDireccion.Text;
            oLitografia.Telefono = txtTelefono.Text;
            oLitografia.Imagen = img;

            Usuario oUsuario = new Usuario();
            oUsuario.NomUsuario = txtNombreusuario.Text;
            oUsuario.Clave = txtClave.Text;
            if (dpEstado.SelectedValue.Equals('1'))
            {
                oUsuario.Estado = true;
            }
            else
            {
                oUsuario.Estado = false;
            }
             

            oLitografia.UsuLitografia = oUsuario;
            return oLitografia;
        }

        private InfoLitografia GetEditarLitografia()
        {
            var img = (byte[])ViewState["ImagenLito"];
            InfoLitografia oLitografia = new InfoLitografia();
            oLitografia.IdLitografia = Convert.ToInt32(Session["IdLitografia"]);
            oLitografia.Nombre = txtNombre.Text;
            oLitografia.Direccion = txtDireccion.Text;
            oLitografia.Telefono = txtTelefono.Text;
            oLitografia.Imagen = img;

            Usuario oUsuario = new Usuario();
            oUsuario.NomUsuario = txtNombreusuario.Text;
            oUsuario.Clave = txtClave.Text;
            if (dpEstado.SelectedValue.Equals("1"))
            {
                oUsuario.Estado = true;
            }
            else
            {
                oUsuario.Estado = false;
            }

            oLitografia.UsuLitografia = oUsuario;
            return oLitografia;
        }

        private void ValoresGVLitografia()
        {
            try
            {
                short IdLitografia = Cast.ToShort(Session["IdLitografia"]);

                using (IDataReader reader = ohelper.RecuperarLitografiaPorIdLitografia(IdLitografia))
                {
                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                txtNombre.Text = Cast.ToString(reader["Nombre"]);
                                txtDireccion.Text = Cast.ToString(reader["Direccion"]);
                                txtTelefono.Text = Cast.ToString(reader["Telefono"]);
                                txtNombreusuario.Text = Cast.ToString(reader["Usuario"]);
                                txtClave.Text = Cast.ToString(reader["Clave"]);
                                bool Estado = Cast.ToBool(reader["Estado"]);
                                if (Estado)
                                {
                                    dpEstado.SelectedValue = "1";
                                }
                                else
                                {
                                    dpEstado.SelectedValue = "0";
                                }
                                byte[] img = (byte[])(reader["Logo"]);

                                ViewState["ImagenLito"] = img;
                                //string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(Imagenoriginal);
                                string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(img);

                                //Esto es para mostrar la imagen seleccionada y mostrarla 
                                Imglitografia.ImageUrl = ImagenDataURL64;
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public byte[] GetImagen()
        {
            int tamanio = fuploadImagen.PostedFile.ContentLength;
            byte[] Imagenoriginal = new byte[tamanio];

            if (tamanio != 0)
            {
                fuploadImagen.PostedFile.InputStream.Read(Imagenoriginal, 0, tamanio);
                Bitmap ImagenOriginalbinari = new Bitmap(fuploadImagen.PostedFile.InputStream);

                System.Drawing.Image imtThumbnail;
                int Tamaño = 200;
                imtThumbnail = RedimencionarImagen(ImagenOriginalbinari, Tamaño);
                byte[] bImagenThumbnail = new byte[Tamaño];

                ImageConverter Convertidor = new ImageConverter();
                bImagenThumbnail = (byte[])Convertidor.ConvertTo(imtThumbnail, typeof(byte[]));

                //string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(Imagenoriginal);
                string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(bImagenThumbnail);

                //Esto es para mostrar la imagen seleccionada y mostrarla
                Imglitografia.ImageUrl = ImagenDataURL64;

                return bImagenThumbnail;
            }
            else
            {
                return null;
            }
        }

        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image ImagenOriginal, int Alto)
        {
            var Radio = (double)Alto / ImagenOriginal.Height;
            var NuevoAncho = (int)(ImagenOriginal.Width * Radio);
            var NuevoAlto = (int)(ImagenOriginal.Height * Radio);
            var NuevaimagenRedimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(NuevaimagenRedimencionada);
            g.DrawImage(ImagenOriginal, 0, 0, NuevoAncho, NuevoAlto);
            return NuevaimagenRedimencionada;
        }




        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarLitografias.aspx", false);
        }




    }
}