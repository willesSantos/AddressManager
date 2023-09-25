using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;
using AddressManager.Domain.Interfaces;
using AddressManager.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addrees.Application.testes.Api
{
    public class EnderecoRepositoryFake : IEnderecoService
    {
        public Task<EnderecoDTO> Create(EnderecoDTOSemId enderecoDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(EnderecoDTO endereco)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EnderecoDTO>> FindAll(int skip, int take)
        {
            var endereco = new EnderecoDTO
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

            var listaDeEnderecos = new List<EnderecoDTO> { endereco };

            return await Task.FromResult<IEnumerable<EnderecoDTO>>(listaDeEnderecos);
        }

        public Task<EnderecoDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoDTOSemId> ObterEnderecoPorCep(string cepDto)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoDTO> Update(EnderecoDTO enderecoDto)
        {
            throw new NotImplementedException();
        }
    }
}
