﻿namespace SuperStore.Areas.Admin.Controllers
{
    using SuperStore.Areas.Admin.Models.Comments;
    using SuperStore.Services.Comments;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController:AdminController
    {
        private readonly ICommentService comments;

        public CommentsController(ICommentService comments)
        {
            this.comments = comments;
        }

        public IActionResult All([FromQuery] CommentsQueryModel query)
        {
            var queryResult = this.comments.All(
            query.SearchTerm,
            query.CurrentPage,
            CommentsQueryModel.CommentsPerPage,
            IsPublicOnly: false);

            query.Comments = queryResult.Comments;
            query.TotalComments = queryResult.TotalComments;

            return this.View(query);
        }

        public IActionResult ChangeVisibility(int id)
        {
            this.comments.ChangeVisibility(id);

            return RedirectToAction(nameof(All));
        }
      
        public IActionResult Delete(int id)
        {
            var deleted = this.comments.Delete(id);

            if (!deleted)
            {

                return NotFound();

            }

            this.TempData[WebConstants.GlobalMessageKey] = "Comment was deleted successfully!";

            return RedirectToAction(nameof(All));
        }
    }
}
