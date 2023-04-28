using Application.Contracts;
using Domain;
using InfaStructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfaStructure
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }

        public Task<IEnumerable<Category>> FilterByAsync(string? filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
