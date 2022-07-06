using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class personal
    {
        public int id_personal { get; set; }
        public string num_empleado { get; set; }
        public string nombre_completo { get; set; }
        public string nombre { get; set; }
        public string app_paterno { get; set; }
        public string app_materno { get; set; }
        public string correo { get; set; }
        public DateTime fec_nacimiento { get; set; }
        public string direccion { get; set; }
        public string titulo { get; set; }
        public int id_puesto { get; set; }
        public string puesto { get; set; }
        public int id_categoria { get; set; }
        public string categoria { get; set; }
        public string sueldo { get; set; }
        public DateTime fec_ingreso { get; set; }
        public float descuento { get; set; }
        public float total { get; set; }
    }
}