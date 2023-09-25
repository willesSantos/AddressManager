using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;

namespace TestProject1.Services
{
    public class EnderecoServicesTeste : IEnderecoService
    {
        public Task<EnderecoDTO> Create(EnderecoDTOSemId enderecoDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(EnderecoDTO enderecoDTO)
        {
            EnderecoDTO endereco = new EnderecoDTO
            {
                id = 1,
                cep = "08570670",
                Logradouro = "Rua Vereador Benedito Marcos Ribeiro",
                Complemento = "",
                Bairro = "Jardim Santa Helena",
                Localidade = "Itaquaquecetuba",
                Uf = "SP",
                Ibge = "3523107",
                Gia = "3797",
                Ddd = "11",
                Siafi = "6563"
            };

            bool saoIguais =
                 enderecoDTO.id == endereco.id &&
                 enderecoDTO.cep == endereco.cep &&
                 enderecoDTO.Logradouro == endereco.Logradouro &&
                 enderecoDTO.Complemento == endereco.Complemento &&
                 enderecoDTO.Bairro == endereco.Bairro &&
                 enderecoDTO.Localidade == endereco.Localidade &&
                 enderecoDTO.Uf == endereco.Uf &&
                 enderecoDTO.Ibge == endereco.Ibge &&
                 enderecoDTO.Gia == endereco.Gia &&
                 enderecoDTO.Ddd == endereco.Ddd &&
                 enderecoDTO.Siafi == endereco.Siafi;

            return Task.FromResult<bool>(saoIguais);
        }

        public Task<IEnumerable<EnderecoDTO>> FindAll(int skip, int take)
        {
            List<EnderecoDTO> endereco = new List<EnderecoDTO>();

            for (int i = 0; i < 5; i++)
            {
                endereco.Add(new EnderecoDTO
                {
                    id = 1,
                    cep = "08570670",
                    Logradouro = "Rua Vereador Benedito Marcos Ribeiro",
                    Complemento = "",
                    Bairro = "Jardim Santa Helena",
                    Localidade = "Itaquaquecetuba",
                    Uf = "SP",
                    Ibge = "3523107",
                    Gia = "3797",
                    Ddd = "11",
                    Siafi = "6563"
                });
            }

            var enderecoPaginados = endereco.Skip(skip).Take(take);

            var resultado = Task.FromResult<IEnumerable<EnderecoDTO>>(enderecoPaginados);

            return resultado;
        }


        public Task<EnderecoDTO> FindById(int id)
        {
            EnderecoDTO endereco = null;
            if (id == 1)
            {
                endereco = new EnderecoDTO
                {
                    id = 1,
                    cep = "08570670",
                    Logradouro = "Rua Vereador Benedito Marcos Ribeiro",
                    Complemento = "",
                    Bairro = "Jardim Santa Helena",
                    Localidade = "Itaquaquecetuba",
                    Uf = "SP",
                    Ibge = "3523107",
                    Gia = "3797",
                    Ddd = "11",
                    Siafi = "6563"
                };
            }
            return Task.FromResult<EnderecoDTO>(endereco);
        }

        public Task<EnderecoDTOSemId> ObterEnderecoPorCep(string cepDto)
        {
            EnderecoDTOSemId endereco = null;
            if (cepDto.Equals("08570670"))
            {
                endereco = new EnderecoDTOSemId
                {
                    cep = "08570670",
                    Logradouro = "Rua Vereador Benedito Marcos Ribeiro",
                    Complemento = "",
                    Bairro = "Jardim Santa Helena",
                    Localidade = "Itaquaquecetuba",
                    Uf = "SP",
                    Ibge = "3523107",
                    Gia = "3797",
                    Ddd = "11",
                    Siafi = "6563"
                };
            }
            return Task.FromResult<EnderecoDTOSemId>(endereco);
        }

        public Task<EnderecoDTO> Update(EnderecoDTO enderecoDto)
        {
            return Task.FromResult<EnderecoDTO>(enderecoDto);
        }
    }
}
