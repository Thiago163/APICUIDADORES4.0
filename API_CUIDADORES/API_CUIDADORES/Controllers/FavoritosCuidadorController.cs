using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_CUIDADORES.Controllers
{
    [ApiController]
    [Route("api/favoritoscui")]
    [Authorize]

    public class FavoritosCuidadorController : ControllerBase
    {
        private FavoritosCuidadorDAO FavoritosCuidadorDAO;
        public FavoritosCuidadorController()
        {
            FavoritosCuidadorDAO = new FavoritosCuidadorDAO();
        }

        [HttpGet]
        public IActionResult Listar(int id)
        {
            var favoritos = FavoritosCuidadorDAO.Listar(id);
            return Ok(favoritos);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FavoritosCuidadorDTO FavoritosCuidadorDTO)
        {
            try
            {
                var favoritoJaExiste = FavoritosCuidadorDAO.FavoritoJaExiste(FavoritosCuidadorDTO);

                if (favoritoJaExiste)
                {
                    return Ok();
                }
                FavoritosCuidadorDAO.Cadastrar(FavoritosCuidadorDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Remover(int usuario_id, int cuidador_id)
        {
            FavoritosCuidadorDAO dao = new FavoritosCuidadorDAO();
            dao.Remover(usuario_id, cuidador_id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(FavoritosCuidadorDTO cuidador)
        {
            FavoritosCuidadorDAO dao = new FavoritosCuidadorDAO();
            dao.Alterar(cuidador);
            return Ok();
        }
    }
}
