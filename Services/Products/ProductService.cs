using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Products;
using Repositories.Products.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Products
{
    public class ProductService(IProductRepository productRepository,IUnitOfWork unitofwork) : IProductService
    {
        public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count)
        {
            var products = await productRepository.GetTopPrizeProductAsync(count);

            var productAsDto=products.Select(p=>new ProductDto(p.Id,p.Name,p.Price,p.Stock)).ToList();
            return new ServiceResult<List<ProductDto>>()
            {
                Data = productAsDto
            };
        }

        public async Task<ServiceResult<ProductDto?>> GetProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
            {
                ServiceResult<ProductDto>.Fail("Product not found", HttpStatusCode.NotFound);
            }
            var productAsDto = new ProductDto(product.Id, product.Name, product.Price, product.Stock);

            return ServiceResult<ProductDto>.Succses(productAsDto)!;
        }

        public async Task<ServiceResult<List<ProductDto>>> GetAllList()
        {
            var products = await productRepository.GetAll().ToListAsync();

            var productAsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();

            return ServiceResult<List<ProductDto>>.Succses(productAsDto);
        }

        public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.stock,


            };

            await productRepository.Add(product);
            await unitofwork.SaveChangesAsync();
            return ServiceResult<CreateProductResponse>.Succses(new CreateProductResponse(product.Id));

        }

        public async Task<ServiceResult> UpdateProductAync(int id,UpdateProductRequest request)
        {
            var product=await productRepository.GetByIdAsync(id);
            if(product is null)
            {
                return ServiceResult.Fail("not found", HttpStatusCode.NotFound);
            }

            product.Name = request.name;
            product.Price = request.price;
            product.Stock = request.stock;

            await productRepository.Add(product);
            await unitofwork.SaveChangesAsync();

            return ServiceResult.Succses(HttpStatusCode.NoContent);

        }

        public async Task<ServiceResult> DeleteProductAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
            {
                ServiceResult<ProductDto>.Fail("Product not found", HttpStatusCode.NotFound);
            }

            productRepository.Delete(product);
            await unitofwork.SaveChangesAsync();
            return ServiceResult.Succses(HttpStatusCode.NoContent);

        }
    }
}
