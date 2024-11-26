using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorUsuarios.Models
{
    public class Equipo
    {
        public int Id { get; set; } // Identificador único del equipo
        public string Tipo { get; set; } // Tipo de equipo (ej. Laptop, Escritorio, etc.)
        public string Modelo { get; set; } // Modelo del equipo
        public int UsuarioId { get; set; } // Relación con el usuario propietario

        // Propiedad de navegación para el Usuario
        public Usuario Usuario { get; set; }
    }
}
