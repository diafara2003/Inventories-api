namespace DataAccessLayer {

    public class ProductoDTO {
        public int ProdId { get; set; }
        public string ProdNombre { get; set; }
        public string ProdUM { get; set; }
        public string ProdCategoria { get; set; }
        public decimal? ProdPrecioCompra { get; set; }
        public decimal? ProdPrecioVenta { get; set; }
    }

}