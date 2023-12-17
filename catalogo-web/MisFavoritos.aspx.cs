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
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        User usuario = (User)Session["usuario"];
                        List<Articulo> listaFav = negocio.listarFavoritos(usuario.Id);

                        repFavoritos.DataSource = listaFav;
                        repFavoritos.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnQuitarFavorito_Click(object sender, EventArgs e)
        {
            FavoritoNegocio negocio = new FavoritoNegocio();
            int idArticulo = int.Parse(((Button)sender).CommandArgument);
            int idUser = ((User)Session["usuario"]).Id;

            try
            {
                negocio.quitarFavorito(idArticulo, idUser);
                Response.Redirect("MisFavoritos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }
    }
}