using AddressManager.Domain.Models;

namespace AddressManager.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> FindAll(int skip, int take);
        Task<Endereco> FindById(int id);
        Task<Endereco> Create(Endereco enderecoIn);
        Task<Endereco> Update(Endereco enderecoIn);
        Task<bool> Delete(Endereco enderecoIn);
        Task<Endereco> ObterEnderecoPorCep(string cep);
    }
}
