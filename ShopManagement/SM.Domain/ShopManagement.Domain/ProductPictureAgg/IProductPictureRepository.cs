using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductPicture;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<int, ProductPicture>
    {
        EditProductPicture GetDetails(int id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
