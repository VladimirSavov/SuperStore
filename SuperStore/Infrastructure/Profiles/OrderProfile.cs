namespace SuperStore.Infrastructure.Profiles
{
    using AutoMapper;
    using SuperStore.Data.Models;
    using SuperStore.Services.Orders.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ProfileConstants;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<Order, OrderServiceModel>()
              .ForMember(x => x.OrderedOn, cfg => cfg.MapFrom(x => x.OrderedOn.ToString(DateTimeFormat)))
              .ForMember(x => x.TotalAmount, cfg => cfg.MapFrom(x => x.ShoppingCart.Sum(x => (decimal)x.Quantity * x.Product.Price).ToString(PriceFormat)));


            this.CreateMap<Order, OrderDetailsServiceModel>()
            .ForMember(x => x.OrderedOn, cfg => cfg.MapFrom(x => x.OrderedOn.ToString(DateTimeFormat)))
            .ForMember(x => x.OrderedItems, cfg => cfg.MapFrom(x => x.ShoppingCart.Sum(x => x.Quantity)))
            .ForMember(x => x.TotalAmount, cfg => cfg.MapFrom(x => x.ShoppingCart.Sum(x => (decimal)x.Quantity * x.Product.Price).ToString(PriceFormat)));


        }
    }
}
