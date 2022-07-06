<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaViverosTamez.Login" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
        
        <div class="row">
            <div class="col-12">
                <div class="section_heading text-center">
                    <h2>Iniciar Sesión</h2>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-4 offset-4 text-center">
                <div class="form-group">
                    <asp:TextBox ID="txt_user" runat="server" CssClass="form-control" placeholder="usuario" />
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txt_pass" runat="server" TextMode="Password" CssClass="form-control" placeholder="contraseña" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btn_login" runat="server" CssClass="btn btn-success" Text="Iniciar sesión" OnClick="btn_login_Click" />
                </div>
                <asp:Panel ID="panel_error" runat="server">
                    <div class="form-group">
                        <div class="alert alert-danger" role="alert">
                            <asp:Label ID="mensaje_error" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>

    </div>

</asp:Content>