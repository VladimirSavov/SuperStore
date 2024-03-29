﻿namespace SuperStore.Models.Products
{
    using SuperStore.Data.Models.Enums;
    using SuperStore.Services.Products.Models;
    using SuperStore.Services.Questions.Models;
    using SuperStore.Services.Reviews.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductsDetailsQueryModel
    {

        public ProductDetailsServiceModel Product { get; set; }

        public IEnumerable<ProductServiceModel> SimilarProducts { get; set; }

        public const int ReviewsPerPage = 9;

        public string ReviewsSearchTerm { get; set; }

        [Display(Name = "Filter")]
        public ReviewType? ReviewFiltering { get; init; }

        public int ReviewsCurrentPage { get; set; } = 1;

        public int TotalReviews { get; set; }


        public const int QuestionsPerPage = 9;

        public int QuestionsCurrentPage { get; set; } = 1;

        public int TotalQuestions { get; set; }


        public ReviewsProductStatisticsServiceModel ProductReviewsStatistics { get; set; }

        public IEnumerable<ReviewServiceModel> Reviews { get; set; }

        public IEnumerable<QuestionServiceModel> Questions { get; set; }



    }
}
