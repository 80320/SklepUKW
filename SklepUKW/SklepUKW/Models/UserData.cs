using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepUKW.Models
{
    public class UserData
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [EmailAddress(ErrorMessage = "Błędny adres email!")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Podaj poprawny numer telefonu!")]
        public string PhoneNumber { get; set; }

    }
}