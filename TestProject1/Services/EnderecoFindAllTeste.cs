using AddressManager.Application.DTOs;

namespace TestProject1.Services
{
    public class EnderecoFindAllTeste
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
        public void RetornaNenhumENderecoSkypMaiorQueAQuantidadeDeEnderecos()
        {
            var prodMock = new EnderecoServicesTeste().FindAll(6, 2);

            Assert.Equal(0, prodMock.Result.Count());
        }

        [Fact]
        public void RetornaNenhumEnderecoTakeNegativo()
        {
            var prodMock = new EnderecoServicesTeste().FindAll(0, -2);

            Assert.Equal(0, prodMock.Result.Count());
        }
    }
}