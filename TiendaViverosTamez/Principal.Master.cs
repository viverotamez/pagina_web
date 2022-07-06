using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ConsularLogin();
            }
        }

        public bool ConsultaPerfil()
        {
            if (Session["usuario"] != null)
                return true;
            else if (Session["cliente"] != null)
                return false;
            else
                return false;
        }

        public void ConsularLogin()
        {
            if (HttpContext.Current.Session["usuario"] != null)
            {
                this.pnl_login.Style.Add("display", "none");
                this.pnl_carrito.Style.Add("display", "none");
                this.pnl_logeado.Style.Add("display", "block");
                this.lbl_usuario.Text = HttpContext.Current.Session["usuario"].ToString();
            }
            else if (HttpContext.Current.Session["cliente"] != null)
            {
                this.pnl_login.Style.Add("display", "none");
                this.pnl_carrito.Style.Add("display", "initial");
                this.pnl_logeado.Style.Add("display", "initial");
                this.lbl_usuario.Text = HttpContext.Current.Session["cliente"].ToString();
                ConsultarCarrito();
                ConsultarCompra();
            }
            else
            {
                this.pnl_login.Style.Add("display", "block");
                this.pnl_logeado.Style.Add("display", "none");
            }
            
        }

        public void ConsultarCarrito()
        {
            int id_usuario = int.Parse(Session["id_usuario"].ToString());
            List<inventario> datos = consultas.BuscarInventario(id_usuario, 0, true);

            if (datos.Count > 0)
                this.notificacion.Text = @"<span class='badge badge-success'>" + datos.Count.ToString() + "</span>";
            else
                this.notificacion.Text = "";
        }
        
        public void ConsultarCompra()
        {
            if (HttpContext.Current.Session["compra"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "MensajeCorrecto('Tu compra se ha realizado con éxito');", true);
                HttpContext.Current.Session["compra"] = null;
            }
        }

        protected void lnk_logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
            ConsularLogin();
            Response.Redirect(ResolveClientUrl("~/Index.aspx"));
        }
    }
}