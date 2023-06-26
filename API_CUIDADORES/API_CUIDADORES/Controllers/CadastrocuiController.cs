using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_CUIDADORES.Controllers
{
    namespace API_CUIDADORES.Controllers
    {
        [Route("api/cadcui")]
        [ApiController]

        public class CadastrocuiController : ControllerBase
        {

            [HttpPost]
            public IActionResult Cadastrar(CuidadoresDTO cuidador)
            {
                CuidadoresDAO dao = new CuidadoresDAO();
                dao.Cadastrar(cuidador);
                return Ok();
            }
        }
    }
}
