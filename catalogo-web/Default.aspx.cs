using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Web.Services.Description;

namespace catalogo_web
{

    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listaFavoritos;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            FavoritoNegocio negocioFav = new FavoritoNegocio();
            List<Articulo> listaArticulo = negocio.listar();

            if (Session["usuario"] != null)
                listaFavoritos = negocioFav.listarFavoritos(((User)Session["usuario"]).Id);


            if (!IsPostBack)
            {
                repRepetidor.DataSource = listaArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("FormularioArticulo.aspx?id=" + id, false);
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(((LinkButton)sender).CommandArgument);
            int idUser = ((User)Session["usuario"]).Id;
            FavoritoNegocio negocio = new FavoritoNegocio();
            List<Articulo> listaFavoritos = negocio.listarFavoritos(idUser);


            try
            {
                foreach (Articulo art in listaFavoritos)
                {
                    if (art.Id == idArticulo)
                    {
                        Response.Write("<script>alert('El artículo ya fue agregado');</script>");
                        return;
                    }

                }
                negocio.agregarFavorito(idUser, idArticulo);
                Response.Redirect("MisFavoritos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }


        protected bool MostrarBotonFavorito(object id)
        {
            if (Session["usuario"] != null)
            {
                int idArticulo = Convert.ToInt32(id);
                // Suponiendo que listaFavoritos es una lista de objetos Articulo
                return !listaFavoritos.Any(articulo => articulo.Id == idArticulo);
            }
            return false;
        }
    }
}