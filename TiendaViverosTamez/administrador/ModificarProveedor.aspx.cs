using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class ModificarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    CargarStatus();
                    CargarProveedor();
                }
                else
                {
                    Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                }
            }
        }

        public void CargarStatus()
        {
            this.ddl_estatus.DataSource = consultas.ObtieneEstatus().ToList();
            this.ddl_estatus.DataTextField = "txt_status";
            this.ddl_estatus.DataValueField = "id_status";
            this.ddl_estatus.DataBind();
        }

        public void CargarProveedor()
        {
            proveedores u = new proveedores();

            if (Session["id_proveedor_edit"] != null)
            {
                int id_proveedor = int.Parse(Session["id_proveedor_edit"].ToString());
                u = consultas.BuscarProveedor(id_proveedor);

                this.txt_nombre.Text = u.nombre;
                this.txt_rfc.Text = u.rfc;
                this.txt_direccion.Text = u.direccion;
                this.txt_telefono.Text = u.telefono;
                this.ddl_estatus.SelectedValue = u.id_status.ToString();

                this.panel_error.Visible = false;
            }
            else
            {
                this.txt_nombre.Enabled = false;
                this.txt_rfc.Enabled = false;
                this.txt_direccion.Enabled = false;
                this.txt_telefono.Enabled = false;
                this.ddl_estatus.Enabled = false;

                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Error al editar el proveedor";
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string nombre = this.txt_nombre.Text.Trim();
            string rfc = this.txt_rfc.Text.Trim();
            string direccion = this.txt_direccion.Text.Trim();
            string telefono = this.txt_telefono.Text.Trim();
            int id_status = int.Parse(this.ddl_estatus.SelectedValue);

            if (string.IsNullOrEmpty(nombre))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el nombre";
            }
            else if (string.IsNullOrEmpty(rfc))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el RFC";
            }
            else if (string.IsNullOrEmpty(direccion))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la dirección";
            }
            else if (string.IsNullOrEmpty(telefono))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la teléfono";
            }
            else
            {
                this.panel_error.Visible = false;

                proveedores p = new proveedores();
                int id_proveedor = int.Parse(Session["id_proveedor_edit"].ToString());

                p.id_proveedor = id_proveedor;
                p.nombre = nombre;
                p.rfc = rfc;
                p.direccion = direccion;
                p.telefono = telefono;
                p.id_status = id_status;

                bool result = consultas.EditarProveedor(p);

                if (result)
                {
                    Response.Redirect(ResolveClientUrl("~/administrador/Administrador.aspx"));
                }
                else
                {
                    this.panel_error.Visible = true;
                    this.mensaje_error.Text = "Ocurriío un error guardar la modificación";
                }
            }
        }
    }
}