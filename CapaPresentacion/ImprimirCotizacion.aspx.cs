using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.UI;
using CapaEntidades;
using CapaLogicaNegocio;

using System.IO;
using System.Collections;
using CapaLogicaNegocio.Helpers;

namespace CapaPresentacion
{
    public partial class ImprimirCotizacion : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        protected void Page_Load(object sender, EventArgs e)
        {

            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Imprimir Cotización";
            if (!Page.IsPostBack)
            {
            }
        }


        protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {

        }
    }

}