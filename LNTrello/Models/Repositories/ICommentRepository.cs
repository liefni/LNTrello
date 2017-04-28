using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LNTrello.Models.Repositories
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Specifies a method to get  the comments for a card with the specified id.
        /// </summary>
        /// <param name="cardId">The Id of the card to get the comments for.</param>
        /// <returns>A task to get an enumerable of the comments for the specified card.</returns>
        Task<IEnumerable<CommentModel>> GetCommentsForCard(string cardId);

        /// <summary>
        /// Specifies a method to add a comment to the card with the speicified id.
        /// </summary>
        /// <param name="cardId">The id of the card to add the comment to.</param>
        /// <param name="comment">The comment to add.</param>
        Task AddCommentToCard(string cardId, CommentModel comment);
    }
}