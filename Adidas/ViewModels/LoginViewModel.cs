﻿using System.ComponentModel.DataAnnotations;
namespace Adidas.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }
    }
}
