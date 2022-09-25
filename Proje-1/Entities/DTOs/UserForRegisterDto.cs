using Core;
using System;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public int roleId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string deliveryAddress { get; set; }
        public string deliveryZipCode { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public bool type { get; set; }
    }
}
