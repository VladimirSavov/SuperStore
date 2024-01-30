namespace SuperStore.Infrastructure.Profiles
{
    using AutoMapper;
    using SuperStore.Data.Models;
    using SuperStore.Services.Products.Models;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, ProductCategoryServiceModel>();
            this.CreateMap<SubCategory, ProductSubCategoryServiceModel>();
        }
    }
}
