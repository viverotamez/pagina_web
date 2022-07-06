using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class usuarios
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public int id_tipo_usuario { get; set; }
    }
}