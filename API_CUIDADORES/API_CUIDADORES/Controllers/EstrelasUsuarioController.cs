using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_CUIDADORES.Controllers
{
    [ApiController]
    [Route("api/estrelasusu")]
    [Authorize]

    public class EstrelasUsuarioController : ControllerBase
    {
        private EstrelasUsuarioDAO EstrelasUsuarioDAO;
        public EstrelasUsuarioController()
        {
            EstrelasUsuarioDAO = new EstrelasUsuarioDAO();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var estrelas = EstrelasUsuarioDAO.Listar();
            return Ok(estrelas);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] EstrelasUsuarioDTO EstrelasUsuarioDTO)
        {
            try
            {
                EstrelasUsuarioDAO.Cadastrar(EstrelasUsuarioDTO);
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
            EstrelasUsuarioDAO dao = new EstrelasUsuarioDAO();
            dao.Remover(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(EstrelasUsuarioDTO cuidador)
        {
            EstrelasUsuarioDAO dao = new EstrelasUsuarioDAO();
            dao.Alterar(cuidador);
            return Ok();
        }
    }
}
