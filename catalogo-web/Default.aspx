﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="catalogo_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-top: 12px">Bienvenidxs!</h1>
    <h5>Te presentamos los nuevos artículos que tenemos para vos!</h5>
    <hr />
    <div class="row">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col-lg-3 col-sm-6 col-md-4" style="margin-top: 20px">
                    <div class="card h-100">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="..." style="height: 300px; object-fit: contain">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <asp:Button Text="Ver Detalle" ID="btnVerDetalle" runat="server" CssClass="btn btn-primary" OnClick="btnVerDetalle_Click" CommandArgument='<%#Eval("Id")%>' CommandName="ArtId" />
                            <% if (negocio.Seguridad.sesionActiva(Session["usuario"]))
                                { %>
                            <%--<asp:Button Text="Favorito" ID="btnAgregarFavorito" runat="server" CssClass="btn btn-secondary"
                                CommandArgument='<%#Eval("Id")%>' CommandName="ArtId"
                                OnClick="btnAgregarFavorito_Click" Visible='<%# MostrarBotonFavorito(Eval("Id")) %>'>
                            <i class="bi-alarm"></i></asp:Button>--%>

                            <asp:LinkButton ID="btnAgregarFavorito" runat="server" CssClass="btn btn-secondary"
                                CommandArgument='<%# Eval("Id") %>' CommandName="ArtId"
                                OnClick="btnAgregarFavorito_Click" Visible='<%# MostrarBotonFavorito(Eval("Id")) %>'>
                            <i class="bi bi-star" style="margin-bottom:20px;"></i> Favorito
                            </asp:LinkButton>


                            <% }%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
