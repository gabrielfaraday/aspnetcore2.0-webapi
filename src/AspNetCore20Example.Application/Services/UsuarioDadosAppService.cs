using AspNetCore20Example.Application.Interfaces;
using AspNetCore20Example.Application.ViewModels;
using AspNetCore20Example.Domain.Usuarios.Entities;
using AspNetCore20Example.Domain.Usuarios.Interfaces;
using AutoMapper;
using AspNetCore20Example.Domain.Core.Interfaces;

namespace AspNetCore20Example.Application.Services
{
    public class UsuarioDadosAppService : AppServiceBase<UsuarioDados, UsuarioDadosViewModel, IUsuarioDadosService>, IUsuarioDadosAppService
    {
        public UsuarioDadosAppService(IUnitOfWork uow, IUsuarioDadosService service, IMapper mapper) : base(uow, service, mapper)
        {
        }
    }
}
