using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    CargarUsuario();
                }
                else
                {
                    Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                }
            }
        }

        public void CargarUsuario()
        {
            usuarios u = new usuarios();

            if (Session["id_usuario_edit"] != null)
            {
                int id_usuario = int.Parse(Session["id_usuario_edit"].ToString());
                u = consultas.BuscarUsuario(id_usuario);

                this.txt_nombre.Text = u.nombre;
                this.txt_correo.Text = u.correo;
                this.panel_error.Visible = false;
            }
            else
            {
                this.txt_nombre.Enabled = false;
                this.txt_correo.Enabled = false;
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Error al editar el usuario";
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            usuarios u = new usuarios();
            int id_usuario = int.Parse(Session["id_usuario_edit"].ToString());
            string nombre = this.txt_nombre.Text.Trim();
            string correo = this.txt_correo.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el nombre completo";
            }
            else if (string.IsNullOrEmpty(correo))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el correo electrónico";
            }
            else
            {
                u.id_usuario = id_usuario;
                u.nombre = nombre;
                u.correo = correo;

                bool result = consultas.EditarUsuario(u);

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