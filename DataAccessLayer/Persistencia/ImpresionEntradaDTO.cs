
using System.Collections.Generic;
namespace DataAccessLayer
{

    public class ImpresionEntradaDTO
    {

        public string EnFecha { get; set; }
        public string Usuario { get; set; }
        public string TerNombre { get; set; }
        public string TerDireccion { get; set; }
        public string TerNIT { get; set; }
        public string TerFelefono { get; set; }
        public string TerCorreo { get; set; }
        public decimal EnSubTotal { get; set; }
        public decimal MyProperEnSubTotalty { get; set; }
        public decimal EnVrTotal { get; set; }

        public IEnumerable<ImpresionEntradaDetalleDTO> detalles { get; set; }
    }


    public class ImpresionEntradaDetalleDTO
    {
        public int ProdId { get; set; }
        public string ProdNombre { get; set; }
        public string ProdUM { get; set; }
        public decimal EnDetCantidad { get; set; }
        public decimal EnDetVrUnit { get; set; }
        public decimal EnDetVrTotal { get; set; }


    }
}