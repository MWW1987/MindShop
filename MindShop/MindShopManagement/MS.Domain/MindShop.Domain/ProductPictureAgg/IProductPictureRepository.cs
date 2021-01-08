using _0_Framework.Domain;
using MindShop.Application.Contracts.ProductPicture;
using System.Collections.Generic;

namespace MindShop.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<int, ProductPicture>
    {
        EditProductPicture GetDetails(int id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
