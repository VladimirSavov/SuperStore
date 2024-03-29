﻿namespace SuperStore.Services.ShoppingCarts.Models
{
    public class ShoppingCartItemServiceModel
    {
        public int Id { get; set; }

        public string ProductId { get; set; }

        public string ProductTitle { get; set; }

        public string ProductCondition { get; set; }

        public string ProductDelivery { get; set; }

        public byte ProductQuantity { get; init; }
        
        public byte Quantity { get; init; }

        public string ImageUrl { get; set; }

        public decimal Price { get; init; }

        public string TraderName { get; set; }

        public string TraderTelephoneNumber { get; set; }



    }
}
