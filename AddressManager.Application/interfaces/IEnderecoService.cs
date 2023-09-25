using AddressManager.Application.DTOs;

namespace AddressManager.Application.interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoDTO>> FindAll(int skip, int take);
        Task<EnderecoDTO> FindById(int id);
        Task<EnderecoDTO> Create(EnderecoDTOSemId enderecoDto);
        Task<EnderecoDTO> Update(EnderecoDTO enderecoDto);
        Task<bool> Delete(EnderecoDTO endereco);
        Task<EnderecoDTOSemId> ObterEnderecoPorCep(string cepDto);
    }
}
