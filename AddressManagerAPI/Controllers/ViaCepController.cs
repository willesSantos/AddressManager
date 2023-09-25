using AddressManagerAPI.Model;
using AddressManagerAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AddressManagerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ViaCepController : ControllerBase
    {
        private IEnderecoRepository _repository;

        public ViaCepController(IEnderecoRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<IEnumerable<Endereco>>> BuscaViaCep(string cep)
        {
            try
            {
                Endereco endereco = _repository.ObterEnderecoPorCep(cep);

                if (endereco == null)
                {
                    return StatusCode(204, "Cep No Content");
                }

                return Ok(endereco);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }            
        }
    }
}
