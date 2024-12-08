using Repositories.Products.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Products
{
    public interface IProductService
    {
        public Task<ServiceResult<List<Product>>> GetTopPriceProductAsync(int count);
    }   
}
