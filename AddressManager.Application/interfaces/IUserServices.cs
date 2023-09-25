using AddressManager.Application.DTOs;

namespace AddressManager.Application.interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDTO>> FindAll();
        Task<UserDTO> FindById(int id);
        Task<UserDTO> Create(UserDTO user);
        Task<UserDTO> Update(UserDTO user);
        Task<UserDTO> Delete(int id);
    }
}
