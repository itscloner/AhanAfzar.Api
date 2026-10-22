using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.Brand;
using ShopManagment.Application.Contracts.Category;
using ShopManagment.Application.Contracts.Standard;
using ShopManagment.Application.Contracts.Unit;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.BrandAgg;
using ShopManagment.Domain.CategoryAgg;
using ShopManagment.Domain.StandardAgg;
using ShopManagment.Domain.UnitAgg;
using ShopManagment.Infrustructure.EfCore;
using ShopManagment.Infrustructure.EfCore.Repository;

namespace ShopManagment.Infrustructure.Configuration
{
    public class ShopManagmentBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICategoryApplication, CategoryApplication>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IStandardApplication, StandardApplication>();
            services.AddTransient<IStandardRepository, StandardRepository>();

            services.AddTransient<IUnitApplication, UnitApplication>();
            services.AddTransient<IUnitRepository, UnitRepository>();

            services.AddTransient<IBrandApplication, BrandApplication>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddDbContext<ShopManagmentContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
