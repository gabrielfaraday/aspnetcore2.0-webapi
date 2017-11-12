using System;

namespace AspNetCore20Example.Services.API.Integration.Tests.DTOs
{
    public class ContatoJsonDTO
    {
        public bool success { get; set; }
        public ContatoDTO data { get; set; }
    }

    public class ContatoDTO
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dataCadastro { get; set; }
        public bool ativo { get; set; }
        public string ativadoPor { get; set; }
        public object dataNascimento { get; set; }
        public string enderecoId { get; set; }
        public object[] telefones { get; set; }
        public EnderecoDTO endereco { get; set; }
        public object telefoneEmAlteracao { get; set; }
        public ValidationresultDTO validationResult { get; set; }
    }

    public class EnderecoDTO
    {
        public string id { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public object complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public ValidationresultDTO validationResult { get; set; }
    }

    public class ValidationresultDTO
    {
        public bool isValid { get; set; }
        public object[] errors { get; set; }
    }
}
