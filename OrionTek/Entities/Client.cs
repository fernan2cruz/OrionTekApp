using System;
using System.Collections.Generic;

namespace OrionTek.Entities
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
