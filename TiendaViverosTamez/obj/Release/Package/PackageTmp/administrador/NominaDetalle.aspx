<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NominaDetalle.aspx.cs" Inherits="TiendaViverosTamez.administrador.NominaDetalle" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
            
        <div class="row">
            <div class="col-12">
                <div class="card">
				    <div class="card-header" style="background-color:#28a745;">
				        <h3 style="color:#ffff;">Detalle de la nómina:&nbsp;<asp:Label id="titulo_nomina" runat="server" /></h3>
				    </div>
				    <div class="card-body">
                        <div class="form-group col-12">
                            <asp:GridView ID="grid_nomina_personal" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="id_personal">
                                <Columns>
                                    <asp:BoundField DataField="num_empleado" HeaderText="Número de empleado"></asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre"></asp:BoundField>
                                    <asp:BoundField DataField="app_paterno" HeaderText="Apellido paterno"></asp:BoundField>
                                    <asp:BoundField DataField="app_materno" HeaderText="Apellido materno"></asp:BoundField>
                                    <asp:BoundField DataField="puesto" HeaderText="Puesto"></asp:BoundField>
                                    <asp:BoundField DataField="categoria" HeaderText="Categoría"></asp:BoundField>
                                    <asp:BoundField DataField="sueldo" HeaderText="Sueldo"></asp:BoundField>
                                    <asp:BoundField DataField="descuento" HeaderText="Descuentos"></asp:BoundField>
                                    <asp:BoundField DataField="total" HeaderText="Total a pagar"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="card-footer">
                        <a href="<%= ResolveClientUrl("~/administrador/Nomina.aspx") %>" class="btn btn-warning"><i class="fa fa-arrow-left"></i>&nbsp;Regresar</a>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>