using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Entities
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public string? Address { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Customer other = (Customer)obj;
            return CustomerId == other.CustomerId && Name == other.Name && Address == other.Address;
        }

    }
}
