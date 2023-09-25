using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManager.Domain.Interfaces
{
    public interface IAccount
    {
        Task<bool> AuthenticateAsync(string email, string senha);
        Task<bool> UserExists(string email);
        Task<string> GenerateToken(int id, string email);
    }
}
