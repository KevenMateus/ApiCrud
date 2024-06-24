using ApiCrud.Domain.Dto;
using ApiCrud.Domain.Entities;
using AutoMapper;

namespace ApiCrud.Service.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();
        }
    }
}
