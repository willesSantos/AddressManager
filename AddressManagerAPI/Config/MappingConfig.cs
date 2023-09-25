using AddressManagerAPI.Model;
using AddressManagerAPI.Model.Input;
using AddressManagerAPI.Model.Output;
using AutoMapper;

namespace AddressManagerAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EnderecoIn, Endereco>();
                config.CreateMap<Endereco, EnderecoIn>();
                config.CreateMap<Endereco, EnderecoOut>();
                config.CreateMap<EnderecoOut, Endereco>();
                config.CreateMap<EnderecoIn, EnderecoOut>();
                config.CreateMap<EnderecoOut, EnderecoIn>();

            });
            return mappingConfig;
        }
    }
}
