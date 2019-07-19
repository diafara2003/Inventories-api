using System.Collections.Generic;

namespace DataAccessLayer {

    public class ConexionDTO {

        public ConexionDTO () {
            parametros = new Dictionary<string, object> ();
        }

        
        public string procedimiento { get; set; }
        public Dictionary<string, object> parametros { get; set; }
    }
}