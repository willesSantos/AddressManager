using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;
using AddressManager.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressManager.Api.Controllers
{
    public class ViaCepController : Controller
    {
        private IEnderecoService _repository;

        public ViaCepController(IEnderecoService repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<EnderecoDTO>> BuscaViaCep(string cep)
        {
            try
            {
                EnderecoDTOSemId endereco = await _repository.ObterEnderecoPorCep(cep);

                if (endereco == null)
                {
                    return Content("Cep No Content");
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
