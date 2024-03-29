﻿namespace SuperStore.Areas.Admin.Controllers
{
    using SuperStore.Areas.Admin.Models.Answers;
    using SuperStore.Services.Answers;
    using Microsoft.AspNetCore.Mvc;

    public class AnswersController:AdminController
    {
        private readonly IAnswerService answers;

        public AnswersController(IAnswerService answers)
        {
            this.answers = answers;
        }

        public IActionResult All([FromQuery] AnswersQueryModel query)
        {
            var queryResult = this.answers.All(
            query.SearchTerm,
            query.CurrentPage,
            AnswersQueryModel.AnswersPerPage,
            IsPublicOnly: false);

            query.Answers = queryResult.Answers;
            query.TotalAnswers = queryResult.TotalAnswers;

            return this.View(query);
        }

        public IActionResult ChangeVisibility(int id)
        {
            this.answers.ChangeVisibility(id);

            return RedirectToAction(nameof(All));
        }
    
        public IActionResult Delete(int id)
        {
            var deleted= this.answers.Delete(id); 

            if (!deleted)
            {
                return NotFound();
            }

            this.TempData[WebConstants.GlobalMessageKey] = "Answer was deleted successfully!";

            return RedirectToAction(nameof(All));
        }
    }
}
