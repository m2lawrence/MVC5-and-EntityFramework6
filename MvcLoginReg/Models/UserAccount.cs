//Michael Lawrence BSc (HONS).
//This is my Model with validation.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add this below:
using System.ComponentModel.DataAnnotations;

namespace MvcLoginReg.Models
{
    public class UserAccount
    {
        //add constants in database table and will be my Key.
        [Key]
        public int UserID { get; set; }

        //add varification with help of data mutations to the Model here.
        //the required attribute forces the user to fill that field.
        [Required(ErrorMessage ="First Name is required.")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } 
    }
}