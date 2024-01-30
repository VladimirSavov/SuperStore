namespace SuperStore.Areas.Admin.Models.Orders
{
    using SuperStore.Services.Orders.Models;
    using SuperStore.Services.ShoppingCarts.Models;
    using System.Collections.Generic;

    public class OrderDetailsModel
    {
        public OrderDetailsServiceModel Order { get; set; }

        public IEnumerable<ShoppingCartItemServiceModel> OrderItems { get; set; }

    }
}
