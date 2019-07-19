using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;

namespace LogicLayerBusiness {

    public class UsuarioBI {

        public IEnumerable<UsuarioDTO> Get () {
            IEnumerable<UsuarioDTO> objresonse = new List<UsuarioDTO> ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "GetAllUser";
            
            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objresonse = Tool.DataTableToList<UsuarioDTO> (dt);

            }

            return objresonse;
        }

        public UsuarioDTO GerUser (string user, string pass) {
            UsuarioDTO objresonse = new UsuarioDTO ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "ObtenerUsuario";
            cnn.parametros.Add ("usu", user);
            cnn.parametros.Add ("pass", pass);

            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objresonse = Tool.DataTableToList<UsuarioDTO> (dt).FirstOrDefault ();

            }

            return objresonse;
        }

    }
}