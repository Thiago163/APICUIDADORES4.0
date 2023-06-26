using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_CUIDADORES.Controllers
{
    namespace API_CUIDADORES.Controllers
    {
        [Route("api/cadusu")]
        [ApiController]

        public class CadastrousuController : ControllerBase
        {

            [HttpPost]
            public IActionResult Cadastrar(UsuariosDTO usuario)
            {
                UsuariosDAO dao = new UsuariosDAO();
                dao.Cadastrar(usuario);
                return Ok();
            }
        }
    }
}
