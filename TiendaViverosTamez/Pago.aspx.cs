using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Limpiar();
            }
        }

        private void Limpiar()
        {
            inventario i = new inventario();
            
            int id_usuario = int.Parse(Session["id_usuario"].ToString());
            i = consultas.ConsultaUltimoCarrito(id_usuario);

            this.lbl_total.Text = consultas.TotalCarrito(id_usuario, i.num_carrito).ToString();
            this.panel_domicilio.Visible = true;
            this.panel_tarjeta.Visible = false;

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnContinuarCompra_Click(object sender, EventArgs e)
        {
            this.panel_domicilio.Visible = false;
            this.panel_tarjeta.Visible = true;
            
        }

        protected void btnContinarPago_Click(object sender, EventArgs e)
        {
            int id_usuario = int.Parse(Session["id_usuario"].ToString());
            List<inventario> datos = consultas.BuscarInventario(id_usuario, 0, true);
            consultas.ConfirmarPago(datos);
            HttpContext.Current.Session["compra"] = true;
            Response.Redirect("Index.aspx");
        }

    }
}