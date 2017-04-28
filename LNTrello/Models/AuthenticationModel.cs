using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNTrello.Models
{
    public class AuthenticationModel
    {
        [Display(Name = "User Token")]
        [Required]
        public string UserToken { get; set; }
    }
}