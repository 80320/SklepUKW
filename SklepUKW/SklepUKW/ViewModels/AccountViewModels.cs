using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepUKW.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail!")]
        [Required(ErrorMessage = "Musisz podać Email!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Musisz podać hasło!")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj Mnie")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail!")]
        [Required(ErrorMessage = "Musisz podać Email!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Musisz podać hasło!")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło:")]
        [Required(ErrorMessage = "Musisz podać oba hasła!")]
        [Compare("Password", ErrorMessage = "Hasła muszą być jednakowe!")]
        public string ConfirmPassword { get; set; }
    }
}