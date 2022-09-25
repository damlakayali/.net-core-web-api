using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBasketService
    {
        IDataResult<List<Basket>> GetAll();
        IResult Add(Basket basket);
        IResult Delete(int id);
        IDataResult<Basket> Get(int id);
        IDataResult<Basket> Get2(string guid);
        IResult Update(Basket basket);
    }
}
