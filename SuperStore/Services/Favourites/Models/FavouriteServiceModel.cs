﻿namespace SuperStore.Services.Favourites.Models
{
    public class FavouriteServiceModel
    {
        public int Id { get; set; }

        public string ProductId { get; set; }

        public string ProductTitle { get; set; }

        public string ProductCondition { get; set; }

        public int ReviewsCount { get; set; }

        public int QuestionsCount { get; set; }

        public string ImageUrl { get; set; }

        public byte Quantity { get; init; }

        public string Price { get; init; }

        public string ProductDelivery { get; set; }
    }
}
