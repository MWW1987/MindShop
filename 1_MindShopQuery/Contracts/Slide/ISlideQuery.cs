using System.Collections.Generic;

namespace _1_MindShopQuery.Contracts.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
