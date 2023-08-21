using Adidas.Interfaces;
using Adidas.Models;
using Adidas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Adidas.Repositories;

namespace Adidas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.Login(dadosLogin.Email, dadosLogin.Senha);
                if(usuarioBuscado == null)
                {
                    return Unauthorized(new { msg = "Email ou Senha incorretos" });

                }

                var minhasClaims = new[] 
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("adidas-chave-autenticacao"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var newToken = new JwtSecurityToken(
                    issuer: "adidas.webapi",
                    audience: "adidas.webapi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(68),
                    signingCredentials: credenciais
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(meuToken) });
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
    }
}
