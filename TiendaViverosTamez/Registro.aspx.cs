using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Limpiar();
            }
        }

        private void Limpiar()
        {
            this.txt_nombre.Focus();
            this.txt_nombre.Text = "";
            this.txt_correo.Text = "";
            this.txt_usuario.Text = "";
            this.txt_password.Text = "";
            this.panel_error.Visible = false;
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string user = this.txt_usuario.Text.Trim();
                string pass = this.txt_password.Text.Trim();
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
                    u.id_tipo_usuario = 2; //Cliente

                    int result = consultas.AgregarUsuario(u);

                    if (result > 0)
                    {
                        Session["cliente"] = u.usuario;
                        Session["id_usuario"] = u.id_usuario;
                        Master.ConsularLogin();
                        Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                    }
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "MensajeError('" + ex.Message + "');", true);
            }
        }

    }
}