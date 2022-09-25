using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class BasketModel
    {
        public string message { get; set; }
        public Basket value { get; set; }
    }
}
