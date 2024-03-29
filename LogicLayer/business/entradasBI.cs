using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;
using LogicLayerBusiness.Modelo;

namespace LogicLayerBusiness
{

    public class EntradaBI
    {

        public IEnumerable<EntradaDTO> Get()
        {
            IEnumerable<EntradaDTO> objResponse = new List<EntradaDTO>();

            ConexionDTO cnn = new ConexionDTO();
            cnn.procedimiento = "GetEntradafiltros";

            var dt = new Conexion().ConsultarSPDT(cnn);

            if (dt.Rows.Count > 0)
            {

                objResponse = Tool.DataTableToList<EntradaDTO>(dt);

                foreach (EntradaDTO item in objResponse)
                {
                    item.terceroEntrada = new TerceroBI().GetXId(item.EnProveedor);
                }

            }

            return objResponse;
        }

        public IEnumerable<EntradaDTO> GetState(int state = -1)
        {
            IEnumerable<EntradaDTO> objResponse = new List<EntradaDTO>();

            ConexionDTO cnn = new ConexionDTO();
            cnn.procedimiento = "GetEntradafiltros";
            cnn.parametros.Add("@state", state);

            var dt = new Conexion().ConsultarSPDT(cnn);

            if (dt.Rows.Count > 0)
            {

                objResponse = Tool.DataTableToList<EntradaDTO>(dt);

                foreach (EntradaDTO item in objResponse)
                {
                    item.terceroEntrada = new TerceroBI().GetXId(item.EnProveedor);
                }

            }

            return objResponse;
        }

        public EntradaDTO GetXId(int id)
        {
            EntradaDTO objResponse = new EntradaDTO();

            ConexionDTO cnn = new ConexionDTO();
            cnn.procedimiento = "GetEntradafiltros";
            cnn.parametros.Add("@id", id);

            var dt = new Conexion().ConsultarSPDT(cnn);

            if (dt.Rows.Count > 0)
            {
                int id_tercero = (int)dt.Rows[0]["EnProveedor"];
                objResponse = Tool.DataTableToList<EntradaDTO>(dt).FirstOrDefault();
                objResponse.EntradaDetalle = new EntradaDetalleBI().GetxIdEntrada(id);
                objResponse.terceroEntrada = new TerceroBI().GetXId(id_tercero);

            }

            return objResponse;
        }


        public ImpresionEntradaDTO Impresion(int id)
        {

            ImpresionEntradaDTO objresponse = new ImpresionEntradaDTO();

            try
            {
                ConexionDTO cnn = new ConexionDTO();
                cnn.procedimiento = "ImprimirEntrada";
                cnn.parametros.Add("idEntrada", id);


                var ds = new Conexion().ConsultarSPDS(cnn);

                objresponse = Tool.DataTableToList<ImpresionEntradaDTO>(ds.Tables[0]).FirstOrDefault();
                objresponse.detalles = Tool.DataTableToList<ImpresionEntradaDetalleDTO>(ds.Tables[1]);


            }
            catch (System.Exception e)
            {

                throw e;
            }

            return objresponse;
        }
        public ResponseDTO CambiarEstado(AprobarEntradaDTO modelo)
        {

            ResponseDTO objresponse = new ResponseDTO();

            try
            {

                ConexionDTO cnn = new ConexionDTO();
                cnn.procedimiento = "ActualizarEntradaEstado";
                cnn.parametros.Add("EnId", modelo.Identrada);
                cnn.parametros.Add("EnEstado", modelo.estado);

                objresponse.codigo = 1;
                objresponse.mensaje = string.Empty;

                new Conexion().ConsultarSPDT(cnn);

            }
            catch (System.Exception e)
            {

                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;
            }

            return objresponse;
        }

        public ResponseDTO Update(EntradaDTO modelo)
        {

            ResponseDTO objresponse = new ResponseDTO();

            objresponse.codigo = modelo.EnId;
            objresponse.mensaje = string.Empty;

            ConexionDTO cnn = new ConexionDTO();
            cnn.procedimiento = "ActualizarEntrada";
            cnn.parametros.Add("EnId", modelo.EnId);
            cnn.parametros.Add("EnProveedor", modelo.EnProveedor);
            cnn.parametros.Add("EnObservacion", modelo.EnObservacion);
            cnn.parametros.Add("EnUsuarioModifica", modelo.EnUsuarioModifica);

            try
            {
                var dt = new Conexion().ConsultarSPDT(cnn);

                if (modelo.EntradaDetalle != null)
                {
                    foreach (var item in modelo.EntradaDetalle)
                    {
                        item.EndDetEntradaId = modelo.EnId;
                        new EntradaDetalleBI().Insert(item);
                    }
                }

            }
            catch (System.Exception e)
            {
                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;

            }

            return objresponse;

        }

        public ResponseDTO Insert(EntradaDTO modelo)
        {

            ResponseDTO objresponse = new ResponseDTO();
            ConexionDTO cnn = new ConexionDTO();

            objresponse.mensaje = "Se creó la entrada correctamente";

            try
            {
                cnn.procedimiento = "InsertarEntrada";
                cnn.parametros.Add("EnProveedor", modelo.EnProveedor);
                cnn.parametros.Add("EnUsuarioCrea", modelo.EnUsuarioCrea);
                cnn.parametros.Add("EnObservacion", modelo.EnObservacion);

                var dt = new Conexion().ConsultarSPDT(cnn);

                objresponse.codigo = (int)dt.Rows[0]["id"];

                if (modelo.EntradaDetalle != null)
                {
                    foreach (var item in modelo.EntradaDetalle)
                    {
                        item.EndDetEntradaId = objresponse.codigo;
                        new EntradaDetalleBI().Insert(item);
                    }
                }

            }
            catch (System.Exception e)
            {

                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;
            }

            return objresponse;
        }

        public ResponseDTO Delete(int id)
        {

            ResponseDTO objresponse = new ResponseDTO();
            ConexionDTO cnn = new ConexionDTO();
            cnn.procedimiento = "EliminarEntradas";
            cnn.parametros.Add("id", id);
            objresponse.codigo = 1;
            objresponse.mensaje = string.Empty;

            try
            {
                var dt = new Conexion().ConsultarSPDT(cnn);
            }
            catch (System.Exception e)
            {
                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;

            }

            return objresponse;

        }

    }

}