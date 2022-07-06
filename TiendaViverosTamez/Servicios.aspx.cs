using TiendaViverosTamez.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaViverosTamez
{
    public partial class Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LimpiarCotizacion();
            }
        }

        public void LimpiarCotizacion()
        {
            this.txt_nombre1.Text = "";
            this.txt_direccion1.Text = "";
            this.txt_telefono1.Text = "";
            this.txt_correo1.Text = "";
            this.txt_nombre2.Text = "";
            this.txt_direccion2.Text = "";
            this.txt_telefono2.Text = "";
            this.txt_correo2.Text = "";
            this.txt_nombre3.Text = "";
            this.txt_direccion3.Text = "";
            this.txt_telefono3.Text = "";
            this.txt_correo3.Text = "";
        }

        public void GuardarEnviar(int id_tipo_cotizacion)
        {
            cotizacion c = new cotizacion();
            c.id_tipo_cotizacion = id_tipo_cotizacion;

            switch (id_tipo_cotizacion)
            {
                case 1:
                    c.nombre = this.txt_nombre1.Text.Trim();
                    c.direccion = this.txt_direccion1.Text.Trim();
                    c.telefono = this.txt_telefono1.Text.Trim();
                    c.correo = this.txt_correo1.Text.Trim();
                    break;
                case 2:
                    c.nombre = this.txt_nombre2.Text.Trim();
                    c.direccion = this.txt_direccion2.Text.Trim();
                    c.telefono = this.txt_telefono2.Text.Trim();
                    c.correo = this.txt_correo2.Text.Trim();
                    break;
                case 3:
                    c.nombre = this.txt_nombre3.Text.Trim();
                    c.direccion = this.txt_direccion3.Text.Trim();
                    c.telefono = this.txt_telefono3.Text.Trim();
                    c.correo = this.txt_correo3.Text.Trim();
                    break;
            }

            int result = consultas.AgregarCotizacion(c);

            if (result > 0)
            {
                LimpiarCotizacion();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "EnviarCotizacion();", true);
            }
        }

        protected void EnviarCotizacion1_Click(object sender, EventArgs e)
        {
            GuardarEnviar(1);
        }

        protected void EnviarCotizacion2_Click(object sender, EventArgs e)
        {
            GuardarEnviar(2);
        }

        protected void EnviarCotizacion3_Click(object sender, EventArgs e)
        {
            GuardarEnviar(3);
        }
    }
}