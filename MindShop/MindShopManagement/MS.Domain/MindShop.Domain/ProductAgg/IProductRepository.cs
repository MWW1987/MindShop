using _0_Framework.Domain;
using MindShop.Application.Contracts.Product;
using System.Collections.Generic;

namespace MindShop.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<int, Product>
    {
        EditProduct GetDetails(int id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
