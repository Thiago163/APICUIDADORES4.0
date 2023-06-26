using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_CUIDADORES.Controllers
{
    [ApiController]
    [Route("api/recentescui")]
    [Authorize]

    public class RecentesCuidadorController : ControllerBase
    {
        private RecentesCuidadorDAO RecentesCuidadorDAO;

        public RecentesCuidadorController()
        {
            RecentesCuidadorDAO = new RecentesCuidadorDAO();
        }

        [HttpGet]
        public IActionResult Listar(int id)
        {
            var recentes = RecentesCuidadorDAO.Listar(id);
            return Ok(recentes);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] RecentesCuidadorDTO recente)
        {
            try
            {
                RecentesCuidadorDAO.Cadastrar(recente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{usuario_id}/{cuidador_id}")]
        public IActionResult Remover(int usuario_id, int cuidador_id)
        {
            RecentesCuidadorDAO.Remover(usuario_id, cuidador_id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] RecentesCuidadorDTO recente)
        {
            RecentesCuidadorDAO.Alterar(recente);
            return Ok();
        }
    }
}