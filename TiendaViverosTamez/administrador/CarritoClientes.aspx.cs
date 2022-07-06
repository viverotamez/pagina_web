using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class CarritoClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    CargarCarrito();
                }
                else
                {
                    Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                }
            }
        }

        public void CargarCarrito()
        {
            List<inventario> datos = consultas.CarritosActivos();
            this.grid_carrito_clientes.DataSource = datos;
            this.grid_carrito_clientes.DataBind();
        }

        public void CargarCarritoDetalle(int id_usuario, int num_carrito)
        {
            List<inventario> datos = consultas.BuscarInventario(id_usuario, num_carrito, false);
            this.grid_carrito_detalle.DataSource = datos;
            this.grid_carrito_detalle.DataBind();
        }

        protected void grid_carrito_clientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView grid = (GridView)sender;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id_status = int.Parse(grid.DataKeys[e.Row.RowIndex].Values["id_status"].ToString());
                string status = grid.DataKeys[e.Row.RowIndex].Values["status"].ToString();
                
                Literal tipoStatus = (Literal)e.Row.FindControl("tipoStatus");
                LinkButton btnCancelar = (LinkButton)e.Row.FindControl("btn_cancelar");
                btnCancelar.Visible = false;

                if (id_status == 1)
                {
                    tipoStatus.Text = "<span class='badge badge-primary'>" + status + "</span>";
                    btnCancelar.Visible = true;
                }
                else if (id_status == 3)
                {
                    tipoStatus.Text = "<span class='badge badge-danger'>" + status + "</span>";
                }
            }
        }

        protected void grid_carrito_clientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row_index = int.Parse((e.CommandArgument).ToString());
            int id_usuario = int.Parse(this.grid_carrito_clientes.DataKeys[row_index]["id_usuario"].ToString());
            int num_carrito = int.Parse(this.grid_carrito_clientes.DataKeys[row_index]["num_carrito"].ToString());

            if (e.CommandName == "Detalle")
            {
                CargarCarritoDetalle(id_usuario, num_carrito);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Ventana", "$(document).ready(function() { $('#ModalDetalle').modal('show'); });", true);
            }
            else if (e.CommandName == "Cancelar")
            {
                bool valida = consultas.CancelarCarrito(id_usuario);

                if (valida)
                {
                    CargarCarrito();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeCorrecto('El carrito se ha cancelado con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeError('Hubo un error al cancelar el carrito');", true);
                }
            }
        }
    }
}