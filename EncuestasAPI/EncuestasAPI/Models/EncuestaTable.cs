using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasAPI.Models
{
    public partial class EncuestaTable
    {
        public EncuestaTable()
        {
            Campos = new HashSet<Campo>();
            RespuestasEncuesta = new HashSet<RespuestasEncuestum>();
        }

        public int IdEncuesta { get; set; }
        public string NombreEncuesta { get; set; }
        public string DescripcionEncuesta { get; set; }
        public string Link { get; set; }

        public virtual ICollection<Campo> Campos { get; set; }
        public virtual ICollection<RespuestasEncuestum> RespuestasEncuesta { get; set; }
    }
}
