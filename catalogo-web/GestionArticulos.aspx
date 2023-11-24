<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GestionArticulos.aspx.cs" Inherits="catalogo_web.GestionArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <hr />
                <h1>Listado de Artículos</h1>
                <hr />

                <div class="col-6">
                    <div class="mb-3">
                        <label for="txtFiltro" class="form-label">Filtro</label>
                        <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" Style="margin-bottom: 20px"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblFiltroAvanzado" runat="server" Text="Filtro Avanzado" CssClass="form-label"></asp:Label>
                        <asp:CheckBox ID="ckbFiltroAvanzado" runat="server" OnCheckedChanged="ckbFiltroAvanzado_CheckedChanged" AutoPostBack="true" />
                    </div>
                </div>
                <div class="col-6">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-warning" ID="btnBuscar" OnClick="btnBuscar_Click" Style="margin-top: 32px" />
                    <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-secondary" ID="btnLimpiar" OnClick="btnLimpiar_Click" Style="margin-top: 32px" />
                </div>
            </div>
            <%if (ckbFiltroAvanzado.Checked)
                {  %>
            <div class="row">
                <div class="col-4">
                    <label for="ddlCampo" class="form-label">Campo</label>
                    <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Código" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Marca" />
                        <asp:ListItem Text="Categoria" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                </div>
                <div class="col-4">
                    <label for="ddlCriterio" class="form-label">Criterio</label>
                    <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-3">
                    <label for="txtFiltroAvanzado" class="form-label">Filtro</label>
                    <asp:TextBox ID="txtFiltroAvanzado" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-1">
                    <asp:Button Text="Buscar" runat="server" ID="btnBuscarAvanzado" CssClass="btn btn-primary" OnClick="btnBuscarAvanzado_Click" style="margin-top:32px" />
                </div>
            </div>
            <%} %>

            <hr />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
