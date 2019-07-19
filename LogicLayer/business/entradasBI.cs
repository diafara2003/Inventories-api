using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;

namespace LogicLayerBusiness {

    public class EntradaBI {

        public IEnumerable<EntradaDTO> Get () {
            IEnumerable<EntradaDTO> objresonse = new List<EntradaDTO> ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "GetAllEntrada";

            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objresonse = Tool.DataTableToList<EntradaDTO> (dt);

            }

            return objresonse;
        }

        public IEnumerable<EntradaDTO> GetState (int state = -1) {
            IEnumerable<EntradaDTO> objresonse = new List<EntradaDTO> ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "GetAllEntrada";
            cnn.parametros.Add ("state", state);

            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objresonse = Tool.DataTableToList<EntradaDTO> (dt);

            }

            return objresonse;
        }

        public Entrada GetXId (int id) {
            IEnumerable<EntradaDTO> objresonse = new List<EntradaDTO> ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "GetAllEntrada";
            cnn.parametros.Add ("id", id);

            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objresonse = Tool.DataTableToList<EntradaDTO> (dt);

            }

            return objresonse;
        }

    }

}