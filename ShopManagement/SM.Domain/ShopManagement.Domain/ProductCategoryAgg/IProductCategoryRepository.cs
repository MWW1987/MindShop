using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _0_Framework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<int, ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        EditProductCategory GetDetails(int id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
