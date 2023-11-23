<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GestionArticulos.aspx.cs" Inherits="catalogo_web.GestionArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8">
            <hr />
            <h1>Listado de Artículos</h1>
            <hr />
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <label for="txtFiltro" class="form-label">Filtro</label>
                        <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" style="margin-bottom:20px"></asp:TextBox>
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-warning" ID="btnBuscar" OnClick="btnBuscar_Click" />
                        <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-secondary" ID="btnLimpiar" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>
            <asp:GridView runat="server" ID="gvArticulos" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table" OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C2}" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✏️" />
                </Columns>
            </asp:GridView>
            <asp:Button Text="Agregar" ID="btnAgregar" runat="server" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
        </div>
    </div>
</asp:Content>
