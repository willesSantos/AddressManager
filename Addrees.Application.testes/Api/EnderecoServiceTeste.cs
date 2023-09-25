using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;
using AddressManager.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Addrees.Application.testes.Api
{
    public class EnderecoServiceTeste
    {
        EnderecoDTO enderecoDto = new EnderecoDTO
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

        [Fact]
        public void TestarTodosOsEnderecos()
        {
            List<EnderecoDTO> listaDeEnderecos = new List<EnderecoDTO> { enderecoDto };

            // Suponhamos que prodMock seja uma IEnumerable<EnderecoDTO>.
            IEnumerable<EnderecoDTO> prodMock = (IEnumerable<EnderecoDTO>) new EnderecoRepositoryFake().FindAll(0, 1);

            // Converta prodMock em uma lista.
            var prodMockList = new List<EnderecoDTO>(prodMock);

            Assert.Equal(prodMock, listaDeEnderecos);
        }


    }
}
