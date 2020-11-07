using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductCatagory;
using ShopManagement.Domain.ProductCatagoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCatagoryRepository: RepositoryBase<int, ProductCatagory>, IProductCatagoryRepository
    {
        private readonly ShopContext _context;

        public ProductCatagoryRepository(ShopContext context) :base(context)
        {
            _context = context;
        }
        

        

        public EditProductCatagory GetDetails(int id)
        {
            return _context.ProductCatagories.Select(x => new EditProductCatagory
            {
                Id = x.Id,
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCatagoryViewModel> Search(ProductCatagorySearchModel searchModel)
        {
            var query = _context.ProductCatagories.Select(x => new ProductCatagoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToString(),


            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
