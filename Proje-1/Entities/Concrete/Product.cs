using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
    }
}
