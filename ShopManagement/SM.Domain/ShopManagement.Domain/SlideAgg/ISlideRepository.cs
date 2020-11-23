using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Slide;
using System.Collections.Generic;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<int, Slide>
    {
        EditSlide GetDetails(int id);
        List<SlideViewModel> GetList();
    }
}
