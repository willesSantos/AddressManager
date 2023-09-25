using AddressManager.Application.DTOs.Hateoas;
using AddressManager.Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace AddressManager.Application.Services
{
    public class HateoasService : IHeteoas
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IConfiguration _configuration;

        public HateoasService(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor, IConfiguration configuration)
        {
            _actionContextAccessor = actionContextAccessor;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
            _configuration = configuration;
        }

        public List<Link> GetLinks(int id)
        {
            var links = new List<Link>
            {
                new Link(_configuration["Hateoas:Protocol"] + _urlHelper.Action("FindById", "Endereco", new { id = id }), "self", "GET"),
                new Link(_configuration["Hateoas:Protocol"] + _urlHelper.Action("Create", "Endereco", new RouteValueDictionary()), "self", "POST"),
                new Link(_configuration["Hateoas:Protocol"] + _urlHelper.Action("Update", "Endereco", new RouteValueDictionary()), "self", "PUT"),
                new Link(_configuration["Hateoas:Protocol"] + _urlHelper.Action("Delete", "Endereco", new { id = id }), "self", "DELETE")
            };
            return links;
        }
    }    
}
