namespace SuperStore.Services.Statistics
{
    using SuperStore.Data;
    using SuperStore.Services.Statistics.Models;
    using System.Linq;

    public class StatisticsService : IStatisticsService
    {
        private readonly SuperStoreDbContext data;

        public StatisticsService(SuperStoreDbContext data)
        => this.data = data;


        public StatisticsServiceModel Total()
        {
            var totalProducts = this.data.Products.Count(c=>c.IsPublic);
            var totalUsers = this.data.Users.Count();

            return new StatisticsServiceModel
            {
                TotalProducts = totalProducts,
                TotalUsers = totalUsers,

            };
        }
    }
}

