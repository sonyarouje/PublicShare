using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM.Domain
{
    public class Customer
    {
        public int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual string ContactNumber { get; set; }
    }
}
