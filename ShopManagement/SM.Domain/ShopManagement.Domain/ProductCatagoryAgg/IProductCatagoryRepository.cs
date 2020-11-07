using ShopManagement.Application.Contract.ProductCatagory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _0_Framework.Domain;

namespace ShopManagement.Domain.ProductCatagoryAgg
{
    public interface IProductCatagoryRepository:IRepository<int, ProductCatagory>
    {
        EditProductCatagory GetDetails(int id);
        List<ProductCatagoryViewModel> Search(ProductCatagorySearchModel searchModel);
    }
}
