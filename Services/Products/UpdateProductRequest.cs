using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Products
{
    public record  UpdateProductRequest(int id,string name,decimal price,int stock);
    
}
