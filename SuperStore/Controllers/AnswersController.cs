﻿namespace SuperStore.Controllers
{
    using SuperStore.Infrastructure;
    using SuperStore.Models.Answers;
    using SuperStore.Services.Answers;
    using SuperStore.Services.Questions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AnswersController:Controller
    {
        private readonly IAnswerService answers;
        private readonly IQuestionsService questions;

        public AnswersController(IQuestionsService questions, IAnswerService answers)
        {
            this.questions = questions;
            this.answers = answers;
        }

        [Authorize]
        public IActionResult Add(int id,string information)
        {
            var questionModel = this.questions.QuestionById(id);

            if (questionModel == null || questionModel.GetInformation() != information || !(questionModel.IsPublic))
            {
                return NotFound();
            }

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(int id,string information,AnswerFormModel answer)
        {           
            var questionModel = this.questions.QuestionById(id);

            if (questionModel == null || questionModel.GetInformation() != information || !(questionModel.IsPublic))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.View(answer);
            }

            var IsUserAdmin = this.User.IsAdmin();

            this.answers.Create(
                id,
                this.User.Id(),
                answer.Content,
               IsUserAdmin);

            this.TempData[WebConstants.GlobalMessageKey] = $"Your answer was added { (IsUserAdmin ? string.Empty : "and is awaiting for approval!") }";
       
            return RedirectToAction("Details","Questions", new { id = questionModel.Id, information = questionModel.GetInformation() });          
        }    
    }
}
