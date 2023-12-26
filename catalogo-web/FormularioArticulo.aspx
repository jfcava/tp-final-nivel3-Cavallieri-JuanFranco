<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="catalogo_web.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-2"></div>
            <div class="col-8">
                <%if (Request.QueryString["id"] == null && negocio.Seguridad.sesionActiva(Session["usuario"]))
                    {

                %>
                <h1 style="padding-top: 20px">Agregar Artículo</h1>
                <%}
                    else if (negocio.Seguridad.sesionActiva(Session["usuario"]))
                    {

                %>
                <h1 style="padding-top: 20px">Modificar Artículo</h1>
                <%}
                    else if(Request.QueryString["id"] != null)
                    { %>
                <h1 style="padding-top: 20px">Detalle del artículo</h1>
                <%}

                %>
                <hr />
            </div>
            <div class="col-2"></div>
        </div>
        <div class="row">
            <div class="col-2"></div>
            <div class="col">
                <div class="mb-3">
                    <label class="form-label">Código</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Descripción</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion" TextMode="MultiLine" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Marca</label>
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <%if (negocio.Seguridad.sesionActiva(Session["usuario"]))
                    { %>

                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <%if (Request.QueryString["id"] != null)
                    {  %>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                <%}%>
                <a href="GestionArticulos.aspx">Cancelar</a>
                <div class="mb-3">
                    <%if (confirmaEliminar)
                        {  %>
                    <asp:Label ID="lblConfirmarEliminar" runat="server" Text="Confirmar Eliminación" CssClass="form-label"></asp:Label>
                    <asp:CheckBox ID="ckbConfirmaEliminar" runat="server" />
                    <asp:Button ID="btnConfirmaEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminar_Click" />
                    <%}

                    %>
                </div>
                <%}
                    else
                    {  %>
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-primary" onclick="btnRegresar_Click" />
                <%} %>
            </div>
            <div class="col">
                <div class="mb-3">
                    <label class="form-label">Url Imagen</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Precio</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio" />
                </div>
                <div class="mb-3">
                    <asp:Image ID="imgArticulo" runat="server" ImageUrl="https://www.pulsecarshalton.co.uk/wp-content/uploads/2016/08/jk-placeholder-image.jpg" Width="50%" />
                </div>
            </div>
            <div class="col-2"></div>
        </div>
    </div>
</asp:Content>
