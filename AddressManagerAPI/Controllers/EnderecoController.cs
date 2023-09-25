using AddressManagerAPI.Model;
using AddressManagerAPI.Model.Input;
using AddressManagerAPI.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EnderecoOut = AddressManagerAPI.Model.Output.EnderecoOut;

namespace AddressManagerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _repository;
        private readonly IUrlHelper _urlHelper;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoRepository repository, IMapper mapper, IUrlHelper urlHelper)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
            _mapper = mapper;
            _urlHelper = urlHelper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoOut>>> FindAll()
        {
            try
            {
                IEnumerable<Endereco> endereco = _repository.FindAll();

                if (!endereco.Any())
                {
                    return Content("Cep No Content");
                }

                return Ok(endereco);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<IEnumerable<EnderecoOut>>> FindByCep(string cep)
        {
            try
            {
                if (cep == null)
                {
                    return BadRequest("Cep Bad Request");
                }

                Endereco endereco = _repository.FindByCep(cep);

                if (endereco == null)
                {
                    return Content("Cep No Content");
                }

                EnderecoOut enderecoOut = _mapper.Map<EnderecoOut>(endereco);

                return Ok(enderecoOut);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpPost]
        public ActionResult Create([FromBody] EnderecoIn enderecoIn)
        {
            EnderecoOut enderecoOut;
            try
            {
                if (enderecoIn == null)
                {
                    return BadRequest("Address Bad Request");
                }

                Endereco buscaViaCep = _repository.ObterEnderecoPorCep(enderecoIn.cep);

                if (buscaViaCep == null)
                {
                    return Content("Cep No Content");
                }

                Endereco endereco = _repository.FindByCep(enderecoIn.cep);

                if (endereco != null)
                {
                    return Conflict("Cep Conflict");
                }

                bool status = _repository.Create(enderecoIn);
                enderecoOut = _mapper.Map<EnderecoOut>(enderecoIn);

                return Created(_urlHelper.RouteUrl(Create), enderecoOut);                
            }            
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Endereco>> Update([FromBody] EnderecoIn enderecoIn)
        {
            try
            {
                if (enderecoIn == null)
                {
                    return BadRequest("Address Bad Request");
                }

                Endereco endereco = _repository.FindByCep(enderecoIn.cep);

                if (endereco == null)
                {
                    return Content("Cep No Content");
                }

                bool status = _repository.Update(enderecoIn);

                EnderecoOut enderecoOut = _mapper.Map<EnderecoOut>(enderecoIn);

                return Ok(enderecoOut);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpDelete("{cep}")]
        public async Task<ActionResult> Delete(string cep)
        {
            try
            {
                if (cep == null)
                {
                    return BadRequest("cep Bad Request");
                }

                Endereco endereco = _repository.FindByCep(cep);

                if (endereco == null)
                {
                    return Content("Cep No Content");
                }

                bool status = _repository.Delete(endereco);

                if (!status)
                {
                    return Problem("Internal Error");
                }

                EnderecoOut enderecoOut = _mapper.Map<EnderecoOut>(endereco);

                return Ok(enderecoOut);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }
    }
}
