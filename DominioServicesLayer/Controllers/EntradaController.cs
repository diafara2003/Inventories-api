using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;

using LogicLayerBusiness;
using LogicLayerBusiness.Modelo;

using Microsoft.AspNetCore.Mvc;


namespace DominioServicesLayer.Controllers {

    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase {

     [HttpGet]
        public ActionResult<IEnumerable<EntradaDTO>> Get()
        {
            return Ok(new EntradaBI().Get());
        }

        [HttpGet("{id}")]
        public ActionResult<EntradaDTO> GetXId(int id) {
            return Ok(new EntradaBI().GetXId(id));
        }

        [HttpGet("Estado/{estado}")]
        public ActionResult<IEnumerable<EntradaDTO>> GetEntriesState(int estado)
        {
            return Ok(new EntradaBI().GetState(estado));
        }


        [HttpPost]
        public ActionResult<ResponseDTO> Post(EntradaDTO entrada)
        {
            return Ok(new EntradaBI().Insert(entrada));
        }


        [HttpPut]
        public ActionResult<ResponseDTO> UpdateEntry(EntradaDTO modelo)
        {
            return Ok(new EntradaBI().Update(modelo));
        }

        [HttpPut("cambiarEstado")]
        public ActionResult<ResponseDTO> ApproveEntry(AprobarEntradaDTO modelo) {
            return Ok(new EntradaBI().CambiarEstado(modelo));
        }

        [HttpDelete("{identrada}")]
        public ActionResult<ResponseDTO> DeleteEntry(int identrada)
        {
            return Ok(new EntradaBI().Delete(identrada));
        }

    }
}