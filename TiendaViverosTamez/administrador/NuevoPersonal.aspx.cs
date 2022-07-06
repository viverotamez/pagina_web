using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class NuevoPersonal : System.Web.UI.Page
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
            this.CargarPuestos();
            this.CargarCategorias();
            this.txt_NoEmpleado.Focus();
            this.txt_NoEmpleado.Text = "";
            this.txt_nombre.Text = "";
            this.txt_paterno.Text = "";
            this.txt_materno.Text = "";
            this.txt_correo.Text = "";
            this.fecha_nac.Text = "";
            this.txt_direccion.Text = "";
            this.txt_titulo.Text = "";
            this.txt_sueldo.Text = "";
            this.fecha_ingreso.Text = "";
            this.panel_error.Visible = false;
        }

        public void CargarPuestos()
        {
            this.ddl_puesto.DataSource = consultas.ObtienePuestos().ToList();
            this.ddl_puesto.DataTextField = "puesto";
            this.ddl_puesto.DataValueField = "id_puesto";
            this.ddl_puesto.DataBind();
        }

        public void CargarCategorias()
        {
            this.ddl_categoria.DataSource = consultas.ObtieneCategorias().ToList();
            this.ddl_categoria.DataTextField = "categoria";
            this.ddl_categoria.DataValueField = "id_categoria";
            this.ddl_categoria.DataBind();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string num_empleado = this.txt_NoEmpleado.Text.Trim();
            string nombre = this.txt_nombre.Text.Trim();
            string paterno = this.txt_paterno.Text.Trim();
            string materno = this.txt_materno.Text.Trim();
            string correo = this.txt_correo.Text.Trim();
            string fecha_nac = this.fecha_nac.Text.Trim();
            string direccion = this.txt_direccion.Text.Trim();
            string titulo = this.txt_titulo.Text.Trim();
            int id_puesto = int.Parse(this.ddl_puesto.SelectedValue);
            int id_categoria = int.Parse(this.ddl_categoria.SelectedValue);
            string sueldo = this.txt_sueldo.Text.Trim();
            string fecha_ingreso = this.fecha_ingreso.Text.Trim();

            if (string.IsNullOrEmpty(num_empleado))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el número de empleado";
            }
            else if (string.IsNullOrEmpty(nombre))
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
            else if (string.IsNullOrEmpty(correo))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el correo electrónico";
            }
            else if (string.IsNullOrEmpty(fecha_nac))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la fecha de nacimiento";
            }
            else if (string.IsNullOrEmpty(direccion))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la dirección";
            }
            else if (string.IsNullOrEmpty(titulo))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el título profesional";
            }
            else if (string.IsNullOrEmpty(sueldo))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar el sueldo";
            }
            else if (string.IsNullOrEmpty(fecha_ingreso))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la fecha de ingreso";
            }
            else
            {
                this.panel_error.Visible = false;

                personal p = new personal();
                p.num_empleado = num_empleado;
                p.nombre = nombre;
                p.app_paterno = paterno;
                p.app_materno = materno;
                p.correo = correo;
                p.fec_nacimiento = DateTime.ParseExact(fecha_nac, "dd/mm/yyyy", null);
                p.direccion = direccion;
                p.titulo = titulo;
                p.id_puesto = id_puesto;
                p.id_categoria = id_categoria;
                p.sueldo = sueldo;
                p.fec_ingreso = DateTime.ParseExact(fecha_ingreso, "dd/mm/yyyy", null);

                bool result = consultas.AgregarPersonal(p);

                if (result)
                {
                    Limpiar();
                    Response.Redirect(ResolveClientUrl("~/administrador/Administrador.aspx"));
                }
            }
        }

    }
}