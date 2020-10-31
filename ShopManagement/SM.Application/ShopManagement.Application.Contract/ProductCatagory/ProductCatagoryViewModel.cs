namespace ShopManagement.Application.Contract.ProductCatagory
{
    public class ProductCatagoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string CreationDate { get; set; }
        public int ProductCount { get; set; }

    }
}
