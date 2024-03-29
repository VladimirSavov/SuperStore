﻿namespace SuperStore.Controllers
{
    using SuperStore.Infrastructure;
    using SuperStore.Services.Orders;
    using SuperStore.Services.Orders.Models;
    using SuperStore.Services.ShoppingCarts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using static WebConstants;

    public class OrdersController:Controller
    {
        private readonly IShoppingCartService shoppingCarts;
        private readonly IOrderService orders;

        public OrdersController(IShoppingCartService shoppingCarts, IOrderService orders)
        {
            this.shoppingCarts = shoppingCarts;
            this.orders = orders;
        }

        [Authorize]
        public IActionResult Add()
        {
            var shoppingCartErrorsMessages = this.shoppingCarts
                .ValidateShoppingCartOfUser(this.User.Id());

            if (shoppingCartErrorsMessages.Any())
            {
                this.TempData[GlobalErrorMessageKey] = shoppingCartErrorsMessages;

                return RedirectToAction(nameof(ShoppingCartController.Mine), "ShoppingCart");
            }

            var orderFormModel = this.orders.GetOrderAddFormModel(this.User.Id());

            return View(orderFormModel);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Add(OrderFormServiceModel order)
        {
            var shoppingCartErrorsMessages = this.shoppingCarts
                .ValidateShoppingCartOfUser(this.User.Id());

            if (shoppingCartErrorsMessages.Any())
            {
                this.TempData[GlobalErrorMessageKey] = shoppingCartErrorsMessages;

                return RedirectToAction(nameof(ShoppingCartController.Mine), "ShoppingCart");
            }

            if (!ModelState.IsValid)
            {
                return View(order);
            }

            this.orders.Add(
                order.FullName,
                order.TelephoneNumber,
                order.State,
                order.City,
                order.Address,
                order.ZipCode,
                this.User.Id());

            this.TempData[GlobalMessageKey] = "Your order was created succesfully and it is awaiting for accomplish!";

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
