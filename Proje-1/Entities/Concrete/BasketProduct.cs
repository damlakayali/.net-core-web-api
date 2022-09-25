using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BasketProduct:IEntity
    {
        public int id { get; set; }
        public int basket_id { get; set; }
        public int count { get; set; }
        public int productid { get; set; }
        public Product product { get; set; }
    }
}
