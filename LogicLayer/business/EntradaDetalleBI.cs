using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;

namespace LogicLayerBusiness {
    public class EntradaDetalleBI {

        public List<EntradaDetalleDTO> GetxIdEntrada (int id) {

            List<EntradaDetalleDTO> objresponse = new List<EntradaDetalleDTO> ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "ConsultarDetalle";
            cnn.parametros.Add ("@idEntrada", id);
 
 
            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objresponse = Tool.DataTableToList<EntradaDetalleDTO> (dt);

                foreach (var item in objresponse) {
                    item.EnDetProucto = new ProductoBI ().GetxId (item.EnDetProuctoId);
                }

            }

            return objresponse;
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

        public ResponseDTO Insert (EntradaDetalleDTO modelo) {

            ConexionDTO cnn = new ConexionDTO ();
            ResponseDTO objresponse = new ResponseDTO ();
            objresponse.mensaje = string.Empty;

            cnn.procedimiento = "InsertarDetalleEntrada";
            cnn.parametros.Add ("@EndDetEntradaId", modelo.EndDetEntradaId);
            cnn.parametros.Add ("@EnDetProuctoId", modelo.EnDetProuctoId);
            cnn.parametros.Add ("@EnDetCantidad", modelo.EnDetCantidad);
            cnn.parametros.Add ("@EnDetVrUnit", modelo.EnDetVrUnit);
            cnn.parametros.Add ("@EnDetVrTotal", modelo.EnDetVrTotal);

            var dt = new Conexion ().ConsultarSPDT (cnn);

            objresponse.codigo = (int) dt.Rows[0]["id"];

            return objresponse;
        }

    }
}