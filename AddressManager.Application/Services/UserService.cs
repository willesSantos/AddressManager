using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;
using AddressManager.Domain.Interfaces;
using AddressManager.Domain.Models;
using AutoMapper;

namespace AddressManager.Application.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var createUser = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(createUser);
        }

        public async Task<UserDTO> Delete(int id)
        {
            var DeleteUser = await _userRepository.Delete(id);
            return _mapper.Map<UserDTO>(DeleteUser);
        }

        public async Task<IEnumerable<UserDTO>> FindAll()
        {
            var usuarios = await _userRepository.FindAll();
            return _mapper.Map<IEnumerable<UserDTO>>(usuarios);
        }

        public async Task<UserDTO> FindById(int id)
        {
            var usuario = _userRepository.FindById(id);
            return _mapper.Map<UserDTO>(usuario);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var UpdateUser = await _userRepository.Update(user);
            
            return _mapper.Map<UserDTO>(UpdateUser);
        }
    }
}
