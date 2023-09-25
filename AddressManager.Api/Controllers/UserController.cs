using AddressManager.Api.Models;
using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;
using AddressManager.Domain.Interfaces;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressManager.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IAccount _authenticateService;

        public UserController(IAccount authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("Credenciais inválidas");
            }

            var email = loginDTO.Email;
            var senha = loginDTO.Password;

            bool verificacao = await _authenticateService.UserExists(email);

            if (!verificacao)
            {
                return BadRequest("User Invalid");
            }

            var isAuthenticated = await _authenticateService.AuthenticateAsync(email, senha);

            if (!isAuthenticated)
            {
                return Unauthorized("Credenciais inválidas");
            }

            var token = await _authenticateService.GenerateToken(3, email);

            return Ok(new { Token = token });
        }
    }
}
