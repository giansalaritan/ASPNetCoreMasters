﻿using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.BindingModels
{
    public class RegisterBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
