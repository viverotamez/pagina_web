using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class Nomina : System.Web.UI.Page
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
            this.ddl_anio.DataSource = consultas.ObtieneAnios().ToList();
            this.ddl_anio.DataTextField = "anio";
            this.ddl_anio.DataValueField = "id_anio";
            this.ddl_anio.DataBind();

            this.ddl_quincena.DataSource = consultas.ObtieneQuincenas().ToList();
            this.ddl_quincena.DataTextField = "quincena";
            this.ddl_quincena.DataValueField = "id_quincena";
            this.ddl_quincena.DataBind();

            this.grid_nominas.DataSource = consultas.ObtieneNominas();
            this.grid_nominas.DataBind();

            this.txt_desc.Text = "";
            this.panel_error.Visible = false;
        }

        protected void grid_nominas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row_index = int.Parse((e.CommandArgument).ToString());
            int id_nomina = int.Parse(this.grid_nominas.DataKeys[row_index]["id_nomina"].ToString());

            if (e.CommandName == "Editar")
            {
                Session["id_nomina_edit"] = id_nomina;
                Response.Redirect(ResolveClientUrl("~/administrador/NominaDetalle.aspx"));
            }
            else if (e.CommandName == "Eliminar")
            {
                bool valida = consultas.EliminarNomina(id_nomina);

                if (valida)
                {
                    Limpiar();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeCorrecto('La nómina se ha eliminado con éxito.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeError('Hubo un error al eliminar la nómina.');", true);
                }
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            int id_anio = int.Parse(this.ddl_anio.SelectedValue);
            int id_quincena = int.Parse(this.ddl_quincena.SelectedValue);
            string descripcion = this.txt_desc.Text.Trim();

            if (string.IsNullOrEmpty(descripcion))
            {
                this.panel_error.Visible = true;
                this.mensaje_error.Text = "Falta por capturar la descripción de la nómina.";
            }
            else
            {
                this.panel_error.Visible = false;

                nomina n = new nomina();
                n.id_anio = id_anio;
                n.id_quincena = id_quincena;
                n.descripcion = descripcion;
                n.id_status_nomina = 1;
                n.id_usuario = int.Parse(Session["id_usuario"].ToString());
                n.fec_registro = DateTime.Now;

                bool result = consultas.AgregarNomina(n);

                if (result)
                {
                    Limpiar();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "MensajeCorrecto('Nómina registrada.');", true);
                }
                else
                {
                    this.panel_error.Visible = true;
                    this.mensaje_error.Text = "Ocurrió un error guardar el descuento.";
                }
            }
        }

    }
}