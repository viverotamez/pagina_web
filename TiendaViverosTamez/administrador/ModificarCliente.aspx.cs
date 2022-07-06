using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class ModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    CargarStatus();
                    CargarCliente();
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

        public void CargarCliente()
        {
            clientes u = new clientes();

            if (Session["id_cliente_edit"] != null)
            {
                int id_cliente = int.Parse(Session["id_cliente_edit"].ToString());
                u = consultas.BuscarCliente(id_cliente);

                this.txt_nombre.Text = u.nombre;
                this.txt_paterno.Text = u.app_paterno;
                this.txt_materno.Text = u.app_materno;
                this.txt_rfc.Text = u.rfc;
                this.txt_direccion.Text = u.direccion;
                this.txt_telefono.Text = u.telefono;
                this.ddl_estatus.SelectedValue = u.id_status.ToString();

                this.panel_error.Visible = false;
            }
            else
            {
                this.txt_nombre.Enabled = false;
                this.txt_paterno.Enabled = false;
                this.txt_materno.Enabled = false;
                this.txt_rfc.Enabled = false;
                this.txt_direccion.Enabled = false;
                this.txt_telefono.Enabled = false;
                this.ddl_estatus.Enabled = false;

                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Error al editar el cliente";
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string nombre = this.txt_nombre.Text.Trim();
            string paterno = this.txt_paterno.Text.Trim();
            string materno = this.txt_materno.Text.Trim();
            string rfc = this.txt_rfc.Text.Trim();
            string direccion = this.txt_direccion.Text.Trim();
            string telefono = this.txt_telefono.Text.Trim();
            int id_status = int.Parse(this.ddl_estatus.SelectedValue);

            if (string.IsNullOrEmpty(nombre))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el nombre";
            }
            else if (string.IsNullOrEmpty(paterno))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el apellido paterno";
            }
            else if (string.IsNullOrEmpty(materno))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el apellido materno";
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

                clientes p = new clientes();
                int id_cliente = int.Parse(Session["id_cliente_edit"].ToString());

                p.id_cliente = id_cliente;
                p.nombre = nombre;
                p.app_paterno = paterno;
                p.app_materno = materno;
                p.rfc = rfc;
                p.direccion = direccion;
                p.telefono = telefono;
                p.id_status = id_status;

                bool result = consultas.EditarCliente(p);

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