using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity
{
    public class Electronics: Products
    {
        public string Brand { get; set; }
        public int WarrantyPeriod { get; set; }
    }
}
