using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity
{
    public class Order
    {
        public int OrderId { get; set; } 
        public int UserId { get; set; } 
        public List<Products> Products { get; set; } 
        public DateTime OrderDate { get; set; } 

    }
}
