using AddressManager.Application.DTOs.Hateoas;

namespace AddressManager.Application.interfaces
{
    public interface IHeteoas
    {
        List<Link> GetLinks(int id);
    }
}
