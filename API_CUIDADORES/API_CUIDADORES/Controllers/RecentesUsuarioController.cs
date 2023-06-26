using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_CUIDADORES.Controllers
{
    [ApiController]
    [Route("api/recentesusu")]
    [Authorize]

    public class RecentesUsuarioController : ControllerBase
    {
        private RecentesUsuarioDAO RecentesUsuarioDAO;

        public RecentesUsuarioController()
        {
            RecentesUsuarioDAO = new RecentesUsuarioDAO();
        }

        [HttpGet]
        public IActionResult Listar(int id)
        {
            var recentes = RecentesUsuarioDAO.Listar(id);
            return Ok(recentes);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] RecentesUsuarioDTO recente)
        {
            try
            {
                RecentesUsuarioDAO.Cadastrar(recente);
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
            RecentesUsuarioDAO.Remover(usuario_id, cuidador_id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] RecentesUsuarioDTO recente)
        {
            RecentesUsuarioDAO.Alterar(recente);
            return Ok();
        }
    }
}