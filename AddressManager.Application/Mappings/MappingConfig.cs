using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressManager.Application.DTOs;
using AddressManager.Domain.Models;
using AutoMapper;

namespace AddressManager.Application.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Endereco, EnderecoDTO>();
                config.CreateMap<EnderecoDTO, Endereco>();
                config.CreateMap<Endereco, EnderecoDTOSemId>();
                config.CreateMap<EnderecoDTOSemId, Endereco>();
                config.CreateMap<User, UserDTO>();
                config.CreateMap<UserDTO, User>();

            });
            return mappingConfig;
        }
    }
}
