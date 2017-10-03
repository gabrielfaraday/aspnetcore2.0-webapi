using AutoMapper;
using AspNetCore20Example.Application.Interfaces;
using AspNetCore20Example.Application.ViewModels;
using AspNetCore20Example.Domain.Contatos.Entities;
using AspNetCore20Example.Domain.Contatos.Interfaces;
using AspNetCore20Example.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace AspNetCore20Example.Application.Services
{
    public class ContatoAppService : AppServiceBase<Contato, ContatoViewModel, IContatoService>, IContatoAppService
    {
        public ContatoAppService(IContatoService contatoService, IUnitOfWork uow, IMapper mapper) : base(uow, contatoService, mapper)
        {
        }

        public override void Delete(Guid id)
        {
            var contato = FindById(id);
            _service.RemoverEndereco(contato.EnderecoId);
            base.Delete(id);
        }

        public ICollection<ContatoViewModel> ObterAtivos()
        {
            return _mapper.Map<ICollection<ContatoViewModel>>(_service.ObterAtivos());
        }

        public ContatoViewModel ObterPorEmail(string email)
        {
            return _mapper.Map<ContatoViewModel>(_service.ObterPorEmail(email));
        }

        public TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = _service.AdicionarTelefone(_mapper.Map<Telefone>(telefoneViewModel));

            if (telefone.ValidationResult.IsValid)
                Commit();

            return _mapper.Map<TelefoneViewModel>(telefone);
        }

        public TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = _service.AtualizarTelefone(_mapper.Map<Telefone>(telefoneViewModel));

            if (telefone.ValidationResult.IsValid)
                Commit();

            return _mapper.Map<TelefoneViewModel>(telefone);
        }

        public void RemoverTelefone(Guid id)
        {
            _service.RemoverTelefone(id);
            Commit();
        }

        public TelefoneViewModel ObterTelefonePorId(Guid id)
        {
            return _mapper.Map<TelefoneViewModel>(_service.ObterTelefonePorId(id));
        }
    }
}
