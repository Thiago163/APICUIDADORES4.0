using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_CUIDADORES.Controllers
{
    [ApiController]
    [Route("api/estrelascui")]
    [Authorize]
    public class EstrelasCuidadorController : ControllerBase
    {
        private EstrelasCuidadorDAO EstrelasCuidadorDAO;
        public EstrelasCuidadorController()
        {
            EstrelasCuidadorDAO = new EstrelasCuidadorDAO();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var estrelas = EstrelasCuidadorDAO.Listar();
            return Ok(estrelas);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] EstrelasCuidadorDTO EstrelasCuidadorDTO)
        {
            try
            {
                EstrelasCuidadorDAO.Cadastrar(EstrelasCuidadorDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            EstrelasCuidadorDAO dao = new EstrelasCuidadorDAO();
            dao.Remover(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(EstrelasCuidadorDTO cuidador)
        {
            EstrelasCuidadorDAO dao = new EstrelasCuidadorDAO();
            dao.Alterar(cuidador);
            return Ok();
        }
    }
}
