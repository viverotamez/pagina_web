using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class Descuentos : System.Web.UI.Page
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
            this.ddl_empleado.DataSource = consultas.ObtienePersonal().ToList();
            this.ddl_empleado.DataTextField = "nombre_completo";
            this.ddl_empleado.DataValueField = "id_personal";
            this.ddl_empleado.DataBind();

            this.ddl_clasificacion.DataSource = consultas.ObtieneClasificacionDescuento().ToList();
            this.ddl_clasificacion.DataTextField = "txt_clasificacion_descuento";
            this.ddl_clasificacion.DataValueField = "id_clasificacion_descuento";
            this.ddl_clasificacion.DataBind();

            this.ddl_anio.DataSource = consultas.ObtieneAnios().ToList();
            this.ddl_anio.DataTextField = "anio";
            this.ddl_anio.DataValueField = "id_anio";
            this.ddl_anio.DataBind();

            this.ddl_quincena.DataSource = consultas.ObtieneQuincenas().ToList();
            this.ddl_quincena.DataTextField = "quincena";
            this.ddl_quincena.DataValueField = "id_quincena";
            this.ddl_quincena.DataBind();

            this.grid_descuentos.DataSource = consultas.ObtieneDescuentos();
            this.grid_descuentos.DataBind();

            this.txt_desc.Text = "";
            this.txt_cantidad.Text = "";
            this.panel_error.Visible = false;
            this.btn_modificar.Visible = false;
            this.btn_guardar.Visible = true;
        }

        public void CargarDescuento()
        {
            descuentos d = new descuentos();

            if (Session["id_descuento_edit"] != null)
            {
                int id_descuento = int.Parse(Session["id_descuento_edit"].ToString());
                d = consultas.BuscarDescuento(id_descuento);

                this.ddl_clasificacion.SelectedValue = d.id_clasificacion_descuento.ToString();
                this.ddl_anio.SelectedValue = d.id_anio.ToString();
                this.ddl_quincena.SelectedValue = d.id_quincena.ToString();
                this.txt_desc.Text = d.descripcion;
                this.txt_cantidad.Text = d.cantidad.ToString();
                this.panel_error.Visible = false;
                this.btn_guardar.Visible = false;
                this.btn_modificar.Visible = true;
            }
            else
            {
                this.panel_error.Visible = true;
                this.btn_guardar.Visible = true;
                this.btn_modificar.Visible = false;
                this.mensaje_error.Text = "Error al editar el descuento";
            }
        }

        protected void grid_descuentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row_index = int.Parse((e.CommandArgument).ToString());
            int id_descuento = int.Parse(this.grid_descuentos.DataKeys[row_index]["id_descuento"].ToString());

            if (e.CommandName == "Editar")
            {
                Session["id_descuento_edit"] = id_descuento;
                CargarDescuento();
            }
            else if (e.CommandName == "Eliminar")
            {
                bool valida = consultas.EliminarDescuento(id_descuento);

                if (valida)
                {
                    Limpiar();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeCorrecto('El descuento se ha eliminado con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeError('Hubo un error al eliminar el descuento');", true);
                }
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string desc = this.txt_desc.Text.Trim();
            int id_personal = int.Parse(this.ddl_empleado.SelectedValue);
            int id_clasificacion = int.Parse(this.ddl_clasificacion.SelectedValue);
            float cantidad = float.Parse(this.txt_cantidad.Text.Trim());
            int id_anio = int.Parse(this.ddl_anio.SelectedValue);
            int id_quincena = int.Parse(this.ddl_quincena.SelectedValue);
            int sueldo = int.Parse(consultas.BuscarPersonal(id_personal).sueldo);

            if (string.IsNullOrEmpty(desc))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la descripción del descuento";
            }
            else if (string.IsNullOrEmpty(cantidad.ToString()))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la cantidad del descuento";
            }
            else if (cantidad > sueldo)
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "El descuento no puede ser mayor al sueldo percibido del empleado";
            }
            else
            {
                this.panel_error.Visible = false;

                descuentos u = new descuentos();
                u.id_personal = id_personal;
                u.id_clasificacion_descuento = id_clasificacion;
                u.descripcion = desc;
                u.cantidad = cantidad;
                u.id_anio = id_anio;
                u.id_quincena = id_quincena;
                u.id_usuario = int.Parse(Session["id_usuario"].ToString());
                u.fec_registro = DateTime.Now;

                bool result = consultas.AgregarDescuento(u);

                if (result)
                {
                    Limpiar();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "MensajeCorrecto('Descuento agregado');", true);
                }
                else
                {
                    this.panel_error.Visible = true;
                    this.mensaje_error.Text = "Ocurrió un error guardar el descuento";
                }
            }
        }
        
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            string desc = this.txt_desc.Text.Trim();
            int id_clasificacion = int.Parse(this.ddl_clasificacion.SelectedValue);
            float cantidad = float.Parse(this.txt_cantidad.Text.Trim());
            int id_anio = int.Parse(this.ddl_anio.SelectedValue);
            int id_quincena = int.Parse(this.ddl_quincena.SelectedValue);

            if (string.IsNullOrEmpty(desc))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la descripción del descuento";
            }
            else if (string.IsNullOrEmpty(cantidad.ToString()))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la cantidad del descuento";
            }
            else
            {
                this.panel_error.Visible = false;

                descuentos u = new descuentos();
                int id_descuento = int.Parse(Session["id_descuento_edit"].ToString());

                u.id_descuento = id_descuento;
                u.id_clasificacion_descuento = id_clasificacion;
                u.descripcion = desc;
                u.cantidad = cantidad;
                u.id_anio = id_anio;
                u.id_quincena = id_quincena;
                u.id_usuario = int.Parse(Session["id_usuario"].ToString());
                u.fec_registro = DateTime.Now;

                bool result = consultas.EditarDescuento(u);

                if (result)
                {
                    Limpiar();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "MensajeCorrecto('El descuento se ha modificado con éxito');", true);
                }
                else
                {
                    this.panel_error.Visible = true;
                    this.mensaje_error.Text = "Ocurriío un error modificar el descuento";
                }
            }
        }
    }
}