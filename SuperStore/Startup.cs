namespace SuperStore
{
    using SuperStore.Data;
    using SuperStore.Data.Models;
    using SuperStore.Infrastructure;
    using SuperStore.Services.Answers;
    using SuperStore.Services.Comments;
    using SuperStore.Services.Favourites;
    using SuperStore.Services.Orders;
    using SuperStore.Services.Products;
    using SuperStore.Services.Questions;
    using SuperStore.Services.Reports;
    using SuperStore.Services.Reviews;
    using SuperStore.Services.ShoppingCarts;
    using SuperStore.Services.Statistics;
    using SuperStore.Services.Traders;
    using SuperStore.Services.Users;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<SuperStoreDbContext>(options => options
                  .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddDatabaseDeveloperPageExceptionFilter();

            services
                .AddDefaultIdentity<User>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SuperStoreDbContext>();

            services
                .AddControllersWithViews(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddAutoMapper(typeof(Startup));
            services.AddMemoryCache();

            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ITraderService, TraderService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IReportsService, ReportsService>();
            services.AddTransient<IQuestionsService, QuestionsService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IFavouriteService, FavouriteService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultAreaRoute();

                    endpoints.MapReviewsDetailsRoute();
                    endpoints.MapQuestionsDetailsRoute();

                    endpoints.MapAnswersAddRoute();
                    endpoints.MapCommentsAddRoute();

                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                });
        }
    }
}
