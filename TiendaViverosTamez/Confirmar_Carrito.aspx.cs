using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez
{
    public partial class Confirmar_Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarTabla();
            }
        }

        private void CargarTabla()
        {
            int id_usuario = int.Parse(Session["id_usuario"].ToString());
            List<inventario> datos = consultas.BuscarInventario(id_usuario, 0, true);
            this.tabla_carrito.DataSource = datos;
            this.tabla_carrito.DataBind();

            if (datos.Count > 0)
            {
                this.lbl_grid.Text = "";
                this.btnConfirmar.Visible = true;
            }
            else
            {
                this.lbl_grid.Text = "Tu carrito está vacío";
                this.btnConfirmar.Visible = false;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pago.aspx");
        }

    }
}