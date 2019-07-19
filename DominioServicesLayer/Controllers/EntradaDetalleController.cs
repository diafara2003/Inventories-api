using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using LogicLayerBusiness;
using Microsoft.AspNetCore.Mvc;


namespace DominioServicesLayer.Controllers {

    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class EntradaDetalleController : ControllerBase {

     [HttpDelete("{iddetalle}")]
        public ActionResult<ResponseDTO> DeleteDetailEntry(int iddetalle)
        {
            return Ok(new EntradaDetalleBI().Delete(iddetalle));
        }

    }
}