using _0_Framework.Infrastructure;
using MindShop.Application.Contracts.Slide;
using MindShop.Domain.SlideAgg;
using System.Collections.Generic;
using System.Linq;

namespace MindShop.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<int, Slide>, ISlideRepository
    {
        private readonly MindShopContext _context;

        public SlideRepository(MindShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(int id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Heading = x.Heading,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Link = x.Link,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Heading = x.Heading,
                Picture = x.Picture,
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToString()
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
