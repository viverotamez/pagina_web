<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="HistorialVentas.aspx.cs" Inherits="TiendaViverosTamez.administrador.HistorialVentas" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
            
        <div class="row">
            <div class="col-12">
                <div class="card">
				    <div class="card-header" style="background-color:#28a745;">
				        <h3 style="color:#ffff;">Historial de ventas realizadas</h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group col-12">
                            <asp:GridView ID="grid_historial" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" DataKeyNames="id_usuario,num_carrito" OnRowCommand="grid_historial_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="num_carrito" HeaderText="Número de carrito" />
                                    <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                                    <asp:BoundField DataField="nombre_usuario" HeaderText="Nombre del usuario" />
                                    <asp:BoundField DataField="total" HeaderText="Total pagado" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btn_detalle" runat="server" CssClass="btn btn-info btn-sm" CommandName="Detalle" CommandArgument='<%#Container.DataItemIndex %>'>
                                                <i class="fa fa-info-circle"></i>&nbsp;Ver detalle
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="card-footer">
                        <a href="<%= ResolveClientUrl("~/administrador/Administrador.aspx") %>" class="btn btn-warning"><i class="fa fa-arrow-left"></i>&nbsp;Regresar</a>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- MODAL DETALLE -->
    <div class="modal fade" id="ModalDetalle">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background-color:#1e88e5;">
                    <h4 class="modal-title" style="color:#fff;">Detalle de los productos vendidos</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <asp:GridView ID="grid_historial_detalle" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="descripcion" HeaderText="Producto" />
                                        <asp:BoundField DataField="num_inventario" HeaderText="Cantidad" />
                                        <asp:BoundField DataField="precio" HeaderText="Precio del producto" />
                                        <asp:BoundField DataField="total" HeaderText="Subtotal" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="btnCerrar" runat="server" ForeColor="white" CssClass="btn btn-shadow btn-secondary" data-dismiss="modal">
                        <i class="fa fa-times"></i>&nbsp;&nbsp;Cerrar
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>