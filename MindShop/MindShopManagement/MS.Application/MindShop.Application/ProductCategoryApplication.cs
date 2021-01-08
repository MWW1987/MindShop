using _0_Framework.Application;
using MindShop.Application.Contracts.ProductCategory;
using MindShop.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace MindShop.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository repo;

        public ProductCategoryApplication(IProductCategoryRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (repo.Exist(c => c.Name == command.Name))
                return operation.Failed("این نام تکراری است. لطفا نام دیگری انتخاب کنید");
            var slug = command.Slug.Slugify();
            var productCatagory = new ProductCategory(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            repo.Create(productCatagory);
            repo.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = repo.Get(command.Id);
            if (productCategory == null)
                return operation.Failed("رکوردی یافت نشد");

            if (repo.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("این نام تکراری است. لطفا نام دیگری انتخاب کنید");

            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt,
                command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            repo.SaveChange();
            return operation.Succedded("ویرایش اطلاعات با موفقیت انجام شد");
        }

        public EditProductCategory GetDetails(int id)
        {
            return repo.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return repo.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return repo.Search(searchModel);
        }
    }
}
