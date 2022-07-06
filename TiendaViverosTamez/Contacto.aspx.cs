using TiendaViverosTamez.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaViverosTamez
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LimpiarContacto();
            }
        }

        public void LimpiarContacto()
        {
            this.ddl_motivo.SelectedValue = "0";
            this.txt_pregunta.Text = "";
            this.txt_nombre.Text = "";
            this.txt_direccion.Text = "";
            this.txt_telefono.Text = "";
            this.txt_correo.Text = "";
        }

        protected void EnviarContacto_Click(object sender, EventArgs e)
        {
            contactos c = new contactos();
            c.id_motivo_contacto = int.Parse(this.ddl_motivo.SelectedValue);
            c.pregunta = this.txt_pregunta.Text.Trim();
            c.nombre = this.txt_nombre.Text.Trim();
            c.direccion = this.txt_direccion.Text.Trim();
            c.telefono = this.txt_telefono.Text.Trim();
            c.correo = this.txt_correo.Text.Trim();

            int result = consultas.AgregarContacto(c);

            if (result > 0)
            {
                LimpiarContacto();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "EnviarContacto();", true);
            }
        }

    }
}