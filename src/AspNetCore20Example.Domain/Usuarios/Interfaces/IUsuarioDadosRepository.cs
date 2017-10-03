using AspNetCore20Example.Domain.Core.Interfaces;
using AspNetCore20Example.Domain.Usuarios.Entities;

namespace AspNetCore20Example.Domain.Usuarios.Interfaces
{
    public interface IUsuarioDadosRepository : IRepositoryBase<UsuarioDados>
    {
        UsuarioDados ObterUsuarioPorCPF(string cpf);
    }
}
