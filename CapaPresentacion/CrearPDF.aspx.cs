﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.UI;
using CapaEntidades;
using CapaLogicaNegocio;

using System.IO;
using System.Collections;


namespace CapaPresentacion
{
    public partial class CrearPDF : System.Web.UI.Page
    {
        DataHelper ohelper = new DataHelper();

        protected void Page_Load(object sender, EventArgs e)
        {

            Session["IsOtraPagina"] = true;
            Session["PanelPrincipal"] = "Generar PDF";
            if (!Page.IsPostBack)
            {
            }
        }


        protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {

        }
    }

}