namespace DataAccessLayer {
    public class UsuarioDTO {
        public int UsuId { get; set; }
        public string UsuUsuario { get; set; }
        public string UsuClave { get; set; }
        public bool? UsuActivo { get; set; }
        public int? UsuIntentos { get; set; }
    }
}