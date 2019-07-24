using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;
using LogicLayerBusiness.Modelo;

namespace LogicLayerBusiness
{
    public class TerceroBI
    {
        public IEnumerable<TerceroDTO> Get()
        {
            IEnumerable<TerceroDTO> objResponse = new List<TerceroDTO>();

            ConexionDTO cnn = new ConexionDTO();
            cnn.procedimiento = "GetTerceroFiltros";

            var dt = new Conexion().ConsultarSPDT(cnn);

            if (dt.Rows.Count > 0)
            {

                objResponse = Tool.DataTableToList<TerceroDTO>(dt);

            }

            return objResponse;
        }

        public TerceroDTO GetXId(int id)
        {
            TerceroDTO objResponse = new TerceroDTO();

            ConexionDTO cnn = new ConexionDTO();
            cnn.procedimiento = "GetTerceroFiltros";
            cnn.parametros.Add("@id", id);

            var dt = new Conexion().ConsultarSPDT(cnn);

            if (dt.Rows.Count > 0)
            {

                objResponse = Tool.DataTableToList<TerceroDTO>(dt).FirstOrDefault();

            }

            return objResponse;
        }


        public IEnumerable<TerceroDTO> GetXNombre(string filter)
        {
            IEnumerable<TerceroDTO> objResponse = new List<TerceroDTO>();

            ConexionDTO cnn = new ConexionDTO();
            cnn.procedimiento = "GetTerceroFiltros";
            cnn.parametros.Add("@nombre", filter);

            var dt = new Conexion().ConsultarSPDT(cnn);

            if (dt.Rows.Count > 0)
            {
                objResponse = Tool.DataTableToList<TerceroDTO>(dt);
            }

            return objResponse;
        }

        

        public ResponseDTO Crud(TerceroDTO tercero,int op)
        {
            ResponseDTO objresponse = new ResponseDTO();
            try
            {

                ConexionDTO cnn = new ConexionDTO();

                cnn.procedimiento = "CRUDTercero";

                cnn.parametros.Add("@TerId", tercero.TerId);
                cnn.parametros.Add("@TerNombre", tercero.TerNombre);
                cnn.parametros.Add("@TerNIT", tercero.TerNIT);
                cnn.parametros.Add("@TerDireccion", tercero.TerDireccion);
                cnn.parametros.Add("@TerTelefono", tercero.TerTelefono);
                cnn.parametros.Add("@TerCorreo", tercero.TerCorreo);
                cnn.parametros.Add("@Op", op);

                var dt = new Conexion().ConsultarSPDT(cnn);

                objresponse.codigo = (int) dt.Rows[0]["id"];
                 objresponse.mensaje = "";

            }
            catch (Exception e)
            {

                objresponse.codigo = -1;
                objresponse.mensaje = e.Message;
            }
            return objresponse;
        }


    }
}