﻿using _1_MindShopQuery.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationPresentation.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slides = _slideQuery.GetSlides();
            return View(slides);
        }
    }
}