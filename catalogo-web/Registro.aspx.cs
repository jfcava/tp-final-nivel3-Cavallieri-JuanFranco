﻿using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace catalogo_web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            User nuevo = new User();
            UserNegocio negocio = new UserNegocio();

            try
            {
                nuevo.Email = txtEmail.Text;
                nuevo.Pass = txtPassword.Text;

                negocio.insertarNuevo(nuevo);

                if (negocio.Login(nuevo))
                {
                    Session.Add("usuario", nuevo);
                    Response.Redirect("MiPerfil.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}