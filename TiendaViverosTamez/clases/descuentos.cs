using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class descuentos
    {
        public int id_descuento { get; set; }
        public int id_personal { get; set; }
        public string nombre_completo { get; set; }
        public int id_clasificacion_descuento { get; set; }
        public string txt_clasificacion_descuento { get; set; }
        public string descripcion { get; set; }
        public float cantidad { get; set; }
        public int id_anio { get; set; }
        public string anio { get; set; }
        public int id_quincena { get; set; }
        public string quincena { get; set; }
        public int id_usuario { get; set; }
        public DateTime fec_registro { get; set; }
    }
}