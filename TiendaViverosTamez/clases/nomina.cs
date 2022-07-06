using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class nomina
    {
        public int id_nomina { get; set; }
        public int id_anio { get; set; }
        public string anio { get; set; }
        public int id_quincena { get; set; }
        public string quincena { get; set; }
        public string descripcion { get; set; }
        public int id_status_nomina { get; set; }
        public string status_nomina { get; set; }
        public int id_usuario { get; set; }
        public DateTime fec_registro { get; set; }
    }
}