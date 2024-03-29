﻿namespace SuperStore.Services.Questions.Models
{
    public class QuestionServiceModel : IQuestionModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public bool IsPublic { get; set; }

        public string ProductTitle { get; set; }

        public int ProductCondition { get; set; }

        public string PublishedOn { get; set; }

        public int AnswersCount { get; set; }

    }
}
