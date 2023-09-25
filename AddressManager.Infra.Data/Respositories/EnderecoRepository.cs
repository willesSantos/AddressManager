using AddressManager.Domain.Interfaces;
using AddressManager.Domain.Models.Context;
using AddressManager.Domain.Models;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace AddressManager.Infra.Data.Respositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly SqlContext _context;
        private readonly IMapper _mapper;

        public EnderecoRepository(SqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Endereco>> FindAll(int skip, int take)
        {
            List<Endereco> enderecos = await _context.endereco
            .OrderBy(e => e.id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

            return enderecos;
        }

        public async Task<Endereco> FindById(int id)
        {
            Endereco endereco = await _context.endereco.Where(p => p.id == id).FirstOrDefaultAsync();

            return endereco;
        }

        public async Task<Endereco> Create(Endereco enderecoIn)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoIn);
            _context.endereco.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> Update(Endereco enderecoIn)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoIn);
            _context.endereco.Update(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        public async Task<Endereco> ObterEnderecoPorCep(string cep)
        {
            Endereco endereco;

            var baseAddress = "https://viacep.com.br/ws/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            var response = client.GetAsync($"{cep}/json/").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                endereco = JsonConvert.DeserializeObject<Endereco>(content);
                endereco.cep = endereco.cep.Replace("-", "");

                return endereco;
            }

            return null;
        }

        public async Task<bool> Delete(Endereco enderecoIn)
        {
            _context.endereco.Remove(enderecoIn);
            await _context.SaveChangesAsync();

            return true;
        }
        
    }
}
