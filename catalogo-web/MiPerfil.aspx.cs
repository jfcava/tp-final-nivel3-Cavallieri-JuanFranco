using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace catalogo_web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    User usuario = (User)Session["usuario"];

                    txtApellido.Text = usuario.Apellido;
                    txtEmail.Text = usuario.Email;
                    txtEmail.ReadOnly = true;
                    txtNombre.Text = usuario.Nombre;
                    txtPassword.Text = usuario.Pass;
                    if (!string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                        imgPerfil.ImageUrl = "~/Images/" + usuario.UrlImagenPerfil;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            User userActualizado = (User)Session["usuario"];
            UserNegocio negocio = new UserNegocio();


            try
            {
                userActualizado.Nombre = txtNombre.Text;
                userActualizado.Apellido = txtApellido.Text;
                userActualizado.Pass = txtPassword.Text;

                if (txtImagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + userActualizado.Id + ".jpg");
                    userActualizado.UrlImagenPerfil = "perfil-" + userActualizado.Id + ".jpg";
                }

                negocio.actualizar(userActualizado);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}