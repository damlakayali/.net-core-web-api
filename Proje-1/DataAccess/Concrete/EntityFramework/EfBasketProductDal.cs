using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketProductDal: EfEntityRepositoryBase<BasketProduct, ProjectDatabaseContext>, IBasketProductDal
    {
        public List<BasketProduct> GetProducts(int id)
        {
            using(var context= new ProjectDatabaseContext())
            {
                var result = from basketProduct in context.BasketProducts
                             join product in context.Products
                                 on basketProduct.productid equals product.id
                             where basketProduct.basket_id == id
                             select new BasketProduct
                             {
                                 id = basketProduct.id,
                                 basket_id = id,
                                 count = basketProduct.count,
                                 productid = basketProduct.productid,
                                 product= new Product
                                 {
                                     id = basketProduct.productid,
                                     name = product.name,
                                     price = product.price
                                 }
                             };

                return result.ToList();
            }
        }
    }
}
