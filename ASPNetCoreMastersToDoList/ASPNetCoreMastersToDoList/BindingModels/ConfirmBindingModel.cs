using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.BindingModels
{
    public class ConfirmBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
