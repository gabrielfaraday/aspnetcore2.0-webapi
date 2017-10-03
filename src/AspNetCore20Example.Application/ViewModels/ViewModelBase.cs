using System.ComponentModel.DataAnnotations;

namespace AspNetCore20Example.Application.ViewModels
{
    public class ViewModelBase
    {
        [ScaffoldColumn(false)]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }
    }
}
