namespace TestProject1.Services
{
    public class EnderecoBuscaViaCepTeste
    {
        [Fact]
        public void RetornarNuloQuandoN�oExistirCep()
        {
            var prodMock = new EnderecoServicesTeste().ObterEnderecoPorCep("08570671").Result;

            Assert.Null(prodMock);
        }
    }
}