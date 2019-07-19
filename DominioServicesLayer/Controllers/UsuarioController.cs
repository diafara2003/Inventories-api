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
    public class UsuarioController : ControllerBase {

        public ActionResult<IEnumerable<UsuarioDTO>> Get () {
            return Ok (new UsuarioBI ().Get ());
        }

        [HttpGet ("validar")]

        public ActionResult<UsuarioDTO> GetUser ([FromQuery] string user, [FromQuery] string password) {
            if (string.IsNullOrEmpty (user) || string.IsNullOrEmpty (password)) {
                return BadRequest ("los parametros de user y password son obligatorios");
            } else {
                return Ok (new UsuarioBI ().GerUser (password, user));
            }

        }

    }
}