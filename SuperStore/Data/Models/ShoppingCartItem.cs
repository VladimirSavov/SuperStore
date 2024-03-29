﻿namespace SuperStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class ShoppingCartItem
    {
        public int Id { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public byte Quantity { get; set; }


        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }

        
    }
}
