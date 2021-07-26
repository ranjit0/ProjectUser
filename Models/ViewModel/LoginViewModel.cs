using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectUser.Models.ViewModel
{
    public class LoginViewModel
    {
        public string UserName{get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public bool RememberMe { get; set; }
    }
}