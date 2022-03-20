﻿using Services.DTO;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.BindingModels
{
    public class ItemCreateBindingModel
    {

        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Text { get; set; }
        public ItemDTO Map()
        {
            return new ItemDTO
            {
                Text = Text
            };
        }
    }
}
