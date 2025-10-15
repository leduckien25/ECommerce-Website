using System.ComponentModel.DataAnnotations;

namespace WebApplicationMvc.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
