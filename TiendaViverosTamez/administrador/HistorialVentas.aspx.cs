using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class HistorialVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    CargarHistorial();
                }
                else
                {
                    Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                }
            }
        }

        public void CargarHistorial()
        {
            List<ventas> datos = consultas.ConsultaVentas();
            this.grid_historial.DataSource = datos;
            this.grid_historial.DataBind();
        }

        public void CargarVentasDetalle(int id_usuario, int num_carrito)
        {
            List<inventario> datos = consultas.ConsultaVentasDetalle(id_usuario, num_carrito);
            this.grid_historial_detalle.DataSource = datos;
            this.grid_historial_detalle.DataBind();
        }

        protected void grid_historial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row_index = int.Parse((e.CommandArgument).ToString());
            int id_usuario = int.Parse(this.grid_historial.DataKeys[row_index]["id_usuario"].ToString());
            int num_carrito = int.Parse(this.grid_historial.DataKeys[row_index]["num_carrito"].ToString());

            if (e.CommandName == "Detalle")
            {
                CargarVentasDetalle(id_usuario, num_carrito);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Ventana", "$(document).ready(function() { $('#ModalDetalle').modal('show'); });", true);
            }
        }

    }
}