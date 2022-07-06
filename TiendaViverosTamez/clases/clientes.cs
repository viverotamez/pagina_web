using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class clientes
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string app_paterno { get; set; }
        public string app_materno { get; set; }
        public string rfc { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int id_status { get; set; }
        public string status { get; set; }
        public DateTime fec_registro { get; set; }
    }
}