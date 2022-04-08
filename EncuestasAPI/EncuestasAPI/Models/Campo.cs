using System;
using System.Collections.Generic;

#nullable disable

namespace EncuestasAPI.Models
{
    public partial class Campo
    {
        public int IdCampo { get; set; }
        public string NombreCampo { get; set; }
        public string TituloCampo { get; set; }
        public bool EsRequerido { get; set; }
        public int IdTipoCampo { get; set; }
        public int IdEncuesta { get; set; }

        public virtual EncuestaTable IdEncuestaNavigation { get; set; }
        public virtual TipoCampo IdTipoCampoNavigation { get; set; }
    }
}
