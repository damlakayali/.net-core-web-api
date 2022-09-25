using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BasketProductManager : IBasketProductService
    {
        IBasketProductDal _basketProductDal;

        public BasketProductManager(IBasketProductDal basketProductDal)
        {
            _basketProductDal = basketProductDal;
        }
        public IResult Add(BasketProduct product)
        {
            _basketProductDal.Add(product);

            return new SuccessResult("Added");
        }

        public IResult Delete(BasketProduct product)
        {
            _basketProductDal.Delete(product);

            return new SuccessResult("Deleted.");
        }

        public IDataResult<BasketProduct> Get(int id)
        {
            return new SuccessDataResult<BasketProduct>(_basketProductDal.Get(a => a.id == id), "Basket");
        }


        public IDataResult<List<BasketProduct>> GetAllByBasket(string id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BasketProduct>> GetAllByBasket(int id)
        {
            throw new NotImplementedException();
        }

        public List<BasketProduct> GetProducts(int id)
        {
            return _basketProductDal.GetProducts(id);
        }
    }
}
