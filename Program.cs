using CoinWeb.Models;

namespace CoinWeb
{
    public class Program
    {
        internal static IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath (Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add service for caching
            builder.Services.AddMemoryCache();

            builder.Services.AddOutputCache();

            builder.Services.AddSqlServer<ApplicationContext>
                (
                configuration.GetConnectionString("DefaultConnection")
                );
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseOutputCache();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
