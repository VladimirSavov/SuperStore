namespace SuperStore.Services.Traders
{
    using SuperStore.Data;
    using SuperStore.Data.Models;
    using System.Linq;

    public class TraderService : ITraderService
    {
        private readonly SuperStoreDbContext data;

        public TraderService(SuperStoreDbContext data)
        {
            this.data = data;
        }

        public void Create(string userId, string name, string telephoneNumber)
        {
            var trader = new Trader
            {
                Name = name,
                TelephoneNumber =telephoneNumber,
                UserId = userId
            };

            data.Traders.Add(trader);

            data.SaveChanges();
        }

        public string IdByUser(string userId)
        => this.data.Traders
                .Where(x => x.UserId == userId)
                .Select(x => x.Id)
                .FirstOrDefault();

        public bool IsUserTrader(string userId)
        => this.data.Traders.Any(x=>x.UserId==userId);

        public string TelephoneNumberByUser(string userId)
        => this.data.Traders
            .Where(x => x.UserId == userId)
            .Select(x => x.TelephoneNumber)
            .FirstOrDefault();
    }
}
