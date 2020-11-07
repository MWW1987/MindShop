using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductCatagory;
using ShopManagement.Domain.ProductCatagoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCatagoryApplication : IProductCatagoryApplication
    {
        private readonly IProductCatagoryRepository repo;

        public ProductCatagoryApplication(IProductCatagoryRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Create(CreateProductCatagory command)
        {
            var operation = new OperationResult();
            if (repo.Exist(c => c.Name == command.Name))
                return operation.Failed("این نام تکراری است. لطفا نام دیگری انتخاب کنید");
            var slug = command.Slug.Slugify();
            var productCatagory = new ProductCatagory(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            repo.Create(productCatagory);
            repo.SaveChange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCatagory command)
        {
            var operation = new OperationResult();
            var productCatagory = repo.Get(command.Id);
            if (productCatagory == null)
                return operation.Failed("رکوردی یافت نشد");

            if (repo.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("این نام تکراری است. لطفا نام دیگری انتخاب کنید");

            var slug = command.Slug.Slugify();
            productCatagory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt,
                command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            repo.SaveChange();
            return operation.Succedded("ویرایش اطلاعات با موفقیت انجام شد");
        }

        public EditProductCatagory GetDetails(int id)
        {
            return repo.GetDetails(id);
        }

        public List<ProductCatagoryViewModel> Search(ProductCatagorySearchModel searchModel)
        {
            return repo.Search(searchModel);
        }
    }
}