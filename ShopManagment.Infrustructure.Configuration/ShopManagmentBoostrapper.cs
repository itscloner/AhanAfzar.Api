using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.Contracts.ProductStandard;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Domain.ProductStandardAgg;
using ShopManagment.Infrustructure.EfCore;
using ShopManagment.Infrustructure.EfCore.Repository;

namespace ShopManagment.Infrustructure.Configuration
{
    public class ShopManagmentBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductStandardApplication, ProductStandardApplication>();
            services.AddTransient<IProductStandardRepository, ProductStandardRepository>();


            services.AddDbContext<ShopManagmentContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
