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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                
                ddlCategoria.DataSource = categoriaNegocio.listar();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();

                ddlMarca.DataSource = marcaNegocio.listar();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();


                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> listaModificado = negocio.listar(id);

                    Articulo modificado = listaModificado[0];

                    txtCodigo.Text = modificado.Codigo;
                    txtNombre.Text = modificado.Nombre;
                    txtDescripcion.Text = modificado.Descripcion;

                    ddlCategoria.SelectedValue = modificado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = modificado.Marca.Id.ToString();

                    txtPrecio.Text = modificado.Precio.ToString();
                    txtUrlImagen.Text = modificado.ImagenUrl;

                    imgArticulo.ImageUrl = modificado.ImagenUrl;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }
    }
}