using Microsoft.AspNetCore.Mvc;
using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using System.Collections.Generic;

namespace API_CUIDADORES.Controllers
{
    [ApiController]
    [Route("api/tipos")]
    public class TipoController : ControllerBase
    {
        private readonly TiposDAO _tiposDAO;

        public TipoController()
        {
            _tiposDAO = new TiposDAO();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            List<TipoDTO> tipos = _tiposDAO.Listar();
            return Ok(tipos);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] TipoDTO tipoDTO)
        {
            _tiposDAO.Cadastrar(tipoDTO);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            TiposDAO dao = new TiposDAO();
            dao.Remover(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(TipoDTO cuidador)
        {
            TiposDAO dao = new TiposDAO();
            dao.Alterar(cuidador);
            return Ok();
        }
    }
}
