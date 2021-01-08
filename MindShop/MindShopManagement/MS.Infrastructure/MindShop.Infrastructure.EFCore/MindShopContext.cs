using Microsoft.EntityFrameworkCore;
using MindShop.Domain.ProductAgg;
using MindShop.Domain.ProductCategoryAgg;
using MindShop.Domain.ProductPictureAgg;
using MindShop.Domain.SlideAgg;
using MindShop.Infrastructure.EFCore.Mapping;

namespace MindShop.Infrastructure.EFCore
{
    public class MindShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Slide> Slides { get; set; }

        public MindShopContext(DbContextOptions<MindShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
