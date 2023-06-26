using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_CUIDADORES.DAO;
using API_CUIDADORES.DTO;

namespace API_CUIDADORES.Controllers
{
    [Route("api/loginusu")]
    [ApiController]
    public class AuthUsuariosController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromForm] string login, [FromForm] string senha)
        {

            var usuarioDAO = new UsuariosDAO();

            var usuario = usuarioDAO.Login(login, senha);

            if (usuario.id == 0)
            {
                return BadRequest("Usuário ou senha inválidos");
            }

            var token = GenerateJwtToken(usuario, "16b564d8e7b9b32a36edf518df48e40c35aeb933ce4abab8e75fd3e5ef89a7f6");

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }
            else
            {
                // Lógica de tratamento caso o token seja nulo ou vazio
                return BadRequest("Falha ao gerar o token JWT");
            }
        }

        public string GenerateJwtToken(UsuariosDTO usuario, string secretKey)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("ID", usuario.id.ToString()),
                new Claim("Email", usuario.email),
                new Claim("cpf", usuario.cpf)
            };

            var token = new JwtSecurityToken(
                "",
                "",
                claims,
                expires: DateTime.UtcNow.AddDays(90),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    [Route("api/logincui")]
    [ApiController]
    public class AuthCuidadoresController : ControllerBase
    {

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromForm] string login, [FromForm] string senha)
        {

            var cuidadoresDAO = new CuidadoresDAO();

            var cuidador = cuidadoresDAO.Login(login, senha);

            if (cuidador.id == 0)
            {
                return BadRequest("Usuário ou senha inválidos");
            }

            var token = GenerateJwtToken(cuidador, "16b564d8e7b9b32a36edf518df48e40c35aeb933ce4abab8e75fd3e5ef89a7f6");

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }
            else
            {
                // Lógica de tratamento caso o token seja nulo ou vazio
                return BadRequest("Falha ao gerar o token JWT");
            }
        }

        public string GenerateJwtToken(CuidadoresDTO cuidador, string secretKey)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("ID", cuidador.id.ToString()),
                new Claim("Email", cuidador.email),
                new Claim("cpf", cuidador.cpf)
            };

            var token = new JwtSecurityToken(
                "",
                "",
                claims,
                expires: DateTime.UtcNow.AddDays(90),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
