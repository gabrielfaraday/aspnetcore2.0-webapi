using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore20Example.Application.ViewModels
{
    public class UsuarioDadosViewModel : ViewModelBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é requerido")]
        [StringLength(11)]
        public string CPF { get; set; }
    }
}
