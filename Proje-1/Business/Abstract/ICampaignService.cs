using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        IDataResult<List<Campaign>> GetAll();
        IResult Add(Campaign campaing);
        IResult Delete(int id);
        IDataResult<Campaign> Get(int id);
    }
}
