using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class contactos
    {
        public int id_contacto { get; set; }
        public int id_motivo_contacto { get; set; }
        public string pregunta { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
    }
}