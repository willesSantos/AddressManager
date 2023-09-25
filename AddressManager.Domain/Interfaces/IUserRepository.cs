using AddressManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAll();
        Task<User> FindById(int id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(int id);
    }
}
