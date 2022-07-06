<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="TiendaViverosTamez.administrador.Administrador" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
            
        <div class="row">
            <div class="col-12">
                <div class="section_heading text-center">
                    <h2>Administrador</h2>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-12 text-center">
                <a href="<%= ResolveClientUrl("~/administrador/NuevoUsuario.aspx") %>" class="btn btn-primary"><i class="fa fa-plus"></i>&nbsp;Agregar administrador</a>
                <a href="<%= ResolveClientUrl("~/administrador/NuevoPersonal.aspx") %>" class="btn btn-primary"><i class="fa fa-plus"></i>&nbsp;Agregar personal</a>
                <a href="<%= ResolveClientUrl("~/administrador/NuevoProveedor.aspx") %>" class="btn btn-primary"><i class="fa fa-plus"></i>&nbsp;Agregar proveedor</a>
                <a href="<%= ResolveClientUrl("~/administrador/NuevoCliente.aspx") %>" class="btn btn-primary"><i class="fa fa-plus"></i>&nbsp;Agregar cliente</a>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12 text-center">
                <a href="<%= ResolveClientUrl("~/administrador/Descuentos.aspx") %>" class="btn btn-info"><i class="fa fa-pencil-square-o"></i>&nbsp;Registrar descuento</a>
                <a href="<%= ResolveClientUrl("~/administrador/Nomina.aspx") %>" class="btn btn-info"><i class="fa fa-credit-card"></i>&nbsp;Nómina</a>
                <a href="<%= ResolveClientUrl("~/administrador/CarritoClientes.aspx") %>" class="btn btn-info"><i class="ti-shopping-cart"></i>&nbsp;Carrito de clientes</a>
                <a href="<%= ResolveClientUrl("~/administrador/HistorialVentas.aspx") %>" class="btn btn-info"><i class="fa fa-money"></i>&nbsp;Historial de ventas</a>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-12">
                
                <!--ADMINISTRADORES-->
                <div class="card">
				    <div class="card-header" style="background-color:#007bff;">
				        <h3 style="color:#ffff;">Administradores</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group col-12">
						    <asp:GridView ID="grid_usuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="id_usuario" OnRowCommand="grid_usuarios_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="usuario" HeaderText="Usuario"></asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre"></asp:BoundField>
                                    <asp:BoundField DataField="correo" HeaderText="Correo electrónico"></asp:BoundField>
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
                                            <asp:LinkButton ID="btn_eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Container.DataItemIndex %>' OnClientClick="return MensajeConfirmar(this, '¿Está seguro de eliminar el usuario?');">
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
                
                <!--PERSONAL / EMPLEADOS-->
                <div class="card">
				    <div class="card-header" style="background-color:#007bff;">
				        <h3 style="color:#ffff;">Personal</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group col-12">
                            <asp:GridView ID="grid_personal" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="id_personal" OnRowCommand="grid_personal_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="num_empleado" HeaderText="Número de empleado"></asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre"></asp:BoundField>
                                    <asp:BoundField DataField="app_paterno" HeaderText="Apellido paterno"></asp:BoundField>
                                    <asp:BoundField DataField="app_materno" HeaderText="Apellido materno"></asp:BoundField>
                                    <asp:BoundField DataField="puesto" HeaderText="Puesto"></asp:BoundField>
                                    <asp:BoundField DataField="categoria" HeaderText="Categoría"></asp:BoundField>
                                    <asp:BoundField DataField="sueldo" HeaderText="Sueldo"></asp:BoundField>
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
                                            <asp:LinkButton ID="btn_eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Container.DataItemIndex %>' OnClientClick="return MensajeConfirmar(this, '¿Está seguro de eliminar el empleado?');">
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

                <!--PROVEEDORES-->
                <div class="card">
				    <div class="card-header" style="background-color:#007bff;">
				        <h3 style="color:#ffff;">Proveedores</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group col-12">
                            <asp:GridView ID="grid_proveedores" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="id_proveedor" OnRowCommand="grid_proveedores_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre"></asp:BoundField>
                                    <asp:BoundField DataField="rfc" HeaderText="RFC"></asp:BoundField>
                                    <asp:BoundField DataField="status" HeaderText="Estatus"></asp:BoundField>
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
                                            <asp:LinkButton ID="btn_eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Container.DataItemIndex %>' OnClientClick="return MensajeConfirmar(this, '¿Está seguro de eliminar el proveedor?');">
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

                <!--CLIENTES-->
                <div class="card">
				    <div class="card-header" style="background-color:#007bff;">
				        <h3 style="color:#ffff;">Clientes</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group col-12">
                            <asp:GridView ID="grid_clientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="id_cliente" OnRowCommand="grid_clientes_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre"></asp:BoundField>
                                    <asp:BoundField DataField="app_paterno" HeaderText="Apellido paterno"></asp:BoundField>
                                    <asp:BoundField DataField="app_materno" HeaderText="Apellido materno"></asp:BoundField>
                                    <asp:BoundField DataField="rfc" HeaderText="RFC"></asp:BoundField>
                                    <asp:BoundField DataField="status" HeaderText="Estatus"></asp:BoundField>
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
                                            <asp:LinkButton ID="btn_eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Container.DataItemIndex %>' OnClientClick="return MensajeConfirmar(this, '¿Está seguro de eliminar el cliente?');">
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
