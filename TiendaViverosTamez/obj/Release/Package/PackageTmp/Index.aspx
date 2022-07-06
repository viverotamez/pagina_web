<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TiendaViverosTamez.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <!-- ****** Área Descuentos ****** -->
    <section class="top-discount-area d-md-flex align-items-center">
        <div class="single-discount-area">
            <h5>Envíos y devoluciones gratis</h5>
            <h6><a href="#">COMPRAR</a></h6>
        </div>
        <div class="single-discount-area">
            <h5>10% Descuento en orquídeas y tulipanes</h5>
            <h6>USAR CUPÓN: FlowerTamez</h6>
        </div>
        <div class="single-discount-area">
            <h5>20% Descuento macetas colgantes</h5>
            <h6>USAR CUPÓN: FlowerTamez</h6>
        </div>
    </section>

    <!-- ****** Welcome Slides Area Start ****** -->
    <section class="welcome_area">
        <div class="welcome_slides owl-carousel">
            <!-- Single Slide Start -->
            <div class="single_slide height-800 bg-img background-overlay" style="background-image: url(img/image-01.jpeg);">
                <div class="container h-100">
                    <div class="row h-100 align-items-center">
                        <div class="col-12">
                            <div class="welcome_slide_text">
                                <h6 data-animation="bounceInDown" data-delay="0" data-duration="500ms">* Horario de 9:00 a 19:00 horas</h6>
                                <h2 data-animation="fadeInUp" data-delay="500ms" data-duration="500ms">Variedad de flores</h2>
                                <a href="#" class="btn karl-btn" data-animation="fadeInUp" data-delay="1s" data-duration="500ms">Checar variedad</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Single Slide Start -->
            <div class="single_slide height-800 bg-img background-overlay" style="background-image: url(img/image-02.jpeg);">
                <div class="container h-100">
                    <div class="row h-100 align-items-center">
                        <div class="col-12">
                            <div class="welcome_slide_text">
                                <h6 data-animation="fadeInDown" data-delay="0" data-duration="500ms">* Horario de 9:00 a 19:00 horas</h6>
                                <h2 data-animation="fadeInUp" data-delay="500ms" data-duration="500ms">Coronas de Cristo</h2>
                                <a href="#" class="btn karl-btn" data-animation="fadeInLeftBig" data-delay="1s" data-duration="500ms">Mira nuestra colección</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div> 

            <!-- Single Slide Start -->
            <div class="single_slide height-800 bg-img background-overlay" style="background-image: url(img/image-03.jpeg);">
                <div class="container h-100">
                    <div class="row h-100 align-items-center">
                        <div class="col-12">
                            <div class="welcome_slide_text">
                                <h6 data-animation="fadeInDown" data-delay="0" data-duration="500ms">* Horario de 9:00 a 19:00 horas</h6>
                                <h2 data-animation="bounceInDown" data-delay="500ms" data-duration="500ms">Macetas a tu gusto</h2>
                                <a href="#" class="btn karl-btn" data-animation="fadeInRightBig" data-delay="1s" data-duration="500ms">Checar variedad</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
