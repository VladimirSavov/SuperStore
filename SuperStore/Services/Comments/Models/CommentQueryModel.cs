﻿namespace SuperStore.Services.Comments.Models
{
    using SuperStore.Services.Answers.Models;
    using System.Collections.Generic;

    public class CommentQueryModel
    {
        public int CurrentPage { get; init; }

        public int CommentsPerPage { get; init; }

        public int TotalComments { get; init; }

        public IEnumerable<CommentServiceModel> Comments { get; init; }
    }
}
