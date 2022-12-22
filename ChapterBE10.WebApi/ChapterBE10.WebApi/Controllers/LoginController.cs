using ChapterBE10.WebApi.Interfaces;
using ChapterBE10.WebApi.Models;
using ChapterBE10.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ChapterBE10.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _iUsuarioRepository= usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new { msg = "Email e/ou Senha inválido" });
                }
                //define os dados que serao fornecidos no token (payload)
                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                };
                //define a chave de acesso ao token
                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapterbe10-key-authenticator"));
                //define as credencias do token = header
                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                //gera o token
                var meuToken = new JwtSecurityToken(
                    issuer: "ChapterBE10.WebApi",
                    audience: "ChapterBE10.WebApi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credenciais
                    );
                return Ok(
                    new { token = new JwtSecurityTokenHandler().WriteToken(meuToken) }
                    );
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
