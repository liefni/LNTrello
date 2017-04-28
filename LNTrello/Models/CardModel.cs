using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNTrello.Models
{
    public class CardModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }
}