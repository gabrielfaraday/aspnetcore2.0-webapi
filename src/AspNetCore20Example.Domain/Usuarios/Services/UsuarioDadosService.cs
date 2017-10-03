using AspNetCore20Example.Domain.Usuarios.Interfaces;
using AspNetCore20Example.Domain.Usuarios.Entities;
using AspNetCore20Example.Domain.Core;
using FluentValidation.Results;

namespace AspNetCore20Example.Domain.Usuarios.Services
{
    public class UsuarioDadosService : ServiceBase<UsuarioDados, IUsuarioDadosRepository>, IUsuarioDadosService
    {
        public UsuarioDadosService(IUsuarioDadosRepository repository) : base(repository)
        {
        }

        public override UsuarioDados Add(UsuarioDados entity)
        {
            if (!entity.EstaValido() || CPFJaFoiCadastrado(entity))
                return entity;

            return _repository.Add(entity);
        }

        private bool CPFJaFoiCadastrado(UsuarioDados entity)
        {
            if (_repository.ObterUsuarioPorCPF(entity.CPF) != null)
            {
                entity
                    .ValidationResult.Errors
                    .Add(new ValidationFailure("CPF", "O CPF informado já foi cadastrado anteriormente."));

                return true;
            }

            return false;
        }
    }
}