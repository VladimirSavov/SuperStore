﻿namespace SuperStore.Models.Answers
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Answer;

    public class AnswerFormModel
    {
        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = "Field {0} must be between {2} and {1} characters long")]
        [Display(Name = "Answer :")]
        public string Content { get; set; }
    }
}
