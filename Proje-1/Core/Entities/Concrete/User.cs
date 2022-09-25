using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int customerId { get; set; }
        public bool isActive { get; set; }
        public int roleId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string deliveryAddress { get; set; }
        public string deliveryZipCode { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public bool type { get; set; }
        public string resettoken { get; set; }


    }
}
