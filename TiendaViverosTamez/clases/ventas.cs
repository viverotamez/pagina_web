using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class ventas
    {
        public int id_venta { get; set; }
        public int id_inventario { get; set; }
        public DateTime fec_registro { get; set; }
        public float total { get; set; }
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string nombre_usuario { get; set; }
        public int num_carrito { get; set; }
    }
}