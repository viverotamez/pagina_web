using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Limpiar();
            }
        }

        public void Limpiar()
        {
            this.txt_user.Focus();
            this.txt_user.Text = "";
            this.txt_pass.Text = "";
            this.panel_error.Visible = false;
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string user = this.txt_user.Text.Trim();
            string pass = this.txt_pass.Text.Trim();

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
            else
            {
                this.panel_error.Visible = false;
                string pass_encrypt = seguridad.Encrypt(pass); //wbernal89
                usuarios u = consultas.ValidaUsuario(user, pass_encrypt);

                if (u.id_usuario != 0)
                {
                    Session["id_usuario"] = u.id_usuario;
                    Master.ConsularLogin();

                    if (u.id_tipo_usuario == 1)
                    {
                        Session["usuario"] = user;
                        Response.Redirect(ResolveClientUrl("~/administrador/Administrador.aspx"));
                    }
                    else if (u.id_tipo_usuario == 2)
                    {
                        Session["cliente"] = user;
                        Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                    }
                }
                else
                {
                    this.panel_error.Visible = true;
                    this.mensaje_error.Text = "El usuario y/o la contraseña es incorrecta";
                }
            }
        }
    }
}