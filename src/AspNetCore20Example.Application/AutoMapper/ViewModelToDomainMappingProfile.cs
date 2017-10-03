using AutoMapper;
using AspNetCore20Example.Application.ViewModels;
using AspNetCore20Example.Domain.Contatos.Entities;
using AspNetCore20Example.Domain.Usuarios.Entities;

namespace AspNetCore20Example.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContatoViewModel, Contato>()
                .ConstructUsing(c => new Contato(c.Id, c.Nome, c.Email, c.DataNascimento));

            CreateMap<TelefoneViewModel, Telefone>()
                .ConstructUsing(t => new Telefone(t.Id, t.DDD, t.Numero, t.ContatoId));

            CreateMap<EnderecoViewModel, Endereco>()
                .ConstructUsing(e => new Endereco(e.Id, e.Logradouro, e.Numero, e.Complemento, e.Bairro, e.CEP, e.Cidade, e.Estado));


            CreateMap<UsuarioDadosViewModel, UsuarioDados>()
                .ConstructUsing(u => new UsuarioDados(u.Id, u.Nome, u.CPF));
        }
    }
}