<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Descuentos.aspx.cs" Inherits="TiendaViverosTamez.administrador.Descuentos" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">

        <div class="row">
            <div class="col-12">
                <div class="card">
				    <div class="card-header" style="background-color:#28a745;">
				        <h3 style="color:#ffff;">Descuentos</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group row">
						    <label class="col-sm-2 col-form-label">Empleado</label>
					        <div class="col-sm-10">
					            <asp:DropDownList ID="ddl_empleado" runat="server" CssClass="form-control" />
					        </div>
					    </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Clasificación del descuento</label>
					        <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_clasificacion" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Descripción</label>
					        <div class="col-sm-10">
                                <asp:TextBox ID="txt_desc" runat="server" CssClass="form-control" TextMode="MultiLine" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Cantidad</label>
					        <div class="col-sm-2">
                                <asp:TextBox ID="txt_cantidad" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Año</label>
					        <div class="col-sm-2">
                                <asp:DropDownList ID="ddl_anio" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Quincena</label>
					        <div class="col-sm-2">
                                <asp:DropDownList ID="ddl_quincena" runat="server" CssClass="form-control" />
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
                    <div class="card-footer">
                        <a href="<%= ResolveClientUrl("~/administrador/Administrador.aspx") %>" class="btn btn-warning"><i class="fa fa-arrow-left"></i>&nbsp;Regresar</a>
                        <asp:Button ID="btn_guardar" runat="server" CssClass="btn btn-success" Text="Agregar descuento" OnClick="btn_guardar_Click" />
                        <asp:Button ID="btn_modificar" runat="server" CssClass="btn btn-success" Text="Modificar descuento" OnClick="btn_modificar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-12">
                <div class="card">
				    <div class="card-header" style="background-color:#007bff;">
				        <h3 style="color:#ffff;">Descuentos capturados</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group col-12">
						    <asp:GridView ID="grid_descuentos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="id_descuento" OnRowCommand="grid_descuentos_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="nombre_completo" HeaderText="Empleado"></asp:BoundField>
                                    <asp:BoundField DataField="txt_clasificacion_descuento" HeaderText="Clasificación del descuento"></asp:BoundField>
                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad"></asp:BoundField>
                                    <asp:BoundField DataField="anio" HeaderText="Año"></asp:BoundField>
                                    <asp:BoundField DataField="quincena" HeaderText="Quincena"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btn_editar" runat="server" CommandName="Editar" CommandArgument='<%#Container.DataItemIndex %>'>
                                                <i class="fa fa-edit" style="font-size:18pt; color:darkgreen"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btn_eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Container.DataItemIndex %>' OnClientClick="return MensajeConfirmar(this, '¿Está seguro de eliminar el descuento?');">
                                                <i class="fa fa-times" style="font-size:18pt; color:red"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
					    </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>