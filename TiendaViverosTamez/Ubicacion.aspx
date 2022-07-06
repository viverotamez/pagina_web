<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Ubicacion.aspx.cs" Inherits="TiendaViverosTamez.Ubicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function iniciar() {
            var elemento = document.getElementById("obtener");
            elemento.addEventListener("click", obtenerubicacion());
        }
        function obtenerubicacion() {
            var geoconfig = {
                enableHighAccuracy: true,
                timeout: 10000,
                maximumAge: 60000
            };
            navigator.geolocation.getCurrentPosition(mostrar, mostrarerror, geoconfig);
        }
        function mostrar(posicion) {
            var ubicacion = document.getElementById("ubicacion");
            var info = document.getElementById("ubicacioninfo");
            var datos = "";
            datos += "Latitud: " + posicion.coords.latitude + "<br>";
            datos += "Longitud: " + posicion.coords.longitude + "<br>";
            datos += "Exactitud: " + posicion.coords.accuracy + " mts.<br>";
            //Esta es la url original que venia en el documento, pero la cambie por que no funcionaba, ya que faltaba la llave (key) para accesar a la api de google maps y encontre que era "googleapis" y no "maps.google"
            var mapurl = "https://maps.googleapis.com/maps/api/staticmap?center=25.185299,-99.840418&zoom=12&size=600x400&markers=25.185299,-99.840418&key=AIzaSyARPtp84pc8aon0WP5zUtrzhR99jvEkRZo";
            //Aqui muestra la informacion de la latitud, longitud y exactitud
            info.innerHTML = datos;
            //
            ubicacion.innerHTML = '<img src="' + mapurl + '" />';
        }
        function mostrarerror(error) {
            alert("Error: " + error.code + " " + error.message);
        }
        window.addEventListener("load", iniciar);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-12">
                <div class="section_heading text-center">
                    <h2>Localización</h2>
                </div>
            </div>
        </div>
        <!--API-->
        <div class="row">
            <div class="col-12">
                <div class="row text-center">
                    <div class="col-12">
                        <section id="ubicacioninfo"></section>
                        <section id="ubicacion">
                            <button type="button" id="obtener" class="btn btn-primary">Obtener mi ubicacion</button>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>