using System.ComponentModel.DataAnnotations;

namespace ChapterBE10.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O email é obrigatório!")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="A senha é obrigatória!")]
        public string? Senha { get; set; }
    }
}
