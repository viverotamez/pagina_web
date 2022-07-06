using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class ModificarPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    this.CargarPuestos();
                    this.CargarCategorias();
                    this.CargarPersonal();
                }
                else
                {
                    Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                }
            }
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

        public void CargarPersonal()
        {
            personal u = new personal();

            if (Session["id_personal_edit"] != null)
            {
                int id_personal = int.Parse(Session["id_personal_edit"].ToString());
                u = consultas.BuscarPersonal(id_personal);

                this.txt_NoEmpleado.Text = u.num_empleado;
                this.txt_nombre.Text = u.nombre;
                this.txt_paterno.Text = u.app_paterno;
                this.txt_materno.Text = u.app_materno;
                this.txt_correo.Text = u.correo;
                this.fecha_nac.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(u.fec_nacimiento.ToString()));
                this.txt_direccion.Text = u.direccion;
                this.txt_titulo.Text = u.titulo;
                this.ddl_puesto.SelectedValue = u.id_puesto.ToString();
                this.ddl_categoria.SelectedValue = u.id_categoria.ToString();
                this.txt_sueldo.Text = u.sueldo;
                this.fecha_ingreso.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(u.fec_ingreso.ToString()));

                this.panel_error.Visible = false;
            }
            else
            {
                this.txt_NoEmpleado.Enabled = false;
                this.txt_nombre.Enabled = false;
                this.txt_paterno.Enabled = false;
                this.txt_materno.Enabled = false;
                this.txt_correo.Enabled = false;
                this.fecha_nac.Enabled = false;
                this.txt_direccion.Enabled = false;
                this.txt_titulo.Enabled = false;
                this.txt_sueldo.Enabled = false;
                this.fecha_ingreso.Enabled = false;
                
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Error al editar el usuario";
            }
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
                int id_personal = int.Parse(Session["id_personal_edit"].ToString());

                p.id_personal = id_personal;
                p.num_empleado = num_empleado;
                p.nombre = nombre;
                p.app_paterno = paterno;
                p.app_materno = materno;
                p.correo = correo;
                p.fec_nacimiento = DateTime.ParseExact(fecha_nac, "dd/MM/yyyy", null);
                p.direccion = direccion;
                p.titulo = titulo;
                p.id_puesto = id_puesto;
                p.id_categoria = id_categoria;
                p.sueldo = sueldo;
                p.fec_ingreso = DateTime.ParseExact(fecha_ingreso, "dd/MM/yyyy", null);

                bool result = consultas.EditarPersonal(p);

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