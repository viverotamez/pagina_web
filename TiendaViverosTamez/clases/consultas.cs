using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class consultas
    {
        #region "SELECT"

        public static List<puestos> ObtienePuestos()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_puesto,puesto FROM cat_puestos"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<puestos>();

            while (reader.Read())
            {
                list.Add(new puestos
                {
                    id_puesto = int.Parse(reader["id_puesto"].ToString()),
                    puesto = reader["puesto"].ToString()
                });
            }

            return list;
        }

        public static List<categorias> ObtieneCategorias()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_categoria,categoria FROM cat_categorias"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<categorias>();

            while (reader.Read())
            {
                list.Add(new categorias
                {
                    id_categoria = int.Parse(reader["id_categoria"].ToString()),
                    categoria = reader["categoria"].ToString()
                });
            }

            return list;
        }

        public static List<status> ObtieneEstatus()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_status,status FROM cat_status"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<status>();

            while (reader.Read())
            {
                list.Add(new status
                {
                    id_status = int.Parse(reader["id_status"].ToString()),
                    txt_status = reader["status"].ToString()
                });
            }

            return list;
        }

        public static List<personal> ObtienePersonal()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_personal,num_empleado,nombre,app_paterno,app_materno,correo,fec_nac,direccion,titulo,sueldo,fec_ingreso,pu.puesto,c.categoria FROM personal AS p INNER JOIN cat_categorias AS c ON p.id_categoria = c.id_categoria INNER JOIN cat_puestos AS pu ON p.id_puesto = pu.id_puesto"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<personal>();

            while (reader.Read())
            {
                list.Add(new personal
                {
                    id_personal = int.Parse(reader["id_personal"].ToString()),
                    num_empleado = reader["num_empleado"].ToString(),
                    nombre_completo = reader["nombre"].ToString() + " " + reader["app_paterno"].ToString() + " " + reader["app_materno"].ToString(),
                    nombre = reader["nombre"].ToString(),
                    app_paterno = reader["app_paterno"].ToString(),
                    app_materno = reader["app_materno"].ToString(),
                    puesto = reader["puesto"].ToString(),
                    categoria = reader["categoria"].ToString(),
                    sueldo = reader["sueldo"].ToString()
                });
            }

            return list;
        }

        public static List<proveedores> ObtieneProveedores()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_proveedor,nombre,rfc,direccion,telefono,st.id_status,st.status FROM proveedores AS p INNER JOIN cat_status AS st ON p.id_status = st.id_status"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<proveedores>();

            while (reader.Read())
            {
                list.Add(new proveedores
                {
                    id_proveedor = int.Parse(reader["id_proveedor"].ToString()),
                    nombre = reader["nombre"].ToString(),
                    rfc = reader["rfc"].ToString(),
                    direccion = reader["direccion"].ToString(),
                    telefono = reader["telefono"].ToString(),
                    id_status = int.Parse(reader["id_status"].ToString()),
                    status = reader["status"].ToString()
                });
            }

            return list;
        }

        public static List<clientes> ObtieneClientes()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_cliente,nombre,app_paterno,app_materno,rfc,direccion,telefono,st.id_status,st.status FROM clientes AS p INNER JOIN cat_status AS st ON p.id_status = st.id_status"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<clientes>();

            while (reader.Read())
            {
                list.Add(new clientes
                {
                    id_cliente = int.Parse(reader["id_cliente"].ToString()),
                    nombre = reader["nombre"].ToString(),
                    app_paterno = reader["app_paterno"].ToString(),
                    app_materno = reader["app_materno"].ToString(),
                    rfc = reader["rfc"].ToString(),
                    direccion = reader["direccion"].ToString(),
                    telefono = reader["telefono"].ToString(),
                    id_status = int.Parse(reader["id_status"].ToString()),
                    status = reader["status"].ToString()
                });
            }

            return list;
        }

        public static List<personal> ObtieneNominaPersonal(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT sc.id_personal,sc.num_empleado,sc.nombre,sc.app_paterno,sc.app_materno,sc.correo,sc.fec_nac,sc.direccion,sc.titulo,sc.sueldo,sc.fec_ingreso,sc.puesto,sc.categoria,SUM(sc.cantidad_descuento) AS descuento,(sc.sueldo-(SUM(sc.cantidad_descuento))) AS total FROM (SELECT p.id_personal,p.num_empleado,p.nombre,p.app_paterno,p.app_materno,p.correo,p.fec_nac,p.direccion,p.titulo,p.sueldo,p.fec_ingreso,pu.puesto,c.categoria, CASE WHEN de.cantidad IS NULL THEN 0 ELSE de.cantidad END AS cantidad_descuento, nom.id_nomina FROM personal AS p INNER JOIN cat_categorias AS c ON p.id_categoria = c.id_categoria INNER JOIN cat_puestos AS pu ON p.id_puesto = pu.id_puesto INNER JOIN nomina AS nom ON nom.id_nomina = " + id + " LEFT JOIN descuentos AS de ON p.id_personal = de.id_personal AND nom.id_anio = de.id_anio AND nom.id_quincena = de.id_quincena) AS sc GROUP BY sc.id_personal,sc.num_empleado,sc.nombre,sc.app_paterno,sc.app_materno,sc.correo,sc.fec_nac,sc.direccion,sc.titulo,sc.sueldo,sc.fec_ingreso,sc.puesto,sc.categoria;"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<personal>();

            while (reader.Read())
            {
                list.Add(new personal
                {
                    id_personal = int.Parse(reader["id_personal"].ToString()),
                    num_empleado = reader["num_empleado"].ToString(),
                    nombre_completo = reader["nombre"].ToString() + " " + reader["app_paterno"].ToString() + " " + reader["app_materno"].ToString(),
                    nombre = reader["nombre"].ToString(),
                    app_paterno = reader["app_paterno"].ToString(),
                    app_materno = reader["app_materno"].ToString(),
                    puesto = reader["puesto"].ToString(),
                    categoria = reader["categoria"].ToString(),
                    sueldo = reader["sueldo"].ToString(),
                    descuento = float.Parse(reader["descuento"].ToString()),
                    total = float.Parse(reader["total"].ToString())
                });
            }

            return list;
        }

        public static List<usuarios> ObtieneUsuarios(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_usuario,usuario,contrasena,nombre,correo FROM usuarios WHERE id_tipo_usuario = 1 AND id_usuario <> " + id), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<usuarios>();

            while (reader.Read())
            {
                list.Add(new usuarios
                {
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    usuario = reader["usuario"].ToString(),
                    nombre = reader["nombre"].ToString(),
                    correo = reader["correo"].ToString()
                });
            }

            return list;
        }

        public static List<descuentos> ObtieneDescuentos()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_descuento,descripcion,cantidad,pe.nombre,pe.app_paterno,pe.app_materno,cd.clasificacion_descuento,ca.anio,cq.quincena,id_usuario,fec_registro FROM descuentos AS d INNER JOIN personal AS pe ON d.id_personal = pe.id_personal INNER JOIN cat_clasificacion_descuento AS cd ON d.id_clasificacion_descuento = cd.id_clasificacion_descuento INNER JOIN cat_anio AS ca ON d.id_anio = ca.id_anio INNER JOIN cat_quincena AS cq ON d.id_quincena = cq.id_quincena"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<descuentos>();

            while (reader.Read())
            {
                list.Add(new descuentos
                {
                    id_descuento = int.Parse(reader["id_descuento"].ToString()),
                    descripcion = reader["descripcion"].ToString(),
                    nombre_completo = reader["nombre"].ToString() + " " + reader["app_paterno"].ToString() + " " + reader["app_materno"].ToString(),
                    txt_clasificacion_descuento = reader["clasificacion_descuento"].ToString(),
                    cantidad = float.Parse(reader["cantidad"].ToString()),
                    anio = reader["anio"].ToString(),
                    quincena = reader["quincena"].ToString(),
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    fec_registro = DateTime.Parse(reader["fec_registro"].ToString())
                });
            }

            return list;
        }

        public static List<nomina> ObtieneNominas()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_nomina,ca.anio,cq.quincena,descripcion,st.status_nomina,id_usuario,fec_registro FROM nomina AS n INNER JOIN cat_anio AS ca ON n.id_anio = ca.id_anio INNER JOIN cat_quincena AS cq ON n.id_quincena = cq.id_quincena INNER JOIN cat_status_nomina AS st ON n.id_status_nomina = st.id_status_nomina"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<nomina>();

            while (reader.Read())
            {
                list.Add(new nomina
                {
                    id_nomina = int.Parse(reader["id_nomina"].ToString()),
                    anio = reader["anio"].ToString(),
                    quincena = reader["quincena"].ToString(),
                    descripcion = reader["descripcion"].ToString(),
                    status_nomina = reader["status_nomina"].ToString(),
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    fec_registro = DateTime.Parse(reader["fec_registro"].ToString())
                });
            }

            return list;
        }

        public static List<clasificacion_descuento> ObtieneClasificacionDescuento()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_clasificacion_descuento,clasificacion_descuento FROM cat_clasificacion_descuento"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<clasificacion_descuento>();

            while (reader.Read())
            {
                list.Add(new clasificacion_descuento
                {
                    id_clasificacion_descuento = int.Parse(reader["id_clasificacion_descuento"].ToString()),
                    txt_clasificacion_descuento = reader["clasificacion_descuento"].ToString()
                });
            }

            return list;
        }

        public static List<anios> ObtieneAnios()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_anio,anio FROM cat_anio"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<anios>();

            while (reader.Read())
            {
                list.Add(new anios
                {
                    id_anio = int.Parse(reader["id_anio"].ToString()),
                    anio = reader["anio"].ToString()
                });
            }

            return list;
        }

        public static List<quincenas> ObtieneQuincenas()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_quincena,quincena FROM cat_quincena"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<quincenas>();

            while (reader.Read())
            {
                list.Add(new quincenas
                {
                    id_quincena = int.Parse(reader["id_quincena"].ToString()),
                    quincena = reader["quincena"].ToString()
                });
            }

            return list;
        }

        public static usuarios BuscarUsuario(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_usuario,usuario,nombre,correo,id_tipo_usuario FROM usuarios WHERE id_usuario = " + id), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            usuarios u = new usuarios();

            while (reader.Read())
            {
                u.id_usuario = int.Parse(reader["id_usuario"].ToString());
                u.usuario = reader["usuario"].ToString();
                u.nombre = reader["nombre"].ToString();
                u.correo = reader["correo"].ToString();
                u.id_tipo_usuario = int.Parse(reader["id_tipo_usuario"].ToString());
            }

            return u;
        }

        public static personal BuscarPersonal(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_personal,num_empleado,nombre,app_paterno,app_materno,correo,fec_nac,direccion,titulo,id_puesto,id_categoria,sueldo,fec_ingreso FROM personal WHERE id_personal = " + id), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            personal p = new personal();

            while (reader.Read())
            {
                p.id_personal = int.Parse(reader["id_personal"].ToString());
                p.num_empleado = reader["num_empleado"].ToString();
                p.nombre = reader["nombre"].ToString();
                p.app_paterno = reader["app_paterno"].ToString();
                p.app_materno = reader["app_materno"].ToString();
                p.correo = reader["correo"].ToString();
                p.fec_nacimiento = DateTime.Parse(reader["fec_nac"].ToString());
                p.direccion = reader["direccion"].ToString();
                p.titulo = reader["titulo"].ToString();
                p.id_puesto = int.Parse(reader["id_puesto"].ToString());
                p.id_categoria = int.Parse(reader["id_categoria"].ToString());
                p.sueldo = reader["sueldo"].ToString();
                p.fec_ingreso = DateTime.Parse(reader["fec_ingreso"].ToString());
            }

            return p;
        }

        public static proveedores BuscarProveedor(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_proveedor,nombre,rfc,direccion,telefono,id_status FROM proveedores WHERE id_proveedor = " + id), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            proveedores p = new proveedores();

            while (reader.Read())
            {
                p.id_proveedor = int.Parse(reader["id_proveedor"].ToString());
                p.nombre = reader["nombre"].ToString();
                p.rfc = reader["rfc"].ToString();
                p.direccion = reader["direccion"].ToString();
                p.telefono = reader["telefono"].ToString();
                p.id_status = int.Parse(reader["id_status"].ToString());
            }

            return p;
        }

        public static clientes BuscarCliente(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_cliente,nombre,app_paterno,app_materno,rfc,direccion,telefono,id_status FROM clientes WHERE id_cliente = " + id), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            clientes p = new clientes();

            while (reader.Read())
            {
                p.id_cliente = int.Parse(reader["id_cliente"].ToString());
                p.nombre = reader["nombre"].ToString();
                p.app_paterno = reader["app_paterno"].ToString();
                p.app_materno = reader["app_materno"].ToString();
                p.rfc = reader["rfc"].ToString();
                p.direccion = reader["direccion"].ToString();
                p.telefono = reader["telefono"].ToString();
                p.id_status = int.Parse(reader["id_status"].ToString());
            }

            return p;
        }

        public static descuentos BuscarDescuento(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT * FROM descuentos WHERE id_descuento = " + id), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            descuentos p = new descuentos();

            while (reader.Read())
            {
                p.id_descuento = int.Parse(reader["id_descuento"].ToString());
                p.id_personal = int.Parse(reader["id_personal"].ToString());
                p.id_clasificacion_descuento = int.Parse(reader["id_clasificacion_descuento"].ToString());
                p.descripcion = reader["descripcion"].ToString();
                p.cantidad = float.Parse(reader["cantidad"].ToString());
                p.id_anio = int.Parse(reader["id_anio"].ToString());
                p.id_quincena = int.Parse(reader["id_quincena"].ToString());
                p.id_usuario = int.Parse(reader["id_usuario"].ToString());
                p.fec_registro = DateTime.Parse(reader["fec_registro"].ToString());
            }

            return p;
        }

        public static nomina BuscarNomina(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_nomina,ca.id_anio,ca.anio,cq.id_quincena,cq.quincena,descripcion,st.id_status_nomina,st.status_nomina,id_usuario,fec_registro FROM nomina AS n INNER JOIN cat_anio AS ca ON n.id_anio = ca.id_anio INNER JOIN cat_quincena AS cq ON n.id_quincena = cq.id_quincena INNER JOIN cat_status_nomina AS st ON n.id_status_nomina = st.id_status_nomina WHERE id_nomina = " + id), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            nomina p = new nomina();

            while (reader.Read())
            {
                p.id_nomina = int.Parse(reader["id_nomina"].ToString());
                p.id_anio = int.Parse(reader["id_anio"].ToString());
                p.anio = reader["anio"].ToString();
                p.id_quincena = int.Parse(reader["id_quincena"].ToString());
                p.quincena = reader["quincena"].ToString();
                p.descripcion = reader["descripcion"].ToString();
                p.id_status_nomina = int.Parse(reader["id_status_nomina"].ToString());
                p.status_nomina = reader["status_nomina"].ToString();
                p.id_usuario = int.Parse(reader["id_usuario"].ToString());
                p.fec_registro = DateTime.Parse(reader["fec_registro"].ToString());
            }

            return p;
        }

        public static productos BuscarProducto(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_producto,descripcion,actual_inventario,total_inventario,precio,url_imagen FROM productos WHERE id_producto = " + id), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            productos p = new productos();

            while (reader.Read())
            {
                p.id_producto = int.Parse(reader["id_producto"].ToString());
                p.descripcion = reader["descripcion"].ToString();
                p.actual_inventario = int.Parse(reader["actual_inventario"].ToString());
                p.total_inventario = int.Parse(reader["total_inventario"].ToString());
                p.precio = float.Parse(reader["precio"].ToString());
                p.url_imagen = reader["url_imagen"].ToString();
            }

            return p;
        }

        public static List<productos> BuscarProductos()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_producto,descripcion,actual_inventario,total_inventario,precio,url_imagen FROM productos"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<productos>();

            while (reader.Read())
            {
                list.Add(new productos
                {
                    id_producto = int.Parse(reader["id_producto"].ToString()),
                    descripcion = reader["descripcion"].ToString(),
                    actual_inventario = int.Parse(reader["actual_inventario"].ToString()),
                    total_inventario = int.Parse(reader["total_inventario"].ToString()),
                    precio = float.Parse(reader["precio"].ToString()),
                    url_imagen = reader["url_imagen"].ToString()
                });
            }

            return list;
        }

        public static List<usuarios> BuscarUsuarios()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_usuario,usuario,contrasena,nombre,correo FROM usuarios"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<usuarios>();

            while (reader.Read())
            {
                list.Add(new usuarios
                {
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    usuario = reader["usuario"].ToString(),
                    password = reader["contrasena"].ToString(),
                    nombre = reader["nombre"].ToString(),
                    correo = reader["correo"].ToString()
                });
            }

            return list;
        }

        public static List<inventario> BuscarInventario(int id_usuario, int num_carrito, bool status_activo)
        {
            string query = "";
            if (status_activo)
                query = "SELECT u.id_usuario,u.nombre,u.usuario,i.id_inventario,i.id_producto,p.descripcion,i.num_inventario,p.precio,i.total,i.id_status,s.status FROM inventario AS i INNER JOIN productos AS p ON i.id_producto = p.id_producto INNER JOIN usuarios AS u ON i.id_usuario = u.id_usuario INNER JOIN cat_status AS s ON i.id_status = s.id_status WHERE i.id_status = 1 AND (" + id_usuario + " = 0 OR i.id_usuario = " + id_usuario + ")";
            else
                query = "SELECT u.id_usuario,u.nombre,u.usuario,i.id_inventario,i.id_producto,p.descripcion,i.num_inventario,p.precio,i.total,i.id_status,s.status,i.num_carrito FROM inventario AS i INNER JOIN productos AS p ON i.id_producto = p.id_producto INNER JOIN usuarios AS u ON i.id_usuario = u.id_usuario INNER JOIN cat_status AS s ON i.id_status = s.id_status WHERE i.id_status != 2 AND i.num_carrito = " + num_carrito + " AND i.id_usuario = " + id_usuario;

            MySqlCommand command = new MySqlCommand(string.Format(query), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<inventario>();

            while (reader.Read())
            {
                list.Add(new inventario
                {
                    id_inventario = int.Parse(reader["id_inventario"].ToString()),
                    id_producto = int.Parse(reader["id_producto"].ToString()),
                    descripcion = reader["descripcion"].ToString(),
                    num_inventario = int.Parse(reader["num_inventario"].ToString()),
                    precio = float.Parse(reader["precio"].ToString()),
                    total = double.Parse(reader["total"].ToString()),
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    nombre_usuario = reader["nombre"].ToString(),
                    usuario = reader["usuario"].ToString(),
                    id_status = int.Parse(reader["id_status"].ToString()),
                    status = reader["status"].ToString()
                });
            }

            return list;
        }

        public static usuarios ValidaUsuario(string user, string pass)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT * FROM usuarios WHERE usuario = '" + user + "' and contrasena = '" + pass + "'"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();
            usuarios u = new usuarios();

            while (reader.Read())
            {
                u.id_tipo_usuario = int.Parse(reader["id_tipo_usuario"].ToString());
                u.id_usuario = int.Parse(reader["id_usuario"].ToString());
                u.usuario = reader["usuario"].ToString();
                u.nombre = reader["nombre"].ToString();
                u.correo = reader["correo"].ToString();
            }
            return u;
        }

        public static List<inventario> CarritosActivos()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT u.id_usuario,u.nombre,u.usuario,i.id_status,s.status,i.num_carrito FROM inventario AS i INNER JOIN usuarios AS u ON i.id_usuario = u.id_usuario INNER JOIN cat_status AS s ON i.id_status = s.id_status WHERE i.id_status != 2 GROUP BY u.id_usuario,i.num_carrito"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<inventario>();

            while (reader.Read())
            {
                list.Add(new inventario
                {
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    nombre_usuario = reader["nombre"].ToString(),
                    usuario = reader["usuario"].ToString(),
                    id_status = int.Parse(reader["id_status"].ToString()),
                    status = reader["status"].ToString(),
                    num_carrito = int.Parse(reader["num_carrito"].ToString())
                });
            }

            return list;
        }

        public static double TotalCarrito(int id_usuario, int num_carrito)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT total FROM inventario WHERE num_carrito = " + num_carrito + " AND id_usuario = " + id_usuario), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            double total = 0;

            while (reader.Read())
            {
                total +=  double.Parse(reader["total"].ToString());
            }
            
            return total;
        }

        public static List<ventas> ConsultaVentas()
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT sc.id_usuario,sc.usuario,sc.num_carrito,sc.nombre,SUM(sc.total) AS total FROM (SELECT v.id_venta,v.id_inventario,v.fec_registro,i.total,u.id_usuario,u.usuario,u.nombre,i.num_carrito FROM ventas AS v INNER JOIN inventario AS i ON v.id_inventario = i.id_inventario INNER JOIN usuarios AS u ON i.id_usuario = u.id_usuario WHERE i.id_status = 2) AS sc GROUP BY sc.id_usuario,sc.usuario,sc.nombre,sc.num_carrito"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<ventas>();

            while (reader.Read())
            {
                list.Add(new ventas
                {
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    usuario = reader["usuario"].ToString(),
                    nombre_usuario = reader["nombre"].ToString(),
                    total = float.Parse(reader["total"].ToString()),
                    num_carrito = int.Parse(reader["num_carrito"].ToString())
                });
            }

            return list;
        }

        public static List<inventario> ConsultaVentasDetalle(int id_usuario, int num_carrito)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT u.id_usuario,u.nombre,u.usuario,i.id_inventario,i.id_producto,p.descripcion,i.num_inventario,p.precio,i.total,i.id_status,s.status,i.num_carrito FROM inventario AS i INNER JOIN productos AS p ON i.id_producto = p.id_producto INNER JOIN usuarios AS u ON i.id_usuario = u.id_usuario INNER JOIN cat_status AS s ON i.id_status = s.id_status WHERE i.id_status = 2 AND i.num_carrito = " + num_carrito + " AND i.id_usuario = " + id_usuario), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();

            var list = new List<inventario>();

            while (reader.Read())
            {
                list.Add(new inventario
                {
                    id_inventario = int.Parse(reader["id_inventario"].ToString()),
                    id_producto = int.Parse(reader["id_producto"].ToString()),
                    descripcion = reader["descripcion"].ToString(),
                    num_inventario = int.Parse(reader["num_inventario"].ToString()),
                    precio = float.Parse(reader["precio"].ToString()),
                    total = double.Parse(reader["total"].ToString()),
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    nombre_usuario = reader["nombre"].ToString(),
                    usuario = reader["usuario"].ToString(),
                    id_status = int.Parse(reader["id_status"].ToString()),
                    status = reader["status"].ToString()
                });
            }

            return list;
        }

        public static inventario ConsultaUltimoCarrito(int id_usuario)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT MAX(sc.num_carrito) AS num_carrito,sc.id_status FROM (SELECT num_carrito,id_status FROM inventario WHERE id_usuario = " + id_usuario + " GROUP BY id_status,num_carrito) AS sc"), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();
            inventario i = new inventario();

            while (reader.Read())
            {
                i.num_carrito = reader.IsDBNull(0) ? 1 : int.Parse(reader["num_carrito"].ToString());
                i.id_status = reader.IsDBNull(1) ? 1 : int.Parse(reader["id_status"].ToString());
            }
            return i;
        }

        public static List<inventario> ConsultaProductosCarritoActivo(int id_usuario, int num_carrito)
        {
            MySqlCommand command = new MySqlCommand(string.Format("SELECT id_usuario,id_producto,num_inventario FROM inventario WHERE id_status = 1 AND num_carrito = " + num_carrito +  " AND id_usuario = " + id_usuario), conexion.ObtenerConexion());
            MySqlDataReader reader = command.ExecuteReader();
            var list = new List<inventario>();

            while (reader.Read())
            {
                list.Add(new inventario
                {
                    id_usuario = int.Parse(reader["id_usuario"].ToString()),
                    id_producto = int.Parse(reader["id_producto"].ToString()),
                    num_inventario = int.Parse(reader["num_inventario"].ToString())
                });
            }

            return list;
        }

        #endregion

        #region "INSERT"

        public static int AgregarContacto(contactos c)
        {
            int retorno = 0;
            MySqlCommand SQL = new MySqlCommand(
                string.Format("INSERT INTO contactos (id_motivo_contacto,pregunta,nombre,direccion,telefono,correo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                c.id_motivo_contacto,
                c.pregunta,
                c.nombre,
                c.direccion,
                c.telefono,
                c.correo), conexion.ObtenerConexion()
            );
            retorno = SQL.ExecuteNonQuery();
            return retorno;
        }

        public static int AgregarCotizacion(cotizacion c)
        {
            int retorno = 0;
            MySqlCommand SQL = new MySqlCommand(
                string.Format("INSERT INTO cotizacion (id_tipo_cotizacion,nombre,direccion,telefono,correo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                c.id_tipo_cotizacion,
                c.nombre,
                c.direccion,
                c.telefono,
                c.correo), conexion.ObtenerConexion()
            );
            retorno = SQL.ExecuteNonQuery();
            return retorno;
        }

        public static int AgregarUsuario(usuarios c)
        {
            int retorno = 0;
            MySqlCommand SQL = new MySqlCommand(
                string.Format("INSERT INTO usuarios (usuario,contrasena,nombre,correo,id_tipo_usuario) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                c.usuario,
                c.password,
                c.nombre,
                c.correo,
                c.id_tipo_usuario), conexion.ObtenerConexion()
            );
            retorno = SQL.ExecuteNonQuery();
            return retorno;
        }

        public static bool AgregarPersonal(personal p)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "INSERT INTO personal (num_empleado,nombre,app_paterno,app_materno,correo,fec_nac,direccion,titulo,id_puesto,id_categoria,sueldo,fec_ingreso) VALUES (@num_empleado,@nombre,@app_paterno,@app_materno,@correo,@fec_nac,@direccion,@titulo,@id_puesto,@id_categoria,@sueldo,@fec_ingreso)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@num_empleado", p.num_empleado);
            cmd.Parameters.AddWithValue("@nombre", p.nombre);
            cmd.Parameters.AddWithValue("@app_paterno", p.app_paterno);
            cmd.Parameters.AddWithValue("@app_materno", p.app_materno);
            cmd.Parameters.AddWithValue("@correo", p.correo);
            cmd.Parameters.AddWithValue("@fec_nac", p.fec_nacimiento);
            cmd.Parameters.AddWithValue("@direccion", p.direccion);
            cmd.Parameters.AddWithValue("@titulo", p.titulo);
            cmd.Parameters.AddWithValue("@id_puesto", p.id_puesto);
            cmd.Parameters.AddWithValue("@id_categoria", p.id_categoria);
            cmd.Parameters.AddWithValue("@sueldo", p.sueldo);
            cmd.Parameters.AddWithValue("@fec_ingreso", p.fec_ingreso);
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool AgregarDescuento(descuentos p)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "INSERT INTO descuentos (id_personal,id_clasificacion_descuento,descripcion,cantidad,id_anio,id_quincena,id_usuario,fec_registro) VALUES (@id_personal,@id_clasificacion_descuento,@descripcion,@cantidad,@id_anio,@id_quincena,@id_usuario,@fec_registro)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id_personal", p.id_personal);
            cmd.Parameters.AddWithValue("@id_clasificacion_descuento", p.id_clasificacion_descuento);
            cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
            cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
            cmd.Parameters.AddWithValue("@id_anio", p.id_anio);
            cmd.Parameters.AddWithValue("@id_quincena", p.id_quincena);
            cmd.Parameters.AddWithValue("@id_usuario", p.id_usuario);
            cmd.Parameters.AddWithValue("@fec_registro", p.fec_registro);
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool AgregarNomina(nomina n)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "INSERT INTO nomina (id_anio,id_quincena,descripcion,id_status_nomina,id_usuario,fec_registro) VALUES (@id_anio,@id_quincena,@descripcion,@id_status_nomina,@id_usuario,@fec_registro)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id_anio", n.id_anio);
            cmd.Parameters.AddWithValue("@id_quincena", n.id_quincena);
            cmd.Parameters.AddWithValue("@descripcion", n.descripcion);
            cmd.Parameters.AddWithValue("@id_status_nomina", n.id_status_nomina);
            cmd.Parameters.AddWithValue("@id_usuario", n.id_usuario);
            cmd.Parameters.AddWithValue("@fec_registro", n.fec_registro);
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool AgregarProveedor(proveedores p)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "INSERT INTO proveedores (nombre,rfc,direccion,telefono,id_status,fec_registro) VALUES (@nombre,@rfc,@direccion,@telefono,@id_status,@fec_registro)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nombre", p.nombre);
            cmd.Parameters.AddWithValue("@rfc", p.rfc);
            cmd.Parameters.AddWithValue("@direccion", p.direccion);
            cmd.Parameters.AddWithValue("@telefono", p.telefono);
            cmd.Parameters.AddWithValue("@id_status", p.id_status);
            cmd.Parameters.AddWithValue("@fec_registro", p.fec_registro);
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool AgregarCliente(clientes p)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "INSERT INTO clientes (nombre,app_paterno,app_materno,rfc,direccion,telefono,id_status,fec_registro) VALUES (@nombre,@app_paterno,@app_materno,@rfc,@direccion,@telefono,@id_status,@fec_registro)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nombre", p.nombre);
            cmd.Parameters.AddWithValue("@app_paterno", p.app_paterno);
            cmd.Parameters.AddWithValue("@app_materno", p.app_materno);
            cmd.Parameters.AddWithValue("@rfc", p.rfc);
            cmd.Parameters.AddWithValue("@direccion", p.direccion);
            cmd.Parameters.AddWithValue("@telefono", p.telefono);
            cmd.Parameters.AddWithValue("@id_status", p.id_status);
            cmd.Parameters.AddWithValue("@fec_registro", p.fec_registro);
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static int AgregarCarrito(inventario i)
        {
            int retorno = 0;
            MySqlCommand SQL = new MySqlCommand(
                string.Format("INSERT INTO inventario (num_carrito,id_producto,num_inventario,total,id_usuario,id_status) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                i.num_carrito,
                i.id_producto,
                i.num_inventario,
                i.total,
                i.id_usuario,
                i.id_status), conexion.ObtenerConexion()
            );
            retorno = SQL.ExecuteNonQuery();
            return retorno;
        }

        public static void ConfirmarPago(List<inventario> datos)
        {
            foreach (var i in datos)
            {
                MySqlCommand cmd = new MySqlCommand(string.Format("UPDATE inventario SET id_status = 2 WHERE id_inventario = " + i.id_inventario + " AND id_usuario = " + i.id_usuario), conexion.ObtenerConexion());
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand();
                string query = "INSERT INTO ventas (id_inventario,fec_registro) VALUES (@id_inventario,@fec_registro)";
                cmd2.CommandText = query;
                cmd2.Parameters.AddWithValue("@id_inventario", i.id_inventario);
                cmd2.Parameters.AddWithValue("@fec_registro", DateTime.Now);
                cmd2.Connection = conexion.ObtenerConexion();
                cmd2.ExecuteNonQuery();
            }
        }

        #endregion

        #region "UPDATE"

        public static void ActualizaProducto(productos p)
        {
            MySqlCommand SQL = new MySqlCommand(string.Format("UPDATE productos SET actual_inventario = " + p.actual_inventario + " WHERE id_producto = " + p.id_producto.ToString()), conexion.ObtenerConexion());
            SQL.ExecuteNonQuery();
        }

        public static bool EditarUsuario(usuarios c)
        {
            MySqlCommand command = new MySqlCommand(string.Format("UPDATE usuarios SET nombre = '" + c.nombre + "', correo = '" + c.correo + "' WHERE id_usuario = " + c.id_usuario), conexion.ObtenerConexion());
            int rows = command.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EditarPersonal(personal c)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "UPDATE personal SET num_empleado=@num_empleado,nombre=@nombre,app_paterno=@app_paterno,app_materno=@app_materno,correo=@correo,fec_nac=@fec_nac,direccion=@direccion,titulo=@titulo,id_puesto=@id_puesto,id_categoria=@id_categoria,sueldo=@sueldo,fec_ingreso=@fec_ingreso WHERE id_personal=@id_personal";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@num_empleado", c.num_empleado);
            cmd.Parameters.AddWithValue("@nombre", c.nombre);
            cmd.Parameters.AddWithValue("@app_paterno", c.app_paterno);
            cmd.Parameters.AddWithValue("@app_materno", c.app_materno);
            cmd.Parameters.AddWithValue("@correo", c.correo);
            cmd.Parameters.AddWithValue("@fec_nac", c.fec_nacimiento);
            cmd.Parameters.AddWithValue("@direccion", c.direccion);
            cmd.Parameters.AddWithValue("@titulo", c.titulo);
            cmd.Parameters.AddWithValue("@id_puesto", c.id_puesto);
            cmd.Parameters.AddWithValue("@id_categoria", c.id_categoria);
            cmd.Parameters.AddWithValue("@sueldo", c.sueldo);
            cmd.Parameters.AddWithValue("@fec_ingreso", c.fec_ingreso);
            cmd.Parameters.AddWithValue("@id_personal", Convert.ToInt16(c.id_personal));
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EditarProveedor(proveedores c)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "UPDATE proveedores SET nombre=@nombre,rfc=@rfc,direccion=@direccion,telefono=@telefono,id_status=@id_status WHERE id_proveedor=@id_proveedor";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nombre", c.nombre);
            cmd.Parameters.AddWithValue("@rfc", c.rfc);
            cmd.Parameters.AddWithValue("@direccion", c.direccion);
            cmd.Parameters.AddWithValue("@telefono", c.telefono);
            cmd.Parameters.AddWithValue("@id_status", c.id_status);
            cmd.Parameters.AddWithValue("@id_proveedor", Convert.ToInt16(c.id_proveedor));
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EditarCliente(clientes c)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "UPDATE clientes SET nombre=@nombre,app_paterno=@app_paterno,app_materno=@app_materno,rfc=@rfc,direccion=@direccion,telefono=@telefono,id_status=@id_status WHERE id_cliente=@id_cliente";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nombre", c.nombre);
            cmd.Parameters.AddWithValue("@app_paterno", c.app_paterno);
            cmd.Parameters.AddWithValue("@app_materno", c.app_materno);
            cmd.Parameters.AddWithValue("@rfc", c.rfc);
            cmd.Parameters.AddWithValue("@direccion", c.direccion);
            cmd.Parameters.AddWithValue("@telefono", c.telefono);
            cmd.Parameters.AddWithValue("@id_status", c.id_status);
            cmd.Parameters.AddWithValue("@id_cliente", Convert.ToInt16(c.id_cliente));
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EditarDescuento(descuentos c)
        {
            MySqlCommand cmd = new MySqlCommand();
            string query = "UPDATE descuentos SET id_clasificacion_descuento=@id_clasificacion_descuento,descripcion=@descripcion,cantidad=@cantidad,id_anio=@id_anio,id_quincena=@id_quincena,id_usuario=@id_usuario,fec_registro=@fec_registro WHERE id_descuento=@id_descuento";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id_clasificacion_descuento", c.id_clasificacion_descuento);
            cmd.Parameters.AddWithValue("@descripcion", c.descripcion);
            cmd.Parameters.AddWithValue("@cantidad", c.cantidad);
            cmd.Parameters.AddWithValue("@id_anio", c.id_anio);
            cmd.Parameters.AddWithValue("@id_quincena", c.id_quincena);
            cmd.Parameters.AddWithValue("@id_usuario", c.id_usuario);
            cmd.Parameters.AddWithValue("@fec_registro", c.fec_registro);
            cmd.Parameters.AddWithValue("@id_descuento", Convert.ToInt16(c.id_descuento));
            cmd.Connection = conexion.ObtenerConexion();

            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static void ActualizaInventarioCarrito(int id_usuario, int id_producto, int num_inventario)
        {
            MySqlCommand SQL = new MySqlCommand(string.Format("UPDATE inventario SET num_inventario = " + num_inventario + " WHERE id_producto = " + id_producto + " AND id_usuario = " + id_usuario), conexion.ObtenerConexion());
            SQL.ExecuteNonQuery();
        }

        #endregion

        #region "DELETE"
        public static bool EliminarUsuario(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("DELETE FROM usuarios WHERE id_usuario = " + id), conexion.ObtenerConexion());
            int rows = command.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EliminarPersonal(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("DELETE FROM personal WHERE id_personal = " + id), conexion.ObtenerConexion());
            int rows = command.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EliminarProveedor(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("DELETE FROM proveedores WHERE id_proveedor = " + id), conexion.ObtenerConexion());
            int rows = command.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EliminarCliente (int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("DELETE FROM clientes WHERE id_cliente = " + id), conexion.ObtenerConexion());
            int rows = command.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EliminarDescuento(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("DELETE FROM descuentos WHERE id_descuento = " + id), conexion.ObtenerConexion());
            int rows = command.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool EliminarNomina(int id)
        {
            MySqlCommand command = new MySqlCommand(string.Format("DELETE FROM nomina WHERE id_nomina = " + id), conexion.ObtenerConexion());
            int rows = command.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        public static bool CancelarCarrito(int id)
        {
            MySqlCommand cmd = new MySqlCommand(string.Format("UPDATE inventario SET id_status = 3 WHERE id_usuario = " + id), conexion.ObtenerConexion());
            int rows = cmd.ExecuteNonQuery();
            bool result = false;

            if (rows > 0)
                result = true;

            return result;
        }

        #endregion

    }
}