using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zap.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name:")]
        [MaxLength(200)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name:")]
        [MaxLength(200)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email Address:")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [MaxLength(200)]
        public string? Email {get; set;}

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string? Password {get; set;}

        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password:")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword {get; set;}

        public enum ActionState
        {
            OK,
            DuplicateUserName,
        }

        public ActionState State { get; set; } = ActionState.OK;
    }
}