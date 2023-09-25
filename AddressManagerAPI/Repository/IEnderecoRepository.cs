using AddressManagerAPI.Model;
using AddressManagerAPI.Model.Input;

namespace AddressManagerAPI.Repository
{
    public interface IEnderecoRepository
    {
        IEnumerable<Endereco> FindAll();
        Endereco FindByCep(string cep);
        bool Create(EnderecoIn endereco);
        bool Update(EnderecoIn vo);
        bool Delete(Endereco cep);
        Endereco ObterEnderecoPorCep(string cep);
    }
}
