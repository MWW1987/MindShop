using ShopManagement.Application.Contract.ProductCatagory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductCatagoryAgg
{
    public interface IProductCatagoryRepository
    {
        void Create(ProductCatagory entity);
        ProductCatagory Get(int id);
        List<ProductCatagory> GetAll();
        bool Exist(Expression<Func<ProductCatagory, bool>> expression);
        void SaveChanges();
        EditProductCatagory GetDetails(int id);
        List<ProductCatagoryViewModel> Search(ProductCatagorySearchModel searchModel);
    }
}
