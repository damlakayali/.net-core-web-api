using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Basket:IEntity
    {
        public int id { get; set; }
        public int campaign_id { get; set; }
        public string guid { get; set; }
        public string coupon_code { get; set; }
    }
}
