using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Application.Contract.ProductCatagory;
using ShopManagement.Domain.ProductCatagoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCatagoryRepository: IProductCatagoryRepository
    {
        private readonly ShopContext _context;

        public ProductCatagoryRepository(ShopContext context)
        {
            _context = context;
        }
        public void Create(ProductCatagory entity)
        {
            _context.Add(entity);
        }

        public ProductCatagory Get(int id)
        {
            return _context.ProductCatagories.Find(id);
        }

        public List<ProductCatagory> GetAll()
        {
            return _context.ProductCatagories.ToList();
        }

        public bool Exist(Expression<Func<ProductCatagory, bool>> expression)
        {
            return _context.ProductCatagories.Any(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
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
