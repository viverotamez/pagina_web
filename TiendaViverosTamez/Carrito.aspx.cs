using TiendaViverosTamez.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace TiendaViverosTamez
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarProductos();

                if (HttpContext.Current.Session["cliente"] != null)
                    HabilitarCarrito(true);
                else
                    HabilitarCarrito(false);
            }
        }

        public void HabilitarCarrito(bool activar)
        {
            this.btnAgregarCarrito.Visible = activar;
            this.txt_total.Visible = activar;
            this.pnl_sin_registro.Visible = activar == true ? false : true;
        }

        public void CargarProductos()
        {
            List<productos> datos = consultas.BuscarProductos();

            this.rptrArticulos.DataSource = datos;
            this.rptrArticulos.DataBind();
        }

        public int ConsultaInventario(int id_producto)
        {
            List<productos> datos = consultas.BuscarProductos();
            productos p = datos.Where(m => m.id_producto == id_producto).FirstOrDefault();
            return p.actual_inventario;
        }

        public void AgregarCarrito(int id)
        {
            List<productos> datos = consultas.BuscarProductos();
            productos p = new productos();
            inventario inv = new inventario();
            p = datos.Where(m => m.id_producto == id).FirstOrDefault();
            
            int num = Convert.ToInt32(this.txt_total.Text);
            int id_usuario = int.Parse(Session["id_usuario"].ToString());

            // Consulta el ultimo carrito
            inventario invUC = new inventario();
            invUC = consultas.ConsultaUltimoCarrito(id_usuario);

            int num_carrito = invUC.num_carrito;
            int id_status_ultimo = invUC.id_status;

            if (id_status_ultimo != 1)
                num_carrito += 1;

            // Si agrega un producto igual, se actualiza el registro de num_inventario
            List<inventario> linv = new List<inventario>();
            linv = consultas.ConsultaProductosCarritoActivo(id_usuario, num_carrito);
            bool upd = false;
            int nuevo_inventario = 0;

            foreach(var i in linv)
            {
                // Actualiza el numero de inventario de ese producto
                if (i.id_producto == id)
                {
                    nuevo_inventario = i.num_inventario + num;
                    consultas.ActualizaInventarioCarrito(i.id_usuario, i.id_producto, nuevo_inventario);
                    upd = true;
                }
            }

            if (!upd)
            {
                inv.num_carrito = num_carrito;
                inv.id_producto = id;
                inv.num_inventario = num;
                inv.total = (p.precio * num);
                inv.id_usuario = id_usuario;
                inv.id_status = 1;

                int result = consultas.AgregarCarrito(inv);

                if (result > 0)
                {
                    Master.ConsultarCarrito();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "MensajeCorrecto('Se agregó correctamente al carrito');", true);
                }
            }
            else
            {
                Master.ConsultarCarrito();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "MensajeCorrecto('Se actualizó correctamente al carrito');", true);
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            int id_producto = int.Parse(hf_id_producto.Value);
            AgregarCarrito(id_producto);
        }

        [System.Web.Services.WebMethod]
        public static string SeleccionaProducto(int id)
        {
            var detalle = consultas.BuscarProducto(id);
            return JsonConvert.SerializeObject(detalle);
        }

    }
}