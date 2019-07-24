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
    public class ProductoController : ControllerBase
    {


        [HttpGet]
        public ActionResult<IEnumerable<ProductoDTO>> Get()
        {
            return Ok(new ProductoBI().Get());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductoDTO> GetData(int id)
        {
            return Ok(new ProductoBI().GetxId(id));
        }

        [HttpGet("buscar")]
        public ActionResult<ProductoDTO> GetFilter([FromQuery] string filter)
        {
            return Ok(new ProductoBI().GetPrductAC(filter));

        }

        [HttpPost]
        public ActionResult<ResponseDTO> Post(ProductoDTO request)
        {
            return Ok(new ProductoBI().Insert(request));
        }

        [HttpPut]
        public ActionResult<ResponseDTO> update(ProductoDTO request)
        {
            return Ok(new ProductoBI().Update(request));
        }

        [HttpDelete("{iddemo}")]

        public ActionResult<ResponseDTO> Delete(int iddemo)
        {
            return Ok(new ProductoBI().Delete(iddemo));
        }


    }
}