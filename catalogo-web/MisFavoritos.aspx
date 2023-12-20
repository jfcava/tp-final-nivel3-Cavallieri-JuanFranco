<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="catalogo_web.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-top: 12px">Mis Favoritos</h1>
    <hr />
    <div class="row">
        <asp:Repeater ID="repFavoritos" runat="server">
            <ItemTemplate>
                <div class="col-lg-3 col-sm-6 col-md-4" style="margin-top:20px">
                    <div class="card h-100">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/310px-Placeholder_view_vector.svg.png" style="height:300px; object-fit:contain">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <asp:Button Text="Ver Detalle" ID="Button1" runat="server" CssClass="btn btn-primary" CommandArgument='<%#Eval("Id")%>' CommandName="ArtId" />
                            <%if (negocio.Seguridad.sesionActiva(Session["usuario"]))
                                {  %>
                            <asp:Button Text="Quitar" ID="btnQuitarFavorito" runat="server" CssClass="btn btn-secondary" CommandArgument='<%#Eval("Id")%>' CommandName="ArtId" OnClick="btnQuitarFavorito_Click" />
                            <%} %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
