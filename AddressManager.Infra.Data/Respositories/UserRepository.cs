using AddressManager.Domain.Interfaces;
using AddressManager.Domain.Models;
using AddressManager.Infra.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AddressManager.Infra.Data.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            List<User> user = await _context.users.ToListAsync();

            return user;
        }

        public async Task<User> FindById(int id)
        {
            User user = await _context.users.Where(p => p.Id == id).FirstOrDefaultAsync();

            return null;
        }

        public async Task<User> Create(User userIn)
        {
            User user = _mapper.Map<User>(userIn);
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User userIn)
        {
            User user = _mapper.Map<User>(userIn);
            _context.users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> ObterUserPorCep(string cep)
        {
            User user;

            var baseAddress = "https://viacep.com.br/ws/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            var response = client.GetAsync($"{cep}/json/").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(content);

                return user;
            }

            return null;
        }

        public async Task<bool> Delete(User userIn)
        {
            _context.users.Remove(userIn);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<User> ObterEnderecoPorCep(string cep)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
