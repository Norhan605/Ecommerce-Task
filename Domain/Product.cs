using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public Guid ID { get; set; }
        [MinLength(3), MaxLength(50)]
        public string Name { get;  set; }
        [MinLength(20), MaxLength(200)]
        public string? Description { get;  set; }
        public float Price { get;  set; }
        [Range(0,100)]
        public byte? DiscountPercentage { get;  set; }
        public int Availabe { get; private set; }


       
        private IList<Category> categories;
        public IEnumerable<Category> Categories { get { return categories; } }

        private readonly IList<OrderDetail> orderDetails;
        public IEnumerable<OrderDetail> OrderDetails { get { return orderDetails; } }
        private IList<Image> images;
        public IEnumerable<Image> Images { get { return images; } }

       
        public Product(string name ,float price , int availabe , string ? description=null, byte? discountPercentage=null) { 
            Name= name;
            Description= description;
            Price= price;
            DiscountPercentage= discountPercentage;
            Availabe= availabe;
            categories= new List<Category>();
            images= new List<Image>();
            orderDetails= new List<OrderDetail>();
            
       
        }
        private Product() : this(null!, 0, 0)
        {

        }
       
        public bool AddSubCategory(Category category)
        {
            var Category = categories.FirstOrDefault(s => s.Name == category.Name);
            if (Category == null)
            {
                categories.Add(category);
                return true;
            }
            else return false;


        }


        public bool AddImages(Image image)
        {
            var Image = images.FirstOrDefault(s => s.Name == image.Name);
            if (Image == null)
            {
                images.Add(image);
                return true;
            }
            else return false;


        }

    }
}
