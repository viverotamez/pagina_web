using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class NuevoUsuario : System.Web.UI.Page
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
            this.txt_user.Focus();
            this.txt_user.Text = "";
            this.txt_pass.Text = "";
            this.txt_nombre.Text = "";
            this.txt_correo.Text = "";
            this.panel_error.Visible = false;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string user = this.txt_user.Text.Trim();
            string pass = this.txt_pass.Text.Trim();
            string nombre = this.txt_nombre.Text.Trim();
            string correo = this.txt_correo.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el usuario";
            }
            else if (string.IsNullOrEmpty(pass))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la contraseña";
            }
            else if (string.IsNullOrEmpty(nombre))
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
                this.panel_error.Visible = false;

                //Encriptar la contraseña
                string pass_encrypt = seguridad.Encrypt(pass);

                usuarios u = new usuarios();
                u.usuario = user;
                u.password = pass_encrypt;
                u.nombre = nombre;
                u.correo = correo;
                u.id_tipo_usuario = 1;

                int result = consultas.AgregarUsuario(u);

                if (result > 0)
                {
                    Limpiar();
                    Response.Redirect(ResolveClientUrl("~/administrador/Administrador.aspx"));
                }
            }
        }

    }
}