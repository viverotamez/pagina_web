<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="TiendaViverosTamez.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mensajeCotizacion {
            font-weight: bold;
            font-size: 12px;
        }
    </style>
    <script type="text/javascript">
        function EnviarCotizacion() {
            MensajeCorrecto('<p>¡Cotización enviada!</p><p class="mensajeCotizacion">Lo contactaremos por email o telefono dentro de los proximos 3 días habiles.</p>');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-12">
                <div class="section_heading text-center">
                    <h2>Solicita tu cotización:</h2>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <div class="row text-center">
                    <div class="col-6">
                        <button type="button" class="btn btn-success btn-lg" data-toggle="modal" data-target="#mCotizacion1">Instalación de pasto sintético</button>
                    </div>
                    <div class="col-6">
                        <button type="button" class="btn btn-success btn-lg" data-toggle="modal" data-target="#mCotizacion2">Diseño arquitectónico de jardín</button>
                    </div>
                </div>
            </div>
            <div class="col-12" style="margin-top:40px;margin-bottom: 40px">
                <div class="row text-center">
                    <div class="col-12">
                        <button type="button" class="btn btn-success btn-lg" data-toggle="modal" data-target="#mCotizacion3">Creación de área verde</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- ****** Modal Agregar 1 ****** -->
    <div class="modal fade" id="mCotizacion1" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="quickview_body">
                        <div class="container">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <label class="col-sm-12">Nombre</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_nombre1" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Dirección</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_direccion1" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Teléfono de contacto</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_telefono1" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Correo electrónico</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_correo1" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="EnviarCotizacion1" runat="server" Text="Enviar cotización" CssClass="btn btn-success" OnClick="EnviarCotizacion1_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- ****** Modal Agregar 2 ****** -->
    <div class="modal fade" id="mCotizacion2" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="quickview_body">
                        <div class="container">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <label class="col-sm-12">Nombre</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_nombre2" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Dirección</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_direccion2" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Teléfono de contacto</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_telefono2" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Correo electrónico</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_correo2" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="EnviarCotizacion2" runat="server" Text="Enviar cotización" CssClass="btn btn-success" OnClick="EnviarCotizacion2_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- ****** Modal Agregar 3 ****** -->
    <div class="modal fade" id="mCotizacion3" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="quickview_body">
                        <div class="container">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <label class="col-sm-12">Nombre</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_nombre3" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Dirección</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_direccion3" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Teléfono de contacto</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_telefono3" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-12">Correo electrónico</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_correo3" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="EnviarCotizacion3" runat="server" Text="Enviar cotización" CssClass="btn btn-success" OnClick="EnviarCotizacion3_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
