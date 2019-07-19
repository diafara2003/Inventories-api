namespace DataAccessLayer {

    public class EntradaDetalleDTO {

        public int EnDetId { get; set; }
        public int EndDetEntradaId { get; set; }
        public int EnDetProuctoId { get; set; }
        public decimal EnDetCantidad { get; set; }
        public decimal EnDetVrUnit { get; set; }
        public decimal EnDetPrcIva { get; set; }
        public decimal EnDetVrIva { get; set; }
        public decimal EnDetVrTotal { get; set; }

        public virtual ProductoDTO EnDetProucto { get; set; }
    }

}