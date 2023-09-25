using AddressManager.Domain.Interfaces;
using AddressManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AddressManager.Infra.Data.Identity
{
    public class AutenthicateService : IAccount
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;

        public AutenthicateService(ApplicationDBContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }

        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            var usuario = await _context.users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return false;
            }

            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            if (string.Equals(computerHash.ToString(), senha, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UserExists(string email)
        {
            var usuario = await _context.users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return false;
            }

            return true;
        }

        public async Task<string> GenerateToken(int id, string email)
        {
            var claims = new[]
            {
               new Claim("id", id.ToString()),
               new Claim("email", email),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
           };

            var privateKKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));

            var credentials = new SigningCredentials(privateKKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:secretKey"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }    
    }
}
