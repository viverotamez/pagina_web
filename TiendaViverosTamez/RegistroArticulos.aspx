<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroArticulos.aspx.cs" Inherits="TiendaViverosTamez.RegistroArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/indexed.css" rel="stylesheet" />
    <script src="js/indexed.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container text-center">
        <!--TITULO-->
        <div class="row">
            <div class="col-12">
                <div class="section_heading text-center">
                    <h2>Registro de artículos</h2>
                </div>
            </div>
        </div>
        <!--API GUARDAR-->
        <div class="row">
            <div class="col-12">
                <section id="cajaformulario">
                    <div id="formulario-guardar">
                        <label for="texto">Clave:</label><br />
                        <input type="text" name="texto" id="fecha" /><br />
                        <label for="clave">Descripción planta:</label><br />
                        <input type="text" name="clave" id="clave" /><br />
                        <label for="fecha">Cantidad:</label><br />
                        <input type="text" name="fecha" id="titulo" /><br />
                        <br />
                        <button type="button" id="grabar" class="btn btn-success">Grabar</button>
                    </div>
                </section>
                <section id="cajadatos">
                    <p>Información no disponible.</p>
                </section>
            </div>
        </div>
        <br />
        <!--API BUSCAR-->
        <div class="row">
            <div class="col-12">
                <section id="cajaformulario-buscar">
                    <div id="formulario-buscar">
                        <label for="fecha-buscar">Buscar planta por clave:</label><br />
                        <input type="text" name="fecha-buscar" id="clave-buscar" /><br />
                        <br />
                        <button type="button" id="buscar" class="btn btn-primary">Buscar</button>
                    </div>
                </section>
                <section id="cajadatos-buscar">
                    <p>Información no disponible.</p>
                </section>
            </div>
        </div>
    </div>

</asp:Content>