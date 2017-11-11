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
        public Endereco endereco { get; set; }
        public object telefoneEmAlteracao { get; set; }
        public Validationresult1 validationResult { get; set; }
    }

    public class Endereco
    {
        public string id { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public object complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public Validationresult validationResult { get; set; }
    }

    public class Validationresult
    {
        public bool isValid { get; set; }
        public object[] errors { get; set; }
    }

    public class Validationresult1
    {
        public bool isValid { get; set; }
        public object[] errors { get; set; }
    }

}
