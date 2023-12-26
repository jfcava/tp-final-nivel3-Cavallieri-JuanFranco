<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="catalogo_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{
            color: red;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-4">
        <h1 style="margin-top:12px">Registro de Usuario</h1>
        <hr />
        <div class="mb-3">
            <label class="form-label">E-Mail</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            <asp:RequiredFieldValidator ErrorMessage="Debes completar este campo" ControlToValidate="txtEmail" runat="server" CssClass="validacion" />
            <asp:RegularExpressionValidator ErrorMessage="Debes ingresar un e-mail" ControlToValidate="txtEmail" runat="server" CssClass="validacion" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" />
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
        </div>
        <asp:Button Text="Registrarse" runat="server" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" />
        <a href="./">Cancelar</a>
    </div>
</asp:Content>
