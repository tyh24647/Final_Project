using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models {
    public class UserModel {
        [Required]
        [MinLength(1)]
        public string Username { get; set; }

        [Required]
        [MinLength(1)]
        public string Password { get; set; }
    } 
}
