using Dtos.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Category
{
    public class CategoryDetailsDto
    {
     
        public int ID { get; set; }
        
        public string Name { get; set; }
        
       
        public IEnumerable<ProductMinimalDto>? Products { get; set; }
       
        public CategoryMinimalDto? ParentCategory { get; set; }
        
        public IEnumerable<CategoryMinimalDto>? SubCategories { get; set; }

        public CategoryDetailsDto(int iD, string name, IEnumerable<ProductMinimalDto>? products=null, CategoryMinimalDto? parentCategory=null, IEnumerable<CategoryMinimalDto>? subCategories=null)
        {
            ID = iD;
            Name = name;
            Products = products;
            ParentCategory = parentCategory;
            SubCategories = subCategories;
        }

      
    }
}
