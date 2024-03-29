﻿namespace SuperStore.Models.Products
{
    using SuperStore.Data.Models.Enums;
    using SuperStore.Services.Products.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductsQueryModel
    {
        public const int ProductsPerPage = 9;

        public int CurrentPage { get; set; } = 1;

        public string? Category { get; set; }

        public string? SubCategory { get; set; }

        public IEnumerable<ProductCategoryServiceModel>? Categories { get; set; }

        public IEnumerable<ProductSubCategoryServiceModel>? SubCategories { get; set; }


        public string? SearchTerm { get; init; }

        public ProductSorting ProductSorting { get; init; }

        public int TotalProducts { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
    }
}
