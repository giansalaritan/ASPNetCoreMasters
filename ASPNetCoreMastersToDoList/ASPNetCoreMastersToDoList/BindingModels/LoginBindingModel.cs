using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.BindingModels
{
    public class LoginBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
