<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TiendaViverosTamez.Registro" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_heading text-center">
                        <h2>Registra tus datos</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-4 offset-4">
                    <div class="form-group">
                        <label class="col-sm-12">Nombre completo</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12">Correo electrónico</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txt_correo" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12">Usuario</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txt_usuario" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12">Contraseña</label>
                        <div class="col-md-12">
                            <asp:TextBox ID="txt_password" runat="server" CssClass="form-control"  TextMode="Password" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12">&nbsp;</label>
                        <div class="col-md-12">
                            <a href="<%= ResolveClientUrl("~/administrador/Administrador.aspx") %>" class="btn btn-warning"><i class="fa fa-arrow-left"></i>&nbsp;Regresar</a>
                            <asp:Button ID="btnRegistro" runat="server" Text="Registrarme" CssClass="btn btn-success" OnClick="btnRegistro_Click" />
                        </div>
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