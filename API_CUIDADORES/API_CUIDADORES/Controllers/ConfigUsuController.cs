using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_CUIDADORES.Controllers
{
    [ApiController]
    [Route("api/ConfigUsu")]
    [Authorize]
    public class ConfigUsuController : ControllerBase
    {
        private readonly ConfigUsuDAO configUsuDAO;

        public ConfigUsuController()
        {
            configUsuDAO = new ConfigUsuDAO();
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] int id)
        {
            try
            {
                var usuarios = configUsuDAO.Listar(id);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar usuários: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            ConfigUsuDAO dao = new ConfigUsuDAO();
            dao.Remover(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(UsuariosDTO usuario)
        {
            ConfigUsuDAO dao = new ConfigUsuDAO();
            dao.Alterar(usuario);
            return Ok();
        }
    }
}
