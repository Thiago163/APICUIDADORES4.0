using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    [Authorize]

    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            UsuariosDAO dao = new UsuariosDAO();
            var cuidador = dao.Listar();
            return Ok(cuidador);
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuariosDTO cuidador)
        {
            UsuariosDAO dao = new UsuariosDAO();
            dao.Cadastrar(cuidador);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(UsuariosDTO cuidador)
        {
            UsuariosDAO dao = new UsuariosDAO();
            dao.Alterar(cuidador);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            UsuariosDAO dao = new UsuariosDAO();
            dao.Remover(id);
            return Ok();
        }
    }
}
