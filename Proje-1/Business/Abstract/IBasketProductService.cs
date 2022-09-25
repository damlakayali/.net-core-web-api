using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBasketProductService
    {
        IDataResult<List<BasketProduct>> GetAllByBasket(int id);
        IResult Add(BasketProduct product);
        IResult Delete(BasketProduct product);
        IDataResult<BasketProduct> Get(int id);
        List<BasketProduct> GetProducts(int id);
    }
}
