using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace catalogo_web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://www.shutterstock.com/image-vector/vector-flat-illustration-grayscale-avatar-600nw-2281862025.jpg";

            if (!(Page is Default || Page is Login || Page is Error || Page is Registro))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Session.Add("error", "No estas logueado");
                    Response.Redirect("Error.aspx", false);
                }

            }

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                User usuario = (User)Session["usuario"];
                lblUsuario.Text = usuario.Email;

                if (!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                    imgAvatar.ImageUrl = "~/Images/" + ((User)Session["usuario"]).UrlImagenPerfil;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }

        protected void btnMiPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}