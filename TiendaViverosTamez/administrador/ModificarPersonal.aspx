<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificarPersonal.aspx.cs" Inherits="TiendaViverosTamez.administrador.ModificarPersonal" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
            
        <div class="row">
            <div class="col-12">
                <div class="card">
				    <div class="card-header" style="background-color:#28a745;">
				        <h3 style="color:#ffff;">Modificar datos del empleado</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Número de empleado</label>
					        <div class="col-sm-2">
                                <asp:TextBox ID="txt_NoEmpleado" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Nombre</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Apellido paterno</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_paterno" runat="server" CssClass="form-control" />    
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Apellido materno</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_materno" runat="server" CssClass="form-control" />    
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Correo electrónico</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_correo" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Fecha de nacimiento</label>
					        <div class="col-sm-2">
                                <asp:TextBox ID="fecha_nac" runat="server" CssClass="form-control datepicker" autocomplete="off" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Dirección</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Título Profesional</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txt_titulo" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Puesto</label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="ddl_puesto" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Categoría</label>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="ddl_categoria" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Sueldo</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txt_sueldo" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Fecha de ingreso</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="fecha_ingreso" runat="server" CssClass="form-control datepicker" autocomplete="off" />
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
