using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;

namespace LNTrello.Models.Repositories
{
    public class CommentServiceRepository : ICommentRepository
    {
        #region RawModels
        // this region contains models that match the format 
        // of the data as it comes from the webservice
        private class CardAction
        {
            public string Id { get; set; }
            public ActionData Data { get; set; }
        }

        private class ActionData
        {
            public string Text { get; set; }
        }
        #endregion

        readonly IServiceManager serviceManager;

        public CommentServiceRepository(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Adds a comment to the card with the speicified id.
        /// </summary>
        /// <param name="cardId">The id of the card to add the comment to.</param>
        /// <param name="comment">The comment to add.</param>
        public async Task AddCommentToCard(string cardId, CommentModel comment)
        {
            var response = await serviceManager.HttpClient.PostAsJsonAsync(
                string.Format("/1/cards/{0}/actions/comments?{1}", cardId, serviceManager.AuthenticationUrlString), 
                new { text = comment.Comment });

            response.EnsureSuccessStatusCode2();
        }

        /// <summary>
        /// Gets the comments for a card with the specified id.
        /// </summary>
        /// <param name="cardId">The Id of the card to get the comments for.</param>
        /// <returns>A task to get an enumerable of the comments for the specified card.</returns>
        public async Task<IEnumerable<CommentModel>> GetCommentsForCard(string cardId)
        {
            List<CardAction> comments = null;
            var response = await serviceManager.HttpClient.GetAsync(
                string.Format("/1/cards/{0}/actions?filter=commentCard&{1}", cardId, serviceManager.AuthenticationUrlString));

            response.EnsureSuccessStatusCode2();

            comments = await response.Content.ReadAsAsync<List<CardAction>>();
            return comments.Select(c => new CommentModel { Id = c.Id, Comment = c.Data.Text }).ToList();
        }
    }
}