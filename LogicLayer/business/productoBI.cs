using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;

namespace LogicLayerBusiness {

    public class ProductoBI {
        public IEnumerable<ProductoDTO> Get () {

            IEnumerable<ProductoDTO> objResponse = new List<ProductoDTO> ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "productoConsulta";

            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objResponse = Tool.DataTableToList<ProductoDTO> (dt);

            }

            return objResponse;
        }

        public ProductoDTO GetxId (int id) {

            ProductoDTO objResponse = new ProductoDTO ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "productoConsulta";
            cnn.parametros.Add ("@id", id);

            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objResponse = Tool.DataTableToList<ProductoDTO> (dt).FirstOrDefault();                

            }

            return objResponse;
        }

        public IEnumerable<ProductoDTO> GetPrductAC (string filter) {
            IEnumerable<ProductoDTO> objResponse = new List<ProductoDTO> ();

            ConexionDTO cnn = new ConexionDTO ();
            cnn.procedimiento = "productoConsulta";
            cnn.parametros.Add ("@nombre", filter);

            var dt = new Conexion ().ConsultarSPDT (cnn);

            if (dt.Rows.Count > 0) {

                objResponse = Tool.DataTableToList<ProductoDTO> (dt);

            }

            return objResponse;
        }

        public ResponseDTO Update (ProductoDTO prod) {
            ResponseDTO objresponse = new ResponseDTO ();
            try {

                ConexionDTO cnn = new ConexionDTO ();

                cnn.procedimiento = "ActualizarProducto";

                cnn.parametros.Add ("@ProdId", prod.ProdId);
                cnn.parametros.Add ("@ProdNombre", prod.ProdNombre);
                cnn.parametros.Add ("@ProdUM", prod.ProdUM);
                cnn.parametros.Add ("@ProdCategoria", prod.ProdCategoria);
                cnn.parametros.Add ("@ProdPrecioCompra", prod.ProdPrecioCompra);
                cnn.parametros.Add ("@ProdPrecioVenta", prod.ProdPrecioVenta);

                var dt = new Conexion ().ConsultarSPDT (cnn);

            } catch (Exception e) {

                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;
            }
            return objresponse;
        }

        ResponseDTO validarProducto (ProductoDTO modelo) {
            ResponseDTO objresponse = new ResponseDTO ();
            objresponse.codigo = 1;
            objresponse.mensaje = string.Empty;

            return objresponse;
        }

        public ResponseDTO Insert (ProductoDTO prod) {
            ResponseDTO objresponse = new ResponseDTO ();
            try {

                ConexionDTO cnn = new ConexionDTO ();

                cnn.procedimiento = "InsertarProducto";

                cnn.parametros.Add ("@ProdNombre", prod.ProdNombre);
                cnn.parametros.Add ("@ProdUM", prod.ProdUM);
                cnn.parametros.Add ("@ProdCategoria", prod.ProdCategoria);
                cnn.parametros.Add ("@ProdPrecioCompra", prod.ProdPrecioCompra);
                cnn.parametros.Add ("@ProdPrecioVenta", prod.ProdPrecioVenta);

                var dt = new Conexion ().ConsultarSPDT (cnn);

                objresponse.codigo = (int) dt.Rows[0]["id"];
                objresponse.mensaje = "";

            } catch (Exception e) {

                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;
            }

            return objresponse;

        }

        public ResponseDTO Delete (int id) {
            ResponseDTO objresponse = new ResponseDTO ();
            try {
                ConexionDTO cnn = new ConexionDTO ();

                cnn.procedimiento = "EliminarProducto";
                cnn.parametros.Add ("@id", id);

                objresponse.codigo = 1;
                objresponse.mensaje = string.Empty;
            } catch (Exception e) {

                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;
            }
            return objresponse;
        }
    }
}