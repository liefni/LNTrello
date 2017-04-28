using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNTrello.Models
{
    public class CommentModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(16384)]
        public string Comment { get; set; }
    }
}