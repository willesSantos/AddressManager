using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;
using AddressManager.Domain.Models;
using AddressManager.Domain.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressManager.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _repository;
        private readonly IUrlHelper _urlHelper;
        private readonly SqlContext _context;
        private readonly IHeteoas _hateoas;

        public EnderecoController(IEnderecoService repository, IUrlHelper urlHelper, SqlContext context, IHeteoas hateoas)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
            _urlHelper = urlHelper;
            _context = context;
            _hateoas = hateoas;
        }

        [HttpGet(template:"skip/{skip:int}/take/{take:int}")]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> FindAll(int skip, int take)
        {
            try
            {
                IEnumerable<EnderecoDTO> endereco = await _repository.FindAll(skip, take);

                if (!endereco.Any())
                {
                    return Content("Cep No Content");
                }

                int total = await _context.endereco.CountAsync();

                return Ok(new
                {
                    Total = total,
                    Data = endereco
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet(template:"{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> FindById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Address Bad Request");
                }

                EnderecoDTO enderecoDTO = await _repository.FindById(id);

                if (enderecoDTO == null)
                {
                    return Content("Address No Content");
                }

                var hateoas = _hateoas.GetLinks(id);

                return Ok(new
                {
                    Data = enderecoDTO,
                    Link = hateoas
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] EnderecoDTOSemId enderecoDTO)
        {
            try
            {
                if (enderecoDTO == null)
                {
                    return BadRequest("Address Bad Request");
                }

                EnderecoDTOSemId buscaViaCep = await _repository.ObterEnderecoPorCep(enderecoDTO.cep);

                if (buscaViaCep == null)
                {
                    return Content("Address No Content");
                }

                EnderecoDTO enderecoCriado = await _repository.Create(enderecoDTO);

                Created(_urlHelper.RouteUrl(Create), enderecoCriado);

                var hateoas = _hateoas.GetLinks(enderecoCriado.id);

                return Ok(new
                {
                    Data = enderecoCriado,
                    Link = hateoas
                });;
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Endereco>> Update([FromBody] EnderecoDTO enderecoDTO)
        {
            try
            {
                if (enderecoDTO == null)
                {
                    return BadRequest("Address Bad Request");
                }

                EnderecoDTO endereco = await _repository.FindById(enderecoDTO.id);

                if (endereco == null)
                {
                    return Content("Address No Content");
                }

                EnderecoDTO enderecoAlterado = await _repository.Update(enderecoDTO);

                var hateoas = _hateoas.GetLinks(enderecoDTO.id);

                return Ok(new
                {
                    enderecoDTO,
                    Link = hateoas
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpDelete(template: "{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Address Bad Request");
                }

                EnderecoDTO endereco = await _repository.FindById(id);

                if (endereco == null)
                {
                    return Content("Address No Content");
                }

                bool status = await _repository.Delete(endereco);

                if (!status)
                {
                    return Problem("Internal Error");
                }

                var hateoas = _hateoas.GetLinks(id);

                return Ok(new
                {
                    endereco,
                    Link = hateoas
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
