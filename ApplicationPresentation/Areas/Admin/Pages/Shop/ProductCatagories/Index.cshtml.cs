using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCatagory;

namespace ApplicationPresentation.Areas.Admin.Pages.Shop.ProductCatagories
{
    public class IndexModel : PageModel
    {
        public List<ProductCatagoryViewModel> ProductCatagories;
        public ProductCatagorySearchModel SearchModel;
        private readonly IProductCatagoryApplication productCatagoryApplication;

        public IndexModel(IProductCatagoryApplication productCatagoryApplication)
        {
            this.productCatagoryApplication = productCatagoryApplication;
        }
        public void OnGet(ProductCatagorySearchModel searchModel)
        {
            ProductCatagories = productCatagoryApplication.Search(searchModel);
        }
    }
}
