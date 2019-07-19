using System.Collections.Generic;

namespace DataAccessLayer {

    public class ConexionDTO {
       

        public string procedimiento { get; set; }
        public Dictionary<string, object> parametros { get; set; }
    }  
}