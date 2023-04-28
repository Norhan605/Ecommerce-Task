using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public int ID { get; set; }
        [MinLength(3),MaxLength(50)]
        public string Name { get; set; }
        //public Image Image { get; set; }
        public readonly IList<Product> products;
        public IEnumerable<Product> Products
        {
            get { return products;}}
        //selfRelation
        public  Category? ParentCategory { get; set; }
        private readonly IList<Category> subCategories;
        public  IEnumerable<Category>? SubCategories { get { return subCategories; } }

        public Category(int id, string name , Category?parentCategory=null)
        { 
            ID = id;
            products = new List<Product>();
            ParentCategory = parentCategory;
            Name = name;
            subCategories= new List<Category>();
           // Image=image;
        }
        private Category() : this(0, null!, null )
        {
          

        }

        public bool AddSubCategory(Category subcategory)
        {
            var Category = subCategories.FirstOrDefault(s=>s.Name == subcategory.Name);
            if (Category == null)
            {
                subCategories.Add(subcategory);
                return true;
            }
            else return false;

        
        }

        public bool AddProductItem(Product product)
        {
            var ProductItem = products.FirstOrDefault(s=>s.Name == product.Name);
            if (ProductItem == null)
            {
                products.Add(product);
                return true;
            }
            else return false;
        }


    }
}
