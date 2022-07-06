using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class inventario
    {
        public int id_inventario { get; set; }
        public int id_producto { get; set; }
        public int num_inventario { get; set; }
        public double total { get; set; }
        public string descripcion { get; set; }
        public float precio { get; set; }
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string usuario { get; set; }
        public int id_status { get; set; }
        public string status { get; set; }
        public int num_carrito { get; set; }
    }
}