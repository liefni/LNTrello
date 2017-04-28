using LNTrello.Filters;
using LNTrello.Models;
using LNTrello.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LNTrello.Controllers
{
    [ServiceExceptionFilter]
    public class CardsController : Controller
    {
        private ICardRepository cardRepository;
        private ICommentRepository commentRepository;

        public CardsController(ICardRepository cardRepository, ICommentRepository commentRepository)
        {
            this.cardRepository = cardRepository;
            this.commentRepository = commentRepository;
        }

        public async Task<ActionResult> Card(string id)
        {
            var card = await cardRepository.GetCardById(id);
            card.Comments = await commentRepository.GetCommentsForCard(id);

            return View(card);
        }

        public async Task<ActionResult> AddComment(string id)
        {
            var card = await cardRepository.GetCardById(id);
            ViewBag.cardName = card.Name;
            ViewBag.Id = id;
            return View(new CommentModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(CommentModel model, string id)
        {
            if (ModelState.IsValid)
            {
                await commentRepository.AddCommentToCard(id, model);
                return RedirectToAction("Card", new { id = id });
            }

            var card = await cardRepository.GetCardById(id);
            ViewBag.CardName = card.Name;
            ViewBag.Id = id;
            return View(model);
        }
    }
}