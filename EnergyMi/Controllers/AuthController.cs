using EnergyMi.Data;
using EnergyMi.DTO;
using EnergyMi.Models;
using EnergyMi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace EnergyMi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly AppDbContext _context;

        public AuthController(TokenService tokenService, AppDbContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDTO Usuario)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.DsEmail == Usuario.DsEmail && u.DsSenha == Usuario.DsSenha);

            if (user != null)
            {
                var token = _tokenService.GenerateToken(user.DsEmail);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}