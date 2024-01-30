namespace SuperStore.Infrastructure.Profiles
{
    using AutoMapper;
    using SuperStore.Data.Models;
    using SuperStore.Data.Models.Enums;
    using SuperStore.Models.Reviews;
    using SuperStore.Services.Comments.Models;
    using SuperStore.Services.Reviews.Models;
    using System;
    using System.Linq;

    using static ProfileConstants;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            this.CreateMap<Review, ReviewListingServiceModel>()
                 .ForMember(x => x.Rating, cfg => cfg.MapFrom(x => (int)x.Rating))
                 .ForMember(x => x.TotalComments, cfg => cfg.MapFrom(x => x.Comments.Count(c => c.IsPublic)))
                 .ForMember(x => x.PublishedOn, cfg => cfg.MapFrom(x => x.PublishedOn.ToString(DateTimeFormat)))
                 .ForMember(x => x.ProductImage, cfg => cfg.MapFrom(x => x.Product.Images.Select(x => x.ImageUrl).FirstOrDefault())
                 );

            this.CreateMap<Review, ReviewServiceModel>()
                .ForMember(x => x.Rating, cfg => cfg.MapFrom(x => (int)x.Rating))
                .ForMember(x => x.UserName, cfg => cfg.MapFrom(x => x.User.FullName))
                .ForMember(x => x.TotalComments, cfg => cfg.MapFrom(x => x.Comments.Count(c => c.IsPublic)))
                .ForMember(x => x.PublishedOn, cfg => cfg.MapFrom(x => x.PublishedOn.ToString(DateTimeFormat)));


            this.CreateMap<Review, ReviewDetailsServiceModel>()
                .ForMember(x => x.Rating, cfg => cfg.MapFrom(x => (int)x.Rating))
                .ForMember(x => x.ProductPrice, cfg => cfg.MapFrom(x => x.Product.Price.ToString(PriceFormat)))
                .ForMember(x => x.UserName, cfg => cfg.MapFrom(x => x.User.FullName))
                .ForMember(x => x.PublishedOn, cfg => cfg.MapFrom(x => x.PublishedOn.ToString(DateTimeFormat)))
                .ForMember(x => x.ProductImage, cfg => cfg.MapFrom(x => x.Product.Images.Select(x => x.ImageUrl).FirstOrDefault()));

            this.CreateMap<ReviewDetailsServiceModel, ReviewFormModel>()
                .ForMember(x => x.Rating, cfg => cfg.MapFrom(x => (ReviewType)x.Rating));

        }
    }
}
