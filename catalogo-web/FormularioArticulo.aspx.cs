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
        public bool confirmaEliminar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            confirmaEliminar = false;
            try
            {
                if (!IsPostBack)
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
                }


                if (Request.QueryString["id"] != null && !IsPostBack)
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtUrlImagen.Text;

                if (Request.QueryString["id"] == null)                
                    negocio.agregar(nuevo);                
                else
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(nuevo);
                }

                Response.Redirect("GestionArticulos.aspx", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminar = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            if (ckbConfirmaEliminar.Checked)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                int id = int.Parse(Request.QueryString["id"]);

                try
                {
                    negocio.eliminar(id);
                    Response.Redirect("GestionArticulos.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}