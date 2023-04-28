using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public int ID { get; set; }

        public DateTimeOffset PurchaseDate { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        public User User { get; set; }
    }
}
