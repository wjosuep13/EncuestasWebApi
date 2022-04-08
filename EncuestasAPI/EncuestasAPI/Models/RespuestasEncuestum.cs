using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasAPI.Models
{
    public partial class RespuestasEncuestum
    {
        public int IdRespuesta { get; set; }
        public DateTime? Fecha { get; set; }
        public string Respuestas { get; set; }
        public int IdEncuesta { get; set; }

        public virtual EncuestaTable IdEncuestaNavigation { get; set; }
    }
}
