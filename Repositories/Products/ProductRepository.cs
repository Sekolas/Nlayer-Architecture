using Microsoft.EntityFrameworkCore;
using Repositories.Products.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public async Task<List<Product>> GetTopPrizeProductAsync(int count)
        {
           return await context.Products.OrderByDescending(x=>x.Price).Take(count).ToListAsync();
        }
    }
}
