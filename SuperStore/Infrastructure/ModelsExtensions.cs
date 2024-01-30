namespace SuperStore.Infrastructure
{
    using SuperStore.Data.Models;
    using SuperStore.Services.Favourites.Models;
    using SuperStore.Services.Questions.Models;
    using SuperStore.Services.Reviews.Models;
    using System;
    using System.Linq;

    public static class ModelsExtensions
    {

        public static string GetInformation(this IReviewModel model)
        => String.Concat(model.Title + "-" + model.Rating + "-" + model.PublishedOn);

        public static string GetInformation(this IQuestionModel model)
        => String.Concat(model.ProductCondition + "-" + model.PublishedOn + "-" + new string(model.Content.Take(5).ToArray()));



    }
}
