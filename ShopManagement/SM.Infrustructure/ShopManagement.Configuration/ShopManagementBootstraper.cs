using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.ProductCatagory;
using ShopManagement.Domain.ProductCatagoryAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstraper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IProductCatagoryApplication, ProductCatagoryApplication>();
            service.AddTransient<IProductCatagoryRepository, ProductCatagoryRepository>();
            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
