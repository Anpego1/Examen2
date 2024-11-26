using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorUsuarios.Models
{
    public class Tecnico
    {
        public int Id { get; set; } // Identificador único del técnico
        public string Nombre { get; set; } // Nombre del técnico
        public string Especialidad { get; set; } // Especialidad del técnico (ej. Hardware, Software, etc.)
    }
}
