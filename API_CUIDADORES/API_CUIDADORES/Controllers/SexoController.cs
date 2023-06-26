using Microsoft.AspNetCore.Mvc;
using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;

namespace API_CUIDADORES.Controllers
{
    [ApiController]
    [Route("api/sexos")]
    public class SexoController : ControllerBase
    {
        private readonly SexoDAO _sexoDAO;

        public SexoController()
        {
            _sexoDAO = new SexoDAO();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var sexos = _sexoDAO.Listar();
            return Ok(sexos);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] SexoDTO sexoDTO)
        {
            _sexoDAO.Cadastrar(sexoDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            SexoDAO dao = new SexoDAO();
            dao.Remover(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] SexoDTO sexoDTO)
        {
            _sexoDAO.Alterar(sexoDTO);
            return Ok();
        }
    }
}
