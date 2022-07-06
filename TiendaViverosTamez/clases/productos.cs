using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class productos
    {
        public int id_producto { get; set; }
        public string descripcion { get; set; }
        public int actual_inventario { get; set; }
        public int total_inventario { get; set; }
        public float precio { get; set; }
        public string url_imagen { get; set; }
    }
}