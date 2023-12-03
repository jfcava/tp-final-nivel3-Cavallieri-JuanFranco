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
    public partial class MisFavoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FavoritoNegocio negocio = new FavoritoNegocio();

            try
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    User usuario = (User)Session["usuario"];
                    List<int> idArticulos = negocio.listarFavoritos(usuario.Id);
                    ArticuloNegocio artNegocio = new ArticuloNegocio();

                    foreach (int id in idArticulos)
                    {
                        artNegocio.listar(id.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }


        }
    }
}