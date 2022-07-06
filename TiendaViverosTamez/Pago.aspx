<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="TiendaViverosTamez.Pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
        
        <div class="row">
            <div class="col-12">
                <div class="section_heading text-center">
                    <h2>Confirmar compra</h2>
                </div>
            </div>
        </div>

        <div class="row">

            <div class="col-6">
                
                <!--DOMICILIO-->
                <asp:Panel ID="panel_domicilio" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h5>Domicilio de envío</h5>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="col-md-12">Nombre y apellido</label>
                                <div class="col-md-12">
                                    <input type="text" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-6">
                                        <label class="col-md-12">Estado</label>
                                        <div class="col-md-12">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <label class="col-md-12">Municipio</label>
                                        <div class="col-md-12">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-12">Colonia</label>
                                <div class="col-md-12">
                                    <input type="text" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-6">
                                        <label class="col-md-12">Calle</label>
                                        <div class="col-md-12">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <label class="col-md-12">Número</label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txt_num" runat="server" CssClass="form-control" TextMode="Number" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-12">Teléfono de contacto</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txt_telfono" runat="server" CssClass="form-control" TextMode="Number" MaxLength="10" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer text-right">
                            <asp:Button ID="btnContinuarCompra" runat="server" Text="Continuar" CssClass="btn btn-success" OnClick="btnContinuarCompra_Click" />
                        </div>
                    </div>
                </asp:Panel>

                <!--TARJETA-->
                <asp:Panel ID="panel_tarjeta" runat="server" Visible="false">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h5>Medio de pago</h5>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="col-md-12">Número de tarjeta</label>
                                <div class="col-md-12">
                                    <asp:TextBox ID="txt_tarjeta" runat="server" CssClass="form-control" TextMode="Number" onKeyDown="if(this.value.length==16 && event.keyCode!=8) return false;" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-12">Nombre y apellido</label>
                                <div class="col-md-12">
                                    <input type="text" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-6">
                                        <label class="col-md-12">Fecha de vencimiento</label>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <select name="mes" class="form-control">
                                                        <option value="1">01</option>
                                                        <option value="2">02</option>
                                                        <option value="3">03</option>
                                                        <option value="4">04</option>
                                                        <option value="5">05</option>
                                                        <option value="6">06</option>
                                                        <option value="7">07</option>
                                                        <option value="8">08</option>
                                                        <option value="9">09</option>
                                                        <option value="10">10</option>
                                                        <option value="11">11</option>
                                                        <option value="12">12</option>
                                                    </select>
                                                </div>
                                                <div class="col-md-6">
                                                    <select name="anio" class="form-control">
                                                        <option value="1">2021</option>
                                                        <option value="2">2022</option>
                                                        <option value="3">2023</option>
                                                        <option value="4">2024</option>
                                                        <option value="5">2025</option>
                                                        <option value="6">2026</option>
                                                        <option value="7">2027</option>
                                                        <option value="8">2028</option>
                                                        <option value="9">2029</option>
                                                        <option value="10">2023</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <label class="col-md-12">Código de seguridad</label>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txt_cvv" runat="server" CssClass="form-control" TextMode="Number" onKeyDown="if(this.value.length==3 && event.keyCode!=8) return false;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer text-right">
                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
                            <asp:Button ID="btnContinarPago" runat="server" Text="Continuar" CssClass="btn btn-success" OnClick="btnContinarPago_Click" />
                        </div>
                    </div>
                </asp:Panel>

            </div>

            <!--TOTAL A PAGAR-->
            <div class="col-6">
                <div class="panel panel-default">
                    <div class="panel-heading"><h5>Total a pagar</h5></div>
                    <div class="panel-body">
                        <div class="form-group text-center">
                            <label class="col-md-12">&nbsp;</label>
                            <div class="col-md-12">
                                <h1>$ <asp:Label ID="lbl_total" runat="server" /></h1>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>