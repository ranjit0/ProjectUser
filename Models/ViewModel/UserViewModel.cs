using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectUser.Models.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
    
        public string UserName { get; set; }
     

        public string Password { get; set; }
        public string RetypePassword { get; set; }






        public string Usertype { get; set; }
      
        public string FullName { get; set; }
     

    }
}