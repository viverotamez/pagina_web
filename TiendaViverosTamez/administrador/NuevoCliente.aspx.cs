using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class NuevoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    Limpiar();
                }
                else
                {
                    Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                }
            }
        }

        public void Limpiar()
        {
            this.txt_nombre.Focus();
            this.txt_nombre.Text = "";
            this.txt_paterno.Text = "";
            this.txt_materno.Text = "";
            this.txt_rfc.Text = "";
            this.txt_direccion.Text = "";
            this.txt_telefono.Text = "";
            this.panel_error.Visible = false;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string nombre = this.txt_nombre.Text.Trim();
            string paterno = this.txt_paterno.Text.Trim();
            string materno = this.txt_materno.Text.Trim();
            string rfc = this.txt_rfc.Text.Trim();
            string direccion = this.txt_direccion.Text.Trim();
            string telefono = this.txt_telefono.Text.Trim();

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
                p.nombre = nombre;
                p.app_paterno = paterno;
                p.app_materno = materno;
                p.rfc = rfc;
                p.direccion = direccion;
                p.telefono = telefono;
                p.id_status = 1;
                p.fec_registro = DateTime.Now;

                bool result = consultas.AgregarCliente(p);

                if (result)
                {
                    Limpiar();
                    Response.Redirect(ResolveClientUrl("~/administrador/Administrador.aspx"));
                }
            }
        }

    }
}