using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindShop.Application.Contracts.ProductPicture
{
    public class EditProductPicture : CreateProductPicture
    {
        public int Id { get; set; }
    }
}
