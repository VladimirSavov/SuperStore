namespace SuperStore.Models.Questions
{
    using SuperStore.Services.Answers.Models;
    using SuperStore.Services.Questions.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class QuestionDetailsWithAnswersModel
    {
        public QuestionDetailsServiceModel Question { get; init; }

        public IEnumerable<AnswerServiceModel> Answers { get; init; }
    }
}
