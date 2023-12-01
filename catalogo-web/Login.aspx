<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="catalogo_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-4">
        <h1 style="margin-top:12px">Login</h1>
        <hr />
        <div class="mb-3">
            <label class="form-label">E-Mail</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="password" />
        </div>
        <asp:Button runat="server" Text="Ingresar" CssClass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
