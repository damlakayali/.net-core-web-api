using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Campaign:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public int campaign_type_id { get; set; }
        public int campaign_conditions_id { get; set; }
        public int campaign_effect_id { get; set; }
        public int[] condition_which_products { get; set; }
        public int discount_rate { get; set; }
        public int condition_product_count { get; set; }
        public int condition_basket_price { get; set; }
        public int[] effect_which_products { get; set; }
        public int effect_product_count { get; set; }
        public string coupon { get; set; }

    }
}
