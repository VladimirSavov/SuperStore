﻿namespace SuperStore.Areas.Admin.Models.Orders
{
    using SuperStore.Services.Orders.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OrdersQueryModel
    {
        public const int OrdersPerPage = 9;

        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int TotalOrders { get; set; }

        public IEnumerable<OrderServiceModel> Orders { get; set; }
    }
}
