using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Products;

namespace App.API.Controllers
{
    public class ProductsContoller(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var serviceResult = await productService.GetAllList();
            return CreateActionResult(serviceResult);
        }
        [HttpGet("{pagedNumber:int}/{pagedSize:int}")]
        public async Task<IActionResult> GetPagedAll(int pageNumber,int pagedSize)
        {
            var serviceResult = await productService.GetPagedList(pageNumber, pagedSize);
            return CreateActionResult(serviceResult);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var serviceResult = await productService.GetProductByIdAsync(id);
            return CreateActionResult(serviceResult);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var serviceResult = await productService.CreateProductAsync(request);
            return CreateActionResult(serviceResult);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,UpdateProductRequest request)
        {
            var serviceResult = await productService.UpdateProductAync(id,request);
            return CreateActionResult(serviceResult);
        }
        [HttpPatch("stock")]
        public async Task<IActionResult> UpdateStock(UpdateStockProductStockRequest request)
        {
            var serviceResult = await productService.UpdateStockAsyn(request);
            return CreateActionResult(serviceResult);
        }



        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var serviceResult = await productService.DeleteProductAsync(id);
            return CreateActionResult(serviceResult);
        }
    }
}
