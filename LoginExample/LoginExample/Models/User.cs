using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginExample.Models
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}