using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Web.Services.Description;

namespace catalogo_web
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulo = negocio.listar();

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
            int idArticulo = int.Parse(((Button)sender).CommandArgument);
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
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }        
    }
}