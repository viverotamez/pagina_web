using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaViverosTamez.clases;

namespace TiendaViverosTamez.administrador
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Master.ConsultaPerfil())
                {
                    CargarTablas();
                }
                else
                {
                    Response.Redirect(ResolveClientUrl("~/Index.aspx"));
                }
            }
        }

        public void CargarTablas()
        {
            int id_usuario = int.Parse(Session["id_usuario"].ToString());

            this.grid_usuarios.DataSource = consultas.ObtieneUsuarios(id_usuario);
            this.grid_usuarios.DataBind();

            this.grid_personal.DataSource = consultas.ObtienePersonal();
            this.grid_personal.DataBind();

            this.grid_proveedores.DataSource = consultas.ObtieneProveedores();
            this.grid_proveedores.DataBind();

            this.grid_clientes.DataSource = consultas.ObtieneClientes();
            this.grid_clientes.DataBind();
        }

        protected void grid_usuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row_index = int.Parse((e.CommandArgument).ToString());
            int id_usuario = int.Parse(this.grid_usuarios.DataKeys[row_index]["id_usuario"].ToString());

            if (e.CommandName == "Editar")
            {
                Session["id_usuario_edit"] = id_usuario;
                Response.Redirect(ResolveClientUrl("~/administrador/ModificarUsuario.aspx"));
            }
            else if (e.CommandName == "Eliminar")
            {
                bool valida = consultas.EliminarUsuario(id_usuario);

                if (valida)
                {
                    CargarTablas();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeCorrecto('El usuario se ha eliminado con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeError('Hubo un error al eliminar el usuario');", true);
                }
            }
        }

        protected void grid_personal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row_index = int.Parse((e.CommandArgument).ToString());
            int id_personal = int.Parse(this.grid_personal.DataKeys[row_index]["id_personal"].ToString());

            if (e.CommandName == "Editar")
            {
                Session["id_personal_edit"] = id_personal;
                Response.Redirect(ResolveClientUrl("~/administrador/ModificarPersonal.aspx"));
            }
            else if (e.CommandName == "Eliminar")
            {
                bool valida = consultas.EliminarPersonal(id_personal);

                if (valida)
                {
                    CargarTablas();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeCorrecto('La persona se ha eliminado con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeError('Hubo un error al eliminar la persona');", true);
                }
            }
        }

        protected void grid_proveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row_index = int.Parse((e.CommandArgument).ToString());
            int id_proveedor = int.Parse(this.grid_proveedores.DataKeys[row_index]["id_proveedor"].ToString());

            if (e.CommandName == "Editar")
            {
                Session["id_proveedor_edit"] = id_proveedor;
                Response.Redirect(ResolveClientUrl("~/administrador/ModificarProveedor.aspx"));
            }
            else if (e.CommandName == "Eliminar")
            {
                bool valida = consultas.EliminarProveedor(id_proveedor);

                if (valida)
                {
                    CargarTablas();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeCorrecto('El proveedor se ha eliminado con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeError('Hubo un error al eliminar el proveedor');", true);
                }
            }
        }

        protected void grid_clientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row_index = int.Parse((e.CommandArgument).ToString());
            int id_cliente = int.Parse(this.grid_clientes.DataKeys[row_index]["id_cliente"].ToString());

            if (e.CommandName == "Editar")
            {
                Session["id_cliente_edit"] = id_cliente;
                Response.Redirect(ResolveClientUrl("~/administrador/ModificarCliente.aspx"));
            }
            else if (e.CommandName == "Eliminar")
            {
                bool valida = consultas.EliminarCliente(id_cliente);

                if (valida)
                {
                    CargarTablas();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeCorrecto('El cliente se ha eliminado con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ValidaEliminar", "MensajeError('Hubo un error al eliminar el cliente');", true);
                }
            }
        }

    }
}