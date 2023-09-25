using AddressManagerAPI.Model;
using AddressManagerAPI.Model.Context;
using AddressManagerAPI.Model.Input;
using AutoMapper;
using Newtonsoft.Json;

namespace AddressManagerAPI.Repository
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

        public bool Create(EnderecoIn enderecoIn)
        {            
            Endereco endereco = _mapper.Map<Endereco>(enderecoIn);
            _context.endereco.Add(endereco);
            _context.SaveChangesAsync();

            return true;
            
        }

        public IEnumerable<Endereco> FindAll()
        {
            List<Endereco> endereco = _context.endereco.ToList();

            return endereco;            
        }

        public Endereco FindByCep(string cep)
        {
            Endereco endereco = _context.endereco.Where(p => p.Cep == cep).FirstOrDefault();

            return endereco;
        }

        public bool Update(EnderecoIn enderecoIn)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoIn);
            _context.endereco.Update(endereco);
            _context.SaveChanges();

            return true;            
        }

        public bool Delete(Endereco endereco)
        {
            _context.endereco.Remove(endereco);
            _context.SaveChanges();

            return true;            
        }

        public Endereco ObterEnderecoPorCep(string cep)
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
                endereco.Cep = endereco.Cep.Replace("-", "");

                return endereco;
            }

            return null;

        }
       
    }
}
