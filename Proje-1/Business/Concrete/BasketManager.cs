using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }
        public IResult Add(Basket basket)
        {
            _basketDal.Add(basket);

            return new SuccessResult(basket.guid + " nolu sepet oluşturuldu.");
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Basket> Get(int id)
        {
            return new SuccessDataResult<Basket>(_basketDal.Get(a => a.id == id), "Basket");
        }

        public IDataResult<Basket> Get2(string guid)
        {
            return new SuccessDataResult<Basket>(_basketDal.Get(a => a.guid == guid), "Basket");
        }

        public IDataResult<List<Basket>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Basket basket)
        {
            _basketDal.Update(basket);

            return new SuccessResult("Updated");
        }
    }
}
