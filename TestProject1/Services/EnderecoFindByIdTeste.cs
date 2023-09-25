using AddressManager.Application.DTOs;

namespace TestProject1.Services
{
    public class EnderecoFindByIdTeste
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

        [Fact]
        public void RetornarNullIdInexistente()
        {
            EnderecoDTO prodMock = new EnderecoServicesTeste().FindById(2).Result;

            Assert.Null(prodMock);
        }
    }
}