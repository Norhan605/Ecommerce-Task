using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IProductRepository:IRepository<Product,Guid>
    {
       Task <IEnumerable<Product>> FilterByAsync(string? filter=null,int? fromPrice = null, int? toPrice = null, bool? isAvailabe = null, bool? hasDiscount = null,int? categoryId=null);
    }
}
