﻿namespace SuperStore.Services.Favourites
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using SuperStore.Data;
    using SuperStore.Data.Models;
    using SuperStore.Services.Favourites.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class FavouriteService : IFavouriteService
    {
        private readonly SuperStoreDbContext data;

        private readonly IConfigurationProvider mapper;

        public FavouriteService(SuperStoreDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public void Add(string productId, string userId)
        {
            var favourite = new Favourite
            {
                ProductId = productId,
                UserId = userId
            };

            this.data.Favourites.Add(favourite);

            this.data.SaveChanges();

        }

        public IEnumerable<FavouriteServiceModel> Mine(string userId)
        => this.data.Favourites.Where(x => x.UserId == userId)
            .ProjectTo<FavouriteServiceModel>(mapper)
            .ToList();

        public bool Delete(int id)
        {
            var favourite = this.data.Favourites.Find(id);

            if (favourite == null)
            {
                return false;
            }

            this.data.Favourites.Remove(favourite);

            this.data.SaveChanges();

            return true;

        }

        public bool IsFavouriteByUser(int id, string userId)
         => this.data.Favourites.Any(x => x.Id == id && x.UserId == userId);

        public bool IsFavouriteExists(string productId, string userId)
        => this.data.Favourites.Any(x => x.ProductId == productId && x.UserId == userId);


    }
}
