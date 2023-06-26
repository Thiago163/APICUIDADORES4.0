using API_CUIDADORES.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CUIDADORES.Controllers
{
    [Route("api/site")]
    [ApiController]
    public class SiteController : Controller
    {
        [HttpGet]
        public IActionResult Listar()
        {
            CuidadoresDAO dao = new CuidadoresDAO();
            var cuidadores = dao.Listar();

            // Criar uma nova lista com os campos desejados (excluindo "cpf")
            var response = cuidadores.Select(c => new
            {
                c.id,
                c.nome,
                c.sobrenome,
                c.data_de_nasc,
                c.celular,
                c.endereco,
                c.email,
                c.preco,
                c.descricao,
                c.imagem,
                c.link,
                c.sexo,
                c.cidade,
                c.estado,
                c.bairro
            });

            return Ok(response);
        }
    }
}
