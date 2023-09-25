using AddressManager.Application.DTOs;

namespace TestProject1.Services
{
    public class EnderecoDeleteTeste
    {
        EnderecoDTO endereco = new EnderecoDTO
        {
            id = 1,
            cep = "08570671",
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
        public void RetornarFalseEnderecoDiferente()
        {
            bool prodMock = new EnderecoServicesTeste().Delete(endereco).Result;

            Assert.False(prodMock);
        }
    }
}