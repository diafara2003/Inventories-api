using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;

namespace LogicLayerBusiness {
    public class EntradaDetalleBI {

        public List<EntradaDetalleDTO> GetxIdEntrada (int id) {

            List<EntradaDetalleDTO> objresonse = new List<EntradaDetalleDTO> ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "ConsultarDetalle";
            cnn.parametros.Add ("@idEntrada", id);
 
 
            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objresonse = Tool.DataTableToList<EntradaDetalleDTO> (dt);

            }

            return objresonse;
        }

        public ResponseDTO Delete (int id) {

            ResponseDTO objresponse = new ResponseDTO ();
            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "EliminarDetalleEntrada";
            cnn.parametros.Add ("id", id);
            objresponse.codigo = 1;
            objresponse.mensaje = string.Empty;

            try {
                var dt = new Conexion ().ConsultarSPDT (cnn);
            } catch (System.Exception e) {
                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;

            }

            return objresponse;

        }

    }
}