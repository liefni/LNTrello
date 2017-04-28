using LNTrello.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LNTrello.Models;

namespace LNTrello.Tests.TestRepositories
{
    public class CommentTestRepository : ICommentRepository
    {
        public static Dictionary<string, List<CommentModel>> Comments = new Dictionary<string, List<CommentModel>>
        {
            { "58ffd0baa826642823a7fecf", new List<CommentModel> { new CommentModel { Id = "5901571e8e5e548f25d17782", Comment = "Test comment for Card 1" } } }
        };

        public async Task AddCommentToCard(string cardId, CommentModel comment)
        {
            Comments[cardId].Add(comment);
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsForCard(string cardId)
        {
            return Comments[cardId];
        }
    }
}
