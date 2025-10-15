using System.ComponentModel.DataAnnotations;

namespace WebApplicationMvc.ViewModels
{
    public class ConfirmPasswordViewModel
    {
        [Required]

        public string Password { get; set; }
    }
}
