<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificarProveedor.aspx.cs" Inherits="TiendaViverosTamez.administrador.ModificarProveedor" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
            
        <div class="row">
            <div class="col-12">
                <div class="card">
				    <div class="card-header" style="background-color:#28a745;">
				        <h3 style="color:#ffff;">Modificar proveedor</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Nombre</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">RFC</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_rfc" runat="server" CssClass="form-control" MaxLength="13" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Dirección</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Teléfono</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Estatus</label>
					        <div class="col-sm-10">
                                <asp:DropDownList ID="ddl_estatus" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Panel ID="panel_error" runat="server">
                                <div class="form-group">
                                    <div class="alert alert-danger" role="alert">
                                        <asp:Label ID="mensaje_error" runat="server" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="card-footer">
                        <a href="<%= ResolveClientUrl("~/administrador/Administrador.aspx") %>" class="btn btn-warning"><i class="fa fa-arrow-left"></i>&nbsp;Regresar</a>
                        <asp:Button ID="btn_guardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btn_guardar_Click" />
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>