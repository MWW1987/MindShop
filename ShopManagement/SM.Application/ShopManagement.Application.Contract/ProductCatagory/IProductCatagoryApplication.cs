using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCatagory
{
    public interface IProductCatagoryApplication
    {
        OperationResult Create(CreateProductCatagory command);
        OperationResult Edit(EditProductCatagory command);
        Domain.ProductCatagoryAgg.ProductCatagory GetDetails(int id);
        List<ProductCatagoryViewModel> Search(ProductCatagorySearchModel searchModel);
    }
}
