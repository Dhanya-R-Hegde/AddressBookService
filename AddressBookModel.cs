using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService
{
    internal class AddressBookModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public long Zip { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        public AddressBookModel()
        {
            this.Id = 0;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Address = string.Empty;
            this.City = string.Empty;
            this.State = string.Empty;
            this.Zip = 0;
            this.PhoneNumber = 0;
            this.Email = string.Empty;
        }
    }
}
