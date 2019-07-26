using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using LogicLayerBusiness;
using Microsoft.AspNetCore.Mvc;


namespace DominioServicesLayer.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : ControllerBase
    {


        [HttpGet]
        public ActionResult<IEnumerable<TerceroDTO>> Get()
        {
            return Ok(new TerceroBI().Get());
        }

        [HttpGet("{id}")]
        public ActionResult<TerceroDTO> GetData(int id)
        {
            return Ok(new TerceroBI().GetXId(id));
        }

        [HttpGet("buscar")]
        public ActionResult<TerceroDTO> GetFilter([FromQuery] string filter)
        {
            return Ok(new TerceroBI().GetXNombre(filter));

        }

        [HttpPost]
        public ActionResult<ResponseDTO> Post(TerceroDTO request)
        {
            if (request.TerId > 0)
            {
                //edicion
                return Ok(new TerceroBI().Crud(request, 2));
            }
            else
            {
                //insert
                return Ok(new TerceroBI().Crud(request, 1));
            }

        }

        [HttpPut]
        public ActionResult<ResponseDTO> update(TerceroDTO request)
        {
            return Ok(new TerceroBI().Crud(request, 2));
        }

        [HttpDelete("{iddemo}")]

        public ActionResult<ResponseDTO> Delete(int iddemo)
        {
            return Ok(new TerceroBI().Crud(new TerceroDTO()
            {
                TerId = iddemo
            }, 3));
        }

    }
}