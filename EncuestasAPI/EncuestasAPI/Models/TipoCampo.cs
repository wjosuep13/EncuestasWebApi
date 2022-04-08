using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasAPI.Models
{
    public partial class TipoCampo
    {
        public TipoCampo()
        {
            Campos = new HashSet<Campo>();
        }

        public int IdTipoCampo { get; set; }
        public string DescripcionTipo { get; set; }
        public string TipoHtml { get; set; }

        public virtual ICollection<Campo> Campos { get; set; }
    }
}
