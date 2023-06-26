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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CuidadoresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            CuidadoresDAO dao = new CuidadoresDAO();
            var cuidador = dao.Listar();
            return Ok(cuidador);
        }

        [HttpPost]
        public IActionResult Cadastrar(CuidadoresDTO cuidador)
        {
            CuidadoresDAO dao = new CuidadoresDAO();
            dao.Cadastrar(cuidador);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(CuidadoresDTO cuidador)
        {
            CuidadoresDAO dao = new CuidadoresDAO();
            dao.Alterar(cuidador);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            CuidadoresDAO dao = new CuidadoresDAO();
            dao.Remover(id);
            return Ok();
        }
    }
}
