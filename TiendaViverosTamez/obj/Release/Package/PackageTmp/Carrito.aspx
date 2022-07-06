<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TiendaViverosTamez.Carrito" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .disponibles {
            font-weight: bold;
            font-size: 12px;
        }
    </style>
    <script type="text/javascript">
        function ActualizaProducto(id) {
            $("#hf_id_producto").val(id);
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                url: "<%= ResolveClientUrl("~/Carrito.aspx") %>/SeleccionaProducto",
                data: "{id: " + id + "}",
                success: function (response) {
                    if (response != null && response.d != null) {
                        var data = response.d;
                        data = $.parseJSON(data);
                        $("#lbl_titulo_detalle").text(data.descripcion);
                        $("#lbl_precio_detalle").text(data.precio);
                        $("#img_detalle").attr("src", "img/" + data.url_imagen);
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <section class="new_arrivals_area section_padding clearfix">
        
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_heading text-center">
                        <h2>Productos</h2>
                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hf_id_producto" runat="server" ClientIDMode="Static" />

        <asp:Repeater ID="rptrArticulos" runat="server">
            <HeaderTemplate>
                <div class="container">
                <div class="row karl-new-arrivals">
            </HeaderTemplate>
            <ItemTemplate>
                <!-- Artículo 1 -->
                <div class="col-12 col-sm-6 col-md-4 single_gallery_item">
                    <!-- Imgen -->
                    <div class="product-img">
                        <img src="img/<%# Eval("url_imagen") %>" alt="" />
                        <div class="product-quicview">
                            <a href="#" data-toggle="modal" data-target="#mProducto" onclick="ActualizaProducto(<%# Eval("id_producto") %>);"><i class="ti-plus"></i></a>
                        </div>
                    </div>
                    <!-- Descripción -->
                    <div class="product-description">
                        <h4 class="product-price">$<span><%# Eval("precio") %></span></h4>
                        <p><span><%# Eval("descripcion") %></span></p>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>

    </section>

    <!-- ****** Modal Detalle ****** -->
    <div class="modal fade" id="mProducto" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="quickview_body">
                        <div class="container">
                            <div class="row">
                                <div class="col-12 text-right">
                                    <button type="button" class="close btn" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12 col-lg-5">
                                    <div class="quickview_pro_img">
                                        <img id="img_detalle" alt="" />
                                    </div>
                                </div>
                                <div class="col-12 col-lg-7">
                                    <div class="quickview_pro_des">
                                        <h4 class="title"><label id="lbl_titulo_detalle" /></h4>
                                        <h5>$<label id="lbl_precio_detalle" /></h5>
                                    </div>
                                    <div class="cart">
                                        <asp:Panel ID="pnl_sin_registro" runat="server">
                                            <div class="quantity">
                                                <span class="text-danger">Para comprar nuestros productos, regístrate e inicia sesión.</span>
                                            </div>
                                        </asp:Panel>
                                        <div class="quantity">
                                            <asp:TextBox ID="txt_total" runat="server" TextMode="Number" CssClass="qty-text" Text="1" />
                                        </div>
                                        <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="cart-submit" OnClick="btnAgregarCarrito_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
