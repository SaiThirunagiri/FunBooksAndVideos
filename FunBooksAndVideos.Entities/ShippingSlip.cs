using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Entities
{
    public class ShippingSlip
    {
        public int Shipmentnumber { get; set; }
        public string? ShippingAddress { get; set; }

        public DateTime  ShippingDate { get; set; }

        public int InvoiceNumber { get; set; }

        public string? CustomerName { get; set; }
    }
}
