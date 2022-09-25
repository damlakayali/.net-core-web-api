using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        ICampaingDal _campaingDal;

        public CampaignManager(ICampaingDal campaingDal)
        {
            _campaingDal = campaingDal;
        }
        public IResult Add(Campaign campaing)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Campaign> Get(int id)
        {
            return new SuccessDataResult<Campaign>(_campaingDal.Get(a => a.id == id), "Campaign");
        }

        public IDataResult<List<Campaign>> GetAll()
        {
            return new SuccessDataResult<List<Campaign>>(_campaingDal.GetAll(), "All Campaign");
        }
    }
}
