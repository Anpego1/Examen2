using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorUsuarios.Models
{
    public class Usuario
    {
        public int Id { get; set; } // Identificador único del usuario
        public string Nombre { get; set; } // Nombre del usuario
        public string Correo { get; set; } // Correo electrónico del usuario
        public string Telefono { get; set; } // Teléfono del usuario
    }
}
