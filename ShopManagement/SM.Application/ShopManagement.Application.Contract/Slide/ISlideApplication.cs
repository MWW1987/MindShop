﻿using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Remove(int id);
        OperationResult Restore(int id);
        EditSlide GetDetails(int id);
        List<SlideViewModel> GetList();
    }
}