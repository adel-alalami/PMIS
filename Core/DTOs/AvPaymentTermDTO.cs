using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class AvPaymentTermDTO
    {
        public int PaymentTermId { get; set; }
        public string PaymentTermTitle { get; set; }
        public decimal PaymentTermAmount { get; set; }
        public string DeliverableName { get; set; }
    }
}
