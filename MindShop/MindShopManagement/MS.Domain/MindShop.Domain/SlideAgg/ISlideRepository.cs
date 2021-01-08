using _0_Framework.Domain;
using MindShop.Application.Contracts.Slide;
using System.Collections.Generic;

namespace MindShop.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<int, Slide>
    {
        EditSlide GetDetails(int id);
        List<SlideViewModel> GetList();
    }
}
