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
    public partial class GestionarImagenes : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();
        bool Hayimagenes = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Registrar Imagenes";
            if (!Page.IsPostBack)
            {
                ddlProyectos.DataSource = ohelper.RecuperarProyectos();
                ddlProyectos.DataTextField = "Nombre";
                ddlProyectos.DataValueField = "IdProyecto";
                ddlProyectos.DataBind();
            }
            Hayimagenes = false;
            ConsultarImagenesPorProyecto(Convert.ToInt32(ddlProyectos.SelectedValue));
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                ImagenesProyectos imagenesProyectos = new ImagenesProyectos();
                imagenesProyectos = GetImagenesProyectos();
                if (imagenesProyectos.Imagen != null)
                {
                    ohelper.InsertarImagenProyecto(imagenesProyectos);
                }

                ConsultarImagenesPorProyecto(Convert.ToInt32(ddlProyectos.SelectedValue));

                txtTitulo.Text = string.Empty;
                txtNumeroImagen.Text = string.Empty;

                //Mensaje Ok
                string mensaje = "Imagen agregada satisfactoriamente.!";
                ClientScript.RegisterStartupScript(this.GetType(), "Gestion Imagenes", "<script>swal('', '" + mensaje + "', 'success')</script>");

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestion Imagenes", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }

        }



        public ImagenesProyectos GetImagenesProyectos()
        {
            byte[] Imagen = GetImagen();
            ImagenesProyectos imagen = new ImagenesProyectos();
            imagen.IdCotizacion = 0;
            imagen.IdProyecto = Convert.ToInt32(ddlProyectos.SelectedValue);
            imagen.Imagen = Imagen;
            imagen.Tituloimagen = txtTitulo.Text;
            imagen.NumeroImagen = Convert.ToInt32(txtNumeroImagen.Text);
            return imagen;
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
                //ImgPreviw.ImageUrl = ImagenDataURL64;

                return bImagenThumbnail;
            }
            else
            {
                return null;
            }
        }


        //Consultar imagenes de la bd
        private void ConsultarImagenesPorProyecto(Int32 IdProyecto)
        {
            //Recuperamos las imagenes de la bd con un Datatable
            DataTable ImagenesBD = new DataTable();
            ImagenesBD = ohelper.RecuperarImagenes(IdProyecto);
            if (ImagenesBD.Rows.Count > 0)
            {
                Hayimagenes = true;
            }

            Repeater1.DataSource = ImagenesBD;
            Repeater1.DataBind();



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


        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProyectos.aspx", false);
        }

        protected void btnAtras_Click1(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProyectos.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Hayimagenes)
            {
                ohelper.EliminarImagenesPorProyecto(Convert.ToInt32(ddlProyectos.SelectedValue));
                Hayimagenes = false;
                //Mensaje Ok
                string mensaje = "Imagenes eliminadas satisfactoriamente.";
                ClientScript.RegisterStartupScript(this.GetType(), "Gestion Imagenes", "<script>swal('', '" + mensaje + "', 'success')</script>");

                ConsultarImagenesPorProyecto(Convert.ToInt32(ddlProyectos.SelectedValue));
            }
            else
            {
                string mensaje = "El proyecto no contiene imagenes";
                //Mensaje Error
                ClientScript.RegisterStartupScript(this.GetType(), "Gestion Imagenes", "<script>swal('Error', '" + mensaje + "', 'error')</script>");
            }

        }
    }
}