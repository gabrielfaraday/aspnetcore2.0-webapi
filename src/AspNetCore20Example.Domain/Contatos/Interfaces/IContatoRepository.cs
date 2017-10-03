using AspNetCore20Example.Domain.Contatos.Entities;
using AspNetCore20Example.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace AspNetCore20Example.Domain.Contatos.Interfaces
{
    public interface IContatoRepository : IRepositoryBase<Contato>
    {
        Contato ObterContatoPorEmail(string email);
        ICollection<Contato> ObterContatosAtivos();

        void RemoverEndereco(Guid enderecoId);

        Telefone ObterTelefonePorId(Guid telefoneId);
        Telefone AdicionarTelefone(Telefone telefone);
        Telefone AtualizarTelefone(Telefone telefone);
        void RemoverTelefone(Guid telefoneId);

    }
}
