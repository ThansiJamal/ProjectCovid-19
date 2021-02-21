using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCovid_19.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
       ErrorMessage = "Please Enter Correct Email Address")]
        public string Username{ get; set; }

        [Required(ErrorMessage = "password reqired")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "Password must be string ang maximum length should be 7")]
        public string Password { get; set; }
    }
}