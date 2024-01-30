namespace SuperStore.Services.Users
{
    using SuperStore.Data;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly SuperStoreDbContext data;

        public UserService(SuperStoreDbContext data)
        {
            this.data = data;
        }

        public string GetFullName(string userId)
        => this.data.Users
            .Where(x => x.Id == userId)
            .Select(x => x.FullName)
            .FirstOrDefault();
    }
}
