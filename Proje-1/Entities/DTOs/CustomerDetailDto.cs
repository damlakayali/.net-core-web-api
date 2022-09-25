using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OrganizationNumber { get; set; }


    }
}
