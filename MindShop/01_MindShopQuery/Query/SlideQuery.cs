using _01_MindShopQuery.Contracts.Slide;
using MindShop.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_MindShopQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly MindShopContext _shopContext;

        public SlideQuery(MindShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _shopContext.Slides
                .Where(x => x.IsRemoved == false)
                .Select(x => new SlideQueryModel
                {
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    BtnText = x.BtnText,
                    Heading = x.Heading,
                    Link = x.Link,
                    Text = x.Text,
                    Title = x.Title
                }).ToList();
        }
    }
}
