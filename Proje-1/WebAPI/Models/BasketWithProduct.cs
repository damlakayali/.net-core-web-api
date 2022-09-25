using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class BasketWithProduct
    {
        public Basket basket { get; set; }
        public List<BasketProduct> products { get; set; }

        public Campaign selectCampaign { get; set; }
        public double totalPrice { get; set; }
        public double totalPriceWithCampaign { get; set; }
    }
}
