using AutoMapper;
using AspNetCore20Example.Application.ViewModels;
using AspNetCore20Example.Domain.Contatos.Entities;
using AspNetCore20Example.Domain.Usuarios.Entities;

namespace AspNetCore20Example.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Telefone, TelefoneViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();

            CreateMap<UsuarioDados, UsuarioDadosViewModel>();
        }
    }
}