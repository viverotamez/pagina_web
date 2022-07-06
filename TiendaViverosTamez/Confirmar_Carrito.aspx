<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Confirmar_Carrito.aspx.cs" Inherits="TiendaViverosTamez.Confirmar_Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-12">
                <div class="section_heading text-center">
                    <h2>Carrito de compras</h2>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <div class="form-group">
                    <!--Tabla-->
                    <asp:GridView ID="tabla_carrito" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="descripcion" HeaderText="Producto" />
                            <asp:BoundField DataField="num_inventario" HeaderText="Cantidad" />
                            <asp:BoundField DataField="precio" HeaderText="Precio del producto" />
                            <asp:BoundField DataField="total" HeaderText="Subtotal" />
                        </Columns>
                    </asp:GridView>
                    <div class="text-center">
                        <asp:Label ID="lbl_grid" runat="server" CssClass="text-info" />
                    </div>
                </div>
                <div class="form-group text-center">
                    <label class="col-sm-12">&nbsp;</label>
                    <div class="col-md-12">
                        <asp:Button ID="btnConfirmar" runat="server" Text="Continuar con la compra" CssClass="btn btn-success" OnClick="btnConfirmar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>