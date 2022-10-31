using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zap.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email Address:")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string? Email {get; set;}
        
        [Required(ErrorMessage = "Please enter a password")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string? Password {get; set;}

        public bool IsValid { get; set; } = true;
    }
}