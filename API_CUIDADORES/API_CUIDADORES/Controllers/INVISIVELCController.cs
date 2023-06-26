using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.Controllers
{
    [Route("api/invisivelcui")]
    [ApiController]

    public class INVISIVELCController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            INVISIVELCDAO dao = new INVISIVELCDAO();
            var invisivel = dao.Listar();

            // Criar uma nova lista com os campos desejados (excluindo "cpf")
            var response = invisivel.Select(c => new
            {
                c.tipo,
                c.id,
                c.nome,
                c.sobrenome,
                c.celular,
                c.endereco,
                c.preco,
                c.link,
                c.sexo,
                c.cidade,
                c.estado,
                c.bairro,
                c.imagem
            });

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Cadastrar(INVISIVELCDTO cuidador)
        {
            INVISIVELCDAO dao = new INVISIVELCDAO();
            dao.Cadastrar(cuidador);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(INVISIVELCDTO cuidador)
        {
            INVISIVELCDAO dao = new INVISIVELCDAO();
            dao.Alterar(cuidador);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            INVISIVELCDAO dao = new INVISIVELCDAO();
            dao.Remover(id);
            return Ok();
        }
    }
}
