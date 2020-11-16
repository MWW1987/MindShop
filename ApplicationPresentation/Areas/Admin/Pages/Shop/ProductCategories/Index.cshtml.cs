using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCatagory;

namespace ApplicationPresentation.Areas.Admin.Pages.Shop.ProductCatagories
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCatagories;
        public ProductCategorySearchModel SearchModel;
        private readonly IProductCategoryApplication productCatagoryApplication;

        public IndexModel(IProductCategoryApplication productCatagoryApplication)
        {
            this.productCatagoryApplication = productCatagoryApplication;
        }
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCatagories = productCatagoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = productCatagoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var productCatagory = productCatagoryApplication.GetDetails(id);
            return Partial("Edit", productCatagory);
        }
    }
}
