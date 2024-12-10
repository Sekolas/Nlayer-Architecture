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
        public Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count);
        public  Task<ServiceResult<ProductDto?>> GetProductByIdAsync(int id);

        public  Task<ServiceResult<List<ProductDto>>> GetAllList();

        public Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);

        public  Task<ServiceResult> UpdateProductAync(int id, UpdateProductRequest request);

        public  Task<ServiceResult> DeleteProductAsync(int id);
    }   
}
