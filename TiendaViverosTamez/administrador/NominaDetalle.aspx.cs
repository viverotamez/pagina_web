using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class NominaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    CargarNomina();
                }
                else
                {
                    Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                }
            }
        }

        public void CargarNomina()
        {
            nomina n = new nomina();

            if (Session["id_nomina_edit"] != null)
            {
                int id_nomina = int.Parse(Session["id_nomina_edit"].ToString());
                n = consultas.BuscarNomina(id_nomina);

                this.titulo_nomina.Text = "Año " + n.anio + " quincena " + n.quincena + ".";

                this.grid_nomina_personal.DataSource = consultas.ObtieneNominaPersonal(id_nomina);
                this.grid_nomina_personal.DataBind();
            }
            else
            {

            }
        }

    }
}