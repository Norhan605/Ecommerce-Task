using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderDetail
    {
        public OrderDetail(Order order, Product product, int quantity)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
        }
        private OrderDetail():this(null!,null!,0)
        {

        }

        //CompositeKey
       
        public int ID { get; set; }
        
       
       public Order Order { get; private set; }
        public Product Product { get;private set; }
        public int Quantity { get; set; }



    }
}
