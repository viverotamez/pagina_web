<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TiendaViverosTamez.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function EnviarContacto() {
            MensajeCorrecto('Hemos enviado tu pregunta te responderemos a la brevedad por los medios de contacto.');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-12">
                <div class="section_heading text-center">
                    <h2>Contacto</h2>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-8 offset-2">
                <div class="form-group">
                    <label class="col-sm-12">Motivo de contacto</label>
                    <div class="col-md-12">
                        <asp:DropDownList ID="ddl_motivo" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Selected="True">SELECCIONA</asp:ListItem>
                            <asp:ListItem Value="1">Preguntar sobre existencia de productos</asp:ListItem>
                            <asp:ListItem Value="2">Cotización</asp:ListItem>
                            <asp:ListItem Value="3">Cotización de productos al mayoreo</asp:ListItem>
                            <asp:ListItem Value="4">Otra pregunta</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-12">Pregunta</label>
                    <div class="col-md-12">
                        <asp:TextBox ID="txt_pregunta" runat="server" CssClass="form-control" TextMode="MultiLine" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-12">Nombre</label>
                    <div class="col-md-12">
                        <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-12">Dirección</label>
                    <div class="col-md-12">
                        <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-12">Teléfono de contacto</label>
                    <div class="col-md-12">
                        <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-12">Correo electrónico</label>
                    <div class="col-md-12">
                        <asp:TextBox ID="txt_correo" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:Button ID="EnviarContacto" runat="server" Text="Enviar" CssClass="btn btn-success" OnClick="EnviarContacto_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
