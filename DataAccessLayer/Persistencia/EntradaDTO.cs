using System;
using System.Collections.Generic;

namespace DataAccessLayer {

    public class EntradaDTO {
        public int EnId { get; set; }
        public int EnProveedor { get; set; }
        public DateTime EnFecha { get; set; }
        public int? EnEstado { get; set; }
        public int? EnUsuarioCrea { get; set; }
        public DateTime? EnFechaRegitro { get; set; }
        public int? EnUsuarioModifica { get; set; }
        public DateTime? EnFechaModifica { get; set; }
        public string EnObservacion { get; set; }

        public List<EntradaDetalleDTO> EntradaDetalle { get; set; }
        public TerceroDTO terceroEntrada { get; set; }
    }
}