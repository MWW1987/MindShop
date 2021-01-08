using _01_MindShopQuery.Contracts.Slide;
using _01_MindShopQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MindShop.Application;
using MindShop.Application.Contracts.Product;
using MindShop.Application.Contracts.ProductCategory;
using MindShop.Application.Contracts.ProductPicture;
using MindShop.Application.Contracts.Slide;
using MindShop.Domain.ProductAgg;
using MindShop.Domain.ProductCategoryAgg;
using MindShop.Domain.ProductPictureAgg;
using MindShop.Domain.SlideAgg;
using MindShop.Infrastructure.EFCore;
using MindShop.Infrastructure.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindShop.Configuration
{
    public class MindShopManagementBootstraper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            service.AddTransient<ISlideApplication, SlideApplication>();
            service.AddTransient<ISlideRepository, SlideRepository>();
            service.AddTransient<ISlideQuery, SlideQuery>();
            service.AddDbContext<MindShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
